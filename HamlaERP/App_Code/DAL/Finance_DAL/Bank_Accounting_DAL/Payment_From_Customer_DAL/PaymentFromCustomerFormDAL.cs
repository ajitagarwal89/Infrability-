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
/// Summary description for PaymentFromCustomerFormDAL
/// </summary>
public class PaymentFromCustomerFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PaymentFromCustomerFormDAL()
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
            logExcpUIobj.MethodName = "PaymentFromCustomerFormDAL()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentFromCustomerFormDAL : PaymentFromCustomerFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentFromCustomerListById(PaymentFromCustomerFormUI paymentFromCustomerFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomer_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;

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
                audit_IUD.WebServiceSelectInsert("tbl_PaymentFromCustomer", paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPaymentFromCustomerListById()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerFormDAL : GetPaymentFromCustomerListById] An error occured in the processing of Record Id : " + paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPaymentFromCustomer(PaymentFromCustomerFormUI paymentFromCustomerFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomer_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = paymentFromCustomerFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentFromCustomerFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = paymentFromCustomerFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@ReceiptDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReceiptDate"].Value = paymentFromCustomerFormUI.ReceiptDate;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = paymentFromCustomerFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_CustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerId"].Value = paymentFromCustomerFormUI.Tbl_CustomerId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = paymentFromCustomerFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@opt_PayablesType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_PayablesType"].Value = paymentFromCustomerFormUI.opt_PayablesType;


                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = paymentFromCustomerFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = paymentFromCustomerFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = paymentFromCustomerFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = paymentFromCustomerFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = paymentFromCustomerFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = paymentFromCustomerFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = paymentFromCustomerFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@Comments", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comments"].Value = paymentFromCustomerFormUI.Comments;

                sqlCmd.Parameters.Add("@IsAutoAppliyTo", SqlDbType.Bit);
                sqlCmd.Parameters["@IsAutoAppliyTo"].Value = paymentFromCustomerFormUI.IsAutoAppliyTo;

                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = paymentFromCustomerFormUI.IsPosted;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = paymentFromCustomerFormUI.PostingDate;

                sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ApplyDate"].Value = paymentFromCustomerFormUI.ApplyDate;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = paymentFromCustomerFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DocumentType"].Value = paymentFromCustomerFormUI.opt_DocumentType;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = paymentFromCustomerFormUI.opt_DocumentType;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_PaymentFromCustomer";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(paymentFromCustomerFormUI);
                    audit_IUD.WebServiceInsert(paymentFromCustomerFormUI.Tbl_OrganizationId, tableName, RecoredID, paymentFromCustomerFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddPaymentFromCustomer()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentFromCustomerFormDAL : AddPaymentFromCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdatePaymentFromCustomer(PaymentFromCustomerFormUI paymentFromCustomerFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomer_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = paymentFromCustomerFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentFromCustomerFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentFromCustomerId"].Value = paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = paymentFromCustomerFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@ReceiptDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReceiptDate"].Value = paymentFromCustomerFormUI.ReceiptDate;

                //sqlCmd.Parameters.Add("@ReceiptDate_Hijri", SqlDbType.DateTime);
                //sqlCmd.Parameters["@ReceiptDate_Hijri"].Value = paymentFromCustomerFormUI.ReceiptDate_Hijri;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = paymentFromCustomerFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_CustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerId"].Value = paymentFromCustomerFormUI.Tbl_CustomerId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = paymentFromCustomerFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@opt_PayablesType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_PayablesType"].Value = paymentFromCustomerFormUI.opt_PayablesType;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = paymentFromCustomerFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = paymentFromCustomerFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = paymentFromCustomerFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = paymentFromCustomerFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = paymentFromCustomerFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = paymentFromCustomerFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = paymentFromCustomerFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@Comments", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comments"].Value = paymentFromCustomerFormUI.Comments;

                sqlCmd.Parameters.Add("@IsAutoAppliyTo", SqlDbType.Bit);
                sqlCmd.Parameters["@IsAutoAppliyTo"].Value = paymentFromCustomerFormUI.IsAutoAppliyTo;

                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = paymentFromCustomerFormUI.IsPosted;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = paymentFromCustomerFormUI.PostingDate;

                sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ApplyDate"].Value = paymentFromCustomerFormUI.ApplyDate;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = paymentFromCustomerFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DocumentType"].Value = paymentFromCustomerFormUI.opt_DocumentType;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = paymentFromCustomerFormUI.opt_DocumentType;


                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(paymentFromCustomerFormUI);
                    audit_IUD.WebServiceUpdate(paymentFromCustomerFormUI.Tbl_OrganizationId, "tbl_PaymentFromCustomer", paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId, paymentFromCustomerFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentFromCustomer()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentFromCustomerFormDAL : UpdatePaymentFromCustomer] An error occured in the processing of Record Id : " + paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePaymentFromCustomer(PaymentFromCustomerFormUI paymentFromCustomerFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomer_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_PaymentFromCustomer", paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentFromCustomer()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerFormDAL : DeletePaymentFromCustomer] An error occured in the processing of Record Id : " + paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePostingPaymentFromCustomer(PaymentFromCustomerFormUI paymentFromCustomerFormUI)
    {
        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomer_UpdatePosting", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = paymentFromCustomerFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentFromCustomerFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = paymentFromCustomerFormUI.IsPosted;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(paymentFromCustomerFormUI);
                    audit_IUD.WebServiceUpdate(paymentFromCustomerFormUI.Tbl_OrganizationId, "tbl_PaymentFromCustomer", paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId, paymentFromCustomerFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();

            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePostingPaymentFromCustomer()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerFormDAL : UpdatePostingPaymentFromCustomer] An error occured in the processing of Record Id : " + paymentFromCustomerFormUI.Tbl_PaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }


        return result;

    }
}