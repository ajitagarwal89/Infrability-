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
/// Summary description for HRDepartmentForm
/// </summary>
public class HRDepartmentFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
     protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public HRDepartmentFormDAL()
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
            logExcpUIobj.MethodName = "HRDepartmentFormDAL()";
            logExcpUIobj.ResourceName = "HRDepartmentFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[HRDepartmentFormDAL : HRDepartmentFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetHRDepartmentListById(HRDepartmentFormUI hRDepartmentFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Department_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_DepartmentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DepartmentId"].Value = hRDepartmentFormUI.Tbl_HR_DepartmentId;

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
                audit_IUD.WebServiceSelectInsert("tbl_HR_Department", hRDepartmentFormUI.Tbl_HR_DepartmentId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetHRDepartmentListById()";
            logExcpUIobj.ResourceName = "HRDivisionFormDAL.CS";
            logExcpUIobj.RecordId = hRDepartmentFormUI.Tbl_HR_DepartmentId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HRDivisionFormDAL : GetHRDepartmentListById] An error occured in the processing of Record Id : " + hRDepartmentFormUI.Tbl_HR_DepartmentId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddHRDepartment(HRDepartmentFormUI hRDepartmentFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Department_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = hRDepartmentFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = hRDepartmentFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_HR_DivisionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DivisionId"].Value = hRDepartmentFormUI.Tbl_HRDivisionId;

                sqlCmd.Parameters.Add("@DepartmentCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DepartmentCode"].Value = hRDepartmentFormUI.DepartmentCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = hRDepartmentFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_HR_DepartmentId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_HR_DepartmentId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_HR_DepartmentId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_HR_Department";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(hRDepartmentFormUI);
                    audit_IUD.WebServiceInsert(hRDepartmentFormUI.Tbl_OrganizationId, tableName, recordID, hRDepartmentFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddHRDepartment()";
            logExcpUIobj.ResourceName = "HRDivisionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HRDivisionFormDAL : AddHRDepartment] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateHRDepartment(HRDepartmentFormUI hRDepartmentFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Department_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_DepartmentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DepartmentId"].Value = hRDepartmentFormUI.Tbl_HR_DepartmentId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = hRDepartmentFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = hRDepartmentFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_HR_DivisionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DivisionId"].Value = hRDepartmentFormUI.Tbl_HRDivisionId;

                sqlCmd.Parameters.Add("@DepartmentCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DepartmentCode"].Value = hRDepartmentFormUI.DepartmentCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = hRDepartmentFormUI.Description;


                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(hRDepartmentFormUI);
                    audit_IUD.WebServiceUpdate(hRDepartmentFormUI.Tbl_OrganizationId, "tbl_HR_Department", hRDepartmentFormUI.Tbl_HR_DepartmentId, hRDepartmentFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateHRDepartment()";
            logExcpUIobj.ResourceName = "HRDivisionFormDAL.CS";
            logExcpUIobj.RecordId = hRDepartmentFormUI.Tbl_HR_DepartmentId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HRDivisionFormDAL : UpdateHRDepartment] An error occured in the processing of Record Id : " + hRDepartmentFormUI.Tbl_HR_DepartmentId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteHRDepartment(HRDepartmentFormUI hRDepartmentFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Department_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_DepartmentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DepartmentId"].Value = hRDepartmentFormUI.Tbl_HR_DepartmentId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_HR_Department", hRDepartmentFormUI.Tbl_HR_DepartmentId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteHRDepartment()";
            logExcpUIobj.ResourceName = "HRDepartmentFormDAL.CS";
            logExcpUIobj.RecordId = hRDepartmentFormUI.Tbl_HR_DepartmentId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HRDepartmentFormDAL : DeleteHRDepartment] An error occured in the processing of Record Id : " + hRDepartmentFormUI.Tbl_HR_DepartmentId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}