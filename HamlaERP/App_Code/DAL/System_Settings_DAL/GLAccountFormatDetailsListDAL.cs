using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for GLAccountFormatDetailsListDAL
/// </summary>
public class GLAccountFormatDetailsListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public GLAccountFormatDetailsListDAL()
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
            logExcpUIobj.MethodName = "GLAccountFormatDetailsListDAL()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetailsListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountFormatDetailsListDAL : GLAccountFormatDetailsListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetGLAccountFormatDetailsList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormatDetails_Select", SupportCon);
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
            logExcpUIobj.MethodName = "getGLAccountFormatDetailsList()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetailsListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatDetailsListDAL : getGLAccountFormatDetailsList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetGLAccountFormatDetailsListById(GLAccountFormatDetailsListUI gLAccountFormatDetailsListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormatDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountFormatDetialsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountFormatDetialsId"].Value = gLAccountFormatDetailsListUI.Tbl_GLAccountFormatDetialsId;

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
            logExcpUIobj.MethodName = "getGLAccountFormatDetailsListById()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetailsListDAL.CS";
            logExcpUIobj.RecordId = gLAccountFormatDetailsListUI.Tbl_GLAccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatDetailsListDAL : getGLAccountFormatDetailsListById] An error occured in the processing of Record Id : " + gLAccountFormatDetailsListUI.Tbl_GLAccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetGLAccountFormatDetailsListByGLAccountFormatId(GLAccountFormatDetailsListUI gLAccountFormatDetailsListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormatDetails_SelectByGLAccountFormatId", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountFormatId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountFormatId"].Value = gLAccountFormatDetailsListUI.Tbl_GLAccountFormatId;

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
            logExcpUIobj.MethodName = "GetGLAccountFormatDetailsListByGLAccountFormatId()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetailsListDAL.CS";
            logExcpUIobj.RecordId = gLAccountFormatDetailsListUI.Tbl_GLAccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatDetailsListDAL : GetGLAccountFormatDetailsListByGLAccountFormatId] An error occured in the processing of Record Id : " + gLAccountFormatDetailsListUI.Tbl_GLAccountFormatId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }


    public DataTable GetGLAccountFormatDetailsListBySearchParameters(GLAccountFormatDetailsListUI gLAccountFormatDetailsListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormatDetails_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = gLAccountFormatDetailsListUI.Search;

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
            logExcpUIobj.MethodName = "GetGLAccountFormatDetailsListBySearchParameters()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetailsListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + gLAccountFormatDetailsListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatDetailsListDAL : GetGLAccountFormatDetailsListBySearchParameters] An error occured in the processing of Record Search = " + gLAccountFormatDetailsListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int DeleteGLAccountFormatDetails(GLAccountFormatDetailsListUI gLAccountFormatDetailsListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormatDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountFormatDetialsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountFormatDetialsId"].Value = gLAccountFormatDetailsListUI.Tbl_GLAccountFormatDetialsId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountFormatDetails()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetailsListDAL.CS";
            logExcpUIobj.RecordId = gLAccountFormatDetailsListUI.Tbl_GLAccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatDetailsListDAL : DeleteGLAccountFormatDetails] An error occured in the processing of Record Id : " + gLAccountFormatDetailsListUI.Tbl_GLAccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetGLAccountFormatDetailsListExportToExcel()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormatDetails_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetGLAccountFormatDetailsListExportToExcel()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetailsListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatDetailsListDAL : GetGLAccountFormatDetailsListExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    
}