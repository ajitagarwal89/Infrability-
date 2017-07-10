using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for GLAccountEntryFormDAL
/// </summary>
public class GLAccountEntryFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public GLAccountEntryFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountEntryFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountEntryFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountEntryFormDAL : GLAccountEntryFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetGLAccountEntryListById(GLAccountEntryFormUI gLAccountEntryFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountEntry_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountEntryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountEntryId"].Value = gLAccountEntryFormUI.Tbl_GLAccountEntryId;

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
            logExcpUIobj.MethodName = "getGLAccountEntryListById()";
            logExcpUIobj.ResourceName = "GLAccountEntryFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountEntryFormUI.Tbl_GLAccountEntryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountEntryFormDAL : getGLAccountEntryListById] An error occured in the processing of Record Id : " + gLAccountEntryFormUI.Tbl_GLAccountEntryId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGLAccountEntry(GLAccountEntryFormUI gLAccountEntryFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountEntry_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountEntryFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountEntryFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@JournalEntry", SqlDbType.NVarChar);
                sqlCmd.Parameters["@JournalEntry"].Value = gLAccountEntryFormUI.JournalEntry;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = gLAccountEntryFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@TransactionType", SqlDbType.Bit);
                sqlCmd.Parameters["@TransactionType"].Value = gLAccountEntryFormUI.TransactionType;

                sqlCmd.Parameters.Add("@TransactionDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@TransactionDate"].Value = gLAccountEntryFormUI.TransactionDate;

                //sqlCmd.Parameters.Add("@TransactionDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@TransactionDate_Hijri"].Value = gLAccountEntryFormUI.TransactionDate_Hijri;

                sqlCmd.Parameters.Add("@tbl_SourceDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocument"].Value = gLAccountEntryFormUI.Tbl_SourceDocument;

                sqlCmd.Parameters.Add("@Reference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Reference"].Value = gLAccountEntryFormUI.Reference;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = gLAccountEntryFormUI.Tbl_CurrencyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddGLAccountEntry()";
            logExcpUIobj.ResourceName = "GLAccountEntryFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountEntryFormDAL : AddGLAccountEntry] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccountEntry(GLAccountEntryFormUI gLAccountEntryFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountEntry_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountEntryFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_GLAccountEntryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountEntryId"].Value = gLAccountEntryFormUI.Tbl_GLAccountEntryId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountEntryFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@JournalEntry", SqlDbType.NVarChar);
                sqlCmd.Parameters["@JournalEntry"].Value = gLAccountEntryFormUI.JournalEntry;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = gLAccountEntryFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@TransactionType", SqlDbType.Bit);
                sqlCmd.Parameters["@TransactionType"].Value = gLAccountEntryFormUI.TransactionType;

                sqlCmd.Parameters.Add("@TransactionDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@TransactionDate"].Value = gLAccountEntryFormUI.TransactionDate;

                            sqlCmd.Parameters.Add("@tbl_SourceDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocument"].Value = gLAccountEntryFormUI.Tbl_SourceDocument;

                sqlCmd.Parameters.Add("@Reference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Reference"].Value = gLAccountEntryFormUI.Reference;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = gLAccountEntryFormUI.Tbl_CurrencyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountEntry()";
            logExcpUIobj.ResourceName = "GLAccountEntryFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountEntryFormUI.Tbl_GLAccountEntryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountEntryFormDAL : UpdateGLAccountEntry] An error occured in the processing of Record Id : " + gLAccountEntryFormUI.Tbl_GLAccountEntryId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGLAccountEntry(GLAccountEntryFormUI gLAccountEntryFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountEntry_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountEntryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountEntryId"].Value = gLAccountEntryFormUI.Tbl_GLAccountEntryId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountEntry()";
            logExcpUIobj.ResourceName = "GLAccountEntryFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountEntryFormUI.Tbl_GLAccountEntryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountEntryFormDAL : DeleteGLAccountEntry] An error occured in the processing of Record Id : " + gLAccountEntryFormUI.Tbl_GLAccountEntryId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}