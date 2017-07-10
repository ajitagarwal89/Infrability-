using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for GLAccountBudgetDetailsFormDAL
/// </summary>
public class GLAccountBudgetDetailsFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public GLAccountBudgetDetailsFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountBudgetDetailsFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountBudgetDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountBudgetDetailsFormDAL : GLAccountBudgetDetailsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetGLAccountBudgetDetailsListById(GLAccountBudgetDetailsFormUI gLAccountBudgetDetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountBudgetDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountBudgetDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountBudgetDetailsId"].Value = gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId;

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
            logExcpUIobj.MethodName = "getGLAccountBudgetDetailsListById()";
            logExcpUIobj.ResourceName = "GLAccountBudgetDetailsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountBudgetDetailsFormDAL : getGLAccountBudgetDetailsListById] An error occured in the processing of Record Id : " + gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGLAccountBudgetDetails(GLAccountBudgetDetailsFormUI gLAccountBudgetDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountBudgetDetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountBudgetDetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountBudgetDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountBudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountBudgetId"].Value = gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetId;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = gLAccountBudgetDetailsFormUI.Tbl_FiscalPeriodId;

                sqlCmd.Parameters.Add("@Period", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Period"].Value = gLAccountBudgetDetailsFormUI.Period;

                sqlCmd.Parameters.Add("@PeriodName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PeriodName"].Value = gLAccountBudgetDetailsFormUI.PeriodName;

                sqlCmd.Parameters.Add("@PeriodDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PeriodDate"].Value = gLAccountBudgetDetailsFormUI.PeriodDate;

                sqlCmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                sqlCmd.Parameters["@Amount"].Value = gLAccountBudgetDetailsFormUI.Amount;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddGLAccountBudgetDetails()";
            logExcpUIobj.ResourceName = "GLAccountBudgetDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountBudgetDetailsFormDAL : AddGLAccountBudgetDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccountBudgetDetails(GLAccountBudgetDetailsFormUI gLAccountBudgetDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountBudgetDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountBudgetDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountBudgetDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountBudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountBudgetId"].Value = gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetId;


                sqlCmd.Parameters.Add("@tbl_GLAccountBudgetDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountBudgetDetailsId"].Value = gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = gLAccountBudgetDetailsFormUI.Tbl_FiscalPeriodId;

                sqlCmd.Parameters.Add("@Period", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Period"].Value = gLAccountBudgetDetailsFormUI.Period;

                sqlCmd.Parameters.Add("@PeriodName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PeriodName"].Value = gLAccountBudgetDetailsFormUI.PeriodName;

                sqlCmd.Parameters.Add("@PeriodDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PeriodDate"].Value = gLAccountBudgetDetailsFormUI.PeriodDate;
                

                sqlCmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                sqlCmd.Parameters["@Amount"].Value = gLAccountBudgetDetailsFormUI.Amount;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountBudgetDetails()";
            logExcpUIobj.ResourceName = "GLAccountBudgetDetailsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountBudgetDetailsFormDAL : UpdateGLAccountBudgetDetails] An error occured in the processing of Record Id : " + gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGLAccountBudgetDetails(GLAccountBudgetDetailsFormUI gLAccountBudgetDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountBudgetDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountBudgetDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountBudgetDetailsId"].Value = gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountBudgetDetails()";
            logExcpUIobj.ResourceName = "GLAccountBudgetDetailsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountBudgetDetailsFormDAL : DeleteGLAccountBudgetDetails] An error occured in the processing of Record Id : " + gLAccountBudgetDetailsFormUI.Tbl_GLAccountBudgetDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}