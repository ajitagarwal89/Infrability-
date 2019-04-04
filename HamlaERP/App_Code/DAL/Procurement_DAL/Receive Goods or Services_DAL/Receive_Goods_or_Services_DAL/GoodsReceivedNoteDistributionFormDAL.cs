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
/// Summary description for GoodsReceivedNoteDistributionFormDAL
/// </summary>
public class GoodsReceivedNoteDistributionFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    Audit_IUD audit_IUD = new Audit_IUD();

    public GoodsReceivedNoteDistributionFormDAL()
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
            logExcpUIobj.MethodName = "GoodsReceivedNoteDistributionFormDAL()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GoodsReceivedNoteDistributionFormDAL : GoodsReceivedNoteDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetGoodsReceivedNoteDistributionListById(GoodsReceivedNoteDistributionFormUI goodsReceivedNoteDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNoteDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteDistributionId"].Value = goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId;

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
                audit_IUD.WebServiceSelectInsert("tbl_GoodsReceivedNoteDistribution", goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getGoodsReceivedNoteDistributionListById()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDistributionFormDAL.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteDistributionFormDAL : getGoodsReceivedNoteDistributionListById] An error occured in the processing of Record Id : " + goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGoodsReceivedNoteDistribution(GoodsReceivedNoteDistributionFormUI goodsReceivedNoteDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNoteDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = goodsReceivedNoteDistributionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = goodsReceivedNoteDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteId"].Value = goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = goodsReceivedNoteDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_GLAccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_GLAccountType"].Value = goodsReceivedNoteDistributionFormUI.opt_GLAccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = goodsReceivedNoteDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = goodsReceivedNoteDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = goodsReceivedNoteDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = goodsReceivedNoteDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteDistributionId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteDistributionId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_GoodsReceivedNoteDistributionId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_GoodsReceivedNoteDistribution";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(goodsReceivedNoteDistributionFormUI);
                    audit_IUD.WebServiceInsert(goodsReceivedNoteDistributionFormUI.Tbl_OrganizationId, tableName, recordID, goodsReceivedNoteDistributionFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddGoodsReceivedNoteDistribution()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteDistributionFormDAL : AddGoodsReceivedNoteDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGoodsReceivedNoteDistribution(GoodsReceivedNoteDistributionFormUI goodsReceivedNoteDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNoteDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = goodsReceivedNoteDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = goodsReceivedNoteDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteDistributionId"].Value = goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteId"].Value = goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = goodsReceivedNoteDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_GLAccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_GLAccountType"].Value = goodsReceivedNoteDistributionFormUI.opt_GLAccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = goodsReceivedNoteDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = goodsReceivedNoteDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = goodsReceivedNoteDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = goodsReceivedNoteDistributionFormUI.Credit;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(goodsReceivedNoteDistributionFormUI);
                    audit_IUD.WebServiceUpdate(goodsReceivedNoteDistributionFormUI.Tbl_OrganizationId, "tbl_GoodsReceivedNoteDistribution", goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId, goodsReceivedNoteDistributionFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGoodsReceivedNoteDistribution()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDistributionFormDAL.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteDistributionFormDAL : UpdateGoodsReceivedNoteDistribution] An error occured in the processing of Record Id : " + goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGoodsReceivedNoteDistribution(GoodsReceivedNoteDistributionFormUI goodsReceivedNoteDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNoteDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteDistributionId"].Value = goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_GoodsReceivedNoteDistribution", goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGoodsReceivedNoteDistribution()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteDistributionFormDAL.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteDistributionFormDAL : DeleteGoodsReceivedNoteDistribution] An error occured in the processing of Record Id : " + goodsReceivedNoteDistributionFormUI.Tbl_GoodsReceivedNoteDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}