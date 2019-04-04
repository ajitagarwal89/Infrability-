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
/// Summary description for CustomerGroupFormDAL
/// </summary>
public class CustomerGroupFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public CustomerGroupFormDAL()
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
            logExcpUIobj.MethodName = "CustomerGroupFormDAL()";
            logExcpUIobj.ResourceName = "CustomerGroupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[CustomerGroupFormDAL : CustomerGroupFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetCustomerGroupListById(CustomerGroupFormUI customerGroupFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerGroup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CustomerGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerGroupId"].Value = customerGroupFormUI.Tbl_CustomerGroupId;

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
                audit_IUD.WebServiceSelectInsert("tbl_CustomerGroup", customerGroupFormUI.Tbl_CustomerGroupId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getCustomerGroupListById()";
            logExcpUIobj.ResourceName = "CustomerGroupFormDAL.CS";
            logExcpUIobj.RecordId = customerGroupFormUI.Tbl_CustomerGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerGroupFormDAL : getCustomerGroupListById] An error occured in the processing of Record Id : " + customerGroupFormUI.Tbl_CustomerGroupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddCustomerGroup(CustomerGroupFormUI customerGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerGroup_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = customerGroupFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = customerGroupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_CustomerGroupId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerGroupId_Self"].Value = customerGroupFormUI.Tbl_CustomerGroupId_Self;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = customerGroupFormUI.Description;

                sqlCmd.Parameters.Add("@IsDefault", SqlDbType.Bit);
                sqlCmd.Parameters["@IsDefault"].Value = customerGroupFormUI.IsDefault;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = customerGroupFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@Opt_BalanceType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_BalanceType"].Value = customerGroupFormUI.Opt_BalanceType;

                sqlCmd.Parameters.Add("@Opt_MinimumPayment", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MinimumPayment"].Value = customerGroupFormUI.Opt_MinimumPayment;

                sqlCmd.Parameters.Add("@MinimumPaymentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@MinimumPaymentAmount"].Value = customerGroupFormUI.MinimumPaymentAmount;

                sqlCmd.Parameters.Add("@Opt_CreditLimit", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_CreditLimit"].Value = customerGroupFormUI.Opt_CreditLimit;

                sqlCmd.Parameters.Add("@CreditLimitAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditLimitAmount"].Value = customerGroupFormUI.CreditLimitAmount;

                sqlCmd.Parameters.Add("@Opt_Writeoff", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Writeoff"].Value = customerGroupFormUI.Opt_Writeoff;

                sqlCmd.Parameters.Add("@WriteoffAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@WriteoffAmount"].Value = customerGroupFormUI.WriteoffAmount;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = customerGroupFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = customerGroupFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@CalendarYear", SqlDbType.Bit);
                sqlCmd.Parameters["@CalendarYear"].Value = customerGroupFormUI.CalendarYear;

                sqlCmd.Parameters.Add("@FiscalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@FiscalYear"].Value = customerGroupFormUI.FiscalYear;

                sqlCmd.Parameters.Add("@Transaction", SqlDbType.Bit);
                sqlCmd.Parameters["@Transaction"].Value = customerGroupFormUI.Transaction;

                sqlCmd.Parameters.Add("@Distribution", SqlDbType.Bit);
                sqlCmd.Parameters["@Distribution"].Value = customerGroupFormUI.Distribution;

                sqlCmd.Parameters.Add("@Opt_StatementCycle", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_StatementCycle"].Value = customerGroupFormUI.Opt_StatementCycle;

                sqlCmd.Parameters.Add("@tbl_CustomerGroupID", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_CustomerGroupID"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_CustomerGroupId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_CustomerGroup";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(customerGroupFormUI);
                    audit_IUD.WebServiceInsert(customerGroupFormUI.Tbl_OrganizationId, tableName, RecoredID, customerGroupFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddCustomerGroup()";
            logExcpUIobj.ResourceName = "CustomerGroupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerGroupFormDAL : AddCustomerGroup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateCustomerGroup(CustomerGroupFormUI customerGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerGroup_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = customerGroupFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = customerGroupFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_CustomerGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerGroupId"].Value = customerGroupFormUI.Tbl_CustomerGroupId;


                sqlCmd.Parameters.Add("@tbl_CustomerGroupId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerGroupId_Self"].Value = customerGroupFormUI.Tbl_CustomerGroupId_Self;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = customerGroupFormUI.Description;

                sqlCmd.Parameters.Add("@IsDefault", SqlDbType.Bit);
                sqlCmd.Parameters["@IsDefault"].Value = customerGroupFormUI.IsDefault;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = customerGroupFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@Opt_BalanceType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_BalanceType"].Value = customerGroupFormUI.Opt_BalanceType;

                sqlCmd.Parameters.Add("@Opt_MinimumPayment", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_MinimumPayment"].Value = customerGroupFormUI.Opt_MinimumPayment;

                sqlCmd.Parameters.Add("@MinimumPaymentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@MinimumPaymentAmount"].Value = customerGroupFormUI.MinimumPaymentAmount;

                sqlCmd.Parameters.Add("@Opt_CreditLimit", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_CreditLimit"].Value = customerGroupFormUI.Opt_CreditLimit;

                sqlCmd.Parameters.Add("@CreditLimitAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditLimitAmount"].Value = customerGroupFormUI.CreditLimitAmount;

                sqlCmd.Parameters.Add("@Opt_Writeoff", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Writeoff"].Value = customerGroupFormUI.Opt_Writeoff;

                sqlCmd.Parameters.Add("@WriteoffAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@WriteoffAmount"].Value = customerGroupFormUI.WriteoffAmount;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = customerGroupFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = customerGroupFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@CalendarYear", SqlDbType.Bit);
                sqlCmd.Parameters["@CalendarYear"].Value = customerGroupFormUI.CalendarYear;

                sqlCmd.Parameters.Add("@FiscalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@FiscalYear"].Value = customerGroupFormUI.FiscalYear;

                sqlCmd.Parameters.Add("@Transaction", SqlDbType.Bit);
                sqlCmd.Parameters["@Transaction"].Value = customerGroupFormUI.Transaction;

                sqlCmd.Parameters.Add("@Distribution", SqlDbType.Bit);
                sqlCmd.Parameters["@Distribution"].Value = customerGroupFormUI.Distribution;

                sqlCmd.Parameters.Add("@Opt_StatementCycle", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_StatementCycle"].Value = customerGroupFormUI.Opt_StatementCycle;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(customerGroupFormUI);
                    audit_IUD.WebServiceUpdate(customerGroupFormUI.Tbl_OrganizationId, "tbl_CustomerGroup", customerGroupFormUI.Tbl_CustomerGroupId, customerGroupFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateCustomerGroup()";
            logExcpUIobj.ResourceName = "CustomerGroupFormDAL.CS";
            logExcpUIobj.RecordId = customerGroupFormUI.Tbl_CustomerGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerGroupFormDAL : UpdateCustomerGroup] An error occured in the processing of Record Id : " + customerGroupFormUI.Tbl_CustomerGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteCustomerGroup(CustomerGroupFormUI customerGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerGroup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CustomerGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerGroupId"].Value = customerGroupFormUI.Tbl_CustomerGroupId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_CustomerGroup", customerGroupFormUI.Tbl_CustomerGroupId);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteCustomerGroup()";
            logExcpUIobj.ResourceName = "CustomerGroupFormDAL.CS";
            logExcpUIobj.RecordId = customerGroupFormUI.Tbl_CustomerGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerGroupFormDAL : DeleteCustomerGroup] An error occured in the processing of Record Id : " + customerGroupFormUI.Tbl_CustomerGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}