using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using log4net;

/// <summary>
/// Summary description for PageControlEdit
/// </summary>
namespace Infra.SecuritySystem
{
    public class PrivilegesDetailsDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public PrivilegesDetailsDAL()
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
                logExcpUIobj.MethodName = "PrivilegesDetailsDAL()";
                logExcpUIobj.ResourceName = "PrivilegesDetailsDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[PrivilegesDetailsDAL : PrivilegesDetailsDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public int AddProfilePageControlMapping(int profileId, int pageId, int controlId, string privelege)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSecurityProfilePageControlMappingInsert", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@RoleId", SqlDbType.Int);
                    sqlCmd.Parameters["@RoleId"].Value = profileId;

                    sqlCmd.Parameters.Add("@PageId", SqlDbType.Int);
                    sqlCmd.Parameters["@PageId"].Value = pageId;

                    sqlCmd.Parameters.Add("@ControlId", SqlDbType.Int);
                    sqlCmd.Parameters["@ControlId"].Value = controlId;

                    sqlCmd.Parameters.Add("@Privelege", SqlDbType.VarChar, 5);
                    sqlCmd.Parameters["@Privelege"].Value = privelege;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "AddProfilePageControlMapping()";
                logExcpUIobj.ResourceName = "PrivilegesDetailsDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PrivilegesDetailsDAL : AddProfilePageControlMapping] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public DataTable GetPrivilegesDetails(int securityProfile, int pageMapping)
        {
            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("prSecurityProfilePageControlMappingSelect", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;                    
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add(new SqlParameter("@RoleId", securityProfile));
                    sqlCmd.Parameters.Add(new SqlParameter("@PageId", pageMapping));

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
                logExcpUIobj.ResourceName = "PrivilegesDetailsDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PrivilegesDetailsDAL : getPrivilegesDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");

            }
            finally
            {
                ds.Dispose();
            }
            return dtbl;
        }

        public int RemoveProfilePageControlMapping(int profileId, int pageId)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSecurityProfilePageControlMappingRemove", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@RoleId", SqlDbType.Int);
                    sqlCmd.Parameters["@RoleId"].Value = profileId;

                    sqlCmd.Parameters.Add("@PageId", SqlDbType.Int);
                    sqlCmd.Parameters["@PageId"].Value = pageId;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "RemoveProfilePageControlMapping()";
                logExcpUIobj.ResourceName = "PrivilegesDetailsDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[PrivilegesDetailsDAL : RemoveProfilePageControlMapping] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }
    }
}