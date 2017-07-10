using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;


namespace InfrERPWS
{
    /// <summary>
    /// Summary description for AuditWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AuditWS : System.Web.Services.WebService
    {
        public AuditWS()
        {
        }

        string connectionString = string.Empty;
        int commandTimeout = 0;
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Add(int a, int b)
        {
            return a + b;

        }

        [WebMethod]
            public void AddAudit_IUD(string tbl_OrganizationId, string tbl_UserId, string TableName,int Opertaion,  string NewValue,string OldValue, string ipAddress,string Browser)
        {
            ////    Audit_IUDFormUI audit_IUDFormUI = new Audit_IUDFormUI();
            ////    audit_IUDFormUI.Tbl_OrganizationId = tbl_OrganizationId;
            ////    audit_IUDFormUI.Tbl_UserId = tbl_UserId;
            ////    audit_IUDFormUI.TableName = TableName;          
            ////    audit_IUDFormUI.NewValue = NewValue;
            ////    audit_IUDFormUI.OldValue = OldValue;
            ////    audit_IUDFormUI.IPAddress = ipAddress;
            ////    audit_IUDFormUI.Browser = Browser;
            ////    try
            ////    {
            ////        Audit_IUDFormBAL audit_IUDFormBAL = new Audit_IUDFormBAL();
            ////        audit_IUDFormBAL.AddAudit_IUD(audit_IUDFormUI);

            ////    }
            ////    catch (Exception exp)
            ////    {
            ////        throw exp;

            ////    }
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    SqlCommand sqlCmd = new SqlCommand("SP_Audit_IUD_Insert", con);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;
                    sqlCmd.Parameters.AddWithValue("@tbl_OrganizationId", tbl_OrganizationId);
                    sqlCmd.Parameters.AddWithValue("@tbl_UserId", tbl_UserId);
                    sqlCmd.Parameters.AddWithValue("@TableName", TableName);
                    sqlCmd.Parameters.AddWithValue("@Operation", Opertaion);
                    sqlCmd.Parameters.AddWithValue("@NewValue", NewValue);
                    sqlCmd.Parameters.AddWithValue("@OldValue", OldValue);
                    sqlCmd.Parameters.AddWithValue("@IPAddress", ipAddress);
                    sqlCmd.Parameters.AddWithValue("@Browser", Browser);

                    sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    con.Close();
                }
            }
            catch (Exception exp)
            {
                throw exp;

            }

        }
            //  public void AddAuditInsert()

        }
}
