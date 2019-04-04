using System;
using System.Data.SqlClient;
using System.Data;
using log4net;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.SessionState;
using System.Web;
using Finware;
/// <summary>
/// Summary description for AssetTransferDetailsFormDAL
/// </summary>
public class AssetTransferDetailsFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public AssetTransferDetailsFormDAL()
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
            logExcpUIobj.MethodName = "AssetTransferDetailsFormDAL()";
            logExcpUIobj.ResourceName = "AssetTransferDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AssetTransferDetailsFormDAL : AssetTransferDetailsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetAssetTransferDetailsListById(AssetTransferDetailsFormUI assetTransferDetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AssetTransferDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetTransferDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetTransferDetailsId"].Value = assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl = ds.Tables[0];
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_AssetTransferDetails", assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getAssetTransferDetailsListById()";
            logExcpUIobj.ResourceName = "AssetTransferDetailsFormDAL.CS";
            logExcpUIobj.RecordId = assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetTransferDetailsFormDAL : getAssetTransferDetailsListById] An error occured in the processing of Record Id : " + assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddAssetTransferDetails(AssetTransferDetailsFormUI assetTransferDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetTransferDetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = assetTransferDetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetTransferDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetTransferId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetTransferId"].Value = assetTransferDetailsFormUI.Tbl_AssetTransferId;

                sqlCmd.Parameters.Add("@tbl_AssetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId"].Value = assetTransferDetailsFormUI.Tbl_AssetId;

                sqlCmd.Parameters.Add("@UOM", SqlDbType.NVarChar);
                sqlCmd.Parameters["@UOM"].Value = assetTransferDetailsFormUI.UOM;

                sqlCmd.Parameters.Add("@Quantity", SqlDbType.Decimal);
                sqlCmd.Parameters["@Quantity"].Value = assetTransferDetailsFormUI.Quantity;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetTransferDetailsFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_LocationId_From", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId_From"].Value = assetTransferDetailsFormUI.Tbl_LocationId_From;

                sqlCmd.Parameters.Add("@tbl_LocationId_To", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId_To"].Value = assetTransferDetailsFormUI.Tbl_LocationId_To;


                sqlCmd.Parameters.Add("@SubTotal", SqlDbType.Decimal);
                sqlCmd.Parameters["@SubTotal"].Value = assetTransferDetailsFormUI.SubTotal;

                sqlCmd.Parameters.Add("@QuantityAvailable", SqlDbType.Int);
                sqlCmd.Parameters["@QuantityAvailable"].Value = assetTransferDetailsFormUI.QuantityAvailable;

                sqlCmd.Parameters.Add("@tbl_AssetTransferDetailsId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_AssetTransferDetailsId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_AssetTransferDetailsId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_AssetTransferDetails";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(assetTransferDetailsFormUI);
                    audit_IUD.WebServiceInsert(assetTransferDetailsFormUI.Tbl_OrganizationId, tableName, RecoredID, assetTransferDetailsFormUI.CreatedBy, newValue);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddAssetTransferDetails()";
            logExcpUIobj.ResourceName = "AssetTransferDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetTransferDetailsFormDAL : AddAssetTransferDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAssetTransferDetails(AssetTransferDetailsFormUI assetTransferDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetTransferDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = assetTransferDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetTransferDetailsFormUI.Tbl_OrganizationId;


                sqlCmd.Parameters.Add("@tbl_AssetTransferDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetTransferDetailsId"].Value = assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId;


                sqlCmd.Parameters.Add("@tbl_AssetTransferId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetTransferId"].Value = assetTransferDetailsFormUI.Tbl_AssetTransferId;

                sqlCmd.Parameters.Add("@tbl_AssetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId"].Value = assetTransferDetailsFormUI.Tbl_AssetId;

                sqlCmd.Parameters.Add("@UOM", SqlDbType.NVarChar);
                sqlCmd.Parameters["@UOM"].Value = assetTransferDetailsFormUI.UOM;

                sqlCmd.Parameters.Add("@Quantity", SqlDbType.Decimal);
                sqlCmd.Parameters["@Quantity"].Value = assetTransferDetailsFormUI.Quantity;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetTransferDetailsFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_LocationId_From", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId_From"].Value = assetTransferDetailsFormUI.Tbl_LocationId_From;

                sqlCmd.Parameters.Add("@tbl_LocationId_To", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId_To"].Value = assetTransferDetailsFormUI.Tbl_LocationId_To;


                sqlCmd.Parameters.Add("@SubTotal", SqlDbType.Decimal);
                sqlCmd.Parameters["@SubTotal"].Value = assetTransferDetailsFormUI.SubTotal;

                sqlCmd.Parameters.Add("@QuantityAvailable", SqlDbType.Int);
                sqlCmd.Parameters["@QuantityAvailable"].Value = assetTransferDetailsFormUI.QuantityAvailable;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(assetTransferDetailsFormUI);
                    audit_IUD.WebServiceUpdate(assetTransferDetailsFormUI.Tbl_OrganizationId, "tbl_AssetTransferDetails", assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId, assetTransferDetailsFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAssetTransferDetails()";
            logExcpUIobj.ResourceName = "AssetTransferDetailsFormDAL.CS";
            logExcpUIobj.RecordId = assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetTransferDetailsFormDAL : UpdateAssetTransferDetails] An error occured in the processing of Record Id : " + assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAssetTransferDetails(AssetTransferDetailsFormUI assetTransferDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetTransferDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetTransferDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetTransferDetailsId"].Value = assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_AssetTransferDetails", assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAssetTransferDetails()";
            logExcpUIobj.ResourceName = "AssetTransferDetailsFormDAL.CS";
            logExcpUIobj.RecordId = assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetTransferDetailsFormDAL : DeleteAssetTransferDetails] An error occured in the processing of Record Id : " + assetTransferDetailsFormUI.Tbl_AssetTransferDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}