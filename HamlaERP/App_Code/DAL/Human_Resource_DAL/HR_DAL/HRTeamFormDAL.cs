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
/// Summary description for HRTeamFormDAL
/// </summary>
public class HRTeamFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public HRTeamFormDAL()
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
            logExcpUIobj.MethodName = "HRTeamFormDAL()";
            logExcpUIobj.ResourceName = "HRTeamFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[HRTeamFormDAL : HRTeamFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetHRTeamListById(HRTeamFormUI hRTeamFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Team_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_TeamId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_TeamId"].Value = hRTeamFormUI.Tbl_HR_TeamId;

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
                audit_IUD.WebServiceSelectInsert("tbl_HR_Team", hRTeamFormUI.Tbl_HR_TeamId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getHRTeamListById()";
            logExcpUIobj.ResourceName = "HRTeamFormDAL.CS";
            logExcpUIobj.RecordId = hRTeamFormUI.Tbl_HR_TeamId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HRTeamFormDAL : getHRTeamListById] An error occured in the processing of Record Id : " + hRTeamFormUI.Tbl_HR_TeamId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddHRTeam(HRTeamFormUI hRTeamFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Team_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = hRTeamFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = hRTeamFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_HR_DepartmentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DepartmentId"].Value = hRTeamFormUI.Tbl_HR_DepartmentId;

                sqlCmd.Parameters.Add("@TeamCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@TeamCode"].Value = hRTeamFormUI.TeamCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = hRTeamFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_HR_TeamId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_HR_TeamId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_HR_TeamId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_HR_Team";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(hRTeamFormUI);
                    audit_IUD.WebServiceInsert(hRTeamFormUI.Tbl_OrganizationId, tableName, recordID, hRTeamFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddHRTeam()";
            logExcpUIobj.ResourceName = "HRTeamFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HRTeamFormDAL : AddHRTeam] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateHRTeam(HRTeamFormUI hRTeamFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Team_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_TeamId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_TeamId"].Value = hRTeamFormUI.Tbl_HR_TeamId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = hRTeamFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = hRTeamFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_HR_DepartmentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DepartmentId"].Value = hRTeamFormUI.Tbl_HR_DepartmentId;

                sqlCmd.Parameters.Add("@TeamCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@TeamCode"].Value = hRTeamFormUI.TeamCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = hRTeamFormUI.Description;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(hRTeamFormUI);
                    audit_IUD.WebServiceUpdate(hRTeamFormUI.Tbl_OrganizationId, "tbl_HR_Team", hRTeamFormUI.Tbl_HR_TeamId, hRTeamFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateHRTeam()";
            logExcpUIobj.ResourceName = "HRTeamFormDAL.CS";
            logExcpUIobj.RecordId = hRTeamFormUI.Tbl_HR_TeamId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HRTeamFormDAL : UpdateHRTeam] An error occured in the processing of Record Id : " + hRTeamFormUI.Tbl_HR_TeamId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteHRTeam(HRTeamFormUI hRTeamFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Team_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_TeamId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_TeamId"].Value = hRTeamFormUI.Tbl_HR_TeamId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_HR_Team", hRTeamFormUI.Tbl_HR_TeamId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteHRTeam()";
            logExcpUIobj.ResourceName = "HRTeamFormDAL.CS";
            logExcpUIobj.RecordId = hRTeamFormUI.Tbl_HR_TeamId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HRTeamFormDAL : DeleteHRTeam] An error occured in the processing of Record Id : " + hRTeamFormUI.Tbl_HR_TeamId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}