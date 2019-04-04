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
/// Summary description for AssetDisposalFormDAL
/// </summary>
public class AssetDisposalFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public AssetDisposalFormDAL()
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
            logExcpUIobj.MethodName = "AssetDisposalFormDAL()";
            logExcpUIobj.ResourceName = "AssetDisposalFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AssetDisposalFormDAL : AssetDisposalFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAssetDisposalListById(AssetDisposalFormUI assetDisposalFormUI)
    {


        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AssetDisposal_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetDisposalId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetDisposalId"].Value = assetDisposalFormUI.Tbl_AssetDisposalId;

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
                audit_IUD.WebServiceSelectInsert("tbl_AssetDisposal", assetDisposalFormUI.Tbl_AssetDisposalId, selectedValue);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetAssetDisposalListById()";
            logExcpUIobj.ResourceName = "AssetDisposalFormDAL.CS";
            logExcpUIobj.RecordId = assetDisposalFormUI.Tbl_AssetDisposalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetDisposalFormDAL : GetAssetDisposalListById] An error occured in the processing of Record Id : " + assetDisposalFormUI.Tbl_AssetDisposalId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddAssetDisposal(AssetDisposalFormUI assetDisposalFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetDisposal_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = assetDisposalFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetDisposalFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@AssetDisposalCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AssetDisposalCode"].Value = assetDisposalFormUI.AssetDisposalCode;

                sqlCmd.Parameters.Add("@tbl_AssetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId"].Value = assetDisposalFormUI.Tbl_AssetId;

                sqlCmd.Parameters.Add("@RetirementDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@RetirementDate"].Value = assetDisposalFormUI.RetirementDate;

                sqlCmd.Parameters.Add("@opt_RetirementType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_RetirementType"].Value = assetDisposalFormUI.opt_RetirementType;

                sqlCmd.Parameters.Add("@RetirementEvent", SqlDbType.NVarChar);
                sqlCmd.Parameters["@RetirementEvent"].Value = assetDisposalFormUI.RetirementEvent;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = assetDisposalFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_AssetDisposalId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_AssetDisposalId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_AssetDisposalId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_AssetDisposal";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(assetDisposalFormUI);
                    audit_IUD.WebServiceInsert(assetDisposalFormUI.Tbl_OrganizationId, tableName, RecoredID, assetDisposalFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddAssetDisposal()";
            logExcpUIobj.ResourceName = "AssetDisposalFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetDisposalFormDAL : AddAssetDisposal] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAssetDisposal(AssetDisposalFormUI assetDisposalFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetDisposal_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = assetDisposalFormUI.ModifiedBy;
                             

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetDisposalFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetDisposalId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetDisposalId"].Value = assetDisposalFormUI.Tbl_AssetDisposalId;

                sqlCmd.Parameters.Add("@AssetDisposalCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AssetDisposalCode"].Value = assetDisposalFormUI.AssetDisposalCode;

                sqlCmd.Parameters.Add("@tbl_AssetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId"].Value = assetDisposalFormUI.Tbl_AssetId;

                sqlCmd.Parameters.Add("@RetirementDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@RetirementDate"].Value = assetDisposalFormUI.RetirementDate;

                sqlCmd.Parameters.Add("@opt_RetirementType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_RetirementType"].Value = assetDisposalFormUI.opt_RetirementType;

                sqlCmd.Parameters.Add("@RetirementEvent", SqlDbType.NVarChar);
                sqlCmd.Parameters["@RetirementEvent"].Value = assetDisposalFormUI.RetirementEvent;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = assetDisposalFormUI.Tbl_CurrencyId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(assetDisposalFormUI);
                    audit_IUD.WebServiceUpdate(assetDisposalFormUI.Tbl_OrganizationId, "tbl_AssetDisposal", assetDisposalFormUI.Tbl_AssetDisposalId, assetDisposalFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAssetBookSetup()";
            logExcpUIobj.ResourceName = "AssetBookSetupFormDAL.CS";
            logExcpUIobj.RecordId = assetDisposalFormUI.Tbl_AssetDisposalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookSetupFormDAL : UpdateAssetBookSetup] An error occured in the processing of Record Id : " + assetDisposalFormUI.Tbl_AssetDisposalId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAssetDisposal(AssetDisposalFormUI assetDisposalFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetDisposal_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetDisposalId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetDisposalId"].Value = assetDisposalFormUI.Tbl_AssetDisposalId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_AssetDisposal", assetDisposalFormUI.Tbl_AssetDisposalId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAssetDisposal()";
            logExcpUIobj.ResourceName = "AssetPurchaseDetailsFormDAL.CS";
            logExcpUIobj.RecordId = assetDisposalFormUI.Tbl_AssetDisposalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetBookSetupFormDAL : DeleteAssetDisposal] An error occured in the processing of Record Id : " + assetDisposalFormUI.Tbl_AssetDisposalId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetSerialNumber(AssetDisposalFormUI assetDisposalFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AssetDisposal_SerialNumber", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@RecordType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@RecordType"].Value = assetDisposalFormUI.InvoiceType;

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
                audit_IUD.WebServiceSelectInsert("tbl_AssetDisposal", assetDisposalFormUI.Tbl_AssetDisposalId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSerialNumber()";
            logExcpUIobj.ResourceName = "AssetDisposalFormDAL.CS";
            logExcpUIobj.RecordId = assetDisposalFormUI.Tbl_AssetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetDisposalFormDAL : GetSerialNumber] An error occured in the processing of Record Id : " + assetDisposalFormUI.Tbl_AssetDisposalId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

}