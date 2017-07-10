using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for GLAccountCategoryFormDAL
/// </summary>
public class GLAccountCategoryFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public GLAccountCategoryFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountCategoryFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountCategoryFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountCategoryFormDAL : GLAccountCategoryFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetGLAccountCategoryListById(GLAccountCategoryFormUI gLAccountCategoryFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountCategory_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountCategoryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountCategoryId"].Value = gLAccountCategoryFormUI.Tbl_GLAccountCategoryId;

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
            logExcpUIobj.MethodName = "getGLAccountCategoryListById()";
            logExcpUIobj.ResourceName = "GLAccountCategoryFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountCategoryFormUI.Tbl_GLAccountCategoryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountCategoryFormDAL : getGLAccountCategoryListById] An error occured in the processing of Record Id : " + gLAccountCategoryFormUI.Tbl_GLAccountCategoryId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGLAccountCategory(GLAccountCategoryFormUI gLAccountCategoryFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountCategory_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountCategoryFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountCategoryFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@CategoryNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CategoryNumber"].Value = gLAccountCategoryFormUI.CategoryNumber;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = gLAccountCategoryFormUI.Description;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddGLAccountCategory()";
            logExcpUIobj.ResourceName = "GLAccountCategoryFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountCategoryFormDAL : AddGLAccountCategory] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccountCategory(GLAccountCategoryFormUI gLAccountCategoryFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountCategory_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountCategoryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountCategoryId"].Value = gLAccountCategoryFormUI.Tbl_GLAccountCategoryId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountCategoryFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountCategoryFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@CategoryNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CategoryNumber"].Value = gLAccountCategoryFormUI.CategoryNumber;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = gLAccountCategoryFormUI.Description;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountCategory()";
            logExcpUIobj.ResourceName = "GLAccountCategoryFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountCategoryFormUI.Tbl_GLAccountCategoryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountCategoryFormDAL : UpdateGLAccountCategory] An error occured in the processing of Record Id : " + gLAccountCategoryFormUI.Tbl_GLAccountCategoryId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGLAccountCategory(GLAccountCategoryFormUI gLAccountCategoryFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountCategory_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountCategoryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountCategoryId"].Value = gLAccountCategoryFormUI.Tbl_GLAccountCategoryId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountCategory()";
            logExcpUIobj.ResourceName = "GLAccountCategoryFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountCategoryFormUI.Tbl_GLAccountCategoryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountCategoryFormDAL : DeleteGLAccountCategory] An error occured in the processing of Record Id : " + gLAccountCategoryFormUI.Tbl_GLAccountCategoryId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}