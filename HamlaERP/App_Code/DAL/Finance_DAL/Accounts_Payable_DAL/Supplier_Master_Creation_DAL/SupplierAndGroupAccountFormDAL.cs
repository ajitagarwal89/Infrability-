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
/// Summary description for SupplierAndGroupAccountFormDAL
/// </summary>
public class SupplierAndGroupAccountFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public SupplierAndGroupAccountFormDAL()
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
            logExcpUIobj.MethodName = "SupplierAndGroupAccountFormDAL()";
            logExcpUIobj.ResourceName = "SupplierAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[SupplierAndGroupAccountFormDAL : SupplierAndGroupAccountFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetSupplierAndGroupAccountListById(SupplierAndGroupAccountFormUI supplierAndGroupAccountFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierAndGroupAccount_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierAndGroupAccountId"].Value = supplierAndGroupAccountFormUI.Tbl_SupplierAndGroupAccountId;

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
                audit_IUD.WebServiceSelectInsert("tbl_SupplierAndGroupAccount", supplierAndGroupAccountFormUI.Tbl_SupplierAndGroupAccountId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getSupplierAndGroupAccountListById()";
            logExcpUIobj.ResourceName = "SupplierAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = supplierAndGroupAccountFormUI.Tbl_SupplierAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierAndGroupAccountFormDAL : getSupplierAndGroupAccountListById] An error occured in the processing of Record Id : " + supplierAndGroupAccountFormUI.Tbl_SupplierAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddSupplierAndGroupAccount(SupplierAndGroupAccountFormUI supplierAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierAndGroupAccount_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = supplierAndGroupAccountFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierAndGroupAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_SupplierGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierGroupId"].Value = supplierAndGroupAccountFormUI.Tbl_SupplierGroupId;

                sqlCmd.Parameters.Add("@Opt_AccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_AccountType"].Value = supplierAndGroupAccountFormUI.Opt_AccountType;

                sqlCmd.Parameters.Add("@PaymentMode", SqlDbType.Bit);
                sqlCmd.Parameters["@PaymentMode"].Value = supplierAndGroupAccountFormUI.PaymentMode;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = supplierAndGroupAccountFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountPayable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountPayable"].Value = supplierAndGroupAccountFormUI.Tbl_GLAccountId_AccountPayable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Purchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Purchase"].Value = supplierAndGroupAccountFormUI.Tbl_GLAccountId_Purchase;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_TradeDiscount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_TradeDiscount"].Value = supplierAndGroupAccountFormUI.Tbl_GLAccountId_TradeDiscount;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Freight", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Freight"].Value = supplierAndGroupAccountFormUI.Tbl_GLAccountId_Freight;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccruedPurchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccruedPurchase"].Value = supplierAndGroupAccountFormUI.Tbl_GLAccountId_AccruedPurchase;

                sqlCmd.Parameters.Add("@tbl_SupplierAndGroupAccountId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_SupplierAndGroupAccountId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_SupplierAndGroupAccountId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_SupplierAndGroupAccount";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(supplierAndGroupAccountFormUI);
                    audit_IUD.WebServiceInsert(supplierAndGroupAccountFormUI.Tbl_OrganizationId, tableName, RecoredID, supplierAndGroupAccountFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddSupplierAndGroupAccount()";
            logExcpUIobj.ResourceName = "SupplierAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierAndGroupAccountFormDAL : AddSupplierAndGroupAccount] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateSupplierAndGroupAccount(SupplierAndGroupAccountFormUI supplierAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierAndGroupAccount_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = supplierAndGroupAccountFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierAndGroupAccountFormUI.Tbl_OrganizationId;


                sqlCmd.Parameters.Add("@tbl_SupplierAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierAndGroupAccountId"].Value = supplierAndGroupAccountFormUI.Tbl_SupplierAndGroupAccountId;

                sqlCmd.Parameters.Add("@tbl_SupplierGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierGroupId"].Value = supplierAndGroupAccountFormUI.Tbl_SupplierGroupId;

                sqlCmd.Parameters.Add("@Opt_AccountType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_AccountType"].Value = supplierAndGroupAccountFormUI.Opt_AccountType;

                sqlCmd.Parameters.Add("@PaymentMode", SqlDbType.Bit);
                sqlCmd.Parameters["@PaymentMode"].Value = supplierAndGroupAccountFormUI.PaymentMode;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = supplierAndGroupAccountFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountPayable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountPayable"].Value = supplierAndGroupAccountFormUI.Tbl_GLAccountId_AccountPayable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Purchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Purchase"].Value = supplierAndGroupAccountFormUI.Tbl_GLAccountId_Purchase;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_TradeDiscount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_TradeDiscount"].Value = supplierAndGroupAccountFormUI.Tbl_GLAccountId_TradeDiscount;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Freight", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Freight"].Value = supplierAndGroupAccountFormUI.Tbl_GLAccountId_Freight;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccruedPurchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccruedPurchase"].Value = supplierAndGroupAccountFormUI.Tbl_GLAccountId_AccruedPurchase;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(supplierAndGroupAccountFormUI);
                    audit_IUD.WebServiceUpdate(supplierAndGroupAccountFormUI.Tbl_OrganizationId, "tbl_SupplierAndGroupAccount", supplierAndGroupAccountFormUI.Tbl_SupplierAndGroupAccountId, supplierAndGroupAccountFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateSupplierAndGroupAccount()";
            logExcpUIobj.ResourceName = "SupplierAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = supplierAndGroupAccountFormUI.Tbl_SupplierAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierAndGroupAccountFormDAL : UpdateSupplierAndGroupAccount] An error occured in the processing of Record Id : " + supplierAndGroupAccountFormUI.Tbl_SupplierAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteSupplierAndGroupAccount(SupplierAndGroupAccountFormUI supplierAndGroupAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierAndGroupAccount_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierAndGroupAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierAndGroupAccountId"].Value = supplierAndGroupAccountFormUI.Tbl_SupplierAndGroupAccountId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_SupplierAndGroupAccount", supplierAndGroupAccountFormUI.Tbl_SupplierAndGroupAccountId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSupplierAndGroupAccount()";
            logExcpUIobj.ResourceName = "SupplierAndGroupAccountFormDAL.CS";
            logExcpUIobj.RecordId = supplierAndGroupAccountFormUI.Tbl_SupplierAndGroupAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierAndGroupAccountFormDAL : DeleteSupplierAndGroupAccount] An error occured in the processing of Record Id : " + supplierAndGroupAccountFormUI.Tbl_SupplierAndGroupAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}