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
/// Summary description for GoodsReceivedNoteDetailsFormDAL
/// </summary>
public class GoodsReceivedNoteDetailsFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    Audit_IUD audit_IUD = new Audit_IUD();

    public GoodsReceivedNoteDetailsFormDAL()
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
            logExcpUIobj.MethodName = "GoodsReceivedNoteDetailsFormDAL()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GoodsReceivedNoteDetailsFormDAL : GoodsReceivedNoteDetailsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetGoodsReceivedNoteDetailsListById(GoodsReceivedNoteDetailsFormUI goodsReceivedNoteDetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNoteDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteDetailsId"].Value = goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId;

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
                audit_IUD.WebServiceSelectInsert("tbl_GoodsReceivedNoteDetails", goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getGoodsReceivedNoteDetailsListById()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDetailsFormDAL.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteDetailsFormDAL : getGoodsReceivedNoteDetailsListById] An error occured in the processing of Record Id : " + goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGoodsReceivedNoteDetails(GoodsReceivedNoteDetailsFormUI goodsReceivedNoteDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNoteDetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = goodsReceivedNoteDetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = goodsReceivedNoteDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteId"].Value = goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteId;

                sqlCmd.Parameters.Add("@tbl_POId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POId"].Value = goodsReceivedNoteDetailsFormUI.Tbl_POId;

                sqlCmd.Parameters.Add("@tbl_AssetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId"].Value = goodsReceivedNoteDetailsFormUI.Tbl_AssetId;

                sqlCmd.Parameters.Add("@UOM", SqlDbType.NVarChar);
                sqlCmd.Parameters["@UOM"].Value = goodsReceivedNoteDetailsFormUI.UOM;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = goodsReceivedNoteDetailsFormUI.Tbl_LocationId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = goodsReceivedNoteDetailsFormUI.Description;

                sqlCmd.Parameters.Add("@QuantityOrdered", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityOrdered"].Value = goodsReceivedNoteDetailsFormUI.QuantityOrdered;

                sqlCmd.Parameters.Add("@QuantityShipped", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityShipped"].Value = goodsReceivedNoteDetailsFormUI.QuantityShipped;

                sqlCmd.Parameters.Add("@QuantityInvoiced", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityInvoiced"].Value = goodsReceivedNoteDetailsFormUI.QuantityInvoiced;

                sqlCmd.Parameters.Add("@PreviouslyShipped", SqlDbType.Decimal);
                sqlCmd.Parameters["@PreviouslyShipped"].Value = goodsReceivedNoteDetailsFormUI.PreviouslyShipped;

                sqlCmd.Parameters.Add("@PreviouslyInvoiced", SqlDbType.Decimal);
                sqlCmd.Parameters["@PreviouslyInvoiced"].Value = goodsReceivedNoteDetailsFormUI.PreviouslyInvoiced;

                sqlCmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@UnitCost"].Value = goodsReceivedNoteDetailsFormUI.UnitCost;

                sqlCmd.Parameters.Add("@ExtendedCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExtendedCost"].Value = goodsReceivedNoteDetailsFormUI.ExtendedCost;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteDetailsId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteDetailsId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_GoodsReceivedNoteDetailsId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_GoodsReceivedNoteDetails";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(goodsReceivedNoteDetailsFormUI);
                    audit_IUD.WebServiceInsert(goodsReceivedNoteDetailsFormUI.Tbl_OrganizationId, tableName, recordID, goodsReceivedNoteDetailsFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddGoodsReceivedNoteDetails()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteDetailsFormDAL : AddGoodsReceivedNoteDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGoodsReceivedNoteDetails(GoodsReceivedNoteDetailsFormUI goodsReceivedNoteDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNoteDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = goodsReceivedNoteDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = goodsReceivedNoteDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteDetailsId"].Value = goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteId"].Value = goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteId;

                sqlCmd.Parameters.Add("@tbl_POId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POId"].Value = goodsReceivedNoteDetailsFormUI.Tbl_POId;

                sqlCmd.Parameters.Add("@tbl_AssetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetId"].Value = goodsReceivedNoteDetailsFormUI.Tbl_AssetId;

                sqlCmd.Parameters.Add("@UOM", SqlDbType.NVarChar);
                sqlCmd.Parameters["@UOM"].Value = goodsReceivedNoteDetailsFormUI.UOM;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = goodsReceivedNoteDetailsFormUI.Tbl_LocationId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = goodsReceivedNoteDetailsFormUI.Description;

                sqlCmd.Parameters.Add("@QuantityOrdered", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityOrdered"].Value = goodsReceivedNoteDetailsFormUI.QuantityOrdered;

                sqlCmd.Parameters.Add("@QuantityShipped", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityShipped"].Value = goodsReceivedNoteDetailsFormUI.QuantityShipped;

                sqlCmd.Parameters.Add("@QuantityInvoiced", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityInvoiced"].Value = goodsReceivedNoteDetailsFormUI.QuantityInvoiced;

                sqlCmd.Parameters.Add("@PreviouslyShipped", SqlDbType.Decimal);
                sqlCmd.Parameters["@PreviouslyShipped"].Value = goodsReceivedNoteDetailsFormUI.PreviouslyShipped;

                sqlCmd.Parameters.Add("@PreviouslyInvoiced", SqlDbType.Decimal);
                sqlCmd.Parameters["@PreviouslyInvoiced"].Value = goodsReceivedNoteDetailsFormUI.PreviouslyInvoiced;

                sqlCmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@UnitCost"].Value = goodsReceivedNoteDetailsFormUI.UnitCost;

                sqlCmd.Parameters.Add("@ExtendedCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExtendedCost"].Value = goodsReceivedNoteDetailsFormUI.ExtendedCost;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(goodsReceivedNoteDetailsFormUI);
                    audit_IUD.WebServiceUpdate(goodsReceivedNoteDetailsFormUI.Tbl_OrganizationId, "Tbl_GoodsReceivedNoteDetails", goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId, goodsReceivedNoteDetailsFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGoodsReceivedNoteDetails()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDetailsFormDAL.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteDetailsFormDAL : UpdateGoodsReceivedNoteDetails] An error occured in the processing of Record Id : " + goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGoodsReceivedNoteDetails(GoodsReceivedNoteDetailsFormUI goodsReceivedNoteDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNoteDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteDetailsId"].Value = goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_GoodsReceivedNoteDetails", goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGoodsReceivedNoteDetails()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDetailsFormDAL.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteDetailsFormDAL : DeleteGoodsReceivedNoteDetails] An error occured in the processing of Record Id : " + goodsReceivedNoteDetailsFormUI.Tbl_GoodsReceivedNoteDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}