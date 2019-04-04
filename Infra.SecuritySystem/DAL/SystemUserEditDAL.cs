using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using log4net;

/// <summary>
/// Summary description for SystemUserEditDAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class SystemUserEditDAL
    {

        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SystemUserEditDAL()
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
                logExcpUIobj.MethodName = "SystemUserEditDAL()";
                logExcpUIobj.ResourceName = "SystemUserEditDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[SystemUserEditDAL : SystemUserEditDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public void InsertSystemUserOrgCode(DataSet ds, string OrgCode)
        {


            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSystemUserInsertOrgCode", SupportCon);

                    sqlCmd.Parameters.Add("@OrgCode", SqlDbType.SmallInt);
                    sqlCmd.Parameters["@OrgCode"].Value = OrgCode;

                    sqlCmd.Parameters.Add("@SystemUser", SqlDbType.Int);
                    sqlCmd.Parameters["@SystemUser"].Value = ds.Tables[0].Rows[0]["SystemUser"].ToString();

                    sqlCmd.CommandType = CommandType.StoredProcedure;

                    sqlCmd.ExecuteNonQuery();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "InsertSystemUserOrgCode()";
                logExcpUIobj.ResourceName = "SystemUserEditDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[SystemUserEditDAL : InsertSystemUserOrgCode] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");

            }
            finally
            {

            }
        }
    }
}