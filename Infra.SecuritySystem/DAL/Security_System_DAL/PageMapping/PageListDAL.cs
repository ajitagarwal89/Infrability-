using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using log4net;

/// <summary>
/// Summary description for PageListDAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class PageListDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PageListDAL()
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
                logExcpUIobj.MethodName = "PageListDAL()";
                logExcpUIobj.ResourceName = "PageListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[PageListDAL : PageListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public DataTable GetPageList()
        {
            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("prPageMappingFetchAll", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                    {
                        adapter.Fill(ds);
                    }

                    if (ds.Tables.Count > 0)
                        dtbl = ds.Tables[0];
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "getPageList()";
                logExcpUIobj.ResourceName = "PageListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PageListDAL : getPageList] An error occured in the processing of Record . Details : [" + exp.ToString() + "]");

            }
            finally
            {
                ds.Dispose();
            }
            return dtbl;
        }

        public DataTable GetPage(int id)
        {
            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("prPageMappingFetch", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add(new SqlParameter("@PageMapping", id));                   

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
                logExcpUIobj.MethodName = "getPage()";
                logExcpUIobj.ResourceName = "PageListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PageListDAL : getPage] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");

            }
            finally
            {
                ds.Dispose();
            }
            return dtbl;
        }

        public int DeletePage(string id)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prPageMappingDelete", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@PageMapping", SqlDbType.Int);
                    sqlCmd.Parameters["@PageMapping"].Value = id;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "DeletePage()";
                logExcpUIobj.ResourceName = "PageListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PageListDAL : DeletePage] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

    }
}