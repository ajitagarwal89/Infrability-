using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for DownPaymentFromCustomerFormDAL
/// </summary>
public class DownPaymentFromCustomerFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public DownPaymentFromCustomerFormDAL()
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
            logExcpUIobj.MethodName = "DownPaymentFromCustomerFormDAL()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[DownPaymentFromCustomerFormDAL : DownPaymentFromCustomerFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetDownPaymentFromCustomerListById(DownPaymentFromCustomerFormUI downPaymentFromCustomerFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomer_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerId"].Value = downPaymentFromCustomerFormUI.Tbl_DownPaymentFromCustomerId;

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
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomerListById()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerFormUI.Tbl_DownPaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerFormDAL : GetDownPaymentFromCustomerListById] An error occured in the processing of Record Id : " + downPaymentFromCustomerFormUI.Tbl_DownPaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddDownPaymentFromCustomer(DownPaymentFromCustomerFormUI downPaymentFromCustomerFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomer_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = downPaymentFromCustomerFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = downPaymentFromCustomerFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = downPaymentFromCustomerFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@ReceiptDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReceiptDate"].Value = downPaymentFromCustomerFormUI.ReceiptDate;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = downPaymentFromCustomerFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_CustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerId"].Value = downPaymentFromCustomerFormUI.Tbl_CustomerId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = downPaymentFromCustomerFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = downPaymentFromCustomerFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = downPaymentFromCustomerFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = downPaymentFromCustomerFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = downPaymentFromCustomerFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = downPaymentFromCustomerFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = downPaymentFromCustomerFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = downPaymentFromCustomerFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@Comments", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comments"].Value = downPaymentFromCustomerFormUI.Comments;

                sqlCmd.Parameters.Add("@IsAutoAppliyTo", SqlDbType.Bit);
                sqlCmd.Parameters["@IsAutoAppliyTo"].Value = downPaymentFromCustomerFormUI.IsAutoAppliyTo;

                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = downPaymentFromCustomerFormUI.IsPosted;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = downPaymentFromCustomerFormUI.PostingDate;

                sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ApplyDate"].Value = downPaymentFromCustomerFormUI.ApplyDate;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = downPaymentFromCustomerFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DocumentType"].Value = downPaymentFromCustomerFormUI.opt_DocumentType;

                sqlCmd.Parameters.Add("@TotalAmount", SqlDbType.Int);
                sqlCmd.Parameters["@TotalAmount"].Value = downPaymentFromCustomerFormUI.TotalAmount;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddDownPaymentFromCustomer()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[DownPaymentFromCustomerFormDAL : AddDownPaymentFromCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdateDownPaymentFromCustomer(DownPaymentFromCustomerFormUI downPaymentFromCustomerFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomer_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value =downPaymentFromCustomerFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value =downPaymentFromCustomerFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_DownPaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_DownPaymentFromCustomerId"].Value =downPaymentFromCustomerFormUI.Tbl_DownPaymentFromCustomerId;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = downPaymentFromCustomerFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@ReceiptDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReceiptDate"].Value = downPaymentFromCustomerFormUI.ReceiptDate;

                //sqlCmd.Parameters.Add("@ReceiptDate_Hijri", SqlDbType.DateTime);
                //sqlCmd.Parameters["@ReceiptDate_Hijri"].Value = downPaymentFromCustomerFormUI.ReceiptDate_Hijri;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = downPaymentFromCustomerFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_CustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerId"].Value = downPaymentFromCustomerFormUI.Tbl_CustomerId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = downPaymentFromCustomerFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = downPaymentFromCustomerFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = downPaymentFromCustomerFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = downPaymentFromCustomerFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = downPaymentFromCustomerFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = downPaymentFromCustomerFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = downPaymentFromCustomerFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = downPaymentFromCustomerFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@Comments", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comments"].Value = downPaymentFromCustomerFormUI.Comments;

                sqlCmd.Parameters.Add("@IsAutoAppliyTo", SqlDbType.Bit);
                sqlCmd.Parameters["@IsAutoAppliyTo"].Value = downPaymentFromCustomerFormUI.IsAutoAppliyTo;

                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = downPaymentFromCustomerFormUI.IsPosted;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = downPaymentFromCustomerFormUI.PostingDate;

                sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ApplyDate"].Value = downPaymentFromCustomerFormUI.ApplyDate;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = downPaymentFromCustomerFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DocumentType"].Value = downPaymentFromCustomerFormUI.opt_DocumentType;

                sqlCmd.Parameters.Add("@TotalAmount", SqlDbType.Int);
                sqlCmd.Parameters["@TotalAmount"].Value = downPaymentFromCustomerFormUI.TotalAmount;



                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateDownPaymentFromCustomer()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerFormUI.Tbl_DownPaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[DownPaymentFromCustomerFormDAL : UpdateDownPaymentFromCustomer] An error occured in the processing of Record Id : " + downPaymentFromCustomerFormUI.Tbl_DownPaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteDownPaymentFromCustomer(DownPaymentFromCustomerFormUI downPaymentFromCustomerFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomer_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerId"].Value =downPaymentFromCustomerFormUI.Tbl_DownPaymentFromCustomerId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteDownPaymentFromCustomer()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerFormUI.Tbl_DownPaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerFormDAL : DeleteDownPaymentFromCustomer] An error occured in the processing of Record Id : " +downPaymentFromCustomerFormUI.Tbl_DownPaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}