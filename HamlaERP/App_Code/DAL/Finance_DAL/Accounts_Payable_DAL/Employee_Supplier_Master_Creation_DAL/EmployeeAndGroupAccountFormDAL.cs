using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for EmployeeAndGroupAccountFormDAL
/// </summary>
public class EmployeeAndGroupAccountFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
	public EmployeeAndGroupAccountFormDAL()
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
            logExcpUIobj.MethodName = "EmployeeAndGroupAccountFormDAL()";
            logExcpUIobj.ResourceName = "EmployeeAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[EmployeeAndGroupAccountFormDAL : EmployeeAndGroupAccountFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetEmployeeAndGroupAccountListById(EmployeeAndGroupAccountFormUI employeeAndGroupAccountFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeAndGroupAccount_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeAndGroupAccountId"].Value = employeeAndGroupAccountFormUI.Tbl_EmployeeAndGroupAccountId;

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
            logExcpUIobj.MethodName = "GetEmployeeAndGroupAccountListById()";
            logExcpUIobj.ResourceName = "EmployeeAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = employeeAndGroupAccountFormUI.Tbl_EmployeeAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeAndGroupAccountFormDAL : GetEmployeeAndGroupAccountListById] An error occured in the processing of Record Id : " + employeeAndGroupAccountFormUI.Tbl_EmployeeAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddEmployeeAndGroupAccount(EmployeeAndGroupAccountFormUI employeeAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeAndGroupAccount_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = employeeAndGroupAccountFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = employeeAndGroupAccountFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeAndGroupAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_EmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeGroupId"].Value = employeeAndGroupAccountFormUI.Tbl_EmployeeGroupId;

                sqlCmd.Parameters.Add("@AccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@AccountType"].Value = employeeAndGroupAccountFormUI.Opt_AccountType;

                sqlCmd.Parameters.Add("@PaymentMode", SqlDbType.Bit);
                sqlCmd.Parameters["@PaymentMode"].Value = employeeAndGroupAccountFormUI.PaymentMode;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = employeeAndGroupAccountFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountPayable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountPayable"].Value = employeeAndGroupAccountFormUI.Tbl_GLAccountId_AccountPayable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Purchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Purchase"].Value = employeeAndGroupAccountFormUI.Tbl_GLAccountId_Purchase;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_TradeDiscount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_TradeDiscount"].Value = employeeAndGroupAccountFormUI.Tbl_GLAccountId_TradeDiscount;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Freight", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Freight"].Value = employeeAndGroupAccountFormUI.Tbl_GLAccountId_Freight;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccruedPurchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccruedPurchase"].Value = employeeAndGroupAccountFormUI.Tbl_GLAccountId_AccruedPurchase;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddEmployeeAndGroupAccount()";
            logExcpUIobj.ResourceName = "EmployeeAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeAndGroupAccountFormDAL : AddEmployeeAndGroupAccount] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateEmployeeAndGroupAccount(EmployeeAndGroupAccountFormUI employeeAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeAndGroupAccount_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = employeeAndGroupAccountFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = employeeAndGroupAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_EmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeGroupId"].Value = employeeAndGroupAccountFormUI.Tbl_EmployeeGroupId;

                sqlCmd.Parameters.Add("@AccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@AccountType"].Value = employeeAndGroupAccountFormUI.Opt_AccountType;

                sqlCmd.Parameters.Add("@PaymentMode", SqlDbType.Bit);
                sqlCmd.Parameters["@PaymentMode"].Value = employeeAndGroupAccountFormUI.PaymentMode;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = employeeAndGroupAccountFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountPayable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountPayable"].Value = employeeAndGroupAccountFormUI.Tbl_GLAccountId_AccountPayable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Purchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Purchase"].Value = employeeAndGroupAccountFormUI.Tbl_GLAccountId_Purchase;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_TradeDiscount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_TradeDiscount"].Value = employeeAndGroupAccountFormUI.Tbl_GLAccountId_TradeDiscount;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Freight", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Freight"].Value = employeeAndGroupAccountFormUI.Tbl_GLAccountId_Freight;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccruedPurchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccruedPurchase"].Value = employeeAndGroupAccountFormUI.Tbl_GLAccountId_AccruedPurchase;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateEmployeeAndGroupAccount()";
            logExcpUIobj.ResourceName = "EmployeeAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = employeeAndGroupAccountFormUI.Tbl_EmployeeAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeAndGroupAccountFormDAL : UpdateEmployeeAndGroupAccount] An error occured in the processing of Record Id : " + employeeAndGroupAccountFormUI.Tbl_EmployeeAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteEmployeeAndGroupAccount(EmployeeAndGroupAccountFormUI employeeAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_EmployeeAndGroupAccount_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_EmployeeAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_EmployeeAndGroupAccountId"].Value = employeeAndGroupAccountFormUI.Tbl_EmployeeAndGroupAccountId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteEmployeeAndGroupAccount()";
            logExcpUIobj.ResourceName = "EmployeeAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = employeeAndGroupAccountFormUI.Tbl_EmployeeAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[EmployeeAndGroupAccountFormDAL : DeleteEmployeeAndGroupAccount] An error occured in the processing of Record Id : " + employeeAndGroupAccountFormUI.Tbl_EmployeeAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}