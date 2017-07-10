using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using log4net;

/// <summary>
/// Summary description for PageMappingFormDAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class PageFormDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PageFormDAL()
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
                logExcpUIobj.MethodName = "PageFormDAL()";
                logExcpUIobj.ResourceName = "PageFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[PageFormDAL : PageFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public int AddPage(PageFormUI pageMappingFormUI)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prPageMappingInsert", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@PageMappingX", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@PageMappingX"].Value = pageMappingFormUI.PageMappingX;

                    sqlCmd.Parameters.Add("@CreatedOnDate", SqlDbType.DateTime);
                    sqlCmd.Parameters["@CreatedOnDate"].Value = pageMappingFormUI.CreatedOn;

                    sqlCmd.Parameters.Add("@UpdatedOnDate", SqlDbType.DateTime);
                    sqlCmd.Parameters["@UpdatedOnDate"].Value = pageMappingFormUI.UpdatedOn;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "AddPage()";
                logExcpUIobj.ResourceName = "PageFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PageFormDAL : AddPage] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public int UpdatePage(PageFormUI pageMappingFormUI, int id)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prPageMappingUpdate", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@PageMappingX", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@PageMappingX"].Value = pageMappingFormUI.PageMappingX;

                    sqlCmd.Parameters.Add("@UpdatedOnDate", SqlDbType.DateTime);
                    sqlCmd.Parameters["@UpdatedOnDate"].Value = pageMappingFormUI.UpdatedOn;

                    sqlCmd.Parameters.Add("@PageMapping", SqlDbType.Int);
                    sqlCmd.Parameters["@PageMapping"].Value = id;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "UpdatePage()";
                logExcpUIobj.ResourceName = "PageFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PageFormDAL : UpdatePage] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public int DeletePage(int id)
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
                logExcpUIobj.ResourceName = "PageFormDAL.CS";
                logExcpUIobj.RecordId = id.ToString();
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PageFormDAL : DeletePage] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }
    }
}