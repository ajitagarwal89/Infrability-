using System;
using System.Data.SqlClient;
using System.Data;
using log4net;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.SessionState;
using System.Web;
using Finware;

/// <summary>
/// Summary description for BatchForm
/// </summary>
public class BatchFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
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
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_Batch", batchFormUI.Tbl_BatchId, selectedValue);
            }
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

               
                
                sqlCmd.Parameters.Add("@Opt_Frequency", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Frequency"].Value = batchFormUI.Opt_Frequency;

               

                sqlCmd.Parameters.Add("@RecurringPosting", SqlDbType.Int);
                sqlCmd.Parameters["@RecurringPosting"].Value = batchFormUI.RecurringPosting;

                sqlCmd.Parameters.Add("@DaysToIncrement", SqlDbType.Int);
                sqlCmd.Parameters["@DaysToIncrement"].Value = batchFormUI.DaysToIncrement;

                

                sqlCmd.Parameters.Add("@NumberOfTimesPosted", SqlDbType.Int);
                sqlCmd.Parameters["@NumberOfTimesPosted"].Value = batchFormUI.NumberOfTimesPosted;

                sqlCmd.Parameters.Add("@ControlJournalEntries", SqlDbType.Int);
                sqlCmd.Parameters["@ControlJournalEntries"].Value = batchFormUI.ControlJournalEntries;

                sqlCmd.Parameters.Add("@ActualJournalEntries", SqlDbType.Int);
                sqlCmd.Parameters["@ActualJournalEntries"].Value = batchFormUI.ActualJournalEntries;

                sqlCmd.Parameters.Add("@IsApproved", SqlDbType.Bit);
                sqlCmd.Parameters["@IsApproved"].Value = batchFormUI.IsApproved;
               
                result = sqlCmd.ExecuteNonQuery();
                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_BatchId"].Value);
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    sqlCmd.Dispose();
                    SupportCon.Close();
                    string tableName = "tbl_BankAccount";                    
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(batchFormUI);
                    audit_IUD.WebServiceInsert(batchFormUI.Tbl_OrganizationId, tableName, RecoredID, batchFormUI.CreatedBy, newValue);
                    return 1;
                }
                else
                {
                    return 0;
                }                
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

               
              

                sqlCmd.Parameters.Add("@Opt_Frequency", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Frequency"].Value = batchFormUI.Opt_Frequency;

               

                sqlCmd.Parameters.Add("@RecurringPosting", SqlDbType.Int);
                sqlCmd.Parameters["@RecurringPosting"].Value = batchFormUI.RecurringPosting;

                sqlCmd.Parameters.Add("@DaysToIncrement", SqlDbType.Int);
                sqlCmd.Parameters["@DaysToIncrement"].Value = batchFormUI.DaysToIncrement;

                

                sqlCmd.Parameters.Add("@NumberOfTimesPosted", SqlDbType.Int);
                sqlCmd.Parameters["@NumberOfTimesPosted"].Value = batchFormUI.NumberOfTimesPosted;

                sqlCmd.Parameters.Add("@ControlJournalEntries", SqlDbType.Int);
                sqlCmd.Parameters["@ControlJournalEntries"].Value = batchFormUI.ControlJournalEntries;

                sqlCmd.Parameters.Add("@ActualJournalEntries", SqlDbType.Int);
                sqlCmd.Parameters["@ActualJournalEntries"].Value = batchFormUI.ActualJournalEntries;

                sqlCmd.Parameters.Add("@IsApproved", SqlDbType.Bit);
                sqlCmd.Parameters["@IsApproved"].Value = batchFormUI.IsApproved;
                
                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(batchFormUI);
                    audit_IUD.WebServiceUpdate(batchFormUI.Tbl_OrganizationId, "tbl_Batch", batchFormUI.Tbl_BatchId, batchFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();

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
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_Batch", batchFormUI.Tbl_BatchId);
                }

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

    public int UpdatePostingBatch(BatchFormUI batchFormUI)
    {
        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Batch_UpdatePosting", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;


                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = batchFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = batchFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = batchFormUI.Tbl_BatchId;         
                  
                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = batchFormUI.IsPosted;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(batchFormUI);
                    audit_IUD.WebServiceUpdate(batchFormUI.Tbl_OrganizationId, "tbl_Batch", batchFormUI.Tbl_BatchId, batchFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();

            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePostingBatch()";
            logExcpUIobj.ResourceName = "BatchFormDAL.CS";
            logExcpUIobj.RecordId = batchFormUI.Tbl_BatchId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[BatchFormDAL : UpdatePostingBatch] An error occured in the processing of Record Id : " + batchFormUI.Tbl_BatchId + ". Details : [" + exp.ToString() + "]");
        }


        return result;

    }
}