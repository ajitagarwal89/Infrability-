using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;
/// <summary>
/// Summary description for PaymentToEmployeeFormDAL
/// </summary>
public class PaymentToEmployeeFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PaymentToEmployeeFormDAL()
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
            logExcpUIobj.MethodName = "PaymentToEmployeeFormDAL()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentToEmployeeFormDAL : PaymentToEmployeeFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentToEmployeeListById(PaymentToEmployeeFormUI PaymentToEmployeeFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployee_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeId"].Value = PaymentToEmployeeFormUI.Tbl_PaymentToEmployeeId;

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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeListById()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToEmployeeFormUI.Tbl_PaymentToEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeFormDAL : GetPaymentToEmployeeListById] An error occured in the processing of Record Id : " + PaymentToEmployeeFormUI.Tbl_PaymentToEmployeeId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPaymentToEmployee(PaymentToEmployeeFormUI PaymentToEmployeeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployee_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = PaymentToEmployeeFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentToEmployeeFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@PaymentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentNumber"].Value = PaymentToEmployeeFormUI.PaymentNumber;

                sqlCmd.Parameters.Add("@PaymentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PaymentDate"].Value = PaymentToEmployeeFormUI.PaymentDate;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = PaymentToEmployeeFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = PaymentToEmployeeFormUI.Tbl_EmployeeId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = PaymentToEmployeeFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PayablesId_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_BankTransfer"].Value = PaymentToEmployeeFormUI.Tbl_PayablesId_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = PaymentToEmployeeFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = PaymentToEmployeeFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = PaymentToEmployeeFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = PaymentToEmployeeFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = PaymentToEmployeeFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = PaymentToEmployeeFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = PaymentToEmployeeFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@Unapplied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Unapplied"].Value = PaymentToEmployeeFormUI.Unapplied;

                sqlCmd.Parameters.Add("@Applied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Applied"].Value = PaymentToEmployeeFormUI.Applied;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = PaymentToEmployeeFormUI.Total;
                sqlCmd.Parameters.Add("@IsAutoAppliyTo", SqlDbType.Bit);
                sqlCmd.Parameters["@IsAutoAppliyTo"].Value = PaymentToEmployeeFormUI.IsAutoAppliyTo;


                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = PaymentToEmployeeFormUI.IsPosted;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = PaymentToEmployeeFormUI.PostingDate;

                sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ApplyDate"].Value = PaymentToEmployeeFormUI.ApplyDate;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = PaymentToEmployeeFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DocumentType"].Value = PaymentToEmployeeFormUI.opt_DocumentType;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPaymentToEmployee()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToEmployeeFormDAL : AddPaymentToEmployee] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdatePaymentToEmployee(PaymentToEmployeeFormUI PaymentToEmployeeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployee_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = PaymentToEmployeeFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentToEmployeeFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentToEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentToEmployeeId"].Value = PaymentToEmployeeFormUI.Tbl_PaymentToEmployeeId;

                sqlCmd.Parameters.Add("@PaymentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentNumber"].Value = PaymentToEmployeeFormUI.PaymentNumber;

                sqlCmd.Parameters.Add("@PaymentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PaymentDate"].Value = PaymentToEmployeeFormUI.PaymentDate;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = PaymentToEmployeeFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = PaymentToEmployeeFormUI.Tbl_EmployeeId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = PaymentToEmployeeFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PayablesId_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_BankTransfer"].Value = PaymentToEmployeeFormUI.Tbl_PayablesId_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = PaymentToEmployeeFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = PaymentToEmployeeFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = PaymentToEmployeeFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = PaymentToEmployeeFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = PaymentToEmployeeFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = PaymentToEmployeeFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = PaymentToEmployeeFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@Unapplied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Unapplied"].Value = PaymentToEmployeeFormUI.Unapplied;

                sqlCmd.Parameters.Add("@Applied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Applied"].Value = PaymentToEmployeeFormUI.Applied;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = PaymentToEmployeeFormUI.Total;

                sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ApplyDate"].Value = PaymentToEmployeeFormUI.ApplyDate;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = PaymentToEmployeeFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DocumentType"].Value = PaymentToEmployeeFormUI.opt_DocumentType;





                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentToEmployee()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToEmployeeFormUI.Tbl_PaymentToEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToEmployeeFormDAL : UpdatePaymentToEmployee] An error occured in the processing of Record Id : " + PaymentToEmployeeFormUI.Tbl_PaymentToEmployeeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePaymentToEmployee(PaymentToEmployeeFormUI PaymentToEmployeeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployee_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeId"].Value = PaymentToEmployeeFormUI.Tbl_PaymentToEmployeeId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentToEmployee()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToEmployeeFormUI.Tbl_PaymentToEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeFormDAL : DeletePaymentToEmployee] An error occured in the processing of Record Id : " + PaymentToEmployeeFormUI.Tbl_PaymentToEmployeeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}