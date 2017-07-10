using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for SupplierGroupFormDAL
/// </summary>
public class SupplierGroupFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public SupplierGroupFormDAL()
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
            logExcpUIobj.MethodName = "SupplierGroupFormDAL()";
            logExcpUIobj.ResourceName = "SupplierGroupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[SupplierGroupFormDAL : SupplierGroupFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetSupplierGroupListById(SupplierGroupFormUI supplierGroupFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierGroup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierGroupId"].Value = supplierGroupFormUI.Tbl_SupplierGroupId;

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
            logExcpUIobj.MethodName = "getSupplierGroupListById()";
            logExcpUIobj.ResourceName = "SupplierGroupFormDAL.CS";
            logExcpUIobj.RecordId = supplierGroupFormUI.Tbl_SupplierGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierGroupFormDAL : getSupplierGroupListById] An error occured in the processing of Record Id : " + supplierGroupFormUI.Tbl_SupplierGroupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddSupplierGroup(SupplierGroupFormUI supplierGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierGroup_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = supplierGroupFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierGroupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_SupplierGroupId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierGroupId_Self"].Value = supplierGroupFormUI.Tbl_SupplierGroupId_Self;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = supplierGroupFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = supplierGroupFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = supplierGroupFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = supplierGroupFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Opt_MinimumPayment", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MinimumPayment"].Value = supplierGroupFormUI.Opt_MinimumPayment;

                sqlCmd.Parameters.Add("@Opt_MaximumInvoiceAmount", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MaximumInvoiceAmount"].Value = supplierGroupFormUI.Opt_MaximumInvoiceAmount;

                sqlCmd.Parameters.Add("@Opt_CreditLimit", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_CreditLimit"].Value = supplierGroupFormUI.Opt_CreditLimit;

                sqlCmd.Parameters.Add("@Opt_Writeoff", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Writeoff"].Value = supplierGroupFormUI.Opt_Writeoff;

                sqlCmd.Parameters.Add("@CalendarYear", SqlDbType.Bit);
                sqlCmd.Parameters["@CalendarYear"].Value = supplierGroupFormUI.CalendarYear;

                sqlCmd.Parameters.Add("@FiscalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@FiscalYear"].Value = supplierGroupFormUI.FiscalYear;

                sqlCmd.Parameters.Add("@Transaction", SqlDbType.Bit);
                sqlCmd.Parameters["@Transaction"].Value = supplierGroupFormUI.Transaction;

                sqlCmd.Parameters.Add("@Distribution", SqlDbType.Bit);
                sqlCmd.Parameters["@Distribution"].Value = supplierGroupFormUI.Distribution;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddSupplierGroup()";
            logExcpUIobj.ResourceName = "SupplierGroupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierGroupFormDAL : AddSupplierGroup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateSupplierGroup(SupplierGroupFormUI supplierGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierGroup_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = supplierGroupFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierGroupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_SupplierGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierGroupId"].Value = supplierGroupFormUI.Tbl_SupplierGroupId;

                sqlCmd.Parameters.Add("@tbl_SupplierGroupId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierGroupId_Self"].Value = supplierGroupFormUI.Tbl_SupplierGroupId_Self;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = supplierGroupFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = supplierGroupFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = supplierGroupFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = supplierGroupFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Opt_MinimumPayment", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MinimumPayment"].Value = supplierGroupFormUI.Opt_MinimumPayment;

                sqlCmd.Parameters.Add("@Opt_MaximumInvoiceAmount", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MaximumInvoiceAmount"].Value = supplierGroupFormUI.Opt_MaximumInvoiceAmount;

                sqlCmd.Parameters.Add("@Opt_CreditLimit", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_CreditLimit"].Value = supplierGroupFormUI.Opt_CreditLimit;

                sqlCmd.Parameters.Add("@Opt_Writeoff", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Writeoff"].Value = supplierGroupFormUI.Opt_Writeoff;

                sqlCmd.Parameters.Add("@CalendarYear", SqlDbType.Bit);
                sqlCmd.Parameters["@CalendarYear"].Value = supplierGroupFormUI.CalendarYear;

                sqlCmd.Parameters.Add("@FiscalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@FiscalYear"].Value = supplierGroupFormUI.FiscalYear;

                sqlCmd.Parameters.Add("@Transaction", SqlDbType.Bit);
                sqlCmd.Parameters["@Transaction"].Value = supplierGroupFormUI.Transaction;

                sqlCmd.Parameters.Add("@Distribution", SqlDbType.Bit);
                sqlCmd.Parameters["@Distribution"].Value = supplierGroupFormUI.Distribution;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateSupplierGroup()";
            logExcpUIobj.ResourceName = "SupplierGroupFormDAL.CS";
            logExcpUIobj.RecordId = supplierGroupFormUI.Tbl_SupplierGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierGroupFormDAL : UpdateSupplierGroup] An error occured in the processing of Record Id : " + supplierGroupFormUI.Tbl_SupplierGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteSupplierGroup(SupplierGroupFormUI supplierGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierGroup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierGroupId"].Value = supplierGroupFormUI.Tbl_SupplierGroupId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSupplierGroup()";
            logExcpUIobj.ResourceName = "SupplierGroupFormDAL.CS";
            logExcpUIobj.RecordId = supplierGroupFormUI.Tbl_SupplierGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierGroupFormDAL : DeleteSupplierGroup] An error occured in the processing of Record Id : " + supplierGroupFormUI.Tbl_SupplierGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}