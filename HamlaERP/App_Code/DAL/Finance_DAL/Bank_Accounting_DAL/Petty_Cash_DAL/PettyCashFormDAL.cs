using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for PettyCashFormDAL
/// </summary>
public class PettyCashFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PettyCashFormDAL()
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
            logExcpUIobj.MethodName = "PettyCashFormDAL()";
            logExcpUIobj.ResourceName = "PettyCashFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PettyCashFormDAL : PettyCashFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetPettyCashListById(PettyCashFormUI pettyCashFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PettyCash_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PettyCashId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PettyCashId"].Value = pettyCashFormUI.Tbl_PettyCashId;

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
            logExcpUIobj.MethodName = "getPettyCashListById()";
            logExcpUIobj.ResourceName = "PettyCashFormDAL.CS";
            logExcpUIobj.RecordId = pettyCashFormUI.Tbl_PettyCashId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PettyCashFormDAL : getPettyCashListById] An error occured in the processing of Record Id : " + pettyCashFormUI.Tbl_PettyCashId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPettyCash(PettyCashFormUI pettyCashFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PettyCash_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = pettyCashFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pettyCashFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@PettyCashId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PettyCashId"].Value = pettyCashFormUI.PettyCashId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = pettyCashFormUI.Description;

                sqlCmd.Parameters.Add("@IsInactive", SqlDbType.Bit);
                sqlCmd.Parameters["@IsInactive"].Value = pettyCashFormUI.IsInactive;

                sqlCmd.Parameters.Add("@IBAN", SqlDbType.NVarChar);
                sqlCmd.Parameters["@IBAN"].Value = pettyCashFormUI.IBAN;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = pettyCashFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@CurrentPettyCashBalance", SqlDbType.Decimal);
                sqlCmd.Parameters["@CurrentPettyCashBalance"].Value = pettyCashFormUI.CurrentPettyCashBalance;

                sqlCmd.Parameters.Add("@CashAccountBalance", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAccountBalance"].Value = pettyCashFormUI.CashAccountBalance;

                sqlCmd.Parameters.Add("@tbl_GLAccount_CashAccount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_CashAccount"].Value = pettyCashFormUI.Tbl_GLAccount_CashAccount;

                sqlCmd.Parameters.Add("@NextPettyCashNumber", SqlDbType.BigInt);
                sqlCmd.Parameters["@NextPettyCashNumber"].Value = pettyCashFormUI.NextPettyCashNumber;

                sqlCmd.Parameters.Add("@NextDepositNumber", SqlDbType.BigInt);
                sqlCmd.Parameters["@NextDepositNumber"].Value = pettyCashFormUI.NextDepositNumber;

                sqlCmd.Parameters.Add("@AccountNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AccountNumber"].Value = pettyCashFormUI.AccountNumber;

                sqlCmd.Parameters.Add("@DuplicateChequeNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DuplicateChequeNumber"].Value = pettyCashFormUI.DuplicateChequeNumber;

                sqlCmd.Parameters.Add("@OverrideChequeNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OverrideChequeNumber"].Value = pettyCashFormUI.OverrideChequeNumber;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPettyCash()";
            logExcpUIobj.ResourceName = "PettyCashFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PettyCashFormDAL : AddPettyCashe] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePettyCash(PettyCashFormUI pettyCashFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PettyCash_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PettyCashId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PettyCashId"].Value = pettyCashFormUI.Tbl_PettyCashId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = pettyCashFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pettyCashFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@PettyCashId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PettyCashId"].Value = pettyCashFormUI.PettyCashId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = pettyCashFormUI.Description;

                sqlCmd.Parameters.Add("@IsInactive", SqlDbType.Bit);
                sqlCmd.Parameters["@IsInactive"].Value = pettyCashFormUI.IsInactive;

                sqlCmd.Parameters.Add("@IBAN", SqlDbType.NVarChar);
                sqlCmd.Parameters["@IBAN"].Value = pettyCashFormUI.IBAN;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = pettyCashFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@CurrentPettyCashBalance", SqlDbType.Decimal);
                sqlCmd.Parameters["@CurrentPettyCashBalance"].Value = pettyCashFormUI.CurrentPettyCashBalance;

                sqlCmd.Parameters.Add("@CashAccountBalance", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAccountBalance"].Value = pettyCashFormUI.CashAccountBalance;

                sqlCmd.Parameters.Add("@tbl_GLAccount_CashAccount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_CashAccount"].Value = pettyCashFormUI.Tbl_GLAccount_CashAccount;

                sqlCmd.Parameters.Add("@NextPettyCashNumber", SqlDbType.BigInt);
                sqlCmd.Parameters["@NextPettyCashNumber"].Value = pettyCashFormUI.NextPettyCashNumber;

                sqlCmd.Parameters.Add("@NextDepositNumber", SqlDbType.BigInt);
                sqlCmd.Parameters["@NextDepositNumber"].Value = pettyCashFormUI.NextDepositNumber;

                sqlCmd.Parameters.Add("@AccountNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AccountNumber"].Value = pettyCashFormUI.AccountNumber;

                sqlCmd.Parameters.Add("@DuplicateChequeNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DuplicateChequeNumber"].Value = pettyCashFormUI.DuplicateChequeNumber;

                sqlCmd.Parameters.Add("@OverrideChequeNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OverrideChequeNumber"].Value = pettyCashFormUI.OverrideChequeNumber;



                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePettyCash()";
            logExcpUIobj.ResourceName = "PettyCashFormDAL.CS";
            logExcpUIobj.RecordId = pettyCashFormUI.Tbl_PettyCashId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PettyCashFormDAL : UpdatePettyCash] An error occured in the processing of Record Id : " + pettyCashFormUI.Tbl_PettyCashId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePettyCash(PettyCashFormUI pettyCashFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PettyCash_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PettyCashId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PettyCashId"].Value = pettyCashFormUI.Tbl_PettyCashId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePettyCash()";
            logExcpUIobj.ResourceName = "PettyCashFormDAL.CS";
            logExcpUIobj.RecordId = pettyCashFormUI.Tbl_PettyCashId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PettyCashFormDAL : DeletePettyCash] An error occured in the processing of Record Id : " + pettyCashFormUI.Tbl_PettyCashId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}