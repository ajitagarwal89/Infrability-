using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for AssetPurchaseDetailsFormDAL
/// </summary>
public class AssetPurchaseDetailsFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public AssetPurchaseDetailsFormDAL()
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
            logExcpUIobj.MethodName = "AssetPurchaseDetailsFormDAL()";
            logExcpUIobj.ResourceName = "AssetPurchaseDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AssetPurchaseDetailsFormDAL : AssetPurchaseDetailsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAssetPurchaseDetailsListById(AssetPurchaseDetailsFormUI assetPurchaseDetailsFormUI)
    {


        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AssetPurchaseDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetPurchaseDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetPurchaseDetailsId"].Value = assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId;

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
            logExcpUIobj.MethodName = "GetAssetPurchaseDetailsListById()";
            logExcpUIobj.ResourceName = "AssetPurchaseDetailsFormDAL.CS";
            logExcpUIobj.RecordId = assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetPurchaseDetailsFormDAL : GetAssetPurchaseDetailsListById] An error occured in the processing of Record Id : " + assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
   public int AddAssetPurchaseDetails(AssetPurchaseDetailsFormUI assetPurchaseDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetPurchaseDetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = assetPurchaseDetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetPurchaseDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetPurchaseId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetPurchaseId"].Value = assetPurchaseDetailsFormUI.Tbl_AssetPurchaseId;

                sqlCmd.Parameters.Add("@tbl_PONumberId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PONumberId"].Value = assetPurchaseDetailsFormUI.Tbl_PONumberId;

                sqlCmd.Parameters.Add("@tbl_AssetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId"].Value = assetPurchaseDetailsFormUI.Tbl_AssetId;

                sqlCmd.Parameters.Add("@UOM", SqlDbType.NVarChar);
                sqlCmd.Parameters["@UOM"].Value = assetPurchaseDetailsFormUI.UOM;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = assetPurchaseDetailsFormUI.Tbl_LocationId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetPurchaseDetailsFormUI.Description;

                sqlCmd.Parameters.Add("@QuantityOrdered", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityOrdered"].Value = assetPurchaseDetailsFormUI.QuantityOrdered;


                sqlCmd.Parameters.Add("@QuantityShipped", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityShipped"].Value = assetPurchaseDetailsFormUI.QuantityShipped;

                sqlCmd.Parameters.Add("@QuantityInvoiced", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityInvoiced"].Value = assetPurchaseDetailsFormUI.QuantityInvoiced;

                sqlCmd.Parameters.Add("@PreviouslyShipped", SqlDbType.Decimal);
                sqlCmd.Parameters["@PreviouslyShipped"].Value = assetPurchaseDetailsFormUI.PreviouslyShipped;

                sqlCmd.Parameters.Add("@PreviouslyInvoiced", SqlDbType.Decimal);
                sqlCmd.Parameters["@PreviouslyInvoiced"].Value = assetPurchaseDetailsFormUI.PreviouslyInvoiced;


                sqlCmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@UnitCost"].Value = assetPurchaseDetailsFormUI.UnitCost;

                sqlCmd.Parameters.Add("@ExtendedCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExtendedCost"].Value = assetPurchaseDetailsFormUI.ExtendedCost;

                result = sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddAssetPurchaseDetails()";
            logExcpUIobj.ResourceName = "AssetPurchaseDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetPurchaseDetailsFormDAL : AddAssetPurchaseDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAssetPurchaseDetails(AssetPurchaseDetailsFormUI assetPurchaseDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetPurchaseDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = assetPurchaseDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetPurchaseDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetPurchaseDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetPurchaseDetailsId"].Value = assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId;
                
                sqlCmd.Parameters.Add("@tbl_AssetPurchaseId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetPurchaseId"].Value = assetPurchaseDetailsFormUI.Tbl_AssetPurchaseId;

                sqlCmd.Parameters.Add("@tbl_PONumberId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PONumberId"].Value = assetPurchaseDetailsFormUI.Tbl_PONumberId;

                sqlCmd.Parameters.Add("@tbl_AssetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId"].Value = assetPurchaseDetailsFormUI.Tbl_AssetId;

                sqlCmd.Parameters.Add("@UOM", SqlDbType.NVarChar);
                sqlCmd.Parameters["@UOM"].Value = assetPurchaseDetailsFormUI.UOM;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = assetPurchaseDetailsFormUI.Tbl_LocationId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetPurchaseDetailsFormUI.Description;

                sqlCmd.Parameters.Add("@QuantityOrdered", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityOrdered"].Value = assetPurchaseDetailsFormUI.QuantityOrdered;


                sqlCmd.Parameters.Add("@QuantityShipped", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityShipped"].Value = assetPurchaseDetailsFormUI.QuantityShipped;

                sqlCmd.Parameters.Add("@QuantityInvoiced", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityInvoiced"].Value = assetPurchaseDetailsFormUI.QuantityInvoiced;

                sqlCmd.Parameters.Add("@PreviouslyShipped", SqlDbType.Decimal);
                sqlCmd.Parameters["@PreviouslyShipped"].Value = assetPurchaseDetailsFormUI.PreviouslyShipped;

                sqlCmd.Parameters.Add("@PreviouslyInvoiced", SqlDbType.Decimal);
                sqlCmd.Parameters["@PreviouslyInvoiced"].Value = assetPurchaseDetailsFormUI.PreviouslyInvoiced;


                sqlCmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@UnitCost"].Value = assetPurchaseDetailsFormUI.UnitCost;

                sqlCmd.Parameters.Add("@ExtendedCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExtendedCost"].Value = assetPurchaseDetailsFormUI.ExtendedCost;

                result = sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAssetPurchase()";
            logExcpUIobj.ResourceName = "AssetPurchaseFormDAL.CS";
            logExcpUIobj.RecordId = assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetPurchaseFormDAL : UpdateAssetPurchase] An error occured in the processing of Record Id : " + assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAssetPurchaseDetails(AssetPurchaseDetailsFormUI assetPurchaseDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetPurchaseDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetPurchaseDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetPurchaseDetailsId"].Value = assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAssetPurchaseDetails()";
            logExcpUIobj.ResourceName = "AssetPurchaseDetailsFormDAL.CS";
            logExcpUIobj.RecordId = assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetPurchaseDetailsFormDAL : DeleteAssetPurchaseDetails] An error occured in the processing of Record Id : " + assetPurchaseDetailsFormUI.Tbl_AssetPurchaseDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}