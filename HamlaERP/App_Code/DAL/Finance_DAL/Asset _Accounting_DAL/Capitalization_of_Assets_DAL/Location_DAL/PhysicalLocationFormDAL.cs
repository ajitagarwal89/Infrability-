using System;
using System.Data.SqlClient;
using System.Data;
using log4net;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.SessionState;
using System.Web;
using Finware;


/// <summary>
/// Summary description for PhysicalLocationFormDAL
/// </summary>
public class PhysicalLocationFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
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
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_PhysicalLocation", physicalLocationFormUI.Tbl_PhysicalLocationId, selectedValue);
            }
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

    public int AddPhysicalLocation(PhysicalLocationFormUI physicalLocationFormUI)
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
                sqlCmd.Parameters["@CreatedBy"].Value = physicalLocationFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = physicalLocationFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = physicalLocationFormUI.Tbl_LocationId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = physicalLocationFormUI.Description;

                sqlCmd.Parameters.Add("@LastInventoryDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastInventoryDate"].Value = physicalLocationFormUI.LastInventoryDate;

                sqlCmd.Parameters.Add("@tbl_PhysicalLocationID", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_PhysicalLocationID"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_PhysicalLocationId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_PhysicalLocation";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(physicalLocationFormUI);
                    audit_IUD.WebServiceInsert(physicalLocationFormUI.Tbl_OrganizationId, tableName, RecoredID, physicalLocationFormUI.CreatedBy, newValue);
                    return 1;
                }
                else
                {
                    return 0;
                }

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

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(physicalLocationFormUI);
                    audit_IUD.WebServiceUpdate(physicalLocationFormUI.Tbl_OrganizationId, "tbl_PhysicalLocation", physicalLocationFormUI.Tbl_PhysicalLocationId, physicalLocationFormUI.ModifiedBy, newValue);
                }

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
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_PhysicalLocation", physicalLocationFormUI.Tbl_PhysicalLocationId);
                }

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