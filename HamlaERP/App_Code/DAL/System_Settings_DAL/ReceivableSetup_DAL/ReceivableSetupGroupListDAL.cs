using System;
using System.Data.SqlClient;
using System.Data;
using log4net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Services;
using System.Web.SessionState;
using System.Web;
using Finware;
/// <summary>
/// Summary description for ReceivableSetupGroupListDAL
/// </summary>
public class ReceivableSetupGroupListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public ReceivableSetupGroupListDAL()
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
            logExcpUIobj.MethodName = "ReceivableSetupGroupListDAL()";
            logExcpUIobj.ResourceName = "ReceivableSetupGroupListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[ReceivableSetupGroupListDAL : ReceivableSetupGroupListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }


    public DataTable GetReceivableSetupGroupList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupGroup_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetReceivableSetupGroupList()";
            logExcpUIobj.ResourceName = "ReceivableSetupGroupListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupGroupListDAL : GetReceivableSetupGroupList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetReceivableSetupGroupListById(ReceivableSetupGroupListUI receivableSetupGroupListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupGroup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupGroupId"].Value = receivableSetupGroupListUI.Tbl_ReceivableSetupGroupId;

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
                audit_IUD.WebServiceSelectInsert("tbl_ReceivableSetupGroup", receivableSetupGroupListUI.Tbl_ReceivableSetupGroupId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetRecievableSetupGroupListById()";
            logExcpUIobj.ResourceName = "ReceivableSetupGroupListDAL.CS";
            logExcpUIobj.RecordId = receivableSetupGroupListUI.Tbl_ReceivableSetupGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupGroupListDAL : GetReceivableSetupGroupListById] An error occured in the processing of Record Id : " + receivableSetupGroupListUI.Tbl_ReceivableSetupGroupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int DeleteReceivableSetupGroup(ReceivableSetupGroupListUI receivableSetupGroupListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupGroup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupGroupId"].Value = receivableSetupGroupListUI.Tbl_ReceivableSetupGroupId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_ReceivableSetupGroup", receivableSetupGroupListUI.Tbl_ReceivableSetupGroupId);
                }

            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteRecievableSetupGroup()";
            logExcpUIobj.ResourceName = "ReceivableSetupGroupListDAL.CS";
            logExcpUIobj.RecordId = receivableSetupGroupListUI.Tbl_ReceivableSetupGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupGroupListDAL : DeleteRecievableSetupGroup] An error occured in the processing of Record Id : " + receivableSetupGroupListUI.Tbl_ReceivableSetupGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }


    public DataTable GetReceivableSetupGroupListBySearchParameters(ReceivableSetupGroupListUI receivableSetupGroupListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {

                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupGroup_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = receivableSetupGroupListUI.Search;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl = ds.Tables[0];
            string record = dtbl.Rows[0]["tbl_ReceivableSetupGroupId"].ToString();
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_RecievableSetupGroup", receivableSetupGroupListUI.Tbl_ReceivableSetupGroupId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetRecievableSetupGroupListBySearchParameters()";
            logExcpUIobj.ResourceName = "ReceivableSetupGroupListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + receivableSetupGroupListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupGroupListDAL : GetRecievableSetupGroupListBySearchParameters] An error occured in the processing of Record Search = " + receivableSetupGroupListUI.Search + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetReceivableSetupGroupListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupGroup_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetRecievableSetupGroupListForExportToExcel()";
            logExcpUIobj.ResourceName = "ReceivableSetupGroupListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[ReceivableSetupGroupListDAL : GetRecievableSetupGroupListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }
}