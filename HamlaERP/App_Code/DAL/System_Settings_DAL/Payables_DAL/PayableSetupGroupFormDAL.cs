using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.SessionState;
using Finware;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for PayableSetupGroupFormDAL
/// </summary>
public class PayableSetupGroupFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public PayableSetupGroupFormDAL()
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
            logExcpUIobj.MethodName = "PayableSetupGroupFormDAL()";
            logExcpUIobj.ResourceName = "PayableSetupGroupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PayableSetupGroupFormDAL : PayableSetupGroupFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPayableSetupGroupListById(PayableSetupGroupFormUI payableSetupGroupFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupGroup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PayableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupGroupId"].Value = payableSetupGroupFormUI.Tbl_PayableSetupGroupId;

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
                audit_IUD.WebServiceSelectInsert("tbl_PayableSetupGroup", payableSetupGroupFormUI.Tbl_PayableSetupGroupId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPayableSetupGroupListById()";
            logExcpUIobj.ResourceName = "PayableSetupGroupFormDAL.CS";
            logExcpUIobj.RecordId = payableSetupGroupFormUI.Tbl_PayableSetupGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupGroupFormDAL : GetPayableSetupGroupListById] An error occured in the processing of Record Id : " + payableSetupGroupFormUI.Tbl_PayableSetupGroupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddPayableSetupGroup(PayableSetupGroupFormUI payableSetupGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupGroup_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = payableSetupGroupFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = payableSetupGroupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PayableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupId"].Value = payableSetupGroupFormUI.tbl_PayableSetup;

                sqlCmd.Parameters.Add("@tbl_PayableSetupGroupId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupGroupId_Self"].Value = payableSetupGroupFormUI.tbl_PayableSetupGroupId_Self;

                sqlCmd.Parameters.Add("@Default", SqlDbType.Bit);
                sqlCmd.Parameters["@Default"].Value = payableSetupGroupFormUI.Default;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = payableSetupGroupFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = payableSetupGroupFormUI.tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = payableSetupGroupFormUI.tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@PaymentPriority", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentPriority"].Value = payableSetupGroupFormUI.PaymentPriority;

                sqlCmd.Parameters.Add("@MinimumOrder", SqlDbType.NVarChar);
                sqlCmd.Parameters["@MinimumOrder"].Value = payableSetupGroupFormUI.MinimumOrder;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@TradeDiscount"].Value = payableSetupGroupFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Opt_MinimumPayment", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MinimumPayment"].Value = payableSetupGroupFormUI.Opt_MinimumPayment;

                sqlCmd.Parameters.Add("@Opt_MaximumInvoiceAmt", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MaximumInvoiceAmt"].Value = payableSetupGroupFormUI.Opt_MaximumInvoiceAmt;

                sqlCmd.Parameters.Add("@Opt_CreditLimit", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_CreditLimit"].Value = payableSetupGroupFormUI.Opt_CreditLimit;

                sqlCmd.Parameters.Add("@Opt_WriteOff", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_WriteOff"].Value = payableSetupGroupFormUI.Opt_WriteOff;

                sqlCmd.Parameters.Add("@CalenderYear", SqlDbType.Bit);
                sqlCmd.Parameters["@CalenderYear"].Value = payableSetupGroupFormUI.CalenderYear;

                sqlCmd.Parameters.Add("@Transaction", SqlDbType.Bit);
                sqlCmd.Parameters["@Transaction"].Value = payableSetupGroupFormUI.Transaction;

                sqlCmd.Parameters.Add("@FiscalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@FiscalYear"].Value = payableSetupGroupFormUI.FiscalYear;

                sqlCmd.Parameters.Add("@Distribution", SqlDbType.Bit);
                sqlCmd.Parameters["@Distribution"].Value = payableSetupGroupFormUI.Distribution;

                sqlCmd.Parameters.Add("@tbl_PayableSetupGroupId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_PayableSetupGroupId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_PayableSetupGroupId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_PayableSetupGroup";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(payableSetupGroupFormUI);
                    audit_IUD.WebServiceInsert(payableSetupGroupFormUI.Tbl_OrganizationId, tableName, RecoredID, payableSetupGroupFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddPayableSetupGroup()";
            logExcpUIobj.ResourceName = "PayableSetupGroupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupGroupFormDAL : AddPayableSetupGroup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int UpdatePayableSetupGroup(PayableSetupGroupFormUI payableSetupGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupGroup_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = payableSetupGroupFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = payableSetupGroupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PayableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupGroupId"].Value = payableSetupGroupFormUI.Tbl_PayableSetupGroupId;

                sqlCmd.Parameters.Add("@tbl_PayableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupId"].Value = payableSetupGroupFormUI.tbl_PayableSetup;

                sqlCmd.Parameters.Add("@tbl_PayableSetupGroupId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupGroupId_Self"].Value = payableSetupGroupFormUI.tbl_PayableSetupGroupId_Self;

                sqlCmd.Parameters.Add("@Default", SqlDbType.Bit);
                sqlCmd.Parameters["@Default"].Value = payableSetupGroupFormUI.Default;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = payableSetupGroupFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = payableSetupGroupFormUI.tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = payableSetupGroupFormUI.tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@PaymentPriority", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentPriority"].Value = payableSetupGroupFormUI.PaymentPriority;

                sqlCmd.Parameters.Add("@MinimumOrder", SqlDbType.NVarChar);
                sqlCmd.Parameters["@MinimumOrder"].Value = payableSetupGroupFormUI.MinimumOrder;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@TradeDiscount"].Value = payableSetupGroupFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Opt_MinimumPayment", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MinimumPayment"].Value = payableSetupGroupFormUI.Opt_MinimumPayment;

                sqlCmd.Parameters.Add("@Opt_MaximumInvoiceAmt", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MaximumInvoiceAmt"].Value = payableSetupGroupFormUI.Opt_MaximumInvoiceAmt;

                sqlCmd.Parameters.Add("@Opt_CreditLimit", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_CreditLimit"].Value = payableSetupGroupFormUI.Opt_CreditLimit;

                sqlCmd.Parameters.Add("@Opt_WriteOff", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_WriteOff"].Value = payableSetupGroupFormUI.Opt_WriteOff;

                sqlCmd.Parameters.Add("@CalenderYear", SqlDbType.Bit);
                sqlCmd.Parameters["@CalenderYear"].Value = payableSetupGroupFormUI.CalenderYear;

                sqlCmd.Parameters.Add("@Transaction", SqlDbType.Bit);
                sqlCmd.Parameters["@Transaction"].Value = payableSetupGroupFormUI.Transaction;

                sqlCmd.Parameters.Add("@FiscalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@FiscalYear"].Value = payableSetupGroupFormUI.FiscalYear;

                sqlCmd.Parameters.Add("@Distribution", SqlDbType.Bit);
                sqlCmd.Parameters["@Distribution"].Value = payableSetupGroupFormUI.Distribution;



                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(payableSetupGroupFormUI);
                    audit_IUD.WebServiceUpdate(payableSetupGroupFormUI.Tbl_OrganizationId, "tbl_PayableSetupGroup", payableSetupGroupFormUI.Tbl_PayableSetupGroupId, payableSetupGroupFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePayableSetupGroup()";
            logExcpUIobj.ResourceName = "PayableSetupGroupFormDAL.CS";
            logExcpUIobj.RecordId = payableSetupGroupFormUI.Tbl_PayableSetupGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupGroupFormDAL : UpdatePayableSetupGroup] An error occured in the processing of Record Id : " + payableSetupGroupFormUI.Tbl_PayableSetupGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int DeletePayableSetupGroup(PayableSetupGroupFormUI payableSetupGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupGroup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PayableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupGroupId"].Value = payableSetupGroupFormUI.Tbl_PayableSetupGroupId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_PayableSetupGroup", payableSetupGroupFormUI.Tbl_PayableSetupGroupId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePayableSetupGroup()";
            logExcpUIobj.ResourceName = "PayableSetupGroupFormDAL.CS";
            logExcpUIobj.RecordId = payableSetupGroupFormUI.Tbl_PayableSetupGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupGroupFormDAL : DeletePayableSetupGroup] An error occured in the processing of Record Id : " + payableSetupGroupFormUI.Tbl_PayableSetupGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}