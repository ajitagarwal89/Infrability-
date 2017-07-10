using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using log4net;
/// <summary>
/// Summary description for UserRolesDAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class UserRolesDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserRolesDAL()
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
                logExcpUIobj.MethodName = "UserRolesDAL()";
                logExcpUIobj.ResourceName = "UserRolesDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[UserRolesDAL : UserRolesDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public int AddRoles(UserRolesFormUI userRolesFormUI)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSystemNewUserRolesInsert", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@SystemUser", SqlDbType.Int);
                    sqlCmd.Parameters["@SystemUser"].Value = userRolesFormUI.SystemUser;

                    sqlCmd.Parameters.Add("@SecurityProfile", SqlDbType.Int);
                    sqlCmd.Parameters["@SecurityProfile"].Value = userRolesFormUI.SecurityProfile;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "AddRoles()";
                logExcpUIobj.ResourceName = "UserRolesDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[UserRolesDAL : AddRoles] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
            return result;
        }

        public int RemoveRoles(int id)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSystemNewUserRolesRemove", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@SystemUser", SqlDbType.Int);
                    sqlCmd.Parameters["@SystemUser"].Value = id;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "RemoveRoles()";
                logExcpUIobj.ResourceName = "UserRolesDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[UserRolesDAL : RemoveRoles] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public DataTable GetRoles()
        {
            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();

            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("prSecuritySystemProfilesFetchAllForUser", SupportCon);
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
                logExcpUIobj.MethodName = "getRoles()";
                logExcpUIobj.ResourceName = "UserRolesDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[UserRolesDAL : getRoles] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
            finally
            {
                ds.Dispose();
            }
            return dtbl;
        }
    }
}