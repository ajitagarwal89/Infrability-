using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for PaymentToSupplierEmployeeDistributionFormDAL
/// </summary>
public class PaymentToSupplierEmployeeDistributionFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public PaymentToSupplierEmployeeDistributionFormDAL()
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
            logExcpUIobj.MethodName = "PaymentToSupplierEmployeeDistributionFormDAL()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentToSupplierEmployeeDistributionFormDAL : PaymentToSupplierEmployeeDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentToSupplierEmployeeDistributionListById(PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeDistributionId"].Value = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId;

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
            logExcpUIobj.MethodName = "GetPaymentToSupplierEmployeeDistributionListById()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeDistributionFormDAL : GetPaymentToSupplierEmployeeDistributionListById] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddPaymentToSupplierEmployeeDistribution(PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = paymentToSupplierEmployeeDistributionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentToSupplierEmployeeDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeId"].Value = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = paymentToSupplierEmployeeDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = paymentToSupplierEmployeeDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = paymentToSupplierEmployeeDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = paymentToSupplierEmployeeDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = paymentToSupplierEmployeeDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = paymentToSupplierEmployeeDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = paymentToSupplierEmployeeDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = paymentToSupplierEmployeeDistributionFormUI.DistributionReference;

                //sqlCmd.Parameters.Add("@CompanyId", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@CompanyId"].Value = paymentToSupplierEmployeeDistributionFormUI.CompanyId;

                sqlCmd.Parameters.Add("@tbl_OrganizationIdCorrespondence", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationIdCorrespondence"].Value = paymentToSupplierEmployeeDistributionFormUI.Tbl_OrganizationIdCorrespondence;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPaymentToSupplierEmployeeDistribution()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToSupplierEmployeeDistributionFormDAL : AddPaymentToSupplierEmployeeDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdatePaymentToSupplierEmployeeDistribution(PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = paymentToSupplierEmployeeDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentToSupplierEmployeeDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentToSupplierEmployeeDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentToSupplierEmployeeDistributionId"].Value = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeId"].Value = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = paymentToSupplierEmployeeDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = paymentToSupplierEmployeeDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = paymentToSupplierEmployeeDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = paymentToSupplierEmployeeDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = paymentToSupplierEmployeeDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = paymentToSupplierEmployeeDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = paymentToSupplierEmployeeDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = paymentToSupplierEmployeeDistributionFormUI.DistributionReference;

                //sqlCmd.Parameters.Add("@CompanyId", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@CompanyId"].Value = paymentToSupplierEmployeeDistributionFormUI.CompanyId;

                //sqlCmd.Parameters.Add("@CorrespondenceCompanyId", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@CorrespondenceCompanyId"].Value = paymentToSupplierEmployeeDistributionFormUI.CorrespondenceCompanyId;
                sqlCmd.Parameters.Add("@tbl_OrganizationIdCorrespondence", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationIdCorrespondence"].Value = paymentToSupplierEmployeeDistributionFormUI.Tbl_OrganizationIdCorrespondence;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentToSupplierEmployeeDistribution()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToSupplierEmployeeDistributionFormDAL : UpdatePaymentToSupplierEmployeeDistribution] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePaymentToSupplierEmployeeDistribution(PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeDistributionId"].Value = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentToSupplierEmployeeDistribution()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeDistributionFormDAL : DeletePaymentToSupplierEmployeeDistribution] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetPaymentToSupplierEmployeeDistribution_SelectByPaymentToEmployeeId(PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeDistribution_SelectByPaymentToEmployeeId", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeId"].Value = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeId;

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
            logExcpUIobj.MethodName = "GetPaymentToSupplierEmployeeDistribution_SelectByPaymentToEmployeeId()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeDistributionFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeDistributionFormDAL : GetPaymentToSupplierEmployeeDistribution_SelectByPaymentToEmployeeId] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeDistributionFormUI.Tbl_PaymentToSupplierEmployeeId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
}