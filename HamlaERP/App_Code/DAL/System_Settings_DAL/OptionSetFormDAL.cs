using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for OptionSetFormDAL
/// </summary>
public class OptionSetFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public OptionSetFormDAL()
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
            logExcpUIobj.MethodName = "OptionSetFormDAL()";
            logExcpUIobj.ResourceName = "OptionSetFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[OptionSetFormDAL : OptionSetFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetOptionSetListById(OptionSetFormUI optionSetFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OptionSetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSetId"].Value = optionSetFormUI.Tbl_OptionSetId;

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
            logExcpUIobj.MethodName = "getOptionSetListById()";
            logExcpUIobj.ResourceName = "OptionSetFormDAL.CS";
            logExcpUIobj.RecordId = optionSetFormUI.Tbl_OptionSetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSetFormDAL : getOptionSetListById] An error occured in the processing of Record Id : " + optionSetFormUI.Tbl_OptionSetId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddOptionSet(OptionSetFormUI optionSetFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = optionSetFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = optionSetFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@TableName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@TableName"].Value = optionSetFormUI.ParentOptionSetValue;

                sqlCmd.Parameters.Add("@ParentOptionSetValue", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ParentOptionSetValue"].Value = optionSetFormUI.ParentOptionSetValue;

                sqlCmd.Parameters.Add("@OptionSetName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OptionSetName"].Value = optionSetFormUI.OptionSetName;

                sqlCmd.Parameters.Add("@OptionSetLable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OptionSetLable"].Value = optionSetFormUI.OptionSetLable;

                sqlCmd.Parameters.Add("@OptionSetValue", SqlDbType.BigInt);
                sqlCmd.Parameters["@OptionSetValue"].Value = optionSetFormUI.OptionSetValue;

                sqlCmd.Parameters.Add("@TableObjectId", SqlDbType.BigInt);
                sqlCmd.Parameters["@TableObjectId"].Value = optionSetFormUI.TableObjectId;

                sqlCmd.Parameters.Add("@ColumnId", SqlDbType.BigInt);
                sqlCmd.Parameters["@ColumnId"].Value = optionSetFormUI.ColumnId;
                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddOptionSet()";
            logExcpUIobj.ResourceName = "OptionSetFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSetFormDAL : AddOptionSet] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateOptionSet(OptionSetFormUI optionSetFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OptionSetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSetId"].Value = optionSetFormUI.Tbl_OptionSetId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = optionSetFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = optionSetFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@TableName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@TableName"].Value = optionSetFormUI.TableName;

                sqlCmd.Parameters.Add("@ParentOptionSetValue", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ParentOptionSetValue"].Value = optionSetFormUI.ParentOptionSetValue;

                sqlCmd.Parameters.Add("@OptionSetName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OptionSetName"].Value = optionSetFormUI.OptionSetName;

                sqlCmd.Parameters.Add("@OptionSetLable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OptionSetLable"].Value = optionSetFormUI.OptionSetLable;

                sqlCmd.Parameters.Add("@OptionSetValue", SqlDbType.BigInt);
                sqlCmd.Parameters["@OptionSetValue"].Value = optionSetFormUI.OptionSetValue;

                sqlCmd.Parameters.Add("@TableObjectId", SqlDbType.BigInt);
                sqlCmd.Parameters["@TableObjectId"].Value = optionSetFormUI.TableObjectId;

                sqlCmd.Parameters.Add("@ColumnId", SqlDbType.BigInt);
                sqlCmd.Parameters["@ColumnId"].Value = optionSetFormUI.ColumnId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateOptionSet()";
            logExcpUIobj.ResourceName = "OptionSetFormDAL.CS";
            logExcpUIobj.RecordId = optionSetFormUI.Tbl_OptionSetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSetFormDAL : UpdateOptionSet] An error occured in the processing of Record Id : " + optionSetFormUI.Tbl_OptionSetId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteOptionSet(OptionSetFormUI optionSetFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OptionSetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSetId"].Value = optionSetFormUI.Tbl_OptionSetId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteOptionSet()";
            logExcpUIobj.ResourceName = "OptionSetFormDAL.CS";
            logExcpUIobj.RecordId = optionSetFormUI.Tbl_OptionSetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSetFormDAL : DeleteOptionSet] An error occured in the processing of Record Id : " + optionSetFormUI.Tbl_OptionSetId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}