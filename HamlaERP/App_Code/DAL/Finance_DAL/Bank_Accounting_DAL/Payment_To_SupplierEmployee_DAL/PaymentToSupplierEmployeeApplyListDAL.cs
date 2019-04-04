using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;
/// <summary>
/// Summary description for PaymentToSupplierEmployeeApplyListDAL
/// </summary>
public class PaymentToSupplierEmployeeApplyListDAL
{

    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PaymentToSupplierEmployeeApplyListDAL()
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
            logExcpUIobj.MethodName = "PaymentToSupplierEmployeeApplyListDAL()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            throw new Exception("[PaymentToSupplierEmployeeApplyListDAL : PaymentToSupplierEmployeeApplyListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentToSupplierEmployeeApplyListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeApply_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetPaymentToSupplierEmployeeApplyListForExportToExcel()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeApplyListDAL : GetPaymentToSupplierEmployeeApplyListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

    public DataTable GetPaymentToSupplierEmployeeApplyList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeApply_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetPaymentToSupplierEmployeeApplyList()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeApplyListDAL : GetPaymentToSupplierEmployeeApplyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetPaymentToSupplierEmployeeApplyListById(PaymentToSupplierEmployeeApplyListUI paymentToSupplierEmployeeApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeApply_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeApplyId"].Value = paymentToSupplierEmployeeApplyListUI.Tbl_PaymentToSupplierEmployeeApplyId;

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
            logExcpUIobj.MethodName = "GetPaymentToSupplierEmployeeApplyListById()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeApplyListUI.Tbl_PaymentToSupplierEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeApplyListDAL : GetPaymentToSupplierEmployeeApplyListById] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeApplyListUI.Tbl_PaymentToSupplierEmployeeApplyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetPaymentToSupplierEmployeeApplyListBySearchParameters(PaymentToSupplierEmployeeApplyListUI paymentToSupplierEmployeeApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeApply_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = paymentToSupplierEmployeeApplyListUI.Search;

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
            logExcpUIobj.MethodName = "GetPaymentToSupplierEmployeeApplyListBySearchParameters()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + paymentToSupplierEmployeeApplyListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeApplyListDAL : GetPaymentToSupplierEmployeeApplyListBySearchParameters] An error occured in the processing of Record Search = " + paymentToSupplierEmployeeApplyListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }

    public DataTable GetPaymentToSupplierEmployeeApplyListByPaymentToEmployeeId(PaymentToSupplierEmployeeApplyListUI paymentToSupplierEmployeeApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeApply_SelectByPaymentToEmployeeId", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeId"].Value = paymentToSupplierEmployeeApplyListUI.Tbl_PaymentToSupplierEmployeeId;

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
            logExcpUIobj.MethodName = "GetPaymentToSupplierEmployeeApplyListByPaymentToEmployeeId()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeApplyListUI.Tbl_PaymentToSupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeApplyListDAL : GetPaymentToSupplierEmployeeApply_SelectByPaymentToEmployeeId] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeApplyListUI.Tbl_PaymentToSupplierEmployeeId + ". Details : [" + exp.ToString() + "]");
        }

        return dtbl;
    }
    public int DeletePaymentToSupplierEmployeeApply(PaymentToSupplierEmployeeApplyListUI paymentToSupplierEmployeeApplyListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeApply_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeApplyId"].Value = paymentToSupplierEmployeeApplyListUI.Tbl_PaymentToSupplierEmployeeApplyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentToSupplierEmployeeApply()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeApplyListUI.Tbl_PaymentToSupplierEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeApplyListDAL : DeletePaymentToSupplierEmployeeApply] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeApplyListUI.Tbl_PaymentToSupplierEmployeeApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}
