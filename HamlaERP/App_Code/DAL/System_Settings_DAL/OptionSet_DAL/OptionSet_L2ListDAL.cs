using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Web.Services;
using System.Web.SessionState;
using Finware;

/// <summary>
/// Summary description for OptionSet_L2ListDAL
/// </summary>
public class OptionSet_L2ListDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    Audit_IUD audit_IUD = new Audit_IUD();
    public OptionSet_L2ListDAL()
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
            logExcpUIobj.MethodName = "OptionSet_L2ListDAL()";
            logExcpUIobj.ResourceName = "OptionSet_L2ListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[OptionSet_L2ListDAL : OptionSet_L2ListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetOptionSet_L2List()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_L2_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetOptionSet_L2List()";
            logExcpUIobj.ResourceName = "OptionSet_L2ListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSet_L2ListDAL : GetOptionSet_L2List] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetOptionSet_L2ListById(OptionSet_L2ListUI optionSet_L2ListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_L2_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L2Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSet_L2Id"].Value = optionSet_L2ListUI.Tbl_OptionSet_L2Id;

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
                audit_IUD.WebServiceSelectInsert("tbl_OptionSet_L2", optionSet_L2ListUI.Tbl_OptionSet_L2Id, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetOptionSet_L2ListById()";
            logExcpUIobj.ResourceName = "OptionSet_L2ListDAL.CS";
            logExcpUIobj.RecordId = optionSet_L2ListUI.Tbl_OptionSet_L1Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSet_L2ListDAL : GetOptionSet_L2ListById] An error occured in the processing of Record Id : " + optionSet_L2ListUI.Tbl_OptionSet_L2Id + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetOptionSet_L2ListBySearchParameters(OptionSet_L2ListUI optionSet_L2ListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_L2_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = optionSet_L2ListUI.Search;

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
                audit_IUD.WebServiceSelectInsert("tbl_OptionSet_L2", optionSet_L2ListUI.Tbl_OptionSet_L2Id, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetOptionSet_L2ListBySearchParameters()";
            logExcpUIobj.ResourceName = "OptionSet_L2ListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + optionSet_L2ListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSet_L2ListDAL : GetOptionSet_L2ListBySearchParameters] An error occured in the processing of Record Search = " + optionSet_L2ListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int DeleteOptionSet_L2(OptionSet_L2ListUI optionSet_L2ListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_L2_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_OptionSet_L2Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OptionSet_L2Id"].Value = optionSet_L2ListUI.Tbl_OptionSet_L2Id;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_OptionSet_L2", optionSet_L2ListUI.Tbl_OptionSet_L2Id);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteOptionSet_L2()";
            logExcpUIobj.ResourceName = "OptionSet_L2ListDAL.CS";
            logExcpUIobj.RecordId = optionSet_L2ListUI.Tbl_OptionSet_L1Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSet_L2ListDAL : DeleteOptionSet_L2] An error occured in the processing of Record Id : " + optionSet_L2ListUI.Tbl_OptionSet_L2Id + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public DataTable GetOptionSetListByOptionSetName(OptionSetListUI optionSetListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();

        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_SelectOptionSet", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@TableName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@TableName"].Value = optionSetListUI.TableName;

                sqlCmd.Parameters.Add("@OptionSetName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@OptionSetName"].Value = optionSetListUI.OptionSetName;

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
            logExcpUIobj.MethodName = "GetOptionSetListByOptionSetName()";
            logExcpUIobj.ResourceName = "OptionSet_L2ListDAL.CS";
            logExcpUIobj.RecordId = optionSetListUI.OptionSetName;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[OptionSet_L2ListDAL : GetOptionSetListByOptionSetName] An error occured in the processing of Record Id : " + optionSetListUI.OptionSetName + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetOptionSet_L2ListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_OptionSet_L2_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetOptionSet_L2ListForExportToExcel()";
            logExcpUIobj.ResourceName = "OptionSet_L2ListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[OptionSet_L2ListDAL : GetOptionSet_L2ListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }
}