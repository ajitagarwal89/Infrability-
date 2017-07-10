using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for LocationFormDAL
/// </summary>
public class LocationFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public LocationFormDAL()
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
            logExcpUIobj.MethodName = "LocationFormDAL()";
            logExcpUIobj.ResourceName = "LocationFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[LocationFormDAL : LocationFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetLocationListById(LocationFormUI locationFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Location_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = locationFormUI.Tbl_LocationId;

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
            logExcpUIobj.MethodName = "GetLocationListById()";
            logExcpUIobj.ResourceName = "LocationFormDAL.CS";
            logExcpUIobj.RecordId = locationFormUI.Tbl_LocationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[LocationFormDAL : GetLocationListById] An error occured in the processing of Record Id : " + locationFormUI.Tbl_LocationId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddLocation(LocationFormUI locationFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Location_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = locationFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = locationFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@LocationCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@LocationCode"].Value = locationFormUI.LocationCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = locationFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = locationFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = locationFormUI.City;

             
                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddLocation()";
            logExcpUIobj.ResourceName = "LocationFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[LocationFormDAL : AddLocation] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateLocation(LocationFormUI locationFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Location_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = locationFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = locationFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = locationFormUI.Tbl_LocationId;

                sqlCmd.Parameters.Add("@LocationCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@LocationCode"].Value = locationFormUI.LocationCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = locationFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = locationFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = locationFormUI.City;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateLocation()";
            logExcpUIobj.ResourceName = "LocationFormDAL.CS";
            logExcpUIobj.RecordId = locationFormUI.Tbl_LocationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[LocationFormDAL : UpdateLocation] An error occured in the processing of Record Id : " + locationFormUI.Tbl_LocationId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteLocation(LocationFormUI locationFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Location_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = locationFormUI.Tbl_LocationId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteLocation()";
            logExcpUIobj.ResourceName = "LocationFormDAL.CS";
            logExcpUIobj.RecordId = locationFormUI.Tbl_LocationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[LocationFormDAL : DeleteLocation] An error occured in the processing of Record Id : " + locationFormUI.Tbl_LocationId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }



}