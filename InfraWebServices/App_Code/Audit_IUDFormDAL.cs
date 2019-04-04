using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using log4net;

namespace InfraWebServices
{
    public class Audit_IUDFormDAL
    {
        LogExceptionUI logExcpUIobj = new LogExceptionUI();
        LogException logExcpDALobj = new LogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string connectionString = string.Empty;
        int commandTimeout = 0;

        public Audit_IUDFormDAL()
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
                logExcpUIobj.MethodName = "Audit_IUDFormDAL()";
                logExcpUIobj.ResourceName = "Audit_IUDFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[Audit_IUDFormDAL : Audit_IUDFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }
        public int AddAudit_IUD(Audit_IUDFormUI audit_IUDFormUI)
        {

            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("SP_Audit_IUD_Insert", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;
                    sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_OrganizationId"].Value = audit_IUDFormUI.Tbl_OrganizationId;

                    sqlCmd.Parameters.Add("@TableName", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@TableName"].Value = audit_IUDFormUI.TableName;

                    sqlCmd.Parameters.Add("@tbl_RecordId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_RecordId"].Value = audit_IUDFormUI.Tbl_RecordId;

                    sqlCmd.Parameters.Add("@tbl_UserId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_UserId"].Value = audit_IUDFormUI.Tbl_UserId;

                    sqlCmd.Parameters.Add("@Operation", SqlDbType.TinyInt);
                    sqlCmd.Parameters["@Operation"].Value = audit_IUDFormUI.Operation;

                    sqlCmd.Parameters.Add("@NewValue", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@NewValue"].Value = audit_IUDFormUI.NewValue;                   

                    sqlCmd.Parameters.Add("@IPAddress", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@IPAddress"].Value = audit_IUDFormUI.IPAddress;

                    sqlCmd.Parameters.Add("@Browser", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@Browser"].Value = audit_IUDFormUI.Browser;
                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "AddAudit_IUD()";
                logExcpUIobj.ResourceName = "Audit_IUDFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Audit_IUDFormDAL : AddAudit_IUD] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");

            }

            return result;

        }

        public int UpdateAudit_IUD(Audit_IUDFormUI audit_IUDFormUI)
        {

            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("SP_Audit_IUD_Update", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;
                    sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_OrganizationId"].Value = audit_IUDFormUI.Tbl_OrganizationId;

                    sqlCmd.Parameters.Add("@TableName", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@TableName"].Value = audit_IUDFormUI.TableName;

                    sqlCmd.Parameters.Add("@tbl_RecordId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_RecordId"].Value = audit_IUDFormUI.Tbl_RecordId;

                    sqlCmd.Parameters.Add("@tbl_UserId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_UserId"].Value = audit_IUDFormUI.Tbl_UserId;

                    sqlCmd.Parameters.Add("@Operation", SqlDbType.TinyInt);
                    sqlCmd.Parameters["@Operation"].Value = audit_IUDFormUI.Operation;

                    sqlCmd.Parameters.Add("@OldValue", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@OldValue"].Value = audit_IUDFormUI.OldValue;

                    sqlCmd.Parameters.Add("@NewValue", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@NewValue"].Value = audit_IUDFormUI.NewValue;                   

                    sqlCmd.Parameters.Add("@IPAddress", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@IPAddress"].Value = audit_IUDFormUI.IPAddress;

                    sqlCmd.Parameters.Add("@Browser", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@Browser"].Value = audit_IUDFormUI.Browser;
                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "UpdateAudit_IUD()";
                logExcpUIobj.ResourceName = "Audit_IUDFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Audit_IUDFormDAL : UpdateAudit_IUD] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");

            }

            return result;

        }

        public int DeleteAudit_IUD(Audit_IUDFormUI audit_IUDFormUI)
        {

            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("SP_Audit_IUD_Update", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;
                    sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_OrganizationId"].Value = audit_IUDFormUI.Tbl_OrganizationId;

                    sqlCmd.Parameters.Add("@TableName", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@TableName"].Value = audit_IUDFormUI.TableName;

                    sqlCmd.Parameters.Add("@tbl_RecordId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_RecordId"].Value = audit_IUDFormUI.Tbl_RecordId;

                    sqlCmd.Parameters.Add("@tbl_UserId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_UserId"].Value = audit_IUDFormUI.Tbl_UserId;

                    sqlCmd.Parameters.Add("@Operation", SqlDbType.TinyInt);
                    sqlCmd.Parameters["@Operation"].Value = audit_IUDFormUI.Operation;
              
                    sqlCmd.Parameters.Add("@IPAddress", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@IPAddress"].Value = audit_IUDFormUI.IPAddress;

                    sqlCmd.Parameters.Add("@Browser", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@Browser"].Value = audit_IUDFormUI.Browser;
                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "DeleteAudit_IUD()";
                logExcpUIobj.ResourceName = "Audit_IUDFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Audit_IUDFormDAL : DeleteAudit_IUD] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");

            }

            return result;

        }

        public string GetOldRecordData(string recordId)
        {
            string oldRecord = string.Empty;
            DataTable dtb = new DataTable();

            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("SP_Audit_SelectByRecordIDAndTableName", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@tbl_RecordId", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@tbl_RecordId"].Value = recordId;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                    {
                        adapter.Fill(dtb);
                    }

                    if (dtb.Rows.Count > 0)
                        oldRecord = dtb.Rows[0]["NewValue"].ToString();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch(Exception exp)
            {
                logExcpUIobj.MethodName = "GetOldRecordData()";
                logExcpUIobj.ResourceName = "Audit_IUDFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[Audit_IUDFormDAL : GetOldRecordData] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return oldRecord;
        }

    }
}