using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;
/// <summary>
/// Summary description for PaymentToEmployeeApplyListDAL
/// </summary>
public class PaymentToEmployeeApplyListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PaymentToEmployeeApplyListDAL()
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
            logExcpUIobj.MethodName = "PaymentToEmployeeApplyListDAL()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            throw new Exception("[PaymentToEmployeeApplyListDAL : PaymentToEmployeeApplyListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentToEmployeeApplyListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeApply_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeApplyListForExportToExcel()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeApplyListDAL : GetPaymentToEmployeeApplyListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

    public DataTable GetPaymentToEmployeeApplyList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeApply_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeApplyList()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeApplyListDAL : GetPaymentToEmployeeApplyList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetPaymentToEmployeeApplyListById(PaymentToEmployeeApplyListUI PaymentToEmployeeApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeApply_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeApplyId"].Value = PaymentToEmployeeApplyListUI.Tbl_PaymentToEmployeeApplyId;

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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeApplyListById()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = PaymentToEmployeeApplyListUI.Tbl_PaymentToEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeApplyListDAL : GetPaymentToEmployeeApplyListById] An error occured in the processing of Record Id : " + PaymentToEmployeeApplyListUI.Tbl_PaymentToEmployeeApplyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetPaymentToEmployeeApplyListBySearchParameters(PaymentToEmployeeApplyListUI PaymentToEmployeeApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeApply_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = PaymentToEmployeeApplyListUI.Search;

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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeApplyListBySearchParameters()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + PaymentToEmployeeApplyListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeApplyListDAL : GetPaymentToEmployeeApplyListBySearchParameters] An error occured in the processing of Record Search = " + PaymentToEmployeeApplyListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }

    public DataTable GetPaymentToEmployeeApplyListByPaymentToEmployeeId(PaymentToEmployeeApplyListUI paymentToEmployeeApplyListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeApply_SelectByPaymentToEmployeeId", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeId"].Value = paymentToEmployeeApplyListUI.Tbl_PaymentToEmployeeId;

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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeApplyListByPaymentToEmployeeId()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = paymentToEmployeeApplyListUI.Tbl_PaymentToEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeApplyListDAL : GetPaymentToEmployeeApply_SelectByPaymentToEmployeeId] An error occured in the processing of Record Id : " + paymentToEmployeeApplyListUI.Tbl_PaymentToEmployeeId + ". Details : [" + exp.ToString() + "]");
        }

        return dtbl;
    }
    public int DeletePaymentToEmployeeApply(PaymentToEmployeeApplyListUI PaymentToEmployeeApplyListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeApply_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeApplyId"].Value = PaymentToEmployeeApplyListUI.Tbl_PaymentToEmployeeApplyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentToEmployeeApply()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeApplyListDAL.CS";
            logExcpUIobj.RecordId = PaymentToEmployeeApplyListUI.Tbl_PaymentToEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeApplyListDAL : DeletePaymentToEmployeeApply] An error occured in the processing of Record Id : " + PaymentToEmployeeApplyListUI.Tbl_PaymentToEmployeeApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}