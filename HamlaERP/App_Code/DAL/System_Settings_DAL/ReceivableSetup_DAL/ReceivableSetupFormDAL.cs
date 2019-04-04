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
/// <summary>
/// Summary description for ReceivableSetupFormDAL
/// </summary>
public class ReceivableSetupFormDAL: IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    ReceivableSetupFormUI receivableSetupFormUI = new ReceivableSetupFormUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public ReceivableSetupFormDAL()
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
            logExcpUIobj.MethodName = "ReceivableSetupFormDAL()";
            logExcpUIobj.ResourceName = "ReceivableSetupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[ReceivableSetupFormDAL : ReceivableSetupFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetReceivableSetupListById(ReceivableSetupFormUI receivableSetupFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupId"].Value = receivableSetupFormUI.Tbl_ReceivableSetupId;

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
                audit_IUD.WebServiceSelectInsert("tbl_ReceivableSetup", receivableSetupFormUI.Tbl_ReceivableSetupId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetReceivableSetupListById()";
            logExcpUIobj.ResourceName = "ReceivableSetupFormDAL.CS";
            logExcpUIobj.RecordId = receivableSetupFormUI.Tbl_ReceivableSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupFormDAL : GetReceivableSetupListById] An error occured in the processing of Record Id : " + receivableSetupFormUI.Tbl_ReceivableSetupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetReceivalbeSetupPeriodIdListById(ReceivableSetupFormUI receivableSetupFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivalbeSetupPeriodSelectId", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupId"].Value = receivableSetupFormUI.Tbl_ReceivableSetupId;

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
                audit_IUD.WebServiceSelectInsert("tbl_ReceivableSetup", receivableSetupFormUI.Tbl_ReceivableSetupId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetReceivalbeSetupPeriodIdListById()";
            logExcpUIobj.ResourceName = "ReceivableSetupFormDAL.CS";
            logExcpUIobj.RecordId = receivableSetupFormUI.Tbl_ReceivableSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupFormDAL : GetReceivalbeSetupPeriodIdListById] An error occured in the processing of Record Id : " + receivableSetupFormUI.Tbl_ReceivableSetupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddReceivableSetup(ReceivableSetupFormUI receivableSetupFormUI)
    {
        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetup_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = receivableSetupFormUI.CreatedBy;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = receivableSetupFormUI.Tbl_OrganizationId;
                sqlCmd.Parameters.Add("@IsAgingPeriods", SqlDbType.Bit);
                sqlCmd.Parameters["@IsAgingPeriods"].Value = receivableSetupFormUI.IsAgingPeriods;               
                sqlCmd.Parameters.Add("@ExceedCardLimit", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExceedCardLimit"].Value = receivableSetupFormUI.ExceedCardLimit;
                sqlCmd.Parameters.Add("@RemoveCustomerHold", SqlDbType.NVarChar);
                sqlCmd.Parameters["@RemoveCustomerHold"].Value = receivableSetupFormUI.RemoveCustomerHold;
                sqlCmd.Parameters.Add("@ExceedMaximumWriteOffs", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExceedMaximumWriteOffs"].Value = receivableSetupFormUI.ExceedMaximumWriteOffs;
                sqlCmd.Parameters.Add("@IsApplyBy", SqlDbType.Bit);
                sqlCmd.Parameters["@IsApplyBy"].Value = receivableSetupFormUI.IsApplyBy;

                sqlCmd.Parameters.Add("@tbl_CheckBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CheckBookId"].Value = receivableSetupFormUI.Tbl_CheckBookId;

                sqlCmd.Parameters.Add("@Opt_DocumentFormate", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_DocumentFormate"].Value = receivableSetupFormUI.Opt_DocumentFormate;
                sqlCmd.Parameters.Add("@Opt_SummaryView", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Opt_SummaryView"].Value = receivableSetupFormUI.Opt_SummaryView;
                sqlCmd.Parameters.Add("@IsReprintStatements", SqlDbType.Bit);
                sqlCmd.Parameters["@IsReprintStatements"].Value = receivableSetupFormUI.IsReprintStatements;
                sqlCmd.Parameters.Add("@IsPrintTrialBalance", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPrintTrialBalance"].Value = receivableSetupFormUI.IsPrintTrialBalance;
                //<!-- new Add -->
                sqlCmd.Parameters.Add("@SaleInvoiceDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SaleInvoiceDescription"].Value = receivableSetupFormUI.SaleInvoiceDescription;

                sqlCmd.Parameters.Add("@SaleInvoiceCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SaleInvoiceCode"].Value = receivableSetupFormUI.SaleInvoiceCode;


               

                sqlCmd.Parameters.Add("@DebitMemoDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DebitMemoDescription"].Value = receivableSetupFormUI.DebitMemoDescription;

                sqlCmd.Parameters.Add("@DebitMemoCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DebitMemoCode"].Value = receivableSetupFormUI.DebitMemoCode;

              

                sqlCmd.Parameters.Add("@CreditMemoDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreditMemoDescription"].Value = receivableSetupFormUI.CreditMemoDescription;

                sqlCmd.Parameters.Add("@CreditMemoCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreditMemoCode"].Value = receivableSetupFormUI.CreditMemoCode;


              

                sqlCmd.Parameters.Add("@ReturnDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReturnDescription"].Value = receivableSetupFormUI.ReturnDescription;


                sqlCmd.Parameters.Add("@ReturnCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReturnCode"].Value = receivableSetupFormUI.ReturnCode;


                sqlCmd.Parameters.Add("@CashReceiptDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CashReceiptDescription"].Value = receivableSetupFormUI.CashReceiptDescription;

                sqlCmd.Parameters.Add("@CashReceiptCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CashReceiptCode"].Value = receivableSetupFormUI.CashReceiptCode;

             

                sqlCmd.Parameters.Add("@StatementsPrintedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@StatementsPrintedDate"].Value = receivableSetupFormUI.StatementsPrintedDate;

                sqlCmd.Parameters.Add("@BalanceForwardAccountsAgedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@BalanceForwardAccountsAgedDate"].Value = receivableSetupFormUI.BalanceForwardAccountsAgedDate;

                sqlCmd.Parameters.Add("@OpenitemAccountsAgedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@OpenitemAccountsAgedDate"].Value = receivableSetupFormUI.OpenitemAccountsAgedDate;

                sqlCmd.Parameters.Add("@Sales", SqlDbType.Bit);
                sqlCmd.Parameters["@Sales"].Value = receivableSetupFormUI.Sales;

                sqlCmd.Parameters.Add("@Discount", SqlDbType.Bit);
                sqlCmd.Parameters["@Discount"].Value = receivableSetupFormUI.Discount;

                sqlCmd.Parameters.Add("@Freight", SqlDbType.Bit);
                sqlCmd.Parameters["@Freight"].Value = receivableSetupFormUI.Freight;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupGroupId"].Value = receivableSetupFormUI.Tbl_ReceivableSetupGroupId;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupAndGroupAccountId"].Value = receivableSetupFormUI.Tbl_ReceivableSetupAndGroupAccountId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = receivableSetupFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountReceivable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountReceivable"].Value = receivableSetupFormUI.Tbl_GLAccountId_AccountReceivable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Sales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Sales"].Value = receivableSetupFormUI.Tbl_GLAccountId_Sales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_CostOfSales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_CostOfSales"].Value = receivableSetupFormUI.Tbl_GLAccountId_CostOfSales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Inventory", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Inventory"].Value = receivableSetupFormUI.Tbl_GLAccountId_Inventory;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccuralDifferedA_C", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccuralDifferedA_C"].Value = receivableSetupFormUI.Tbl_GLAccountId_AccuralDifferedA_C;


                sqlCmd.Parameters.Add("@tbl_ReceivableSetupId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_ReceivableSetupId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_ReceivableSetupId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    string tableName = "tbl_ReceivableSetup";
                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(receivableSetupFormUI);
                    audit_IUD.WebServiceInsert(receivableSetupFormUI.Tbl_OrganizationId, tableName, RecoredID, receivableSetupFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddReceivableSetup()";
            logExcpUIobj.ResourceName = "ReceivableSetupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupFormDAL : AddReceivableSetup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateReceivableSetup(ReceivableSetupFormUI receivableSetupFormUI)
    {
        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetup_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = receivableSetupFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = receivableSetupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupId", SqlDbType.NChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupId"].Value = receivableSetupFormUI.Tbl_ReceivableSetupId;

                sqlCmd.Parameters.Add("@IsAgingPeriods", SqlDbType.Bit);
                sqlCmd.Parameters["@IsAgingPeriods"].Value = receivableSetupFormUI.IsAgingPeriods;    
                
                           
                sqlCmd.Parameters.Add("@ExceedCardLimit", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExceedCardLimit"].Value = receivableSetupFormUI.ExceedCardLimit;


                sqlCmd.Parameters.Add("@RemoveCustomerHold", SqlDbType.NVarChar);
                sqlCmd.Parameters["@RemoveCustomerHold"].Value = receivableSetupFormUI.RemoveCustomerHold;

                sqlCmd.Parameters.Add("@ExceedMaximumWriteOffs", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExceedMaximumWriteOffs"].Value = receivableSetupFormUI.ExceedMaximumWriteOffs;

                sqlCmd.Parameters.Add("@IsApplyBy", SqlDbType.Bit);
                sqlCmd.Parameters["@IsApplyBy"].Value = receivableSetupFormUI.IsApplyBy;


                sqlCmd.Parameters.Add("@tbl_CheckBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CheckBookId"].Value = receivableSetupFormUI.Tbl_CheckBookId;

                sqlCmd.Parameters.Add("@Opt_DocumentFormate", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_DocumentFormate"].Value = receivableSetupFormUI.Opt_DocumentFormate;

                sqlCmd.Parameters.Add("@Opt_SummaryView", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Opt_SummaryView"].Value = receivableSetupFormUI.Opt_SummaryView;


                sqlCmd.Parameters.Add("@IsReprintStatements", SqlDbType.Bit);
                sqlCmd.Parameters["@IsReprintStatements"].Value = receivableSetupFormUI.IsReprintStatements;

                sqlCmd.Parameters.Add("@IsPrintTrialBalance", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPrintTrialBalance"].Value = receivableSetupFormUI.IsPrintTrialBalance;
                //<!-- new Add -->
                sqlCmd.Parameters.Add("@SaleInvoiceDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SaleInvoiceDescription"].Value = receivableSetupFormUI.SaleInvoiceDescription;

                sqlCmd.Parameters.Add("@SaleInvoiceCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SaleInvoiceCode"].Value = receivableSetupFormUI.SaleInvoiceCode;


                sqlCmd.Parameters.Add("@DebitMemoDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DebitMemoDescription"].Value = receivableSetupFormUI.DebitMemoDescription;

                sqlCmd.Parameters.Add("@DebitMemoCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DebitMemoCode"].Value = receivableSetupFormUI.DebitMemoCode;

               

                sqlCmd.Parameters.Add("@CreditMemoDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreditMemoDescription"].Value = receivableSetupFormUI.CreditMemoDescription;

                sqlCmd.Parameters.Add("@CreditMemoCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreditMemoCode"].Value = receivableSetupFormUI.CreditMemoCode;

              

             

                sqlCmd.Parameters.Add("@ReturnDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReturnDescription"].Value = receivableSetupFormUI.ReturnDescription;


                sqlCmd.Parameters.Add("@ReturnCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReturnCode"].Value = receivableSetupFormUI.ReturnCode;

             

                sqlCmd.Parameters.Add("@CashReceiptDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CashReceiptDescription"].Value = receivableSetupFormUI.CashReceiptDescription;

                sqlCmd.Parameters.Add("@CashReceiptCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CashReceiptCode"].Value = receivableSetupFormUI.CashReceiptCode;

            

                sqlCmd.Parameters.Add("@StatementsPrintedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@StatementsPrintedDate"].Value = receivableSetupFormUI.StatementsPrintedDate;

                sqlCmd.Parameters.Add("@BalanceForwardAccountsAgedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@BalanceForwardAccountsAgedDate"].Value = receivableSetupFormUI.BalanceForwardAccountsAgedDate;

                sqlCmd.Parameters.Add("@OpenitemAccountsAgedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@OpenitemAccountsAgedDate"].Value = receivableSetupFormUI.OpenitemAccountsAgedDate;

                sqlCmd.Parameters.Add("@Sales", SqlDbType.Bit);
                sqlCmd.Parameters["@Sales"].Value = receivableSetupFormUI.Sales;

                sqlCmd.Parameters.Add("@Discount", SqlDbType.Bit);
                sqlCmd.Parameters["@Discount"].Value = receivableSetupFormUI.Discount;

                sqlCmd.Parameters.Add("@Freight", SqlDbType.Bit);
                sqlCmd.Parameters["@Freight"].Value = receivableSetupFormUI.Freight;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupGroupId"].Value = receivableSetupFormUI.Tbl_ReceivableSetupGroupId;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupAndGroupAccountId"].Value = receivableSetupFormUI.Tbl_ReceivableSetupAndGroupAccountId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = receivableSetupFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountReceivable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountReceivable"].Value = receivableSetupFormUI.Tbl_GLAccountId_AccountReceivable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Sales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Sales"].Value = receivableSetupFormUI.Tbl_GLAccountId_Sales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_CostOfSales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_CostOfSales"].Value = receivableSetupFormUI.Tbl_GLAccountId_CostOfSales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Inventory", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Inventory"].Value = receivableSetupFormUI.Tbl_GLAccountId_Inventory;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccuralDifferedA_C", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccuralDifferedA_C"].Value = receivableSetupFormUI.Tbl_GLAccountId_AccuralDifferedA_C;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_ReceivableSetupId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    string tableName = "tbl_ReceivableSetup";
                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(receivableSetupFormUI);
                    audit_IUD.WebServiceInsert(receivableSetupFormUI.Tbl_OrganizationId, tableName, RecoredID, receivableSetupFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddReceivableSetup()";
            logExcpUIobj.ResourceName = "ReceivableConfigurationSettingFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableConfigurationSettingFormDAL : AddReceivableSetup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteReceivableSetup(ReceivableSetupFormUI receivableSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupId"].Value = receivableSetupFormUI.Tbl_ReceivableSetupId;

                result = sqlCmd.ExecuteNonQuery();

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_ReceivableSetup", receivableSetupFormUI.Tbl_ReceivableSetupId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();

            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteReceivableSetup()";
            logExcpUIobj.ResourceName = "ReceivableSetupFormDAL.CS";
            logExcpUIobj.RecordId = receivableSetupFormUI.Tbl_ReceivableSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupFormDAL : DeleteReceivableSetup] An error occured in the processing of Record Id : " + receivableSetupFormUI.Tbl_ReceivableSetupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}