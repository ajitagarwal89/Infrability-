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
/// Summary description for AssetBookGroupSetupFormDAL
/// </summary>
public class AssetBookGroupSetupFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


    public AssetBookGroupSetupFormDAL()
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
            logExcpUIobj.MethodName = "AssetBookGroupSetupFormDAL()";
            logExcpUIobj.ResourceName = "AssetBookGroupSetupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AssetBookGroupSetupFormDAL : AssetBookGroupSetupFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAssetBookGroupSetupListById(AssetBookGroupSetupFormUI assetBookGroupSetupFormUI)
    {


        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AssetBookGroupSetup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetBookGroupSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetBookGroupSetupId"].Value = assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId;

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
                audit_IUD.WebServiceSelectInsert("tbl_AssetBookGroupSetup", assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetAssetBookGroupSetupListById()";
            logExcpUIobj.ResourceName = "AssetBookGroupSetupFormDAL.CS";
            logExcpUIobj.RecordId = assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookGroupSetupFormDAL : GetAssetBookGroupSetupListById] An error occured in the processing of Record Id : " + assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddAssetBookGroupSetup(AssetBookGroupSetupFormUI assetBookGroupSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetBookGroupSetup_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = assetBookGroupSetupFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetBookGroupSetupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@AssetBookGroupSetupCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AssetBookGroupSetupCode"].Value = assetBookGroupSetupFormUI.AssetBookGroupSetupCode;

                sqlCmd.Parameters.Add("@tbl_AssetBookSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetBookSetupId"].Value = assetBookGroupSetupFormUI.Tbl_AssetBookSetupId;

                sqlCmd.Parameters.Add("@tbl_AssetGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetGroupId"].Value = assetBookGroupSetupFormUI.Tbl_AssetGroupId;


                sqlCmd.Parameters.Add("@opt_DepreciationMethod", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DepreciationMethod"].Value = assetBookGroupSetupFormUI.opt_DepreciationMethod;


                sqlCmd.Parameters.Add("@opt_AveragingConvention", SqlDbType.Int);
                sqlCmd.Parameters["@opt_AveragingConvention"].Value = assetBookGroupSetupFormUI.opt_AveragingConvention;


                sqlCmd.Parameters.Add("@OriginalLifeYear", SqlDbType.Int);
                sqlCmd.Parameters["@OriginalLifeYear"].Value = assetBookGroupSetupFormUI.OriginalLifeYear;

                sqlCmd.Parameters.Add("@OriginalLifeDay", SqlDbType.Int);
                sqlCmd.Parameters["@OriginalLifeDay"].Value = assetBookGroupSetupFormUI.OriginalLifeDay;

                sqlCmd.Parameters.Add("@ScrapValue", SqlDbType.Decimal);
                sqlCmd.Parameters["@ScrapValue"].Value = assetBookGroupSetupFormUI.ScrapValue;

                sqlCmd.Parameters.Add("@tbl_AssetBookGroupSetupID", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_AssetBookGroupSetupID"].Direction = ParameterDirection.Output;


                result = sqlCmd.ExecuteNonQuery();


                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_AssetBookGroupSetupId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_AssetBookGroupSetup";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(assetBookGroupSetupFormUI);
                    audit_IUD.WebServiceInsert(assetBookGroupSetupFormUI.Tbl_OrganizationId, tableName, RecoredID, assetBookGroupSetupFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddAssetBookGroupSetup()";
            logExcpUIobj.ResourceName = "AssetBookGroupSetupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookGroupSetupFormDAL : AddAssetBookGroupSetup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAssetBookGroupSetup(AssetBookGroupSetupFormUI assetBookGroupSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetBookGroupSetup_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = assetBookGroupSetupFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetBookGroupSetupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetBookGroupSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetBookGroupSetupId"].Value = assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId;

                sqlCmd.Parameters.Add("@AssetBookGroupSetupCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AssetBookGroupSetupCode"].Value = assetBookGroupSetupFormUI.AssetBookGroupSetupCode;

                sqlCmd.Parameters.Add("@tbl_AssetBookSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetBookSetupId"].Value = assetBookGroupSetupFormUI.Tbl_AssetBookSetupId;

                sqlCmd.Parameters.Add("@tbl_AssetGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetGroupId"].Value = assetBookGroupSetupFormUI.Tbl_AssetGroupId;


                sqlCmd.Parameters.Add("@opt_DepreciationMethod", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DepreciationMethod"].Value = assetBookGroupSetupFormUI.opt_DepreciationMethod;


                sqlCmd.Parameters.Add("@opt_AveragingConvention", SqlDbType.Int);
                sqlCmd.Parameters["@opt_AveragingConvention"].Value = assetBookGroupSetupFormUI.opt_AveragingConvention;


                sqlCmd.Parameters.Add("@OriginalLifeYear", SqlDbType.Int);
                sqlCmd.Parameters["@OriginalLifeYear"].Value = assetBookGroupSetupFormUI.OriginalLifeYear;

                sqlCmd.Parameters.Add("@OriginalLifeDay", SqlDbType.Int);
                sqlCmd.Parameters["@OriginalLifeDay"].Value = assetBookGroupSetupFormUI.OriginalLifeDay;

                sqlCmd.Parameters.Add("@ScrapValue", SqlDbType.Decimal);
                sqlCmd.Parameters["@ScrapValue"].Value = assetBookGroupSetupFormUI.ScrapValue;


                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(assetBookGroupSetupFormUI);
                    audit_IUD.WebServiceUpdate(assetBookGroupSetupFormUI.Tbl_OrganizationId, "tbl_AssetBookGroupSetup", assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId, assetBookGroupSetupFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAssetBookGroupSetup()";
            logExcpUIobj.ResourceName = "AssetBookGroupSetupFormDAL.CS";
            logExcpUIobj.RecordId = assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookGroupSetupFormDAL : UpdateAsset] An error occured in the processing of Record Id : " + assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAssetBookGroupSetup(AssetBookGroupSetupFormUI assetBookGroupSetupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetBookGroupSetup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetBookGroupSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetBookGroupSetupId"].Value = assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_AssetBookGroupSetup", assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAsset()";
            logExcpUIobj.ResourceName = "AssetBookGroupSetupFormDAL.CS";
            logExcpUIobj.RecordId = assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookGroupSetupFormDAL : DeleteAsset] An error occured in the processing of Record Id : " + assetBookGroupSetupFormUI.Tbl_AssetBookGroupSetupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}