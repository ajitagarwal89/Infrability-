using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for PaymentToSupplierDistributionFormDAL
/// </summary>
public class PaymentToSupplierDistributionFormDAL
{

    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public PaymentToSupplierDistributionFormDAL()
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
            logExcpUIobj.MethodName = "PaymentToSupplierDistributionFormDAL()";
            logExcpUIobj.ResourceName = "PaymentToSupplierDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentToSupplierDistributionFormDAL : PaymentToSupplierDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentToSupplierDistributionListById(PaymentToSupplierDistributionFormUI PaymentToSupplierDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierDistributionId"].Value = PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId;

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
            logExcpUIobj.MethodName = "GetPaymentToSupplierDistributionListById()";
            logExcpUIobj.ResourceName = "PaymentToSupplierDistributionFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierDistributionFormDAL : GetPaymentToSupplierDistributionListById] An error occured in the processing of Record Id : " + PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddPaymentToSupplierDistribution(PaymentToSupplierDistributionFormUI PaymentToSupplierDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = PaymentToSupplierDistributionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentToSupplierDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierId"].Value = PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = PaymentToSupplierDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = PaymentToSupplierDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = PaymentToSupplierDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = PaymentToSupplierDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = PaymentToSupplierDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = PaymentToSupplierDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = PaymentToSupplierDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = PaymentToSupplierDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@CompanyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CompanyId"].Value = PaymentToSupplierDistributionFormUI.CompanyId;

                sqlCmd.Parameters.Add("@CorrespondenceCompanyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CorrespondenceCompanyId"].Value = PaymentToSupplierDistributionFormUI.CorrespondenceCompanyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPaymentToSupplierDistribution()";
            logExcpUIobj.ResourceName = "PaymentToSupplierDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToSupplierDistributionFormDAL : AddPaymentToSupplierDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdatePaymentToSupplierDistribution(PaymentToSupplierDistributionFormUI PaymentToSupplierDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = PaymentToSupplierDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentToSupplierDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentToSupplierDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentToSupplierDistributionId"].Value = PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierId"].Value = PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = PaymentToSupplierDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = PaymentToSupplierDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = PaymentToSupplierDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = PaymentToSupplierDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = PaymentToSupplierDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = PaymentToSupplierDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = PaymentToSupplierDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = PaymentToSupplierDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@CompanyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CompanyId"].Value = PaymentToSupplierDistributionFormUI.CompanyId;

                sqlCmd.Parameters.Add("@CorrespondenceCompanyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CorrespondenceCompanyId"].Value = PaymentToSupplierDistributionFormUI.CorrespondenceCompanyId;
                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentToSupplierDistribution()";
            logExcpUIobj.ResourceName = "PaymentToSupplierDistributionFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToSupplierDistributionFormDAL : UpdatePaymentToSupplierDistribution] An error occured in the processing of Record Id : " + PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePaymentToSupplierDistribution(PaymentToSupplierDistributionFormUI PaymentToSupplierDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierDistributionId"].Value = PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentToSupplierDistribution()";
            logExcpUIobj.ResourceName = "PaymentToSupplierDistributionFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierDistributionFormDAL : DeletePaymentToSupplierDistribution] An error occured in the processing of Record Id : " + PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetPaymentToSupplierDistribution_SelectByPaymentToSupplierId(PaymentToSupplierDistributionFormUI PaymentToSupplierDistributionFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierDistribution_SelectByPaymentToSupplierId", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierId"].Value = PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierId;

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
            logExcpUIobj.MethodName = "GetPaymentToSupplierDistribution_SelectByPaymentToSupplierId()";
            logExcpUIobj.ResourceName = "PaymentToSupplierDistributionFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierDistributionFormDAL : GetPaymentToSupplierDistribution_SelectByPaymentToSupplierId] An error occured in the processing of Record Id : " + PaymentToSupplierDistributionFormUI.Tbl_PaymentToSupplierId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
}