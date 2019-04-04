using System;
using System.Data.SqlClient;
using System.Data;
using log4net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Services;
using System.Web.SessionState;
using System.Web;
using Finware;
/// <summary>
/// Summary description for OrganizationTypeListDAL
/// </summary>
public class OrganizationTypeListDAL : IRequiresSessionState
{



    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    Audit_IUD audit_IUD = new Audit_IUD();

    public OrganizationTypeListDAL()
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
            logExcpUIobj.MethodName = "OrganizationTypeListDAL()";
            logExcpUIobj.ResourceName = "OrganizationTypeListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[OrganizationTypeListDAL : OrganizationTypeListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetOrganizationTypeList()
    {

        DataSet ds = new DataSet();

        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_OrganizationType_Select", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl= ds.Tables[0];
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getOrganizationTypeList()";
            logExcpUIobj.ResourceName = "OrganizationTypeListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OrganizationTypeListDAL : getOrganizationTypeList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetOrganizationTypeListById(OrganizationTypeListUI organizationTypeListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_OrganizationType_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OrganizationTypeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationTypeId"].Value = organizationTypeListUI.Tbl_OrganizationTypeId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl =ds.Tables[0];
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_OrganizationType", organizationTypeListUI.Tbl_OrganizationTypeId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getOrganizationTypeListById()";
            logExcpUIobj.ResourceName = "OrganizationTypeListDAL.CS";
            logExcpUIobj.RecordId = organizationTypeListUI.Tbl_OrganizationTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OrganizationTypeListDAL : getOrganizationTypeListById] An error occured in the processing of Record Id : " + organizationTypeListUI.Tbl_OrganizationTypeId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetOrganizationTypeListBySearchParameters(OrganizationTypeListUI organizationTypeListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_OrganizationType_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = organizationTypeListUI.Search;

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
                audit_IUD.WebServiceSelectInsert("tbl_OrganizationType", organizationTypeListUI.Tbl_OrganizationTypeId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetOrganizationTypeListBySearchParameters()";
            logExcpUIobj.ResourceName = "OrganizationTypeListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + organizationTypeListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OrganizationTypeListDAL : GetOrganizationTypeListBySearchParameters] An error occured in the processing of Record Search = " + organizationTypeListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int DeleteOrganizationType(OrganizationTypeListUI organizationTypeListUI)
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
                sqlCmd.Parameters["@tbl_OrganizationTypeId"].Value = organizationTypeListUI.Tbl_OrganizationTypeId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_OrganizationType", organizationTypeListUI.Tbl_OrganizationTypeId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
             logExcpUIobj.MethodName = "DeleteOrganizationType()";
            logExcpUIobj.ResourceName = "OrganizationTypeListDAL.CS";
            logExcpUIobj.RecordId = organizationTypeListUI.Tbl_OrganizationTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OrganizationTypeListDAL : DeleteOrganizationType] An error occured in the processing of Record Id : " + organizationTypeListUI.Tbl_OrganizationTypeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetOrganizationTypeListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_OrganizationType_SelectExportToExcel", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
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
            logExcpUIobj.MethodName = "GetOrganizationTypeListForExportToExcel()";
            logExcpUIobj.ResourceName = "OrganizationTypeListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[OrganizationTypeListDAL : GetOrganizationTypeListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

}
