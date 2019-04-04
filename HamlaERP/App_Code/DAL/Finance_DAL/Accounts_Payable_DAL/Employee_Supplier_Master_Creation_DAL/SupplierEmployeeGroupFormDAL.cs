using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for SupplierEmployeeGroupFormDAL
/// </summary>
public class SupplierEmployeeGroupFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public SupplierEmployeeGroupFormDAL()
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
            logExcpUIobj.MethodName = "SupplierEmployeeGroupFormDAL()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGroupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[SupplierEmployeeGroupFormDAL : SupplierEmployeeGroupFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetSupplierEmployeeGroupListById(SupplierEmployeeGroupFormUI supplierEmployeeGroupFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGroup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGroupId"].Value = supplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId;

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
            logExcpUIobj.MethodName = "getSupplierEmployeeGroupListById()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGroupFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeGroupFormDAL : getSupplierEmployeeGroupListById] An error occured in the processing of Record Id : " + supplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddSupplierEmployeeGroup(SupplierEmployeeGroupFormUI supplierEmployeeGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGroup_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = supplierEmployeeGroupFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierEmployeeGroupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGroupId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGroupId_Self"].Value = supplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId_Self;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = supplierEmployeeGroupFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = supplierEmployeeGroupFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = supplierEmployeeGroupFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = supplierEmployeeGroupFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Opt_MinimumPayment", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MinimumPayment"].Value = supplierEmployeeGroupFormUI.Opt_MinimumPayment;

                sqlCmd.Parameters.Add("@Opt_MaximumInvoiceAmount", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MaximumInvoiceAmount"].Value = supplierEmployeeGroupFormUI.Opt_MaximumInvoiceAmount;

                sqlCmd.Parameters.Add("@Opt_CreditLimit", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_CreditLimit"].Value = supplierEmployeeGroupFormUI.Opt_CreditLimit;

                sqlCmd.Parameters.Add("@Opt_Writeoff", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Writeoff"].Value = supplierEmployeeGroupFormUI.Opt_Writeoff;

                sqlCmd.Parameters.Add("@CalendarYear", SqlDbType.Bit);
                sqlCmd.Parameters["@CalendarYear"].Value = supplierEmployeeGroupFormUI.CalendarYear;

                sqlCmd.Parameters.Add("@FiscalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@FiscalYear"].Value = supplierEmployeeGroupFormUI.FiscalYear;

                sqlCmd.Parameters.Add("@Transaction", SqlDbType.Bit);
                sqlCmd.Parameters["@Transaction"].Value = supplierEmployeeGroupFormUI.Transaction;

                sqlCmd.Parameters.Add("@Distribution", SqlDbType.Bit);
                sqlCmd.Parameters["@Distribution"].Value = supplierEmployeeGroupFormUI.Distribution;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddSupplierEmployeeGroup()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGroupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeGroupFormDAL : AddSupplierEmployeeGroup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateSupplierEmployeeGroup(SupplierEmployeeGroupFormUI supplierEmployeeGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGroup_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = supplierEmployeeGroupFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierEmployeeGroupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGroupId"].Value = supplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGroupId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGroupId_Self"].Value = supplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId_Self;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = supplierEmployeeGroupFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = supplierEmployeeGroupFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = supplierEmployeeGroupFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = supplierEmployeeGroupFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Opt_MinimumPayment", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MinimumPayment"].Value = supplierEmployeeGroupFormUI.Opt_MinimumPayment;

                sqlCmd.Parameters.Add("@Opt_MaximumInvoiceAmount", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MaximumInvoiceAmount"].Value = supplierEmployeeGroupFormUI.Opt_MaximumInvoiceAmount;

                sqlCmd.Parameters.Add("@Opt_CreditLimit", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_CreditLimit"].Value = supplierEmployeeGroupFormUI.Opt_CreditLimit;

                sqlCmd.Parameters.Add("@Opt_Writeoff", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Writeoff"].Value = supplierEmployeeGroupFormUI.Opt_Writeoff;

                sqlCmd.Parameters.Add("@CalendarYear", SqlDbType.Bit);
                sqlCmd.Parameters["@CalendarYear"].Value = supplierEmployeeGroupFormUI.CalendarYear;

                sqlCmd.Parameters.Add("@FiscalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@FiscalYear"].Value = supplierEmployeeGroupFormUI.FiscalYear;

                sqlCmd.Parameters.Add("@Transaction", SqlDbType.Bit);
                sqlCmd.Parameters["@Transaction"].Value = supplierEmployeeGroupFormUI.Transaction;

                sqlCmd.Parameters.Add("@Distribution", SqlDbType.Bit);
                sqlCmd.Parameters["@Distribution"].Value = supplierEmployeeGroupFormUI.Distribution;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateSupplierEmployeeGroup()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGroupFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeGroupFormDAL : UpdateSupplierEmployeeGroup] An error occured in the processing of Record Id : " + supplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteSupplierEmployeeGroup(SupplierEmployeeGroupFormUI supplierEmployeeGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGroup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGroupId"].Value = supplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSupplierEmployeeGroup()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGroupFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeGroupFormDAL : DeleteSupplierEmployeeGroup] An error occured in the processing of Record Id : " + supplierEmployeeGroupFormUI.Tbl_SupplierEmployeeGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}