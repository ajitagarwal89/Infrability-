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
/// Summary description for PODetailsFormDAL
/// </summary>
public class PODetailsFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


    public PODetailsFormDAL()
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
            logExcpUIobj.MethodName = "PODetailsFormDAL()";
            logExcpUIobj.ResourceName = "PODetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PODetailsFormDAL : PODetailsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetPODetailsListById(PODetailsFormUI pODetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PODetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PODetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PODetailsId"].Value = pODetailsFormUI.Tbl_PODetailsId;

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
                audit_IUD.WebServiceSelectInsert("tbl_PODetails", pODetailsFormUI.Tbl_PODetailsId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getPODetailsListById()";
            logExcpUIobj.ResourceName = "PODetailsFormDAL.CS";
            logExcpUIobj.RecordId = pODetailsFormUI.Tbl_PODetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PODetailsFormDAL : getPODetailsListById] An error occured in the processing of Record Id : " + pODetailsFormUI.Tbl_PODetailsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPODetails(PODetailsFormUI pODetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PODetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = pODetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pODetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_POId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POId"].Value = pODetailsFormUI.Tbl_POId;

                sqlCmd.Parameters.Add("@tbl_AssetId_FixedAsset", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId_FixedAsset"].Value = pODetailsFormUI.Tbl_AssetId_FixedAsset;

                sqlCmd.Parameters.Add("@UOM", SqlDbType.NVarChar);
                sqlCmd.Parameters["@UOM"].Value = pODetailsFormUI.UOM;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = pODetailsFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = pODetailsFormUI.Tbl_LocationId;



                sqlCmd.Parameters.Add("@QuantityOrdered", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityOrdered"].Value = pODetailsFormUI.QuantityOrdered;


                sqlCmd.Parameters.Add("@QuantityCanceled", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityCanceled"].Value = pODetailsFormUI.QuantityCanceled;

                sqlCmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@UnitCost"].Value = pODetailsFormUI.UnitCost;

                sqlCmd.Parameters.Add("@ExtendedCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExtendedCost"].Value = pODetailsFormUI.ExtendedCost;

                sqlCmd.Parameters.Add("@tbl_PODetailsId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_PODetailsId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_PODetailsId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_PODetails";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(pODetailsFormUI);
                    audit_IUD.WebServiceInsert(pODetailsFormUI.Tbl_OrganizationId, tableName, RecoredID, pODetailsFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddPODetails()";
            logExcpUIobj.ResourceName = "PODetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PODetailsFormDAL : AddPODetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePODetails(PODetailsFormUI pODetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PODetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Tbl_PODetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PODetailsId"].Value = pODetailsFormUI.Tbl_PODetailsId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = pODetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pODetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_POId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POId"].Value = pODetailsFormUI.Tbl_POId;

                sqlCmd.Parameters.Add("@tbl_AssetId_FixedAsset", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId_FixedAsset"].Value = pODetailsFormUI.Tbl_AssetId_FixedAsset;

                sqlCmd.Parameters.Add("@UOM", SqlDbType.NVarChar);
                sqlCmd.Parameters["@UOM"].Value = pODetailsFormUI.UOM;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = pODetailsFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = pODetailsFormUI.Tbl_LocationId;

                sqlCmd.Parameters.Add("@QuantityOrdered", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityOrdered"].Value = pODetailsFormUI.QuantityOrdered;


                sqlCmd.Parameters.Add("@QuantityCanceled", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityCanceled"].Value = pODetailsFormUI.QuantityCanceled;

                sqlCmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@UnitCost"].Value = pODetailsFormUI.UnitCost;

                sqlCmd.Parameters.Add("@ExtendedCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExtendedCost"].Value = pODetailsFormUI.ExtendedCost;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(pODetailsFormUI);
                    audit_IUD.WebServiceUpdate(pODetailsFormUI.Tbl_OrganizationId, "tbl_PODetails", pODetailsFormUI.Tbl_PODetailsId, pODetailsFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePODetails()";
            logExcpUIobj.ResourceName = "PODetailsFormDAL.CS";
            logExcpUIobj.RecordId = pODetailsFormUI.Tbl_PODetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PODetailsFormDAL : UpdatePODetails] An error occured in the processing of Record Id : " + pODetailsFormUI.Tbl_PODetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePODetails(PODetailsFormUI pODetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PODetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PODetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PODetailsId"].Value = pODetailsFormUI.Tbl_PODetailsId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_PODetails", pODetailsFormUI.Tbl_PODetailsId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePODetails()";
            logExcpUIobj.ResourceName = "PODetailsFormDAL.CS";
            logExcpUIobj.RecordId = pODetailsFormUI.Tbl_PODetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PODetailsFormDAL : DeletePODetails] An error occured in the processing of Record Id : " + pODetailsFormUI.Tbl_PODetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}