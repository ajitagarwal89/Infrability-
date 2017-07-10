using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for AssetGroupFormDAL
/// </summary>
public class AssetGroupFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public AssetGroupFormDAL()
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
            logExcpUIobj.MethodName = "AssetGroupFormDAL()";
            logExcpUIobj.ResourceName = "AssetGroupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AssetGroupFormDAL : AssetGroupFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAssetGroupListById(AssetGroupFormUI assetGroupFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AssetGroup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetGroupId"].Value = assetGroupFormUI.Tbl_AssetGroupId;

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
            logExcpUIobj.MethodName = "getAssetGroupListById()";
            logExcpUIobj.ResourceName = "AssetGroupFormDAL.CS";
            logExcpUIobj.RecordId = assetGroupFormUI.Tbl_AssetGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetGroupFormDAL : getAssetGroupListById] An error occured in the processing of Record Id : " + assetGroupFormUI.Tbl_AssetGroupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddAssetGroup(AssetGroupFormUI assetGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetGroup_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = assetGroupFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetGroupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetGroupFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_AssetAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetAndGroupAccountId"].Value = assetGroupFormUI.Tbl_AssetAndGroupAccountId;

                sqlCmd.Parameters.Add("@tbl_InsuranceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_InsuranceId"].Value = assetGroupFormUI.Tbl_InsuranceId;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddAssetGroup()";
            logExcpUIobj.ResourceName = "AssetGroupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetGroupFormDAL : AddAssetGroup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAssetGroup(AssetGroupFormUI assetGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetGroup_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Tbl_AssetGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_AssetGroupId"].Value = assetGroupFormUI.Tbl_AssetGroupId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = assetGroupFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = assetGroupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = assetGroupFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_AssetAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetAndGroupAccountId"].Value = assetGroupFormUI.Tbl_AssetAndGroupAccountId;

                sqlCmd.Parameters.Add("@tbl_InsuranceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_InsuranceId"].Value = assetGroupFormUI.Tbl_InsuranceId;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAssetGroup()";
            logExcpUIobj.ResourceName = "AssetGroupFormDAL.CS";
            logExcpUIobj.RecordId = assetGroupFormUI.Tbl_AssetGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetGroupFormDAL : UpdateAssetGroup] An error occured in the processing of Record Id : " + assetGroupFormUI.Tbl_AssetGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAssetGroup(AssetGroupFormUI assetGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AssetGroup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AssetGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AssetGroupId"].Value = assetGroupFormUI.Tbl_AssetGroupId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAssetGroup()";
            logExcpUIobj.ResourceName = "AssetGroupFormDAL.CS";
            logExcpUIobj.RecordId = assetGroupFormUI.Tbl_AssetGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AssetGroupFormDAL : DeleteAssetGroup] An error occured in the processing of Record Id : " + assetGroupFormUI.Tbl_AssetGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}