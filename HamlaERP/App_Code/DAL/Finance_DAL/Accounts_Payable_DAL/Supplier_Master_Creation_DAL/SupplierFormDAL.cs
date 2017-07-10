using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for SupplierFormDAL
/// </summary>
public class SupplierFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public SupplierFormDAL()
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
            logExcpUIobj.MethodName = "SupplierFormDAL()";
            logExcpUIobj.ResourceName = "SupplierFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[SupplierFormDAL : SupplierFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetSupplierListById(SupplierFormUI supplierFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Supplier_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = supplierFormUI.Tbl_SupplierId;

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
            logExcpUIobj.MethodName = "getSupplierListById()";
            logExcpUIobj.ResourceName = "SupplierFormDAL.CS";
            logExcpUIobj.RecordId = supplierFormUI.Tbl_SupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierFormDAL : getSupplierListById] An error occured in the processing of Record Id : " + supplierFormUI.Tbl_SupplierId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddSupplier(SupplierFormUI supplierFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Supplier_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = supplierFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@SupplierCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SupplierCode"].Value = supplierFormUI.SupplierCode;

                sqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Name"].Value = supplierFormUI.Name;

                sqlCmd.Parameters.Add("@ShortName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ShortName"].Value = supplierFormUI.ShortName;

                sqlCmd.Parameters.Add("@ChequeName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ChequeName"].Value = supplierFormUI.ChequeName;

                sqlCmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Contact"].Value = supplierFormUI.Contact;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = supplierFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = supplierFormUI.City;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = supplierFormUI.ZipCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = supplierFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Phone"].Value = supplierFormUI.Phone;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = supplierFormUI.Mobile;

                sqlCmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FaxNo"].Value = supplierFormUI.FaxNo;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = supplierFormUI.Email;

                sqlCmd.Parameters.Add("@Comment1", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment1"].Value = supplierFormUI.Comment1;

                sqlCmd.Parameters.Add("@Comment2", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment2"].Value = supplierFormUI.Comment2;

                sqlCmd.Parameters.Add("@Opt_Status", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Status"].Value = supplierFormUI.Opt_Status;

                sqlCmd.Parameters.Add("@tbl_SupplierGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierGroupId"].Value = supplierFormUI.Tbl_SupplierGroupId;

                sqlCmd.Parameters.Add("@OnHold", SqlDbType.Bit);
                sqlCmd.Parameters["@OnHold"].Value = supplierFormUI.OnHold;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddSupplier()";
            logExcpUIobj.ResourceName = "SupplierFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierFormDAL : AddSupplier] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateSupplier(SupplierFormUI supplierFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Supplier_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = supplierFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = supplierFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = supplierFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@SupplierCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SupplierCode"].Value = supplierFormUI.SupplierCode;

                sqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Name"].Value = supplierFormUI.Name;

                sqlCmd.Parameters.Add("@ShortName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ShortName"].Value = supplierFormUI.ShortName;

                sqlCmd.Parameters.Add("@ChequeName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ChequeName"].Value = supplierFormUI.ChequeName;

                sqlCmd.Parameters.Add("@Contact", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Contact"].Value = supplierFormUI.Contact;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = supplierFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = supplierFormUI.City;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = supplierFormUI.ZipCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = supplierFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Phone"].Value = supplierFormUI.Phone;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = supplierFormUI.Mobile;

                sqlCmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FaxNo"].Value = supplierFormUI.FaxNo;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = supplierFormUI.Email;

                sqlCmd.Parameters.Add("@Comment1", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment1"].Value = supplierFormUI.Comment1;

                sqlCmd.Parameters.Add("@Comment2", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comment2"].Value = supplierFormUI.Comment2;

                sqlCmd.Parameters.Add("@Opt_Status", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Status"].Value = supplierFormUI.Opt_Status;

                sqlCmd.Parameters.Add("@tbl_SupplierGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierGroupId"].Value = supplierFormUI.Tbl_SupplierGroupId;

                sqlCmd.Parameters.Add("@OnHold", SqlDbType.Bit);
                sqlCmd.Parameters["@OnHold"].Value = supplierFormUI.OnHold;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateSupplier()";
            logExcpUIobj.ResourceName = "SupplierFormDAL.CS";
            logExcpUIobj.RecordId = supplierFormUI.Tbl_SupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierFormDAL : UpdateSupplier] An error occured in the processing of Record Id : " + supplierFormUI.Tbl_SupplierId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteSupplier(SupplierFormUI supplierFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Supplier_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = supplierFormUI.Tbl_SupplierId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSupplier()";
            logExcpUIobj.ResourceName = "SupplierFormDAL.CS";
            logExcpUIobj.RecordId = supplierFormUI.Tbl_SupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[SupplierFormDAL : DeleteSupplier] An error occured in the processing of Record Id : " + supplierFormUI.Tbl_SupplierId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}