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
/// Summary description for GLAccountBudgetFormDAL
/// </summary>
public class GLAccountBudgetFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public GLAccountBudgetFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountBudgetFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountBudgetFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountBudgetFormDAL : GLAccountBudgetFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetGLAccountBudgetListById(GLAccountBudgetFormUI gLAccountBudgetFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountBudget_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountBudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountBudgetId"].Value = gLAccountBudgetFormUI.Tbl_GLAccountBudgetId;

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
                audit_IUD.WebServiceSelectInsert("tbl_GLAccountBudget", gLAccountBudgetFormUI.Tbl_GLAccountBudgetId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getGLAccountBudgetListById()";
            logExcpUIobj.ResourceName = "GLAccountBudgetFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountBudgetFormUI.Tbl_GLAccountBudgetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountBudgetFormDAL : getGLAccountBudgetListById] An error occured in the processing of Record Id : " + gLAccountBudgetFormUI.Tbl_GLAccountBudgetId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGLAccountBudget(GLAccountBudgetFormUI gLAccountBudgetFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountBudget_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountBudgetFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountBudgetFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = gLAccountBudgetFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@tbl_BudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BudgetId"].Value = gLAccountBudgetFormUI.Tbl_BudgetId;

                sqlCmd.Parameters.Add("@Opt_BasedOn", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_BasedOn"].Value = gLAccountBudgetFormUI.Opt_BasedOn;

                sqlCmd.Parameters.Add("@Opt_BudgetYear", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_BudgetYear"].Value = gLAccountBudgetFormUI.Opt_BudgetYear;

                sqlCmd.Parameters.Add("@Opt_CalculationMethod", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_CalculationMethod"].Value = gLAccountBudgetFormUI.Opt_CalculationMethod;

                sqlCmd.Parameters.Add("@Year", SqlDbType.Int);
                sqlCmd.Parameters["@Year"].Value = gLAccountBudgetFormUI.Year;

                sqlCmd.Parameters.Add("@tbl_ButdetId_SourceBudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ButdetId_SourceBudgetId"].Value = gLAccountBudgetFormUI.Tbl_ButdetId_SourceBudgetId;

                sqlCmd.Parameters.Add("@Percentage", SqlDbType.Decimal);
                sqlCmd.Parameters["@Percentage"].Value = gLAccountBudgetFormUI.Percentage;

                sqlCmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                sqlCmd.Parameters["@Amount"].Value = gLAccountBudgetFormUI.Amount;

                sqlCmd.Parameters.Add("@IsIncrease", SqlDbType.Bit);
                sqlCmd.Parameters["@IsIncrease"].Value = gLAccountBudgetFormUI.IsIncrease;

                sqlCmd.Parameters.Add("@Display", SqlDbType.Bit);
                sqlCmd.Parameters["@Display"].Value = gLAccountBudgetFormUI.Display;

                sqlCmd.Parameters.Add("@IncludeBiginningBalance", SqlDbType.Bit);
                sqlCmd.Parameters["@IncludeBiginningBalance"].Value = gLAccountBudgetFormUI.IncludeBiginningBalance;

                sqlCmd.Parameters.Add("@tbl_GLAccountBudgetId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_GLAccountBudgetId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_GLAccountBudgetId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_GLAccountBudget";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(gLAccountBudgetFormUI);
                    audit_IUD.WebServiceInsert(gLAccountBudgetFormUI.Tbl_OrganizationId, tableName, recordID, gLAccountBudgetFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddGLAccountBudget()";
            logExcpUIobj.ResourceName = "GLAccountBudgetFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountBudgetFormDAL : AddGLAccountBudget] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccountBudget(GLAccountBudgetFormUI gLAccountBudgetFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountBudget_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountBudgetFormUI.@ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountBudgetFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountBudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountBudgetId"].Value = gLAccountBudgetFormUI.Tbl_GLAccountBudgetId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = gLAccountBudgetFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@tbl_BudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BudgetId"].Value = gLAccountBudgetFormUI.Tbl_BudgetId;

                sqlCmd.Parameters.Add("@Opt_BasedOn", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_BasedOn"].Value = gLAccountBudgetFormUI.Opt_BasedOn;

                sqlCmd.Parameters.Add("@Opt_BudgetYear", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_BudgetYear"].Value = gLAccountBudgetFormUI.Opt_BudgetYear;

                sqlCmd.Parameters.Add("@Opt_CalculationMethod", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_CalculationMethod"].Value = gLAccountBudgetFormUI.Opt_CalculationMethod;

                sqlCmd.Parameters.Add("@Year", SqlDbType.Int);
                sqlCmd.Parameters["@Year"].Value = gLAccountBudgetFormUI.Year;

                sqlCmd.Parameters.Add("@tbl_ButdetId_SourceBudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ButdetId_SourceBudgetId"].Value = gLAccountBudgetFormUI.Tbl_ButdetId_SourceBudgetId;

                sqlCmd.Parameters.Add("@Percentage", SqlDbType.Decimal);
                sqlCmd.Parameters["@Percentage"].Value = gLAccountBudgetFormUI.Percentage;

                sqlCmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                sqlCmd.Parameters["@Amount"].Value = gLAccountBudgetFormUI.Amount;

                sqlCmd.Parameters.Add("@IsIncrease", SqlDbType.Bit);
                sqlCmd.Parameters["@IsIncrease"].Value = gLAccountBudgetFormUI.IsIncrease;

                sqlCmd.Parameters.Add("@Display", SqlDbType.Bit);
                sqlCmd.Parameters["@Display"].Value = gLAccountBudgetFormUI.Display;

                sqlCmd.Parameters.Add("@IncludeBiginningBalance", SqlDbType.Bit);
                sqlCmd.Parameters["@IncludeBiginningBalance"].Value = gLAccountBudgetFormUI.IncludeBiginningBalance;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(gLAccountBudgetFormUI);
                    audit_IUD.WebServiceUpdate(gLAccountBudgetFormUI.Tbl_OrganizationId, "tbl_GLAccountBudget", gLAccountBudgetFormUI.Tbl_GLAccountBudgetId, gLAccountBudgetFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountBudget()";
            logExcpUIobj.ResourceName = "GLAccountBudgetFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountBudgetFormUI.Tbl_GLAccountBudgetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountBudgetFormDAL : UpdateGLAccountBudget] An error occured in the processing of Record Id : " + gLAccountBudgetFormUI.Tbl_GLAccountBudgetId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGLAccountBudget(GLAccountBudgetFormUI gLAccountBudgetFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountBudget_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountBudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountBudgetId"].Value = gLAccountBudgetFormUI.Tbl_GLAccountBudgetId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_GLAccountBudget", gLAccountBudgetFormUI.Tbl_GLAccountBudgetId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountBudget()";
            logExcpUIobj.ResourceName = "GLAccountBudgetFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountBudgetFormUI.Tbl_GLAccountBudgetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountBudgetFormDAL : DeleteGLAccountBudget] An error occured in the processing of Record Id : " + gLAccountBudgetFormUI.Tbl_GLAccountBudgetId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}