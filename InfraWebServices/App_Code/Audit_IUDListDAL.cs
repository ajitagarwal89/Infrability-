using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InfraWebServices
{
    public class Audit_IUDListDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;


        public DataTable GetAudit_IUDList()
        {

            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();

            try
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                using (SqlConnection SupportCon = new SqlConnection(constr))
                {
                    SqlCommand sqlCmd = new SqlCommand("SP_Audit_IUD_Select", SupportCon);
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
                throw exp;
            }
            finally
            {
                ds.Dispose();
            }

            return dtbl;

        }

        public DataTable GetAudit_SelectRecordfromAudit_S_Select(Audit_IUDListUI audit_IUDListUI)
        {
            DataTable dtbl = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                
                }
            }
            catch
            {
            }
            finally {
            }
            return dtbl;
        }
    }
}