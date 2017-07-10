using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for PhysicalLocationFormDAL
/// </summary>
public class PhysicalLocationFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PhysicalLocationFormDAL()
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
            logExcpUIobj.MethodName = "PhysicalLocationFormDAL()";
            logExcpUIobj.ResourceName = "PhysicalLocationFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PhysicalLocationFormDAL : PhysicalLocationFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetPhysicalLocationListById(PhysicalLocationFormUI physicalLocationFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PhysicalLocation_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PhysicalLocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PhysicalLocationId"].Value = physicalLocationFormUI.Tbl_PhysicalLocationId;

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
            logExcpUIobj.MethodName = "GetPhysicalLocationListById()";
            logExcpUIobj.ResourceName = "PhysicalLocationFormDAL.CS";
            logExcpUIobj.RecordId = physicalLocationFormUI.Tbl_PhysicalLocationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PhysicalLocationFormDAL : GetPhysicalLocationListById] An error occured in the processing of Record Id : " + physicalLocationFormUI.Tbl_PhysicalLocationId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPhysicalLocation(PhysicalLocationFormUI PhysicalLocationFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PhysicalLocation_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = PhysicalLocationFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PhysicalLocationFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = PhysicalLocationFormUI.Tbl_LocationId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = PhysicalLocationFormUI.Description;

                sqlCmd.Parameters.Add("@LastInventoryDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastInventoryDate"].Value = PhysicalLocationFormUI.LastInventoryDate;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPhysicalLocation()";
            logExcpUIobj.ResourceName = "PhysicalLocationFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PhysicalLocationFormDAL : AddPhysicalLocation] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePhysicalLocation(PhysicalLocationFormUI physicalLocationFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PhysicalLocation_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = physicalLocationFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = physicalLocationFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PhysicalLocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PhysicalLocationId"].Value = physicalLocationFormUI.Tbl_PhysicalLocationId;
                
                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = physicalLocationFormUI.Tbl_LocationId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = physicalLocationFormUI.Description;

                sqlCmd.Parameters.Add("@LastInventoryDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastInventoryDate"].Value = physicalLocationFormUI.LastInventoryDate;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePhysicalLocation()";
            logExcpUIobj.ResourceName = "PhysicalLocationFormDAL.CS";
            logExcpUIobj.RecordId = physicalLocationFormUI.Tbl_PhysicalLocationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PhysicalLocationFormDAL : UpdatePhysicalLocation] An error occured in the processing of Record Id : " + physicalLocationFormUI.Tbl_PhysicalLocationId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePhysicalLocation(PhysicalLocationFormUI physicalLocationFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PhysicalLocation_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PhysicalLocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PhysicalLocationId"].Value = physicalLocationFormUI.Tbl_PhysicalLocationId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePhysicalLocation()";
            logExcpUIobj.ResourceName = "PhysicalLocationFormDAL.CS";
            logExcpUIobj.RecordId = physicalLocationFormUI.Tbl_PhysicalLocationId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PhysicalLocationFormDAL : DeletePhysicalLocation] An error occured in the processing of Record Id : " + physicalLocationFormUI.Tbl_PhysicalLocationId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}