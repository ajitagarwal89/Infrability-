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
/// Summary description for HR_SupervisorFormDAL
/// </summary>
public class HR_SupervisorFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public HR_SupervisorFormDAL()
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
            logExcpUIobj.MethodName = "HR_SupervisorFormDAL()";
            logExcpUIobj.ResourceName = "HR_SupervisorFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[HR_SupervisorFormDAL : HR_SupervisorFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetHR_SupervisorListById(HR_SupervisorFormUI hR_SupervisorFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Supervisor_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_SupervisorId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_SupervisorId"].Value = hR_SupervisorFormUI.Tbl_HR_SupervisorId;

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
                audit_IUD.WebServiceSelectInsert("tbl_HR_Supervisor", hR_SupervisorFormUI.Tbl_HR_SupervisorId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getHR_SupervisorListById()";
            logExcpUIobj.ResourceName = "HR_SupervisorFormDAL.CS";
            logExcpUIobj.RecordId = hR_SupervisorFormUI.Tbl_HR_SupervisorId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_SupervisorFormDAL : getHR_SupervisorListById] An error occured in the processing of Record Id : " + hR_SupervisorFormUI.Tbl_HR_SupervisorId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddHR_Supervisor(HR_SupervisorFormUI hR_SupervisorFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Supervisor_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = hR_SupervisorFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = hR_SupervisorFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@SupervisorCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SupervisorCode"].Value = hR_SupervisorFormUI.SupervisorCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = hR_SupervisorFormUI.Description;

                sqlCmd.Parameters.Add("@opt_DepreciatedPeriod", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_DepreciatedPeriod"].Value = hR_SupervisorFormUI.opt_DepreciatedPeriod;

                sqlCmd.Parameters.Add("@opt_CurrentyFiscalYear", SqlDbType.Int);
                sqlCmd.Parameters["@opt_CurrentyFiscalYear"].Value = hR_SupervisorFormUI.opt_CurrentyFiscalYear;

                sqlCmd.Parameters.Add("@tbl_HR_SupervisorId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_HR_SupervisorId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_HR_SupervisorId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_HR_Supervisor";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(hR_SupervisorFormUI);
                    audit_IUD.WebServiceInsert(hR_SupervisorFormUI.Tbl_OrganizationId, tableName, recordID, hR_SupervisorFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddHR_Supervisor()";
            logExcpUIobj.ResourceName = "HR_SupervisorFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_SupervisorFormDAL : AddHR_Supervisor] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateHR_Supervisor(HR_SupervisorFormUI hR_SupervisorFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Supervisor_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = hR_SupervisorFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = hR_SupervisorFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_HR_SupervisorId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_SupervisorId"].Value = hR_SupervisorFormUI.Tbl_HR_SupervisorId;

                sqlCmd.Parameters.Add("@SupervisorCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SupervisorCode"].Value = hR_SupervisorFormUI.SupervisorCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = hR_SupervisorFormUI.Description;

                sqlCmd.Parameters.Add("@opt_DepreciatedPeriod", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_DepreciatedPeriod"].Value = hR_SupervisorFormUI.opt_DepreciatedPeriod;

                sqlCmd.Parameters.Add("@opt_CurrentyFiscalYear", SqlDbType.Int);
                sqlCmd.Parameters["@opt_CurrentyFiscalYear"].Value = hR_SupervisorFormUI.opt_CurrentyFiscalYear;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(hR_SupervisorFormUI);
                    audit_IUD.WebServiceUpdate(hR_SupervisorFormUI.Tbl_OrganizationId, "tbl_HR_Supervisor", hR_SupervisorFormUI.Tbl_HR_SupervisorId, hR_SupervisorFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateHR_Supervisor()";
            logExcpUIobj.ResourceName = "HR_SupervisorFormDAL.CS";
            logExcpUIobj.RecordId = hR_SupervisorFormUI.Tbl_HR_SupervisorId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_SupervisorFormDAL : UpdateHR_Supervisor] An error occured in the processing of Record Id : " + hR_SupervisorFormUI.Tbl_HR_SupervisorId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteHR_Supervisor(HR_SupervisorFormUI hR_SupervisorFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Supervisor_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_SupervisorId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_SupervisorId"].Value = hR_SupervisorFormUI.Tbl_HR_SupervisorId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_HR_Supervisor", hR_SupervisorFormUI.Tbl_HR_SupervisorId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteHR_Supervisor()";
            logExcpUIobj.ResourceName = "HR_SupervisorFormDAL.CS";
            logExcpUIobj.RecordId = hR_SupervisorFormUI.Tbl_HR_SupervisorId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_SupervisorFormDAL : DeleteHR_Supervisor] An error occured in the processing of Record Id : " + hR_SupervisorFormUI.Tbl_HR_SupervisorId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }


}