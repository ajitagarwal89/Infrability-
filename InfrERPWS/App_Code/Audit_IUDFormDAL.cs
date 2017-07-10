using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace InfrERPWS
{
    public class Audit_IUDFormDAL
    {
       string connectionString = string.Empty;
        int commandTimeout = 0;

        public int AddAudit_IUD(Audit_IUDFormUI audit_IUDFormUI)
        {
           
                int result = 0;
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection SupportCon = new SqlConnection(constr))
                //using (SqlConnection SupportCon = new SqlConnection(connectionString))
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
                    sqlCmd.Parameters["@Operation"].Value = Convert.ToInt32(1).ToString();

                     sqlCmd.Parameters.Add("@NewValue", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@NewValue"].Value = audit_IUDFormUI.NewValue;

                    sqlCmd.Parameters.Add("@OldValue", SqlDbType.NVarChar);
                    sqlCmd.Parameters["@OldValue"].Value = audit_IUDFormUI.OldValue;

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
                throw exp;

            }

            return result;

        }
    }

}