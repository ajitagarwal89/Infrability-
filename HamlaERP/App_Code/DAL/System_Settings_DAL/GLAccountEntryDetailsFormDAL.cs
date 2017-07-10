using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for GLAccountEntryDetailsFormDAL
/// </summary>
public class GLAccountEntryDetailsFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public GLAccountEntryDetailsFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountEntryDetailsFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountEntryDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountEntryDetailsFormDAL : GLAccountEntryDetailsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetGLAccountEntryDetailsListById(GLAccountEntryDetailsFormUI gLAccountEntryDetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
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
            logExcpUIobj.MethodName = "GetGLAccountEntryDetailsListById()";
            logExcpUIobj.ResourceName = "GLAccountEntryFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountEntryDetailsFormDAL : GetGLAccountEntryDetailsListById] An error occured in the processing of Record Id : " + gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGLAccountEntryDetails(GLAccountEntryDetailsFormUI gLAccountEntryDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountEntryDetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountEntryDetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountEntryDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountEntryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountEntryId"].Value = gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = gLAccountEntryDetailsFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = gLAccountEntryDetailsFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = gLAccountEntryDetailsFormUI.Credit;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddGLAccountEntryDetails()";
            logExcpUIobj.ResourceName = "GLAccountEntryFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountEntryDetailsFormDAL : AddGLAccountEntryDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccountEntryDetails(GLAccountEntryDetailsFormUI gLAccountEntryDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountEntryDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountEntryDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_GLAccountEntryDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountEntryDetailsId"].Value = gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountEntryDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountEntryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountEntryId"].Value = gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = gLAccountEntryDetailsFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = gLAccountEntryDetailsFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = gLAccountEntryDetailsFormUI.Credit;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountEntry()";
            logExcpUIobj.ResourceName = "GLAccountEntryDetailsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountEntryDetailsFormDAL : UpdateGLAccountEntryDetails] An error occured in the processing of Record Id : " + gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGLAccountEntryDetails(GLAccountEntryDetailsFormUI gLAccountEntryDetailsFormUI)
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
            logExcpUIobj.MethodName = "DeleteGLAccountEntryDetails()";
            logExcpUIobj.ResourceName = "GLAccountEntryFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountEntryFormDAL : DeleteGLAccountEntryDetails] An error occured in the processing of Record Id : " + gLAccountEntryDetailsFormUI.Tbl_GLAccountEntryDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}