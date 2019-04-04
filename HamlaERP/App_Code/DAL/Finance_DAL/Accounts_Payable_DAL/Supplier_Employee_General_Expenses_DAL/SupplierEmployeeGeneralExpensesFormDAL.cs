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
/// Summary description for SupplierEmployeeGeneralExpensesFormDAL
/// </summary>
public class SupplierEmployeeGeneralExpensesFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public SupplierEmployeeGeneralExpensesFormDAL()
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
            logExcpUIobj.MethodName = "SupplierEmployeeGeneralExpensesFormDAL()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[SupplierEmployeeGeneralExpensesFormDAL : SupplierEmployeeGeneralExpensesFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetSupplierEmployeeGeneralExpensesListById(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGeneralExpenses_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGeneralExpensesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGeneralExpensesId"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId;

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
                audit_IUD.WebServiceSelectInsert("tbl_SupplierEmployeeGeneralExpenses", supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId, selectedValue);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SupplierEmployeeGeneralExpensesListById()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeGeneralExpensesFormDAL : SupplierEmployeeGeneralExpensesListById] An error occured in the processing of Record Id : " + supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddSupplierEmployeeGeneralExpenses(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGeneralExpenses_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = supplierEmployeeGeneralExpensesFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@VoucherNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@VoucherNumber"].Value = supplierEmployeeGeneralExpensesFormUI.VoucherNumber;

                sqlCmd.Parameters.Add("@InterCompany", SqlDbType.Bit);
                sqlCmd.Parameters["@InterCompany"].Value = supplierEmployeeGeneralExpensesFormUI.InterCompany;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@Opt_DocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_DocumentType"].Value = supplierEmployeeGeneralExpensesFormUI.Opt_DocumentType;

                sqlCmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DocumentDate"].Value = supplierEmployeeGeneralExpensesFormUI.DocumentDate;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = supplierEmployeeGeneralExpensesFormUI.Description;

                

                sqlCmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceDate"].Value = supplierEmployeeGeneralExpensesFormUI.InvoiceDate;

                sqlCmd.Parameters.Add("@ReceivedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReceivedDate"].Value = supplierEmployeeGeneralExpensesFormUI.ReceivedDate;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeId"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@Expenses", SqlDbType.Decimal);
                sqlCmd.Parameters["@Expenses"].Value = supplierEmployeeGeneralExpensesFormUI.Expenses;

                sqlCmd.Parameters.Add("@Opt_PayablesType ", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_PayablesType "].Value = supplierEmployeeGeneralExpensesFormUI.Opt_PayablesType;

                sqlCmd.Parameters.Add("@tbl_Payables_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_BankTransfer"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = supplierEmployeeGeneralExpensesFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_Payables_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_Cash"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_Cash;

                sqlCmd.Parameters.Add("@Cash", SqlDbType.Decimal);
                sqlCmd.Parameters["@Cash"].Value = supplierEmployeeGeneralExpensesFormUI.Cash;

                sqlCmd.Parameters.Add("@tbl_Payables_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_Cheque"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_Cheque;

                sqlCmd.Parameters.Add("@Cheque", SqlDbType.Decimal);
                sqlCmd.Parameters["@Cheque"].Value = supplierEmployeeGeneralExpensesFormUI.Cheque;

                sqlCmd.Parameters.Add("@tbl_Payables_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_CreditCard"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_CreditCard;

                sqlCmd.Parameters.Add("@CreditCard", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCard"].Value = supplierEmployeeGeneralExpensesFormUI.Cheque;
               
                sqlCmd.Parameters.Add("@OnAccount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OnAccount"].Value = supplierEmployeeGeneralExpensesFormUI.OnAccount;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGeneralExpensesId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGeneralExpensesId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_SupplierEmployeeGeneralExpensesId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_SupplierEmployeeGeneralExpenses";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(supplierEmployeeGeneralExpensesFormUI);
                    audit_IUD.WebServiceInsert(supplierEmployeeGeneralExpensesFormUI.Tbl_OrganizationId, tableName, RecoredID, supplierEmployeeGeneralExpensesFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddSupplierEmployeeGeneralExpenses()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeGeneralExpensesFormDAL : AddSupplierEmployeeGeneralExpenses] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateSupplierEmployeeGeneralExpenses(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGeneralExpenses_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = supplierEmployeeGeneralExpensesFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGeneralExpensesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGeneralExpensesId"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId;

                sqlCmd.Parameters.Add("@VoucherNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@VoucherNumber"].Value = supplierEmployeeGeneralExpensesFormUI.VoucherNumber;

                sqlCmd.Parameters.Add("@InterCompany", SqlDbType.Bit);
                sqlCmd.Parameters["@InterCompany"].Value = supplierEmployeeGeneralExpensesFormUI.InterCompany;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@Opt_DocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_DocumentType"].Value = supplierEmployeeGeneralExpensesFormUI.Opt_DocumentType;

                sqlCmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DocumentDate"].Value = supplierEmployeeGeneralExpensesFormUI.DocumentDate;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = supplierEmployeeGeneralExpensesFormUI.Description;

               

                sqlCmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceDate"].Value = supplierEmployeeGeneralExpensesFormUI.InvoiceDate;

                sqlCmd.Parameters.Add("@ReceivedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReceivedDate"].Value = supplierEmployeeGeneralExpensesFormUI.ReceivedDate;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeId"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@Expenses", SqlDbType.Decimal);
                sqlCmd.Parameters["@Expenses"].Value = supplierEmployeeGeneralExpensesFormUI.Expenses;

                sqlCmd.Parameters.Add("@Opt_PayablesType ", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_PayablesType "].Value = supplierEmployeeGeneralExpensesFormUI.Opt_PayablesType;
                
                sqlCmd.Parameters.Add("@tbl_Payables_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_BankTransfer"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = supplierEmployeeGeneralExpensesFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_Payables_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_Cash"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_Cash;

                sqlCmd.Parameters.Add("@Cash", SqlDbType.Decimal);
                sqlCmd.Parameters["@Cash"].Value = supplierEmployeeGeneralExpensesFormUI.Cash;

                sqlCmd.Parameters.Add("@tbl_Payables_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_Cheque"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_Cheque;

                sqlCmd.Parameters.Add("@Cheque", SqlDbType.Decimal);
                sqlCmd.Parameters["@Cheque"].Value = supplierEmployeeGeneralExpensesFormUI.Cheque;

                sqlCmd.Parameters.Add("@tbl_Payables_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_CreditCard"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_Payables_CreditCard;

                sqlCmd.Parameters.Add("@CreditCard", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCard"].Value = supplierEmployeeGeneralExpensesFormUI.Cheque;

                sqlCmd.Parameters.Add("@OnAccount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OnAccount"].Value = supplierEmployeeGeneralExpensesFormUI.OnAccount;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(supplierEmployeeGeneralExpensesFormUI);
                    audit_IUD.WebServiceUpdate(supplierEmployeeGeneralExpensesFormUI.Tbl_OrganizationId, "tbl_SupplierEmployeeGeneralExpenses", supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId, supplierEmployeeGeneralExpensesFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateSupplierEmployeeGeneralExpenses()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeGeneralExpensesFormDAL : UpdateSupplierEmployeeGeneralExpenses] An error occured in the processing of Record Id : " + supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteSupplierEmployeeGeneralExpenses(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGeneralExpenses_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGeneralExpensesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGeneralExpensesId"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_SupplierEmployeeGeneralExpenses", supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSupplierEmployeeGeneralExpenses()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeGeneralExpensesFormDAL : DeleteSupplierEmployeeGeneralExpenses] An error occured in the processing of Record Id : " + supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePostingSupplierEmployeeGeneralExpenses(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {
        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGeneralExpenses_UpdatePosting", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGeneralExpensesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGeneralExpensesId"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = supplierEmployeeGeneralExpensesFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierEmployeeGeneralExpensesFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = supplierEmployeeGeneralExpensesFormUI.IsPosted;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(supplierEmployeeGeneralExpensesFormUI);
                    audit_IUD.WebServiceUpdate(supplierEmployeeGeneralExpensesFormUI.Tbl_OrganizationId, "tbl_SupplierEmployeeGeneralExpenses", supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId, supplierEmployeeGeneralExpensesFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();

            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePostingSupplierEmployeeGeneralExpenses()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[SupplierEmployeeGeneralExpensesFormDAL : UpdatePostingSupplierEmployeeGeneralExpenses] An error occured in the processing of Record Id : " + supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }


        return result;

    }

    public DataTable GetSerialNumber(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGeneralExpenses_SerialNumber", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@RecordType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@RecordType"].Value = supplierEmployeeGeneralExpensesFormUI.InvoiceType;

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
                audit_IUD.WebServiceSelectInsert("tbl_SupplierEmployeeGeneralExpenses", supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSerialNumber()";
            logExcpUIobj.ResourceName = "EmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeGeneralExpensesFormDAL : GetSerialNumber] An error occured in the processing of Record Id : " + supplierEmployeeGeneralExpensesFormUI.Tbl_SupplierEmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
}