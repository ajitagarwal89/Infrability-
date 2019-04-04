using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for PaymentToSupplierEmployeeApplyFormDAL
/// </summary>
public class PaymentToSupplierEmployeeApplyFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PaymentToSupplierEmployeeApplyFormDAL()
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
            logExcpUIobj.MethodName = "PaymentToSupplierEmployeeApplyFormDAL()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeApplyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentToSupplierEmployeeApplyFormDAL : PaymentToSupplierEmployeeApplyFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentToSupplierEmployeeApplyListById(PaymentToSupplierEmployeeApplyFormUI paymentToSupplierEmployeeApplyFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeApply_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeApplyId"].Value = paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId;

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
            logExcpUIobj.MethodName = "GetPaymentToSupplierEmployeeApplyListById()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeApplyFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeApplyFormDAL : GetPaymentToSupplierEmployeeApplyListById] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPaymentToSupplierEmployeeApply(PaymentToSupplierEmployeeApplyFormUI paymentToSupplierEmployeeApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeApply_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = paymentToSupplierEmployeeApplyFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentToSupplierEmployeeApplyFormUI.Tbl_OrganizationId;


                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeId"].Value = paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeId;


                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = paymentToSupplierEmployeeApplyFormUI.opt_ApplyToDocumentType;

                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = paymentToSupplierEmployeeApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = paymentToSupplierEmployeeApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = paymentToSupplierEmployeeApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = paymentToSupplierEmployeeApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = paymentToSupplierEmployeeApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = paymentToSupplierEmployeeApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = paymentToSupplierEmployeeApplyFormUI.DiscountDate;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPaymentToSupplierEmployeeApply()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeApplyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeApplyFormDAL : AddPaymentToSupplierEmployeeApply] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdatePaymentToSupplierEmployeeApply(PaymentToSupplierEmployeeApplyFormUI paymentToSupplierEmployeeApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeApply_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = paymentToSupplierEmployeeApplyFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentToSupplierEmployeeApplyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentToSupplierEmployeeApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentToSupplierEmployeeApplyId"].Value = paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeId"].Value = paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeId;

                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = paymentToSupplierEmployeeApplyFormUI.opt_ApplyToDocumentType;

                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = paymentToSupplierEmployeeApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = paymentToSupplierEmployeeApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = paymentToSupplierEmployeeApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = paymentToSupplierEmployeeApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = paymentToSupplierEmployeeApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = paymentToSupplierEmployeeApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = paymentToSupplierEmployeeApplyFormUI.DiscountDate;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentToSupplierEmployeeApply()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeApplyFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeApplyFormDAL : UpdatePaymentToSupplierEmployeeApply] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int DeletePaymentToSupplierEmployeeApply(PaymentToSupplierEmployeeApplyFormUI paymentToSupplierEmployeeApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplierEmployeeApply_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierEmployeeApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierEmployeeApplyId"].Value = paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentToSupplierEmployeeApply()";
            logExcpUIobj.ResourceName = "PaymentToSupplierEmployeeApplyFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToSupplierEmployeeApplyFormDAL : DeletePaymentToSupplierEmployeeApply] An error occured in the processing of Record Id : " + paymentToSupplierEmployeeApplyFormUI.Tbl_PaymentToSupplierEmployeeApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}