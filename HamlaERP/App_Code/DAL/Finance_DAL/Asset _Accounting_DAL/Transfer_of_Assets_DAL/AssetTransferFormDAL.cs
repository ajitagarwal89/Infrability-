using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for AssetTransferFormDAL
/// </summary>
public class AssetTransferFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public AssetTransferFormDAL()
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
            logExcpUIobj.MethodName = "AssetTransferFormDAL()";
            logExcpUIobj.ResourceName = "AssetTransferFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AssetTransferFormDAL : AssetTransferFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAssetTransferListById(AssetTransferFormUI assetTransferFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AssetTransfer_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetTransferId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetTransferId"].Value = assetTransferFormUI.Tbl_AssetTransferId;

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
            logExcpUIobj.MethodName = "getAssetTransferListById()";
            logExcpUIobj.ResourceName = "AssetTransferFormDAL.CS";
            logExcpUIobj.RecordId = assetTransferFormUI.Tbl_AssetTransferId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetTransferFormDAL : getAssetTransferListById] An error occured in the processing of Record Id : " + assetTransferFormUI.Tbl_AssetTransferId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddAssetTransfer(AssetTransferFormUI assetTransferFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetTransfer_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = assetTransferFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetTransferFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_DocumentType"].Value = assetTransferFormUI.opt_DocumentType;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = assetTransferFormUI.Number;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = assetTransferFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@Date", SqlDbType.DateTime);
                sqlCmd.Parameters["@Date"].Value = assetTransferFormUI.Date;

                sqlCmd.Parameters.Add("@tbl_LocationId_From", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId_From"].Value = assetTransferFormUI.Tbl_LocationId_From;

                sqlCmd.Parameters.Add("@tbl_LocationId_To", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId_To"].Value = assetTransferFormUI.Tbl_LocationId_To;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddAssetTransfer()";
            logExcpUIobj.ResourceName = "AssetTransferFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetTransferFormDAL : AddAssetTransfer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAssetTransfer(AssetTransferFormUI assetTransferFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetTransfer_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetTransferFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = assetTransferFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_AssetTransferId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetTransferId"].Value = assetTransferFormUI.Tbl_AssetTransferId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_DocumentType"].Value = assetTransferFormUI.opt_DocumentType;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = assetTransferFormUI.Number;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = assetTransferFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@Date", SqlDbType.DateTime);
                sqlCmd.Parameters["@Date"].Value = assetTransferFormUI.Date;

                sqlCmd.Parameters.Add("@tbl_LocationId_From", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId_From"].Value = assetTransferFormUI.Tbl_LocationId_From;

                sqlCmd.Parameters.Add("@tbl_LocationId_To", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId_To"].Value = assetTransferFormUI.Tbl_LocationId_To;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAssetTransfer()";
            logExcpUIobj.ResourceName = "AssetTransferFormDAL.CS";
            logExcpUIobj.RecordId = assetTransferFormUI.Tbl_AssetTransferId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetTransferFormDAL : UpdateAssetTransfer] An error occured in the processing of Record Id : " + assetTransferFormUI.Tbl_AssetTransferId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAssetTransfer(AssetTransferFormUI assetTransferFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetTransfer_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetTransferId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetTransferId"].Value = assetTransferFormUI.Tbl_AssetTransferId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAssetTransferType()";
            logExcpUIobj.ResourceName = "AssetTransferFormDAL.CS";
            logExcpUIobj.RecordId = assetTransferFormUI.Tbl_AssetTransferId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetTransferFormDAL : DeleteAssetTransfer] An error occured in the processing of Record Id : " + assetTransferFormUI.Tbl_AssetTransferId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}