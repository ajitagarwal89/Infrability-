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
/// Summary description for GLAccountSummaryDetailsFormDAL
/// </summary>
public class GLAccountSummaryDetailsFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public GLAccountSummaryDetailsFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountSummaryDetailsFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountSummaryDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountSummaryDetailsFormDAL : GLAccountSummaryDetailsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetGLAccountSummaryDetailsListById(GLAccountSummaryDetailsFormUI gLAccountSummaryDetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSummaryDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountSummaryDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSummaryDetailsId"].Value = gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId;

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
                audit_IUD.WebServiceSelectInsert("tbl_GLAccountSummaryDetails", gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getGLAccountSummaryDetailsListById()";
            logExcpUIobj.ResourceName = "GLAccountSummaryDetailsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSummaryDetailsFormDAL : getGLAccountSummaryDetailsListById] An error occured in the processing of Record Id : " + gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGLAccountSummaryDetails(GLAccountSummaryDetailsFormUI gLAccountSummaryDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSummaryDetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountSummaryDetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountSummaryDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountSummaryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSummaryId"].Value = gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryId;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = gLAccountSummaryDetailsFormUI.Tbl_FiscalPeriodId;

                sqlCmd.Parameters.Add("@Period", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Period"].Value = gLAccountSummaryDetailsFormUI.Period;

                sqlCmd.Parameters.Add("@PeriodName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PeriodName"].Value = gLAccountSummaryDetailsFormUI.PeriodName;

                sqlCmd.Parameters.Add("@PeriodDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PeriodDate"].Value = gLAccountSummaryDetailsFormUI.PeriodDate;

                //sqlCmd.Parameters.Add("@PeriodDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@PeriodDate_Hijri"].Value = gLAccountSummaryDetailsFormUI.PeriodDate_Hijri;

                sqlCmd.Parameters.Add("@DebitAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@DebitAmount"].Value = gLAccountSummaryDetailsFormUI.DebitAmount;

                sqlCmd.Parameters.Add("@CreditAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditAmount"].Value = gLAccountSummaryDetailsFormUI.CreditAmount;

                sqlCmd.Parameters.Add("@NetChageAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@NetChageAmount"].Value = gLAccountSummaryDetailsFormUI.NetChageAmount;

                sqlCmd.Parameters.Add("@PeriodBalanceAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@PeriodBalanceAmount"].Value = gLAccountSummaryDetailsFormUI.PeriodBalanceAmount;

                sqlCmd.Parameters.Add("@tbl_GLAccountSummaryDetailsId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_GLAccountSummaryDetailsId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_GLAccountSummaryDetailsId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_GLAccountSummaryDetails";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(gLAccountSummaryDetailsFormUI);
                    audit_IUD.WebServiceInsert(gLAccountSummaryDetailsFormUI.Tbl_OrganizationId, tableName, recordID, gLAccountSummaryDetailsFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddGLAccountSummaryDetails()";
            logExcpUIobj.ResourceName = "GLAccountSummaryDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSummaryDetailsFormDAL : AddGLAccountSummaryDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccountSummaryDetails(GLAccountSummaryDetailsFormUI gLAccountSummaryDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSummaryDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountSummaryDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountSummaryDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountSummaryDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSummaryDetailsId"].Value = gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId;


                sqlCmd.Parameters.Add("@tbl_GLAccountSummaryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSummaryId"].Value = gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryId;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = gLAccountSummaryDetailsFormUI.Tbl_FiscalPeriodId;

                sqlCmd.Parameters.Add("@Period", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Period"].Value = gLAccountSummaryDetailsFormUI.Period;

                sqlCmd.Parameters.Add("@PeriodName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PeriodName"].Value = gLAccountSummaryDetailsFormUI.PeriodName;

                sqlCmd.Parameters.Add("@PeriodDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PeriodDate"].Value = gLAccountSummaryDetailsFormUI.PeriodDate;

                //sqlCmd.Parameters.Add("@PeriodDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@PeriodDate_Hijri"].Value = gLAccountSummaryDetailsFormUI.PeriodDate_Hijri;

                sqlCmd.Parameters.Add("@DebitAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@DebitAmount"].Value = gLAccountSummaryDetailsFormUI.DebitAmount;

                sqlCmd.Parameters.Add("@CreditAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditAmount"].Value = gLAccountSummaryDetailsFormUI.CreditAmount;

                sqlCmd.Parameters.Add("@NetChageAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@NetChageAmount"].Value = gLAccountSummaryDetailsFormUI.NetChageAmount;

                sqlCmd.Parameters.Add("@PeriodBalanceAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@PeriodBalanceAmount"].Value = gLAccountSummaryDetailsFormUI.PeriodBalanceAmount;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(gLAccountSummaryDetailsFormUI);
                    audit_IUD.WebServiceUpdate(gLAccountSummaryDetailsFormUI.Tbl_OrganizationId, "tbl_GLAccountSummaryDetails", gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId, gLAccountSummaryDetailsFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountSummaryDetails()";
            logExcpUIobj.ResourceName = "GLAccountSummaryDetailsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSummaryDetailsFormDAL : UpdateGLAccountSummaryDetails] An error occured in the processing of Record Id : " + gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGLAccountSummaryDetails(GLAccountSummaryDetailsFormUI gLAccountSummaryDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountSummaryDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountSummaryDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountSummaryDetailsId"].Value = gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_GLAccountSummaryDetails", gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountSummaryDetails()";
            logExcpUIobj.ResourceName = "GLAccountSummaryDetailsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountSummaryDetailsFormDAL : DeleteGLAccountSummaryDetails] An error occured in the processing of Record Id : " + gLAccountSummaryDetailsFormUI.Tbl_GLAccountSummaryDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}