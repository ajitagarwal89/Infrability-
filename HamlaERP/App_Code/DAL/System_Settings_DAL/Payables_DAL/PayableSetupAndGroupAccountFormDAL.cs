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
/// Summary description for PayableSetupGroupAccountFormDAL
/// </summary>
public class PayableSetupAndGroupAccountFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PayableSetupAndGroupAccountFormDAL()
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
            logExcpUIobj.MethodName = "PayableSetupAndGroupAccountFormDAL()";
            logExcpUIobj.ResourceName = "PayableSetupAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PayableSetupAndGroupAccountFormDAL : PayableSetupAndGroupAccountFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPayableSetupAndGroupAccountListById(PayableSetupAndGroupAccountFormUI payableSetupAndGroupAccountFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupAndGroupAccount_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PayableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupAndGroupAccountId"].Value = payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId;

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
                audit_IUD.WebServiceSelectInsert("tbl_PayableSetupAndGroupAccount", payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPayableSetupAndGroupAccountListById()";
            logExcpUIobj.ResourceName = "PayableSetupAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupAndGroupAccountFormDAL : GetPayableSetupAndGroupAccountListById] An error occured in the processing of Record Id : " + payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public int AddPayableSetupAndGroupAccount(PayableSetupAndGroupAccountFormUI payableSetupAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupAndGroupAccount_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = payableSetupAndGroupAccountFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = payableSetupAndGroupAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PayableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupId"].Value = payableSetupAndGroupAccountFormUI.tbl_PayableSetup;

                sqlCmd.Parameters.Add("@tbl_PayableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupGroupId"].Value = payableSetupAndGroupAccountFormUI.tbl_PayableSetupGroupId;

                sqlCmd.Parameters.Add("@tbl_ChequeBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ChequeBookId"].Value = payableSetupAndGroupAccountFormUI.tbl_ChequeBookId;

                sqlCmd.Parameters.Add("@AccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@AccountType"].Value = payableSetupAndGroupAccountFormUI.Opt_AccountType;

                sqlCmd.Parameters.Add("@PaymentMode", SqlDbType.Bit);
                sqlCmd.Parameters["@PaymentMode"].Value = payableSetupAndGroupAccountFormUI.PaymentMode;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = payableSetupAndGroupAccountFormUI.tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountReceivable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountReceivable"].Value = payableSetupAndGroupAccountFormUI.tbl_GLAccountId_AccountReceivable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Sales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Sales"].Value = payableSetupAndGroupAccountFormUI.tbl_GLAccountId_Sales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_CostOfSales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_CostOfSales"].Value = payableSetupAndGroupAccountFormUI.tbl_GLAccountId_CostOfSales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Inventory", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Inventory"].Value = payableSetupAndGroupAccountFormUI.tbl_GLAccountId_Inventory;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccuralDifferedA_C", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccuralDifferedA_C"].Value = payableSetupAndGroupAccountFormUI.tbl_GLAccountId_AccuralDifferedA_C;



                sqlCmd.Parameters.Add("@tbl_PayableSetupAndGroupAccountId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_PayableSetupAndGroupAccountId"].Direction = ParameterDirection.Output;
               

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_PayableSetupAndGroupAccountId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_PayableSetupGroupAccount";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(payableSetupAndGroupAccountFormUI);
                    audit_IUD.WebServiceInsert(payableSetupAndGroupAccountFormUI.Tbl_OrganizationId, tableName, RecoredID, payableSetupAndGroupAccountFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddPayableSetupAndGroupAccount()";
            logExcpUIobj.ResourceName = "PayableSetupAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupAndGroupAccountFormDAL : AddPayableSetupAndGroupAccount] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int UpdatePayableSetupAndGroupAccount(PayableSetupAndGroupAccountFormUI payableSetupAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupAndGroupAccount_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = payableSetupAndGroupAccountFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = payableSetupAndGroupAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PayableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupAndGroupAccountId"].Value = payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId;

                sqlCmd.Parameters.Add("@tbl_PayableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupId"].Value = payableSetupAndGroupAccountFormUI.tbl_PayableSetup;

                sqlCmd.Parameters.Add("@tbl_PayableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupGroupId"].Value = payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId;

                sqlCmd.Parameters.Add("@tbl_ChequeBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ChequeBookId"].Value = payableSetupAndGroupAccountFormUI.tbl_ChequeBookId;

                sqlCmd.Parameters.Add("@AccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@AccountType"].Value = payableSetupAndGroupAccountFormUI.Opt_AccountType;

                sqlCmd.Parameters.Add("@PaymentMode", SqlDbType.Bit);
                sqlCmd.Parameters["@PaymentMode"].Value = payableSetupAndGroupAccountFormUI.PaymentMode;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = payableSetupAndGroupAccountFormUI.tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountReceivable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountReceivable"].Value = payableSetupAndGroupAccountFormUI.tbl_GLAccountId_AccountReceivable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Sales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Sales"].Value = payableSetupAndGroupAccountFormUI.tbl_GLAccountId_Sales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_CostOfSales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_CostOfSales"].Value = payableSetupAndGroupAccountFormUI.tbl_GLAccountId_CostOfSales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Inventory", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Inventory"].Value = payableSetupAndGroupAccountFormUI.tbl_GLAccountId_Inventory;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccuralDifferedA_C", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccuralDifferedA_C"].Value = payableSetupAndGroupAccountFormUI.tbl_GLAccountId_AccuralDifferedA_C;



                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(payableSetupAndGroupAccountFormUI);
                    audit_IUD.WebServiceUpdate(payableSetupAndGroupAccountFormUI.Tbl_OrganizationId, "tbl_PayableSetupAndGroupAccount", payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId, payableSetupAndGroupAccountFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePayableSetupAndGroupAccount()";
            logExcpUIobj.ResourceName = "PayableSetupAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupAndGroupAccountFormDAL : UpdatePayableSetupAndGroupAccount] An error occured in the processing of Record Id : " + payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int DeletePayableSetupAndGroupAccount(PayableSetupAndGroupAccountFormUI payableSetupAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupAndGroupAccount_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PayableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupAndGroupAccountId"].Value = payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_PayableSetupAndGroupAccount", payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePayableSetupAndGroupAccount()";
            logExcpUIobj.ResourceName = "PayableSetupGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupGroupAccountFormDAL : DeletePayableSetupAndGroupAccount] An error occured in the processing of Record Id : " + payableSetupAndGroupAccountFormUI.tbl_PayableSetupAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}