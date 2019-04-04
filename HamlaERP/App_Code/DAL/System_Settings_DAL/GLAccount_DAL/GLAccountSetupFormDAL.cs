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
/// Summary description for GLAccountSetupFormDAL
/// </summary>
public class GLAccountSetupFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    
    public GLAccountSetupFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountSetupFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountSetupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountSetupFormDAL : GLAccountSetupFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetGLAccountSetupListById(GLAccountSetupFormUI gLAccountSetupFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSetup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSetupId"].Value = gLAccountSetupFormUI.Tbl_GLAccountSetupId;

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
                audit_IUD.WebServiceSelectInsert("tbl_GLAccountSetup", gLAccountSetupFormUI.Tbl_GLAccountSetupId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetGLAccountSetupListById()";
            logExcpUIobj.ResourceName = "GLAccountSetupFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountSetupFormUI.Tbl_GLAccountSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSetupFormDAL : GetGLAccountSetupListById] An error occured in the processing of Record Id : " + gLAccountSetupFormUI.Tbl_GLAccountSetupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGLAccountSetup(GLAccountSetupFormUI gLAccountSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSetup_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountSetupFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountSetupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Display", SqlDbType.Bit);
                sqlCmd.Parameters["@Display"].Value = gLAccountSetupFormUI.Display;

                
                sqlCmd.Parameters.Add("@tbl_GLAccountId_Account", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Account"].Value = gLAccountSetupFormUI.Tbl_GLAccountId_Account;

                sqlCmd.Parameters.Add("@Accounts", SqlDbType.Bit);
                sqlCmd.Parameters["@Accounts"].Value = gLAccountSetupFormUI.Accounts;

                sqlCmd.Parameters.Add("@Transactions", SqlDbType.Bit);
                sqlCmd.Parameters["@Transactions"].Value = gLAccountSetupFormUI.Transactions;

                sqlCmd.Parameters.Add("@PostingToHistory", SqlDbType.Bit);
                sqlCmd.Parameters["@PostingToHistory"].Value = gLAccountSetupFormUI.PostingToHistory;

                sqlCmd.Parameters.Add("@DeletionOfSavedTransactions", SqlDbType.Bit);
                sqlCmd.Parameters["@DeletionOfSavedTransactions"].Value = gLAccountSetupFormUI.DeletionOfSavedTransactions;

                sqlCmd.Parameters.Add("@tbl_GLAccountSetupId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_GLAccountSetupId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();
                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_GLAccountSetupId"].Value);
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    sqlCmd.Dispose();
                    SupportCon.Close();
                    string tableName = "tbl_GLAccountSetup";
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(gLAccountSetupFormUI);
                    audit_IUD.WebServiceInsert(gLAccountSetupFormUI.Tbl_OrganizationId, tableName, RecoredID, gLAccountSetupFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddGLAccountSetup()";
            logExcpUIobj.ResourceName = "GLAccountSetupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSetupFormDAL : AddGLAccountSetup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccountSetup(GLAccountSetupFormUI gLAccountSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSetup_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountSetupFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_GLAccountSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSetupId"].Value = gLAccountSetupFormUI.Tbl_GLAccountSetupId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountSetupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Display", SqlDbType.Bit);
                sqlCmd.Parameters["@Display"].Value = gLAccountSetupFormUI.Display;
              

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Account", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Account"].Value = gLAccountSetupFormUI.Tbl_GLAccountId_Account;

                sqlCmd.Parameters.Add("@Accounts", SqlDbType.Bit);
                sqlCmd.Parameters["@Accounts"].Value = gLAccountSetupFormUI.Accounts;

                sqlCmd.Parameters.Add("@Transactions", SqlDbType.Bit);
                sqlCmd.Parameters["@Transactions"].Value = gLAccountSetupFormUI.Transactions;

                sqlCmd.Parameters.Add("@PostingToHistory", SqlDbType.Bit);
                sqlCmd.Parameters["@PostingToHistory"].Value = gLAccountSetupFormUI.PostingToHistory;

                sqlCmd.Parameters.Add("@DeletionOfSavedTransactions", SqlDbType.Bit);
                sqlCmd.Parameters["@DeletionOfSavedTransactions"].Value = gLAccountSetupFormUI.DeletionOfSavedTransactions;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(gLAccountSetupFormUI);
                    audit_IUD.WebServiceUpdate(gLAccountSetupFormUI.Tbl_OrganizationId, "tbl_GLAccountSetup", gLAccountSetupFormUI.Tbl_GLAccountSetupId, gLAccountSetupFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountSetup()";
            logExcpUIobj.ResourceName = "GLAccountSetupFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountSetupFormUI.Tbl_GLAccountSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSetupFormDAL : UpdateGLAccountSetup] An error occured in the processing of Record Id : " + gLAccountSetupFormUI.Tbl_GLAccountSetupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGLAccountSetup(GLAccountSetupFormUI gLAccountSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSetup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSetupId"].Value = gLAccountSetupFormUI.Tbl_GLAccountSetupId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_GLAccountSetup", gLAccountSetupFormUI.Tbl_GLAccountSetupId);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountSetup()";
            logExcpUIobj.ResourceName = "GLAccountSetupFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountSetupFormUI.Tbl_GLAccountSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSetupFormDAL : DeleteGLAccountSetup] An error occured in the processing of Record Id : " + gLAccountSetupFormUI.Tbl_GLAccountSetupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}