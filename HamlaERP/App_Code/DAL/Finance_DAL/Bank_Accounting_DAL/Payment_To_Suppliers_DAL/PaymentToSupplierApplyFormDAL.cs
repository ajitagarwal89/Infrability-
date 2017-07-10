using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;
/// <summary>
/// Summary description for PaymentToSupplierApplyFormDAL
/// </summary>
public class PaymentToSupplierApplyFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PaymentToSupplierApplyFormDAL()
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
            logExcpUIobj.MethodName = "PaymentToSupplierApplyFormDAL()";
            logExcpUIobj.ResourceName = "PaymentToSupplierApplyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentToSupplierApplyFormDAL : PaymentToSupplierApplyFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentToSupplierApplyListById(PaymentToSupplierApplyFormUI PaymentToSupplierApplyFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierApply_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierApplyId"].Value = PaymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId;

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
            logExcpUIobj.MethodName = "GetPaymentToSupplierApplyListById()";
            logExcpUIobj.ResourceName = "PaymentToSupplierApplyFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierApplyFormDAL : GetPaymentToSupplierApplyListById] An error occured in the processing of Record Id : " + PaymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPaymentToSupplierApply(PaymentToSupplierApplyFormUI PaymentToSupplierApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierApply_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = PaymentToSupplierApplyFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentToSupplierApplyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentToSupplierId"].Value = PaymentToSupplierApplyFormUI.Tbl_PaymentToSupplierId;

                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = PaymentToSupplierApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = PaymentToSupplierApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = PaymentToSupplierApplyFormUI.opt_ApplyToDocumentType;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = PaymentToSupplierApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = PaymentToSupplierApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = PaymentToSupplierApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = PaymentToSupplierApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = PaymentToSupplierApplyFormUI.DiscountDate;

                sqlCmd.Parameters.Add("@tbl_CurrencyId_ApplyToCurrency", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId_ApplyToCurrency"].Value = PaymentToSupplierApplyFormUI.Tbl_CurrencyId_ApplyToCurrency;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPaymentToSupplierApply()";
            logExcpUIobj.ResourceName = "PaymentToSupplierApplyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierApplyFormDAL : AddPaymentToSupplierApply] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdatePaymentToSupplierApply(PaymentToSupplierApplyFormUI PaymentToSupplierApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierApply_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = PaymentToSupplierApplyFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentToSupplierApplyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentToSupplierApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentToSupplierApplyId"].Value = PaymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId;

                sqlCmd.Parameters.Add("@Tbl_PaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentToSupplierId"].Value = PaymentToSupplierApplyFormUI.Tbl_PaymentToSupplierId;

                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = PaymentToSupplierApplyFormUI.opt_ApplyToDocumentType;

                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = PaymentToSupplierApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = PaymentToSupplierApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = PaymentToSupplierApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = PaymentToSupplierApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = PaymentToSupplierApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = PaymentToSupplierApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = PaymentToSupplierApplyFormUI.DiscountDate;

                sqlCmd.Parameters.Add("@tbl_CurrencyId_ApplyToCurrency", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId_ApplyToCurrency"].Value = PaymentToSupplierApplyFormUI.Tbl_CurrencyId_ApplyToCurrency;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentToSupplierApply()";
            logExcpUIobj.ResourceName = "PaymentToSupplierApplyFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierApplyFormDAL : UpdatePaymentToSupplierApply] An error occured in the processing of Record Id : " + PaymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int DeletePaymentToSupplierApply(PaymentToSupplierApplyFormUI PaymentToSupplierApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierApply_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierApplyId"].Value = PaymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentToSupplierApply()";
            logExcpUIobj.ResourceName = "PaymentToSupplierApplyFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierApplyFormDAL : DeletePaymentToSupplierApply] An error occured in the processing of Record Id : " + PaymentToSupplierApplyFormUI.Tbl_PaymentToSupplierApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}