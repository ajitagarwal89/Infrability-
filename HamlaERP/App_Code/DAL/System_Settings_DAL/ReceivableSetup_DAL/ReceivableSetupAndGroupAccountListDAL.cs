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
/// Summary description for ReceivableSetupAndGroupAccountListDAL
/// </summary>
public class ReceivableSetupAndGroupAccountListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public ReceivableSetupAndGroupAccountListDAL()
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
            logExcpUIobj.MethodName = "ReceivableSetupAndGroupAccountListDAL()";
            logExcpUIobj.ResourceName = "ReceivableSetupAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[ReceivableSetupAndGroupAccountListDAL : ReceivableSetupAndGroupAccountListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetReceivableSetupAndGroupAccountList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupAndGroupAccount_Select",
                    SupportCon);
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
            logExcpUIobj.MethodName = "GetReceivableSetupAndGroupAccountList()";
            logExcpUIobj.ResourceName = "ReceivableSetupAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupAndGroupAccountListDAL : GetReceivableSetupAndGroupAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetReceivableSetupAndGroupAccountListForExportToExcel()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupAndGroupAccount_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetReceivableSetupAndGroupAccountListForExportToExcel()";
            logExcpUIobj.ResourceName = "ReceivableSetupAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupAndGroupAccountListDAL : GetReceivableSetupAndGroupAccountListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetReceivableSetupAndGroupAccountListById(ReceivableSetupAndGroupAccountListUI receivableSetupAndGroupAccountListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupAndGroupAccount_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupAndGroupAccountId"].Value = receivableSetupAndGroupAccountListUI.Tbl_ReceivableSetupAndGroupAccountId;

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
                audit_IUD.WebServiceSelectInsert("tbl_ReceivableSetupAndGroupAccount", receivableSetupAndGroupAccountListUI.Tbl_ReceivableSetupAndGroupAccountId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetReceivableSetupAndGroupAccountListById()";
            logExcpUIobj.ResourceName = "ReceivableSetupAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = receivableSetupAndGroupAccountListUI.Tbl_ReceivableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupAndGroupAccountListDAL : GetReceivableSetupAndGroupAccountListById] An error occured in the processing of Record Id : " + receivableSetupAndGroupAccountListUI.Tbl_ReceivableSetupAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int DeleteReceivableSetupAndGroupAccount(ReceivableSetupAndGroupAccountListUI receivableSetupAndGroupAccountListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupAndGroupAccount_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupAndGroupAccountId"].Value = receivableSetupAndGroupAccountListUI.Tbl_ReceivableSetupAndGroupAccountId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_ReceivableSetupAndGroupAccount", receivableSetupAndGroupAccountListUI.Tbl_ReceivableSetupAndGroupAccountId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteReceivableSetupAndGroupAccount()";
            logExcpUIobj.ResourceName = "ReceivableSetupAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = receivableSetupAndGroupAccountListUI.Tbl_ReceivableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupAndGroupAccountListDAL : DeleteReceivableSetupAndGroupAccount] An error occured in the processing of Record Id : " + receivableSetupAndGroupAccountListUI.Tbl_ReceivableSetupAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }



    public DataTable GetReceivableSetupAndGroupAccountListBySearchParameters(ReceivableSetupAndGroupAccountListUI receivableSetupAndGroupAccountListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupAndGroupAccount_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = receivableSetupAndGroupAccountListUI.Search;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl = ds.Tables[0];
            string recordId = dtbl.Rows[0]["tbl_ReceivableSetupAndGroupAccountId"].ToString();
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_ReceivableSetupAndGroupAccount", recordId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetReceivableSetupAndGroupAccountListBySearchParameters()";
            logExcpUIobj.ResourceName = "ReceivableSetupAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + receivableSetupAndGroupAccountListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupAndGroupAccountListDAL : GetReceivableSetupAndGroupAccountListBySearchParameters] An error occured in the processing of Record Search = " + receivableSetupAndGroupAccountListUI.Search + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
}