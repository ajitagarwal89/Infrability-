using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using log4net;
/// <summary>
/// Summary description for SystemUserListDAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class SystemUserListDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SystemUserListDAL()
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
                logExcpUIobj.MethodName = "SystemUserListDAL()";
                logExcpUIobj.ResourceName = "SystemUserListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[SystemUserListDAL : SystemUserListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public DataTable GetUserList()
        {
            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();

            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("prSystemNewUserFetchAll", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

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
                logExcpUIobj.MethodName = "getPrivilegesDetails()";
                logExcpUIobj.ResourceName = "SystemUserListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[SystemUserListDAL : getPrivilegesDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
            finally
            {
                ds.Dispose();
            }
            return dtbl;
        }

        public DataTable GetUser(int id)
        {
            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("prSystemNewUserFetch", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add(new SqlParameter("@SystemUser", id));

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
                logExcpUIobj.ResourceName = "SystemUserListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[SystemUserListDAL : getUser] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
            finally
            {
                ds.Dispose();
            }
            return dtbl;
        }

        public int DeleteUser(string userId)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSystemNewUserDelete", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@SystemUser", SqlDbType.Int);
                    sqlCmd.Parameters["@SystemUser"].Value = userId;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "DeleteUser()";
                logExcpUIobj.ResourceName = "SystemUserListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[SystemUserListDAL : DeleteUser] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public DataTable GetRoles(int id)
        {
            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();

            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("prUserRolesFetch", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add(new SqlParameter("@SystemUser", id));

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
                logExcpUIobj.MethodName = "GetRoles()";
                logExcpUIobj.ResourceName = "SystemUserListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[SystemUserListDAL : GetRoles] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
            finally
            {
                ds.Dispose();
            }
            return dtbl;
        }

        public int LockUser(int userId, int num)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSystemNewUserLock", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@SystemUser", SqlDbType.Int);
                    sqlCmd.Parameters["@SystemUser"].Value = userId;

                    sqlCmd.Parameters.Add("@IsLocked", SqlDbType.Int);
                    sqlCmd.Parameters["@IsLocked"].Value = num;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "LockUser()";
                logExcpUIobj.ResourceName = "SystemUserListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[SystemUserListDAL : LockUser] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public int ActivateUser(int userId, int num)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSystemNewUserActivate", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@SystemUser", SqlDbType.Int);
                    sqlCmd.Parameters["@SystemUser"].Value = userId;

                    sqlCmd.Parameters.Add("@IsActive", SqlDbType.Int);
                    sqlCmd.Parameters["@IsActive"].Value = num;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "ActivateUser()";
                logExcpUIobj.ResourceName = "SystemUserListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[SystemUserListDAL : ActivateUser] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public int ResetPassword(int userId)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSystemNewUserResetPassword", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@SystemUser", SqlDbType.Int);
                    sqlCmd.Parameters["@SystemUser"].Value = userId;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "ResetPassword()";
                logExcpUIobj.ResourceName = "SystemUserListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[SystemUserListDAL : ResetPassword] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public DataTable CheckUserExists(string userId)
        {
            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("prSystemNewUserCheckIfExists", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add(new SqlParameter("@UserId", userId));

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
                logExcpUIobj.MethodName = "CheckUserExists()";
                logExcpUIobj.ResourceName = "SystemUserListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[SystemUserListDAL : CheckUserExists] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
            finally
            {
                ds.Dispose();
            }
            return dtbl;
        }
    }
}