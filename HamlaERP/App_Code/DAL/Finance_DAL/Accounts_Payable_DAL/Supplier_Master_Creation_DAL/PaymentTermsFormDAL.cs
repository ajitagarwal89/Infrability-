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
/// Summary description for PaymentTermsFormDAL
/// </summary>
public class PaymentTermsFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PaymentTermsFormDAL()
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
            logExcpUIobj.MethodName = "PaymentTermsFormDAL()";
            logExcpUIobj.ResourceName = "PaymentTermsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentTermsFormDAL : PaymentTermsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetPaymentTermsListById(PaymentTermsFormUI paymentTermsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentTerms_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = paymentTermsFormUI.Tbl_PaymentTermsId;

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
                audit_IUD.WebServiceSelectInsert("tbl_PaymentTerms", paymentTermsFormUI.Tbl_PaymentTermsId, selectedValue);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getPaymentTermsListById()";
            logExcpUIobj.ResourceName = "PaymentTermsFormDAL.CS";
            logExcpUIobj.RecordId = paymentTermsFormUI.Tbl_PaymentTermsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentTermsFormDAL : getPaymentTermsListById] An error occured in the processing of Record Id : " + paymentTermsFormUI.Tbl_PaymentTermsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPaymentTerms(PaymentTermsFormUI paymentTermsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentTerms_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = paymentTermsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentTermsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@PaymentTermsName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentTermsName"].Value = paymentTermsFormUI.PaymentTermsName;

                sqlCmd.Parameters.Add("@DueInDays", SqlDbType.Int);
                sqlCmd.Parameters["@DueInDays"].Value = paymentTermsFormUI.DueInDays;

                sqlCmd.Parameters.Add("@DiscountInDays", SqlDbType.Int);
                sqlCmd.Parameters["@DiscountInDays"].Value = paymentTermsFormUI.DiscountInDays;

                sqlCmd.Parameters.Add("@Opt_DiscountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_DiscountType"].Value = paymentTermsFormUI.Opt_DiscountType;

                sqlCmd.Parameters.Add("@DiscountTypeValue", SqlDbType.Decimal);
                sqlCmd.Parameters["@DiscountTypeValue"].Value = paymentTermsFormUI.DiscountTypeValue;

                sqlCmd.Parameters.Add("@SalesOrPurchase", SqlDbType.Bit);
                sqlCmd.Parameters["@SalesOrPurchase"].Value = paymentTermsFormUI.SalesOrPurchase;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_PaymentTermsId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_PaymentTerms";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(paymentTermsFormUI);
                    audit_IUD.WebServiceInsert(paymentTermsFormUI.Tbl_OrganizationId, tableName, recordID, paymentTermsFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddPaymentTerms()";
            logExcpUIobj.ResourceName = "PaymentTermsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentTermsFormDAL : AddPaymentTerms] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePaymentTerms(PaymentTermsFormUI paymentTermsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentTerms_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = paymentTermsFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = paymentTermsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentTermsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@PaymentTermsName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentTermsName"].Value = paymentTermsFormUI.PaymentTermsName;

                sqlCmd.Parameters.Add("@DueInDays", SqlDbType.Int);
                sqlCmd.Parameters["@DueInDays"].Value = paymentTermsFormUI.DueInDays;

                sqlCmd.Parameters.Add("@DiscountInDays", SqlDbType.Int);
                sqlCmd.Parameters["@DiscountInDays"].Value = paymentTermsFormUI.DiscountInDays;

                sqlCmd.Parameters.Add("@Opt_DiscountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_DiscountType"].Value = paymentTermsFormUI.Opt_DiscountType;

                sqlCmd.Parameters.Add("@DiscountTypeValue", SqlDbType.Decimal);
                sqlCmd.Parameters["@DiscountTypeValue"].Value = paymentTermsFormUI.DiscountTypeValue;

                sqlCmd.Parameters.Add("@SalesOrPurchase", SqlDbType.Bit);
                sqlCmd.Parameters["@SalesOrPurchase"].Value = paymentTermsFormUI.SalesOrPurchase;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(paymentTermsFormUI);
                    audit_IUD.WebServiceUpdate(paymentTermsFormUI.Tbl_OrganizationId, "tbl_PaymentTerms", paymentTermsFormUI.Tbl_PaymentTermsId, paymentTermsFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentTerms()";
            logExcpUIobj.ResourceName = "PaymentTermsFormDAL.CS";
            logExcpUIobj.RecordId = paymentTermsFormUI.Tbl_PaymentTermsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentTermsFormDAL : UpdatePaymentTerms] An error occured in the processing of Record Id : " + paymentTermsFormUI.Tbl_PaymentTermsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePaymentTerms(PaymentTermsFormUI paymentTermsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentTerms_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = paymentTermsFormUI.Tbl_PaymentTermsId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_PaymentTerms", paymentTermsFormUI.Tbl_PaymentTermsId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentTerms()";
            logExcpUIobj.ResourceName = "PaymentTermsFormDAL.CS";
            logExcpUIobj.RecordId = paymentTermsFormUI.Tbl_PaymentTermsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentTermsFormDAL : DeletePaymentTerms] An error occured in the processing of Record Id : " + paymentTermsFormUI.Tbl_PaymentTermsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}