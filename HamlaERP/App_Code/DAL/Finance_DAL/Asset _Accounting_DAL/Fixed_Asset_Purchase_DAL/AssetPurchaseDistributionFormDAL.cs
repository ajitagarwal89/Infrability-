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
/// Summary description for AssetPurchaseDistributionFormDAL
/// </summary>
public class AssetPurchaseDistributionFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public AssetPurchaseDistributionFormDAL()
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
            logExcpUIobj.MethodName = "AssetPurchaseDistributionFormDAL()";
            logExcpUIobj.ResourceName = "AssetPurchaseDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AssetPurchaseDistributionFormDAL : AssetPurchaseDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAssetPurchaseDistributionListById(AssetPurchaseDistributionFormUI assetPurchaseDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AssetPurchaseDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetPurchaseDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetPurchaseDistributionId"].Value = assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId;

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
                audit_IUD.WebServiceSelectInsert("tbl_AssetPurchaseDistribution", assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getAssetPurchaseDistributionListById()";
            logExcpUIobj.ResourceName = "AssetPurchaseDistributionFormDAL.CS";
            logExcpUIobj.RecordId = assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetPurchaseDistributionFormDAL : getAssetPurchaseDistributionListById] An error occured in the processing of Record Id : " + assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddAssetPurchaseDistribution(AssetPurchaseDistributionFormUI assetPurchaseDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetPurchaseDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = assetPurchaseDistributionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetPurchaseDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetPurchaseId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetPurchaseId"].Value = assetPurchaseDistributionFormUI.Tbl_AssetPurchaseId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = assetPurchaseDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_GLAccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_GLAccountType"].Value = assetPurchaseDistributionFormUI.opt_GLAccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetPurchaseDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = assetPurchaseDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = assetPurchaseDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = assetPurchaseDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@tbl_AssetPurchaseDistributionId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_AssetPurchaseDistributionId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_AssetPurchaseDistributionId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_AssetPurchaseDistribution";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(assetPurchaseDistributionFormUI);
                    audit_IUD.WebServiceInsert(assetPurchaseDistributionFormUI.Tbl_OrganizationId, tableName, RecoredID, assetPurchaseDistributionFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddAssetPurchaseDistribution()";
            logExcpUIobj.ResourceName = "AssetPurchaseDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetPurchaseDistributionFormDAL : AddAssetPurchaseDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAssetPurchaseDistribution(AssetPurchaseDistributionFormUI assetPurchaseDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetPurchaseDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = assetPurchaseDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetPurchaseDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetPurchaseDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetPurchaseDistributionId"].Value = assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId;

                sqlCmd.Parameters.Add("@tbl_AssetPurchaseId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetPurchaseId"].Value = assetPurchaseDistributionFormUI.Tbl_AssetPurchaseId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = assetPurchaseDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_GLAccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_GLAccountType"].Value = assetPurchaseDistributionFormUI.opt_GLAccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetPurchaseDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = assetPurchaseDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = assetPurchaseDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = assetPurchaseDistributionFormUI.Credit;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(assetPurchaseDistributionFormUI);
                    audit_IUD.WebServiceUpdate(assetPurchaseDistributionFormUI.Tbl_OrganizationId, "tbl_AssetPurchaseDistribution", assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId, assetPurchaseDistributionFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAssetPurchaseDistribution()";
            logExcpUIobj.ResourceName = "AssetPurchaseDistributionFormDAL.CS";
            logExcpUIobj.RecordId = assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetPurchaseDistributionFormDAL : UpdateAssetPurchaseDistribution] An error occured in the processing of Record Id : " + assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAssetPurchaseDistribution(AssetPurchaseDistributionFormUI assetPurchaseDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetPurchaseDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetPurchaseDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetPurchaseDistributionId"].Value = assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_AssetPurchaseDistribution", assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAssetPurchaseDistribution()";
            logExcpUIobj.ResourceName = "AssetPurchaseDistributionFormDAL.CS";
            logExcpUIobj.RecordId = assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetPurchaseDistributionFormDAL : DeleteAssetPurchaseDistribution] An error occured in the processing of Record Id : " + assetPurchaseDistributionFormUI.Tbl_AssetPurchaseDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}