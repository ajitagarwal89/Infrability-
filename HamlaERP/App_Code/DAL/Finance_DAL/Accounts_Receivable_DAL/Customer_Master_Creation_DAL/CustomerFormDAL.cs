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
/// Summary description for CustomerFormDAL
/// </summary>
public class CustomerFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public CustomerFormDAL()
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
            logExcpUIobj.MethodName = "CustomerFormDAL()";
            logExcpUIobj.ResourceName = "CustomerFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[CustomerFormDAL : CustomerFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetCustomerListById(CustomerFormUI customerFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Customer_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerId"].Value = customerFormUI.Tbl_CustomerId;

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
                audit_IUD.WebServiceSelectInsert("tbl_Customer", customerFormUI.Tbl_CustomerId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getCustomerListById()";
            logExcpUIobj.ResourceName = "CustomerFormDAL.CS";
            logExcpUIobj.RecordId = customerFormUI.Tbl_CustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerFormDAL : getCustomerListById] An error occured in the processing of Record Id : " + customerFormUI.Tbl_CustomerId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddCustomer(CustomerFormUI customerFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Customer_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = customerFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = customerFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@CustomerCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CustomerCode"].Value = customerFormUI.CustomerCode;

                sqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Name"].Value = customerFormUI.Name;

                sqlCmd.Parameters.Add("@ShortName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ShortName"].Value = customerFormUI.ShortName;

                sqlCmd.Parameters.Add("@StatementName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@StatementName"].Value = customerFormUI.StatementName;

                sqlCmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Contact"].Value = customerFormUI.Contact;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = customerFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = customerFormUI.City;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = customerFormUI.ZipCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = customerFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Phone"].Value = customerFormUI.Phone;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = customerFormUI.Mobile;

                sqlCmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FaxNo"].Value = customerFormUI.FaxNo;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = customerFormUI.Email;

                sqlCmd.Parameters.Add("@Comment1", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment1"].Value = customerFormUI.Comment1;

                sqlCmd.Parameters.Add("@Comment2", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment2"].Value = customerFormUI.Comment2;

                sqlCmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Status"].Value = customerFormUI.Opt_Status;

                sqlCmd.Parameters.Add("@tbl_CustomerGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerGroupId"].Value = customerFormUI.Tbl_CustomerGroupId;

                sqlCmd.Parameters.Add("@OnHold", SqlDbType.Bit);
                sqlCmd.Parameters["@OnHold"].Value = customerFormUI.OnHold;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = customerFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountReceivable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountReceivable"].Value = customerFormUI.Tbl_GLAccountId_AccountReceivable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Sales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Sales"].Value = customerFormUI.Tbl_GLAccountId_Sales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_CostOfSales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_CostOfSales"].Value = customerFormUI.Tbl_GLAccountId_CostOfSales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Inventory", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Inventory"].Value = customerFormUI.Tbl_GLAccountId_Inventory;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccuralDifferedA_C", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccuralDifferedA_C"].Value = customerFormUI.Tbl_GLAccountId_AccuralDifferedA_C;

                sqlCmd.Parameters.Add("@tbl_CustomerID", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_CustomerID"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_CustomerId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_Customer";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(customerFormUI);
                    audit_IUD.WebServiceInsert(customerFormUI.Tbl_OrganizationId, tableName, RecoredID, customerFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddCustomer()";
            logExcpUIobj.ResourceName = "CustomerFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerFormDAL : AddCustomer] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateCustomer(CustomerFormUI customerFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Customer_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerId"].Value = customerFormUI.Tbl_CustomerId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = customerFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = customerFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@CustomerCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CustomerCode"].Value = customerFormUI.CustomerCode;

                sqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Name"].Value = customerFormUI.Name;

                sqlCmd.Parameters.Add("@ShortName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ShortName"].Value = customerFormUI.ShortName;

                sqlCmd.Parameters.Add("@StatementName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@StatementName"].Value = customerFormUI.StatementName;

                sqlCmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Contact"].Value = customerFormUI.Contact;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = customerFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = customerFormUI.City;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = customerFormUI.ZipCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = customerFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Phone"].Value = customerFormUI.Phone;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = customerFormUI.Mobile;

                sqlCmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FaxNo"].Value = customerFormUI.FaxNo;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = customerFormUI.Email;

                sqlCmd.Parameters.Add("@Comment1", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment1"].Value = customerFormUI.Comment1;

                sqlCmd.Parameters.Add("@Comment2", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment2"].Value = customerFormUI.Comment2;

                sqlCmd.Parameters.Add("@Status", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Status"].Value = customerFormUI.Opt_Status;

                sqlCmd.Parameters.Add("@tbl_CustomerGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerGroupId"].Value = customerFormUI.Tbl_CustomerGroupId;

                sqlCmd.Parameters.Add("@OnHold", SqlDbType.Bit);
                sqlCmd.Parameters["@OnHold"].Value = customerFormUI.OnHold;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Cash"].Value = customerFormUI.Tbl_GLAccountId_Cash;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccountReceivable", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccountReceivable"].Value = customerFormUI.Tbl_GLAccountId_AccountReceivable;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Sales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Sales"].Value = customerFormUI.Tbl_GLAccountId_Sales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_CostOfSales", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_CostOfSales"].Value = customerFormUI.Tbl_GLAccountId_CostOfSales;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_Inventory", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_Inventory"].Value = customerFormUI.Tbl_GLAccountId_Inventory;

                sqlCmd.Parameters.Add("@tbl_GLAccountId_AccuralDifferedA_C", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId_AccuralDifferedA_C"].Value = customerFormUI.Tbl_GLAccountId_AccuralDifferedA_C;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(customerFormUI);
                    audit_IUD.WebServiceUpdate(customerFormUI.Tbl_OrganizationId, "tbl_Customer", customerFormUI.Tbl_CustomerId, customerFormUI.ModifiedBy, newValue);
                }


                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateCustomer()";
            logExcpUIobj.ResourceName = "CustomerFormDAL.CS";
            logExcpUIobj.RecordId = customerFormUI.Tbl_CustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerFormDAL : UpdateCustomer] An error occured in the processing of Record Id : " + customerFormUI.Tbl_CustomerId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteCustomer(CustomerFormUI customerFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Customer_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerId"].Value = customerFormUI.Tbl_CustomerId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_Customer", customerFormUI.Tbl_CustomerId);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteCustomer()";
            logExcpUIobj.ResourceName = "CustomerFormDAL.CS";
            logExcpUIobj.RecordId = customerFormUI.Tbl_CustomerId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerFormDAL : DeleteCustomer] An error occured in the processing of Record Id : " + customerFormUI.Tbl_CustomerId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}