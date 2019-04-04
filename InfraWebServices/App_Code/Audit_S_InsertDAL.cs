using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InfraWebServices
{
    public class Audit_S_InsertDAL
    {
        LogExceptionUI logExcpUIobj = new LogExceptionUI();
        LogException logExcpDALobj = new LogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string connectionString = string.Empty;
        int commandTimeout = 0;
        public Audit_S_InsertDAL()
        {
            try
            {
                GlobalConfigurations objConfig = new GlobalConfigurations();
                objConfig.InitilizeConnectionString();
                connectionString = objConfig.connectionString;
                commandTimeout = Convert.ToInt32(objConfig.commandTimeout);
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "Audit_S_InsertDAL()";
                logExcpUIobj.ResourceName = "Audit_S_InsertDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[Audit_IUDFormDAL : Audit_IUDFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }

        }
        public int Audit_S_insert(Audit_Select_InsertUI audit_S_InsertUI)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("SP_Audit_S_Insert", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;
                    sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_OrganizationId"].Value = audit_S_InsertUI.Tbl_OrganizationId;

                    sqlCmd.Parameters.Add("@TableName", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@TableName"].Value = audit_S_InsertUI.TableName;

                    sqlCmd.Parameters.Add("@tbl_RecordId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_RecordId"].Value = audit_S_InsertUI.Tbl_RecordId;

                    sqlCmd.Parameters.Add("@tbl_UserId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_UserId"].Value = audit_S_InsertUI.Tbl_UserId;
                                       
                    sqlCmd.Parameters.Add("@SelectedValue", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@SelectedValue"].Value = audit_S_InsertUI.SelectedValue;

                    sqlCmd.Parameters.Add("@IPAddress", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@IPAddress"].Value = audit_S_InsertUI.IPAddress;

                    sqlCmd.Parameters.Add("@Browser", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@Browser"].Value = audit_S_InsertUI.Browser;
                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }

            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "Audit_S_insert()";
                logExcpUIobj.ResourceName = "Audit_S_InsertDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Audit_S_InsertDAL : Audit_S_InsertDAL] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }
    }
}
