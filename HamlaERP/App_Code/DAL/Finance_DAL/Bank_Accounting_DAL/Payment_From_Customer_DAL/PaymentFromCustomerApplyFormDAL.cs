using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for PaymentFromCustomerApplyFormDAL
/// </summary>
public class PaymentFromCustomerApplyFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PaymentFromCustomerApplyFormDAL()
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
            logExcpUIobj.MethodName = "PaymentFromCustomerApplyFormDAL()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentFromCustomerApplyFormDAL : PaymentFromCustomerApplyFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentFromCustomerApplyListById(PaymentFromCustomerApplyFormUI PaymentFromCustomerApplyFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerApply_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerApplyId"].Value = PaymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;

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
            logExcpUIobj.MethodName = "GetPaymentFromCustomerApplyListById()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyFormDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerApplyFormDAL : GetPaymentFromCustomerApplyListById] An error occured in the processing of Record Id : " + PaymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPaymentFromCustomerApply(PaymentFromCustomerApplyFormUI PaymentFromCustomerApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerApply_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = PaymentFromCustomerApplyFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentFromCustomerApplyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = PaymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerId;

                //sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                //sqlCmd.Parameters["@ApplyDate"].Value = PaymentFromCustomerApplyFormUI.ApplyDate;


                //sqlCmd.Parameters.Add("@Tbl_SourceDocumentId", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@Tbl_SourceDocumentId"].Value = PaymentFromCustomerApplyFormUI.Tbl_SourceDocumentId;

                //sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                //sqlCmd.Parameters["@opt_DocumentType"].Value = PaymentFromCustomerApplyFormUI.opt_DocumentType;

                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = PaymentFromCustomerApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = PaymentFromCustomerApplyFormUI.opt_ApplyToDocumentType;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = PaymentFromCustomerApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = PaymentFromCustomerApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = PaymentFromCustomerApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = PaymentFromCustomerApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = PaymentFromCustomerApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = PaymentFromCustomerApplyFormUI.DiscountDate;

                sqlCmd.Parameters.Add("@tbl_CurrencyId_ApplyToCurrency", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId_ApplyToCurrency"].Value = PaymentFromCustomerApplyFormUI.Tbl_CurrencyId_ApplyToCurrency;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPaymentFromCustomerApply()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerApplyFormDAL : AddPaymentFromCustomerApply] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdatePaymentFromCustomerApply(PaymentFromCustomerApplyFormUI PaymentFromCustomerApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerApply_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = PaymentFromCustomerApplyFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentFromCustomerApplyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerApplyId"].Value = PaymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = PaymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerId;


                //sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                //sqlCmd.Parameters["@ApplyDate"].Value = PaymentFromCustomerApplyFormUI.ApplyDate;

                //sqlCmd.Parameters.Add("@Tbl_SourceDocumentId", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@Tbl_SourceDocumentId"].Value = PaymentFromCustomerApplyFormUI.Tbl_SourceDocumentId;

                //sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                //sqlCmd.Parameters["@opt_DocumentType"].Value = PaymentFromCustomerApplyFormUI.opt_DocumentType;

                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = PaymentFromCustomerApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = PaymentFromCustomerApplyFormUI.opt_ApplyToDocumentType;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = PaymentFromCustomerApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = PaymentFromCustomerApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = PaymentFromCustomerApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = PaymentFromCustomerApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = PaymentFromCustomerApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = PaymentFromCustomerApplyFormUI.DiscountDate;

                sqlCmd.Parameters.Add("@tbl_CurrencyId_ApplyToCurrency", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId_ApplyToCurrency"].Value = PaymentFromCustomerApplyFormUI.Tbl_CurrencyId_ApplyToCurrency;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentFromCustomerApply()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyFormDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerApplyFormDAL : UpdatePaymentFromCustomerApply] An error occured in the processing of Record Id : " + PaymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int DeletePaymentFromCustomerApply(PaymentFromCustomerApplyFormUI PaymentFromCustomerApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentFromCustomerApply_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerApplyId"].Value = PaymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentFromCustomerApply()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyFormDAL.CS";
            logExcpUIobj.RecordId = PaymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerApplyFormDAL : DeletePaymentFromCustomerApply] An error occured in the processing of Record Id : " + PaymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}