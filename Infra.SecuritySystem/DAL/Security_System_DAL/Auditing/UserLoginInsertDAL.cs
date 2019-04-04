using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using log4net;

/// <summary>
/// Summary description for UserLoginInsertDAL
/// </summary>
/// 
namespace Infra.SecuritySystem
{
    public class UserLoginInsertDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserLoginInsertDAL()
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
                logExcpUIobj.MethodName = "UserLoginInsertDAL()";
                logExcpUIobj.ResourceName = "UserLoginInsertDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[UserLoginInsertDAL : UserLoginInsertDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public int CreateLogForUserLogin(UserLoginFormUI userLoginFormUI)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSystemUserLoginAuditInsert", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@SystemUser", SqlDbType.Int);
                    sqlCmd.Parameters["@SystemUser"].Value = userLoginFormUI.SystemUser;

                    sqlCmd.Parameters.Add("@UserId", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@UserId"].Value = userLoginFormUI.UserId;

                    sqlCmd.Parameters.Add("@UserGuid", SqlDbType.NVarChar, 50);
                    sqlCmd.Parameters["@UserGuid"].Value = userLoginFormUI.UserGuid;

                    sqlCmd.Parameters.Add("@UserBrowser", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@UserBrowser"].Value = userLoginFormUI.UserBrowser;

                    sqlCmd.Parameters.Add("@UserIP", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@UserIP"].Value = userLoginFormUI.UserIP;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "CreateLogForUserLogin()";
                logExcpUIobj.ResourceName = "UserLoginInsertDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[UserLoginInsertDAL : CreateLogForUserLogin] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }
    }
}