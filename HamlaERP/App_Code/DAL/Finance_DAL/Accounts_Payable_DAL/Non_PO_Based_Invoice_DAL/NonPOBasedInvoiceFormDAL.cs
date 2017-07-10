using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for NonPOBasedInvoiceFormDAL
/// </summary>
public class NonPOBasedInvoiceFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public NonPOBasedInvoiceFormDAL()
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
            logExcpUIobj.MethodName = "NonPOBasedInvoiceFormDAL()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[NonPOBasedInvoiceFormDAL : NonPOBasedInvoiceFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetNonPOBasedInvoiceListById(NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoice_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_NonPOBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_NonPOBasedInvoiceId"].Value = nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId;

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
            logExcpUIobj.MethodName = "getNonPOBasedInvoiceListById()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[NonPOBasedInvoiceFormDAL : getNonPOBasedInvoiceListById] An error occured in the processing of Record Id : " + nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddNonPOBasedInvoice(NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoice_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = nonPOBasedInvoiceFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = nonPOBasedInvoiceFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@VoucherNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@VoucherNumber"].Value = nonPOBasedInvoiceFormUI.VoucherNumber;

                sqlCmd.Parameters.Add("@InterCompany", SqlDbType.Bit);
                sqlCmd.Parameters["@InterCompany"].Value = nonPOBasedInvoiceFormUI.InterCompany;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = nonPOBasedInvoiceFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@Opt_DocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_DocumentType"].Value = nonPOBasedInvoiceFormUI.Opt_DocumentType;

                sqlCmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DocumentDate"].Value = nonPOBasedInvoiceFormUI.DocumentDate;

                //sqlCmd.Parameters.Add("@DocumentDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@DocumentDate_Hijri"].Value = nonPOBasedInvoiceFormUI.DocumentDate_Hijri;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = nonPOBasedInvoiceFormUI.Description;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = nonPOBasedInvoiceFormUI.PostingDate;

                //sqlCmd.Parameters.Add("@PostingDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@PostingDate_Hijri"].Value = nonPOBasedInvoiceFormUI.PostingDate_Hijri;

                sqlCmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceDate"].Value = nonPOBasedInvoiceFormUI.InvoiceDate;

                //sqlCmd.Parameters.Add("@InvoiceDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@InvoiceDate_Hijri"].Value = nonPOBasedInvoiceFormUI.InvoiceDate_Hijri;

                sqlCmd.Parameters.Add("@ReceivedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReceivedDate"].Value = nonPOBasedInvoiceFormUI.ReceivedDate;

                //sqlCmd.Parameters.Add("@ReceivedDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@ReceivedDate_Hijri"].Value = nonPOBasedInvoiceFormUI.ReceivedDate_Hijri;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = nonPOBasedInvoiceFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = nonPOBasedInvoiceFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = nonPOBasedInvoiceFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@PONumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PONumber"].Value = nonPOBasedInvoiceFormUI.PONumber;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = nonPOBasedInvoiceFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@Purchase", SqlDbType.Decimal);
                sqlCmd.Parameters["@Purchase"].Value = nonPOBasedInvoiceFormUI.Purchase;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = nonPOBasedInvoiceFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Freight", SqlDbType.Decimal);
                sqlCmd.Parameters["@Freight"].Value = nonPOBasedInvoiceFormUI.Freight;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = nonPOBasedInvoiceFormUI.Total;

                sqlCmd.Parameters.Add("@tbl_PayablesId_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_BankTransfer"].Value = nonPOBasedInvoiceFormUI.Tbl_PayablesId_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = nonPOBasedInvoiceFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = nonPOBasedInvoiceFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = nonPOBasedInvoiceFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = nonPOBasedInvoiceFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = nonPOBasedInvoiceFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = nonPOBasedInvoiceFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = nonPOBasedInvoiceFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@OnAccount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OnAccount"].Value = nonPOBasedInvoiceFormUI.OnAccount;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddNonPOBasedInvoice()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[NonPOBasedInvoiceFormDAL : AddNonPOBasedInvoice] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateNonPOBasedInvoice(NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoice_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = nonPOBasedInvoiceFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = nonPOBasedInvoiceFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_NonPOBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_NonPOBasedInvoiceId"].Value = nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId;

                sqlCmd.Parameters.Add("@VoucherNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@VoucherNumber"].Value = nonPOBasedInvoiceFormUI.VoucherNumber;

                sqlCmd.Parameters.Add("@InterCompany", SqlDbType.Bit);
                sqlCmd.Parameters["@InterCompany"].Value = nonPOBasedInvoiceFormUI.InterCompany;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = nonPOBasedInvoiceFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@Opt_DocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_DocumentType"].Value = nonPOBasedInvoiceFormUI.Opt_DocumentType;

                sqlCmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DocumentDate"].Value = nonPOBasedInvoiceFormUI.DocumentDate;

                //sqlCmd.Parameters.Add("@DocumentDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@DocumentDate_Hijri"].Value = nonPOBasedInvoiceFormUI.DocumentDate_Hijri;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = nonPOBasedInvoiceFormUI.Description;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = nonPOBasedInvoiceFormUI.PostingDate;

                //sqlCmd.Parameters.Add("@PostingDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@PostingDate_Hijri"].Value = nonPOBasedInvoiceFormUI.PostingDate_Hijri;

                sqlCmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceDate"].Value = nonPOBasedInvoiceFormUI.InvoiceDate;

                //sqlCmd.Parameters.Add("@InvoiceDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@InvoiceDate_Hijri"].Value = nonPOBasedInvoiceFormUI.InvoiceDate_Hijri;

                sqlCmd.Parameters.Add("@ReceivedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReceivedDate"].Value = nonPOBasedInvoiceFormUI.ReceivedDate;

                //sqlCmd.Parameters.Add("@ReceivedDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@ReceivedDate_Hijri"].Value = nonPOBasedInvoiceFormUI.ReceivedDate_Hijri;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = nonPOBasedInvoiceFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = nonPOBasedInvoiceFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = nonPOBasedInvoiceFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@PONumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PONumber"].Value = nonPOBasedInvoiceFormUI.PONumber;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = nonPOBasedInvoiceFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@Purchase", SqlDbType.Decimal);
                sqlCmd.Parameters["@Purchase"].Value = nonPOBasedInvoiceFormUI.Purchase;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = nonPOBasedInvoiceFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Freight", SqlDbType.Decimal);
                sqlCmd.Parameters["@Freight"].Value = nonPOBasedInvoiceFormUI.Freight;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = nonPOBasedInvoiceFormUI.Total;

                sqlCmd.Parameters.Add("@tbl_PayablesId_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_BankTransfer"].Value = nonPOBasedInvoiceFormUI.Tbl_PayablesId_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = nonPOBasedInvoiceFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = nonPOBasedInvoiceFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = nonPOBasedInvoiceFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = nonPOBasedInvoiceFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = nonPOBasedInvoiceFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = nonPOBasedInvoiceFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = nonPOBasedInvoiceFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@OnAccount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OnAccount"].Value = nonPOBasedInvoiceFormUI.OnAccount;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateNonPOBasedInvoice()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[NonPOBasedInvoiceFormDAL : UpdateNonPOBasedInvoice] An error occured in the processing of Record Id : " + nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteNonPOBasedInvoice(NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoice_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_NonPOBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_NonPOBasedInvoiceId"].Value = nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteNonPOBasedInvoice()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[NonPOBasedInvoiceFormDAL : DeleteNonPOBasedInvoice] An error occured in the processing of Record Id : " + nonPOBasedInvoiceFormUI.Tbl_NonPOBasedInvoiceId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}