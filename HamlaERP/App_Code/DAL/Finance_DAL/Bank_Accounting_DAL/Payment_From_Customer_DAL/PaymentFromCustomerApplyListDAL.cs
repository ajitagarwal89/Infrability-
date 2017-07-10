using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for PaymentFromCustomerApplyListDAL
/// </summary>
public class PaymentFromCustomerApplyListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PaymentFromCustomerApplyListDAL()
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
            logExcpUIobj.MethodName = "PaymentFromCustomerApplyListDAL()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            throw new Exception("[PaymentFromCustomerApplyListDAL : PaymentFromCustomerApplyListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentFromCustomerApplyListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerApply_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetPaymentFromCustomerApplyListForExportToExcel()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerApplyListDAL : GetPaymentFromCustomerApplyListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

    public DataTable GetPaymentFromCustomerApplyList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerApply_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetPaymentFromCustomerApplyList()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerApplyListDAL : GetPaymentFromCustomerApplyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetPaymentFromCustomerApplyListById(PaymentFromCustomerApplyListUI PaymentFromCustomerApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerApply_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerApplyId"].Value = PaymentFromCustomerApplyListUI.Tbl_PaymentFromCustomerApplyId;

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
            logExcpUIobj.MethodName = "GetPaymentFromCustomerApplyListById()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyListDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerApplyListUI.Tbl_PaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerApplyListDAL : GetPaymentFromCustomerApplyListById] An error occured in the processing of Record Id : " + PaymentFromCustomerApplyListUI.Tbl_PaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetPaymentFromCustomerApplyListBySearchParameters(PaymentFromCustomerApplyListUI PaymentFromCustomerApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerApply_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = PaymentFromCustomerApplyListUI.Search;

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
            logExcpUIobj.MethodName = "GetPaymentFromCustomerApplyListBySearchParameters()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + PaymentFromCustomerApplyListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerApplyListDAL : GetPaymentFromCustomerApplyListBySearchParameters] An error occured in the processing of Record Search = " + PaymentFromCustomerApplyListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }
    public int DeletePaymentFromCustomerApply(PaymentFromCustomerApplyListUI PaymentFromCustomerApplyListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerApply_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerApplyId"].Value = PaymentFromCustomerApplyListUI.Tbl_PaymentFromCustomerApplyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentFromCustomerApply()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyListDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerApplyListUI.Tbl_PaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerApplyListDAL : DeletePaymentFromCustomerApply] An error occured in the processing of Record Id : " + PaymentFromCustomerApplyListUI.Tbl_PaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetPaymentFromCustomerApplyListByPaymentFromCustomerId(PaymentFromCustomerApplyListUI paymentFromCustomerApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerApply_SelectByPaymentFromCustomerId", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_paymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_paymentFromCustomerId"].Value = paymentFromCustomerApplyListUI.Tbl_PaymentFromCustomerId;

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
            logExcpUIobj.MethodName = "GetPaymentFromCustomerApplyListByPaymentFromCustomerId()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerFormDAL.CS";
            logExcpUIobj.RecordId = paymentFromCustomerApplyListUI.Tbl_PaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerFormDAL : GetPaymentFromCustomerApplyByPaymentFromCustomerId] An error occured in the processing of Record Id : " + paymentFromCustomerApplyListUI.Tbl_PaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }

        return dtbl;
    }
}