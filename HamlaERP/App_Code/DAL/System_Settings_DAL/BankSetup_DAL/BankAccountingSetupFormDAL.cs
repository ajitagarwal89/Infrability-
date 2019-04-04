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
/// Summary description for BankAccountingSetupFormDAL
/// </summary>
public class BankAccountingSetupFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    BankAccountingSetupFormUI bankAccountingSetupFormUI = new BankAccountingSetupFormUI();
    public BankAccountingSetupFormDAL()
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
            logExcpUIobj.MethodName = "BankAccountingSetupFormDAL()";
            logExcpUIobj.ResourceName = "BankAccountingSetupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[BankAccountingSetupFormDAL : BankAccountingSetupFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }


    public DataTable GetBankAccountingSetupListById(BankAccountingSetupFormUI bankAccountingSetupFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_BankAccountingSetup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_BankAccountingSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BankAccountingSetupId"].Value = bankAccountingSetupFormUI.Tbl_BankAccountingSetupId;

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
                audit_IUD.WebServiceSelectInsert("tbl_BankAccountingSetup", bankAccountingSetupFormUI.Tbl_BankAccountingSetupId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetBankAccountingSetupListById()";
            logExcpUIobj.ResourceName = "BankAccountingSetupFormDAL.CS";
            logExcpUIobj.RecordId = bankAccountingSetupFormUI.Tbl_BankAccountingSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BankAccountingSetupFormDAL : GetBankAccountingSetupListById] An error occured in the processing of Record Id : " + bankAccountingSetupFormUI.Tbl_BankAccountingSetupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddBankAccountingSetup(BankAccountingSetupFormUI bankAccountingSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_BankAccountingSetup_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = bankAccountingSetupFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = bankAccountingSetupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Depositcode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Depositcode"].Value = bankAccountingSetupFormUI.Depositcode;

                sqlCmd.Parameters.Add("@Deposit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Deposit"].Value = bankAccountingSetupFormUI.Deposit;

                sqlCmd.Parameters.Add("@ReceiptCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptCode"].Value = bankAccountingSetupFormUI.ReceiptCode;

                sqlCmd.Parameters.Add("@Receipt", SqlDbType.Decimal);
                sqlCmd.Parameters["@Receipt"].Value = bankAccountingSetupFormUI.Receipt;

                sqlCmd.Parameters.Add("@CheckCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CheckCode"].Value = bankAccountingSetupFormUI.CheckCode;

                sqlCmd.Parameters.Add("@Check", SqlDbType.Decimal);
                sqlCmd.Parameters["@Check"].Value = bankAccountingSetupFormUI.Check;

                sqlCmd.Parameters.Add("@WithdrawalCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@WithdrawalCode"].Value = bankAccountingSetupFormUI.WithdrawalCode;


                sqlCmd.Parameters.Add("@Withdrawal", SqlDbType.Decimal);
                sqlCmd.Parameters["@Withdrawal"].Value = bankAccountingSetupFormUI.Withdrawal;


                sqlCmd.Parameters.Add("@IncreaseAdjustmentCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@IncreaseAdjustmentCode"].Value = bankAccountingSetupFormUI.IncreaseAdjustmentCode;

                sqlCmd.Parameters.Add("@IncreaseAdjustment", SqlDbType.Decimal);
                sqlCmd.Parameters["@IncreaseAdjustment"].Value = bankAccountingSetupFormUI.IncreaseAdjustment;

                sqlCmd.Parameters.Add("@DecreaseAdjustmentCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DecreaseAdjustmentCode"].Value = bankAccountingSetupFormUI.DecreaseAdjustmentCode;

                sqlCmd.Parameters.Add("@DecreaseAdjustment", SqlDbType.Decimal);
                sqlCmd.Parameters["@DecreaseAdjustment"].Value = bankAccountingSetupFormUI.DecreaseAdjustment;

                sqlCmd.Parameters.Add("@TransferCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@TransferCode"].Value = bankAccountingSetupFormUI.TransferCode;

                sqlCmd.Parameters.Add("@Transfer", SqlDbType.Decimal);
                sqlCmd.Parameters["@Transfer"].Value = bankAccountingSetupFormUI.Transfer;

                sqlCmd.Parameters.Add("@IsTransaction_Reconcilation", SqlDbType.Bit);
                sqlCmd.Parameters["@IsTransaction_Reconcilation"].Value = bankAccountingSetupFormUI.IsTransaction_Reconcilation;

                sqlCmd.Parameters.Add("@tbl_ChequeBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ChequeBookId"].Value = bankAccountingSetupFormUI.Tbl_ChequeBookId;

                sqlCmd.Parameters.Add("@InterestIncomeCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@InterestIncomeCode"].Value = bankAccountingSetupFormUI.InterestIncomeCode;

                sqlCmd.Parameters.Add("@InterestIncome", SqlDbType.Decimal);
                sqlCmd.Parameters["@InterestIncome"].Value = bankAccountingSetupFormUI.InterestIncome;

                sqlCmd.Parameters.Add("@OtherIncomeCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OtherIncomeCode"].Value = bankAccountingSetupFormUI.OtherIncomeCode;

                sqlCmd.Parameters.Add("@OtherIncome", SqlDbType.Decimal);
                sqlCmd.Parameters["@OtherIncome"].Value = bankAccountingSetupFormUI.OtherIncome;

               
                sqlCmd.Parameters.Add("@OtherExpenseCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OtherExpenseCode"].Value = bankAccountingSetupFormUI.OtherExpenseCode;

                sqlCmd.Parameters.Add("@OtherExpense", SqlDbType.Decimal);
                sqlCmd.Parameters["@OtherExpense"].Value = bankAccountingSetupFormUI.OtherExpense;

                sqlCmd.Parameters.Add("@ServiceChargeCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ServiceChargeCode"].Value = bankAccountingSetupFormUI.ServiceChargeCode;

                sqlCmd.Parameters.Add("@ServiceCharge", SqlDbType.Decimal);
                sqlCmd.Parameters["@ServiceCharge"].Value = bankAccountingSetupFormUI.ServiceCharge;

                sqlCmd.Parameters.Add("@tbl_BankAccountingSetupId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_BankAccountingSetupId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();
                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_BankAccountingSetupId"].Value);
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    sqlCmd.Dispose();
                    SupportCon.Close();
                    string tableName = "tbl_BankAccountingSetup";
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(bankAccountingSetupFormUI);
                    audit_IUD.WebServiceInsert(bankAccountingSetupFormUI.Tbl_BankAccountingSetupId, tableName, RecoredID, bankAccountingSetupFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddBankAccountingSetup()";
            logExcpUIobj.ResourceName = "BankAccountingSetupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BankAccountingSetupFormDAL : AddBankAccountingSetup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateBankAccountingSetup(BankAccountingSetupFormUI bankAccountingSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_BankAccountingSetup_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = bankAccountingSetupFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_BankAccountingSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BankAccountingSetupId"].Value = bankAccountingSetupFormUI.Tbl_BankAccountingSetupId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = bankAccountingSetupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Depositcode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Depositcode"].Value = bankAccountingSetupFormUI.Depositcode;

                sqlCmd.Parameters.Add("@Deposit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Deposit"].Value = bankAccountingSetupFormUI.Deposit;

                sqlCmd.Parameters.Add("@ReceiptCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptCode"].Value = bankAccountingSetupFormUI.ReceiptCode;

                sqlCmd.Parameters.Add("@Receipt", SqlDbType.Decimal);
                sqlCmd.Parameters["@Receipt"].Value = bankAccountingSetupFormUI.Receipt;

                sqlCmd.Parameters.Add("@CheckCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CheckCode"].Value = bankAccountingSetupFormUI.CheckCode;

                sqlCmd.Parameters.Add("@Check", SqlDbType.Decimal);
                sqlCmd.Parameters["@Check"].Value = bankAccountingSetupFormUI.Check;

                sqlCmd.Parameters.Add("@WithdrawalCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@WithdrawalCode"].Value = bankAccountingSetupFormUI.WithdrawalCode;


                sqlCmd.Parameters.Add("@Withdrawal", SqlDbType.Decimal);
                sqlCmd.Parameters["@Withdrawal"].Value = bankAccountingSetupFormUI.Withdrawal;


                sqlCmd.Parameters.Add("@IncreaseAdjustmentCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@IncreaseAdjustmentCode"].Value = bankAccountingSetupFormUI.IncreaseAdjustmentCode;

                sqlCmd.Parameters.Add("@IncreaseAdjustment", SqlDbType.Decimal);
                sqlCmd.Parameters["@IncreaseAdjustment"].Value = bankAccountingSetupFormUI.IncreaseAdjustment;

                sqlCmd.Parameters.Add("@DecreaseAdjustmentCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DecreaseAdjustmentCode"].Value = bankAccountingSetupFormUI.DecreaseAdjustmentCode;

                sqlCmd.Parameters.Add("@DecreaseAdjustment", SqlDbType.Decimal);
                sqlCmd.Parameters["@DecreaseAdjustment"].Value = bankAccountingSetupFormUI.DecreaseAdjustment;

                sqlCmd.Parameters.Add("@TransferCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@TransferCode"].Value = bankAccountingSetupFormUI.TransferCode;

                sqlCmd.Parameters.Add("@Transfer", SqlDbType.Decimal);
                sqlCmd.Parameters["@Transfer"].Value = bankAccountingSetupFormUI.Transfer;

                sqlCmd.Parameters.Add("@IsTransaction_Reconcilation", SqlDbType.Bit);
                sqlCmd.Parameters["@IsTransaction_Reconcilation"].Value = bankAccountingSetupFormUI.IsTransaction_Reconcilation;

                sqlCmd.Parameters.Add("@tbl_ChequeBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ChequeBookId"].Value = bankAccountingSetupFormUI.Tbl_ChequeBookId;

                sqlCmd.Parameters.Add("@InterestIncomeCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@InterestIncomeCode"].Value = bankAccountingSetupFormUI.InterestIncomeCode;

                sqlCmd.Parameters.Add("@InterestIncome", SqlDbType.Decimal);
                sqlCmd.Parameters["@InterestIncome"].Value = bankAccountingSetupFormUI.InterestIncome;

                sqlCmd.Parameters.Add("@OtherIncomeCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OtherIncomeCode"].Value = bankAccountingSetupFormUI.OtherIncomeCode;

                sqlCmd.Parameters.Add("@OtherIncome", SqlDbType.Decimal);
                sqlCmd.Parameters["@OtherIncome"].Value = bankAccountingSetupFormUI.OtherIncome;


                sqlCmd.Parameters.Add("@OtherExpenseCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OtherExpenseCode"].Value = bankAccountingSetupFormUI.OtherExpenseCode;

                sqlCmd.Parameters.Add("@OtherExpense", SqlDbType.Decimal);
                sqlCmd.Parameters["@OtherExpense"].Value = bankAccountingSetupFormUI.OtherExpense;

                sqlCmd.Parameters.Add("@ServiceChargeCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ServiceChargeCode"].Value = bankAccountingSetupFormUI.ServiceChargeCode;

                sqlCmd.Parameters.Add("@ServiceCharge", SqlDbType.Decimal);
                sqlCmd.Parameters["@ServiceCharge"].Value = bankAccountingSetupFormUI.ServiceCharge;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(bankAccountingSetupFormUI);
                    audit_IUD.WebServiceUpdate(bankAccountingSetupFormUI.Tbl_OrganizationId, "tbl_BankAccountingSetup", bankAccountingSetupFormUI.Tbl_BankAccountingSetupId, bankAccountingSetupFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateBankAccountingSetup()";
            logExcpUIobj.ResourceName = "BankAccountingSetupFormDAL.CS";
            logExcpUIobj.RecordId = bankAccountingSetupFormUI.Tbl_BankAccountingSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BankAccountingSetupFormDAL : UpdateBankAccountingSetup] An error occured in the processing of Record Id : " + bankAccountingSetupFormUI.Tbl_BankAccountingSetupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteBankAccountingSetup(BankAccountingSetupFormUI bankAccountingSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_BankAccountingSetup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_BankAccountingSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BankAccountingSetupId"].Value = bankAccountingSetupFormUI.Tbl_BankAccountingSetupId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_BankAccountingSetup", bankAccountingSetupFormUI.Tbl_BankAccountingSetupId);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteBankAccountingSetup()";
            logExcpUIobj.ResourceName = "BankAccountingSetupFormDAL.CS";
            logExcpUIobj.RecordId = bankAccountingSetupFormUI.Tbl_BankAccountingSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BankAccountingSetupFormDAL : DeleteBatch] An error occured in the processing of Record Id : " + bankAccountingSetupFormUI.Tbl_BankAccountingSetupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}