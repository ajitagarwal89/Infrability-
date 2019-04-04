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
/// Summary description for SupplierEmployeeAndGroupAccountListDAL
/// </summary>
public class SupplierEmployeeAndGroupAccountListDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    Audit_IUD audit_IUD = new Audit_IUD();

    public SupplierEmployeeAndGroupAccountListDAL()
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
            logExcpUIobj.MethodName = "SupplierEmployeeAndGroupAccountListDAL()";
            logExcpUIobj.ResourceName = "SupplierEmployeeAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[SupplierEmployeeAndGroupAccountListDAL : SupplierEmployeeAndGroupAccountListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetSupplierEmployeeAndGroupAccountList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeAndGroupAccount_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetSupplierEmployeeAndGroupAccountList()";
            logExcpUIobj.ResourceName = "SupplierEmployeeAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeAndGroupAccountListDAL : GetSupplierEmployeeAndGroupAccountList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetSupplierEmployeeAndGroupAccountListById(SupplierEmployeeAndGroupAccountListUI supplierEmployeeAndGroupAccountListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeAndGroupAccount_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeAndGroupAccountId"].Value = supplierEmployeeAndGroupAccountListUI.Tbl_SupplierEmployeeAndGroupAccountId;

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
                audit_IUD.WebServiceSelectInsert("tbl_SupplierEmployeeAndGroupAccount", supplierEmployeeAndGroupAccountListUI.Tbl_SupplierEmployeeAndGroupAccountId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSupplierEmployeeAndGroupAccountListById()";
            logExcpUIobj.ResourceName = "SupplierEmployeeAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeAndGroupAccountListUI.Tbl_SupplierEmployeeAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeAndGroupAccountListDAL : GetSupplierEmployeeAndGroupAccountListById] An error occured in the processing of Record Id : " + supplierEmployeeAndGroupAccountListUI.Tbl_SupplierEmployeeAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetSupplierEmployeeAndGroupAccountListBySearchParameters(SupplierEmployeeAndGroupAccountListUI supplierEmployeeAndGroupAccountListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeAndGroupAccount_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = supplierEmployeeAndGroupAccountListUI.Search;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl = ds.Tables[0];
            string recordId = dtbl.Rows[0]["tbl_SupplierEmployeeAndGroupAccountId"].ToString();
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_SupplierEmployeeAndGroupAccount", recordId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSupplierEmployeeAndGroupAccountListBySearchParameters()";
            logExcpUIobj.ResourceName = "SupplierEmployeeAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + supplierEmployeeAndGroupAccountListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeAndGroupAccountListDAL : GetSupplierEmployeeAndGroupAccountListBySearchParameters] An error occured in the processing of Record Search = " + supplierEmployeeAndGroupAccountListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int DeleteSupplierEmployeeAndGroupAccount(SupplierEmployeeAndGroupAccountListUI supplierEmployeeAndGroupAccountListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeAndGroupAccount_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeAndGroupAccountId"].Value = supplierEmployeeAndGroupAccountListUI.Tbl_SupplierEmployeeAndGroupAccountId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_SupplierEmployeeAndGroupAccount", supplierEmployeeAndGroupAccountListUI.Tbl_SupplierEmployeeAndGroupAccountId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSupplierEmployeeAndGroupAccount()";
            logExcpUIobj.ResourceName = "SupplierEmployeeAndGroupAccountListDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeAndGroupAccountListUI.Tbl_SupplierEmployeeAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeAndGroupAccountListDAL : DeleteSupplierEmployeeAndGroupAccount] An error occured in the processing of Record Id : " + supplierEmployeeAndGroupAccountListUI.Tbl_SupplierEmployeeAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}