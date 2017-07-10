using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for GoodsReceivedNoteFormDAL
/// </summary>
public class GoodsReceivedNoteFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public GoodsReceivedNoteFormDAL()
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
            logExcpUIobj.MethodName = "GoodsReceivedNoteFormDAL()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GoodsReceivedNoteFormDAL : GoodsReceivedNoteFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetGoodsReceivedNoteListById(GoodsReceivedNoteFormUI goodsReceivedNoteFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNote_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteId"].Value = goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId;

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
            logExcpUIobj.MethodName = "getGoodsReceivedNoteListById()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteFormDAL.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteFormDAL : getGoodsReceivedNoteListById] An error occured in the processing of Record Id : " + goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGoodsReceivedNote(GoodsReceivedNoteFormUI goodsReceivedNoteFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNote_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = goodsReceivedNoteFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = goodsReceivedNoteFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@opt_ReceivedType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_ReceivedType"].Value = goodsReceivedNoteFormUI.opt_ReceivedType;

                sqlCmd.Parameters.Add("@GoodsReceivedNoteNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@GoodsReceivedNoteNumber"].Value = goodsReceivedNoteFormUI.GoodsReceivedNoteNumber;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = goodsReceivedNoteFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@SupplierDocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SupplierDocumentNumber"].Value = goodsReceivedNoteFormUI.SupplierDocumentNumber;

                sqlCmd.Parameters.Add("@Date", SqlDbType.DateTime);
                sqlCmd.Parameters["@Date"].Value = goodsReceivedNoteFormUI.Date;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = goodsReceivedNoteFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = goodsReceivedNoteFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@SubTotal", SqlDbType.Decimal);
                sqlCmd.Parameters["@SubTotal"].Value = goodsReceivedNoteFormUI.SubTotal;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = goodsReceivedNoteFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Freight", SqlDbType.Decimal);
                sqlCmd.Parameters["@Freight"].Value = goodsReceivedNoteFormUI.Freight;

                sqlCmd.Parameters.Add("@Miscellaneous", SqlDbType.Decimal);
                sqlCmd.Parameters["@Miscellaneous"].Value = goodsReceivedNoteFormUI.Miscellaneous;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = goodsReceivedNoteFormUI.Total;
                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddGoodsReceivedNote()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteFormDAL : AddGoodsReceivedNote] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGoodsReceivedNote(GoodsReceivedNoteFormUI goodsReceivedNoteFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNote_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = goodsReceivedNoteFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = goodsReceivedNoteFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteId"].Value = goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId;

                sqlCmd.Parameters.Add("@opt_ReceivedType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_ReceivedType"].Value = goodsReceivedNoteFormUI.opt_ReceivedType;

                sqlCmd.Parameters.Add("@GoodsReceivedNoteNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@GoodsReceivedNoteNumber"].Value = goodsReceivedNoteFormUI.GoodsReceivedNoteNumber;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = goodsReceivedNoteFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@SupplierDocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SupplierDocumentNumber"].Value = goodsReceivedNoteFormUI.SupplierDocumentNumber;

                sqlCmd.Parameters.Add("@Date", SqlDbType.DateTime);
                sqlCmd.Parameters["@Date"].Value = goodsReceivedNoteFormUI.Date;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = goodsReceivedNoteFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = goodsReceivedNoteFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@SubTotal", SqlDbType.Decimal);
                sqlCmd.Parameters["@SubTotal"].Value = goodsReceivedNoteFormUI.SubTotal;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = goodsReceivedNoteFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Freight", SqlDbType.Decimal);
                sqlCmd.Parameters["@Freight"].Value = goodsReceivedNoteFormUI.Freight;

                sqlCmd.Parameters.Add("@Miscellaneous", SqlDbType.Decimal);
                sqlCmd.Parameters["@Miscellaneous"].Value = goodsReceivedNoteFormUI.Miscellaneous;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = goodsReceivedNoteFormUI.Total;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGoodsReceivedNote()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteFormDAL.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteFormDAL : UpdateGoodsReceivedNote] An error occured in the processing of Record Id : " + goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGoodsReceivedNote(GoodsReceivedNoteFormUI goodsReceivedNoteFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GoodsReceivedNote_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteId"].Value = goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGoodsReceivedNote()";
            logExcpUIobj.ResourceName = "GoodsReceivedNoteFormDAL.CS";
            logExcpUIobj.RecordId = goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GoodsReceivedNoteFormDAL : DeleteGoodsReceivedNote] An error occured in the processing of Record Id : " + goodsReceivedNoteFormUI.Tbl_GoodsReceivedNoteId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}