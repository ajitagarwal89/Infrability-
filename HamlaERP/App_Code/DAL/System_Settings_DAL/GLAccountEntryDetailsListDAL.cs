using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for GLAccountEntryDetailsListDAL
/// </summary>
public class GLAccountEntryDetailsListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public GLAccountEntryDetailsListDAL()
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
            logExcpUIobj.MethodName = "GLAccountEntryDetailsListDAL()";
            logExcpUIobj.ResourceName = "GLAccountEntryDetailsListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountEntryDetailsListDAL : GLAccountEntryDetailsListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetGLAccountEntryDetailsList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountEntryDetails_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetGLAccountEntryDetailsList()";
            logExcpUIobj.ResourceName = "GLAccountEntryDetailsListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountEntryDetailsListDAL : GetGLAccountEntryDetailsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetGLAccountEntryDetailsListForExportToExcel()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountEntryDetails_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetGLAccountEntryDetailsListForExportToExcel()";
            logExcpUIobj.ResourceName = "GLAccountEntryDetailsListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountEntryDetailsListDAL : GetGLAccountEntryDetailsListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetGLAccountEntryDetailsListById(GLAccountEntryDetailsListUI gLAccountEntryDetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountEntryDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountEntryDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountEntryDetailsId"].Value = gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId;

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
            logExcpUIobj.MethodName = "GetGLAccountEntryListDetailsById()";
            logExcpUIobj.ResourceName = "GLAccountEntryDetailsListDAL.CS";
            logExcpUIobj.RecordId = gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountEntryDetailsListDAL : GetGLAccountEntryListDetailsById] An error occured in the processing of Record Id : " + gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetGLAccountEntryDetailsListBySearchParameters(GLAccountEntryDetailsListUI gLAccountEntryDetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
    
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountEntryDetails_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = gLAccountEntryDetailsFormUI.Search;

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
            logExcpUIobj.MethodName = "GetGLAccountEntryDetailsListBySearchParameters()";
            logExcpUIobj.ResourceName = "GLAccountEntryDetailsListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + gLAccountEntryDetailsFormUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountEntryDetailsListDAL : GetGLAccountEntryDetailsListBySearchParameters] An error occured in the processing of Record Search = " + gLAccountEntryDetailsFormUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int DeleteGLAccountEntryDetails(GLAccountEntryDetailsListUI gLAccountEntryDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountEntryDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountEntryDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountEntryDetailsId"].Value = gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountEntry()";
            logExcpUIobj.ResourceName = "GLAccountEntryListDAL.CS";
            logExcpUIobj.RecordId = gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountEntryListDAL : DeleteGLAccountEntry] An error occured in the processing of Record Id : " + gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId+ ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}