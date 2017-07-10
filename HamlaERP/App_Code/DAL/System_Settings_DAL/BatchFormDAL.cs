using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for BatchForm
/// </summary>
public class BatchFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public BatchFormDAL()
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
            logExcpUIobj.MethodName = "BatchFormDAL()";
            logExcpUIobj.ResourceName = "BatchFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[BatchFormDAL : BatchFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetBatchListById(BatchFormUI batchFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Batch_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = batchFormUI.Tbl_BatchId;

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
            logExcpUIobj.MethodName = "getBatchListById()";
            logExcpUIobj.ResourceName = "BatchFormDAL.CS";
            logExcpUIobj.RecordId = batchFormUI.Tbl_BatchId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BatchFormDAL : getBatchListById] An error occured in the processing of Record Id : " + batchFormUI.Tbl_BatchId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddBatch(BatchFormUI batchFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Batch_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = batchFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = batchFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Opt_BatchType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_BatchType"].Value = batchFormUI.Opt_BatchType;

                sqlCmd.Parameters.Add("@BatchName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BatchName"].Value = batchFormUI.BatchName;

                sqlCmd.Parameters.Add("@Comment", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment"].Value = batchFormUI.Comment;

                sqlCmd.Parameters.Add("@Opt_Origin", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Origin"].Value = batchFormUI.Opt_Origin;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = batchFormUI.PostingDate;
                
                sqlCmd.Parameters.Add("@Opt_Frequency", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Frequency"].Value = batchFormUI.Opt_Frequency;

                sqlCmd.Parameters.Add("@BreakDownAllocation", SqlDbType.Bit);
                sqlCmd.Parameters["@BreakDownAllocation"].Value = batchFormUI.BreakDownAllocation;

                sqlCmd.Parameters.Add("@RecurringPosting", SqlDbType.Int);
                sqlCmd.Parameters["@RecurringPosting"].Value = batchFormUI.RecurringPosting;

                sqlCmd.Parameters.Add("@DaysToIncrement", SqlDbType.Int);
                sqlCmd.Parameters["@DaysToIncrement"].Value = batchFormUI.DaysToIncrement;

                sqlCmd.Parameters.Add("@LastDatePosted", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastDatePosted"].Value = batchFormUI.LastDatePosted;

                sqlCmd.Parameters.Add("@NumberOfTimesPosted", SqlDbType.Int);
                sqlCmd.Parameters["@NumberOfTimesPosted"].Value = batchFormUI.NumberOfTimesPosted;

                sqlCmd.Parameters.Add("@ControlJournalEntries", SqlDbType.Int);
                sqlCmd.Parameters["@ControlJournalEntries"].Value = batchFormUI.ControlJournalEntries;

                sqlCmd.Parameters.Add("@ActualJournalEntries", SqlDbType.Int);
                sqlCmd.Parameters["@ActualJournalEntries"].Value = batchFormUI.ActualJournalEntries;

                sqlCmd.Parameters.Add("@IsApproved", SqlDbType.Bit);
                sqlCmd.Parameters["@IsApproved"].Value = batchFormUI.IsApproved;

                //sqlCmd.Parameters.Add("@tbl_UserId_ApprovedBy", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@tbl_UserId_ApprovedBy"].Value = batchFormUI.Tbl_UserId_ApprovedBy;

                //sqlCmd.Parameters.Add("@ApprovedDate", SqlDbType.DateTime);
                //sqlCmd.Parameters["@ApprovedDate"].Value = batchFormUI.ApprovedDate;           

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddBatch()";
            logExcpUIobj.ResourceName = "BatchFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BatchFormDAL : AddBatch] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateBatch(BatchFormUI batchFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Batch_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = batchFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = batchFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = batchFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Opt_BatchType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_BatchType"].Value = batchFormUI.Opt_BatchType;

                sqlCmd.Parameters.Add("@BatchName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BatchName"].Value = batchFormUI.BatchName;

                sqlCmd.Parameters.Add("@Comment", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment"].Value = batchFormUI.Comment;

                sqlCmd.Parameters.Add("@Opt_Origin", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Origin"].Value = batchFormUI.Opt_Origin;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = batchFormUI.PostingDate;
              

                sqlCmd.Parameters.Add("@Opt_Frequency", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Frequency"].Value = batchFormUI.Opt_Frequency;

                sqlCmd.Parameters.Add("@BreakDownAllocation", SqlDbType.Bit);
                sqlCmd.Parameters["@BreakDownAllocation"].Value = batchFormUI.BreakDownAllocation;

                sqlCmd.Parameters.Add("@RecurringPosting", SqlDbType.Int);
                sqlCmd.Parameters["@RecurringPosting"].Value = batchFormUI.RecurringPosting;

                sqlCmd.Parameters.Add("@DaysToIncrement", SqlDbType.Int);
                sqlCmd.Parameters["@DaysToIncrement"].Value = batchFormUI.DaysToIncrement;

                sqlCmd.Parameters.Add("@LastDatePosted", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastDatePosted"].Value = batchFormUI.LastDatePosted;

                sqlCmd.Parameters.Add("@NumberOfTimesPosted", SqlDbType.Int);
                sqlCmd.Parameters["@NumberOfTimesPosted"].Value = batchFormUI.NumberOfTimesPosted;

                sqlCmd.Parameters.Add("@ControlJournalEntries", SqlDbType.Int);
                sqlCmd.Parameters["@ControlJournalEntries"].Value = batchFormUI.ControlJournalEntries;

                sqlCmd.Parameters.Add("@ActualJournalEntries", SqlDbType.Int);
                sqlCmd.Parameters["@ActualJournalEntries"].Value = batchFormUI.ActualJournalEntries;

                sqlCmd.Parameters.Add("@IsApproved", SqlDbType.Bit);
                sqlCmd.Parameters["@IsApproved"].Value = batchFormUI.IsApproved;

                //sqlCmd.Parameters.Add("@tbl_UserId_ApprovedBy", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@tbl_UserId_ApprovedBy"].Value = batchFormUI.Tbl_UserId_ApprovedBy;

                //sqlCmd.Parameters.Add("@ApprovedDate", SqlDbType.DateTime);
                //sqlCmd.Parameters["@ApprovedDate"].Value = batchFormUI.ApprovedDate;               

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateBatch()";
            logExcpUIobj.ResourceName = "BatchFormDAL.CS";
            logExcpUIobj.RecordId = batchFormUI.Tbl_BatchId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BatchFormDAL : UpdateBatch] An error occured in the processing of Record Id : " + batchFormUI.Tbl_BatchId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteBatch(BatchFormUI batchFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Batch_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = batchFormUI.Tbl_BatchId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteBatch()";
            logExcpUIobj.ResourceName = "BatchFormDAL.CS";
            logExcpUIobj.RecordId = batchFormUI.Tbl_BatchId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BatchFormDAL : DeleteBatch] An error occured in the processing of Record Id : " + batchFormUI.Tbl_BatchId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}