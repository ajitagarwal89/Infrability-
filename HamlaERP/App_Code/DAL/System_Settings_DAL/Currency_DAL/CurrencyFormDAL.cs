using System;
using System.Data.SqlClient;
using System.Data;
using log4net;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.SessionState;
using System.Web;
using Finware;

/// <summary>
/// Summary description for CurrencyFormDAL
/// </summary>
public class CurrencyFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
  
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public CurrencyFormDAL()
	{
        try
        {
            GlobalConfigurations objConfig = new GlobalConfigurations();
            objConfig.InitilizeConnectionString();
            connectionString = objConfig.connectionString;
            commandTimeout = Convert.ToInt32(objConfig.commandTimeout);
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "CurrencyFormDAL()";
            logExcpUIobj.ResourceName = "CurrencyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[CurrencyFormDAL : CurrencyFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetCurrencyListById(CurrencyFormUI currencyFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Currency_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = currencyFormUI.Tbl_CurrencyId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl = ds.Tables[0];
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_Currency", currencyFormUI.Tbl_CurrencyId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getCurrencyListById()";
            logExcpUIobj.ResourceName = "CurrencyFormDAL.CS";
            logExcpUIobj.RecordId = currencyFormUI.Tbl_CurrencyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CurrencyFormDAL : getCurrencyListById] An error occured in the processing of Record Id : " + currencyFormUI.Tbl_CurrencyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddCurrency(CurrencyFormUI currencyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Currency_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = currencyFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = currencyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CurrencyCode"].Value = currencyFormUI.CurrencyCode;

                sqlCmd.Parameters.Add("@CurrencyName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CurrencyName"].Value = currencyFormUI.CurrencyName;

                sqlCmd.Parameters.Add("@Tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_CountryId"].Value = currencyFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_CurrencyId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_CurrencyId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_Currency";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(currencyFormUI);
                    audit_IUD.WebServiceInsert(currencyFormUI.Tbl_OrganizationId, tableName, RecoredID, currencyFormUI.CreatedBy, newValue);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddCurrency()";
            logExcpUIobj.ResourceName = "CurrencyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            
            log.Error("[CurrencyFormDAL : AddCurrency] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateCurrency(CurrencyFormUI currencyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Currency_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = currencyFormUI.ModifiedBy;
                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = currencyFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = currencyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@CurrencyCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CurrencyCode"].Value = currencyFormUI.CurrencyCode;

                sqlCmd.Parameters.Add("@CurrencyName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CurrencyName"].Value = currencyFormUI.CurrencyName;

                sqlCmd.Parameters.Add("@Tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_CountryId"].Value = currencyFormUI.Tbl_CountryId;
                
                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(currencyFormUI);
                    audit_IUD.WebServiceUpdate(currencyFormUI.Tbl_OrganizationId, "tbl_Currency", currencyFormUI.Tbl_CurrencyId, currencyFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateCurrency()";
            logExcpUIobj.ResourceName = "CurrencyFormDAL.CS";
            logExcpUIobj.RecordId = currencyFormUI.Tbl_CurrencyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CurrencyFormDAL : UpdateCurrency] An error occured in the processing of Record Id : " + currencyFormUI.Tbl_CurrencyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteCurrency(CurrencyFormUI currencyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Currency_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = currencyFormUI.Tbl_CurrencyId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_Currency", currencyFormUI.Tbl_CurrencyId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteCurrency()";
            logExcpUIobj.ResourceName = "CurrencyFormDAL.CS";
            logExcpUIobj.RecordId = currencyFormUI.Tbl_CurrencyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CurrencyFormDAL : DeleteCurrency] An error occured in the processing of Record Id : " + currencyFormUI.Tbl_CurrencyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}