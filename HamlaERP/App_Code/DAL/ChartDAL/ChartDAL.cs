using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ChartDAL
/// </summary>
public class ChartDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public ChartDAL()
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
            logExcpUIobj.MethodName = "ChartDAL()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[ChartDAL : ChartDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }

    }

    #region Chart DownPaymentFromCustomer
    public DataTable GetDownPaymentFromCustomer_Posting_Status()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomer_Chart_PostingStatus", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

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
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomer_Posting_Status()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetDownPaymentFromCustomer_Posting_Status] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }
    public DataSet GetDownPaymentFromCustomer_Posting_On_Status()
    {
        DataSet ds = new DataSet();
        //DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[SP_DownPaymentFromCustomer_Chart_Posting_On_Status]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomer_Posting_Status()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetDownPaymentFromCustomer_Posting_Status] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return ds;
    }

    public DataSet GetDownPaymentFromCustomer_Chart_Periodically(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomer_Chart_Periodically", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetDownPaymentFromCustomer_Chart_Periodically()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetDownPaymentFromCustomer_Chart_Periodically] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }

    #endregion

    #region Chart tDownPaymentToSupplier
    public DataTable GetDownPaymentToSupplier_Chart_Posting_On_Status(ChartUI chartUI)

    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplier_Chart_PostingOnStatus", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

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
            logExcpUIobj.MethodName = "GetDownPaymentToSupplier_Chart_Posting_On_Status()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetDownPaymentToSupplier_Chart_Posting_On_Status] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }
    public DataSet GetDownPaymentToSupplier_Chart_BasedOnPayment_Mode()
    {
        DataSet ds = new DataSet();
        // DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[SP_DownPaymentToSupplier_Chart_BasedOnPaymentMode]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetDownPaymentToSupplier_BasedOnPayment_Mode()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetDownPaymentToSupplier_BasedOnPayment_Mode] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return ds;
    }

    public DataSet GetDownPaymentToSupplier_Chart_Periodically(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection supportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplier_Chart_Periodically", supportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = "GetDownPaymentToSupplier_BasedOnPayment_Mode()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetDownPaymentToSupplier_BasedOnPayment_Mode] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();

        }
        return ds;
    }

    #endregion

    #region PaymentFromCustomer
    public DataTable GetPaymentFromCustomer_Posting_On_Status(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[SP_PaymentFromCustomer_Chart_PostingOnStatus]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

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
            logExcpUIobj.MethodName = "GetPaymentFromCustomer_Posting_On_Status()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetPaymentFromCustomer_Posting_On_Status] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }

    public DataSet GetPaymentFromCustomer_BasedOnPayment_Mode(ChartUI chartUI)
    {

        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomer_Chart_BasedOnCollectionMode", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPaymentFromCustomer_BasedOnPayment_Mode()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetPaymentFromCustomer_BasedOnPayment_Mode] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");

        }
        finally
        {
            ds.Dispose();
        }
        return ds;
    }

    public DataSet GetPaymentFromCustomer_Chart_Periodically(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection supportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomer_Chart_Periodically", supportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = "GetPaymentFromCustomer_Chart_Periodically()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GeTPaymentFromCustomer_Chart_Periodically] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();

        }
        return ds;
    }
    #endregion

    #region Payment To SupplierEmployee

    public DataSet GetPaymentToSupplierEmployee_Periodically(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployee_Chart_Periodically", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetPaymentToSupplierEmployee_Periodically()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetPaymentToSupplierEmployee_Periodically] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }

    public DataSet GetPaymentToSupplierEmployee_BasedOnPayment_Mode(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployee_Chart_BasedOnPaymentMode", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetPaymentToSupplierEmployee_BasedOnPayment_Mode()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetPaymentToSupplierEmployee_BasedOnPayment_Mode] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }

    public DataTable GetPaymentToSupplierEmployee_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[SP_paymentToSupplierEmployee_Chart_PostingOnStatus]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;
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
            logExcpUIobj.MethodName = "GetPaymentToSupplierEmployee_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetPaymentToSupplierEmployee_Chart_PostingOnStatus] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }
    #endregion

    #region Customer Invoice Process
    public DataSet GetCustomerInvoiceProcess_Chart_Periodically(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoiceProcess_Chart_Periodically", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetCustomerInvoiceProcess_Chart_Periodically()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetCustomerInvoiceProcess_Chart_Periodically] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }

    public DataSet GetCustomerInvoiceProcess_Chart_BasedOnPaymentMode(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoiceProcess_Chart_BasedOnPaymentMode", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetPaymentToSupplierEmployee_BasedOnPayment_Mode()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetCustomerInvoiceProcess_Chart_BasedOnPaymentMode] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }

    public DataTable GetCustomerInvoiceProcess_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[SP_CustomerInvoiceProcess_Chart_PostingOnStatus]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;
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
            logExcpUIobj.MethodName = "GetCustomerInvoiceProcess_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetCustomerInvoiceProcess_Chart_PostingOnStatus] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }
    #endregion

    #region SupplierEmployeeGeneralExpenses
    public DataSet GetSupplierEmployeeGeneralExpenses_Chart_Periodically(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGeneralExpenses_Chart_Periodically", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetSupplierEmployeeGeneralExpenses_Chart_Periodically()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetSupplierEmployeeGeneralExpenses_Chart_Periodically] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }
    public DataSet GetSupplierEmployeeGeneralExpenses_Chart_BasedOnPaymentMode(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGeneralExpenses_Chart_BasedOnPaymentMode", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetSupplierEmployeeGeneralExpenses_Chart_BasedOnPaymentMode()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetSupplierEmployeeGeneralExpenses_Chart_BasedOnPaymentMode] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }
    public DataTable GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[SP_SupplierEmployeeGeneralExpenses_Chart_PostingOnStatus]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;
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
            logExcpUIobj.MethodName = "GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetSupplierEmployeeGeneralExpenses_Chart_PostingOnStatus] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }
    #endregion

    #region NonPOBasedInvoice
    public DataSet GetNonPOBasedInvoice_Chart_Periodically(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoice_Chart_Periodically", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetNonPOBasedInvoice_Chart_Periodically()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetNonPOBasedInvoice_Chart_Periodically] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }
    public DataSet GetNonPOBasedInvoice_Chart_BasedOnPaymentMode(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoice_Chart_BasedOnPaymentMode", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetNonPOBasedInvoice_Chart_BasedOnPaymentMode()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetNonPOBasedInvoice_Chart_BasedOnPaymentMode] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }
    public DataTable GetNonPOBasedInvoice_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[SP_NonPOBasedInvoice_Chart_PostingOnStatus]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;
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
            logExcpUIobj.MethodName = "GetNonPOBasedInvoice_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetNonPOBasedInvoice_Chart_PostingOnStatus] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }
    #endregion

    #region Payment To Supplier
    public DataSet GetPaymentToSupplier_Chart_Periodically(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplier_Chart_Periodically", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetPaymentToSupplier_Chart_Periodically()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetPaymentToSupplier_Chart_Periodically] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }
    public DataSet GetPaymentToSupplier_Chart_BasedOnPaymentMode(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplier_Chart_BasedOnPaymentMode", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetPaymentToSupplier_Chart_BasedOnPaymentMode()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetPaymentToSupplier_Chart_BasedOnPaymentMode] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }
    public DataTable GetPaymentToSupplier_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[SP_PaymentToSupplier_Chart_PostingOnStatus]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;
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
            logExcpUIobj.MethodName = "GetNonPOBasedInvoice_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetNonPOBasedInvoice_Chart_PostingOnStatus] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }
    #endregion

    #region EmployeeGeneralExpenses
    public DataSet GetEmployeeGeneralExpenses_Chart_Periodically(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeGeneralExpenses_Chart_Periodically", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetEmployeeGeneralExpenses_Chart_Periodically()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetEmployeeGeneralExpenses_Chart_Periodically] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }
    public DataSet GetEmployeeGeneralExpenses_Chart_BasedOnPaymentMode(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeGeneralExpenses_Chart_BasedOnPaymentMode", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetEmployeeGeneralExpenses_Chart_BasedOnPaymentMode()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetEmployeeGeneralExpenses_Chart_BasedOnPaymentMode] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }
    public DataTable GetEmployeeGeneralExpenses_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[SP_EmployeeGeneralExpenses_Chart_PostingOnStatus]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;
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
            logExcpUIobj.MethodName = "GetNonPOBasedInvoice_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetNonPOBasedInvoice_Chart_PostingOnStatus] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }
    #endregion

    #region paymentToEmployee
    public DataSet GetPaymentToEmployee_Chart_Periodically(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployee_Chart_periodically", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetPaymentToEmployee_Chart_Periodically()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetPaymentToEmployee_Chart_Periodically] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }
    public DataSet GetPaymentToEmployee_Chart_BasedOnPaymentMode(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployee_Chart_BasedOnCollection_Mode", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
        }
        catch (Exception exp)
        {

            logExcpUIobj.MethodName = " GetPaymentToEmployee_Chart_BasedOnPaymentMode()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL :  GetPaymentToEmployee_Chart_BasedOnPaymentMode] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return ds;

    }
    public DataTable GetPaymentToEmployee_Chart_PostingOnStatus(ChartUI chartUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[SP_PaymentToEmployee_Chart_PostingOnStatus]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chartUI.Tbl_OrganizationId;
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
            logExcpUIobj.MethodName = "GetPaymentToEmployee_Chart_PostingOnStatus()";
            logExcpUIobj.ResourceName = "ChartDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChartDAL : GetPaymentToEmployee_Chart_PostingOnStatus] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }

    #endregion

}