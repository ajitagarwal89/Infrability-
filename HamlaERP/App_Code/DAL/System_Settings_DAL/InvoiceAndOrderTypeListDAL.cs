using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for InvoiceAndOrderTypeListDAL
/// </summary>
public class InvoiceAndOrderTypeListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public InvoiceAndOrderTypeListDAL()
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
            logExcpUIobj.MethodName = "InvoiceAndOrderTypeListDAL()";
            logExcpUIobj.ResourceName = "InvoiceAndOrderTypeListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[InvoiceAndOrderTypeListDAL : InvoiceAndOrderTypeListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}



    public DataTable GetInvoiceAndOrderTypeList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_InvoiceAndOrderType_Select", SupportCon);
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
            logExcpUIobj.MethodName = "getInvoiceAndOrderTypeList()";
            logExcpUIobj.ResourceName = "InvoiceAndOrderTypeListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[InvoiceAndOrderTypeListDAL : getInvoiceAndOrderTypeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetInvoiceAndOrderTypeListForExportToExcel()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_InvoiceAndOrderType_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetInvoiceAndOrderTypeListForExportToExcel()";
            logExcpUIobj.ResourceName = "InvoiceAndOrderTypeListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[InvoiceAndOrderTypeListDAL : GetInvoiceAndOrderTypeListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetInvoiceAndOrderTypeListById(InvoiceAndOrderTypeListUI invoiceAndOrderTypeListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_InvoiceAndOrderType_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_InvoiceAndOrderTypeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_InvoiceAndOrderTypeId"].Value = invoiceAndOrderTypeListUI.Tbl_InvoiceAndOrderTypeId;

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
            logExcpUIobj.MethodName = "getInvoiceAndOrderTypeListById()";
            logExcpUIobj.ResourceName = "InvoiceAndOrderTypeListDAL.CS";
            logExcpUIobj.RecordId = invoiceAndOrderTypeListUI.Tbl_InvoiceAndOrderTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[InvoiceAndOrderTypeListDAL : getInvoiceAndOrderTypeListById] An error occured in the processing of Record Id : " + invoiceAndOrderTypeListUI.Tbl_InvoiceAndOrderTypeId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetInvoiceAndOrderTypeListBySearchParameters(InvoiceAndOrderTypeListUI invoiceAndOrderTypeListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_InvoiceAndOrderType_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = invoiceAndOrderTypeListUI.Search;

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
            logExcpUIobj.MethodName = "GetInvoiceAndOrderTypeListBySearchParameters()";
            logExcpUIobj.ResourceName = "InvoiceAndOrderTypeListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + invoiceAndOrderTypeListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[InvoiceAndOrderTypeListDAL : GetInvoiceAndOrderTypeListBySearchParameters] An error occured in the processing of Record Search = " + invoiceAndOrderTypeListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int DeleteInvoiceAndOrderType(InvoiceAndOrderTypeListUI invoiceAndOrderTypeListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_InvoiceAndOrderType_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_InvoiceAndOrderTypeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_InvoiceAndOrderTypeId"].Value = invoiceAndOrderTypeListUI.Tbl_InvoiceAndOrderTypeId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteInvoiceAndOrderType()";
            logExcpUIobj.ResourceName = "InvoiceAndOrderTypeListDAL.CS";
            logExcpUIobj.RecordId = invoiceAndOrderTypeListUI.Tbl_InvoiceAndOrderTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[InvoiceAndOrderTypeListDAL : DeleteInvoiceAndOrderType] An error occured in the processing of Record Id : " + invoiceAndOrderTypeListUI.Tbl_InvoiceAndOrderTypeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}