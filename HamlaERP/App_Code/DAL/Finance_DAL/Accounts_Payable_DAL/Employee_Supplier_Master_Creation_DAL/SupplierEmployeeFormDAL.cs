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
/// Summary description for SupplierEmployeeFormDAL
/// </summary>
public class SupplierEmployeeFormDAL: IRequiresSessionState
{

    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public SupplierEmployeeFormDAL()
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
            logExcpUIobj.MethodName = "SupplierEmployeeFormDAL()";
            logExcpUIobj.ResourceName = "SupplierEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[SupplierEmployeeFormDAL : SupplierEmployeeFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetSupplierEmployeeListById(SupplierEmployeeFormUI supplierEmployeeFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployee_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeId"].Value = supplierEmployeeFormUI.Tbl_SupplierEmployeeId;

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
                audit_IUD.WebServiceSelectInsert("tbl_SupplierEmployee", supplierEmployeeFormUI.Tbl_SupplierEmployeeId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getSupplierEmployeeListById()";
            logExcpUIobj.ResourceName = "SupplierEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeFormUI.Tbl_SupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeFormDAL : getSupplierEmployeeListById] An error occured in the processing of Record Id : " + supplierEmployeeFormUI.Tbl_SupplierEmployeeId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddSupplierEmployee(SupplierEmployeeFormUI supplierEmployeeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployee_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = supplierEmployeeFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierEmployeeFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@SupplierEmployeeCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SupplierEmployeeCode"].Value = supplierEmployeeFormUI.SupplierEmployeeCode;

                sqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Name"].Value = supplierEmployeeFormUI.Name;

                sqlCmd.Parameters.Add("@ShortName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ShortName"].Value = supplierEmployeeFormUI.ShortName;

                sqlCmd.Parameters.Add("@ChequeName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ChequeName"].Value = supplierEmployeeFormUI.ChequeName;

                sqlCmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Contact"].Value = supplierEmployeeFormUI.Contact;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = supplierEmployeeFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = supplierEmployeeFormUI.City;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = supplierEmployeeFormUI.ZipCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = supplierEmployeeFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Phone"].Value = supplierEmployeeFormUI.Phone;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = supplierEmployeeFormUI.Mobile;

                sqlCmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FaxNo"].Value = supplierEmployeeFormUI.FaxNo;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = supplierEmployeeFormUI.Email;

                sqlCmd.Parameters.Add("@Comment1", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment1"].Value = supplierEmployeeFormUI.Comment1;

                sqlCmd.Parameters.Add("@Comment2", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment2"].Value = supplierEmployeeFormUI.Comment2;

                sqlCmd.Parameters.Add("@Opt_Status", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Status"].Value = supplierEmployeeFormUI.Opt_Status;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGroupId"].Value = supplierEmployeeFormUI.Tbl_SupplierEmployeeGroupId;

                sqlCmd.Parameters.Add("@OnHold", SqlDbType.Bit);
                sqlCmd.Parameters["@OnHold"].Value = supplierEmployeeFormUI.OnHold;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = supplierEmployeeFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountPayable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountPayable"].Value = supplierEmployeeFormUI.Tbl_GLAccountId_AccountPayable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Purchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Purchase"].Value = supplierEmployeeFormUI.Tbl_GLAccountId_Purchase;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_TradeDiscount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_TradeDiscount"].Value = supplierEmployeeFormUI.Tbl_GLAccountId_TradeDiscount;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Freight", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Freight"].Value = supplierEmployeeFormUI.Tbl_GLAccountId_Freight;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccruedPurchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccruedPurchase"].Value = supplierEmployeeFormUI.Tbl_GLAccountId_AccruedPurchase;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_SupplierEmployeeId"].Direction = ParameterDirection.Output;


                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_SupplierEmployeeId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_SupplierEmployee";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(supplierEmployeeFormUI);
                    audit_IUD.WebServiceInsert(supplierEmployeeFormUI.Tbl_OrganizationId, tableName, recordID, supplierEmployeeFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddSupplierEmployee()";
            logExcpUIobj.ResourceName = "SupplierEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeFormDAL : AddSupplierEmployee] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateSupplierEmployee(SupplierEmployeeFormUI supplierEmployeeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployee_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = supplierEmployeeFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierEmployeeFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeId"].Value = supplierEmployeeFormUI.Tbl_SupplierEmployeeId;

                sqlCmd.Parameters.Add("@SupplierEmployeeCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SupplierEmployeeCode"].Value = supplierEmployeeFormUI.SupplierEmployeeCode;

                sqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Name"].Value = supplierEmployeeFormUI.Name;

                sqlCmd.Parameters.Add("@ShortName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ShortName"].Value = supplierEmployeeFormUI.ShortName;

                sqlCmd.Parameters.Add("@ChequeName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ChequeName"].Value = supplierEmployeeFormUI.ChequeName;

                sqlCmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Contact"].Value = supplierEmployeeFormUI.Contact;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = supplierEmployeeFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = supplierEmployeeFormUI.City;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = supplierEmployeeFormUI.ZipCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = supplierEmployeeFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Phone"].Value = supplierEmployeeFormUI.Phone;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = supplierEmployeeFormUI.Mobile;

                sqlCmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FaxNo"].Value = supplierEmployeeFormUI.FaxNo;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = supplierEmployeeFormUI.Email;

                sqlCmd.Parameters.Add("@Comment1", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment1"].Value = supplierEmployeeFormUI.Comment1;

                sqlCmd.Parameters.Add("@Comment2", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment2"].Value = supplierEmployeeFormUI.Comment2;

                sqlCmd.Parameters.Add("@Opt_Status", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Status"].Value = supplierEmployeeFormUI.Opt_Status;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeGroupId"].Value = supplierEmployeeFormUI.Tbl_SupplierEmployeeGroupId;

                sqlCmd.Parameters.Add("@OnHold", SqlDbType.Bit);
                sqlCmd.Parameters["@OnHold"].Value = supplierEmployeeFormUI.OnHold;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = supplierEmployeeFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountPayable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountPayable"].Value = supplierEmployeeFormUI.Tbl_GLAccountId_AccountPayable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Purchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Purchase"].Value = supplierEmployeeFormUI.Tbl_GLAccountId_Purchase;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_TradeDiscount", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_TradeDiscount"].Value = supplierEmployeeFormUI.Tbl_GLAccountId_TradeDiscount;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Freight", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Freight"].Value = supplierEmployeeFormUI.Tbl_GLAccountId_Freight;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccruedPurchase", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccruedPurchase"].Value = supplierEmployeeFormUI.Tbl_GLAccountId_AccruedPurchase;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(supplierEmployeeFormUI);
                    audit_IUD.WebServiceUpdate(supplierEmployeeFormUI.Tbl_OrganizationId, "tbl_SupplierEmployee", supplierEmployeeFormUI.Tbl_SupplierEmployeeId, supplierEmployeeFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateSupplierEmployee()";
            logExcpUIobj.ResourceName = "SupplierEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeFormUI.Tbl_SupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeFormDAL : UpdateSupplierEmployee] An error occured in the processing of Record Id : " + supplierEmployeeFormUI.Tbl_SupplierEmployeeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteSupplierEmployee(SupplierEmployeeFormUI supplierEmployeeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployee_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierEmployeeId"].Value = supplierEmployeeFormUI.Tbl_SupplierEmployeeId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_SupplierEmployee", supplierEmployeeFormUI.Tbl_SupplierEmployeeId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSupplierEmployee()";
            logExcpUIobj.ResourceName = "SupplierEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = supplierEmployeeFormUI.Tbl_SupplierEmployeeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeFormDAL : DeleteSupplierEmployee] An error occured in the processing of Record Id : " + supplierEmployeeFormUI.Tbl_SupplierEmployeeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetSerialNumber()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();

        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_SupplierEmployee_SerialNumber", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

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
            logExcpUIobj.MethodName = "GetSerialNumber()";
            logExcpUIobj.ResourceName = "SupplierEmployeeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierEmployeeFormDAL : GetSerialNumber] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

}