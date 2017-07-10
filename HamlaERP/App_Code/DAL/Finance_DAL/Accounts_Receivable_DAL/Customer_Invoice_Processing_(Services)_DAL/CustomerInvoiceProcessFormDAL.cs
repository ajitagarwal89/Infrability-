using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for CustomerInvoiceProcessFormDAL
/// </summary>
public class CustomerInvoiceProcessFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public CustomerInvoiceProcessFormDAL()
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
            logExcpUIobj.MethodName = "CustomerInvoiceProcessFormDAL()";
            logExcpUIobj.ResourceName = "CustomerInvoiceProcessFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[CustomerInvoiceProcessFormDAL : CustomerInvoiceProcessFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetCustomerInvoiceProcessListById(CustomerInvoiceProcessFormUI customerInvoiceProcessFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoiceProcess_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CustomerInvoiceProcessId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerInvoiceProcessId"].Value = customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId;

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
            logExcpUIobj.MethodName = "getCustomerInvoiceProcessListById()";
            logExcpUIobj.ResourceName = "CustomerInvoiceProcessFormDAL.CS";
            logExcpUIobj.RecordId = customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerInvoiceProcessFormDAL : getCustomerInvoiceProcessListById] An error occured in the processing of Record Id : " + customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddCustomerInvoiceProcess(CustomerInvoiceProcessFormUI customerInvoiceProcessFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoiceProcess_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = customerInvoiceProcessFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = customerInvoiceProcessFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Opt_DocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_DocumentType"].Value = customerInvoiceProcessFormUI.Opt_DocumentType;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = customerInvoiceProcessFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = customerInvoiceProcessFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DocumentDate"].Value = customerInvoiceProcessFormUI.DocumentDate;


                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = customerInvoiceProcessFormUI.Description;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = customerInvoiceProcessFormUI.PostingDate;


                sqlCmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceDate"].Value = customerInvoiceProcessFormUI.InvoiceDate;


                sqlCmd.Parameters.Add("@InvoiceIssueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceIssueDate"].Value = customerInvoiceProcessFormUI.InvoiceIssueDate;


                sqlCmd.Parameters.Add("@tbl_CustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerId"].Value = customerInvoiceProcessFormUI.Tbl_CustomerId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = customerInvoiceProcessFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = customerInvoiceProcessFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@PONumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PONumber"].Value = customerInvoiceProcessFormUI.PONumber;

                sqlCmd.Parameters.Add("@Cost", SqlDbType.Decimal);
                sqlCmd.Parameters["@Cost"].Value = customerInvoiceProcessFormUI.Cost;

                sqlCmd.Parameters.Add("@Sales", SqlDbType.Decimal);
                sqlCmd.Parameters["@Sales"].Value = customerInvoiceProcessFormUI.Sales;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = customerInvoiceProcessFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Freight", SqlDbType.Decimal);
                sqlCmd.Parameters["@Freight"].Value = customerInvoiceProcessFormUI.Freight;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = customerInvoiceProcessFormUI.Total;

                sqlCmd.Parameters.Add("@tbl_PayablesId_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_BankTransfer"].Value = customerInvoiceProcessFormUI.Tbl_PayablesId_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = customerInvoiceProcessFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = customerInvoiceProcessFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = customerInvoiceProcessFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = customerInvoiceProcessFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = customerInvoiceProcessFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = customerInvoiceProcessFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = customerInvoiceProcessFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@OnAccount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OnAccount"].Value = customerInvoiceProcessFormUI.OnAccount;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddCustomerInvoiceProcess()";
            logExcpUIobj.ResourceName = "CustomerInvoiceProcessFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerInvoiceProcessFormDAL : AddCustomerInvoiceProcess] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateCustomerInvoiceProcess(CustomerInvoiceProcessFormUI customerInvoiceProcessFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoiceProcess_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;


                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = customerInvoiceProcessFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = customerInvoiceProcessFormUI.Tbl_OrganizationId;
                sqlCmd.Parameters.Add("@tbl_CustomerInvoiceProcessId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerInvoiceProcessId"].Value = customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId;

                sqlCmd.Parameters.Add("@Opt_DocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_DocumentType"].Value = customerInvoiceProcessFormUI.Opt_DocumentType;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = customerInvoiceProcessFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = customerInvoiceProcessFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DocumentDate"].Value = customerInvoiceProcessFormUI.DocumentDate;

                //sqlCmd.Parameters.Add("@DocumentDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@DocumentDate_Hijri"].Value = customerInvoiceProcessFormUI.DocumentDate_Hijri;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = customerInvoiceProcessFormUI.Description;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = customerInvoiceProcessFormUI.PostingDate;

                sqlCmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceDate"].Value = customerInvoiceProcessFormUI.InvoiceDate;

                sqlCmd.Parameters.Add("@InvoiceIssueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceIssueDate"].Value = customerInvoiceProcessFormUI.InvoiceIssueDate;

                sqlCmd.Parameters.Add("@tbl_CustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerId"].Value = customerInvoiceProcessFormUI.Tbl_CustomerId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = customerInvoiceProcessFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = customerInvoiceProcessFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@PONumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PONumber"].Value = customerInvoiceProcessFormUI.PONumber;

                sqlCmd.Parameters.Add("@Cost", SqlDbType.Decimal);
                sqlCmd.Parameters["@Cost"].Value = customerInvoiceProcessFormUI.Cost;

                sqlCmd.Parameters.Add("@Sales", SqlDbType.Decimal);
                sqlCmd.Parameters["@Sales"].Value = customerInvoiceProcessFormUI.Sales;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = customerInvoiceProcessFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Freight", SqlDbType.Decimal);
                sqlCmd.Parameters["@Freight"].Value = customerInvoiceProcessFormUI.Freight;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = customerInvoiceProcessFormUI.Total;

                sqlCmd.Parameters.Add("@tbl_PayablesId_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_BankTransfer"].Value = customerInvoiceProcessFormUI.Tbl_PayablesId_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = customerInvoiceProcessFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = customerInvoiceProcessFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = customerInvoiceProcessFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = customerInvoiceProcessFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = customerInvoiceProcessFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = customerInvoiceProcessFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = customerInvoiceProcessFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@OnAccount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OnAccount"].Value = customerInvoiceProcessFormUI.OnAccount;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateCustomerInvoiceProcess()";
            logExcpUIobj.ResourceName = "CustomerInvoiceProcessFormDAL.CS";
            logExcpUIobj.RecordId = customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerInvoiceProcessFormDAL : UpdateCustomerInvoiceProcess] An error occured in the processing of Record Id : " + customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteCustomerInvoiceProcess(CustomerInvoiceProcessFormUI customerInvoiceProcessFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoiceProcess_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CustomerInvoiceProcessId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerInvoiceProcessId"].Value = customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteCustomerInvoiceProcess()";
            logExcpUIobj.ResourceName = "CustomerInvoiceProcessFormDAL.CS";
            logExcpUIobj.RecordId = customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerInvoiceProcessFormDAL : DeleteCustomerInvoiceProcess] An error occured in the processing of Record Id : " + customerInvoiceProcessFormUI.Tbl_CustomerInvoiceProcessId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}