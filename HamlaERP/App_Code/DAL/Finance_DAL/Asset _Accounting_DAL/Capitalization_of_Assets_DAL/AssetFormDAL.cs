using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for AssetFormDAL
/// </summary>
public class AssetFormDAL
{

    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public AssetFormDAL()
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
            logExcpUIobj.MethodName = "AssetFormDAL()";
            logExcpUIobj.ResourceName = "AssetFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AssetFormDAL : AssetFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAssetListById(AssetFormUI assetFormUI)
    {
       

          DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Asset_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId"].Value = assetFormUI.Tbl_AssetId;

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
            logExcpUIobj.MethodName = "GetAssetListById()";
            logExcpUIobj.ResourceName = "AssetFormDAL.CS";
            logExcpUIobj.RecordId = assetFormUI.Tbl_AssetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetFormDAL : GetAssetListById] An error occured in the processing of Record Id : " + assetFormUI.Tbl_AssetId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddAsset(AssetFormUI assetFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Asset_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = assetFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@AssetCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AssetCode"].Value = assetFormUI.AssetCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetFormUI.Description;

                sqlCmd.Parameters.Add("@ExtendedDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ExtendedDescription"].Value = assetFormUI.ExtendedDescription;

                sqlCmd.Parameters.Add("@ShortName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ShortName"].Value = assetFormUI.ShortName;

                sqlCmd.Parameters.Add("@tbl_AssetGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetGroupId"].Value = assetFormUI.Tbl_AssetGroupId;               

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = assetFormUI.opt_Type;

                sqlCmd.Parameters.Add("@tbl_AssetAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetAndGroupAccountId"].Value = assetFormUI.Tbl_AssetAndGroupAccountId;

                sqlCmd.Parameters.Add("@AcquisitionDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@AcquisitionDate"].Value = assetFormUI.AcquisitionDate;

                sqlCmd.Parameters.Add("@AcquisitionCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@AcquisitionCost"].Value = assetFormUI.AcquisitionCost;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = assetFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = assetFormUI.Tbl_LocationId;

                sqlCmd.Parameters.Add("@tbl_PhysicalLocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PhysicalLocationId"].Value = assetFormUI.Tbl_PhysicalLocationId;
                
                sqlCmd.Parameters.Add("@AssetBarcode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AssetBarcode"].Value = assetFormUI.AssetBarcode;

                sqlCmd.Parameters.Add("@tbl_StructureId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_StructureId"].Value = assetFormUI.Tbl_StructureId;

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = assetFormUI.Tbl_EmployeeId;

                sqlCmd.Parameters.Add("@ManufacturerName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ManufacturerName"].Value = assetFormUI.ManufacturerName;

                sqlCmd.Parameters.Add("@Quantity", SqlDbType.Decimal);
                sqlCmd.Parameters["@Quantity"].Value = assetFormUI.Quantity;

                sqlCmd.Parameters.Add("@LastMaintenanceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastMaintenanceDate"].Value = assetFormUI.LastMaintenanceDate;

                sqlCmd.Parameters.Add("@DateAdded", SqlDbType.DateTime);
                sqlCmd.Parameters["@DateAdded"].Value = assetFormUI.DateAdded;

                sqlCmd.Parameters.Add("@opt_Status", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Status"].Value = assetFormUI.opt_Status;

                sqlCmd.Parameters.Add("@SerialNumber", SqlDbType.NVarChar );
                sqlCmd.Parameters["@SerialNumber"].Value = assetFormUI.SerialNumber;

                sqlCmd.Parameters.Add("@ModalNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModalNumber"].Value = assetFormUI.ModalNumber;

                sqlCmd.Parameters.Add("@WarrantyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@WarrantyDate"].Value = assetFormUI.WarrantyDate;

                result = sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddAsset()";
            logExcpUIobj.ResourceName = "AssetFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetFormDAL : AddAsset] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAsset(AssetFormUI assetFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Asset_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = assetFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId"].Value = assetFormUI.Tbl_AssetId;

                sqlCmd.Parameters.Add("@AssetCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AssetCode"].Value = assetFormUI.AssetCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetFormUI.Description;

                sqlCmd.Parameters.Add("@ExtendedDescription", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ExtendedDescription"].Value = assetFormUI.ExtendedDescription;

                sqlCmd.Parameters.Add("@ShortName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ShortName"].Value = assetFormUI.ShortName;

                sqlCmd.Parameters.Add("@tbl_AssetGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetGroupId"].Value = assetFormUI.Tbl_AssetGroupId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = assetFormUI.opt_Type;

                sqlCmd.Parameters.Add("@tbl_AssetAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetAndGroupAccountId"].Value = assetFormUI.Tbl_AssetAndGroupAccountId;

                sqlCmd.Parameters.Add("@AcquisitionDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@AcquisitionDate"].Value = assetFormUI.AcquisitionDate;

                sqlCmd.Parameters.Add("@AcquisitionCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@AcquisitionCost"].Value = assetFormUI.AcquisitionCost;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = assetFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = assetFormUI.Tbl_LocationId;

                sqlCmd.Parameters.Add("@tbl_PhysicalLocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PhysicalLocationId"].Value = assetFormUI.Tbl_PhysicalLocationId;

                sqlCmd.Parameters.Add("@AssetBarcode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AssetBarcode"].Value = assetFormUI.AssetBarcode;

                sqlCmd.Parameters.Add("@tbl_StructureId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_StructureId"].Value = assetFormUI.Tbl_StructureId;

                sqlCmd.Parameters.Add("@tbl_EmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeId"].Value = assetFormUI.Tbl_EmployeeId;

                sqlCmd.Parameters.Add("@ManufacturerName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ManufacturerName"].Value = assetFormUI.ManufacturerName;

                sqlCmd.Parameters.Add("@Quantity", SqlDbType.Decimal);
                sqlCmd.Parameters["@Quantity"].Value = assetFormUI.Quantity;

                sqlCmd.Parameters.Add("@LastMaintenanceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastMaintenanceDate"].Value = assetFormUI.LastMaintenanceDate;

                sqlCmd.Parameters.Add("@DateAdded", SqlDbType.DateTime);
                sqlCmd.Parameters["@DateAdded"].Value = assetFormUI.DateAdded;

                sqlCmd.Parameters.Add("@opt_Status", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Status"].Value = assetFormUI.opt_Status;

                sqlCmd.Parameters.Add("@SerialNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SerialNumber"].Value = assetFormUI.SerialNumber;

                sqlCmd.Parameters.Add("@ModalNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModalNumber"].Value = assetFormUI.ModalNumber;

                sqlCmd.Parameters.Add("@WarrantyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@WarrantyDate"].Value = assetFormUI.WarrantyDate;

                result = sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAsset()";
            logExcpUIobj.ResourceName = "AssetFormDAL.CS";
            logExcpUIobj.RecordId = assetFormUI.Tbl_AssetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetFormDAL : UpdateAsset] An error occured in the processing of Record Id : " + assetFormUI.Tbl_AssetId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAsset(AssetFormUI assetFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Asset_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId"].Value = assetFormUI.Tbl_AssetId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAsset()";
            logExcpUIobj.ResourceName = "AssetFormDAL.CS";
            logExcpUIobj.RecordId = assetFormUI.Tbl_AssetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetFormDAL : DeleteAsset] An error occured in the processing of Record Id : " + assetFormUI.Tbl_AssetId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}