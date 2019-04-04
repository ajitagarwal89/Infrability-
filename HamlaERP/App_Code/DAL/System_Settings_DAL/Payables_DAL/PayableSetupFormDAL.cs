using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using log4net;
using Newtonsoft.Json;
using Finware;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Payable_Management_FormDal
/// </summary>
public class PayableSetupFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PayableSetupFormDAL()
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
            logExcpUIobj.MethodName = "PayableSetupFormDAL()";
            logExcpUIobj.ResourceName = "PayableSetupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PayableSetupFormDAL : PayableSetupFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPayableSetupListById(PayableSetupFormUI payableSetupFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PayableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupId"].Value = payableSetupFormUI.Tbl_PayableSetupId;

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
                audit_IUD.WebServiceSelectInsert("tbl_ReceivableSetupOption", payableSetupFormUI.Tbl_PayableSetupId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPayableSetupListById()";
            logExcpUIobj.ResourceName = "PayableSetupFormDAL.CS";
            logExcpUIobj.RecordId = payableSetupFormUI.Tbl_PayableSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupFormDAL : GetPayableSetupListById] An error occured in the processing of Record Id : " + payableSetupFormUI.Tbl_PayableSetupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddPayableSetup(PayableSetupFormUI payableSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetup_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = payableSetupFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = payableSetupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@AgingPeriods", SqlDbType.Bit);
                sqlCmd.Parameters["@AgingPeriods"].Value = payableSetupFormUI.AgingPeriods;

                sqlCmd.Parameters.Add("@ApplyBy", SqlDbType.Bit);
                sqlCmd.Parameters["@ApplyBy"].Value = payableSetupFormUI.ApplyBy;

                sqlCmd.Parameters.Add("@Opt_SummaryView", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_SummaryView"].Value = payableSetupFormUI.Opt_SummaryView;

                sqlCmd.Parameters.Add("@tbl_ChequeBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ChequeBookId"].Value = payableSetupFormUI.Tbl_ChequeBookId;

                sqlCmd.Parameters.Add("@RemoveVendorHold", SqlDbType.NVarChar);
                sqlCmd.Parameters["@RemoveVendorHold"].Value = payableSetupFormUI.RemoveVendorHold;

                sqlCmd.Parameters.Add("@ExceedMaxInvoiceAmount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ExceedMaxInvoiceAmount"].Value = payableSetupFormUI.ExceedMaxInvoiceAmount;

                sqlCmd.Parameters.Add("@ExceedMaxWriteOffAmount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ExceedMaxWriteOffAmount"].Value = payableSetupFormUI.ExceedMaxWriteOffAmount;

                sqlCmd.Parameters.Add("@PrintHistoricalAgedTrialBalance", SqlDbType.Bit);
                sqlCmd.Parameters["@PrintHistoricalAgedTrialBalance"].Value = payableSetupFormUI.PrintHistoricalAgedTrialBalance;

                sqlCmd.Parameters.Add("@DeleteUnpostedPrintedDocuments", SqlDbType.Bit);
                sqlCmd.Parameters["@DeleteUnpostedPrintedDocuments"].Value = payableSetupFormUI.DeleteUnpostedPrintedDocuments;

                sqlCmd.Parameters.Add("@AllowDuplicateInvoicesPerVendor", SqlDbType.Bit);
                sqlCmd.Parameters["@AllowDuplicateInvoicesPerVendor"].Value = payableSetupFormUI.AllowDuplicateInvoicesPerVendor;

                sqlCmd.Parameters.Add("@InvoiceDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@InvoiceDescription"].Value = payableSetupFormUI.InvoiceDescription;

                sqlCmd.Parameters.Add("@InvoiceCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@InvoiceCode"].Value = payableSetupFormUI.InvoiceCode;
                            
                sqlCmd.Parameters.Add("@ReturnDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReturnDescription"].Value = payableSetupFormUI.ReturnDescription;

                sqlCmd.Parameters.Add("@ReturnCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReturnCode"].Value = payableSetupFormUI.ReturnCode;

                sqlCmd.Parameters.Add("@CreditMemoDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreditMemoDescription"].Value = payableSetupFormUI.CreditMemoDescription;

                sqlCmd.Parameters.Add("@CreditMemoCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreditMemoCode"].Value = payableSetupFormUI.CreditMemoCode;

                sqlCmd.Parameters.Add("@PaymentDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentDescription"].Value = payableSetupFormUI.PaymentDescription;

                sqlCmd.Parameters.Add("@PaymentCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentCode"].Value = payableSetupFormUI.PaymentCode;

                sqlCmd.Parameters.Add("@tbl_PayableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupGroupId"].Value = payableSetupFormUI.Tbl_PayableSetupGroupId;

                sqlCmd.Parameters.Add("@tbl_PayableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupAndGroupAccountId"].Value = payableSetupFormUI.Tbl_PayableSetupAndGroupAccountId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = payableSetupFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountReceivable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountReceivable"].Value = payableSetupFormUI.Tbl_GLAccountId_AccountReceivable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Sales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Sales"].Value = payableSetupFormUI.Tbl_GLAccountId_Sales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_CostOfSales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_CostOfSales"].Value = payableSetupFormUI.Tbl_GLAccountId_CostOfSales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Inventory", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Inventory"].Value = payableSetupFormUI.Tbl_GLAccountId_Inventory;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccuralDifferedA_C", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccuralDifferedA_C"].Value = payableSetupFormUI.Tbl_GLAccountId_AccuralDifferedA_C;

                sqlCmd.Parameters.Add("@tbl_PayableSetupId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_PayableSetupId"].Direction = ParameterDirection.Output;


                result = sqlCmd.ExecuteNonQuery();

                string recoredID = Convert.ToString(sqlCmd.Parameters["@tbl_PayableSetupId"].Value);
                HttpContext.Current.Session["PayableSetupId"] = recoredID;
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_PayableSetup";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(payableSetupFormUI);
                    audit_IUD.WebServiceInsert(payableSetupFormUI.Tbl_OrganizationId, tableName, recoredID, payableSetupFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddPayableSetup()";
            logExcpUIobj.ResourceName = "PayableSetupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupFormDAL : AddPayableSetup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;

    }
    public int UpdatePayableSetup(PayableSetupFormUI payableSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetup_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = payableSetupFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = payableSetupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PayableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupId"].Value = payableSetupFormUI.Tbl_PayableSetupId;

                sqlCmd.Parameters.Add("@AgingPeriods", SqlDbType.Bit);
                sqlCmd.Parameters["@AgingPeriods"].Value = payableSetupFormUI.AgingPeriods;

                sqlCmd.Parameters.Add("@ApplyBy", SqlDbType.Bit);
                sqlCmd.Parameters["@ApplyBy"].Value = payableSetupFormUI.ApplyBy;

                sqlCmd.Parameters.Add("@Opt_SummaryView", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_SummaryView"].Value = payableSetupFormUI.Opt_SummaryView;

                sqlCmd.Parameters.Add("@tbl_ChequeBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ChequeBookId"].Value = payableSetupFormUI.Tbl_ChequeBookId;

                sqlCmd.Parameters.Add("@RemoveVendorHold", SqlDbType.NVarChar);
                sqlCmd.Parameters["@RemoveVendorHold"].Value = payableSetupFormUI.RemoveVendorHold;

                sqlCmd.Parameters.Add("@ExceedMaxInvoiceAmount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ExceedMaxInvoiceAmount"].Value = payableSetupFormUI.ExceedMaxInvoiceAmount;

                sqlCmd.Parameters.Add("@ExceedMaxWriteOffAmount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ExceedMaxWriteOffAmount"].Value = payableSetupFormUI.ExceedMaxWriteOffAmount;

                sqlCmd.Parameters.Add("@PrintHistoricalAgedTrialBalance", SqlDbType.Bit);
                sqlCmd.Parameters["@PrintHistoricalAgedTrialBalance"].Value = payableSetupFormUI.PrintHistoricalAgedTrialBalance;

                sqlCmd.Parameters.Add("@DeleteUnpostedPrintedDocuments", SqlDbType.Bit);
                sqlCmd.Parameters["@DeleteUnpostedPrintedDocuments"].Value = payableSetupFormUI.DeleteUnpostedPrintedDocuments;

                sqlCmd.Parameters.Add("@AllowDuplicateInvoicesPerVendor", SqlDbType.Bit);
                sqlCmd.Parameters["@AllowDuplicateInvoicesPerVendor"].Value = payableSetupFormUI.AllowDuplicateInvoicesPerVendor;

                sqlCmd.Parameters.Add("@InvoiceDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@InvoiceDescription"].Value = payableSetupFormUI.InvoiceDescription;

                sqlCmd.Parameters.Add("@InvoiceCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@InvoiceCode"].Value = payableSetupFormUI.InvoiceCode;

                sqlCmd.Parameters.Add("@ReturnDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReturnDescription"].Value = payableSetupFormUI.ReturnDescription;

                sqlCmd.Parameters.Add("@ReturnCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReturnCode"].Value = payableSetupFormUI.ReturnCode;

                sqlCmd.Parameters.Add("@CreditMemoDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreditMemoDescription"].Value = payableSetupFormUI.CreditMemoDescription;

                sqlCmd.Parameters.Add("@CreditMemoCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreditMemoCode"].Value = payableSetupFormUI.CreditMemoCode;

                sqlCmd.Parameters.Add("@PaymentDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentDescription"].Value = payableSetupFormUI.PaymentDescription;

                sqlCmd.Parameters.Add("@PaymentCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentCode"].Value = payableSetupFormUI.PaymentCode;

                sqlCmd.Parameters.Add("@tbl_PayableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupGroupId"].Value = payableSetupFormUI.Tbl_PayableSetupGroupId;

                sqlCmd.Parameters.Add("@tbl_PayableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupAndGroupAccountId"].Value = payableSetupFormUI.Tbl_PayableSetupAndGroupAccountId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = payableSetupFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountReceivable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountReceivable"].Value = payableSetupFormUI.Tbl_GLAccountId_AccountReceivable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Sales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Sales"].Value = payableSetupFormUI.Tbl_GLAccountId_Sales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_CostOfSales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_CostOfSales"].Value = payableSetupFormUI.Tbl_GLAccountId_CostOfSales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Inventory", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Inventory"].Value = payableSetupFormUI.Tbl_GLAccountId_Inventory;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccuralDifferedA_C", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccuralDifferedA_C"].Value = payableSetupFormUI.Tbl_GLAccountId_AccuralDifferedA_C;


                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(payableSetupFormUI);
                    audit_IUD.WebServiceUpdate(payableSetupFormUI.Tbl_OrganizationId, "tbl_PayableSetup", payableSetupFormUI.Tbl_PayableSetupId, payableSetupFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePayableSetup()";
            logExcpUIobj.ResourceName = "PayableSetupFormDAL.CS";
            logExcpUIobj.RecordId = payableSetupFormUI.Tbl_PayableSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupFormDAL : UpdatePayableSetup] An error occured in the processing of Record Id : " + payableSetupFormUI.Tbl_PayableSetupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int DeletePayableSetup(PayableSetupFormUI payableSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PayableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupId"].Value = payableSetupFormUI.Tbl_PayableSetupId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_PayableSetup", payableSetupFormUI.Tbl_PayableSetupId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePayableSetup()";
            logExcpUIobj.ResourceName = "PayableSetupFormDAL.CS";
            logExcpUIobj.RecordId = payableSetupFormUI.Tbl_PayableSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupFormDAL : DeletePayableSetup] An error occured in the processing of Record Id : " + payableSetupFormUI.Tbl_PayableSetupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}