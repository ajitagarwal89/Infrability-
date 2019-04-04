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
/// Summary description for GLAccountConfigurationSettingsFormDAL
/// </summary>
public class GLAccountConfigurationSettingsFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public GLAccountConfigurationSettingsFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountConfigurationSettingsFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountConfigurationSettingsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountConfigurationSettingsFormDAL : GLAccountConfigurationSettingsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

      public DataTable GetGLAccountConfigurationSettingsListById(GLAccountConfigurationSettingsFormUI gLAccountConfigurationSettingsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountConfigurationSettings_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountConfigurationSettingsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountConfigurationSettingsId"].Value = gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId;

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
                audit_IUD.WebServiceSelectInsert("tbl_GLAccountConfigurationSettings", gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getGLAccountConfigurationSettingsListById()";
            logExcpUIobj.ResourceName = "GLAccountConfigurationSettingsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountConfigurationSettingsFormDAL : getGLAccountConfigurationSettingsListById] An error occured in the processing of Record Id : " + gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGLAccountConfigurationSettings(GLAccountConfigurationSettingsFormUI gLAccountConfigurationSettingsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountConfigurationSettings_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountConfigurationSettingsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountConfigurationSettingsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_RetainedEarning", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_RetainedEarning"].Value = gLAccountConfigurationSettingsFormUI.Tbl_GLAccountId_RetainedEarning;

                sqlCmd.Parameters.Add("@PostingToHistory", SqlDbType.Bit);
                sqlCmd.Parameters["@PostingToHistory"].Value = gLAccountConfigurationSettingsFormUI.PostingToHistory;

                sqlCmd.Parameters.Add("@DeletionOfSavedTransaction", SqlDbType.Bit);
                sqlCmd.Parameters["@DeletionOfSavedTransaction"].Value = gLAccountConfigurationSettingsFormUI.DeletionOfSavedTransaction;

                sqlCmd.Parameters.Add("@tbl_GLAccountConfigurationSettingsId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_GLAccountConfigurationSettingsId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_GLAccountConfigurationSettingsId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_GLAccountConfigurationSettings";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(gLAccountConfigurationSettingsFormUI);
                    audit_IUD.WebServiceInsert(gLAccountConfigurationSettingsFormUI.Tbl_OrganizationId, tableName, recordID, gLAccountConfigurationSettingsFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddGLAccountConfigurationSettings()";
            logExcpUIobj.ResourceName = "GLAccountConfigurationSettingsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountConfigurationSettingsFormDAL : AddGLAccountConfigurationSettings] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccountConfigurationSettings(GLAccountConfigurationSettingsFormUI gLAccountConfigurationSettingsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountConfigurationSettings_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;


                sqlCmd.Parameters.Add("@tbl_GLAccountConfigurationSettingsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountConfigurationSettingsId"].Value = gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountConfigurationSettingsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountConfigurationSettingsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_RetainedEarning", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_RetainedEarning"].Value = gLAccountConfigurationSettingsFormUI.Tbl_GLAccountId_RetainedEarning;

                sqlCmd.Parameters.Add("@PostingToHistory", SqlDbType.Bit);
                sqlCmd.Parameters["@PostingToHistory"].Value = gLAccountConfigurationSettingsFormUI.PostingToHistory;

                sqlCmd.Parameters.Add("@DeletionOfSavedTransaction", SqlDbType.Bit);
                sqlCmd.Parameters["@DeletionOfSavedTransaction"].Value = gLAccountConfigurationSettingsFormUI.DeletionOfSavedTransaction;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(gLAccountConfigurationSettingsFormUI);
                    audit_IUD.WebServiceUpdate(gLAccountConfigurationSettingsFormUI.Tbl_OrganizationId, "tbl_GLAccountConfigurationSettings", gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId, gLAccountConfigurationSettingsFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountConfigurationSettings()";
            logExcpUIobj.ResourceName = "GLAccountConfigurationSettingsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountConfigurationSettingsFormDAL : UpdateGLAccountConfigurationSettings] An error occured in the processing of Record Id : " + gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGLAccountConfigurationSettings(GLAccountConfigurationSettingsFormUI gLAccountConfigurationSettingsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountConfigurationSettings_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountConfigurationSettingsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountConfigurationSettingsId"].Value = gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_GLAccountConfigurationSettings", gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountConfigurationSettings()";
            logExcpUIobj.ResourceName = "GLAccountConfigurationSettingsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountConfigurationSettingsFormDAL : DeleteGLAccountConfigurationSettings] An error occured in the processing of Record Id : " + gLAccountConfigurationSettingsFormUI.Tbl_GLAccountConfigurationSettingsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}