﻿using System;
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
/// Summary description for HR_PositionListDAL
/// </summary>
public class HR_PositionListDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    Audit_IUD audit_IUD = new Audit_IUD();

    public HR_PositionListDAL()
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
            logExcpUIobj.MethodName = "HR_PositionListDAL()";
            logExcpUIobj.ResourceName = "HR_PositionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[HR_PositionListDAL : HR_PositionListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetHR_PositionList()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Position_Select", SupportCon);
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
            logExcpUIobj.MethodName = "getHR_PositionList()";
            logExcpUIobj.ResourceName = "HR_PositionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_PositionListDAL : getHR_PositionList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetHR_PositionListById(HR_PositionListUI hR_PositionListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Position_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_PositionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_PositionId"].Value = hR_PositionListUI.Tbl_HR_PositionId;

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
                audit_IUD.WebServiceSelectInsert("tbl_HR_Position", hR_PositionListUI.Tbl_HR_PositionId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getHR_PositionListById()";
            logExcpUIobj.ResourceName = "HR_PositionListDAL.CS";
            logExcpUIobj.RecordId = hR_PositionListUI.Tbl_HR_PositionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_PositionListDAL : getHR_PositionListById] An error occured in the processing of Record Id : " + hR_PositionListUI.Tbl_HR_PositionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetHR_PositionListForExportToExcel()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Position_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetHR_PositionListForExportToExcel()";
            logExcpUIobj.ResourceName = "HR_PositionListDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[HR_PositionListDAL : GetHR_PositionListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }
        return dtbl;
    }

    public DataTable GetHR_PositionListBySearchParameters(HR_PositionListUI hR_PositionListUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Position_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Search", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Search"].Value = hR_PositionListUI.Search;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl = ds.Tables[0];
            string recordId = dtbl.Rows[0]["tbl_HR_PositionId"].ToString();
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_HR_Position", recordId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetHR_PositionListBySearchParameters()";
            logExcpUIobj.ResourceName = "HR_PositionListDAL.CS";
            logExcpUIobj.RecordId = "Search = " + hR_PositionListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_PositionListDAL : GetHR_PositionListBySearchParameters] An error occured in the processing of Record Search = " + hR_PositionListUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int DeleteHR_Position(HR_PositionListUI hR_PositionListUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_HR_Position_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_HR_PositionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_HR_PositionId"].Value = hR_PositionListUI.Tbl_HR_PositionId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_HR_Position", hR_PositionListUI.Tbl_HR_PositionId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteHR_Position()";
            logExcpUIobj.ResourceName = "HR_PositionListDAL.CS";
            logExcpUIobj.RecordId = hR_PositionListUI.Tbl_HR_PositionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[HR_PositionListDAL : DeleteHR_Position] An error occured in the processing of Record Id : " + hR_PositionListUI.Tbl_HR_PositionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}