using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for BudgetDetailsFormDAL
/// </summary>
public class BudgetDetailsFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public BudgetDetailsFormDAL()
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
            logExcpUIobj.MethodName = "BudgetDetailsFormDAL()";
            logExcpUIobj.ResourceName = "BudgetDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[BudgetDetailsFormDAL : BudgetDetailsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetBudgetDetailsListById(BudgetDetailsFormUI budgetDetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_BudgetDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_BudgetDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BudgetDetailsId"].Value = budgetDetailsFormUI.Tbl_BudgetDetailsId;

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
            logExcpUIobj.MethodName = "getBudgetDetailsListById()";
            logExcpUIobj.ResourceName = "BudgetDetailsFormDAL.CS";
            logExcpUIobj.RecordId = budgetDetailsFormUI.Tbl_BudgetDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BudgetDetailsFormDAL : getBudgetDetailsListById] An error occured in the processing of Record Id : " + budgetDetailsFormUI.Tbl_BudgetDetailsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddBudgetDetails(BudgetDetailsFormUI budgetDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_BudgetDetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = budgetDetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = budgetDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_BudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BudgetId"].Value = budgetDetailsFormUI.Tbl_BudgetId;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = budgetDetailsFormUI.Tbl_FiscalPeriodId;

                sqlCmd.Parameters.Add("@Period", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Period"].Value = budgetDetailsFormUI.Period;

                sqlCmd.Parameters.Add("@PeriodName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PeriodName"].Value = budgetDetailsFormUI.PeriodName;

                sqlCmd.Parameters.Add("@PeriodDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PeriodDate"].Value = budgetDetailsFormUI.PeriodDate;               

                sqlCmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                sqlCmd.Parameters["@Amount"].Value = budgetDetailsFormUI.Amount;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddBudgetDetails()";
            logExcpUIobj.ResourceName = "BudgetDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BudgetDetailsFormDAL : AddBudgetDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateBudgetDetails(BudgetDetailsFormUI budgetDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_BudgetDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = budgetDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = budgetDetailsFormUI.Tbl_OrganizationId;
                sqlCmd.Parameters.Add("@tbl_BudgetDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BudgetDetailsId"].Value = budgetDetailsFormUI.Tbl_BudgetDetailsId;

                sqlCmd.Parameters.Add("@tbl_BudgetId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BudgetId"].Value = budgetDetailsFormUI.Tbl_BudgetId;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = budgetDetailsFormUI.Tbl_FiscalPeriodId;

                sqlCmd.Parameters.Add("@Period", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Period"].Value = budgetDetailsFormUI.Period;

                sqlCmd.Parameters.Add("@PeriodName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PeriodName"].Value = budgetDetailsFormUI.PeriodName;

                sqlCmd.Parameters.Add("@PeriodDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PeriodDate"].Value = budgetDetailsFormUI.PeriodDate;
                
                sqlCmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                sqlCmd.Parameters["@Amount"].Value = budgetDetailsFormUI.Amount;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateBudgetDetails()";
            logExcpUIobj.ResourceName = "BudgetDetailsFormDAL.CS";
            logExcpUIobj.RecordId = budgetDetailsFormUI.Tbl_BudgetDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BudgetDetailsFormDAL : UpdateBudgetDetails] An error occured in the processing of Record Id : " + budgetDetailsFormUI.Tbl_BudgetDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteBudgetDetails(BudgetDetailsFormUI budgetDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_BudgetDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_BudgetDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BudgetDetailsId"].Value = budgetDetailsFormUI.Tbl_BudgetDetailsId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteBudgetDetails()";
            logExcpUIobj.ResourceName = "BudgetDetailsFormDAL.CS";
            logExcpUIobj.RecordId = budgetDetailsFormUI.Tbl_BudgetDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BudgetDetailsFormDAL : DeleteBudgetDetails] An error occured in the processing of Record Id : " + budgetDetailsFormUI.Tbl_BudgetDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}