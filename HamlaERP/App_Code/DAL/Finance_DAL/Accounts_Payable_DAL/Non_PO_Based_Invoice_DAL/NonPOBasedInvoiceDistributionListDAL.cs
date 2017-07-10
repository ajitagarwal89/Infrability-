using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for NonPOBasedInvoiceDistributionListDAL
/// </summary>
public class NonPOBasedInvoiceDistributionListDAL
{



    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public NonPOBasedInvoiceDistributionListDAL()
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
            logExcpUIobj.MethodName = "NonPOBasedInvoiceDistributionListDAL()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[NonPOBasedInvoiceDistributionListDAL : NonPOBasedInvoiceDistributionListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetNonPOBasedInvoiceDistributionList()
    {

        DataSet ds = new DataSet();

        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoiceDistribution_Select", SupportCon);
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
            logExcpUIobj.MethodName = "getNonPOBasedInvoiceDistributionList()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[NonPOBasedInvoiceDistributionListDAL : getNonPOBasedInvoiceDistributionList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetNonPOBasedInvoiceDistributionListById(NonPOBasedInvoiceDistributionListUI nonPOBasedInvoiceDistributionListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoiceDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_NonPOBasedInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_NonPOBasedInvoiceDistributionId"].Value = nonPOBasedInvoiceDistributionListUI.Tbl_NonPOBasedInvoiceDistributionId;

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
            logExcpUIobj.MethodName = "getNonPOBasedInvoiceDistributionListById()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceDistributionListDAL.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceDistributionListUI.Tbl_NonPOBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[NonPOBasedInvoiceDistributionListDAL : getNonPOBasedInvoiceDistributionListById] An error occured in the processing of Record Id : " + nonPOBasedInvoiceDistributionListUI.Tbl_NonPOBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetNonPOBasedInvoiceDistributionListBySearchParameters(NonPOBasedInvoiceDistributionListUI nonPOBasedInvoiceDistributionListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoiceDistribution_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = nonPOBasedInvoiceDistributionListUI.Search;

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
            logExcpUIobj.MethodName = "GetNonPOBasedInvoiceDistributionListBySearchParameters()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceDistributionListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + nonPOBasedInvoiceDistributionListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[NonPOBasedInvoiceDistributionListDAL : GetNonPOBasedInvoiceDistributionListBySearchParameters] An error occured in the processing of Record Search = " + nonPOBasedInvoiceDistributionListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int DeleteNonPOBasedInvoiceDistribution(NonPOBasedInvoiceDistributionListUI nonPOBasedInvoiceDistributionListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoiceDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_NonPOBasedInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_NonPOBasedInvoiceDistributionId"].Value = nonPOBasedInvoiceDistributionListUI.Tbl_NonPOBasedInvoiceDistributionId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteNonPOBasedInvoiceDistribution()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceDistributionListDAL.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceDistributionListUI.Tbl_NonPOBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[NonPOBasedInvoiceDistributionListDAL : DeleteNonPOBasedInvoiceDistribution] An error occured in the processing of Record Id : " + nonPOBasedInvoiceDistributionListUI.Tbl_NonPOBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetNonPOBasedInvoiceDistributionListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoiceDistribution_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetNonPOBasedInvoiceDistributionListForExportToExcel()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[NonPOBasedInvoiceDistributionListDAL : GetNonPOBasedInvoiceDistributionListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

}
