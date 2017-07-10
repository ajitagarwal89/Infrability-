using System;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for FiscalPeriodFormDAL
/// </summary>
public class FiscalPeriodFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public FiscalPeriodFormDAL()
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
            logExcpUIobj.MethodName = "FiscalPeriodFormDAL()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[FiscalPeriodFormDAL : FiscalPeriodFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetFiscalPeriodListById(FiscalPeriodFormUI fiscalPeriodFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriod_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = fiscalPeriodFormUI.Tbl_FiscalPeriodId;

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
            logExcpUIobj.MethodName = "getFiscalPeriodListById()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = fiscalPeriodFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : getFiscalPeriodListById] An error occured in the processing of Record Id : " + fiscalPeriodFormUI.Tbl_FiscalPeriodId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddFiscalPeriod(FiscalPeriodFormUI fiscalPeriodFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriod_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = fiscalPeriodFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = fiscalPeriodFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Opt_Year", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Year"].Value = fiscalPeriodFormUI.Opt_Year;

                sqlCmd.Parameters.Add("@FirstDayDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@FirstDayDate"].Value = fiscalPeriodFormUI.FirstDayDate;

                //sqlCmd.Parameters.Add("@FirstDayDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@FirstDayDate_Hijri"].Value = fiscalPeriodFormUI.FirstDayDate_Hijri;

                sqlCmd.Parameters.Add("@LastDayDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastDayDate"].Value = fiscalPeriodFormUI.LastDayDate;

                //sqlCmd.Parameters.Add("@LastDayDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@LastDayDate_Hijri"].Value = fiscalPeriodFormUI.LastDayDate_Hijri;

                sqlCmd.Parameters.Add("@HistoricalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@HistoricalYear"].Value = fiscalPeriodFormUI.HistoricalYear;

                sqlCmd.Parameters.Add("@NumberOfPeriod", SqlDbType.TinyInt);
                sqlCmd.Parameters["@NumberOfPeriod"].Value = fiscalPeriodFormUI.NumberOfPeriod;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddFiscalPeriod()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : AddFiscalPeriod] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateFiscalPeriod(FiscalPeriodFormUI fiscalPeriodFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriod_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = fiscalPeriodFormUI.Tbl_FiscalPeriodId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = fiscalPeriodFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = fiscalPeriodFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Opt_Year", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Year"].Value = fiscalPeriodFormUI.Opt_Year;

                sqlCmd.Parameters.Add("@FirstDayDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@FirstDayDate"].Value = fiscalPeriodFormUI.FirstDayDate;

                sqlCmd.Parameters.Add("@LastDayDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastDayDate"].Value = fiscalPeriodFormUI.LastDayDate;

                sqlCmd.Parameters.Add("@HistoricalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@HistoricalYear"].Value = fiscalPeriodFormUI.HistoricalYear;

                sqlCmd.Parameters.Add("@NumberOfPeriod", SqlDbType.TinyInt);
                sqlCmd.Parameters["@NumberOfPeriod"].Value = fiscalPeriodFormUI.NumberOfPeriod;



                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateFiscalPeriod()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = fiscalPeriodFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : UpdateFiscalPeriod] An error occured in the processing of Record Id : " + fiscalPeriodFormUI.Tbl_FiscalPeriodId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteFiscalPeriod(FiscalPeriodFormUI fiscalPeriodFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_FiscalPeriod_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_FiscalPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_FiscalPeriodId"].Value = fiscalPeriodFormUI.Tbl_FiscalPeriodId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteFiscalPeriod()";
            logExcpUIobj.ResourceName = "FiscalPeriodFormDAL.CS";
            logExcpUIobj.RecordId = fiscalPeriodFormUI.Tbl_FiscalPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[FiscalPeriodFormDAL : DeleteFiscalPeriod] An error occured in the processing of Record Id : " + fiscalPeriodFormUI.Tbl_FiscalPeriodId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}