﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for AssetPurchaseFormDAL
/// </summary>
public class AssetPurchaseFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public AssetPurchaseFormDAL()
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
            logExcpUIobj.MethodName = "AssetPurchaseFormDAL()";
            logExcpUIobj.ResourceName = "AssetPurchaseFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AssetPurchaseFormDAL : AssetPurchaseFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetAssetPurchaseListById(AssetPurchaseFormUI AssetPurchaseFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AssetPurchase_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetPurchaseId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetPurchaseId"].Value = AssetPurchaseFormUI.Tbl_AssetPurchaseId;

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
            logExcpUIobj.MethodName = "getAssetPurchaseListById()";
            logExcpUIobj.ResourceName = "AssetPurchaseFormDAL.CS";
            logExcpUIobj.RecordId = AssetPurchaseFormUI.Tbl_AssetPurchaseId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetPurchaseFormDAL : getAssetPurchaseListById] An error occured in the processing of Record Id : " + AssetPurchaseFormUI.Tbl_AssetPurchaseId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddAssetPurchase(AssetPurchaseFormUI assetPurchaseFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetPurchase_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = assetPurchaseFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetPurchaseFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@opt_ReceiptType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_ReceiptType"].Value = assetPurchaseFormUI.opt_ReceiptType;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = assetPurchaseFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = assetPurchaseFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@SupplierDocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SupplierDocumentNumber"].Value = assetPurchaseFormUI.SupplierDocumentNumber;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = assetPurchaseFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@Date", SqlDbType.DateTime);
                sqlCmd.Parameters["@Date"].Value = assetPurchaseFormUI.Date;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = assetPurchaseFormUI.Tbl_BatchId;
                
                sqlCmd.Parameters.Add("@SubTotal", SqlDbType.Decimal);
                sqlCmd.Parameters["@SubTotal"].Value = assetPurchaseFormUI.SubTotal;


                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = assetPurchaseFormUI.TradeDiscount;


                sqlCmd.Parameters.Add("@Frieght", SqlDbType.Decimal);
                sqlCmd.Parameters["@Frieght"].Value = assetPurchaseFormUI.Frieght;

                sqlCmd.Parameters.Add("@Miscellaneous", SqlDbType.Decimal);
                sqlCmd.Parameters["@Miscellaneous"].Value = assetPurchaseFormUI.Miscellaneous;

                sqlCmd.Parameters.Add("@MainTotal", SqlDbType.Decimal);
                sqlCmd.Parameters["@MainTotal"].Value = assetPurchaseFormUI.MainTotal;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddAssetPurchase()";
            logExcpUIobj.ResourceName = "AssetPurchaseFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetPurchaseFormDAL : AddAssetPurchase] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAssetPurchase(AssetPurchaseFormUI assetPurchaseFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetPurchase_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = assetPurchaseFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetPurchaseFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetPurchaseId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetPurchaseId"].Value = assetPurchaseFormUI.Tbl_AssetPurchaseId;

                sqlCmd.Parameters.Add("@opt_ReceiptType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_ReceiptType"].Value = assetPurchaseFormUI.opt_ReceiptType;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = assetPurchaseFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = assetPurchaseFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@SupplierDocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SupplierDocumentNumber"].Value = assetPurchaseFormUI.SupplierDocumentNumber;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = assetPurchaseFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@Date", SqlDbType.DateTime);
                sqlCmd.Parameters["@Date"].Value = assetPurchaseFormUI.Date;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = assetPurchaseFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@SubTotal", SqlDbType.Decimal);
                sqlCmd.Parameters["@SubTotal"].Value = assetPurchaseFormUI.SubTotal;


                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = assetPurchaseFormUI.TradeDiscount;


                sqlCmd.Parameters.Add("@Frieght", SqlDbType.Decimal);
                sqlCmd.Parameters["@Frieght"].Value = assetPurchaseFormUI.Frieght;

                sqlCmd.Parameters.Add("@Miscellaneous", SqlDbType.Decimal);
                sqlCmd.Parameters["@Miscellaneous"].Value = assetPurchaseFormUI.Miscellaneous;

                sqlCmd.Parameters.Add("@MainTotal", SqlDbType.Decimal);
                sqlCmd.Parameters["@MainTotal"].Value = assetPurchaseFormUI.MainTotal;
                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAssetPurchase()";
            logExcpUIobj.ResourceName = "AssetPurchaseFormDAL.CS";
            logExcpUIobj.RecordId = assetPurchaseFormUI.Tbl_AssetPurchaseId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetPurchaseFormDAL : UpdateAssetPurchase] An error occured in the processing of Record Id : " + assetPurchaseFormUI.Tbl_AssetPurchaseId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAssetPurchase(AssetPurchaseFormUI assetPurchaseFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetPurchase_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetPurchaseId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetPurchaseId"].Value = assetPurchaseFormUI.Tbl_AssetPurchaseId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAssetPurchase()";
            logExcpUIobj.ResourceName = "AssetPurchaseFormDAL.CS";
            logExcpUIobj.RecordId = assetPurchaseFormUI.Tbl_AssetPurchaseId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetPurchaseFormDAL : DeleteAssetPurchase] An error occured in the processing of Record Id : " + assetPurchaseFormUI.Tbl_AssetPurchaseId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}