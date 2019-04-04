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
/// Summary description for FiscalPeriodDetailsFormDAL
/// </summary>
public class FiscalPeriodDetailsFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public FiscalPeriodDetailsFormDAL()
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

    public DataTable GetFiscalPeriodDetailsListById(FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriodDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodDetailsId"].Value = fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId;

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
                audit_IUD.WebServiceSelectInsert("tbl_FiscalPeriodDetails", fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId, selectedValue);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getFiscalPeriodListById()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : getFiscalPeriodListById] An error occured in the processing of Record Id : " + fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddFiscalPeriodDetails(FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriodDetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = fiscalPeriodDetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = fiscalPeriodDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodId;

                sqlCmd.Parameters.Add("@PeriodSequence", SqlDbType.TinyInt);
                sqlCmd.Parameters["@PeriodSequence"].Value = fiscalPeriodDetailsFormUI.PeriodSequence;

                sqlCmd.Parameters.Add("@PeriodName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PeriodName"].Value = fiscalPeriodDetailsFormUI.PeriodName;

                sqlCmd.Parameters.Add("@PeriodDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PeriodDate"].Value = fiscalPeriodDetailsFormUI.PeriodDate;

                sqlCmd.Parameters.Add("@ClosingFinancial", SqlDbType.Bit);
                sqlCmd.Parameters["@ClosingFinancial"].Value = fiscalPeriodDetailsFormUI.ClosingFinancial;

                sqlCmd.Parameters.Add("@ClosingHR", SqlDbType.Bit);
                sqlCmd.Parameters["@ClosingHR"].Value = fiscalPeriodDetailsFormUI.ClosingHR;

                sqlCmd.Parameters.Add("@ClosingProcurement", SqlDbType.Bit);
                sqlCmd.Parameters["@ClosingProcurement"].Value = fiscalPeriodDetailsFormUI.ClosingProcurement;

                sqlCmd.Parameters.Add("@IsActive", SqlDbType.Bit);
                sqlCmd.Parameters["@IsActive"].Value = fiscalPeriodDetailsFormUI.IsActive;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodDetailsId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_FiscalPeriodDetailsId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_FiscalPeriodDetailsId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_FiscalPeriodDetails";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(fiscalPeriodDetailsFormUI);
                    audit_IUD.WebServiceInsert(fiscalPeriodDetailsFormUI.Tbl_OrganizationId, tableName, RecoredID, fiscalPeriodDetailsFormUI.CreatedBy, newValue);
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

    public int UpdateFiscalPeriodDetails(FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriodDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodDetailsId"].Value = fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = fiscalPeriodDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = fiscalPeriodDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodId;

                sqlCmd.Parameters.Add("@PeriodSequence", SqlDbType.TinyInt);
                sqlCmd.Parameters["@PeriodSequence"].Value = fiscalPeriodDetailsFormUI.PeriodSequence;

                sqlCmd.Parameters.Add("@PeriodName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PeriodName"].Value = fiscalPeriodDetailsFormUI.PeriodName;

                sqlCmd.Parameters.Add("@PeriodDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PeriodDate"].Value = fiscalPeriodDetailsFormUI.PeriodDate;

                sqlCmd.Parameters.Add("@ClosingFinancial", SqlDbType.Bit);
                sqlCmd.Parameters["@ClosingFinancial"].Value = fiscalPeriodDetailsFormUI.ClosingFinancial;

                sqlCmd.Parameters.Add("@ClosingHR", SqlDbType.Bit);
                sqlCmd.Parameters["@ClosingHR"].Value = fiscalPeriodDetailsFormUI.ClosingHR;

                sqlCmd.Parameters.Add("@ClosingProcurement", SqlDbType.Bit);
                sqlCmd.Parameters["@ClosingProcurement"].Value = fiscalPeriodDetailsFormUI.ClosingProcurement;

                sqlCmd.Parameters.Add("@IsActive", SqlDbType.Bit);
                sqlCmd.Parameters["@IsActive"].Value = fiscalPeriodDetailsFormUI.IsActive;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(fiscalPeriodDetailsFormUI);
                    audit_IUD.WebServiceUpdate(fiscalPeriodDetailsFormUI.Tbl_OrganizationId, "tbl_FiscalPeriodDetails", fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId, fiscalPeriodDetailsFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateFiscalPeriod()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : UpdateFiscalPeriod] An error occured in the processing of Record Id : " + fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateFiscalPeriodDetailsClosingModules(FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriodDetailsClosingModules_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodDetailsId"].Value = fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = fiscalPeriodDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = fiscalPeriodDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@ClosingFinancial", SqlDbType.Bit);
                sqlCmd.Parameters["@ClosingFinancial"].Value = fiscalPeriodDetailsFormUI.ClosingFinancial;

                sqlCmd.Parameters.Add("@ClosingHR", SqlDbType.Bit);
                sqlCmd.Parameters["@ClosingHR"].Value = fiscalPeriodDetailsFormUI.ClosingHR;

                sqlCmd.Parameters.Add("@ClosingProcurement", SqlDbType.Bit);
                sqlCmd.Parameters["@ClosingProcurement"].Value = fiscalPeriodDetailsFormUI.ClosingProcurement;

                sqlCmd.Parameters.Add("@IsActive", SqlDbType.Bit);
                sqlCmd.Parameters["@IsActive"].Value = fiscalPeriodDetailsFormUI.IsActive;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateFiscalPeriod()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : UpdateFiscalPeriod] An error occured in the processing of Record Id : " + fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteFiscalPeriodDetails(FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriodDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodDetailsId"].Value = fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_FiscalPeriodDetails", fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteFiscalPeriod()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : DeleteFiscalPeriod] An error occured in the processing of Record Id : " + fiscalPeriodDetailsFormUI.Tbl_FiscalPeriodDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }


}