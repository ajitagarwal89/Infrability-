using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using log4net;


/// <summary>
/// Summary description for Audit_SDAL
/// </summary>
public class Audit_SDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public Audit_SDAL()
    {
        try {
            GlobalConfigurations objConfig = new global::GlobalConfigurations();
            objConfig.InitilizeConnectionString();
            //commandTimeOut = Convert.ToInt32(objConfig.commandTimeout);
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "Audit_SDAL()";
            logExcpUIobj.ResourceName = "Audit_SDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[Audit_SDAL : Audit_SDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAudit_Audit_SList()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Audit_S_SelectByDate", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);

                }
            }
            if (ds.Tables.Count > 0)
            {
                dtbl = ds.Tables[0];
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetAudit_Audit_SList()";
            logExcpUIobj.ResourceName = "Audit_SDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Audit_SDAL : GetAudit_Audit_SList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally {
            ds.Dispose();

        }
        return dtbl;
    }
    public DataTable GetAudit_SListSearchParameter(Audit_SUI audit_SUI)
    {
        DataSet ds = new DataSet();
        DataTable dtlb = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Audit_IUD_SelectBySearchParameters", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@StartDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@StartDate"].Value = audit_SUI.StartDate;
                sqlCmd.Parameters.Add("@EndDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@EndDate"].Value = audit_SUI.EndDate;
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd )) {
                    adapter.Fill(ds);
                } 
            }
            if (ds.Tables.Count > 0)
                dtlb = ds.Tables[0];


        }
        catch (Exception exp) {
            logExcpUIobj.MethodName = "GetAssetAudit_UIDListSearchParameters()";
            logExcpUIobj.ResourceName = "Audit_IUDListDAL.CS";
           // logExcpUIobj.RecordId = "Search = " + audit_IUDListUI.Search;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            //log.Error("[Audit_IUDListDAL : GetAssetAudit_UIDListSearchParameters] An error occured in the processing of Record Search = " + + " . Details : [" + exp.ToString() + "]");
        }
        finally {
            ds.Dispose();
        }
        return dtlb;
            }

}