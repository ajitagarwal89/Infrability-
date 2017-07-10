using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for PaymentFromCustomerDistributionFormDAL
/// </summary>
public class PaymentFromCustomerDistributionFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public PaymentFromCustomerDistributionFormDAL()
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
            logExcpUIobj.MethodName = "PaymentFromCustomerDistributionFormDAL()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentFromCustomerDistributionFormDAL : PaymentFromCustomerDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentFromCustomerDistributionListById(PaymentFromCustomerDistributionFormUI PaymentFromCustomerDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerDistributionId"].Value = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;

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
            logExcpUIobj.MethodName = "GetPaymentFromCustomerDistributionListById()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerDistributionFormDAL : GetPaymentFromCustomerDistributionListById] An error occured in the processing of Record Id : " + PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddPaymentFromCustomerDistribution(PaymentFromCustomerDistributionFormUI paymentFromCustomerDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = paymentFromCustomerDistributionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentFromCustomerDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = paymentFromCustomerDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = paymentFromCustomerDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = paymentFromCustomerDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = paymentFromCustomerDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = paymentFromCustomerDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = paymentFromCustomerDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = paymentFromCustomerDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = paymentFromCustomerDistributionFormUI.DistributionReference;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPaymentFromCustomerDistribution()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentFromCustomerDistributionFormDAL : AddPaymentFromCustomerDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdatePaymentFromCustomerDistribution(PaymentFromCustomerDistributionFormUI PaymentFromCustomerDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = PaymentFromCustomerDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentFromCustomerDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentFromCustomerDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentFromCustomerDistributionId"].Value = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = PaymentFromCustomerDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = PaymentFromCustomerDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = PaymentFromCustomerDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = PaymentFromCustomerDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = PaymentFromCustomerDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = PaymentFromCustomerDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = PaymentFromCustomerDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = PaymentFromCustomerDistributionFormUI.DistributionReference;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentFromCustomerDistribution()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentFromCustomerDistributionFormDAL : UpdatePaymentFromCustomerDistribution] An error occured in the processing of Record Id : " + PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePaymentFromCustomerDistribution(PaymentFromCustomerDistributionFormUI PaymentFromCustomerDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerDistributionId"].Value = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentFromCustomerDistribution()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerDistributionFormDAL : DeletePaymentFromCustomerDistribution] An error occured in the processing of Record Id : " + PaymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }


    public DataTable GetPaymentFromCustomerDistribution_SelectByPaymentFromCustomerId(PaymentFromCustomerDistributionFormUI paymentFromCustomerDistributionFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerDistribution_SelectByPaymentFromCustomerId", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerId;

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
            logExcpUIobj.MethodName = "GetPaymentFromCustomerDistribution_SelectByPaymentFromCustomerId()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerDistributionFormDAL.CS";
            logExcpUIobj.RecordId = paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerDistributionFormDAL : GetPaymentFromCustomerDistribution_SelectByPaymentFromCustomerId] An error occured in the processing of Record Id : " + paymentFromCustomerDistributionFormUI.Tbl_PaymentFromCustomerId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
}