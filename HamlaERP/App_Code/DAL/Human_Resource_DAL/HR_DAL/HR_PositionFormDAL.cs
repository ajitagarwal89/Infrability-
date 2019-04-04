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
/// Summary description for HR_PositionFormDAL
/// </summary>
public class HR_PositionFormDAL : IRequiresSessionState
{

    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public HR_PositionFormDAL()
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
            logExcpUIobj.MethodName = "HR_PositionFormDAL()";
            logExcpUIobj.ResourceName = "HR_PositionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[HR_PositionFormDAL : HR_PositionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetHR_PositionListById(HR_PositionFormUI hR_PositionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Position_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_PositionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_PositionId"].Value = hR_PositionFormUI.Tbl_HR_PositionId;

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
                audit_IUD.WebServiceSelectInsert("tbl_HR_Position", hR_PositionFormUI.Tbl_HR_PositionId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getHR_PositionListById()";
            logExcpUIobj.ResourceName = "HR_PositionFormDAL.CS";
            logExcpUIobj.RecordId = hR_PositionFormUI.Tbl_HR_PositionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_PositionFormDAL : getHR_PositionListById] An error occured in the processing of Record Id : " + hR_PositionFormUI.Tbl_HR_PositionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddHR_Position(HR_PositionFormUI hR_PositionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Position_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = hR_PositionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = hR_PositionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@PositionCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PositionCode"].Value = hR_PositionFormUI.PositionCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = hR_PositionFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_HR_PositionId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_PositionId_Self"].Value = hR_PositionFormUI.Tbl_HR_PositionId_Self;

                sqlCmd.Parameters.Add("@tbl_PayCodes", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayCodes"].Value = hR_PositionFormUI.Tbl_PayCodes;

                sqlCmd.Parameters.Add("@tbl_HR_PositionId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_HR_PositionId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_HR_PositionId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_HR_Position";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(hR_PositionFormUI);
                    audit_IUD.WebServiceInsert(hR_PositionFormUI.Tbl_OrganizationId, tableName, recordID, hR_PositionFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddHR_Position()";
            logExcpUIobj.ResourceName = "HR_PositionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_PositionFormDAL : AddHR_Position] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateHR_Position(HR_PositionFormUI hR_PositionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Position_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = hR_PositionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = hR_PositionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_HR_PositionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_PositionId"].Value = hR_PositionFormUI.Tbl_HR_PositionId;

                sqlCmd.Parameters.Add("@PositionCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PositionCode"].Value = hR_PositionFormUI.PositionCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = hR_PositionFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_HR_PositionId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_PositionId_Self"].Value = hR_PositionFormUI.Tbl_HR_PositionId_Self;

                sqlCmd.Parameters.Add("@tbl_PayCodes", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayCodes"].Value = hR_PositionFormUI.Tbl_PayCodes;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(hR_PositionFormUI);
                    audit_IUD.WebServiceUpdate(hR_PositionFormUI.Tbl_OrganizationId, "tbl_HR_Position", hR_PositionFormUI.Tbl_HR_PositionId, hR_PositionFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateHR_Position()";
            logExcpUIobj.ResourceName = "HR_PositionFormDAL.CS";
            logExcpUIobj.RecordId = hR_PositionFormUI.Tbl_HR_PositionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_PositionFormDAL : UpdateHR_Position] An error occured in the processing of Record Id : " + hR_PositionFormUI.Tbl_HR_PositionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteHR_Position(HR_PositionFormUI hR_PositionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Position_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_PositionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_PositionId"].Value = hR_PositionFormUI.Tbl_HR_PositionId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_HR_Position", hR_PositionFormUI.Tbl_HR_PositionId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteHR_Position()";
            logExcpUIobj.ResourceName = "HR_PositionFormDAL.CS";
            logExcpUIobj.RecordId = hR_PositionFormUI.Tbl_HR_PositionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_PositionFormDAL : DeleteHR_Position] An error occured in the processing of Record Id : " + hR_PositionFormUI.Tbl_HR_PositionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}