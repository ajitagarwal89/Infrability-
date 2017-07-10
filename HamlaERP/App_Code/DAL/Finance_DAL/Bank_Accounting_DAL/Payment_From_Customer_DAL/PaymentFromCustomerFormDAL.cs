using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for PaymentFromCustomerFormDAL
/// </summary>
public class PaymentFromCustomerFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
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

    public int AddPaymentFromCustomer(PaymentFromCustomerFormUI PaymentFromCustomerFormUI)
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
                sqlCmd.Parameters["@CreatedBy"].Value = PaymentFromCustomerFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentFromCustomerFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = PaymentFromCustomerFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@ReceiptDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReceiptDate"].Value = PaymentFromCustomerFormUI.ReceiptDate;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = PaymentFromCustomerFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_CustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerId"].Value = PaymentFromCustomerFormUI.Tbl_CustomerId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = PaymentFromCustomerFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = PaymentFromCustomerFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = PaymentFromCustomerFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = PaymentFromCustomerFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = PaymentFromCustomerFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = PaymentFromCustomerFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = PaymentFromCustomerFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = PaymentFromCustomerFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@Comments", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comments"].Value = PaymentFromCustomerFormUI.Comments;

                sqlCmd.Parameters.Add("@IsAutoAppliyTo", SqlDbType.Bit);
                sqlCmd.Parameters["@IsAutoAppliyTo"].Value = PaymentFromCustomerFormUI.IsAutoAppliyTo;

                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = PaymentFromCustomerFormUI.IsPosted;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = PaymentFromCustomerFormUI.PostingDate;

                sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ApplyDate"].Value = PaymentFromCustomerFormUI.ApplyDate;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = PaymentFromCustomerFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DocumentType"].Value = PaymentFromCustomerFormUI.opt_DocumentType;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = PaymentFromCustomerFormUI.opt_DocumentType;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
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
    public int UpdatePaymentFromCustomer(PaymentFromCustomerFormUI PaymentFromCustomerFormUI)
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
                sqlCmd.Parameters["@ModifiedBy"].Value = PaymentFromCustomerFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentFromCustomerFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentFromCustomerId"].Value = PaymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = PaymentFromCustomerFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@ReceiptDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReceiptDate"].Value = PaymentFromCustomerFormUI.ReceiptDate;

                //sqlCmd.Parameters.Add("@ReceiptDate_Hijri", SqlDbType.DateTime);
                //sqlCmd.Parameters["@ReceiptDate_Hijri"].Value = PaymentFromCustomerFormUI.ReceiptDate_Hijri;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = PaymentFromCustomerFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_CustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerId"].Value = PaymentFromCustomerFormUI.Tbl_CustomerId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = PaymentFromCustomerFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = PaymentFromCustomerFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = PaymentFromCustomerFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = PaymentFromCustomerFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = PaymentFromCustomerFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = PaymentFromCustomerFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = PaymentFromCustomerFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = PaymentFromCustomerFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@Comments", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comments"].Value = PaymentFromCustomerFormUI.Comments;

                sqlCmd.Parameters.Add("@IsAutoAppliyTo", SqlDbType.Bit);
                sqlCmd.Parameters["@IsAutoAppliyTo"].Value = PaymentFromCustomerFormUI.IsAutoAppliyTo;

                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = PaymentFromCustomerFormUI.IsPosted;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = PaymentFromCustomerFormUI.PostingDate;

                sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ApplyDate"].Value = PaymentFromCustomerFormUI.ApplyDate;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = PaymentFromCustomerFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DocumentType"].Value = PaymentFromCustomerFormUI.opt_DocumentType;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = PaymentFromCustomerFormUI.opt_DocumentType;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentFromCustomer()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentFromCustomerFormDAL : UpdatePaymentFromCustomer] An error occured in the processing of Record Id : " + PaymentFromCustomerFormUI.Tbl_PaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePaymentFromCustomer(PaymentFromCustomerFormUI PaymentFromCustomerFormUI)
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
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = PaymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentFromCustomer()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerFormUI.Tbl_PaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerFormDAL : DeletePaymentFromCustomer] An error occured in the processing of Record Id : " + PaymentFromCustomerFormUI.Tbl_PaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}