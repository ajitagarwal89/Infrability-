using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.SessionState;
using Finware;
using log4net;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for OptionSet_L1FormDAL
/// </summary>
public class OptionSet_L1FormDAL: IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();

    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public OptionSet_L1FormDAL()
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
            logExcpUIobj.MethodName = "OptionSet_L1FormDAL()";
            logExcpUIobj.ResourceName = "OptionSet_L1FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[OptionSet_L1FormDAL : OptionSet_L1FormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetOptionSet_L1ListById(OptionSet_L1FormUI optionSet_L1FormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_L1_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L1Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSet_L1Id"].Value = optionSet_L1FormUI.Tbl_OptionSet_L1Id;

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
                audit_IUD.WebServiceSelectInsert("tbl_OptionSet_L1", optionSet_L1FormUI.Tbl_OptionSet_L1Id, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetOptionSet_L1ListById()";
            logExcpUIobj.ResourceName = "OptionSet_L1FormDAL.CS";
            logExcpUIobj.RecordId = optionSet_L1FormUI.Tbl_OptionSet_L1Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSet_L1FormDAL : GetOptionSet_L1ListById] An error occured in the processing of Record Id : " + optionSet_L1FormUI.Tbl_OptionSet_L1Id + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddOptionSet_L1(OptionSet_L1FormUI optionSet_L1FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_L1_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = optionSet_L1FormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = optionSet_L1FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_OptionSetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSetId"].Value = optionSet_L1FormUI.Tbl_OptionSetId;

                sqlCmd.Parameters.Add("@OptionSetLable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OptionSetLable"].Value = optionSet_L1FormUI.OptionSetLable;

                sqlCmd.Parameters.Add("@OptionSetValue", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OptionSetValue"].Value = optionSet_L1FormUI.OptionSetValue;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L1Id", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_OptionSet_L1Id"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_OptionSet_L1Id"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_OptionSet_L1";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(optionSet_L1FormUI);
                    audit_IUD.WebServiceInsert(optionSet_L1FormUI.Tbl_OrganizationId, tableName, RecoredID, optionSet_L1FormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddOptionSet_L1()";
            logExcpUIobj.ResourceName = "OptionSet_L1FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSet_L1FormDAL : AddOptionSet_L1] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int UpdateOptionSet_L1(OptionSet_L1FormUI optionSet_L1FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_L1_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L1Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSet_L1Id"].Value = optionSet_L1FormUI.Tbl_OptionSet_L1Id;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = optionSet_L1FormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = optionSet_L1FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_OptionSetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSetId"].Value = optionSet_L1FormUI.Tbl_OptionSetId;

                sqlCmd.Parameters.Add("@OptionSetLable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OptionSetLable"].Value = optionSet_L1FormUI.OptionSetLable;

                sqlCmd.Parameters.Add("@OptionSetValue", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OptionSetValue"].Value = optionSet_L1FormUI.OptionSetValue;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_OptionSet_L1Id"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_OptionSet_L1";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(optionSet_L1FormUI);
                    audit_IUD.WebServiceInsert(optionSet_L1FormUI.Tbl_OrganizationId, tableName, RecoredID, optionSet_L1FormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "UpdateOptionSet_L1()";
            logExcpUIobj.ResourceName = "OptionSet_L1FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSet_L1FormDAL : UpdateOptionSet_L1] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int DeleteOptionSet_L1(OptionSet_L1FormUI optionSet_L1FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_L1_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L1Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSet_L1Id"].Value = optionSet_L1FormUI.Tbl_OptionSet_L1Id;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_OptionSet_L1", optionSet_L1FormUI.Tbl_OptionSet_L1Id);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteOptionSet_L1()";
            logExcpUIobj.ResourceName = "OptionSet_L1FormDAL.CS";
            logExcpUIobj.RecordId = optionSet_L1FormUI.Tbl_OptionSet_L1Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSet_L1FormDAL : DeleteOptionSet_L1] An error occured in the processing of Record Id : " + optionSet_L1FormUI.Tbl_OptionSet_L1Id + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}