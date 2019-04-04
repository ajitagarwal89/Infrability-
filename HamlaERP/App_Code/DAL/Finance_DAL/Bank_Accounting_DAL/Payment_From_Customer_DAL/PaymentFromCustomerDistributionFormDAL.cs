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
/// Summary description for PaymentFromCustomerDistributionFormDAL
/// </summary>
public class PaymentFromCustomerDistributionFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public PaymentFromCustomerDistributionFormDAL()
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
            logExcpUIobj.MethodName = "PaymentFromCustomerDistributionFormDAL()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentFromCustomerDistributionFormDAL : PaymentFromCustomerDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentFromCustomerDistributionListById(PaymentFromCustomerDistributionFormUI PaymentFromCustomerDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerDistributionId"].Value = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;

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
                audit_IUD.WebServiceSelectInsert("tbl_PaymentFromCustomerDistribution", PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPaymentFromCustomerDistributionListById()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerDistributionFormDAL : GetPaymentFromCustomerDistributionListById] An error occured in the processing of Record Id : " + PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddPaymentFromCustomerDistribution(PaymentFromCustomerDistributionFormUI paymentFromCustomerDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = paymentFromCustomerDistributionFormUI.CreatedBy;
                
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentFromCustomerDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = paymentFromCustomerDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = paymentFromCustomerDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = paymentFromCustomerDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = paymentFromCustomerDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = paymentFromCustomerDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = paymentFromCustomerDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = paymentFromCustomerDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = paymentFromCustomerDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@Tbl_PaymentFromCustomerDistributionId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@Tbl_PaymentFromCustomerDistributionId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@Tbl_PaymentFromCustomerDistributionId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_PaymentFromCustomerDistribution";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(paymentFromCustomerDistributionFormUI);
                    audit_IUD.WebServiceInsert(paymentFromCustomerDistributionFormUI.Tbl_OrganizationId, tableName, RecoredID, paymentFromCustomerDistributionFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddPaymentFromCustomerDistribution()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentFromCustomerDistributionFormDAL : AddPaymentFromCustomerDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdatePaymentFromCustomerDistribution(PaymentFromCustomerDistributionFormUI PaymentFromCustomerDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = PaymentFromCustomerDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentFromCustomerDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentFromCustomerDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentFromCustomerDistributionId"].Value = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = PaymentFromCustomerDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = PaymentFromCustomerDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = PaymentFromCustomerDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = PaymentFromCustomerDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = PaymentFromCustomerDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = PaymentFromCustomerDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = PaymentFromCustomerDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = PaymentFromCustomerDistributionFormUI.DistributionReference;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(PaymentFromCustomerDistributionFormUI);
                    audit_IUD.WebServiceUpdate(PaymentFromCustomerDistributionFormUI.Tbl_OrganizationId, "tbl_PaymentFromCustomerDistribution", PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId, PaymentFromCustomerDistributionFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentFromCustomerDistribution()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentFromCustomerDistributionFormDAL : UpdatePaymentFromCustomerDistribution] An error occured in the processing of Record Id : " + PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePaymentFromCustomerDistribution(PaymentFromCustomerDistributionFormUI PaymentFromCustomerDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerDistributionId"].Value = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_PaymentFromCustomerDistribution", PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentFromCustomerDistribution()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerDistributionFormDAL : DeletePaymentFromCustomerDistribution] An error occured in the processing of Record Id : " + PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }


    public DataTable GetPaymentFromCustomerDistribution_SelectByPaymentFromCustomerId(PaymentFromCustomerDistributionFormUI paymentFromCustomerDistributionFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_SelectByPaymentFromCustomerId", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerId;

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
            logExcpUIobj.MethodName = "GetPaymentFromCustomerDistribution_SelectByPaymentFromCustomerId()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerDistributionFormDAL : GetPaymentFromCustomerDistribution_SelectByPaymentFromCustomerId] An error occured in the processing of Record Id : " + paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
}