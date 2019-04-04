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
/// Summary description for BudgetFormDAL
/// </summary>
public class BudgetFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public BudgetFormDAL()
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
            logExcpUIobj.MethodName = "BudgetFormDAL()";
            logExcpUIobj.ResourceName = "BudgetFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[BudgetFormDAL : BudgetFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetBudgetListById(BudgetFormUI budgetFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Budget_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_BudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BudgetId"].Value = budgetFormUI.Tbl_BudgetId;

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
                audit_IUD.WebServiceSelectInsert("tbl_Budget", budgetFormUI.Tbl_BudgetId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getBudgetListById()";
            logExcpUIobj.ResourceName = "BudgetFormDAL.CS";
            logExcpUIobj.RecordId = budgetFormUI.Tbl_BudgetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BudgetFormDAL : getBudgetListById] An error occured in the processing of Record Id : " + budgetFormUI.Tbl_BudgetId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddBudget(BudgetFormUI budgetFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Budget_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = budgetFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = budgetFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@BudgetNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BudgetNumber"].Value = budgetFormUI.BudgetNumber;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = budgetFormUI.Description;

                sqlCmd.Parameters.Add("@Opt_BasedOn", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_BasedOn"].Value = budgetFormUI.Opt_BasedOn;

                sqlCmd.Parameters.Add("@Opt_BudgetYear", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_BudgetYear"].Value = budgetFormUI.Opt_BudgetYear;

                sqlCmd.Parameters.Add("@AnnualCapital", SqlDbType.Bit);
                sqlCmd.Parameters["@AnnualCapital"].Value = budgetFormUI.AnnualCapital;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = budgetFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@Display", SqlDbType.Bit);
                sqlCmd.Parameters["@Display"].Value = budgetFormUI.Display;

                sqlCmd.Parameters.Add("@tbl_BudgetId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_BudgetId"].Direction = ParameterDirection.Output;


                result = sqlCmd.ExecuteNonQuery();
                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_BudgetId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_Budget";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(budgetFormUI);
                    audit_IUD.WebServiceInsert(budgetFormUI.Tbl_OrganizationId, tableName, RecoredID, budgetFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddBudget()";
            logExcpUIobj.ResourceName = "BudgetFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BudgetFormDAL : AddBudget] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateBudget(BudgetFormUI budgetFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Budget_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = budgetFormUI.ModifiedBy;
                sqlCmd.Parameters.Add("@tbl_BudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BudgetId"].Value = budgetFormUI.Tbl_BudgetId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = budgetFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@BudgetNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BudgetNumber"].Value = budgetFormUI.BudgetNumber;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = budgetFormUI.Description;

                sqlCmd.Parameters.Add("@Opt_BasedOn", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_BasedOn"].Value = budgetFormUI.Opt_BasedOn;

                sqlCmd.Parameters.Add("@Opt_BudgetYear", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_BudgetYear"].Value = budgetFormUI.Opt_BudgetYear;

                sqlCmd.Parameters.Add("@AnnualCapital", SqlDbType.Bit);
                sqlCmd.Parameters["@AnnualCapital"].Value = budgetFormUI.AnnualCapital;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = budgetFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@Display", SqlDbType.Bit);
                sqlCmd.Parameters["@Display"].Value = budgetFormUI.Display;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(budgetFormUI);
                    audit_IUD.WebServiceUpdate(budgetFormUI.Tbl_OrganizationId, "tbl_Budget", budgetFormUI.Tbl_BudgetId, budgetFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateBudget()";
            logExcpUIobj.ResourceName = "BudgetFormDAL.CS";
            logExcpUIobj.RecordId = budgetFormUI.Tbl_BudgetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BudgetFormDAL : UpdateBudget] An error occured in the processing of Record Id : " + budgetFormUI.Tbl_BudgetId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteBudget(BudgetFormUI budgetFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Budget_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_BudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BudgetId"].Value = budgetFormUI.Tbl_BudgetId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_Budget", budgetFormUI.Tbl_BudgetId);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteBudget()";
            logExcpUIobj.ResourceName = "BudgetFormDAL.CS";
            logExcpUIobj.RecordId = budgetFormUI.Tbl_BudgetId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BudgetFormDAL : DeleteBudget] An error occured in the processing of Record Id : " + budgetFormUI.Tbl_BudgetId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}