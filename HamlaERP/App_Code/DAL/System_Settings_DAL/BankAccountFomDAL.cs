using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for BankFormDAL
/// </summary>
public class BankAccountFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public BankAccountFormDAL()
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
            logExcpUIobj.MethodName = "BankAccountFormDAL()";
            logExcpUIobj.ResourceName = "BankAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[BankAccountFormDAL : BankAccountFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetBankAccountListById(BankAccountFormUI bankAccountFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_BankAccount_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_BankAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BankAccountId"].Value = bankAccountFormUI.Tbl_BankAccountId;

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
            logExcpUIobj.MethodName = "getBankAccountListById()";
            logExcpUIobj.ResourceName = "BankAccountFormDAL.CS";
            logExcpUIobj.RecordId = bankAccountFormUI.Tbl_BankAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BankAccountFormDAL : getBankAccountListById] An error occured in the processing of Record Id : " + bankAccountFormUI.Tbl_BankAccountId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddBankAccount(BankAccountFormUI bankAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_BankAccount_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = bankAccountFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = bankAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@BankAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BankAccountId"].Value = bankAccountFormUI.BankAccountId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = bankAccountFormUI.Description;

                sqlCmd.Parameters.Add("@IsInactive", SqlDbType.NVarChar);
                sqlCmd.Parameters["@IsInactive"].Value = bankAccountFormUI.IsInactive;

                sqlCmd.Parameters.Add("@IBAN", SqlDbType.NVarChar);
                sqlCmd.Parameters["@IBAN"].Value = bankAccountFormUI.IBAN;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = bankAccountFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@CurrentChequebookBalance", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CurrentChequebookBalance"].Value = bankAccountFormUI.CurrentChequebookBalance;

                sqlCmd.Parameters.Add("@CashAccountBalance", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CashAccountBalance"].Value = bankAccountFormUI.CashAccountBalance;

                sqlCmd.Parameters.Add("@tbl_GLAccount_CashAccount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_CashAccount"].Value = bankAccountFormUI.Tbl_GLAccount_CashAccount;

                sqlCmd.Parameters.Add("@NextChequeNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@NextChequeNumber"].Value = bankAccountFormUI.NextChequeNumber;

                sqlCmd.Parameters.Add("@NextDepositNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@NextDepositNumber"].Value = bankAccountFormUI.NextDepositNumber;

                sqlCmd.Parameters.Add("@LastReconciledBalance", SqlDbType.NVarChar);
                sqlCmd.Parameters["@LastReconciledBalance"].Value = bankAccountFormUI.LastReconciledBalance;

                sqlCmd.Parameters.Add("@LastReconciledDate", SqlDbType.NVarChar);
                sqlCmd.Parameters["@LastReconciledDate"].Value = bankAccountFormUI.LastReconciledDate;

                sqlCmd.Parameters.Add("@AccountNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AccountNumber"].Value = bankAccountFormUI.AccountNumber;

                sqlCmd.Parameters.Add("@tbl_BankId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BankId"].Value = bankAccountFormUI.Tbl_BankId;

                sqlCmd.Parameters.Add("@DuplicateChequeNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DuplicateChequeNumber"].Value = bankAccountFormUI.DuplicateChequeNumber;

                sqlCmd.Parameters.Add("@OverrideChequeNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OverrideChequeNumber"].Value = bankAccountFormUI.OverrideChequeNumber;








                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddBankAccount()";
            logExcpUIobj.ResourceName = "BankAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BankAccountFormDAL : AddBankAccount] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateBankAccount(BankAccountFormUI bankAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_BankAccount_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_BankAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BankAccountId"].Value = bankAccountFormUI.Tbl_BankAccountId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = bankAccountFormUI.ModifiedBy;          

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = bankAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@BankAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BankAccountId"].Value = bankAccountFormUI.BankAccountId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = bankAccountFormUI.Description;

                sqlCmd.Parameters.Add("@IsInactive", SqlDbType.NVarChar);
                sqlCmd.Parameters["@IsInactive"].Value = bankAccountFormUI.IsInactive;

                sqlCmd.Parameters.Add("@IBAN", SqlDbType.NVarChar);
                sqlCmd.Parameters["@IBAN"].Value = bankAccountFormUI.IBAN;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = bankAccountFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@CurrentChequebookBalance", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CurrentChequebookBalance"].Value = bankAccountFormUI.CurrentChequebookBalance;

                sqlCmd.Parameters.Add("@CashAccountBalance", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CashAccountBalance"].Value = bankAccountFormUI.CashAccountBalance;

                sqlCmd.Parameters.Add("@tbl_GLAccount_CashAccount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_CashAccount"].Value = bankAccountFormUI.Tbl_GLAccount_CashAccount;

                sqlCmd.Parameters.Add("@NextChequeNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@NextChequeNumber"].Value = bankAccountFormUI.NextChequeNumber;

                sqlCmd.Parameters.Add("@NextDepositNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@NextDepositNumber"].Value = bankAccountFormUI.NextDepositNumber;

                sqlCmd.Parameters.Add("@LastReconciledBalance", SqlDbType.NVarChar);
                sqlCmd.Parameters["@LastReconciledBalance"].Value = bankAccountFormUI.LastReconciledBalance;

                sqlCmd.Parameters.Add("@LastReconciledDate", SqlDbType.NVarChar);
                sqlCmd.Parameters["@LastReconciledDate"].Value = bankAccountFormUI.LastReconciledDate;

                sqlCmd.Parameters.Add("@AccountNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AccountNumber"].Value = bankAccountFormUI.AccountNumber;

                sqlCmd.Parameters.Add("@tbl_BankId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BankId"].Value = bankAccountFormUI.Tbl_BankId;

                sqlCmd.Parameters.Add("@DuplicateChequeNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DuplicateChequeNumber"].Value = bankAccountFormUI.DuplicateChequeNumber;

                sqlCmd.Parameters.Add("@OverrideChequeNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OverrideChequeNumber"].Value = bankAccountFormUI.OverrideChequeNumber;



                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateBankAccount()";
            logExcpUIobj.ResourceName = "BankAccountFormDAL.CS";
            logExcpUIobj.RecordId = bankAccountFormUI.Tbl_BankAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BankAccountFormDAL : UpdateBankAccount] An error occured in the processing of Record Id : " + bankAccountFormUI.Tbl_BankAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteBankAccount(BankAccountFormUI bankAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_BankAccount_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_BankAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BankAccountId"].Value = bankAccountFormUI.Tbl_BankAccountId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteBankAccount()";
            logExcpUIobj.ResourceName = "BankAccountFormDAL.CS";
            logExcpUIobj.RecordId = bankAccountFormUI.Tbl_BankAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BankAccountFormDAL : DeleteBankAccount] An error occured in the processing of Record Id : " + bankAccountFormUI.Tbl_BankAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}