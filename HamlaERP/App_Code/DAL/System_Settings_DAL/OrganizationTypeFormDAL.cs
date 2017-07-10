using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for OrganizationTypeFormDAL
/// </summary>
public class OrganizationTypeFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public OrganizationTypeFormDAL()
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
            logExcpUIobj.MethodName = "OrganizationTypeFormDAL()";
            logExcpUIobj.ResourceName = "OrganizationTypeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[OrganizationTypeFormDAL : OrganizationTypeFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetOrganizationTypeListById(OrganizationTypeFormUI organizationTypeFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_OrganizationType_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OrganizationTypeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationTypeId"].Value = organizationTypeFormUI.Tbl_OrganizationTypeId;

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
            logExcpUIobj.MethodName = "getOrganizationTypeListById()";
            logExcpUIobj.ResourceName = "OrganizationTypeFormDAL.CS";
            logExcpUIobj.RecordId = organizationTypeFormUI.Tbl_OrganizationTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OrganizationTypeFormDAL : getOrganizationTypeListById] An error occured in the processing of Record Id : " + organizationTypeFormUI.Tbl_OrganizationTypeId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddOrganizationType(OrganizationTypeFormUI organizationTypeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_OrganizationType_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = organizationTypeFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@OrganizationType", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OrganizationType"].Value = organizationTypeFormUI.OrganizationType;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddOrganizationType()";
            logExcpUIobj.ResourceName = "OrganizationTypeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OrganizationTypeFormDAL : AddOrganizationType] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateOrganizationType(OrganizationTypeFormUI organizationTypeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_OrganizationType_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Tbl_OrganizationTypeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_OrganizationTypeId"].Value = organizationTypeFormUI.Tbl_OrganizationTypeId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = organizationTypeFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@OrganizationType", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OrganizationType"].Value = organizationTypeFormUI.OrganizationType;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
             logExcpUIobj.MethodName = "UpdateOrganizationType()";
            logExcpUIobj.ResourceName = "OrganizationTypeFormDAL.CS";
            logExcpUIobj.RecordId = organizationTypeFormUI.Tbl_OrganizationTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OrganizationTypeFormDAL : UpdateOrganizationType] An error occured in the processing of Record Id : " + organizationTypeFormUI.Tbl_OrganizationTypeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteOrganizationType(OrganizationTypeFormUI organizationTypeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_OrganizationType_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OrganizationTypeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationTypeId"].Value = organizationTypeFormUI.Tbl_OrganizationTypeId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
             logExcpUIobj.MethodName = "DeleteOrganizationType()";
            logExcpUIobj.ResourceName = "OrganizationTypeFormDAL.CS";
            logExcpUIobj.RecordId = organizationTypeFormUI.Tbl_OrganizationTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OrganizationTypeFormDAL : DeleteOrganizationType] An error occured in the processing of Record Id : " + organizationTypeFormUI.Tbl_OrganizationTypeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}