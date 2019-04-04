using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using log4net;

/// <summary>
/// Summary description for RolePageMappingListDAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class RolePageMappingListDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RolePageMappingListDAL()
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
                logExcpUIobj.MethodName = "RolePageMappingListDAL()";
                logExcpUIobj.ResourceName = "RolePageMappingListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[RolePageMappingListDAL : RolePageMappingListDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public DataTable GetRolePageMappingListDAL(int roleId)
        {
            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("PrRolePagemappingFetchForRole", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;                    
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add(new SqlParameter("@Role", roleId));

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
                logExcpUIobj.MethodName = "getRolePageMappingListDAL()";
                logExcpUIobj.ResourceName = "RolePageMappingListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[RolePageMappingListDAL : getRolePageMappingListDAL] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");

            }
            finally
            {
                ds.Dispose();
            }
            return dtbl;
        }

        public int RemovePageMapping(int profileId)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSecurityProfileRemovePageMapping", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@RoleId", SqlDbType.Int);
                    sqlCmd.Parameters["@RoleId"].Value = profileId;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "RemovePageMapping()";
                logExcpUIobj.ResourceName = "RolePageMappingListDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[RolePageMappingListDAL : RemovePageMapping] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }
    }
}