using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for SourceDocumentFormDAL
/// </summary>
public class SourceDocumentFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public SourceDocumentFormDAL()
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
            logExcpUIobj.MethodName = "SourceDocumentFormDAL()";
            logExcpUIobj.ResourceName = "SourceDocumentFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[SourceDocumentFormDAL : SourceDocumentFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetSourceDocumentListById(SourceDocumentFormUI sourceDocumentFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[SP_SourceDocument_SelectById]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = sourceDocumentFormUI.Tbl_SourceDocumentId;

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
            logExcpUIobj.MethodName = "getSourceDocumentListById()";
            logExcpUIobj.ResourceName = "SourceDocumentFormDAL.CS";
            logExcpUIobj.RecordId = sourceDocumentFormUI.Tbl_SourceDocumentId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SourceDocumentFormDAL : getSourceDocumentListById] An error occured in the processing of Record Id : " + sourceDocumentFormUI.Tbl_SourceDocumentId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddSourceDocument(SourceDocumentFormUI sourceDocumentFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SourceDocument_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = sourceDocumentFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = sourceDocumentFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = sourceDocumentFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = sourceDocumentFormUI.Description;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddSourceDocument()";
            logExcpUIobj.ResourceName = "SourceDocumentFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SourceDocumentFormDAL : AddSourceDocument] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateSourceDocument(SourceDocumentFormUI sourceDocumentFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SourceDocument_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = sourceDocumentFormUI.ModifiedBy;
                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = sourceDocumentFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = sourceDocumentFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = sourceDocumentFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = sourceDocumentFormUI.Description;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateSourceDocument()";
            logExcpUIobj.ResourceName = "SourceDocumentFormDAL.CS";
            logExcpUIobj.RecordId = sourceDocumentFormUI.Tbl_SourceDocumentId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SourceDocumentFormDAL : UpdateSourceDocument] An error occured in the processing of Record Id : " + sourceDocumentFormUI.Tbl_SourceDocumentId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteSourceDocument(SourceDocumentFormUI sourceDocumentFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SourceDocument_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = sourceDocumentFormUI.Tbl_SourceDocumentId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSourceDocument()";
            logExcpUIobj.ResourceName = "SourceDocumentFormDAL.CS";
            logExcpUIobj.RecordId = sourceDocumentFormUI.Tbl_SourceDocumentId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SourceDocumentFormDAL : DeleteSourceDocument] An error occured in the processing of Record Id : " + sourceDocumentFormUI.Tbl_SourceDocumentId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}