using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;
using Finware;

/// <summary>
/// Summary description for PaymentToSupplierEmployeeFormDAL
/// </summary>
public class PaymentToSupplierEmployeeFormDAL
{

    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PaymentToSupplierEmployeeFormDAL()
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
            logExcpUIobj.MethodName = "PaymentToSupplierEmployeeFormDAL()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentToSupplierEmployeeFormDAL : PaymentToSupplierEmployeeFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetPaymentToSupplierEmployeeListById(PaymentToSupplierEmployeeFormUI paymentToSupplierEmployeeFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployee_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeId"].Value = paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId;

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
            logExcpUIobj.MethodName = "GetPaymentToSupplierEmployeeListById()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeFormDAL : GetPaymentToSupplierEmployeeListById] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPaymentToSupplierEmployee(PaymentToSupplierEmployeeFormUI paymentToSupplierEmployeeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployee_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = paymentToSupplierEmployeeFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentToSupplierEmployeeFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@PaymentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentNumber"].Value = paymentToSupplierEmployeeFormUI.PaymentNumber;

                sqlCmd.Parameters.Add("@PaymentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PaymentDate"].Value = paymentToSupplierEmployeeFormUI.PaymentDate;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = paymentToSupplierEmployeeFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeId"].Value = paymentToSupplierEmployeeFormUI.Tbl_SupplierEmployeeId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = paymentToSupplierEmployeeFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PayablesId_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_BankTransfer"].Value = paymentToSupplierEmployeeFormUI.Tbl_PayablesId_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = paymentToSupplierEmployeeFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = paymentToSupplierEmployeeFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = paymentToSupplierEmployeeFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = paymentToSupplierEmployeeFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = paymentToSupplierEmployeeFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = paymentToSupplierEmployeeFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = paymentToSupplierEmployeeFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@Unapplied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Unapplied"].Value = paymentToSupplierEmployeeFormUI.Unapplied;

                sqlCmd.Parameters.Add("@Applied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Applied"].Value = paymentToSupplierEmployeeFormUI.Applied;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = paymentToSupplierEmployeeFormUI.Total;

                sqlCmd.Parameters.Add("@IsAutoAppliyTo", SqlDbType.Bit);
                sqlCmd.Parameters["@IsAutoAppliyTo"].Value = paymentToSupplierEmployeeFormUI.IsAutoApplyTo;


                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = paymentToSupplierEmployeeFormUI.IsPosted;

                


                sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ApplyDate"].Value = paymentToSupplierEmployeeFormUI.ApplyDate;



                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = paymentToSupplierEmployeeFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DocumentType"].Value = paymentToSupplierEmployeeFormUI.opt_DocumentType;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPaymentToSupplierEmployee()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToSupplierEmployeeFormDAL : AddPaymentToSupplierEmployee] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdatePaymentToSupplierEmployee(PaymentToSupplierEmployeeFormUI paymentToSupplierEmployeeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployee_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = paymentToSupplierEmployeeFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentToSupplierEmployeeFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentToSupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentToSupplierEmployeeId"].Value = paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId;

                sqlCmd.Parameters.Add("@PaymentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentNumber"].Value = paymentToSupplierEmployeeFormUI.PaymentNumber;

                sqlCmd.Parameters.Add("@PaymentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PaymentDate"].Value = paymentToSupplierEmployeeFormUI.PaymentDate;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = paymentToSupplierEmployeeFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeId"].Value = paymentToSupplierEmployeeFormUI.Tbl_SupplierEmployeeId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = paymentToSupplierEmployeeFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PayablesId_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_BankTransfer"].Value = paymentToSupplierEmployeeFormUI.Tbl_PayablesId_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = paymentToSupplierEmployeeFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = paymentToSupplierEmployeeFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = paymentToSupplierEmployeeFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = paymentToSupplierEmployeeFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = paymentToSupplierEmployeeFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = paymentToSupplierEmployeeFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = paymentToSupplierEmployeeFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@Unapplied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Unapplied"].Value = paymentToSupplierEmployeeFormUI.Unapplied;

                sqlCmd.Parameters.Add("@Applied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Applied"].Value = paymentToSupplierEmployeeFormUI.Applied;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = paymentToSupplierEmployeeFormUI.Total;

                sqlCmd.Parameters.Add("@IsAutoAppliyTo", SqlDbType.Bit);
                sqlCmd.Parameters["@IsAutoAppliyTo"].Value = paymentToSupplierEmployeeFormUI.IsAutoApplyTo;


                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = paymentToSupplierEmployeeFormUI.IsPosted;

    
                sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ApplyDate"].Value = paymentToSupplierEmployeeFormUI.ApplyDate;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = paymentToSupplierEmployeeFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DocumentType"].Value = paymentToSupplierEmployeeFormUI.opt_DocumentType;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentToSupplierEmployee()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToSupplierEmployeeFormDAL : UpdatePaymentToSupplierEmployee] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePaymentToSupplierEmployee(PaymentToSupplierEmployeeFormUI paymentToSupplierEmployeeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployee_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeId"].Value = paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentToSupplierEmployee()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeFormDAL : DeletePaymentToSupplierEmployee] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePostingPaymentToSupplierEmployee(PaymentToSupplierEmployeeFormUI paymentToSupplierEmployeeFormUI)
    {
        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployee_UpdatePosting", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeId"].Value = paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = paymentToSupplierEmployeeFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentToSupplierEmployeeFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = paymentToSupplierEmployeeFormUI.IsPosted;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(paymentToSupplierEmployeeFormUI);
                    audit_IUD.WebServiceUpdate(paymentToSupplierEmployeeFormUI.Tbl_OrganizationId, "tbl_PaymentToSupplierEmployee", paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId, paymentToSupplierEmployeeFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();

            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePostingPaymentToSupplierEmployee()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeFormDAL : UpdatePostingPaymentToSupplierEmployee] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeFormUI.Tbl_PaymentToSupplierEmployeeId + ". Details : [" + exp.ToString() + "]");
        }


        return result;

    }

    public DataTable GetSerialNumber()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();

        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployee_SerialNumber", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

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
            logExcpUIobj.MethodName = "GetSerialNumber()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToSupplierEmployeeFormDAL : GetSerialNumber] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

}