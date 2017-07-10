using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for NonPOBasedInvoiceDistributionFormDAL
/// </summary>
public class NonPOBasedInvoiceDistributionFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public NonPOBasedInvoiceDistributionFormDAL()
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
            logExcpUIobj.MethodName = "NonPOBasedInvoiceDistributionFormDAL()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[nonPOBasedInvoiceDistributionFormDAL : NonPOBasedInvoiceDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetNonPOBasedInvoiceDistributionListById(NonPOBasedInvoiceDistributionFormUI nonPOBasedInvoiceDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoiceDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_NonPOBasedInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_NonPOBasedInvoiceDistributionId"].Value = nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId;

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
            logExcpUIobj.MethodName = "getNonPOBasedInvoiceDistributionListById()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[NonPOBasedInvoiceDistributionFormDAL : getNonPOBasedInvoiceDistributionListById] An error occured in the processing of Record Id : " + nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddNonPOBasedInvoiceDistribution(NonPOBasedInvoiceDistributionFormUI nonPOBasedInvoiceDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoiceDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = nonPOBasedInvoiceDistributionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = nonPOBasedInvoiceDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_NonPOBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_NonPOBasedInvoiceId"].Value = nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = nonPOBasedInvoiceDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_GLAccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_GLAccountType"].Value = nonPOBasedInvoiceDistributionFormUI.Opt_GLAccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = nonPOBasedInvoiceDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = nonPOBasedInvoiceDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = nonPOBasedInvoiceDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = nonPOBasedInvoiceDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = nonPOBasedInvoiceDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = nonPOBasedInvoiceDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@ExchangeRate", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExchangeRate"].Value = nonPOBasedInvoiceDistributionFormUI.ExchangeRate;       

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddNonPOBasedInvoiceDistribution()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[NonPOBasedInvoiceDistributionFormDAL : AddNonPOBasedInvoiceDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateNonPOBasedInvoiceDistribution(NonPOBasedInvoiceDistributionFormUI nonPOBasedInvoiceDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoiceDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Tbl_NonPOBasedInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_NonPOBasedInvoiceDistributionId"].Value = nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = nonPOBasedInvoiceDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = nonPOBasedInvoiceDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_NonPOBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_NonPOBasedInvoiceId"].Value = nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = nonPOBasedInvoiceDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_GLAccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_GLAccountType"].Value = nonPOBasedInvoiceDistributionFormUI.Opt_GLAccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = nonPOBasedInvoiceDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = nonPOBasedInvoiceDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = nonPOBasedInvoiceDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = nonPOBasedInvoiceDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = nonPOBasedInvoiceDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = nonPOBasedInvoiceDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@ExchangeRate", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExchangeRate"].Value = nonPOBasedInvoiceDistributionFormUI.ExchangeRate;



                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateNonPOBasedInvoiceDistribution()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[NonPOBasedInvoiceDistributionFormDAL : UpdateNonPOBasedInvoiceDistribution] An error occured in the processing of Record Id : " + nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteNonPOBasedInvoiceDistribution(NonPOBasedInvoiceDistributionFormUI nonPOBasedInvoiceDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_NonPOBasedInvoiceDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_NonPOBasedInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_NonPOBasedInvoiceDistributionId"].Value = nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteNonPOBasedInvoiceDistribution()";
            logExcpUIobj.ResourceName = "NonPOBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[NonPOBasedInvoiceDistributionFormDAL : DeleteNonPOBasedInvoiceDistribution] An error occured in the processing of Record Id : " + nonPOBasedInvoiceDistributionFormUI.Tbl_NonPOBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}