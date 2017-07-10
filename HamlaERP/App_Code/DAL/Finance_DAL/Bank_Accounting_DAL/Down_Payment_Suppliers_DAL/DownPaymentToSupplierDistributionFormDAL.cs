using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for DownPaymentToSupplierDistributionFormDAL
/// </summary>
public class DownPaymentToSupplierDistributionFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public DownPaymentToSupplierDistributionFormDAL()
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
            logExcpUIobj.MethodName = "DownPaymentToSupplierDistributionFormDAL()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[DownPaymentToSupplierDistributionFormDAL : DownPaymentToSupplierDistributionFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetDownPaymentToSupplierDistributionListById(DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierDistribution_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierDistributionId"].Value = downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId;

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
            logExcpUIobj.MethodName = "GetDownPaymentToSupplierDistributionListById()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierDistributionFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentToSupplierDistributionFormDAL : GetDownPaymentToSupplierDistributionListById] An error occured in the processing of Record Id : " + downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddDownPaymentToSupplierDistribution(DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierDistribution_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = downPaymentToSupplierDistributionFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = downPaymentToSupplierDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierId"].Value = downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = downPaymentToSupplierDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = downPaymentToSupplierDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = downPaymentToSupplierDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = downPaymentToSupplierDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = downPaymentToSupplierDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = downPaymentToSupplierDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = downPaymentToSupplierDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = downPaymentToSupplierDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@CompanyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CompanyId"].Value = downPaymentToSupplierDistributionFormUI.CompanyId;

                sqlCmd.Parameters.Add("@CorrespondenceCompanyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CorrespondenceCompanyId"].Value = downPaymentToSupplierDistributionFormUI.CorrespondenceCompanyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddDownPaymentToSupplierDistribution()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierDistributionFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[DownPaymentToSupplierDistributionFormDAL : AddDownPaymentToSupplierDistribution] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdateDownPaymentToSupplierDistribution(DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierDistribution_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = downPaymentToSupplierDistributionFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = downPaymentToSupplierDistributionFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_DownPaymentToSupplierDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_DownPaymentToSupplierDistributionId"].Value = downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId;
                
                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierId"].Value = downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = downPaymentToSupplierDistributionFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = downPaymentToSupplierDistributionFormUI.opt_Type;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = downPaymentToSupplierDistributionFormUI.Debit;

                sqlCmd.Parameters.Add("@OriginatingDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingDebit"].Value = downPaymentToSupplierDistributionFormUI.OriginatingDebit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = downPaymentToSupplierDistributionFormUI.Credit;

                sqlCmd.Parameters.Add("@OriginatingCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@OriginatingCredit"].Value = downPaymentToSupplierDistributionFormUI.OriginatingCredit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = downPaymentToSupplierDistributionFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = downPaymentToSupplierDistributionFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@CompanyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CompanyId"].Value = downPaymentToSupplierDistributionFormUI.CompanyId;

                sqlCmd.Parameters.Add("@CorrespondenceCompanyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CorrespondenceCompanyId"].Value = downPaymentToSupplierDistributionFormUI.CorrespondenceCompanyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateDownPaymentToSupplierDistribution()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierDistributionFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[DownPaymentToSupplierDistributionFormDAL : UpdateDownPaymentToSupplierDistribution] An error occured in the processing of Record Id : " + downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteDownPaymentToSupplierDistribution(DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierDistribution_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierDistributionId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierDistributionId"].Value = downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteDownPaymentToSupplierDistribution()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierDistributionFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentToSupplierDistributionFormDAL : DeleteDownPaymentToSupplierDistribution] An error occured in the processing of Record Id : " + downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierDistributionId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetDownPaymentToSupplierDistribution_SelectByDownPaymentToSupplierId(DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierDistribution_SelectByDownPaymentToSupplierId", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierId"].Value = downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierId;

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
            logExcpUIobj.MethodName = "GetDownPaymentToSupplierDistribution_SelectByDownPaymentToSupplierId()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierDistributionFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentToSupplierDistributionFormDAL : GetDownPaymentToSupplierDistribution_SelectByDownPaymentToSupplierId] An error occured in the processing of Record Id : " + downPaymentToSupplierDistributionFormUI.Tbl_DownPaymentToSupplierId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
}