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
/// Summary description for HRDivisionFormDAL
/// </summary>
public class HRDivisionFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
     protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public HRDivisionFormDAL()
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
            logExcpUIobj.MethodName = "HRDivisionFormDAL()";
            logExcpUIobj.ResourceName = "HRDivisionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[HRDivisionFormDAL : HRDivisionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetHRDivisionListById(HRDivisionFormUI hRDivisionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Division_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_DivisionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DivisionId"].Value = hRDivisionFormUI.Tbl_HRDivisionId;

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
                audit_IUD.WebServiceSelectInsert("tbl_HR_Division", hRDivisionFormUI.Tbl_HRDivisionId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getHRDivisionListById()";
            logExcpUIobj.ResourceName = "HRDivisionFormDAL.CS";
            logExcpUIobj.RecordId = hRDivisionFormUI.Tbl_HRDivisionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HRDivisionFormDAL : getHRDivisionListById] An error occured in the processing of Record Id : " + hRDivisionFormUI.Tbl_HRDivisionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddHRDivision(HRDivisionFormUI hRDivisionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Division_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = hRDivisionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = hRDivisionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@DivisionCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DivisionCode"].Value = hRDivisionFormUI.DivisionCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = hRDivisionFormUI.Description;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = hRDivisionFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = hRDivisionFormUI.City;

                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = hRDivisionFormUI.State;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = hRDivisionFormUI.ZipCode;

                sqlCmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Phone"].Value = hRDivisionFormUI.Phone;

                sqlCmd.Parameters.Add("@Extension", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Extension"].Value = hRDivisionFormUI.Extension;

                sqlCmd.Parameters.Add("@Fax", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Fax"].Value = hRDivisionFormUI.Fax;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = hRDivisionFormUI.Email;

                sqlCmd.Parameters.Add("@tbl_HR_DivisionId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_HR_DivisionId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_HR_DivisionId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_HR_Division";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(hRDivisionFormUI);
                    audit_IUD.WebServiceInsert(hRDivisionFormUI.Tbl_OrganizationId, tableName, recordID, hRDivisionFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddHRDivision()";
            logExcpUIobj.ResourceName = "HRDivisionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HRDivisionFormDAL : AddHRDivision] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateHRDivision(HRDivisionFormUI hRDivisionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Division_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_DivisionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DivisionId"].Value = hRDivisionFormUI.Tbl_HRDivisionId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = hRDivisionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = hRDivisionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@DivisionCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DivisionCode"].Value = hRDivisionFormUI.DivisionCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = hRDivisionFormUI.Description;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = hRDivisionFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = hRDivisionFormUI.City;

                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = hRDivisionFormUI.State;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = hRDivisionFormUI.ZipCode;

                sqlCmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Phone"].Value = hRDivisionFormUI.Phone;

                sqlCmd.Parameters.Add("@Extension", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Extension"].Value = hRDivisionFormUI.Extension;

                sqlCmd.Parameters.Add("@Fax", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Fax"].Value = hRDivisionFormUI.Fax;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = hRDivisionFormUI.Email;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(hRDivisionFormUI);
                    audit_IUD.WebServiceUpdate(hRDivisionFormUI.Tbl_OrganizationId, "tbl_HR_Division", hRDivisionFormUI.Tbl_HRDivisionId, hRDivisionFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateHRDivision()";
            logExcpUIobj.ResourceName = "HRDivisionFormDAL.CS";
            logExcpUIobj.RecordId = hRDivisionFormUI.Tbl_HRDivisionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HRDivisionFormDAL : UpdateHRDivision] An error occured in the processing of Record Id : " + hRDivisionFormUI.Tbl_HRDivisionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteHRDivision(HRDivisionFormUI hRDivisionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Division_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_DivisionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_DivisionId"].Value = hRDivisionFormUI.Tbl_HRDivisionId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_HR_Division", hRDivisionFormUI.Tbl_HRDivisionId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteHRDivision()";
            logExcpUIobj.ResourceName = "HRDivisionFormDAL.CS";
            logExcpUIobj.RecordId = hRDivisionFormUI.Tbl_HRDivisionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HRDivisionFormDAL : DeleteHRDivision] An error occured in the processing of Record Id : " + hRDivisionFormUI.Tbl_HRDivisionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}