using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;
/// <summary>
/// Summary description for AssetAndGroupAccountFormDAL
/// </summary>
public class AssetAndGroupAccountFormDAL
{

    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public AssetAndGroupAccountFormDAL()
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
            logExcpUIobj.MethodName = "AssetAndGroupAccountFormDAL()";
            logExcpUIobj.ResourceName = "AssetAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AssetAndGroupAccountFormDAL : AssetAndGroupAccountFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAssetAndGroupAccountListById(AssetAndGroupAccountFormUI assetAndGroupAccountFormUI)
    {


        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AssetAndGroupAccount_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetAndGroupAccountId"].Value = assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId;

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
            logExcpUIobj.MethodName = "GetAssetAndGroupAccountListById()";
            logExcpUIobj.ResourceName = "AssetAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId =assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetAndGroupAccountFormDAL : GetAssetAndGroupAccountListById] An error occured in the processing of Record Id : " + assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddAssetAndGroupAccount(AssetAndGroupAccountFormUI assetAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetAndGroupAccount_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = assetAndGroupAccountFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetAndGroupAccountFormUI.Tbl_OrganizationId;


                sqlCmd.Parameters.Add("@AccountCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AccountCode"].Value = assetAndGroupAccountFormUI.AccountCode;

                sqlCmd.Parameters.Add("@Opt_AccountType", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_AccountType"].Value = assetAndGroupAccountFormUI.Opt_AccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetAndGroupAccountFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_GLAccount_DepreciationExpense", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_DepreciationExpense"].Value = assetAndGroupAccountFormUI.Tbl_GLAccount_DepreciationExpense;

                sqlCmd.Parameters.Add("@tbl_GLAccount_AccumulatedDepreciation", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_AccumulatedDepreciation"].Value = assetAndGroupAccountFormUI.Tbl_GLAccount_AccumulatedDepreciation;

                sqlCmd.Parameters.Add("@tbl_GLAccount_PriorYearDepreciation", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_PriorYearDepreciation"].Value = assetAndGroupAccountFormUI.Tbl_GLAccount_PriorYearDepreciation;
                            
                sqlCmd.Parameters.Add("@tbl_GLAccount_AssetCost", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_AssetCost"].Value = assetAndGroupAccountFormUI.Tbl_GLAccount_AssetCost;
                              
                sqlCmd.Parameters.Add("@tbl_GLAccount_Clearing", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_Clearing"].Value = assetAndGroupAccountFormUI.Tbl_GLAccount_Clearing;

                result = sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddAssetAndGroupAccount()";
            logExcpUIobj.ResourceName = "AssetAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetAndGroupAccountFormDAL : AddAssetAndGroupAccount] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAssetAndGroupAccount(AssetAndGroupAccountFormUI assetAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetAndGroupAccount_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = assetAndGroupAccountFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetAndGroupAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AssetAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetAndGroupAccountId"].Value = assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId;

                sqlCmd.Parameters.Add("@AccountCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AccountCode"].Value = assetAndGroupAccountFormUI.AccountCode;

                sqlCmd.Parameters.Add("@Opt_AccountType", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_AccountType"].Value = assetAndGroupAccountFormUI.Opt_AccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetAndGroupAccountFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_GLAccount_DepreciationExpense", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_DepreciationExpense"].Value = assetAndGroupAccountFormUI.Tbl_GLAccount_DepreciationExpense;

                sqlCmd.Parameters.Add("@tbl_GLAccount_AccumulatedDepreciation", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_AccumulatedDepreciation"].Value = assetAndGroupAccountFormUI.Tbl_GLAccount_AccumulatedDepreciation;

                sqlCmd.Parameters.Add("@tbl_GLAccount_PriorYearDepreciation", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_PriorYearDepreciation"].Value = assetAndGroupAccountFormUI.Tbl_GLAccount_PriorYearDepreciation;
                
                sqlCmd.Parameters.Add("@tbl_GLAccount_AssetCost", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_AssetCost"].Value = assetAndGroupAccountFormUI.Tbl_GLAccount_AssetCost;
                                
                sqlCmd.Parameters.Add("@tbl_GLAccount_Clearing", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccount_Clearing"].Value = assetAndGroupAccountFormUI.Tbl_GLAccount_Clearing;
                
                result = sqlCmd.ExecuteNonQuery();
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAssetAndGroupAccount()";
            logExcpUIobj.ResourceName = "AssetAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetAndGroupAccountFormDAL : UpdateAssetAndGroupAccount] An error occured in the processing of Record Id : " + assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAssetAndGroupAccount(AssetAndGroupAccountFormUI assetAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetAndGroupAccount_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetAndGroupAccountId"].Value = assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAsset()";
            logExcpUIobj.ResourceName = "AssetFormDAL.CS";
            logExcpUIobj.RecordId = assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetAndGroupAccountFormDAL : DeleteAssetAndGroupAccount] An error occured in the processing of Record Id : " + assetAndGroupAccountFormUI.Tbl_AssetAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}