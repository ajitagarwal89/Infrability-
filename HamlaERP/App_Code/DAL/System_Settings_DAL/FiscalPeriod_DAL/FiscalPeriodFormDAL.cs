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
/// Summary description for FiscalPeriodFormDAL
/// </summary>
public class FiscalPeriodFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public FiscalPeriodFormDAL()
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
            logExcpUIobj.MethodName = "FiscalPeriodFormDAL()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[FiscalPeriodFormDAL : FiscalPeriodFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetFiscalPeriodId(FiscalPeriodFormUI fiscalPeriodFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriodId", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = fiscalPeriodFormUI.CreatedBy;

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
            logExcpUIobj.MethodName = "GetFiscalPeriodId()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = fiscalPeriodFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : GetFiscalPeriodId] An error occured in the processing of Record Id : " + fiscalPeriodFormUI.Tbl_FiscalPeriodId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }

    public DataSet GetFiscalPeriodListById(FiscalPeriodFormUI fiscalPeriodFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriod_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = fiscalPeriodFormUI.Tbl_FiscalPeriodId;

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
                audit_IUD.WebServiceSelectInsert("tbl_FiscalPeriod", fiscalPeriodFormUI.Tbl_FiscalPeriodId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getFiscalPeriodListById()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = fiscalPeriodFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : getFiscalPeriodListById] An error occured in the processing of Record Id : " + fiscalPeriodFormUI.Tbl_FiscalPeriodId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return ds;

    }

    public DataSet GetFiscalPeriodListByFinancialYear(FiscalPeriodFormUI fiscalPeriodFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriod_SelectByFinancialYear", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Opt_Year", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Opt_Year"].Value = fiscalPeriodFormUI.Opt_Year;

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
                audit_IUD.WebServiceSelectInsert("tbl_FiscalPeriod", fiscalPeriodFormUI.Tbl_FiscalPeriodId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getFiscalPeriodListById()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = fiscalPeriodFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : getFiscalPeriodListById] An error occured in the processing of Record Id : " + fiscalPeriodFormUI.Tbl_FiscalPeriodId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return ds;

    }

    public int AddFiscalPeriod(FiscalPeriodFormUI fiscalPeriodFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriod_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = fiscalPeriodFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = fiscalPeriodFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Opt_Year", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_Year"].Value = fiscalPeriodFormUI.Opt_Year;

                sqlCmd.Parameters.Add("@FirstDayDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@FirstDayDate"].Value = fiscalPeriodFormUI.FirstDayDate;

                sqlCmd.Parameters.Add("@LastDayDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastDayDate"].Value = fiscalPeriodFormUI.LastDayDate;

                sqlCmd.Parameters.Add("@HistoricalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@HistoricalYear"].Value = fiscalPeriodFormUI.HistoricalYear;

                sqlCmd.Parameters.Add("@NumberOfPeriod", SqlDbType.TinyInt);
                sqlCmd.Parameters["@NumberOfPeriod"].Value = fiscalPeriodFormUI.NumberOfPeriod;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();


                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value);
                HttpContext.Current.Session["FiscalPeriodID"] = RecoredID;

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_FiscalPeriod";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(fiscalPeriodFormUI);
                    audit_IUD.WebServiceInsert(fiscalPeriodFormUI.Tbl_OrganizationId, tableName, RecoredID, fiscalPeriodFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddFiscalPeriod()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : AddFiscalPeriod] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateFiscalPeriod(FiscalPeriodFormUI fiscalPeriodFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriod_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = fiscalPeriodFormUI.Tbl_FiscalPeriodId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = fiscalPeriodFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = fiscalPeriodFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Opt_Year", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_Year"].Value = fiscalPeriodFormUI.Opt_Year;

                sqlCmd.Parameters.Add("@FirstDayDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@FirstDayDate"].Value = fiscalPeriodFormUI.FirstDayDate;

                sqlCmd.Parameters.Add("@LastDayDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastDayDate"].Value = fiscalPeriodFormUI.LastDayDate;

                sqlCmd.Parameters.Add("@HistoricalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@HistoricalYear"].Value = fiscalPeriodFormUI.HistoricalYear;

                sqlCmd.Parameters.Add("@NumberOfPeriod", SqlDbType.TinyInt);
                sqlCmd.Parameters["@NumberOfPeriod"].Value = fiscalPeriodFormUI.NumberOfPeriod;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(fiscalPeriodFormUI);
                    audit_IUD.WebServiceUpdate(fiscalPeriodFormUI.Tbl_OrganizationId, "tbl_FiscalPeriod", fiscalPeriodFormUI.Tbl_FiscalPeriodId, fiscalPeriodFormUI.ModifiedBy, newValue);
                }


                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateFiscalPeriod()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = fiscalPeriodFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : UpdateFiscalPeriod] An error occured in the processing of Record Id : " + fiscalPeriodFormUI.Tbl_FiscalPeriodId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteFiscalPeriod(FiscalPeriodFormUI fiscalPeriodFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriod_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = fiscalPeriodFormUI.Tbl_FiscalPeriodId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_FiscalPeriod", fiscalPeriodFormUI.Tbl_FiscalPeriodId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteFiscalPeriod()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = fiscalPeriodFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : DeleteFiscalPeriod] An error occured in the processing of Record Id : " + fiscalPeriodFormUI.Tbl_FiscalPeriodId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}