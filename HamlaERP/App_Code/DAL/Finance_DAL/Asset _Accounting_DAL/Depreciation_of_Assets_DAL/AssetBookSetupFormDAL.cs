using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for AssetBookSetupFormDAL
/// </summary>
public class AssetBookSetupFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public AssetBookSetupFormDAL()
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
            logExcpUIobj.MethodName = "AssetBookSetupFormDAL()";
            logExcpUIobj.ResourceName = "AssetBookSetupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AssetBookSetupFormDAL : AssetBookSetupFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAssetBookSetupListById(AssetBookSetupFormUI assetBookSetupFormUI)
    {


        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AssetBookSetup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetBookSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetBookSetupId"].Value = assetBookSetupFormUI.Tbl_AssetBookSetupId;

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
            logExcpUIobj.MethodName = "GetAssetBookSetupListById()";
            logExcpUIobj.ResourceName = "AssetBookSetupFormDAL.CS";
            logExcpUIobj.RecordId = assetBookSetupFormUI.Tbl_AssetBookSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookSetupFormDAL : GetAssetBookSetupListById] An error occured in the processing of Record Id : " + assetBookSetupFormUI.Tbl_AssetBookSetupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddAssetBookSetup(AssetBookSetupFormUI assetBookSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetBookSetup_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = assetBookSetupFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetBookSetupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@AssetBookSetupCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AssetBookSetupCode"].Value = assetBookSetupFormUI.AssetBookSetupCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetBookSetupFormUI.Description;

                sqlCmd.Parameters.Add("@opt_CurrentyFiscalYear", SqlDbType.Int);
                sqlCmd.Parameters["@opt_CurrentyFiscalYear"].Value = assetBookSetupFormUI.opt_CurrentyFiscalYear;

                sqlCmd.Parameters.Add("@opt_DepreciatedPeriod", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DepreciatedPeriod"].Value = assetBookSetupFormUI.opt_DepreciatedPeriod;



                result = sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddAssetBookSetup()";
            logExcpUIobj.ResourceName = "AssetBookSetupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookSetupFormDAL : AddAssetBookSetup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAssetBookSetup(AssetBookSetupFormUI assetBookSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetBookSetup_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = assetBookSetupFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetBookSetupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetBookSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetBookSetupId"].Value = assetBookSetupFormUI.Tbl_AssetBookSetupId;

                sqlCmd.Parameters.Add("@AssetBookSetupCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AssetBookSetupCode"].Value = assetBookSetupFormUI.AssetBookSetupCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetBookSetupFormUI.Description;

                sqlCmd.Parameters.Add("@opt_CurrentyFiscalYear", SqlDbType.Int);
                sqlCmd.Parameters["@opt_CurrentyFiscalYear"].Value = assetBookSetupFormUI.opt_CurrentyFiscalYear;

                sqlCmd.Parameters.Add("@opt_DepreciatedPeriod", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DepreciatedPeriod"].Value = assetBookSetupFormUI.opt_DepreciatedPeriod;

                result = sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAssetBookSetup()";
            logExcpUIobj.ResourceName = "AssetBookSetupFormDAL.CS";
            logExcpUIobj.RecordId = assetBookSetupFormUI.Tbl_AssetBookSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookSetupFormDAL : UpdateAssetBookSetup] An error occured in the processing of Record Id : " + assetBookSetupFormUI.Tbl_AssetBookSetupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAssetBookSetup(AssetBookSetupFormUI assetBookSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetBookSetup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetBookSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetBookSetupId"].Value = assetBookSetupFormUI.Tbl_AssetBookSetupId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAssetBookSetup()";
            logExcpUIobj.ResourceName = "AssetPurchaseDetailsFormDAL.CS";
            logExcpUIobj.RecordId = assetBookSetupFormUI.Tbl_AssetBookSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookSetupFormDAL : DeleteAssetBookSetup] An error occured in the processing of Record Id : " + assetBookSetupFormUI.Tbl_AssetBookSetupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}