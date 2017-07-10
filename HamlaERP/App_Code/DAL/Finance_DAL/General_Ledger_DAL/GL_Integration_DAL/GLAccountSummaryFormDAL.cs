using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for GLAccountSummaryFormDAL
/// </summary>
public class GLAccountSummaryFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public GLAccountSummaryFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountSummaryFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountSummaryFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountSummaryFormDAL : GLAccountSummaryFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetGLAccountSummaryListById(GLAccountSummaryFormUI gLAccountSummaryFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSummary_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountSummaryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSummaryId"].Value = gLAccountSummaryFormUI.Tbl_GLAccountSummaryId;

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
            logExcpUIobj.MethodName = "getGLAccountSummaryListById()";
            logExcpUIobj.ResourceName = "GLAccountSummaryFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountSummaryFormUI.Tbl_GLAccountSummaryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSummaryFormDAL : getGLAccountSummaryListById] An error occured in the processing of Record Id : " + gLAccountSummaryFormUI.Tbl_GLAccountSummaryId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGLAccountSummary(GLAccountSummaryFormUI gLAccountSummaryFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSummary_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountSummaryFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountSummaryFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = gLAccountSummaryFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = gLAccountSummaryFormUI.Tbl_FiscalPeriodId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddGLAccountSummary()";
            logExcpUIobj.ResourceName = "GLAccountSummaryFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSummaryFormDAL : AddGLAccountSummary] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccountSummary(GLAccountSummaryFormUI gLAccountSummaryFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSummary_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountSummaryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSummaryId"].Value = gLAccountSummaryFormUI.Tbl_GLAccountSummaryId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountSummaryFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountSummaryFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = gLAccountSummaryFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = gLAccountSummaryFormUI.Tbl_FiscalPeriodId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountSummary()";
            logExcpUIobj.ResourceName = "GLAccountSummaryFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountSummaryFormUI.Tbl_GLAccountSummaryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSummaryFormDAL : UpdateGLAccountSummary] An error occured in the processing of Record Id : " + gLAccountSummaryFormUI.Tbl_GLAccountSummaryId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGLAccountSummary(GLAccountSummaryFormUI gLAccountSummaryFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSummary_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountSummaryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSummaryId"].Value = gLAccountSummaryFormUI.Tbl_GLAccountSummaryId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountSummary()";
            logExcpUIobj.ResourceName = "GLAccountSummaryFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountSummaryFormUI.Tbl_GLAccountSummaryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSummaryFormDAL : DeleteGLAccountSummary] An error occured in the processing of Record Id : " + gLAccountSummaryFormUI.Tbl_GLAccountSummaryId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}