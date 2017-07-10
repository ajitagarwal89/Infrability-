using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for CustomerInvoiceDistributionFormDAL
/// </summary>
public class CustomerInvoiceDistributionFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public CustomerInvoiceDistributionFormDAL()
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
            logExcpUIobj.MethodName = "CustomerInvoiceDistributionFormDAL()";
            logExcpUIobj.ResourceName = "CustomerInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[customerInvoiceDistributionFormDAL : CustomerInvoiceDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetCustomerInvoiceDistributionListById(CustomerInvoiceDistributionFormUI customerInvoiceDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoiceDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CustomerInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerInvoiceDistributionId"].Value = customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId;

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
            logExcpUIobj.MethodName = "getCustomerInvoiceDistributionListById()";
            logExcpUIobj.ResourceName = "CustomerInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerInvoiceDistributionFormDAL : getCustomerInvoiceDistributionListById] An error occured in the processing of Record Id : " + customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddCustomerInvoiceDistribution(CustomerInvoiceDistributionFormUI customerInvoiceDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoiceDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = customerInvoiceDistributionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = customerInvoiceDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_CustomerInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerInvoiceId"].Value = customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = customerInvoiceDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_GLAccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_GLAccountType"].Value = customerInvoiceDistributionFormUI.Opt_GLAccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = customerInvoiceDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = customerInvoiceDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = customerInvoiceDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = customerInvoiceDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = customerInvoiceDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = customerInvoiceDistributionFormUI.OriginatingCredit;
            

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddCustomerInvoiceDistribution()";
            logExcpUIobj.ResourceName = "CustomerInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerInvoiceDistributionFormDAL : AddCustomerInvoiceDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateCustomerInvoiceDistribution(CustomerInvoiceDistributionFormUI customerInvoiceDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoiceDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Tbl_CustomerInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_CustomerInvoiceDistributionId"].Value = customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = customerInvoiceDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = customerInvoiceDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_CustomerInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerInvoiceId"].Value = customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = customerInvoiceDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_GLAccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_GLAccountType"].Value = customerInvoiceDistributionFormUI.Opt_GLAccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = customerInvoiceDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = customerInvoiceDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = customerInvoiceDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = customerInvoiceDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = customerInvoiceDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = customerInvoiceDistributionFormUI.OriginatingCredit;            



                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateCustomerInvoiceDistribution()";
            logExcpUIobj.ResourceName = "CustomerInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerInvoiceDistributionFormDAL : UpdateCustomerInvoiceDistribution] An error occured in the processing of Record Id : " + customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteCustomerInvoiceDistribution(CustomerInvoiceDistributionFormUI customerInvoiceDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoiceDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CustomerInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerInvoiceDistributionId"].Value = customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteCustomerInvoiceDistribution()";
            logExcpUIobj.ResourceName = "CustomerInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerInvoiceDistributionFormDAL : DeleteCustomerInvoiceDistribution] An error occured in the processing of Record Id : " + customerInvoiceDistributionFormUI.Tbl_CustomerInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}