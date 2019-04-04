using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using log4net;

/// <summary>
/// Summary description for SecurityProfileFormDAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class SecurityProfileFormDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SecurityProfileFormDAL()
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
                logExcpUIobj.MethodName = "SecurityProfileFormDAL()";
                logExcpUIobj.ResourceName = "SecurityProfileFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[SecurityProfileFormDAL : SecurityProfileFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public int AddSecurityProfile(SecurityProfileFormUI securityProfileFormUI, ref int newProfileId)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSecurityProfileInsert", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@SecurityProfileX", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@SecurityProfileX"].Value = securityProfileFormUI.SecurityProfileX;

                    sqlCmd.Parameters.Add("@CreatedOnDate", SqlDbType.DateTime);
                    sqlCmd.Parameters["@CreatedOnDate"].Value = securityProfileFormUI.CreatedOn;

                    sqlCmd.Parameters.Add("@UpdatedOnDate", SqlDbType.DateTime);
                    sqlCmd.Parameters["@UpdatedOnDate"].Value = securityProfileFormUI.UpdatedOn;

                    sqlCmd.Parameters.Add("@SecurityProfile", SqlDbType.Int);
                    sqlCmd.Parameters["@SecurityProfile"].Direction = ParameterDirection.Output;

                    result = sqlCmd.ExecuteNonQuery();

                    if (result == -1)
                    {
                        newProfileId = Convert.ToInt32(sqlCmd.Parameters["@SecurityProfile"].Value.ToString());
                    }

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "AddSecurityProfile()";
                logExcpUIobj.ResourceName = "SecurityProfileFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[SecurityProfileFormDAL : AddSecurityProfile] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public int UpdateSecurityProfile(SecurityProfileFormUI securityProfileFormUI, int id)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSecurityProfileUpdate", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@SecurityProfileX", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@SecurityProfileX"].Value = securityProfileFormUI.SecurityProfileX;

                    sqlCmd.Parameters.Add("@UpdatedOnDate", SqlDbType.DateTime);
                    sqlCmd.Parameters["@UpdatedOnDate"].Value = securityProfileFormUI.UpdatedOn;

                    sqlCmd.Parameters.Add("@SecurityProfile", SqlDbType.Int);
                    sqlCmd.Parameters["@SecurityProfile"].Value = id;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "UpdateSecurityProfile()";
                logExcpUIobj.ResourceName = "SecurityProfileFormDAL.CS";
                logExcpUIobj.RecordId = id.ToString();
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[SecurityProfileFormDAL : UpdateSecurityProfile] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public int DeleteSecurityProfile(int id)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSecurityProfileDelete", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@SecurityProfile", SqlDbType.Int);
                    sqlCmd.Parameters["@SecurityProfile"].Value = id;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "DeleteSecurityProfile()";
                logExcpUIobj.ResourceName = "SecurityProfileFormDAL.CS";
                logExcpUIobj.RecordId = id.ToString();
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[SecurityProfileFormDAL : DeleteSecurityProfile] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }
    }
}