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
/// Summary description for POBasedInvoiceDistributionFormDAL 
/// </summary>
public class POBasedInvoiceDistributionFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public POBasedInvoiceDistributionFormDAL()
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
            logExcpUIobj.MethodName = "POBasedInvoiceDistributionFormDAL()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[POBasedInvoiceDistributionFormDAL : POBasedInvoiceDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetPOBasedInvoiceDistributionListById(POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceDistributionId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;

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
                audit_IUD.WebServiceSelectInsert("tbl_POBasedInvoiceDistribution", pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId, selectedValue);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getPOBasedInvoiceDistributionListById()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDistributionFormDAL : getPOBasedInvoiceDistributionListById] An error occured in the processing of Record Id : " + pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPOBasedInvoiceDistribution(POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = pOBasedInvoiceDistributionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_GLAccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_GLAccountType"].Value = pOBasedInvoiceDistributionFormUI.opt_GLAccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = pOBasedInvoiceDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = pOBasedInvoiceDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = pOBasedInvoiceDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = pOBasedInvoiceDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = pOBasedInvoiceDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = pOBasedInvoiceDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@ExchangeRate", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExchangeRate"].Value = pOBasedInvoiceDistributionFormUI.ExchangeRate;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceDistributionId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_POBasedInvoiceDistributionId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_POBasedInvoiceDistributionId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_POBasedInvoiceDistribution";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(pOBasedInvoiceDistributionFormUI);
                    audit_IUD.WebServiceInsert(pOBasedInvoiceDistributionFormUI.Tbl_OrganizationId, tableName, RecoredID, pOBasedInvoiceDistributionFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddPOBasedInvoiceDistribution()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDistributionFormDAL : AddPOBasedInvoiceDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePOBasedInvoiceDistribution(POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = pOBasedInvoiceDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceDistributionId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_GLAccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_GLAccountType"].Value = pOBasedInvoiceDistributionFormUI.opt_GLAccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = pOBasedInvoiceDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = pOBasedInvoiceDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = pOBasedInvoiceDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = pOBasedInvoiceDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = pOBasedInvoiceDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = pOBasedInvoiceDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@ExchangeRate", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExchangeRate"].Value = pOBasedInvoiceDistributionFormUI.ExchangeRate;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(pOBasedInvoiceDistributionFormUI);
                    audit_IUD.WebServiceUpdate(pOBasedInvoiceDistributionFormUI.Tbl_OrganizationId, "tbl_POBasedInvoiceDistribution", pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId, pOBasedInvoiceDistributionFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePOBasedInvoiceDistribution()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDistributionFormDAL : UpdatePOBasedInvoiceDistribution] An error occured in the processing of Record Id : " + pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePOBasedInvoiceDistribution(POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceDistributionId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_POBasedInvoiceDistribution", pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePOBasedInvoiceDistribution()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDistributionFormDAL : DeletePOBasedInvoiceDistribution] An error occured in the processing of Record Id : " + pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}