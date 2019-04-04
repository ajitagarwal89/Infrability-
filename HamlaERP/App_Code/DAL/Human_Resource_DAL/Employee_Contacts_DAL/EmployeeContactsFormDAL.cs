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
/// Summary description for EmployeeContactsFormDAL
/// </summary>
public class EmployeeContactsFormDAL : IRequiresSessionState
{

    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public EmployeeContactsFormDAL()
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
            logExcpUIobj.MethodName = "EmployeeContactsFormDAL()";
            logExcpUIobj.ResourceName = "EmployeeContactsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[EmployeeContactsFormDAL : EmployeeContactsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetEmployeeContactsListById(EmployeeContactsFormUI employeeContactsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeContacts_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeContactsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeContactsId"].Value = employeeContactsFormUI.Tbl_EmployeeContactsId;

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
                audit_IUD.WebServiceSelectInsert("tbl_EmployeeContacts", employeeContactsFormUI.Tbl_EmployeeContactsId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getEmployeeContactsListById()";
            logExcpUIobj.ResourceName = "EmployeeContactsFormDAL.CS";
            logExcpUIobj.RecordId = employeeContactsFormUI.Tbl_EmployeeContactsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeContactsFormDAL : getEmployeeContactsListById] An error occured in the processing of Record Id : " + employeeContactsFormUI.Tbl_EmployeeContactsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddEmployeeContacts(EmployeeContactsFormUI employeeContactsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeContacts_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = employeeContactsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeContactsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = employeeContactsFormUI.Tbl_EmployeeId;

                sqlCmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Contact"].Value = employeeContactsFormUI.Contact;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = employeeContactsFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@Relationship", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Relationship"].Value = employeeContactsFormUI.Relationship;

                sqlCmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@HomePhone"].Value = employeeContactsFormUI.HomePhone;

                sqlCmd.Parameters.Add("@WorkPhone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@WorkPhone"].Value = employeeContactsFormUI.WorkPhone;

                sqlCmd.Parameters.Add("@Ext", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Ext"].Value = employeeContactsFormUI.Ext;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = employeeContactsFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = employeeContactsFormUI.City;

                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = employeeContactsFormUI.State;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = employeeContactsFormUI.ZipCode;

                sqlCmd.Parameters.Add("@tbl_EmployeeContactsId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_EmployeeContactsId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recoredID = Convert.ToString(sqlCmd.Parameters["@tbl_EmployeeContactsId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_EmployeeContacts";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(employeeContactsFormUI);
                    audit_IUD.WebServiceInsert(employeeContactsFormUI.Tbl_OrganizationId, tableName, recoredID, employeeContactsFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddEmployeeContacts()";
            logExcpUIobj.ResourceName = "EmployeeContactsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeContactsFormDAL : AddEmployeeContacts] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateEmployeeContacts(EmployeeContactsFormUI employeeContactsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeContacts_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = employeeContactsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeContactsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_EmployeeContactsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeContactsId"].Value = employeeContactsFormUI.Tbl_EmployeeContactsId;

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = employeeContactsFormUI.Tbl_EmployeeId;

                sqlCmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Contact"].Value = employeeContactsFormUI.Contact;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = employeeContactsFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@Relationship", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Relationship"].Value = employeeContactsFormUI.Relationship;

                sqlCmd.Parameters.Add("@HomePhone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@HomePhone"].Value = employeeContactsFormUI.HomePhone;

                sqlCmd.Parameters.Add("@WorkPhone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@WorkPhone"].Value = employeeContactsFormUI.WorkPhone;

                sqlCmd.Parameters.Add("@Ext", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Ext"].Value = employeeContactsFormUI.Ext;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = employeeContactsFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = employeeContactsFormUI.City;

                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = employeeContactsFormUI.State;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = employeeContactsFormUI.ZipCode;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(employeeContactsFormUI);
                    audit_IUD.WebServiceUpdate(employeeContactsFormUI.Tbl_OrganizationId, "tbl_EmployeeContacts", employeeContactsFormUI.Tbl_EmployeeContactsId, employeeContactsFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateEmployeeContacts()";
            logExcpUIobj.ResourceName = "EmployeeContactsFormDAL.CS";
            logExcpUIobj.RecordId = employeeContactsFormUI.Tbl_EmployeeContactsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeContactsFormDAL : UpdateEmployeeContacts] An error occured in the processing of Record Id : " + employeeContactsFormUI.Tbl_EmployeeContactsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteEmployeeContacts(EmployeeContactsFormUI employeeContactsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeContacts_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeContactsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeContactsId"].Value = employeeContactsFormUI.Tbl_EmployeeContactsId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_EmployeeContacts", employeeContactsFormUI.Tbl_EmployeeContactsId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteEmployeeContacts()";
            logExcpUIobj.ResourceName = "EmployeeContactsFormDAL.CS";
            logExcpUIobj.RecordId = employeeContactsFormUI.Tbl_EmployeeContactsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeContactsFormDAL : DeleteEmployeeContacts] An error occured in the processing of Record Id : " + employeeContactsFormUI.Tbl_EmployeeContactsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}