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
/// Summary description for HR_BranchFormDAL
/// </summary>
public class HR_BranchFormDAL : IRequiresSessionState
{

    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
   protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public HR_BranchFormDAL()
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
            logExcpUIobj.MethodName = "HR_BranchFormDAL()";
            logExcpUIobj.ResourceName = "HR_BranchFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[HR_BranchFormDAL : HR_BranchFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetHR_BranchListById(HR_BranchFormUI hR_BranchFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Branch_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_BranchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_BranchId"].Value = hR_BranchFormUI.Tbl_HR_BranchId;

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
                audit_IUD.WebServiceSelectInsert("tbl_HR_Branch", hR_BranchFormUI.Tbl_HR_BranchId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getHR_BranchListById()";
            logExcpUIobj.ResourceName = "HR_BranchFormDAL.CS";
            logExcpUIobj.RecordId = hR_BranchFormUI.Tbl_HR_BranchId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_BranchFormDAL : getHR_BranchListById] An error occured in the processing of Record Id : " + hR_BranchFormUI.Tbl_HR_BranchId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddHR_Branch(HR_BranchFormUI hR_BranchFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Branch_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = hR_BranchFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = hR_BranchFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@BranchCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BranchCode"].Value = hR_BranchFormUI.BranchCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = hR_BranchFormUI.Description;

                sqlCmd.Parameters.Add("@opt_DepreciatedPeriod", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_DepreciatedPeriod"].Value = hR_BranchFormUI.opt_DepreciatedPeriod;

                sqlCmd.Parameters.Add("@opt_CurrentyFiscalYear", SqlDbType.Int);
                sqlCmd.Parameters["@opt_CurrentyFiscalYear"].Value = hR_BranchFormUI.opt_CurrentyFiscalYear;

                sqlCmd.Parameters.Add("@tbl_HR_BranchId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_HR_BranchId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recoredID = Convert.ToString(sqlCmd.Parameters["@tbl_HR_BranchId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_HR_Branch";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(hR_BranchFormUI);
                    audit_IUD.WebServiceInsert(hR_BranchFormUI.Tbl_OrganizationId, tableName, recoredID, hR_BranchFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddHR_Branch()";
            logExcpUIobj.ResourceName = "HR_BranchFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_BranchFormDAL : AddHR_Branch] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateHR_Branch(HR_BranchFormUI hR_BranchFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Branch_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = hR_BranchFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = hR_BranchFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_HR_BranchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_BranchId"].Value = hR_BranchFormUI.Tbl_HR_BranchId;

                sqlCmd.Parameters.Add("@BranchCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BranchCode"].Value = hR_BranchFormUI.BranchCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = hR_BranchFormUI.Description;

                sqlCmd.Parameters.Add("@opt_DepreciatedPeriod", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_DepreciatedPeriod"].Value = hR_BranchFormUI.opt_DepreciatedPeriod;

                sqlCmd.Parameters.Add("@opt_CurrentyFiscalYear", SqlDbType.Int);
                sqlCmd.Parameters["@opt_CurrentyFiscalYear"].Value = hR_BranchFormUI.opt_CurrentyFiscalYear;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(hR_BranchFormUI);
                    audit_IUD.WebServiceUpdate(hR_BranchFormUI.Tbl_OrganizationId, "tbl_HR_Branch", hR_BranchFormUI.Tbl_HR_BranchId, hR_BranchFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateHR_Branch()";
            logExcpUIobj.ResourceName = "HR_BranchFormDAL.CS";
            logExcpUIobj.RecordId = hR_BranchFormUI.Tbl_HR_BranchId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_BranchFormDAL : UpdateHR_Branch] An error occured in the processing of Record Id : " + hR_BranchFormUI.Tbl_HR_BranchId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteHR_Branch(HR_BranchFormUI hR_BranchFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Branch_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_BranchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_BranchId"].Value = hR_BranchFormUI.Tbl_HR_BranchId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_HR_Branch", hR_BranchFormUI.Tbl_HR_BranchId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteHR_Branch()";
            logExcpUIobj.ResourceName = "HR_BranchFormDAL.CS";
            logExcpUIobj.RecordId = hR_BranchFormUI.Tbl_HR_BranchId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_BranchFormDAL : DeleteHR_Branch] An error occured in the processing of Record Id : " + hR_BranchFormUI.Tbl_HR_BranchId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}