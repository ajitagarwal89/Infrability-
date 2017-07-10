using System;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for CustomerAndGroupAccountFormDAl
/// </summary>
public class CustomerAndGroupAccountFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public CustomerAndGroupAccountFormDAL()
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
            logExcpUIobj.MethodName = "CustomerAndGroupAccountFormDAL()";
            logExcpUIobj.ResourceName = "CustomerAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[CustomerAndGroupAccountFormDAL : CustomerAndGroupAccountFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}


    public DataTable GetCustomerAndGroupAccountListById(CustomerAndGroupAccountFormUI customerAndGroupAccountFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerAndGroupAccount_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CustomerAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerAndGroupAccountId"].Value = customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId;

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
            logExcpUIobj.MethodName = "getCustomerAndGroupAccountListById()";
            logExcpUIobj.ResourceName = "CustomerAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerAndGroupAccountFormDAL : getCustomerAndGroupAccountListById] An error occured in the processing of Record Id : " + customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddCustomerAndGroupAccount(CustomerAndGroupAccountFormUI customerAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerAndGroupAccount_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = customerAndGroupAccountFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = customerAndGroupAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_CustomerGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerGroupId"].Value = customerAndGroupAccountFormUI.Tbl_CustomerGroupId;

                sqlCmd.Parameters.Add("@tbl_ChequeBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ChequeBookId"].Value = customerAndGroupAccountFormUI.Tbl_ChequeBookId;

                sqlCmd.Parameters.Add("@AccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@AccountType"].Value = customerAndGroupAccountFormUI.Opt_AccountType;

                sqlCmd.Parameters.Add("@PaymentMode", SqlDbType.Bit);
                sqlCmd.Parameters["@PaymentMode"].Value = customerAndGroupAccountFormUI.PaymentMode;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = customerAndGroupAccountFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountReceivable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountReceivable"].Value = customerAndGroupAccountFormUI.Tbl_GLAccountId_AccountReceivable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Sales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Sales"].Value = customerAndGroupAccountFormUI.Tbl_GLAccountId_Sales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_CostOfSales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_CostOfSales"].Value = customerAndGroupAccountFormUI.Tbl_GLAccountId_CostOfSales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Inventory", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Inventory"].Value = customerAndGroupAccountFormUI.Tbl_GLAccountId_Inventory;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccuralDifferedA_C", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccuralDifferedA_C"].Value = customerAndGroupAccountFormUI.Tbl_GLAccountId_AccuralDifferedA_C;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddCustomerAndGroupAccount()";
            logExcpUIobj.ResourceName = "CustomerAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerAndGroupAccountFormDAL : AddCustomerAndGroupAccount] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateCustomerAndGroupAccount(CustomerAndGroupAccountFormUI customerAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerAndGroupAccount_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = customerAndGroupAccountFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = customerAndGroupAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_CustomerGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerGroupId"].Value = customerAndGroupAccountFormUI.Tbl_CustomerGroupId;

                sqlCmd.Parameters.Add("@tbl_ChequeBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ChequeBookId"].Value = customerAndGroupAccountFormUI.Tbl_ChequeBookId;

                sqlCmd.Parameters.Add("@AccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@AccountType"].Value = customerAndGroupAccountFormUI.Opt_AccountType;

                sqlCmd.Parameters.Add("@PaymentMode", SqlDbType.Bit);
                sqlCmd.Parameters["@PaymentMode"].Value = customerAndGroupAccountFormUI.PaymentMode;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = customerAndGroupAccountFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountReceivable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountReceivable"].Value = customerAndGroupAccountFormUI.Tbl_GLAccountId_AccountReceivable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Sales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Sales"].Value = customerAndGroupAccountFormUI.Tbl_GLAccountId_Sales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_CostOfSales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_CostOfSales"].Value = customerAndGroupAccountFormUI.Tbl_GLAccountId_CostOfSales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Inventory", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Inventory"].Value = customerAndGroupAccountFormUI.Tbl_GLAccountId_Inventory;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccuralDifferedA_C", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccuralDifferedA_C"].Value = customerAndGroupAccountFormUI.Tbl_GLAccountId_AccuralDifferedA_C;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateCustomerAndGroupAccount()";
            logExcpUIobj.ResourceName = "CustomerAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerAndGroupAccountFormDAL : UpdateCustomerAndGroupAccount] An error occured in the processing of Record Id : " + customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteCustomerAndGroupAccount(CustomerAndGroupAccountFormUI customerAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerAndGroupAccount_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CustomerAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerAndGroupAccountId"].Value = customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteCustomerAndGroupAccount()";
            logExcpUIobj.ResourceName = "CustomerAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerAndGroupAccountFormDAL : DeleteCustomerAndGroupAccount] An error occured in the processing of Record Id : " + customerAndGroupAccountFormUI.Tbl_CustomerAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}