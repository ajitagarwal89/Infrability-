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
/// Summary description for EmployeeEducationFormDAL
/// </summary>
public class EmployeeEducationFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public EmployeeEducationFormDAL()
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
            logExcpUIobj.MethodName = "EmployeeEducationFormDAL()";
            logExcpUIobj.ResourceName = "EmployeeEducationFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[EmployeeEducationFormDAL : EmployeeEducationFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetEmployeeEducationListById(EmployeeEducationFormUI employeeEducationFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeEducation_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeEducationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeEducationId"].Value = employeeEducationFormUI.Tbl_EmployeeEducationId;

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
                audit_IUD.WebServiceSelectInsert("tbl_EmployeeEducation", employeeEducationFormUI.Tbl_EmployeeEducationId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetEmployeeEducationListById()";
            logExcpUIobj.ResourceName = "EmployeeDependentsFormDAL.CS";
            logExcpUIobj.RecordId = employeeEducationFormUI.Tbl_EmployeeEducationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeDependentsFormDAL : GetEmployeeEducationListById] An error occured in the processing of Record Id : " + employeeEducationFormUI.Tbl_EmployeeEducationId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddEmployeeEducation(EmployeeEducationFormUI employeeEducationFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeEducation_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = employeeEducationFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeEducationFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = employeeEducationFormUI.Tbl_EmployeeId;

                sqlCmd.Parameters.Add("@School", SqlDbType.NVarChar);
                sqlCmd.Parameters["@School"].Value = employeeEducationFormUI.School;

                sqlCmd.Parameters.Add("@Major", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Major"].Value = employeeEducationFormUI.Major;

                sqlCmd.Parameters.Add("@Year", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Year"].Value = employeeEducationFormUI.Year;

                sqlCmd.Parameters.Add("@Degree", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Degree"].Value = employeeEducationFormUI.Degree;

                sqlCmd.Parameters.Add("@GPA", SqlDbType.Decimal);
                sqlCmd.Parameters["@GPA"].Value = employeeEducationFormUI.GPA;

                sqlCmd.Parameters.Add("@Note", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Note"].Value = employeeEducationFormUI.Note;

                sqlCmd.Parameters.Add("@tbl_EmployeeEducationId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_EmployeeEducationId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recoredID = Convert.ToString(sqlCmd.Parameters["@tbl_EmployeeEducationId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_EmployeeEducation";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(employeeEducationFormUI);
                    audit_IUD.WebServiceInsert(employeeEducationFormUI.Tbl_OrganizationId, tableName, recoredID, employeeEducationFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddEmployeeEducation()";
            logExcpUIobj.ResourceName = "EmployeeEducationFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeEducationFormDAL : AddEmployeeEducation] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateEmployeeEducation(EmployeeEducationFormUI employeeEducationFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeEducation_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeEducationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeEducationId"].Value = employeeEducationFormUI.Tbl_EmployeeEducationId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = employeeEducationFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeEducationFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = employeeEducationFormUI.Tbl_EmployeeId;

                sqlCmd.Parameters.Add("@School", SqlDbType.NVarChar);
                sqlCmd.Parameters["@School"].Value = employeeEducationFormUI.School;

                sqlCmd.Parameters.Add("@Major", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Major"].Value = employeeEducationFormUI.Major;

                sqlCmd.Parameters.Add("@Year", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Year"].Value = employeeEducationFormUI.Year;

                sqlCmd.Parameters.Add("@Degree", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Degree"].Value = employeeEducationFormUI.Degree;

                sqlCmd.Parameters.Add("@GPA", SqlDbType.Decimal);
                sqlCmd.Parameters["@GPA"].Value = employeeEducationFormUI.GPA;

                sqlCmd.Parameters.Add("@Note", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Note"].Value = employeeEducationFormUI.Note;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(employeeEducationFormUI);
                    audit_IUD.WebServiceUpdate(employeeEducationFormUI.Tbl_OrganizationId, "tbl_EmployeeEducation", employeeEducationFormUI.Tbl_EmployeeEducationId, employeeEducationFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateEmployeeDependents()";
            logExcpUIobj.ResourceName = "EmployeeDependentsFormDAL.CS";
            logExcpUIobj.RecordId = employeeEducationFormUI.Tbl_EmployeeEducationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeDependentsFormDAL : UpdateEmployeeDependents] An error occured in the processing of Record Id : " + employeeEducationFormUI.Tbl_EmployeeEducationId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteEmployeeEducation(EmployeeEducationFormUI employeeEducationFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeEducation_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeEducationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeEducationId"].Value =employeeEducationFormUI.Tbl_EmployeeEducationId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_EmployeeEducation", employeeEducationFormUI.Tbl_EmployeeEducationId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteEmployeeEducation()";
            logExcpUIobj.ResourceName = "EmployeeEducationFormDAL.CS";
            logExcpUIobj.RecordId = employeeEducationFormUI.Tbl_EmployeeEducationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeEducationFormDAL : DeleteEmployeeEducation] An error occured in the processing of Record Id : " + employeeEducationFormUI.Tbl_EmployeeEducationId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}