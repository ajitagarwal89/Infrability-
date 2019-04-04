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
/// Summary description for DownPaymentFromCustomerDistributionListDAL
/// </summary>
public class DownPaymentFromCustomerDistributionListDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    Audit_IUD audit_IUD = new Audit_IUD();

    public DownPaymentFromCustomerDistributionListDAL()
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
            logExcpUIobj.MethodName = "DownPaymentFromCustomerDistributionListDAL()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            throw new Exception("[DownPaymentFromCustomerDistributionListDAL : DownPaymentFromCustomerDistributionListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetDownPaymentFromCustomerDistributionListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerDistribution_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomerDistributionListForExportToExcel()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerDistributionListDAL : GetDownPaymentFromCustomerDistributionListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

    public DataTable GetDownPaymentFromCustomerDistributionList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerDistribution_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomerDistributionList()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerDistributionListDAL : GetDownPaymentFromCustomerDistributionList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetDownPaymentFromCustomerDistributionListById(DownPaymentFromCustomerDistributionListUI downPaymentFromCustomerDistributionListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerDistributionId"].Value = downPaymentFromCustomerDistributionListUI.Tbl_DownPaymentFromCustomerDistributionId;

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
                audit_IUD.WebServiceSelectInsert("tbl_DownPaymentFromCustomerDistribution", downPaymentFromCustomerDistributionListUI.Tbl_DownPaymentFromCustomerDistributionId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomerDistributionListById()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerDistributionListDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerDistributionListUI.Tbl_DownPaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerDistributionListDAL : GetDownPaymentFromCustomerDistributionListById] An error occured in the processing of Record Id : " + downPaymentFromCustomerDistributionListUI.Tbl_DownPaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetDownPaymentFromCustomerDistributionListBySearchParameters(DownPaymentFromCustomerDistributionListUI downPaymentFromCustomerDistributionListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerDistribution_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = downPaymentFromCustomerDistributionListUI.Search;

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
                audit_IUD.WebServiceSelectInsert("tbl_DownPaymentFromCustomerDistribution", downPaymentFromCustomerDistributionListUI.Tbl_DownPaymentFromCustomerDistributionId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomerDistributionListBySearchParameters()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerDistributionListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + downPaymentFromCustomerDistributionListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerDistributionListDAL : GetDownPaymentFromCustomerDistributionListBySearchParameters] An error occured in the processing of Record Search = " + downPaymentFromCustomerDistributionListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }
    public int DeleteDownPaymentFromCustomerDistribution(DownPaymentFromCustomerDistributionListUI downPaymentFromCustomerDistributionListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerDistributionId"].Value = downPaymentFromCustomerDistributionListUI.Tbl_DownPaymentFromCustomerDistributionId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_DownPaymentFromCustomerDistribution", downPaymentFromCustomerDistributionListUI.Tbl_DownPaymentFromCustomerDistributionId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteDownPaymentFromCustomerDistribution()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerDistributionListDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerDistributionListUI.Tbl_DownPaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerDistributionListDAL : DeleteDownPaymentFromCustomerDistribution] An error occured in the processing of Record Id : " + downPaymentFromCustomerDistributionListUI.Tbl_DownPaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}