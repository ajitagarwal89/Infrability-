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
/// Summary description for DownPaymentFromCustomerDistributionFormDAL
/// </summary>
public class DownPaymentFromCustomerDistributionFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public DownPaymentFromCustomerDistributionFormDAL()
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
            logExcpUIobj.MethodName = "DownPaymentFromCustomerDistributionFormDAL()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[DownPaymentFromCustomerDistributionFormDAL : DownPaymentFromCustomerDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetDownPaymentFromCustomerDistributionListById(DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerDistributionId"].Value = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId;

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
                audit_IUD.WebServiceSelectInsert("tbl_DownPaymentFromCustomerDistribution", downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomerDistributionListById()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerDistributionFormDAL : GetDownPaymentFromCustomerDistributionListById] An error occured in the processing of Record Id : " + downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddDownPaymentFromCustomerDistribution(DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = downPaymentFromCustomerDistributionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = downPaymentFromCustomerDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerId"].Value = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = downPaymentFromCustomerDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = downPaymentFromCustomerDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = downPaymentFromCustomerDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = downPaymentFromCustomerDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = downPaymentFromCustomerDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = downPaymentFromCustomerDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = downPaymentFromCustomerDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = downPaymentFromCustomerDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerDistributionId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerDistributionId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_DownPaymentFromCustomerDistributionId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_DownPaymentFromCustomerDistribution";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(downPaymentFromCustomerDistributionFormUI);
                    audit_IUD.WebServiceInsert(downPaymentFromCustomerDistributionFormUI.Tbl_OrganizationId, tableName, RecoredID, downPaymentFromCustomerDistributionFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddDownPaymentFromCustomerDistribution()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[DownPaymentFromCustomerDistributionFormDAL : AddDownPaymentFromCustomerDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdateDownPaymentFromCustomerDistribution(DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = downPaymentFromCustomerDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = downPaymentFromCustomerDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerDistributionId"].Value = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerId"].Value = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = downPaymentFromCustomerDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = downPaymentFromCustomerDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = downPaymentFromCustomerDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = downPaymentFromCustomerDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = downPaymentFromCustomerDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = downPaymentFromCustomerDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = downPaymentFromCustomerDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = downPaymentFromCustomerDistributionFormUI.DistributionReference;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(downPaymentFromCustomerDistributionFormUI);
                    audit_IUD.WebServiceUpdate(downPaymentFromCustomerDistributionFormUI.Tbl_OrganizationId, "tbl_DownPaymentFromCustomerDistribution", downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId, downPaymentFromCustomerDistributionFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateDownPaymentFromCustomerDistribution()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[DownPaymentFromCustomerDistributionFormDAL : UpdateDownPaymentFromCustomerDistribution] An error occured in the processing of Record Id : " + downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteDownPaymentFromCustomerDistribution(DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerDistributionId"].Value = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_DownPaymentFromCustomerDistribution", downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteDownPaymentFromCustomerDistribution()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerDistributionFormDAL : DeleteDownPaymentFromCustomerDistribution] An error occured in the processing of Record Id : " + downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetDownPaymentFromCustomerDistribution_SelectByDownPaymentFromCustomerId(DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerDistribution_SelectByDownPaymentFromCustomerId", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerId"].Value = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl = ds.Tables[0];
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomerDistribution_SelectByDownPaymentFromCustomerId()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerDistributionFormDAL : GetDownPaymentFromCustomerDistribution_SelectByDownPaymentFromCustomerId] An error occured in the processing of Record Id : " + downPaymentFromCustomerDistributionFormUI.Tbl_DownPaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
}