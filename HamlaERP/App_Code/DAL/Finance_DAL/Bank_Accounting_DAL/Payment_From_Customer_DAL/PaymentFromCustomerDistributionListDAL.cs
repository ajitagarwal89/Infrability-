using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;
/// <summary>
/// Summary description for PaymentFromCustomerDistributionListDAL
/// </summary>
public class PaymentFromCustomerDistributionListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PaymentFromCustomerDistributionListDAL()
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
            logExcpUIobj.MethodName = "PaymentFromCustomerDistributionListDAL()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            throw new Exception("[PaymentFromCustomerDistributionListDAL : PaymentFromCustomerDistributionListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentFromCustomerDistributionListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetPaymentFromCustomerDistributionListForExportToExcel()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerDistributionListDAL : GetPaymentFromCustomerDistributionListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

    public DataTable GetPaymentFromCustomerDistributionList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetPaymentFromCustomerDistributionList()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerDistributionListDAL : GetPaymentFromCustomerDistributionList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetPaymentFromCustomerDistributionListById(PaymentFromCustomerDistributionListUI PaymentFromCustomerDistributionListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerDistributionId"].Value = PaymentFromCustomerDistributionListUI.Tbl_PaymentFromCustomerDistributionId;

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
            logExcpUIobj.MethodName = "GetPaymentFromCustomerDistributionListById()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionListDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerDistributionListUI.Tbl_PaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerDistributionListDAL : GetPaymentFromCustomerDistributionListById] An error occured in the processing of Record Id : " + PaymentFromCustomerDistributionListUI.Tbl_PaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetPaymentFromCustomerDistributionListBySearchParameters(PaymentFromCustomerDistributionListUI PaymentFromCustomerDistributionListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = PaymentFromCustomerDistributionListUI.Search;

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
            logExcpUIobj.MethodName = "GetPaymentFromCustomerDistributionListBySearchParameters()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + PaymentFromCustomerDistributionListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerDistributionListDAL : GetPaymentFromCustomerDistributionListBySearchParameters] An error occured in the processing of Record Search = " + PaymentFromCustomerDistributionListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }
    public int DeletePaymentFromCustomerDistribution(PaymentFromCustomerDistributionListUI PaymentFromCustomerDistributionListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerDistributionId"].Value = PaymentFromCustomerDistributionListUI.Tbl_PaymentFromCustomerDistributionId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentFromCustomerDistribution()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionListDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerDistributionListUI.Tbl_PaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerDistributionListDAL : DeletePaymentFromCustomerDistribution] An error occured in the processing of Record Id : " + PaymentFromCustomerDistributionListUI.Tbl_PaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}