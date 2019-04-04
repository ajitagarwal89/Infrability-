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
/// Summary description for SupplierEmployeeGeneralExpensesListDAL
/// </summary>
public class SupplierEmployeeGeneralExpensesListDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    Audit_IUD audit_IUD = new Audit_IUD();

    public SupplierEmployeeGeneralExpensesListDAL()
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
            logExcpUIobj.MethodName = "SupplierEmployeeGeneralExpensesListDAL()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGeneralExpensesListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[SupplierEmployeeGeneralExpensesListDAL : SupplierEmployeeGeneralExpensesListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetSupplierEmployeeGeneralExpensesList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGeneralExpenses_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetSupplierEmployeeGeneralExpensesList()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGeneralExpensesListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeGeneralExpensesListDAL : GetSupplierEmployeeGeneralExpensesList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetSupplierEmployeeGeneralExpensesListById(SupplierEmployeeGeneralExpensesListUI supplierEmployeeGeneralExpensesListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGeneralExpenses_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGeneralExpensesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGeneralExpensesId"].Value = supplierEmployeeGeneralExpensesListUI.Tbl_SupplierEmployeeGeneralExpensesId;

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
                audit_IUD.WebServiceSelectInsert("tbl_SupplierEmployeeGeneralExpenses", supplierEmployeeGeneralExpensesListUI.Tbl_SupplierEmployeeGeneralExpensesId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSupplierEmployeeGeneralExpensesListById()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGeneralExpensesListDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeGeneralExpensesListUI.Tbl_SupplierEmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeGeneralExpensesListDAL : GetSupplierEmployeeGeneralExpensesListById] An error occured in the processing of Record Id : " + supplierEmployeeGeneralExpensesListUI.Tbl_SupplierEmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetSupplierEmployeeGeneralExpensesListBySearchParameters(SupplierEmployeeGeneralExpensesListUI supplierEmployeeGeneralExpensesListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGeneralExpenses_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = supplierEmployeeGeneralExpensesListUI.Search;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl = ds.Tables[0];
            string recordId = dtbl.Rows[0]["tbl_SupplierEmployeeGeneralExpensesId"].ToString();
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_SupplierEmployeeGeneralExpenses", supplierEmployeeGeneralExpensesListUI.Tbl_SupplierEmployeeGeneralExpensesId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSupplierEmployeeGeneralExpensesListBySearchParameters()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGeneralExpensesListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + supplierEmployeeGeneralExpensesListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeGeneralExpensesListDAL : GetSupplierEmployeeGeneralExpensesListBySearchParameters] An error occured in the processing of Record Search = " + supplierEmployeeGeneralExpensesListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int DeleteSupplierEmployeeGeneralExpenses(SupplierEmployeeGeneralExpensesListUI supplierEmployeeGeneralExpensesListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGeneralExpenses_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGeneralExpensesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGeneralExpensesId"].Value = supplierEmployeeGeneralExpensesListUI.Tbl_SupplierEmployeeGeneralExpensesId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_SupplierEmployeeGeneralExpenses", supplierEmployeeGeneralExpensesListUI.Tbl_SupplierEmployeeGeneralExpensesId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "SupplierEmployeeGeneralExpensesListDAL()";
            logExcpUIobj.ResourceName = "EmployeeGeneralExpensesListDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeGeneralExpensesListUI.Tbl_SupplierEmployeeGeneralExpensesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeGeneralExpensesListDAL : SupplierEmployeeGeneralExpensesListDAL] An error occured in the processing of Record Id : " + supplierEmployeeGeneralExpensesListUI.Tbl_SupplierEmployeeGeneralExpensesId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetSupplierEmployeeGeneralExpensesForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeGeneralExpenses_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetSupplierEmployeeGeneralExpensesForExportToExcel()";
            logExcpUIobj.ResourceName = "SupplierEmployeeGeneralExpensesListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[SupplierEmployeeGeneralExpensesListDAL : GetSupplierEmployeeGeneralExpensesForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

}