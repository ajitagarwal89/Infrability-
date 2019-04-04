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
/// Summary description for SupplierEmployeeAndGroupAccountFormDAL
/// </summary>
public class SupplierEmployeeAndGroupAccountFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    Audit_IUD audit_IUD = new Audit_IUD();

    public SupplierEmployeeAndGroupAccountFormDAL()
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
            logExcpUIobj.MethodName = "SupplierEmployeeAndGroupAccountFormDAL()";
            logExcpUIobj.ResourceName = "SupplierEmployeeAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[SupplierEmployeeAndGroupAccountFormDAL : SupplierEmployeeAndGroupAccountFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetSupplierEmployeeAndGroupAccountListById(SupplierEmployeeAndGroupAccountFormUI supplierEmployeeAndGroupAccountFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeAndGroupAccount_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeAndGroupAccountId"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId;

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
                audit_IUD.WebServiceSelectInsert("tbl_SupplierEmployeeAndGroupAccount", supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSupplierEmployeeAndGroupAccountListById()";
            logExcpUIobj.ResourceName = "SupplierEmployeeAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeAndGroupAccountFormDAL : GetSupplierEmployeeAndGroupAccountListById] An error occured in the processing of Record Id : " + supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddSupplierEmployeeAndGroupAccount(SupplierEmployeeAndGroupAccountFormUI supplierEmployeeAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeAndGroupAccount_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = supplierEmployeeAndGroupAccountFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGroupId"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeGroupId;

                sqlCmd.Parameters.Add("@AccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@AccountType"].Value = supplierEmployeeAndGroupAccountFormUI.Opt_AccountType;

                sqlCmd.Parameters.Add("@PaymentMode", SqlDbType.Bit);
                sqlCmd.Parameters["@PaymentMode"].Value = supplierEmployeeAndGroupAccountFormUI.PaymentMode;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountPayable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountPayable"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_AccountPayable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Purchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Purchase"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_Purchase;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_TradeDiscount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_TradeDiscount"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_TradeDiscount;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Freight", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Freight"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_Freight;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccruedPurchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccruedPurchase"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_AccruedPurchase;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeAndGroupAccountId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_SupplierEmployeeAndGroupAccountId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recoredID = Convert.ToString(sqlCmd.Parameters["@tbl_SupplierEmployeeAndGroupAccountId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_SupplierEmployeeAndGroupAccount";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(supplierEmployeeAndGroupAccountFormUI);
                    audit_IUD.WebServiceInsert(supplierEmployeeAndGroupAccountFormUI.Tbl_OrganizationId, tableName, recoredID, supplierEmployeeAndGroupAccountFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddSupplierEmployeeAndGroupAccount()";
            logExcpUIobj.ResourceName = "SupplierEmployeeAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeAndGroupAccountFormDAL : AddSupplierEmployeeAndGroupAccount] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateSupplierEmployeeAndGroupAccount(SupplierEmployeeAndGroupAccountFormUI supplierEmployeeAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeAndGroupAccount_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = supplierEmployeeAndGroupAccountFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_OrganizationId;


                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeAndGroupAccountId"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId;


                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGroupId"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeGroupId;

                sqlCmd.Parameters.Add("@AccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@AccountType"].Value = supplierEmployeeAndGroupAccountFormUI.Opt_AccountType;

                sqlCmd.Parameters.Add("@PaymentMode", SqlDbType.Bit);
                sqlCmd.Parameters["@PaymentMode"].Value = supplierEmployeeAndGroupAccountFormUI.PaymentMode;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountPayable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountPayable"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_AccountPayable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Purchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Purchase"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_Purchase;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_TradeDiscount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_TradeDiscount"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_TradeDiscount;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Freight", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Freight"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_Freight;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccruedPurchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccruedPurchase"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_GLAccountId_AccruedPurchase;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(supplierEmployeeAndGroupAccountFormUI);
                    audit_IUD.WebServiceUpdate(supplierEmployeeAndGroupAccountFormUI.Tbl_OrganizationId, "tbl_SupplierEmployeeAndGroupAccount", supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId, supplierEmployeeAndGroupAccountFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateSupplierEmployeeAndGroupAccount()";
            logExcpUIobj.ResourceName = "SupplierEmployeeAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeAndGroupAccountFormDAL : UpdateSupplierEmployeeAndGroupAccount] An error occured in the processing of Record Id : " + supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteSupplierEmployeeAndGroupAccount(SupplierEmployeeAndGroupAccountFormUI supplierEmployeeAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployeeAndGroupAccount_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeAndGroupAccountId"].Value = supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_SupplierEmployeeAndGroupAccount", supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSupplierEmployeeAndGroupAccount()";
            logExcpUIobj.ResourceName = "SupplierEmployeeAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeAndGroupAccountFormDAL : DeleteSupplierEmployeeAndGroupAccount] An error occured in the processing of Record Id : " + supplierEmployeeAndGroupAccountFormUI.Tbl_SupplierEmployeeAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}