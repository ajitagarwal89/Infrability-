using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.SessionState;
using Finware;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for GLAccountSetupPostingFormDAL
/// </summary>
public class GLAccountSetupPostingFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public GLAccountSetupPostingFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountSetupPostingFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountSetupPostingFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountSetupPostingFormDAL : GLAccountSetupPostingFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetGLAccountSetupPostingListById(GLAccountSetupPostingFormUI gLAccountSetupPostingFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSetupPosting_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountSetupPostingId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSetupPostingId"].Value = gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId;

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
                audit_IUD.WebServiceSelectInsert("tbl_GLAccountSetupPosting", gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetGLAccountSetupPostingListById()";
            logExcpUIobj.ResourceName = "GLAccountSetupPostingFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSetupPostingFormDAL : GetGLAccountSetupPostingListById] An error occured in the processing of Record Id : " + gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddGLAccountSetupPosting(GLAccountSetupPostingFormUI gLAccountSetupPostingFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSetupPosting_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountSetupPostingFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountSetupPostingFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@opt_Series", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_Series"].Value = gLAccountSetupPostingFormUI.opt_Series;

                sqlCmd.Parameters.Add("@opt_Origin", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Origin"].Value = gLAccountSetupPostingFormUI.opt_Origin;

                sqlCmd.Parameters.Add("@PostToGL", SqlDbType.Bit);
                sqlCmd.Parameters["@PostToGL"].Value = gLAccountSetupPostingFormUI.PostToGL;

                sqlCmd.Parameters.Add("@PostThroughGLFile", SqlDbType.Bit);
                sqlCmd.Parameters["@PostThroughGLFile"].Value = gLAccountSetupPostingFormUI.PostThroughGLFile;

                sqlCmd.Parameters.Add("@AllowTransactionPosting", SqlDbType.Bit);
                sqlCmd.Parameters["@AllowTransactionPosting"].Value = gLAccountSetupPostingFormUI.AllowTransactionPosting;

                sqlCmd.Parameters.Add("@IncludeMultiCurrencyInfo", SqlDbType.Bit);
                sqlCmd.Parameters["@IncludeMultiCurrencyInfo"].Value = gLAccountSetupPostingFormUI.IncludeMultiCurrencyInfo;

                sqlCmd.Parameters.Add("@VerifyNumberOfTransaction", SqlDbType.Bit);
                sqlCmd.Parameters["@VerifyNumberOfTransaction"].Value = gLAccountSetupPostingFormUI.VerifyNumberOfTransaction;

                sqlCmd.Parameters.Add("@VerifyBatchAmount", SqlDbType.Bit);
                sqlCmd.Parameters["@VerifyBatchAmount"].Value = gLAccountSetupPostingFormUI.VerifyBatchAmount;

                sqlCmd.Parameters.Add("@Transaction", SqlDbType.Bit);
                sqlCmd.Parameters["@Transaction"].Value = gLAccountSetupPostingFormUI.Transaction;

                sqlCmd.Parameters.Add("@Batch", SqlDbType.Bit);
                sqlCmd.Parameters["@Batch"].Value = gLAccountSetupPostingFormUI.Batch;

                sqlCmd.Parameters.Add("@UseAccountSetting", SqlDbType.Bit);
                sqlCmd.Parameters["@UseAccountSetting"].Value = gLAccountSetupPostingFormUI.UseAccountSetting;

                sqlCmd.Parameters.Add("@PostingDateFromBatch", SqlDbType.Bit);
                sqlCmd.Parameters["@PostingDateFromBatch"].Value = gLAccountSetupPostingFormUI.PostingDateFromBatch;

                sqlCmd.Parameters.Add("@PostingDateFromTrx", SqlDbType.Bit);
                sqlCmd.Parameters["@PostingDateFromTrx"].Value = gLAccountSetupPostingFormUI.PostingDateFromTrx;

                sqlCmd.Parameters.Add("@IfExistingBatchAppend", SqlDbType.Bit);
                sqlCmd.Parameters["@IfExistingBatchAppend"].Value = gLAccountSetupPostingFormUI.IfExistingBatchAppend;

                sqlCmd.Parameters.Add("@IfExistingBatchCreateNew", SqlDbType.Bit);
                sqlCmd.Parameters["@IfExistingBatchCreateNew"].Value = gLAccountSetupPostingFormUI.IfExistingBatchCreateNew;

                sqlCmd.Parameters.Add("@RequireBatchApproval", SqlDbType.Bit);
                sqlCmd.Parameters["@RequireBatchApproval"].Value = gLAccountSetupPostingFormUI.RequireBatchApproval;

                sqlCmd.Parameters.Add("@BatchApprovalPassword", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BatchApprovalPassword"].Value = gLAccountSetupPostingFormUI.BatchApprovalPassword;

                sqlCmd.Parameters.Add("@tbl_GLAccountSetupPostingId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_GLAccountSetupPostingId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_GLAccountSetupPostingId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_GLAccountSetupPosting";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(gLAccountSetupPostingFormUI);
                    audit_IUD.WebServiceInsert(gLAccountSetupPostingFormUI.Tbl_OrganizationId, tableName, RecoredID, gLAccountSetupPostingFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddGLAccountSetupPosting()";
            logExcpUIobj.ResourceName = "GLAccountSetupPostingFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSetupPostingFormDAL : AddGLAccountSetupPosting] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int UpdateGLAccountSetupPosting(GLAccountSetupPostingFormUI gLAccountSetupPostingFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSetupPosting_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountSetupPostingFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountSetupPostingFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountSetupPostingId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSetupPostingId"].Value = gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId;

                sqlCmd.Parameters.Add("@opt_Series", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_Series"].Value = gLAccountSetupPostingFormUI.opt_Series;

                sqlCmd.Parameters.Add("@opt_Origin", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Origin"].Value = gLAccountSetupPostingFormUI.opt_Origin;

                sqlCmd.Parameters.Add("@PostToGL", SqlDbType.Bit);
                sqlCmd.Parameters["@PostToGL"].Value = gLAccountSetupPostingFormUI.PostToGL;

                sqlCmd.Parameters.Add("@PostThroughGLFile", SqlDbType.Bit);
                sqlCmd.Parameters["@PostThroughGLFile"].Value = gLAccountSetupPostingFormUI.PostThroughGLFile;

                sqlCmd.Parameters.Add("@AllowTransactionPosting", SqlDbType.Bit);
                sqlCmd.Parameters["@AllowTransactionPosting"].Value = gLAccountSetupPostingFormUI.AllowTransactionPosting;

                sqlCmd.Parameters.Add("@IncludeMultiCurrencyInfo", SqlDbType.Bit);
                sqlCmd.Parameters["@IncludeMultiCurrencyInfo"].Value = gLAccountSetupPostingFormUI.IncludeMultiCurrencyInfo;

                sqlCmd.Parameters.Add("@VerifyNumberOfTransaction", SqlDbType.Bit);
                sqlCmd.Parameters["@VerifyNumberOfTransaction"].Value = gLAccountSetupPostingFormUI.VerifyNumberOfTransaction;

                sqlCmd.Parameters.Add("@VerifyBatchAmount", SqlDbType.Bit);
                sqlCmd.Parameters["@VerifyBatchAmount"].Value = gLAccountSetupPostingFormUI.VerifyBatchAmount;

                sqlCmd.Parameters.Add("@Transaction", SqlDbType.Bit);
                sqlCmd.Parameters["@Transaction"].Value = gLAccountSetupPostingFormUI.Transaction;

                sqlCmd.Parameters.Add("@Batch", SqlDbType.Bit);
                sqlCmd.Parameters["@Batch"].Value = gLAccountSetupPostingFormUI.Batch;

                sqlCmd.Parameters.Add("@UseAccountSetting", SqlDbType.Bit);
                sqlCmd.Parameters["@UseAccountSetting"].Value = gLAccountSetupPostingFormUI.UseAccountSetting;

                sqlCmd.Parameters.Add("@PostingDateFromBatch", SqlDbType.Bit);
                sqlCmd.Parameters["@PostingDateFromBatch"].Value = gLAccountSetupPostingFormUI.PostingDateFromBatch;

                sqlCmd.Parameters.Add("@PostingDateFromTrx", SqlDbType.Bit);
                sqlCmd.Parameters["@PostingDateFromTrx"].Value = gLAccountSetupPostingFormUI.PostingDateFromTrx;

                sqlCmd.Parameters.Add("@IfExistingBatchAppend", SqlDbType.Bit);
                sqlCmd.Parameters["@IfExistingBatchAppend"].Value = gLAccountSetupPostingFormUI.IfExistingBatchAppend;

                sqlCmd.Parameters.Add("@IfExistingBatchCreateNew", SqlDbType.Bit);
                sqlCmd.Parameters["@IfExistingBatchCreateNew"].Value = gLAccountSetupPostingFormUI.IfExistingBatchCreateNew;

                sqlCmd.Parameters.Add("@RequireBatchApproval", SqlDbType.Bit);
                sqlCmd.Parameters["@RequireBatchApproval"].Value = gLAccountSetupPostingFormUI.RequireBatchApproval;

                sqlCmd.Parameters.Add("@BatchApprovalPassword", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BatchApprovalPassword"].Value = gLAccountSetupPostingFormUI.BatchApprovalPassword;




                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(gLAccountSetupPostingFormUI);
                    audit_IUD.WebServiceUpdate(gLAccountSetupPostingFormUI.Tbl_OrganizationId, "tbl_GLAccountSetupPosting", gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId, gLAccountSetupPostingFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountSetupPosting()";
            logExcpUIobj.ResourceName = "GLAccountSetupPostingFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSetupPostingFormDAL : UpdateGLAccountSetupPosting] An error occured in the processing of Record Id : " + gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int DeleteGLAccountSetupPosting(GLAccountSetupPostingFormUI gLAccountSetupPostingFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSetupPosting_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountSetupPostingId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSetupPostingId"].Value = gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_GLAccountSetupPosting", gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountSetupPosting()";
            logExcpUIobj.ResourceName = "GLAccountSetupPostingFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSetupPostingFormDAL : DeleteGLAccountSetupPosting] An error occured in the processing of Record Id : " + gLAccountSetupPostingFormUI.Tbl_GLAccountSetupPostingId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}