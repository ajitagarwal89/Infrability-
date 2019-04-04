using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Web.Services;
using System.Web.SessionState;
using Finware;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for PayableSetupGroupAccountListDAL
/// </summary>
public class PayableSetupAndGroupAccountListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    Audit_IUD audit_IUD = new Audit_IUD();
    public PayableSetupAndGroupAccountListDAL()

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
            logExcpUIobj.MethodName = "PayableSetupAndGroupAccountListDAL()";
            logExcpUIobj.ResourceName = "PayableSetupAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PayableSetupAndGroupAccountListDAL : PayableSetupAndGroupAccountListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPayableSetupAndGroupAccount_List()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupAndGroupAccount_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetPayableSetupAndGroupAccount_List()";
            logExcpUIobj.ResourceName = "PayableSetupAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupAndGroupAccountListDAL : GetPayableSetupAndGroupAccount_List] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetPayableSetupAndGroupAccountListById(PayableSetupAndGroupAccountListUI payableSetupAndGroupAccountListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupAndGroupAccount_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PayableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupAndGroupAccountId"].Value = payableSetupAndGroupAccountListUI.tbl_PayableSetupAndGroupAccountId;

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
                audit_IUD.WebServiceSelectInsert("tbl_PayableSetupAndGroupAccount", payableSetupAndGroupAccountListUI.tbl_PayableSetupAndGroupAccountId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPayableSetupAndGroupAccountListById()";
            logExcpUIobj.ResourceName = "PayableSetupAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = payableSetupAndGroupAccountListUI.tbl_PayableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupAndGroupAccountListDAL : GetPayableSetupAndGroupAccountListById] An error occured in the processing of Record Id : " + payableSetupAndGroupAccountListUI.tbl_PayableSetupAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetPayableSetupAndGroupAccountListBySearchParameters(PayableSetupAndGroupAccountListUI payableSetupAndGroupAccountListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupAndGroupAccount_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = payableSetupAndGroupAccountListUI.Search;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl = ds.Tables[0];
            string recordId = dtbl.Rows[0]["tbl_PayableSetupAndGroupAccount"].ToString();
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_PayableSetupAndGroupAccount", recordId, selectedValue);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPayableSetupAndGroupAccountListBySearchParameters()";
            logExcpUIobj.ResourceName = "PayableSetupAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + payableSetupAndGroupAccountListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupAndGroupAccountListDAL : GetPayableSetupAndGroupAccountListBySearchParameters] An error occured in the processing of Record Search = " + payableSetupAndGroupAccountListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int DeletePayableSetupAndGroupAccount(PayableSetupAndGroupAccountListUI payableSetupAndGroupAccountListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupAndGroupAccount_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PayableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupAndGroupAccountId"].Value = payableSetupAndGroupAccountListUI.tbl_PayableSetupAndGroupAccountId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_PayableSetupAndGroupAccount", payableSetupAndGroupAccountListUI.tbl_PayableSetupAndGroupAccountId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePayableSetupAndGroupAccount()";
            logExcpUIobj.ResourceName = "PayableSetupAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = payableSetupAndGroupAccountListUI.tbl_PayableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupAndGroupAccountListDAL : DeletePayableSetupAndGroupAccount] An error occured in the processing of Record Id : " + payableSetupAndGroupAccountListUI.tbl_PayableSetupAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public DataTable GetPayableSetupAndGroupAccountListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupAndGroupAccount_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetPayableSetupAndGroupAccountListForExportToExcel()";
            logExcpUIobj.ResourceName = "PayableSetupAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PayableSetupAndGroupAccountListDAL : GetPayableSetupAndGroupAccountListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }
}