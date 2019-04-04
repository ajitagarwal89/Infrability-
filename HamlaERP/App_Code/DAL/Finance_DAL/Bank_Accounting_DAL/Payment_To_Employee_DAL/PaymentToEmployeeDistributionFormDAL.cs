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
/// Summary description for PaymentToEmployeeDistributionFormDAL
/// </summary>
public class PaymentToEmployeeDistributionFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public PaymentToEmployeeDistributionFormDAL()
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
            logExcpUIobj.MethodName = "PaymentToEmployeeDistributionFormDAL()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentToEmployeeDistributionFormDAL : PaymentToEmployeeDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentToEmployeeDistributionListById(PaymentToEmployeeDistributionFormUI paymentToEmployeeDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeDistributionId"].Value = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;

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
                audit_IUD.WebServiceSelectInsert("tbl_PaymentToEmployeeDistribution", paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPaymentToEmployeeDistributionListById()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeDistributionFormDAL : GetPaymentToEmployeeDistributionListById] An error occured in the processing of Record Id : " + paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddPaymentToEmployeeDistribution(PaymentToEmployeeDistributionFormUI paymentToEmployeeDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = paymentToEmployeeDistributionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentToEmployeeDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeId"].Value = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = paymentToEmployeeDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = paymentToEmployeeDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = paymentToEmployeeDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = paymentToEmployeeDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = paymentToEmployeeDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = paymentToEmployeeDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = paymentToEmployeeDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = paymentToEmployeeDistributionFormUI.DistributionReference;

                //sqlCmd.Parameters.Add("@CompanyId", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@CompanyId"].Value = paymentToEmployeeDistributionFormUI.CompanyId;

                //sqlCmd.Parameters.Add("@CorrespondenceCompanyId", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@CorrespondenceCompanyId"].Value = paymentToEmployeeDistributionFormUI.CorrespondenceCompanyId;

                sqlCmd.Parameters.Add("@tbl_OrganizationIdCorrespondence", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationIdCorrespondence"].Value = paymentToEmployeeDistributionFormUI.CorrespondenceCompanyId;


                sqlCmd.Parameters.Add("@Tbl_PaymentToEmployeeDistributionId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@Tbl_PaymentToEmployeeDistributionId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@Tbl_PaymentToEmployeeDistributionId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_PaymentToEmployeeDistribution";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(paymentToEmployeeDistributionFormUI);
                    audit_IUD.WebServiceInsert(paymentToEmployeeDistributionFormUI.Tbl_OrganizationId, tableName, RecoredID, paymentToEmployeeDistributionFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddPaymentToEmployeeDistribution()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToEmployeeDistributionFormDAL : AddPaymentToEmployeeDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdatePaymentToEmployeeDistribution(PaymentToEmployeeDistributionFormUI paymentToEmployeeDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = paymentToEmployeeDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentToEmployeeDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentToEmployeeDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentToEmployeeDistributionId"].Value = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeId"].Value = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = paymentToEmployeeDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = paymentToEmployeeDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = paymentToEmployeeDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = paymentToEmployeeDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = paymentToEmployeeDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = paymentToEmployeeDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = paymentToEmployeeDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = paymentToEmployeeDistributionFormUI.DistributionReference;

                //sqlCmd.Parameters.Add("@CompanyId", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@CompanyId"].Value = paymentToEmployeeDistributionFormUI.CompanyId;

                //sqlCmd.Parameters.Add("@CorrespondenceCompanyId", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@CorrespondenceCompanyId"].Value = paymentToEmployeeDistributionFormUI.CorrespondenceCompanyId;

                sqlCmd.Parameters.Add("@tbl_OrganizationIdCorrespondence", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationIdCorrespondence"].Value = paymentToEmployeeDistributionFormUI.CorrespondenceCompanyId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(paymentToEmployeeDistributionFormUI);
                    audit_IUD.WebServiceUpdate(paymentToEmployeeDistributionFormUI.Tbl_OrganizationId, "tbl_PaymentToEmployeeDistribution", paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId, paymentToEmployeeDistributionFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentToEmployeeDistribution()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToEmployeeDistributionFormDAL : UpdatePaymentToEmployeeDistribution] An error occured in the processing of Record Id : " + paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePaymentToEmployeeDistribution(PaymentToEmployeeDistributionFormUI paymentToEmployeeDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeDistributionId"].Value = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_PaymentToEmployeeDistribution", paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentToEmployeeDistribution()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeDistributionFormDAL : DeletePaymentToEmployeeDistribution] An error occured in the processing of Record Id : " + paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetPaymentToEmployeeDistribution_SelectByPaymentToEmployeeId(PaymentToEmployeeDistributionFormUI paymentToEmployeeDistributionFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_SelectByPaymentToEmployeeId", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeId"].Value = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId;

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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeDistribution_SelectByPaymentToEmployeeId()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeDistributionFormDAL : GetPaymentToEmployeeDistribution_SelectByPaymentToEmployeeId] An error occured in the processing of Record Id : " + paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
   

}