using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for OrganizationFormDAL
/// </summary>
public class OrganizationFormDAL
{

    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public OrganizationFormDAL()
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
            logExcpUIobj.MethodName = "OrganizationFormDAL()";
            logExcpUIobj.ResourceName = "OrganizationFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[OrganizationFormDAL : OrganizationFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetOrganizationListById(OrganizationFormUI organizationFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Organization_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = organizationFormUI.Tbl_OrganizationId;

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
            logExcpUIobj.MethodName = "GetOrganizationListById()";
            logExcpUIobj.ResourceName = "OrganizationFormDAL.CS";
            logExcpUIobj.RecordId = organizationFormUI.Tbl_OrganizationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OrganizationFormDAL : GetOrganizationListById] An error occured in the processing of Record Id : " + organizationFormUI.Tbl_OrganizationId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddOrganization(OrganizationFormUI organizationFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Organization_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = organizationFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationTypeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationTypeId"].Value = organizationFormUI.Tbl_OrganizationTypeId;

                sqlCmd.Parameters.Add("@OrganizationCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OrganizationCode"].Value = organizationFormUI.OrganizationCode;

                sqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Name"].Value = organizationFormUI.Name;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = organizationFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = organizationFormUI.City;

                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = organizationFormUI.State;

                sqlCmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PostalCode"].Value = organizationFormUI.PostalCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = organizationFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@PhoneNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PhoneNo"].Value = organizationFormUI.PhoneNo;

                sqlCmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FaxNo"].Value = organizationFormUI.FaxNo;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = organizationFormUI.Mobile;

                sqlCmd.Parameters.Add("@WebSite", SqlDbType.NVarChar);
                sqlCmd.Parameters["@WebSite"].Value = organizationFormUI.WebSite;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = organizationFormUI.Email;

                sqlCmd.Parameters.Add("@Owner", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Owner"].Value = organizationFormUI.Owner;

                sqlCmd.Parameters.Add("@Logo", SqlDbType.Image);
                sqlCmd.Parameters["@Logo"].Value = organizationFormUI.Logo;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddOrganization()";
            logExcpUIobj.ResourceName = "OrganizationFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OrganizationFormDAL : AddOrganization] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateOrganization(OrganizationFormUI organizationFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Organization_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = organizationFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = organizationFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationTypeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationTypeId"].Value = organizationFormUI.Tbl_OrganizationTypeId;

                sqlCmd.Parameters.Add("@OrganizationCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OrganizationCode"].Value = organizationFormUI.OrganizationCode;

                sqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Name"].Value = organizationFormUI.Name;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = organizationFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = organizationFormUI.City;

                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = organizationFormUI.State;

                sqlCmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PostalCode"].Value = organizationFormUI.PostalCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = organizationFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@PhoneNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PhoneNo"].Value = organizationFormUI.PhoneNo;

                sqlCmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FaxNo"].Value = organizationFormUI.FaxNo;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = organizationFormUI.Mobile;

                sqlCmd.Parameters.Add("@WebSite", SqlDbType.NVarChar);
                sqlCmd.Parameters["@WebSite"].Value = organizationFormUI.WebSite;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = organizationFormUI.Email;

                sqlCmd.Parameters.Add("@Owner", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Owner"].Value = organizationFormUI.Owner;

                sqlCmd.Parameters.Add("@Logo", SqlDbType.Image);
                sqlCmd.Parameters["@Logo"].Value = organizationFormUI.Logo;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateOrganization()";
            logExcpUIobj.ResourceName = "OrganizationFormDAL.CS";
            logExcpUIobj.RecordId = organizationFormUI.Tbl_OrganizationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OrganizationFormDAL : UpdateOrganization] An error occured in the processing of Record Id : " + organizationFormUI.Tbl_OrganizationId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteOrganization(OrganizationFormUI organizationFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Organization_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = organizationFormUI.Tbl_OrganizationId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteOrganization()";
            logExcpUIobj.ResourceName = "OrganizationFormDAL.CS";
            logExcpUIobj.RecordId = organizationFormUI.Tbl_OrganizationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OrganizationFormDAL : DeleteOrganization] An error occured in the processing of Record Id : " + organizationFormUI.Tbl_OrganizationId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}