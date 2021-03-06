﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for AssetDisposalDetailsFormDAL
/// </summary>
public class AssetDisposalDetailsFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public AssetDisposalDetailsFormDAL()
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
            logExcpUIobj.MethodName = "AssetDisposalDetailsFormDAL()";
            logExcpUIobj.ResourceName = "AssetDisposalDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AssetDisposalDetailsFormDAL : AssetDisposalDetailsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetAssetDisposalDetailsListById(AssetDisposalDetailsFormUI assetDisposalDetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AssetDisposalDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetDisposalDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetDisposalDetailsId"].Value = assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId;

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
            logExcpUIobj.MethodName = "getAssetDisposalDetailsListById()";
            logExcpUIobj.ResourceName = "AssetDisposalDetailsFormDAL.CS";
            logExcpUIobj.RecordId = assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetDisposalDetailsFormDAL : getAssetDisposalDetailsListById] An error occured in the processing of Record Id : " + assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddAssetDisposalDetails(AssetDisposalDetailsFormUI assetDisposalDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetDisposalDetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = assetDisposalDetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetDisposalDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetDisposalId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetDisposalId"].Value = assetDisposalDetailsFormUI.Tbl_AssetDisposalId;

                sqlCmd.Parameters.Add("@Quantity", SqlDbType.Decimal);
                sqlCmd.Parameters["@Quantity"].Value = assetDisposalDetailsFormUI.Quantity;

                sqlCmd.Parameters.Add("@Cost", SqlDbType.Decimal);
                sqlCmd.Parameters["@Cost"].Value = assetDisposalDetailsFormUI.Cost;

                sqlCmd.Parameters.Add("@Percent", SqlDbType.Decimal);
                sqlCmd.Parameters["@Percent"].Value = assetDisposalDetailsFormUI.Percent;

                sqlCmd.Parameters.Add("@CashProceeds", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashProceeds"].Value = assetDisposalDetailsFormUI.CashProceeds;

                sqlCmd.Parameters.Add("@NonCashProceeds", SqlDbType.Decimal);
                sqlCmd.Parameters["@NonCashProceeds"].Value = assetDisposalDetailsFormUI.NonCashProceeds;

                sqlCmd.Parameters.Add("@ExpensesOfSales", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExpensesOfSales"].Value = assetDisposalDetailsFormUI.ExpensesOfSales;

                sqlCmd.Parameters.Add("@OriginatingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingAmount"].Value = assetDisposalDetailsFormUI.OriginatingAmount;
                
                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddAssetDisposalDetails()";
            logExcpUIobj.ResourceName = "AssetDisposalDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetDisposalDetailsFormDAL : AddAssetDisposalDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAssetDisposalDetails(AssetDisposalDetailsFormUI assetDisposalDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetDisposalDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = assetDisposalDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetDisposalDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetDisposalDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetDisposalDetailsId"].Value = assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId;

                sqlCmd.Parameters.Add("@tbl_AssetDisposalId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetDisposalId"].Value = assetDisposalDetailsFormUI.Tbl_AssetDisposalId;

                sqlCmd.Parameters.Add("@Quantity", SqlDbType.Decimal);
                sqlCmd.Parameters["@Quantity"].Value = assetDisposalDetailsFormUI.Quantity;

                sqlCmd.Parameters.Add("@Cost", SqlDbType.Decimal);
                sqlCmd.Parameters["@Cost"].Value = assetDisposalDetailsFormUI.Cost;

                sqlCmd.Parameters.Add("@Percent", SqlDbType.Decimal);
                sqlCmd.Parameters["@Percent"].Value = assetDisposalDetailsFormUI.Percent;

                sqlCmd.Parameters.Add("@CashProceeds", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashProceeds"].Value = assetDisposalDetailsFormUI.CashProceeds;

                sqlCmd.Parameters.Add("@NonCashProceeds", SqlDbType.Decimal);
                sqlCmd.Parameters["@NonCashProceeds"].Value = assetDisposalDetailsFormUI.NonCashProceeds;

                sqlCmd.Parameters.Add("@ExpensesOfSales", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExpensesOfSales"].Value = assetDisposalDetailsFormUI.ExpensesOfSales;

                sqlCmd.Parameters.Add("@OriginatingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingAmount"].Value = assetDisposalDetailsFormUI.OriginatingAmount;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAssetDisposalDetails()";
            logExcpUIobj.ResourceName = "AssetDisposalDetailsFormDAL.CS";
            logExcpUIobj.RecordId = assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetDisposalDetailsFormDAL : UpdateAssetDisposalDetails] An error occured in the processing of Record Id : " + assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAssetDisposalDetails(AssetDisposalDetailsFormUI assetDisposalDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetDisposalDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetDisposalDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetDisposalDetailsId"].Value = assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAssetDisposalDetails()";
            logExcpUIobj.ResourceName = "AssetDisposalDetailsFormDAL.CS";
            logExcpUIobj.RecordId = assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetDisposalDetailsFormDAL : DeleteAssetDisposalDetails] An error occured in the processing of Record Id : " + assetDisposalDetailsFormUI.Tbl_AssetDisposalDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}