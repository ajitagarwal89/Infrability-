using System;
using System.Data.SqlClient;
using System.Data;
using log4net;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.SessionState;
using System.Web;
using Finware;

/// <summary>
/// Summary description for PaymentFromCustomerApplyFormDAL
/// </summary>
public class PaymentFromCustomerApplyFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
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
    public DataTable GetPaymentFromCustomerApplyListById(PaymentFromCustomerApplyFormUI paymentFromCustomerApplyFormUI)
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
                sqlCmd.Parameters["@tbl_PaymentFromCustomerApplyId"].Value = paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl = ds.Tables[0];
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_PaymentFromCustomerApply", paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId, selectedValue);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPaymentFromCustomerApplyListById()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyFormDAL.CS";
            logExcpUIobj.RecordId = paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerApplyFormDAL : GetPaymentFromCustomerApplyListById] An error occured in the processing of Record Id : " + paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPaymentFromCustomerApply(PaymentFromCustomerApplyFormUI paymentFromCustomerApplyFormUI)
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
                sqlCmd.Parameters["@CreatedBy"].Value = paymentFromCustomerApplyFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentFromCustomerApplyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerId;

                //sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                //sqlCmd.Parameters["@ApplyDate"].Value = paymentFromCustomerApplyFormUI.ApplyDate;


                //sqlCmd.Parameters.Add("@Tbl_SourceDocumentId", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@Tbl_SourceDocumentId"].Value = paymentFromCustomerApplyFormUI.Tbl_SourceDocumentId;

                //sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                //sqlCmd.Parameters["@opt_DocumentType"].Value = paymentFromCustomerApplyFormUI.opt_DocumentType;

                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = paymentFromCustomerApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = paymentFromCustomerApplyFormUI.opt_ApplyToDocumentType;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = paymentFromCustomerApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = paymentFromCustomerApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = paymentFromCustomerApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = paymentFromCustomerApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = paymentFromCustomerApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = paymentFromCustomerApplyFormUI.DiscountDate;

                sqlCmd.Parameters.Add("@tbl_CurrencyId_ApplyToCurrency", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId_ApplyToCurrency"].Value = paymentFromCustomerApplyFormUI.Tbl_CurrencyId_ApplyToCurrency;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerApplyId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerApplyId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_PaymentFromCustomerApplyId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_PaymentFromCustomerApply";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(paymentFromCustomerApplyFormUI);
                    audit_IUD.WebServiceInsert(paymentFromCustomerApplyFormUI.Tbl_OrganizationId, tableName, RecoredID, paymentFromCustomerApplyFormUI.CreatedBy, newValue);
                    return 1;
                }
                else
                {
                    return 0;
                }

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
    public int UpdatePaymentFromCustomerApply(PaymentFromCustomerApplyFormUI paymentFromCustomerApplyFormUI)
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
                sqlCmd.Parameters["@ModifiedBy"].Value = paymentFromCustomerApplyFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentFromCustomerApplyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerApplyId"].Value = paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;

                sqlCmd.Parameters.Add("@tbl_PaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentFromCustomerId"].Value = paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerId;


                //sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                //sqlCmd.Parameters["@ApplyDate"].Value = paymentFromCustomerApplyFormUI.ApplyDate;

                //sqlCmd.Parameters.Add("@Tbl_SourceDocumentId", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@Tbl_SourceDocumentId"].Value = paymentFromCustomerApplyFormUI.Tbl_SourceDocumentId;

                //sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                //sqlCmd.Parameters["@opt_DocumentType"].Value = paymentFromCustomerApplyFormUI.opt_DocumentType;

                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = paymentFromCustomerApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = paymentFromCustomerApplyFormUI.opt_ApplyToDocumentType;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = paymentFromCustomerApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = paymentFromCustomerApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = paymentFromCustomerApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = paymentFromCustomerApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = paymentFromCustomerApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = paymentFromCustomerApplyFormUI.DiscountDate;

                sqlCmd.Parameters.Add("@tbl_CurrencyId_ApplyToCurrency", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId_ApplyToCurrency"].Value = paymentFromCustomerApplyFormUI.Tbl_CurrencyId_ApplyToCurrency;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(paymentFromCustomerApplyFormUI);
                    audit_IUD.WebServiceUpdate(paymentFromCustomerApplyFormUI.Tbl_OrganizationId, "tbl_PaymentFromCustomerApply", paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId, paymentFromCustomerApplyFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentFromCustomerApply()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyFormDAL.CS";
            logExcpUIobj.RecordId = paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerApplyFormDAL : UpdatePaymentFromCustomerApply] An error occured in the processing of Record Id : " + paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int DeletePaymentFromCustomerApply(PaymentFromCustomerApplyFormUI paymentFromCustomerApplyFormUI)
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
                sqlCmd.Parameters["@tbl_PaymentFromCustomerApplyId"].Value = paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_PaymentFromCustomerApply", paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentFromCustomerApply()";
            logExcpUIobj.ResourceName = "PaymentFromCustomerApplyFormDAL.CS";
            logExcpUIobj.RecordId = paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentFromCustomerApplyFormDAL : DeletePaymentFromCustomerApply] An error occured in the processing of Record Id : " + paymentFromCustomerApplyFormUI.Tbl_PaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}