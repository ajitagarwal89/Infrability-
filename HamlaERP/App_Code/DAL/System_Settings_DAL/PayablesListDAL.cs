using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for PayablesListDAL
/// </summary>
public class PayablesListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PayablesListDAL()
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
            logExcpUIobj.MethodName = "PayablesListDAL()";
            logExcpUIobj.ResourceName = "PayablesListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PayablesListDAL : PayablesListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetPayablesList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Payables_Select", SupportCon);
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
            logExcpUIobj.MethodName = "getPayablesList()";
            logExcpUIobj.ResourceName = "PayablesListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayablesListDAL : getPayablesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetPayablesListById(PayablesListUI payablesListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Payables_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PayablesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId"].Value = payablesListUI.Tbl_PayablesId;

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
            logExcpUIobj.MethodName = "getPayablesListById()";
            logExcpUIobj.ResourceName = "PayablesListDAL.CS";
            logExcpUIobj.RecordId = payablesListUI.Tbl_PayablesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayablesListDAL : getPayablesListById] An error occured in the processing of Record Id : " + payablesListUI.Tbl_PayablesId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetPayablesListBySearchParameters(PayablesListUI payablesListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Payables_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = payablesListUI.Search;

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
            logExcpUIobj.MethodName = "GetPayablesListBySearchParameters()";
            logExcpUIobj.ResourceName = "PayablesListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + payablesListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayablesListDAL : GetPayablesListBySearchParameters] An error occured in the processing of Record Search = " + payablesListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetPayablesListForExportToExcel()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Payables_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetPayablesListForExportToExcel()";
            logExcpUIobj.ResourceName = "PayablesListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayablesListDAL : GetPayablesListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int DeletePayables(PayablesListUI payablesListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Payables_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PayablesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId"].Value = payablesListUI.Tbl_PayablesId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePayables()";
            logExcpUIobj.ResourceName = "PayablesListDAL.CS";
            logExcpUIobj.RecordId = payablesListUI.Tbl_PayablesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayablesListDAL : DeletePayables] An error occured in the processing of Record Id : " + payablesListUI.Tbl_PayablesId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetPayablesListByPayablesAndProcessType(PayablesListUI payablesListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Payables_SelectByPayablesAndProcessType", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Opt_PayablesType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_PayablesType"].Value = payablesListUI.Opt_PayablesType;

                sqlCmd.Parameters.Add("@Opt_ProcessType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_ProcessType"].Value = payablesListUI.Opt_ProcessType;

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
            logExcpUIobj.MethodName = "GetPayablesListByPayablesAndProcessType()";
            logExcpUIobj.ResourceName = "PayablesListDAL.CS";
            logExcpUIobj.RecordId = "Payables And Process Type";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayablesListDAL : GetPayablesListByPayablesAndProcessType] An error occured in the processing of Record for Payables And Process Type . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
}