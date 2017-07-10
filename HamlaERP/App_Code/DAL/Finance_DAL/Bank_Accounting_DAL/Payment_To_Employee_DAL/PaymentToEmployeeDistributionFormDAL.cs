using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;
/// <summary>
/// Summary description for PaymentToEmployeeDistributionFormDAL
/// </summary>
public class PaymentToEmployeeDistributionFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public PaymentToEmployeeDistributionFormDAL()
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
            logExcpUIobj.MethodName = "PaymentToEmployeeDistributionFormDAL()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentToEmployeeDistributionFormDAL : PaymentToEmployeeDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentToEmployeeDistributionListById(PaymentToEmployeeDistributionFormUI PaymentToEmployeeDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeDistributionId"].Value = PaymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;

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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeDistributionListById()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeDistributionFormDAL : GetPaymentToEmployeeDistributionListById] An error occured in the processing of Record Id : " + PaymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddPaymentToEmployeeDistribution(PaymentToEmployeeDistributionFormUI PaymentToEmployeeDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = PaymentToEmployeeDistributionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentToEmployeeDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeId"].Value = PaymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = PaymentToEmployeeDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = PaymentToEmployeeDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = PaymentToEmployeeDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = PaymentToEmployeeDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = PaymentToEmployeeDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = PaymentToEmployeeDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = PaymentToEmployeeDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = PaymentToEmployeeDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@CompanyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CompanyId"].Value = PaymentToEmployeeDistributionFormUI.CompanyId;

                sqlCmd.Parameters.Add("@CorrespondenceCompanyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CorrespondenceCompanyId"].Value = PaymentToEmployeeDistributionFormUI.CorrespondenceCompanyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPaymentToEmployeeDistribution()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToEmployeeDistributionFormDAL : AddPaymentToEmployeeDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdatePaymentToEmployeeDistribution(PaymentToEmployeeDistributionFormUI PaymentToEmployeeDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = PaymentToEmployeeDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentToEmployeeDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentToEmployeeDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentToEmployeeDistributionId"].Value = PaymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeId"].Value = PaymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = PaymentToEmployeeDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = PaymentToEmployeeDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = PaymentToEmployeeDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = PaymentToEmployeeDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = PaymentToEmployeeDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = PaymentToEmployeeDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = PaymentToEmployeeDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = PaymentToEmployeeDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@CompanyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CompanyId"].Value = PaymentToEmployeeDistributionFormUI.CompanyId;

                sqlCmd.Parameters.Add("@CorrespondenceCompanyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CorrespondenceCompanyId"].Value = PaymentToEmployeeDistributionFormUI.CorrespondenceCompanyId;
                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentToEmployeeDistribution()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToEmployeeDistributionFormDAL : UpdatePaymentToEmployeeDistribution] An error occured in the processing of Record Id : " + PaymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePaymentToEmployeeDistribution(PaymentToEmployeeDistributionFormUI PaymentToEmployeeDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeDistributionId"].Value = PaymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentToEmployeeDistribution()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeDistributionFormDAL : DeletePaymentToEmployeeDistribution] An error occured in the processing of Record Id : " + PaymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetPaymentToEmployeeDistribution_SelectByPaymentToEmployeeId(PaymentToEmployeeDistributionFormUI paymentToEmployeeDistributionFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeDistribution_SelectByPaymentToEmployeeId", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeId"].Value = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId;

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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeDistribution_SelectByPaymentToEmployeeId()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeDistributionFormDAL : GetPaymentToEmployeeDistribution_SelectByPaymentToEmployeeId] An error occured in the processing of Record Id : " + paymentToEmployeeDistributionFormUI.Tbl_PaymentToEmployeeId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
   

}