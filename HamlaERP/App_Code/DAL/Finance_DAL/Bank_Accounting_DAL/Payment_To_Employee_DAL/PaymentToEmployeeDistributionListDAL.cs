using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;
/// <summary>
/// Summary description for PaymentToEmployeeDistributionList
/// </summary>
public class PaymentToEmployeeDistributionListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PaymentToEmployeeDistributionListDAL()
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
            logExcpUIobj.MethodName = "PaymentToEmployeeDistributionListDAL()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            throw new Exception("[PaymentToEmployeeDistributionListDAL : PaymentToEmployeeDistributionListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentToEmployeeDistributionListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeDistributionListForExportToExcel()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeDistributionListDAL : GetPaymentToEmployeeDistributionListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

    public DataTable GetPaymentToEmployeeDistributionList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeDistributionList()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeDistributionListDAL : GetPaymentToEmployeeDistributionList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetPaymentToEmployeeDistributionListById(PaymentToEmployeeDistributionListUI PaymentToEmployeeDistributionListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeDistributionId"].Value = PaymentToEmployeeDistributionListUI.Tbl_PaymentToEmployeeDistributionId;

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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeDistributionListById()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionListDAL.CS";
            logExcpUIobj.RecordId = PaymentToEmployeeDistributionListUI.Tbl_PaymentToEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeDistributionListDAL : GetPaymentToEmployeeDistributionListById] An error occured in the processing of Record Id : " + PaymentToEmployeeDistributionListUI.Tbl_PaymentToEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetPaymentToEmployeeDistributionListBySearchParameters(PaymentToEmployeeDistributionListUI PaymentToEmployeeDistributionListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = PaymentToEmployeeDistributionListUI.Search;

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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeDistributionListBySearchParameters()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + PaymentToEmployeeDistributionListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeDistributionListDAL : GetPaymentToEmployeeDistributionListBySearchParameters] An error occured in the processing of Record Search = " + PaymentToEmployeeDistributionListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }
    public int DeletePaymentToEmployeeDistribution(PaymentToEmployeeDistributionListUI PaymentToEmployeeDistributionListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeDistributionId"].Value = PaymentToEmployeeDistributionListUI.Tbl_PaymentToEmployeeDistributionId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentToEmployeeDistribution()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionListDAL.CS";
            logExcpUIobj.RecordId = PaymentToEmployeeDistributionListUI.Tbl_PaymentToEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeDistributionListDAL : DeletePaymentToEmployeeDistribution] An error occured in the processing of Record Id : " + PaymentToEmployeeDistributionListUI.Tbl_PaymentToEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}