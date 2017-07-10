using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;
/// <summary>
/// Summary description for DownPaymentFromCustomerApplyListDAL
/// </summary>
public class DownPaymentFromCustomerApplyListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public DownPaymentFromCustomerApplyListDAL()
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
            logExcpUIobj.MethodName = "DownPaymentFromCustomerApplyListDAL()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            throw new Exception("[DownPaymentFromCustomerApplyListDAL : DownPaymentFromCustomerApplyListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetDownPaymentFromCustomerApplyListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerApply_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomerApplyListForExportToExcel()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerApplyListDAL : GetDownPaymentFromCustomerApplyListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

    public DataTable GetDownPaymentFromCustomerApplyList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerApply_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomerApplyList()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerApplyListDAL : GetDownPaymentFromCustomerApplyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetDownPaymentFromCustomerApplyListById(DownPaymentFromCustomerApplyListUI downPaymentFromCustomerApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerApply_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerApplyId"].Value = downPaymentFromCustomerApplyListUI.Tbl_DownPaymentFromCustomerApplyId;

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
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomerApplyListById()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerApplyListDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerApplyListUI.Tbl_DownPaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerApplyListDAL : GetDownPaymentFromCustomerApplyListById] An error occured in the processing of Record Id : " + downPaymentFromCustomerApplyListUI.Tbl_DownPaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetDownPaymentFromCustomerApplyListBySearchParameters(DownPaymentFromCustomerApplyListUI downPaymentFromCustomerApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerApply_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = downPaymentFromCustomerApplyListUI.Search;

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
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomerApplyListBySearchParameters()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerApplyListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + downPaymentFromCustomerApplyListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerApplyListDAL : GetDownPaymentFromCustomerApplyListBySearchParameters] An error occured in the processing of Record Search = " + downPaymentFromCustomerApplyListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }


    public DataTable GetDownPaymentFromCustomerApplyListByDownPaymentFromCustomerId(DownPaymentFromCustomerApplyListUI downPaymentFromCustomerApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerApply_SelectByDownPaymentFromCustomerId", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerId"].Value = downPaymentFromCustomerApplyListUI.Tbl_DownPaymentFromCustomerId;

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
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomerApplyListByDownPaymentFromCustomerId()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerApplyListUI.Tbl_DownPaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerFormDAL : GetDownPaymentFromCustomerApply_SelectByDownPaymentFromCustomerId] An error occured in the processing of Record Id : " + downPaymentFromCustomerApplyListUI.Tbl_DownPaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }

        return dtbl;
    }

    public int DeleteDownPaymentFromCustomerApply(DownPaymentFromCustomerApplyListUI downPaymentFromCustomerApplyListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerApply_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerApplyId"].Value = downPaymentFromCustomerApplyListUI.Tbl_DownPaymentFromCustomerApplyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteDownPaymentFromCustomerApply()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerApplyListDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerApplyListUI.Tbl_DownPaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerApplyListDAL : DeleteDownPaymentFromCustomerApply] An error occured in the processing of Record Id : " + downPaymentFromCustomerApplyListUI.Tbl_DownPaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }


}