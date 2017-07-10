using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for EmployeeFormDAL
/// </summary>
public class EmployeeFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
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

                sqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Name"].Value = employeeFormUI.Name;

                sqlCmd.Parameters.Add("@ShortName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ShortName"].Value = employeeFormUI.ShortName;

                sqlCmd.Parameters.Add("@ChequeName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ChequeName"].Value = employeeFormUI.ChequeName;

                sqlCmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Contact"].Value = employeeFormUI.Contact;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = employeeFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = employeeFormUI.City;

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

                sqlCmd.Parameters.Add("@Comment1", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment1"].Value = employeeFormUI.Comment1;

                sqlCmd.Parameters.Add("@Comment2", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment2"].Value = employeeFormUI.Comment2;

                sqlCmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Status"].Value = employeeFormUI.Opt_Status;

                sqlCmd.Parameters.Add("@tbl_EmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeGroupId"].Value = employeeFormUI.Tbl_EmployeeGroupId;

                sqlCmd.Parameters.Add("@OnHold", SqlDbType.Bit);
                sqlCmd.Parameters["@OnHold"].Value = employeeFormUI.OnHold;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
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

                sqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Name"].Value = employeeFormUI.Name;

                sqlCmd.Parameters.Add("@ShortName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ShortName"].Value = employeeFormUI.ShortName;

                sqlCmd.Parameters.Add("@ChequeName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ChequeName"].Value = employeeFormUI.ChequeName;

                sqlCmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Contact"].Value = employeeFormUI.Contact;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = employeeFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = employeeFormUI.City;

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

                sqlCmd.Parameters.Add("@Comment1", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment1"].Value = employeeFormUI.Comment1;

                sqlCmd.Parameters.Add("@Comment2", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment2"].Value = employeeFormUI.Comment2;

                sqlCmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Status"].Value = employeeFormUI.Opt_Status;

                sqlCmd.Parameters.Add("@tbl_EmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeGroupId"].Value = employeeFormUI.Tbl_EmployeeGroupId;

                sqlCmd.Parameters.Add("@OnHold", SqlDbType.Bit);
                sqlCmd.Parameters["@OnHold"].Value = employeeFormUI.OnHold;

                result = sqlCmd.ExecuteNonQuery();

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
}