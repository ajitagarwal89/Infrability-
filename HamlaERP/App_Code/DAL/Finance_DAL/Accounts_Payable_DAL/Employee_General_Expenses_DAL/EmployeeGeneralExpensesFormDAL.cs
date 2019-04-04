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
/// Summary description for EmployeeGeneralExpensesFormDAL
/// </summary>
public class EmployeeGeneralExpensesFormDAL: IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public EmployeeGeneralExpensesFormDAL()
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
            logExcpUIobj.MethodName = "EmployeeGeneralExpensesFormDAL()";
            logExcpUIobj.ResourceName = "EmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[EmployeeGeneralExpensesFormDAL : EmployeeGeneralExpensesFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetEmployeeGeneralExpensesListById(EmployeeGeneralExpensesFormUI employeeGeneralExpensesFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeGeneralExpenses_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeGeneralExpensesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeGeneralExpensesId"].Value = employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId;

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
                audit_IUD.WebServiceSelectInsert("tbl_EmployeeGeneralExpenses", employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId, selectedValue);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetEmployeeGeneralExpensesListById()";
            logExcpUIobj.ResourceName = "EmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeGeneralExpensesFormDAL : GetEmployeeGeneralExpensesListById] An error occured in the processing of Record Id : " + employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddEmployeeGeneralExpenses(EmployeeGeneralExpensesFormUI employeeGeneralExpensesFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeGeneralExpenses_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = employeeGeneralExpensesFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeGeneralExpensesFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@VoucherNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@VoucherNumber"].Value = employeeGeneralExpensesFormUI.VoucherNumber;

                sqlCmd.Parameters.Add("@InterCompany", SqlDbType.Bit);
                sqlCmd.Parameters["@InterCompany"].Value = employeeGeneralExpensesFormUI.InterCompany;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = employeeGeneralExpensesFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@Opt_DocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_DocumentType"].Value = employeeGeneralExpensesFormUI.Opt_DocumentType;

                sqlCmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DocumentDate"].Value = employeeGeneralExpensesFormUI.DocumentDate;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = employeeGeneralExpensesFormUI.Description;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = employeeGeneralExpensesFormUI.PostingDate;

              

                sqlCmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceDate"].Value = employeeGeneralExpensesFormUI.InvoiceDate;

              

                sqlCmd.Parameters.Add("@ReceivedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReceivedDate"].Value = employeeGeneralExpensesFormUI.ReceivedDate;

            

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = employeeGeneralExpensesFormUI.Tbl_EmployeeId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = employeeGeneralExpensesFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@Expenses", SqlDbType.Decimal);
                sqlCmd.Parameters["@Expenses"].Value = employeeGeneralExpensesFormUI.Expenses;

                sqlCmd.Parameters.Add("@tbl_Payables_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_BankTransfer"].Value = employeeGeneralExpensesFormUI.Tbl_Payables_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = employeeGeneralExpensesFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@Opt_PayablesType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_PayablesType"].Value = employeeGeneralExpensesFormUI.Opt_PayablesType;

                sqlCmd.Parameters.Add("@tbl_Payables_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_Cash"].Value = employeeGeneralExpensesFormUI.Tbl_Payables_Cash;

                sqlCmd.Parameters.Add("@Cash", SqlDbType.Decimal);
                sqlCmd.Parameters["@Cash"].Value = employeeGeneralExpensesFormUI.Cash;

                sqlCmd.Parameters.Add("@tbl_Payables_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_Cheque"].Value = employeeGeneralExpensesFormUI.Tbl_Payables_Cheque;

                sqlCmd.Parameters.Add("@Cheque", SqlDbType.Decimal);
                sqlCmd.Parameters["@Cheque"].Value = employeeGeneralExpensesFormUI.Cheque;

                sqlCmd.Parameters.Add("@tbl_Payables_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_CreditCard"].Value = employeeGeneralExpensesFormUI.Tbl_Payables_CreditCard;

                sqlCmd.Parameters.Add("@CreditCard", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCard"].Value = employeeGeneralExpensesFormUI.CreditCard;

                sqlCmd.Parameters.Add("@OnAccount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OnAccount"].Value = employeeGeneralExpensesFormUI.OnAccount;

                sqlCmd.Parameters.Add("@tbl_EmployeeGeneralExpensesId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_EmployeeGeneralExpensesId"].Direction = ParameterDirection.Output;              


                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_EmployeeGeneralExpensesId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                   sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(employeeGeneralExpensesFormUI);
                    audit_IUD.WebServiceInsert(employeeGeneralExpensesFormUI.Tbl_OrganizationId, "tbl_EmployeeGeneralExpenses", recordID, employeeGeneralExpensesFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddEmployeeGeneralExpenses()";
            logExcpUIobj.ResourceName = "EmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeGeneralExpensesFormDAL : AddEmployeeGeneralExpenses] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateEmployeeGeneralExpenses(EmployeeGeneralExpensesFormUI employeeGeneralExpensesFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeGeneralExpenses_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = employeeGeneralExpensesFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeGeneralExpensesFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_EmployeeGeneralExpensesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeGeneralExpensesId"].Value = employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId;

                sqlCmd.Parameters.Add("@VoucherNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@VoucherNumber"].Value = employeeGeneralExpensesFormUI.VoucherNumber;

                sqlCmd.Parameters.Add("@InterCompany", SqlDbType.Bit);
                sqlCmd.Parameters["@InterCompany"].Value = employeeGeneralExpensesFormUI.InterCompany;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = employeeGeneralExpensesFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@Opt_DocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_DocumentType"].Value = employeeGeneralExpensesFormUI.Opt_DocumentType;

                sqlCmd.Parameters.Add("@Opt_PayablesType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_PayablesType"].Value = employeeGeneralExpensesFormUI.Opt_PayablesType;


                sqlCmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DocumentDate"].Value = employeeGeneralExpensesFormUI.DocumentDate;

              

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = employeeGeneralExpensesFormUI.Description;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = employeeGeneralExpensesFormUI.PostingDate;

                
                sqlCmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceDate"].Value = employeeGeneralExpensesFormUI.InvoiceDate;

            
                sqlCmd.Parameters.Add("@ReceivedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReceivedDate"].Value = employeeGeneralExpensesFormUI.ReceivedDate;

       
                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = employeeGeneralExpensesFormUI.Tbl_EmployeeId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = employeeGeneralExpensesFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@Expenses", SqlDbType.Decimal);
                sqlCmd.Parameters["@Expenses"].Value = employeeGeneralExpensesFormUI.Expenses;

                sqlCmd.Parameters.Add("@tbl_Payables_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_BankTransfer"].Value = employeeGeneralExpensesFormUI.Tbl_Payables_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = employeeGeneralExpensesFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_Payables_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_Cash"].Value = employeeGeneralExpensesFormUI.Tbl_Payables_Cash;

                sqlCmd.Parameters.Add("@Cash", SqlDbType.Decimal);
                sqlCmd.Parameters["@Cash"].Value = employeeGeneralExpensesFormUI.Cash;

                sqlCmd.Parameters.Add("@tbl_Payables_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_Cheque"].Value = employeeGeneralExpensesFormUI.Tbl_Payables_Cheque;

                sqlCmd.Parameters.Add("@Cheque", SqlDbType.Decimal);
                sqlCmd.Parameters["@Cheque"].Value = employeeGeneralExpensesFormUI.Cheque;

                sqlCmd.Parameters.Add("@tbl_Payables_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Payables_CreditCard"].Value = employeeGeneralExpensesFormUI.Tbl_Payables_CreditCard;

                sqlCmd.Parameters.Add("@CreditCard", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCard"].Value = employeeGeneralExpensesFormUI.CreditCard;

                sqlCmd.Parameters.Add("@OnAccount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OnAccount"].Value = employeeGeneralExpensesFormUI.OnAccount;

                result = sqlCmd.ExecuteNonQuery();

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(employeeGeneralExpensesFormUI);
                    audit_IUD.WebServiceUpdate(employeeGeneralExpensesFormUI.Tbl_OrganizationId, "tbl_EmployeeGeneralExpenses", employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId, employeeGeneralExpensesFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateEmployeeGeneralExpenses()";
            logExcpUIobj.ResourceName = "EmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeGeneralExpensesFormDAL : UpdateEmployeeGeneralExpenses] An error occured in the processing of Record Id : " + employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteEmployeeGeneralExpenses(EmployeeGeneralExpensesFormUI employeeGeneralExpensesFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeGeneralExpenses_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeGeneralExpensesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeGeneralExpensesId"].Value = employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_EmployeeGeneralExpenses", employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteEmployeeGeneralExpenses()";
            logExcpUIobj.ResourceName = "EmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeGeneralExpensesFormDAL : DeleteEmployeeGeneralExpenses] An error occured in the processing of Record Id : " + employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePostingEmployeeGeneralExpenses(EmployeeGeneralExpensesFormUI employeeGeneralExpensesFormUI)
    {
        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeGeneralExpenses_UpdatePosting", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeGeneralExpensesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeGeneralExpensesId"].Value = employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = employeeGeneralExpensesFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeGeneralExpensesFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = employeeGeneralExpensesFormUI.IsPosted;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(employeeGeneralExpensesFormUI);
                    audit_IUD.WebServiceUpdate(employeeGeneralExpensesFormUI.Tbl_OrganizationId, "tbl_EmployeeGeneralExpenses", employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId, employeeGeneralExpensesFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();

            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePostingEmployeeGeneralExpenses()";
            logExcpUIobj.ResourceName = "EmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[EmployeeGeneralExpensesFormDAL : UpdatePostingEmployeeGeneralExpenses] An error occured in the processing of Record Id : " + employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }


        return result;

    }

    public DataTable GetSerialNumber(EmployeeGeneralExpensesFormUI employeeGeneralExpensesFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeGeneralExpenses_SerialNumber", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@RecordType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@RecordType"].Value = employeeGeneralExpensesFormUI.InvoiceType;

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
                audit_IUD.WebServiceSelectInsert("tbl_Asset", employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSerialNumber()";
            logExcpUIobj.ResourceName = "EmployeeGeneralExpensesFormDAL.CS";
            logExcpUIobj.RecordId = employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeGeneralExpensesFormDAL : GetSerialNumber] An error occured in the processing of Record Id : " + employeeGeneralExpensesFormUI.Tbl_EmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

}