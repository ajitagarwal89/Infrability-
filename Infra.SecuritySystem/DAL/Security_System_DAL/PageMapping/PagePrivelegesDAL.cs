using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using log4net;
/// <summary>
/// Summary description for PagePrivelegesDAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class PagePrivelegesDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PagePrivelegesDAL()
        {
            try
            {
                SecuritySystemConfigurations objConfig = new SecuritySystemConfigurations();
                objConfig.InitilizeConnectionString();
                connectionString = objConfig.connectionString;
                commandTimeout = Convert.ToInt32(objConfig.commandTimeout);
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "PagePrivelegesDAL()";
                logExcpUIobj.ResourceName = "PagePrivelegesDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[PagePrivelegesDAL : PagePrivelegesDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public DataTable GetUserPrivelegesForPage(int userId, string pageName)
        {
            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("PrCheckSystemUserPagePriveleges", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add(new SqlParameter("@UserId", userId));
                    sqlCmd.Parameters.Add(new SqlParameter("@PageName", pageName));

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
                logExcpUIobj.MethodName = "getUserPrivelegesForPage()";
                logExcpUIobj.ResourceName = "PagePrivelegesDAL.CS";
                logExcpUIobj.RecordId = userId.ToString();
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PagePrivelegesDAL : getUserPrivelegesForPage] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
            finally
            {
                ds.Dispose();
            }
            return dtbl;
        }

        public DataSet GetUserPrivelegesForControls(int userId, string pageName)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("prCheckSystemUserPageControlPriveleges", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add(new SqlParameter("@UserId", userId));
                    sqlCmd.Parameters.Add(new SqlParameter("@PageName", pageName));

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                    {
                        adapter.Fill(ds);
                    }
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "getUserPrivelegesForControls()";
                logExcpUIobj.ResourceName = "PagePrivelegesDAL.CS";
                logExcpUIobj.RecordId = userId.ToString();
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PagePrivelegesDAL : getUserPrivelegesForControls] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }
    }
}