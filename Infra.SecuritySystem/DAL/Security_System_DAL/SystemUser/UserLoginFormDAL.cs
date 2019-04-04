using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using log4net;

/// <summary>
/// Summary description for UserLoginFormDAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class UserLoginFormDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserLoginFormDAL()
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
                logExcpUIobj.MethodName = "UserLoginFormDAL()";
                logExcpUIobj.ResourceName = "UserLoginFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[UserLoginFormDAL : UserLoginFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public DataTable GetUser(UserLoginFormUI userLoginFormUI)
        {
            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("PrSystemNewUserLogin", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@UserId", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@UserId"].Value = userLoginFormUI.UserId;

                    sqlCmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@Password"].Value = userLoginFormUI.Password;

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
                logExcpUIobj.MethodName = "getUser()";
                logExcpUIobj.ResourceName = "UserLoginFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[UserLoginFormDAL : getUser] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
            finally
            {
                ds.Dispose();
            }
            return dtbl;
        }
        public DataSet GetSystemSettings(UserLoginFormUI userLoginFormUI)
        {

            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();
            //Boolean result = false;

            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("SP_SystemSettings", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_OrganizationId"].Value = userLoginFormUI.Tbl_OrganizationId;

                    sqlCmd.Parameters.Add("@Year", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@Year"].Value = userLoginFormUI.Year;
                    
                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                    {
                        adapter.Fill(ds);
                    }
                    //if (ds.Tables.Count > 0)
                    //    dtbl = ds.Tables[0];

                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "GetFiscalPeriod()";
                logExcpUIobj.ResourceName = "UserLoginFormDAL.CS";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
                
            }
            finally
            {
                ds.Dispose();
            }

            return ds;

        }
    }
   
}