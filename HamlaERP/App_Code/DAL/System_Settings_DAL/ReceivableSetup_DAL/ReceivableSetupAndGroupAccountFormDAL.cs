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
/// Summary description for ReceivableSetupAndGroupAccountFormDAL
/// </summary>
public class ReceivableSetupAndGroupAccountFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public ReceivableSetupAndGroupAccountFormDAL()
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
            logExcpUIobj.MethodName = "ReceivableSetupAndGroupAccountFormDAL()";
            logExcpUIobj.ResourceName = "ReceivableSetupAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[ReceivableSetupAndGroupAccountFormDAL : ReceivableSetupAndGroupAccountFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetReceivableSetupAndGroupAccountListById(ReceivableSetupAndGroupAccountFormUI receivableSetupAndGroupAccountFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupAndGroupAccount_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupAndGroupAccountId"].Value = receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId;

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
                audit_IUD.WebServiceSelectInsert("tbl_ReceivableSetupAndGroupAccount", receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetReceivableSetupAndGroupAccountListById()";
            logExcpUIobj.ResourceName = "ReceivableSetupAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupAndGroupAccountFormDAL : GetReceivableSetupAndGroupAccountListById] An error occured in the processing of Record Id : " + receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddReceivableSetupAndGroupAccount(ReceivableSetupAndGroupAccountFormUI receivableSetupAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupAndGroupAccount_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = receivableSetupAndGroupAccountFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = receivableSetupAndGroupAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupId"].Value = receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupId;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupGroupId"].Value = receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupGroupId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = receivableSetupAndGroupAccountFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_ChequeBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ChequeBookId"].Value = receivableSetupAndGroupAccountFormUI.Tbl_ChequeBookId;


                sqlCmd.Parameters.Add("@CashAccountFrom", SqlDbType.Bit);
                sqlCmd.Parameters["@CashAccountFrom"].Value = receivableSetupAndGroupAccountFormUI.CashAccountFrom;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountReceivable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountReceivable"].Value = receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_AccountReceivable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Sales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Sales"].Value = receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_Sales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_CostOfSales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_CostOfSales"].Value = receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_CostOfSales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Inventory", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Inventory"].Value = receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_Inventory;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccuralDifferedA_C", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccuralDifferedA_C"].Value = receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_AccuralDifferedA_C;


                sqlCmd.Parameters.Add("@tbl_ReceivableSetupAndGroupAccountId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_ReceivableSetupAndGroupAccountId"].Direction = ParameterDirection.Output;

                

                result = sqlCmd.ExecuteNonQuery();
                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_ReceivableSetupAndGroupAccountId"].Value);
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    sqlCmd.Dispose();
                    SupportCon.Close();
                    string tableName = "tbl_ReceivableSetupAndGroupAccount";
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(receivableSetupAndGroupAccountFormUI);
                    audit_IUD.WebServiceInsert(receivableSetupAndGroupAccountFormUI.Tbl_OrganizationId, tableName, RecoredID, receivableSetupAndGroupAccountFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddReceivableSetupAndGroupAccount()";
            logExcpUIobj.ResourceName = "ReceivableSetupAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupAndGroupAccountFormDAL : AddReceivableSetupAndGroupAccount] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateReceivableSetupAndGroupAccount(ReceivableSetupAndGroupAccountFormUI receivableSetupAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupAndGroupAccount_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = receivableSetupAndGroupAccountFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupAndGroupAccountId"].Value = receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupId"].Value = receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = receivableSetupAndGroupAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupGroupId"].Value = receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupGroupId;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = receivableSetupAndGroupAccountFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_ChequeBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ChequeBookId"].Value = receivableSetupAndGroupAccountFormUI.Tbl_ChequeBookId;


                sqlCmd.Parameters.Add("@CashAccountFrom", SqlDbType.Bit);
                sqlCmd.Parameters["@CashAccountFrom"].Value = receivableSetupAndGroupAccountFormUI.CashAccountFrom;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountReceivable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountReceivable"].Value = receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_AccountReceivable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Sales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Sales"].Value = receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_Sales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_CostOfSales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_CostOfSales"].Value = receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_CostOfSales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Inventory", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Inventory"].Value = receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_Inventory;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccuralDifferedA_C", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccuralDifferedA_C"].Value = receivableSetupAndGroupAccountFormUI.Tbl_GLAccountId_AccuralDifferedA_C;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(receivableSetupAndGroupAccountFormUI);
                    audit_IUD.WebServiceUpdate(receivableSetupAndGroupAccountFormUI.Tbl_OrganizationId, "tbl_ReceivableSetupAndGroupAccount", receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId, receivableSetupAndGroupAccountFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateReceivableSetupAndGroupAccount()";
            logExcpUIobj.ResourceName = "ReceivableSetupAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupAndGroupAccountFormDAL : UpdateReceivableSetupAndGroupAccount] An error occured in the processing of Record Id : " + receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteReceivableSetupAndGroupAccount(ReceivableSetupAndGroupAccountFormUI receivableSetupAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupAndGroupAccount_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupAndGroupAccountId"].Value = receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_ReceivableSetupAndGroupAccount", receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteReceivableSetupAndGroupAccount()";
            logExcpUIobj.ResourceName = "ReceivableSetupAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupAndGroupAccountFormDAL : DeleteReceivableSetupAndGroupAccount] An error occured in the processing of Record Id : " + receivableSetupAndGroupAccountFormUI.Tbl_ReceivableSetupAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}