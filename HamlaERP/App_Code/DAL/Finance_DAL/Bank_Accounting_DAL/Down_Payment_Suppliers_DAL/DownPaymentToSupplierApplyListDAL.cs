using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for DownPaymentToSupplierApplyListDAL
/// </summary>
public class DownPaymentToSupplierApplyListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public DownPaymentToSupplierApplyListDAL()
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
            logExcpUIobj.MethodName = "DownPaymentToSupplierApplyListDAL()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            throw new Exception("[DownPaymentToSupplierApplyListDAL : DownPaymentToSupplierApplyListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetDownPaymentToSupplierApplyListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierApply_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetDownPaymentToSupplierApplyListForExportToExcel()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentToSupplierApplyListDAL : GetDownPaymentToSupplierApplyListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

    public DataTable GetDownPaymentToSupplierApplyList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierApply_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetDownPaymentToSupplierApplyList()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentToSupplierApplyListDAL : GetDownPaymentToSupplierApplyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetDownPaymentToSupplierApplyListById(DownPaymentToSupplierApplyListUI downPaymentToSupplierApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierApply_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierApplyId"].Value = downPaymentToSupplierApplyListUI.Tbl_DownPaymentToSupplierApplyId;

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
            logExcpUIobj.MethodName = "GetDownPaymentToSupplierApplyListById()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierApplyListDAL.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierApplyListUI.Tbl_DownPaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentToSupplierApplyListDAL : GetDownPaymentToSupplierApplyListById] An error occured in the processing of Record Id : " + downPaymentToSupplierApplyListUI.Tbl_DownPaymentToSupplierApplyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetDownPaymentToSupplierApplyListBySearchParameters(DownPaymentToSupplierApplyListUI downPaymentToSupplierApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierApply_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = downPaymentToSupplierApplyListUI.Search;

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
            logExcpUIobj.MethodName = "GetDownPaymentToSupplierApplyListBySearchParameters()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierApplyListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + downPaymentToSupplierApplyListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentToSupplierApplyListDAL : GetDownPaymentToSupplierApplyListBySearchParameters] An error occured in the processing of Record Search = " + downPaymentToSupplierApplyListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }

    public DataTable GetDownPaymentToSupplierApplyListByDownPaymentToSupplierId(DownPaymentToSupplierApplyListUI downPaymentToSupplierApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierApply_SelectByDownPaymentToSupplierId", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierId"].Value = downPaymentToSupplierApplyListUI.Tbl_DownPaymentToSupplierId;

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
            logExcpUIobj.MethodName = "GetDownPaymentToSupplierApplyListByDownPaymentToSupplierId()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierApplyListUI.Tbl_DownPaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentToSupplierFormDAL : GetDownPaymentToSupplierApply_SelectByDownPaymentToSupplierId] An error occured in the processing of Record Id : " + downPaymentToSupplierApplyListUI.Tbl_DownPaymentToSupplierId + ". Details : [" + exp.ToString() + "]");
        }

        return dtbl;
    }
    public int DeleteDownPaymentToSupplierApply(DownPaymentToSupplierApplyListUI downPaymentToSupplierApplyListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierApply_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierApplyId"].Value = downPaymentToSupplierApplyListUI.Tbl_DownPaymentToSupplierApplyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteDownPaymentToSupplierApply()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierApplyListDAL.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierApplyListUI.Tbl_DownPaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentToSupplierApplyListDAL : DeleteDownPaymentToSupplierApply] An error occured in the processing of Record Id : " + downPaymentToSupplierApplyListUI.Tbl_DownPaymentToSupplierApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}