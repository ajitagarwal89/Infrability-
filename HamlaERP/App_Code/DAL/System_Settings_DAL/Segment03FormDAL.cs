using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for Segment03FormDAL
/// </summary>
public class Segment03FormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public Segment03FormDAL()
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
            logExcpUIobj.MethodName = "Segment03FormDAL()";
            logExcpUIobj.ResourceName = "Segment03FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[Segment03FormDAL : Segment03FormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetSegment03ListById(Segment03FormUI segment03FormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Segment03_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_Segment03Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment03Id"].Value = segment03FormUI.Tbl_Segment03Id;

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
            logExcpUIobj.MethodName = "getSegment03ListById()";
            logExcpUIobj.ResourceName = "Segment03FormDAL.CS";
            logExcpUIobj.RecordId = segment03FormUI.Tbl_Segment03Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment03FormDAL : getSegment03ListById] An error occured in the processing of Record Id : " + segment03FormUI.Tbl_Segment03Id + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddSegment03(Segment03FormUI segment03FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment03_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = segment03FormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = segment03FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = segment03FormUI.Number;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = segment03FormUI.Description;

                sqlCmd.Parameters.Add("@tbl_Segment01Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment01Id"].Value = segment03FormUI.Tbl_Segment01Id;

                sqlCmd.Parameters.Add("@tbl_Segment02Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment02Id"].Value = segment03FormUI.Tbl_Segment02Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddSegment03()";
            logExcpUIobj.ResourceName = "Segment03FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment03FormDAL : AddSegment03] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateSegment03(Segment03FormUI segment03FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment03_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = segment03FormUI.ModifiedBy;
                sqlCmd.Parameters.Add("@tbl_Segment03Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment03Id"].Value = segment03FormUI.Tbl_Segment03Id;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = segment03FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = segment03FormUI.Number;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = segment03FormUI.Description;

                sqlCmd.Parameters.Add("@tbl_Segment01Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment01Id"].Value = segment03FormUI.Tbl_Segment01Id;
                sqlCmd.Parameters.Add("@tbl_Segment02Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment02Id"].Value = segment03FormUI.Tbl_Segment02Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateSegment03()";
            logExcpUIobj.ResourceName = "Segment03FormDAL.CS";
            logExcpUIobj.RecordId = segment03FormUI.Tbl_Segment03Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment03FormDAL : UpdateSegment03] An error occured in the processing of Record Id : " + segment03FormUI.Tbl_Segment03Id + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteSegment03(Segment03FormUI segment03FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment03_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_Segment03Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment03Id"].Value = segment03FormUI.Tbl_Segment03Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSegment03()";
            logExcpUIobj.ResourceName = "Segment03FormDAL.CS";
            logExcpUIobj.RecordId = segment03FormUI.Tbl_Segment03Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment03FormDAL : DeleteSegment03] An error occured in the processing of Record Id : " + segment03FormUI.Tbl_Segment03Id + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}