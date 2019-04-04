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
/// Summary description for GLAccountCurrencyFormDAL
/// </summary>
public class GLAccountCurrencyFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


    public GLAccountCurrencyFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountCurrencyFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountCurrencyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountCurrencyFormDAL : GLAccountCurrencyFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetGLAccountCurrencyListById(GLAccountCurrencyFormUI gLAccountCurrencyFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountCurrency_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountCurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountCurrencyId"].Value = gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId;

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
                audit_IUD.WebServiceSelectInsert("tbl_GLAccountCurrency", gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getGLAccountCurrencyListById()";
            logExcpUIobj.ResourceName = "GLAccountCurrencyFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountCurrencyFormDAL : getGLAccountCurrencyListById] An error occured in the processing of Record Id : " + gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGLAccountCurrency(GLAccountCurrencyFormUI gLAccountCurrencyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountCurrency_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountCurrencyFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountCurrencyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = gLAccountCurrencyFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = gLAccountCurrencyFormUI.Tbl_CurrencyId;


                sqlCmd.Parameters.Add("@tbl_GLAccountCurrencyId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_GLAccountCurrencyId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_GLAccountCurrencyId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_GLAccountCurrency";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(gLAccountCurrencyFormUI);
                    audit_IUD.WebServiceInsert(gLAccountCurrencyFormUI.Tbl_OrganizationId, tableName, recordID, gLAccountCurrencyFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddGLAccountCurrency()";
            logExcpUIobj.ResourceName = "GLAccountCurrencyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountCurrencyFormDAL : AddGLAccountCurrency] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccountCurrency(GLAccountCurrencyFormUI gLAccountCurrencyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountCurrency_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;


                sqlCmd.Parameters.Add("@tbl_GLAccountCurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountCurrencyId"].Value = gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountCurrencyFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountCurrencyFormUI.Tbl_OrganizationId;


                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = gLAccountCurrencyFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = gLAccountCurrencyFormUI.Tbl_CurrencyId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(gLAccountCurrencyFormUI);
                    audit_IUD.WebServiceUpdate(gLAccountCurrencyFormUI.Tbl_OrganizationId, "tbl_GLAccountCurrency", gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId, gLAccountCurrencyFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountCurrency()";
            logExcpUIobj.ResourceName = "GLAccountCurrencyFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountCurrencyFormDAL : UpdateGLAccountCurrency] An error occured in the processing of Record Id : " + gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGLAccountCurrency(GLAccountCurrencyFormUI gLAccountCurrencyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountCurrency_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountCurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountCurrencyId"].Value = gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_GLAccountCurrency", gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountCurrency()";
            logExcpUIobj.ResourceName = "GLAccountCurrencyFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountCurrencyFormDAL : DeleteGLAccountCurrency] An error occured in the processing of Record Id : " + gLAccountCurrencyFormUI.Tbl_GLAccountCurrencyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}