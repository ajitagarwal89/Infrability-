using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using log4net;

/// <summary>
/// Summary description for ControlMappingFormDAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class PageControlFormDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PageControlFormDAL()
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
                logExcpUIobj.MethodName = "PageControlFormDAL()";
                logExcpUIobj.ResourceName = "PageControlFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[PageControlFormDAL : PageControlFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public int AddControl(PageControlFormUI controlMappingFormUI)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prControlMappingInsert", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@PageMapping", SqlDbType.Int);
                    sqlCmd.Parameters["@PageMapping"].Value = controlMappingFormUI.PageMapping;

                    sqlCmd.Parameters.Add("@ControlMappingX", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@ControlMappingX"].Value = controlMappingFormUI.ControlMappingX;

                    sqlCmd.Parameters.Add("@ControlMappingCode", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@ControlMappingCode"].Value = controlMappingFormUI.ControlMappingCode;

                    sqlCmd.Parameters.Add("@CreatedOnDate", SqlDbType.DateTime);
                    sqlCmd.Parameters["@CreatedOnDate"].Value = controlMappingFormUI.CreatedOn;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "AddControl()";
                logExcpUIobj.ResourceName = "PageControlFormDAL.cs";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PageControlFormDAL : AddControl] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public int UpdateControl(PageControlFormUI controlMappingFormUI, int id)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prControlMappingUpdate", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@ControlMappingX", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@ControlMappingX"].Value = controlMappingFormUI.ControlMappingX;

                    sqlCmd.Parameters.Add("@UpdatedOnDate", SqlDbType.DateTime);
                    sqlCmd.Parameters["@UpdatedOnDate"].Value = controlMappingFormUI.UpdatedOn;

                    sqlCmd.Parameters.Add("@ControlMapping", SqlDbType.Int);
                    sqlCmd.Parameters["@ControlMapping"].Value = id;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "UpdateControl()";
                logExcpUIobj.ResourceName = "PageControlFormDAL.cs";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PageControlFormDAL : UpdateControl] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public int DeleteControl(int id)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prControlMappingDelete", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@ControlMapping", SqlDbType.Int);
                    sqlCmd.Parameters["@ControlMapping"].Value = id;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "DeleteControl()";
                logExcpUIobj.ResourceName = "PageControlFormDAL.cs";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PageControlFormDAL : DeleteControl] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }
    }
}