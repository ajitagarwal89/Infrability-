using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for POBasedInvoiceDistributionListDAL
/// </summary>
public class POBasedInvoiceDistributionListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public POBasedInvoiceDistributionListDAL()
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
            logExcpUIobj.MethodName = "POBasedInvoiceDistributionListDAL()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[POBasedInvoiceDistributionListDAL : POBasedInvoiceDistributionListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetPOBasedInvoiceDistributionList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDistribution_Select", SupportCon);
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
            logExcpUIobj.MethodName = "getPOBasedInvoiceDistributionList()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDistributionListDAL : getPOBasedInvoiceDistributionList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetPOBasedInvoiceDistributionListById(POBasedInvoiceDistributionListUI pOBasedInvoiceDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceDistributionId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;

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
            logExcpUIobj.MethodName = "getPOBasedInvoiceDistributionListById()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionListDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDistributionListDAL : getPOBasedInvoiceDistributionListById] An error occured in the processing of Record Id : " + pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetPOBasedInvoiceDistributionListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDistribution_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetPOBasedInvoiceDistributionListForExportToExcel()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[POBasedInvoiceDistributionListDAL : GetPOBasedInvoiceDistributionListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

    public DataTable GetPOBasedInvoiceDistributionListBySearchParameters(POBasedInvoiceDistributionListUI pOBasedInvoiceDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDistribution_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = pOBasedInvoiceDistributionFormUI.Search;

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
            logExcpUIobj.MethodName = "GetPOBasedInvoiceDistributionListBySearchParameters()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + pOBasedInvoiceDistributionFormUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDistributionListDAL : GetPOBasedInvoiceDistributionListBySearchParameters] An error occured in the processing of Record Search = " + pOBasedInvoiceDistributionFormUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int DeletePOBasedInvoiceDistribution(POBasedInvoiceDistributionListUI pOBasedInvoiceDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceDistributionId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePOBasedInvoiceDistribution()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionListDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDistributionListDAL : DeletePOBasedInvoiceDistribution] An error occured in the processing of Record Id : " + pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}