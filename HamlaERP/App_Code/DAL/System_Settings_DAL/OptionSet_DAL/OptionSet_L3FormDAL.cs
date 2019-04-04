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
/// Summary description for OptionSet_L3FormDAL
/// </summary>
public class OptionSet_L3FormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public OptionSet_L3FormDAL()
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
            logExcpUIobj.MethodName = "OptionSet_L3FormDAL()";
            logExcpUIobj.ResourceName = "OptionSet_L3FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[OptionSet_L3FormDAL : OptionSet_L3FormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetOptionSet_L3ListById(OptionSet_L3FormUI optionSet_L3FormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_L3_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L3Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSet_L3Id"].Value = optionSet_L3FormUI.Tbl_OptionSet_L3Id;

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
                audit_IUD.WebServiceSelectInsert("tbl_OptionSet_L3", optionSet_L3FormUI.Tbl_OptionSet_L3Id, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetOptionSet_L3ListById()";
            logExcpUIobj.ResourceName = "OptionSet_L3FormDAL.CS";
            logExcpUIobj.RecordId = optionSet_L3FormUI.Tbl_OptionSet_L3Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSet_L3FormDAL : GetOptionSet_L3ListById] An error occured in the processing of Record Id : " + optionSet_L3FormUI.Tbl_OptionSet_L3Id + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddOptionSet_L3(OptionSet_L3FormUI optionSet_L3FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_L3_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = optionSet_L3FormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = optionSet_L3FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_OptionSetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSetId"].Value = optionSet_L3FormUI.Tbl_OptionSetId;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L1Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSet_L1Id"].Value = optionSet_L3FormUI.Tbl_OptionSet_L1Id;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L2Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSet_L2Id"].Value = optionSet_L3FormUI.Tbl_OptionSet_L2Id;

                sqlCmd.Parameters.Add("@OptionSetLable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OptionSetLable"].Value = optionSet_L3FormUI.OptionSetLable;

                sqlCmd.Parameters.Add("@OptionSetValue", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OptionSetValue"].Value = optionSet_L3FormUI.OptionSetValue;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L3Id", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_OptionSet_L3Id"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

               

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_OptionSet_L3";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(optionSet_L3FormUI);
                    audit_IUD.WebServiceInsert(optionSet_L3FormUI.Tbl_OrganizationId, tableName, null, optionSet_L3FormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddOptionSet_L3()";
            logExcpUIobj.ResourceName = "OptionSet_L3FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSet_L3FormDAL : AddOptionSet_L3] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int UpdateOptionSet_L3(OptionSet_L3FormUI optionSet_L3FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_L3_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L3Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSet_L3Id"].Value = optionSet_L3FormUI.Tbl_OptionSet_L3Id;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = optionSet_L3FormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = optionSet_L3FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_OptionSetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSetId"].Value = optionSet_L3FormUI.Tbl_OptionSetId;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L1Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSet_L1Id"].Value = optionSet_L3FormUI.Tbl_OptionSet_L1Id;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L2Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSet_L2Id"].Value = optionSet_L3FormUI.Tbl_OptionSet_L2Id;

                sqlCmd.Parameters.Add("@OptionSetLable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OptionSetLable"].Value = optionSet_L3FormUI.OptionSetLable;

                sqlCmd.Parameters.Add("@OptionSetValue", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OptionSetValue"].Value = optionSet_L3FormUI.OptionSetValue;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_OptionSet_L3Id"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_OptionSet_L3";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(optionSet_L3FormUI);
                    audit_IUD.WebServiceInsert(optionSet_L3FormUI.Tbl_OrganizationId, tableName, RecoredID, optionSet_L3FormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "UpdateOptionSet_L3()";
            logExcpUIobj.ResourceName = "OptionSet_L3FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSet_L3FormDAL : UpdateOptionSet_L3] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int DeleteOptionSet_L3(OptionSet_L3FormUI optionSet_L3FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_L3_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L3Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSet_L3Id"].Value = optionSet_L3FormUI.Tbl_OptionSet_L3Id;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_OptionSet_L3", optionSet_L3FormUI.Tbl_OptionSet_L3Id);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteOptionSet_L3()";
            logExcpUIobj.ResourceName = "OptionSet_L3FormDAL.CS";
            logExcpUIobj.RecordId = optionSet_L3FormUI.Tbl_OptionSet_L3Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSet_L3FormDAL : DeleteOptionSet_L3] An error occured in the processing of Record Id : " + optionSet_L3FormUI.Tbl_OptionSet_L3Id + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}