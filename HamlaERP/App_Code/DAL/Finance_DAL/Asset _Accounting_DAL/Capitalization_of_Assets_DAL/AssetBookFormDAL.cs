using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for AssetBookFormDAL
/// </summary>
public class AssetBookFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public AssetBookFormDAL()
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
            logExcpUIobj.MethodName = "AssetBookFormDAL()";
            logExcpUIobj.ResourceName = "AssetBookFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AssetBookFormDAL : AssetBookFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAssetBookListById(AssetBookFormUI assetBookFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AssetBook_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetBookId"].Value = assetBookFormUI.Tbl_AssetBookId;

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
            logExcpUIobj.MethodName = "getAssetBookListById()";
            logExcpUIobj.ResourceName = "AssetBookFormDAL.CS";
            logExcpUIobj.RecordId = assetBookFormUI.Tbl_AssetBookId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookFormDAL : getAssetBookListById] An error occured in the processing of Record Id : " + assetBookFormUI.Tbl_AssetBookId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddAssetBook(AssetBookFormUI assetBookFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetBook_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = assetBookFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetBookFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId"].Value = assetBookFormUI.Tbl_AssetId;

                sqlCmd.Parameters.Add("@AssetBookCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AssetBookCode"].Value = assetBookFormUI.AssetBookCode;

                sqlCmd.Parameters.Add("@PlaceInServiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PlaceInServiceDate"].Value = assetBookFormUI.PlaceInServiceDate;

                sqlCmd.Parameters.Add("@DepreciatedDueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DepreciatedDueDate"].Value = assetBookFormUI.DepreciatedDueDate;

                sqlCmd.Parameters.Add("@BeginYearCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@BeginYearCost"].Value = assetBookFormUI.BeginYearCost;

                sqlCmd.Parameters.Add("@CostBasis", SqlDbType.Decimal);
                sqlCmd.Parameters["@CostBasis"].Value = assetBookFormUI.CostBasis;

                sqlCmd.Parameters.Add("@ScrapValue", SqlDbType.Decimal);
                sqlCmd.Parameters["@ScrapValue"].Value = assetBookFormUI.ScrapValue;

                sqlCmd.Parameters.Add("@YearlyDepreciationRate", SqlDbType.Decimal);
                sqlCmd.Parameters["@YearlyDepreciationRate"].Value = assetBookFormUI.YearlyDepreciationRate;

                sqlCmd.Parameters.Add("@CurrentDepreciation", SqlDbType.Decimal);
                sqlCmd.Parameters["@CurrentDepreciation"].Value = assetBookFormUI.CurrentDepreciation;

                sqlCmd.Parameters.Add("@NetBookValue", SqlDbType.Decimal);
                sqlCmd.Parameters["NetBookValue"].Value = assetBookFormUI.NetBookValue;

                sqlCmd.Parameters.Add("@opt_DepreciationMethod", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_DepreciationMethod"].Value = assetBookFormUI.opt_DepreciationMethod;

                sqlCmd.Parameters.Add("@opt_AveragingConvention", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_AveragingConvention"].Value = assetBookFormUI.opt_AveragingConvention;

                sqlCmd.Parameters.Add("@FullDepreciationFlag", SqlDbType.Bit);
                sqlCmd.Parameters["@FullDepreciationFlag"].Value = assetBookFormUI.FullDepreciationFlag;

                sqlCmd.Parameters.Add("@opt_Status", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_Status"].Value = assetBookFormUI.opt_Status;

                sqlCmd.Parameters.Add("@OriginalLifeYear", SqlDbType.TinyInt);
                sqlCmd.Parameters["@OriginalLifeYear"].Value = assetBookFormUI.OriginalLifeYear;

                sqlCmd.Parameters.Add("@OriginalLifeDay", SqlDbType.TinyInt);
                sqlCmd.Parameters["@OriginalLifeDay"].Value = assetBookFormUI.OriginalLifeDay;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddAssetBook()";
            logExcpUIobj.ResourceName = "AssetBookFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookFormDAL : AddAssetBook] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAssetBook(AssetBookFormUI assetBookFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetBook_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = assetBookFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetBookFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetBookId"].Value = assetBookFormUI.Tbl_AssetBookId;

                sqlCmd.Parameters.Add("@tbl_AssetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId"].Value = assetBookFormUI.Tbl_AssetId;

                sqlCmd.Parameters.Add("@AssetBookCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AssetBookCode"].Value = assetBookFormUI.AssetBookCode;

                sqlCmd.Parameters.Add("@PlaceInServiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PlaceInServiceDate"].Value = assetBookFormUI.PlaceInServiceDate;

                sqlCmd.Parameters.Add("@DepreciatedDueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DepreciatedDueDate"].Value = assetBookFormUI.DepreciatedDueDate;

                sqlCmd.Parameters.Add("@BeginYearCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@BeginYearCost"].Value = assetBookFormUI.BeginYearCost;

                sqlCmd.Parameters.Add("@CostBasis", SqlDbType.Decimal);
                sqlCmd.Parameters["@CostBasis"].Value = assetBookFormUI.CostBasis;

                sqlCmd.Parameters.Add("@ScrapValue", SqlDbType.Decimal);
                sqlCmd.Parameters["@ScrapValue"].Value = assetBookFormUI.ScrapValue;

                sqlCmd.Parameters.Add("@YearlyDepreciationRate", SqlDbType.Decimal);
                sqlCmd.Parameters["@YearlyDepreciationRate"].Value = assetBookFormUI.YearlyDepreciationRate;

                sqlCmd.Parameters.Add("@CurrentDepreciation", SqlDbType.Decimal);
                sqlCmd.Parameters["@CurrentDepreciation"].Value = assetBookFormUI.CurrentDepreciation;

                sqlCmd.Parameters.Add("@NetBookValue", SqlDbType.Decimal);
                sqlCmd.Parameters["NetBookValue"].Value = assetBookFormUI.NetBookValue;

                sqlCmd.Parameters.Add("@opt_DepreciationMethod", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_DepreciationMethod"].Value = assetBookFormUI.opt_DepreciationMethod;

                sqlCmd.Parameters.Add("@opt_AveragingConvention", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_AveragingConvention"].Value = assetBookFormUI.opt_AveragingConvention;

                sqlCmd.Parameters.Add("@FullDepreciationFlag", SqlDbType.Bit);
                sqlCmd.Parameters["@FullDepreciationFlag"].Value = assetBookFormUI.FullDepreciationFlag;

                sqlCmd.Parameters.Add("@opt_Status", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_Status"].Value = assetBookFormUI.opt_Status;

                sqlCmd.Parameters.Add("@OriginalLifeYear", SqlDbType.TinyInt);
                sqlCmd.Parameters["@OriginalLifeYear"].Value = assetBookFormUI.OriginalLifeYear;

                sqlCmd.Parameters.Add("@OriginalLifeDay", SqlDbType.TinyInt);
                sqlCmd.Parameters["@OriginalLifeDay"].Value = assetBookFormUI.OriginalLifeDay;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAssetBook()";
            logExcpUIobj.ResourceName = "AssetBookFormDAL.CS";
            logExcpUIobj.RecordId = assetBookFormUI.Tbl_AssetBookId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookFormDAL : UpdateAssetBook] An error occured in the processing of Record Id : " + assetBookFormUI.Tbl_AssetBookId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAssetBook(AssetBookFormUI assetBookFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetBook_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetBookId"].Value = assetBookFormUI.Tbl_AssetBookId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAssetBook()";
            logExcpUIobj.ResourceName = "AssetBookFormDAL.CS";
            logExcpUIobj.RecordId = assetBookFormUI.Tbl_AssetBookId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookFormDAL : DeleteAssetBook] An error occured in the processing of Record Id : " + assetBookFormUI.Tbl_AssetBookId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}