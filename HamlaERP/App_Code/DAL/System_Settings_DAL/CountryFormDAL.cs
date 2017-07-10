using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for CountryFormDAL
/// </summary>
public class CountryFormDAL
{

    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public CountryFormDAL()
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
            logExcpUIobj.MethodName = "CountryFormDAL()";
            logExcpUIobj.ResourceName = "CountryFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[CountryFormDAL : CountryFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetCountryListById(CountryFormUI countryFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Country_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = countryFormUI.Tbl_CountryId;

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
            logExcpUIobj.MethodName = "getCountryListById()";
            logExcpUIobj.ResourceName = "CountryFormDAL.CS";
            logExcpUIobj.RecordId = countryFormUI.Tbl_CountryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CountryFormDAL : getCountryListById] An error occured in the processing of Record Id : " + countryFormUI.Tbl_CountryId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddCountry(CountryFormUI countryFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Country_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = countryFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@CountryCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CountryCode"].Value = countryFormUI.CountryCode;

                sqlCmd.Parameters.Add("@CountryName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CountryName"].Value = countryFormUI.CountryName;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddCountry()";
            logExcpUIobj.ResourceName = "CountryFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CountryFormDAL : AddCountry] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateCountry(CountryFormUI countryFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Country_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = countryFormUI.ModifiedBy;
                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = countryFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@CountryCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CountryCode"].Value = countryFormUI.CountryCode;

                sqlCmd.Parameters.Add("@CountryName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CountryName"].Value = countryFormUI.CountryName;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateCountry()";
            logExcpUIobj.ResourceName = "CountryFormDAL.CS";
            logExcpUIobj.RecordId = countryFormUI.Tbl_CountryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CountryFormDAL : UpdateCountry] An error occured in the processing of Record Id : " + countryFormUI.Tbl_CountryId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteCountry(CountryFormUI countryFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Country_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = countryFormUI.Tbl_CountryId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteCountry()";
            logExcpUIobj.ResourceName = "CountryFormDAL.CS";
            logExcpUIobj.RecordId = countryFormUI.Tbl_CountryId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CountryFormDAL : DeleteCountry] An error occured in the processing of Record Id : " + countryFormUI.Tbl_CountryId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    
}