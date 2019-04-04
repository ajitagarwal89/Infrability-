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
/// Summary description for EmployeeFormDAL
/// </summary>
public class EmployeeFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
 
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public EmployeeFormDAL()
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
            logExcpUIobj.MethodName = "EmployeeFormDAL()";
            logExcpUIobj.ResourceName = "EmployeeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[EmployeeFormDAL : EmployeeFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetEmployeeListById(EmployeeFormUI employeeFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Employee_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = employeeFormUI.Tbl_EmployeeId;

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
                audit_IUD.WebServiceSelectInsert("tbl_Employee", employeeFormUI.Tbl_EmployeeId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getEmployeeListById()";
            logExcpUIobj.ResourceName = "EmployeeFormDAL.CS";
            logExcpUIobj.RecordId = employeeFormUI.Tbl_EmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeFormDAL : getEmployeeListById] An error occured in the processing of Record Id : " + employeeFormUI.Tbl_EmployeeId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddEmployee(EmployeeFormUI employeeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Employee_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = employeeFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@EmployeeCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@EmployeeCode"].Value = employeeFormUI.EmployeeCode;

                sqlCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FirstName"].Value = employeeFormUI.FirstName;

                sqlCmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@MiddleName"].Value = employeeFormUI.MiddleName;

                sqlCmd.Parameters.Add("@LastName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@LastName"].Value = employeeFormUI.LastName;

                sqlCmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Contact"].Value = employeeFormUI.Contact;

                sqlCmd.Parameters.Add("@Opt_EmployeeNationalType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_EmployeeNationalType"].Value = employeeFormUI.Opt_EmployeeNationalType;

                sqlCmd.Parameters.Add("@IqamaBathaqaNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@IqamaBathaqaNumber"].Value = employeeFormUI.IqamaBathaqaNumber;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = employeeFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = employeeFormUI.City;


                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = employeeFormUI.State;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = employeeFormUI.ZipCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = employeeFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Phone"].Value = employeeFormUI.Phone;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = employeeFormUI.Mobile;

                sqlCmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FaxNo"].Value = employeeFormUI.FaxNo;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = employeeFormUI.Email;

                sqlCmd.Parameters.Add("@tbl_HR_DivisionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DivisionId"].Value = employeeFormUI.Tbl_HR_DivisionId;

                sqlCmd.Parameters.Add("@tbl_HR_DepartmentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DepartmentId"].Value = employeeFormUI.Tbl_HR_DepartmentId;

                sqlCmd.Parameters.Add("@tbl_HR_PositionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_PositionId"].Value = employeeFormUI.Tbl_HR_PositionId;

                sqlCmd.Parameters.Add("@tbl_HR_BranchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_BranchId"].Value = employeeFormUI.Tbl_HR_BranchId;

                sqlCmd.Parameters.Add("@tbl_HR_SupervisorId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_SupervisorId"].Value = employeeFormUI.Tbl_HR_SupervisorId;

                sqlCmd.Parameters.Add("@SeniorityDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@SeniorityDate"].Value = employeeFormUI.@SeniorityDate;

                sqlCmd.Parameters.Add("@HireDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@HireDate"].Value = employeeFormUI.HireDate;
               
                sqlCmd.Parameters.Add("@AdjustedHireDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@AdjustedHireDate"].Value = employeeFormUI.AdjustedHireDate;

                sqlCmd.Parameters.Add("@LastWorkingDay", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastWorkingDay"].Value = employeeFormUI.LastWorkingDay;

                sqlCmd.Parameters.Add("@InactivatedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InactivatedDate"].Value = employeeFormUI.InactivatedDate;

                sqlCmd.Parameters.Add("@Reason", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Reason"].Value = employeeFormUI.Reason;

                sqlCmd.Parameters.Add("@tbl_Country_Nationality", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Country_Nationality"].Value = employeeFormUI.Tbl_Country_Nationality;

                sqlCmd.Parameters.Add("@HRStatus", SqlDbType.TinyInt);
                sqlCmd.Parameters["@HRStatus"].Value = employeeFormUI.HRStatus;

                sqlCmd.Parameters.Add("@opt_EmploymentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_EmploymentType"].Value = employeeFormUI.opt_EmploymentType;

                sqlCmd.Parameters.Add("@DOB", SqlDbType.DateTime);
                sqlCmd.Parameters["@DOB"].Value = employeeFormUI.DOB;

                sqlCmd.Parameters.Add("@Gender", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Gender"].Value = employeeFormUI.Gender;

                sqlCmd.Parameters.Add("@MaritalStatus", SqlDbType.TinyInt);
                sqlCmd.Parameters["@MaritalStatus"].Value = employeeFormUI.MaritalStatus;

                sqlCmd.Parameters.Add("@WorkHoursPerYear", SqlDbType.Int);
                sqlCmd.Parameters["@WorkHoursPerYear"].Value = employeeFormUI.WorkHoursPerYear;

                sqlCmd.Parameters.Add("@PassportNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PassportNumber"].Value = employeeFormUI.PassportNumber;

                sqlCmd.Parameters.Add("@PassportExp", SqlDbType.DateTime);
                sqlCmd.Parameters["@PassportExp"].Value = employeeFormUI.PassportExp;

                sqlCmd.Parameters.Add("@IqamaBathaqaExp", SqlDbType.DateTime);
                sqlCmd.Parameters["@IqamaBathaqaExp"].Value = employeeFormUI.IqamaBathaqaExp;


                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_EmployeeId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recoredID = Convert.ToString(sqlCmd.Parameters["@tbl_EmployeeId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_Employee";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(employeeFormUI);
                    audit_IUD.WebServiceInsert(employeeFormUI.Tbl_OrganizationId, tableName, recoredID, employeeFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddEmployee()";
            logExcpUIobj.ResourceName = "EmployeeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeFormDAL : AddEmployee] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateEmployee(EmployeeFormUI employeeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Employee_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = employeeFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = employeeFormUI.Tbl_EmployeeId;

                sqlCmd.Parameters.Add("@EmployeeCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@EmployeeCode"].Value = employeeFormUI.EmployeeCode;

                sqlCmd.Parameters.Add("@FirstName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FirstName"].Value = employeeFormUI.FirstName;

                sqlCmd.Parameters.Add("@MiddleName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@MiddleName"].Value = employeeFormUI.MiddleName;

                sqlCmd.Parameters.Add("@LastName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@LastName"].Value = employeeFormUI.LastName;

                sqlCmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Contact"].Value = employeeFormUI.Contact;

                sqlCmd.Parameters.Add("@Opt_EmployeeNationalType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_EmployeeNationalType"].Value = employeeFormUI.Opt_EmployeeNationalType;

                sqlCmd.Parameters.Add("@IqamaBathaqaNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@IqamaBathaqaNumber"].Value = employeeFormUI.IqamaBathaqaNumber;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = employeeFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = employeeFormUI.City;

                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = employeeFormUI.State;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = employeeFormUI.ZipCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = employeeFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Phone"].Value = employeeFormUI.Phone;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = employeeFormUI.Mobile;

                sqlCmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FaxNo"].Value = employeeFormUI.FaxNo;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = employeeFormUI.Email;

                sqlCmd.Parameters.Add("@tbl_HR_DivisionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DivisionId"].Value = employeeFormUI.Tbl_HR_DivisionId;

                sqlCmd.Parameters.Add("@tbl_HR_DepartmentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DepartmentId"].Value = employeeFormUI.Tbl_HR_DepartmentId;

                sqlCmd.Parameters.Add("@tbl_HR_PositionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_PositionId"].Value = employeeFormUI.Tbl_HR_PositionId;

                sqlCmd.Parameters.Add("@tbl_HR_BranchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_BranchId"].Value = employeeFormUI.Tbl_HR_BranchId;

                sqlCmd.Parameters.Add("@tbl_HR_SupervisorId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_SupervisorId"].Value = employeeFormUI.Tbl_HR_SupervisorId;

                sqlCmd.Parameters.Add("@SeniorityDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@SeniorityDate"].Value = employeeFormUI.@SeniorityDate;

                sqlCmd.Parameters.Add("@HireDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@HireDate"].Value = employeeFormUI.HireDate;

                sqlCmd.Parameters.Add("@AdjustedHireDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@AdjustedHireDate"].Value = employeeFormUI.AdjustedHireDate;

                sqlCmd.Parameters.Add("@LastWorkingDay", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastWorkingDay"].Value = employeeFormUI.LastWorkingDay;

                sqlCmd.Parameters.Add("@InactivatedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InactivatedDate"].Value = employeeFormUI.InactivatedDate;

                sqlCmd.Parameters.Add("@Reason", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Reason"].Value = employeeFormUI.Reason;

                sqlCmd.Parameters.Add("@tbl_Country_Nationality", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Country_Nationality"].Value = employeeFormUI.Tbl_Country_Nationality;

                sqlCmd.Parameters.Add("@HRStatus", SqlDbType.TinyInt);
                sqlCmd.Parameters["@HRStatus"].Value = employeeFormUI.HRStatus;

                sqlCmd.Parameters.Add("@opt_EmploymentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_EmploymentType"].Value = employeeFormUI.opt_EmploymentType;

                sqlCmd.Parameters.Add("@DOB", SqlDbType.DateTime);
                sqlCmd.Parameters["@DOB"].Value = employeeFormUI.DOB;

                sqlCmd.Parameters.Add("@Gender", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Gender"].Value = employeeFormUI.Gender;

                sqlCmd.Parameters.Add("@MaritalStatus", SqlDbType.TinyInt);
                sqlCmd.Parameters["@MaritalStatus"].Value = employeeFormUI.MaritalStatus;

                sqlCmd.Parameters.Add("@WorkHoursPerYear", SqlDbType.Int);
                sqlCmd.Parameters["@WorkHoursPerYear"].Value = employeeFormUI.WorkHoursPerYear;

                sqlCmd.Parameters.Add("@PassportNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PassportNumber"].Value = employeeFormUI.PassportNumber;

                sqlCmd.Parameters.Add("@PassportExp", SqlDbType.DateTime);
                sqlCmd.Parameters["@PassportExp"].Value = employeeFormUI.PassportExp;

                sqlCmd.Parameters.Add("@IqamaBathaqaExp", SqlDbType.DateTime);
                sqlCmd.Parameters["@IqamaBathaqaExp"].Value = employeeFormUI.IqamaBathaqaExp;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(employeeFormUI);
                    audit_IUD.WebServiceUpdate(employeeFormUI.Tbl_OrganizationId, "tbl_Employee", employeeFormUI.Tbl_EmployeeId, employeeFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateEmployee()";
            logExcpUIobj.ResourceName = "EmployeeFormDAL.CS";
            logExcpUIobj.RecordId = employeeFormUI.Tbl_EmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeFormDAL : UpdateEmployee] An error occured in the processing of Record Id : " + employeeFormUI.Tbl_EmployeeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteEmployee(EmployeeFormUI employeeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Employee_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = employeeFormUI.Tbl_EmployeeId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_Employee", employeeFormUI.Tbl_EmployeeId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteEmployee()";
            logExcpUIobj.ResourceName = "EmployeeFormDAL.CS";
            logExcpUIobj.RecordId = employeeFormUI.Tbl_EmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeFormDAL : DeleteEmployee] An error occured in the processing of Record Id : " + employeeFormUI.Tbl_EmployeeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetSerialNumber(EmployeeFormUI employeeFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Employee_SerialNumber", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@RecordType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@RecordType"].Value = employeeFormUI.InvoiceType;

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
                audit_IUD.WebServiceSelectInsert("tbl_Employee", employeeFormUI.Tbl_EmployeeId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSerialNumber()";
            logExcpUIobj.ResourceName = "EmployeeFormDAL.CS";
            logExcpUIobj.RecordId = employeeFormUI.Tbl_EmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeFormDAL : GetSerialNumber] An error occured in the processing of Record Id : " + employeeFormUI.Tbl_EmployeeId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
}