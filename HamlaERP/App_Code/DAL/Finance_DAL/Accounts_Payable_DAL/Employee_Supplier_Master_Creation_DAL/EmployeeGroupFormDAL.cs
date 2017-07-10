using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for EmployeeGroupFormDAL
/// </summary>
public class EmployeeGroupFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public EmployeeGroupFormDAL()
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
            logExcpUIobj.MethodName = "EmployeeGroupFormDAL()";
            logExcpUIobj.ResourceName = "EmployeeGroupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[EmployeeGroupFormDAL : EmployeeGroupFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetEmployeeGroupListById(EmployeeGroupFormUI employeeGroupFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeGroup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeGroupId"].Value = employeeGroupFormUI.Tbl_EmployeeGroupId;

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
            logExcpUIobj.MethodName = "getEmployeeGroupListById()";
            logExcpUIobj.ResourceName = "EmployeeGroupFormDAL.CS";
            logExcpUIobj.RecordId = employeeGroupFormUI.Tbl_EmployeeGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeGroupFormDAL : getEmployeeGroupListById] An error occured in the processing of Record Id : " + employeeGroupFormUI.Tbl_EmployeeGroupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddEmployeeGroup(EmployeeGroupFormUI employeeGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeGroup_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = employeeGroupFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeGroupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_EmployeeGroupId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeGroupId_Self"].Value = employeeGroupFormUI.Tbl_EmployeeGroupId_Self;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = employeeGroupFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = employeeGroupFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = employeeGroupFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = employeeGroupFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Opt_MinimumPayment", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MinimumPayment"].Value = employeeGroupFormUI.Opt_MinimumPayment;

                sqlCmd.Parameters.Add("@Opt_MaximumInvoiceAmount", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MaximumInvoiceAmount"].Value = employeeGroupFormUI.Opt_MaximumInvoiceAmount;

                sqlCmd.Parameters.Add("@Opt_CreditLimit", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_CreditLimit"].Value = employeeGroupFormUI.Opt_CreditLimit;

                sqlCmd.Parameters.Add("@Opt_Writeoff", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Writeoff"].Value = employeeGroupFormUI.Opt_Writeoff;

                sqlCmd.Parameters.Add("@CalendarYear", SqlDbType.Bit);
                sqlCmd.Parameters["@CalendarYear"].Value = employeeGroupFormUI.CalendarYear;

                sqlCmd.Parameters.Add("@FiscalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@FiscalYear"].Value = employeeGroupFormUI.FiscalYear;

                sqlCmd.Parameters.Add("@Transaction", SqlDbType.Bit);
                sqlCmd.Parameters["@Transaction"].Value = employeeGroupFormUI.Transaction;

                sqlCmd.Parameters.Add("@Distribution", SqlDbType.Bit);
                sqlCmd.Parameters["@Distribution"].Value = employeeGroupFormUI.Distribution;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddEmployeeGroup()";
            logExcpUIobj.ResourceName = "EmployeeGroupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeGroupFormDAL : AddEmployeeGroup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateEmployeeGroup(EmployeeGroupFormUI employeeGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeGroup_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = employeeGroupFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeGroupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_EmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeGroupId"].Value = employeeGroupFormUI.Tbl_EmployeeGroupId;

                sqlCmd.Parameters.Add("@tbl_EmployeeGroupId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeGroupId_Self"].Value = employeeGroupFormUI.Tbl_EmployeeGroupId_Self;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = employeeGroupFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = employeeGroupFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = employeeGroupFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = employeeGroupFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Opt_MinimumPayment", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MinimumPayment"].Value = employeeGroupFormUI.Opt_MinimumPayment;

                sqlCmd.Parameters.Add("@Opt_MaximumInvoiceAmount", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MaximumInvoiceAmount"].Value = employeeGroupFormUI.Opt_MaximumInvoiceAmount;

                sqlCmd.Parameters.Add("@Opt_CreditLimit", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_CreditLimit"].Value = employeeGroupFormUI.Opt_CreditLimit;

                sqlCmd.Parameters.Add("@Opt_Writeoff", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Writeoff"].Value = employeeGroupFormUI.Opt_Writeoff;

                sqlCmd.Parameters.Add("@CalendarYear", SqlDbType.Bit);
                sqlCmd.Parameters["@CalendarYear"].Value = employeeGroupFormUI.CalendarYear;

                sqlCmd.Parameters.Add("@FiscalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@FiscalYear"].Value = employeeGroupFormUI.FiscalYear;

                sqlCmd.Parameters.Add("@Transaction", SqlDbType.Bit);
                sqlCmd.Parameters["@Transaction"].Value = employeeGroupFormUI.Transaction;

                sqlCmd.Parameters.Add("@Distribution", SqlDbType.Bit);
                sqlCmd.Parameters["@Distribution"].Value = employeeGroupFormUI.Distribution;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateEmployeeGroup()";
            logExcpUIobj.ResourceName = "EmployeeGroupFormDAL.CS";
            logExcpUIobj.RecordId = employeeGroupFormUI.Tbl_EmployeeGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeGroupFormDAL : UpdateEmployeeGroup] An error occured in the processing of Record Id : " + employeeGroupFormUI.Tbl_EmployeeGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteEmployeeGroup(EmployeeGroupFormUI employeeGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeGroup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeGroupId"].Value = employeeGroupFormUI.Tbl_EmployeeGroupId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteEmployeeGroup()";
            logExcpUIobj.ResourceName = "EmployeeGroupFormDAL.CS";
            logExcpUIobj.RecordId = employeeGroupFormUI.Tbl_EmployeeGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeGroupFormDAL : DeleteEmployeeGroup] An error occured in the processing of Record Id : " + employeeGroupFormUI.Tbl_EmployeeGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}