using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using log4net;


/// <summary>
/// Summary description for ProfilePageMappingInsertDAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class ProfilePageMappingInsertDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ProfilePageMappingInsertDAL()
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
                logExcpUIobj.MethodName = "ProfilePageMappingInsertDAL()";
                logExcpUIobj.ResourceName = "ProfilePageMappingInsertDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[ProfilePageMappingInsertDAL : ProfilePageMappingInsertDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public int AddProfilePageMapping(int profileId, int pageId, int read)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSecurityProfilePageMappingInsert", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@RoleId", SqlDbType.Int);
                    sqlCmd.Parameters["@RoleId"].Value = profileId;

                    sqlCmd.Parameters.Add("@PageId", SqlDbType.Int);
                    sqlCmd.Parameters["@PageId"].Value = pageId;

                    sqlCmd.Parameters.Add("@Read", SqlDbType.Int);
                    sqlCmd.Parameters["@Read"].Value = read;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "AddProfilePageMapping()";
                logExcpUIobj.ResourceName = "ProfilePageMappingInsertDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[ProfilePageMappingInsertDAL : AddProfilePageMapping] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }
    }
}