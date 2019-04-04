using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using log4net;

public class Audit_SettingFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public Audit_SettingFormDAL()
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
            logExcpUIobj.MethodName = "Audit_SettingFormDAL()";
            logExcpUIobj.ResourceName = "Audit_SettingFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[Audit_SettingFormDAL : Audit_SettingFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAudit_SettingListById(Audit_SettingFormUI audit_SettingFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Audit_Setting_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_Audit_SettingId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Audit_SettingId"].Value = audit_SettingFormUI.Tbl_Audit_SettingId;

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
            logExcpUIobj.MethodName = "GetAudit_SettingListById()";
            logExcpUIobj.ResourceName = "Audit_SettingFormDAL.CS";
            logExcpUIobj.RecordId = audit_SettingFormUI.Tbl_Audit_SettingId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PODetailsFormDAL : getPODetailsListById] An error occured in the processing of Record Id : " + audit_SettingFormUI.Tbl_Audit_SettingId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddAudit_Setting(Audit_SettingFormUI audit_SettingFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Audit_Setting_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = audit_SettingFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = audit_SettingFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@ObjectName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ObjectName"].Value = audit_SettingFormUI.ObjectName;

                sqlCmd.Parameters.Add("@EnableAudit", SqlDbType.Bit);
                sqlCmd.Parameters["@EnableAudit"].Value = audit_SettingFormUI.EnableAudit;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddAudit_Setting()";
            logExcpUIobj.ResourceName = "Audit_SettingFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Audit_SettingFormDAL : AddAudit_Setting] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAudit_Setting(Audit_SettingFormUI audit_SettingFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Audit_Setting_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_Audit_SettingId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Audit_SettingId"].Value = audit_SettingFormUI.Tbl_Audit_SettingId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = audit_SettingFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = audit_SettingFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@ObjectName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ObjectName"].Value = audit_SettingFormUI.ObjectName;

                sqlCmd.Parameters.Add("@EnableAudit", SqlDbType.Bit);
                sqlCmd.Parameters["@EnableAudit"].Value = audit_SettingFormUI.EnableAudit;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAudit_Setting()";
            logExcpUIobj.ResourceName = "PODetailsFormDAL.CS";
            logExcpUIobj.RecordId = audit_SettingFormUI.Tbl_Audit_SettingId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PODetailsFormDAL : UpdateAudit_Setting] An error occured in the processing of Record Id : " + audit_SettingFormUI.Tbl_Audit_SettingId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetSystemTables()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SystemTables_Select", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

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
            logExcpUIobj.MethodName = "GetSystemTables()";
            logExcpUIobj.ResourceName = "Audit_SettingListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Audit_SettingListDAL : GetSystemTables] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
}