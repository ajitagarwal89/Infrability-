using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for BankFormDAL
/// </summary>
public class BankFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public BankFormDAL()
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
            logExcpUIobj.MethodName = "BankFormDAL()";
            logExcpUIobj.ResourceName = "BankFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[BankFormDAL : BankFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetBankListById(BankFormUI bankFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Bank_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_BankId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BankId"].Value = bankFormUI.Tbl_BankId;

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
            logExcpUIobj.MethodName = "getBankListById()";
            logExcpUIobj.ResourceName = "BankFormDAL.CS";
            logExcpUIobj.RecordId = bankFormUI.Tbl_BankId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BankFormDAL : getBankListById] An error occured in the processing of Record Id : " + bankFormUI.Tbl_BankId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddBank(BankFormUI bankFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Bank_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = bankFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = bankFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@BankCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BankCode"].Value = bankFormUI.BankCode;

                sqlCmd.Parameters.Add("@BankName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BankName"].Value = bankFormUI.BankName;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = bankFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = bankFormUI.City;

                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = bankFormUI.State;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = bankFormUI.ZipCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = bankFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Phone"].Value = bankFormUI.Phone;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = bankFormUI.Mobile;

                sqlCmd.Parameters.Add("@Fax", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Fax"].Value = bankFormUI.Fax;

                sqlCmd.Parameters.Add("@Branch", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Branch"].Value = bankFormUI.Branch;

                sqlCmd.Parameters.Add("@IBAN", SqlDbType.NVarChar);
                sqlCmd.Parameters["@IBAN"].Value = bankFormUI.IBAN;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddBank()";
            logExcpUIobj.ResourceName = "BankFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BankFormDAL : AddBank] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateBank(BankFormUI bankFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Bank_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = bankFormUI.ModifiedBy;


                sqlCmd.Parameters.Add("@tbl_BankId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BankId"].Value = bankFormUI.Tbl_BankId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = bankFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@BankCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BankCode"].Value = bankFormUI.BankCode;

                sqlCmd.Parameters.Add("@BankName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@BankName"].Value = bankFormUI.BankName;

                sqlCmd.Parameters.Add("@Address", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Address"].Value = bankFormUI.Address;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = bankFormUI.City;

                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = bankFormUI.State;

                sqlCmd.Parameters.Add("@ZipCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ZipCode"].Value = bankFormUI.ZipCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = bankFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@Phone", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Phone"].Value = bankFormUI.Phone;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = bankFormUI.Mobile;

                sqlCmd.Parameters.Add("@Fax", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Fax"].Value = bankFormUI.Fax;

                sqlCmd.Parameters.Add("@Branch", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Branch"].Value = bankFormUI.Branch;

                sqlCmd.Parameters.Add("@IBAN", SqlDbType.NVarChar);
                sqlCmd.Parameters["@IBAN"].Value = bankFormUI.IBAN;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateBank()";
            logExcpUIobj.ResourceName = "BankFormDAL.CS";
            logExcpUIobj.RecordId = bankFormUI.Tbl_BankId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BankFormDAL : UpdateBank] An error occured in the processing of Record Id : " + bankFormUI.Tbl_BankId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteBank(BankFormUI bankFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Bank_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_BankId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BankId"].Value = bankFormUI.Tbl_BankId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteBank()";
            logExcpUIobj.ResourceName = "BankFormDAL.CS";
            logExcpUIobj.RecordId = bankFormUI.Tbl_BankId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[BankFormDAL : DeleteBank] An error occured in the processing of Record Id : " + bankFormUI.Tbl_BankId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}