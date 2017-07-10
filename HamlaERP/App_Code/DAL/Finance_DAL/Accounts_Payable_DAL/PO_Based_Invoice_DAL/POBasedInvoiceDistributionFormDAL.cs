using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for POBasedInvoiceDistributionFormDAL
/// </summary>
public class POBasedInvoiceDistributionFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public POBasedInvoiceDistributionFormDAL()
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
            logExcpUIobj.MethodName = "POBasedInvoiceDistributionFormDAL()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[POBasedInvoiceDistributionFormDAL : POBasedInvoiceDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetPOBasedInvoiceDistributionListById(POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceDistributionId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;

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
            logExcpUIobj.MethodName = "getPOBasedInvoiceDistributionListById()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDistributionFormDAL : getPOBasedInvoiceDistributionListById] An error occured in the processing of Record Id : " + pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPOBasedInvoiceDistribution(POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = pOBasedInvoiceDistributionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_GLAccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_GLAccountType"].Value = pOBasedInvoiceDistributionFormUI.opt_GLAccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = pOBasedInvoiceDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = pOBasedInvoiceDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = pOBasedInvoiceDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = pOBasedInvoiceDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = pOBasedInvoiceDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = pOBasedInvoiceDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@ExchangeRate", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExchangeRate"].Value = pOBasedInvoiceDistributionFormUI.ExchangeRate;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPOBasedInvoiceDistribution()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDistributionFormDAL : AddPOBasedInvoiceDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePOBasedInvoiceDistribution(POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = pOBasedInvoiceDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceDistributionId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_GLAccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_GLAccountType"].Value = pOBasedInvoiceDistributionFormUI.opt_GLAccountType;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = pOBasedInvoiceDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = pOBasedInvoiceDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = pOBasedInvoiceDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = pOBasedInvoiceDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = pOBasedInvoiceDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = pOBasedInvoiceDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@ExchangeRate", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExchangeRate"].Value = pOBasedInvoiceDistributionFormUI.ExchangeRate;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePOBasedInvoiceDistribution()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDistributionFormDAL : UpdatePOBasedInvoiceDistribution] An error occured in the processing of Record Id : " + pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePOBasedInvoiceDistribution(POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceDistributionId"].Value = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePOBasedInvoiceDistribution()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDistributionFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDistributionFormDAL : DeletePOBasedInvoiceDistribution] An error occured in the processing of Record Id : " + pOBasedInvoiceDistributionFormUI.Tbl_POBasedInvoiceDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}