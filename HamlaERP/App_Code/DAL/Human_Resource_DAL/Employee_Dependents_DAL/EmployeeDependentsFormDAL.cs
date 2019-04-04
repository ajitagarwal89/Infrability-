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
/// Summary description for EmployeeDependentsFormDAL
/// </summary>
public class EmployeeDependentsFormDAL : IRequiresSessionState
{

    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
   protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public EmployeeDependentsFormDAL()
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
            logExcpUIobj.MethodName = "EmployeeDependentsFormDAL()";
            logExcpUIobj.ResourceName = "EmployeeDependentsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[EmployeeDependentsFormDAL : EmployeeDependentsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetEmployeeDependentsListById(EmployeeDependentsFormUI employeeDependentsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeDependents_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeDependentsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeDependentsId"].Value = employeeDependentsFormUI.Tbl_EmployeeDependentsId;

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
                audit_IUD.WebServiceSelectInsert("tbl_EmployeeDependents", employeeDependentsFormUI.Tbl_EmployeeDependentsId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetEmployeeDependentsListById()";
            logExcpUIobj.ResourceName = "EmployeeDependentsFormDAL.CS";
            logExcpUIobj.RecordId = employeeDependentsFormUI.Tbl_EmployeeDependentsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeDependentsFormDAL : GetEmployeeDependentsListById] An error occured in the processing of Record Id : " + employeeDependentsFormUI.Tbl_EmployeeDependentsId+ ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddEmployeeDependents(EmployeeDependentsFormUI employeeDependentsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeDependents_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = employeeDependentsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeDependentsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = employeeDependentsFormUI.Tbl_EmployeeId;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = employeeDependentsFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@tbl_HR_DepartmentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DepartmentId"].Value = employeeDependentsFormUI.Tbl_HR_DepartmentId;

                sqlCmd.Parameters.Add("@Opt_Relationship", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Relationship"].Value = employeeDependentsFormUI.Opt_Relationship;

                sqlCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FirstName"].Value = employeeDependentsFormUI.FirstName;


                sqlCmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@MiddleName"].Value = employeeDependentsFormUI.MiddleName;

                sqlCmd.Parameters.Add("@LastName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@LastName"].Value = employeeDependentsFormUI.LastName;

                sqlCmd.Parameters.Add("@DOB", SqlDbType.DateTime);
                sqlCmd.Parameters["@DOB"].Value = employeeDependentsFormUI.DOB;

                sqlCmd.Parameters.Add("@Gender", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Gender"].Value = employeeDependentsFormUI.Gender;

                sqlCmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@HomePhone"].Value = employeeDependentsFormUI.HomePhone;

                sqlCmd.Parameters.Add("@WorkPhone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@WorkPhone"].Value = employeeDependentsFormUI.WorkPhone;

                sqlCmd.Parameters.Add("@Ext", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Ext"].Value = employeeDependentsFormUI.Ext;

                sqlCmd.Parameters.Add("@Address1", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address1"].Value = employeeDependentsFormUI.Address1;

                sqlCmd.Parameters.Add("@Address2", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address2"].Value = employeeDependentsFormUI.Address2;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = employeeDependentsFormUI.City;

                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = employeeDependentsFormUI.State;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = employeeDependentsFormUI.ZipCode;

                sqlCmd.Parameters.Add("@tbl_EmployeeDependentsId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_EmployeeDependentsId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recoredID = Convert.ToString(sqlCmd.Parameters["@tbl_EmployeeDependentsId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_EmployeeDependents";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(employeeDependentsFormUI);
                    audit_IUD.WebServiceInsert(employeeDependentsFormUI.Tbl_OrganizationId, tableName, recoredID, employeeDependentsFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddEmployeeDependents()";
            logExcpUIobj.ResourceName = "EmployeeDependentsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeDependentsFormDAL : AddEmployeeDependents] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateEmployeeDependents(EmployeeDependentsFormUI employeeDependentsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeDependents_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeDependentsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeDependentsId"].Value = employeeDependentsFormUI.Tbl_EmployeeDependentsId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = employeeDependentsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeDependentsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = employeeDependentsFormUI.Tbl_EmployeeId;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = employeeDependentsFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@tbl_HR_DepartmentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DepartmentId"].Value = employeeDependentsFormUI.Tbl_HR_DepartmentId;

                sqlCmd.Parameters.Add("@Opt_Relationship", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Relationship"].Value = employeeDependentsFormUI.Opt_Relationship;

                sqlCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FirstName"].Value = employeeDependentsFormUI.FirstName;

                sqlCmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@MiddleName"].Value = employeeDependentsFormUI.MiddleName;

                sqlCmd.Parameters.Add("@LastName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@LastName"].Value = employeeDependentsFormUI.LastName;

                sqlCmd.Parameters.Add("@DOB", SqlDbType.DateTime);
                sqlCmd.Parameters["@DOB"].Value = employeeDependentsFormUI.DOB;

                sqlCmd.Parameters.Add("@Gender", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Gender"].Value = employeeDependentsFormUI.Gender;

                sqlCmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@HomePhone"].Value = employeeDependentsFormUI.HomePhone;

                sqlCmd.Parameters.Add("@WorkPhone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@WorkPhone"].Value = employeeDependentsFormUI.WorkPhone;

                sqlCmd.Parameters.Add("@Ext", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Ext"].Value = employeeDependentsFormUI.Ext;

                sqlCmd.Parameters.Add("@Address1", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address1"].Value = employeeDependentsFormUI.Address1;

                sqlCmd.Parameters.Add("@Address2", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address2"].Value = employeeDependentsFormUI.Address2;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = employeeDependentsFormUI.City;

                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = employeeDependentsFormUI.State;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = employeeDependentsFormUI.ZipCode;
                                
                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(employeeDependentsFormUI);
                    audit_IUD.WebServiceUpdate(employeeDependentsFormUI.Tbl_OrganizationId, "tbl_EmployeeDependents", employeeDependentsFormUI.Tbl_EmployeeDependentsId, employeeDependentsFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateEmployeeDependents()";
            logExcpUIobj.ResourceName = "EmployeeDependentsFormDAL.CS";
            logExcpUIobj.RecordId = employeeDependentsFormUI.Tbl_EmployeeDependentsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeDependentsFormDAL : UpdateEmployeeDependents] An error occured in the processing of Record Id : " + employeeDependentsFormUI.Tbl_EmployeeDependentsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteEmployeeDependents(EmployeeDependentsFormUI employeeDependentsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeDependents_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeDependentsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeDependentsId"].Value = employeeDependentsFormUI.Tbl_EmployeeDependentsId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_EmployeeDependents", employeeDependentsFormUI.Tbl_EmployeeDependentsId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteEmployeeDependents()";
            logExcpUIobj.ResourceName = "EmployeeDependentsFormDAL.CS";
            logExcpUIobj.RecordId = employeeDependentsFormUI.Tbl_EmployeeDependentsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeDependentsFormDAL : DeleteEmployeeDependents] An error occured in the processing of Record Id : " + employeeDependentsFormUI.Tbl_EmployeeDependentsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}