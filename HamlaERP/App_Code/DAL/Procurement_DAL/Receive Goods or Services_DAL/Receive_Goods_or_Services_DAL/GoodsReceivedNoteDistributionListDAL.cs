using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for GoodsReceivedNoteDistributionListDAL
/// </summary>
public class GoodsReceivedNoteDistributionListDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public GoodsReceivedNoteDistributionListDAL()
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
            logExcpUIobj.MethodName = "GoodsReceivedNoteDistributionListDAL()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GoodsReceivedNoteDistributionListDAL : GoodsReceivedNoteDistributionListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetGoodsReceivedNoteDistributionList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNoteDistribution_Select", SupportCon);
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
            logExcpUIobj.MethodName = "getGoodsReceivedNoteDistributionList()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteDistributionListDAL : getGoodsReceivedNoteDistributionList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetGoodsReceivedNoteDistributionListById(GoodsReceivedNoteDistributionListUI goodsReceivedNoteDistributionListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNoteDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteDistributionId"].Value = goodsReceivedNoteDistributionListUI.Tbl_GoodsReceivedNoteDistributionId;

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
            logExcpUIobj.MethodName = "getGoodsReceivedNoteDistributionListById()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDistributionListDAL.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteDistributionListUI.Tbl_GoodsReceivedNoteDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteDistributionListDAL : getGoodsReceivedNoteDistributionListById] An error occured in the processing of Record Id : " + goodsReceivedNoteDistributionListUI.Tbl_GoodsReceivedNoteDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetGoodsReceivedNoteDistributionListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNoteDistribution_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetGoodsReceivedNoteDistributionListForExportToExcel()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDistributionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[GoodsReceivedNoteDistributionListDAL : GetGoodsReceivedNoteDistributionListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

    public DataTable GetGoodsReceivedNoteDistributionListBySearchParameters(GoodsReceivedNoteDistributionListUI goodsReceivedNoteDistributionListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNoteDistribution_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = goodsReceivedNoteDistributionListUI.Search;

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
            logExcpUIobj.MethodName = "GetGoodsReceivedNoteDistributionListBySearchParameters()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDistributionListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + goodsReceivedNoteDistributionListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteDistributionListDAL : GetGoodsReceivedNoteDistributionListBySearchParameters] An error occured in the processing of Record Search = " + goodsReceivedNoteDistributionListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int DeleteGoodsReceivedNoteDistribution(GoodsReceivedNoteDistributionListUI goodsReceivedNoteDistributionListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNoteDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteDistributionId"].Value = goodsReceivedNoteDistributionListUI.Tbl_GoodsReceivedNoteDistributionId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGoodsReceivedNoteDistribution()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDistributionListDAL.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteDistributionListUI.Tbl_GoodsReceivedNoteDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteDistributionListDAL : DeleteGoodsReceivedNoteDistribution] An error occured in the processing of Record Id : " + goodsReceivedNoteDistributionListUI.Tbl_GoodsReceivedNoteDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}