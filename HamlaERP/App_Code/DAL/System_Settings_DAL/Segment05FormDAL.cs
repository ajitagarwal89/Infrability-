using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for Segment05FormDAL
/// </summary>
public class Segment05FormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public Segment05FormDAL()
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
            logExcpUIobj.MethodName = "Segment05FormDAL()";
            logExcpUIobj.ResourceName = "Segment05FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[Segment05FormDAL : Segment05FormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetSegment05ListById(Segment05FormUI segment05FormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Segment05_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_Segment05Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment05Id"].Value = segment05FormUI.Tbl_Segment05Id;

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
            logExcpUIobj.MethodName = "getSegment05ListById()";
            logExcpUIobj.ResourceName = "Segment05FormDAL.CS";
            logExcpUIobj.RecordId = segment05FormUI.Tbl_Segment05Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment05FormDAL : getSegment05ListById] An error occured in the processing of Record Id : " + segment05FormUI.Tbl_Segment05Id + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddSegment05(Segment05FormUI segment05FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment05_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = segment05FormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = segment05FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = segment05FormUI.Number;
                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = segment05FormUI.Description;
                sqlCmd.Parameters.Add("@tbl_Segment01Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment01Id"].Value = segment05FormUI.Tbl_Segment01Id;
                sqlCmd.Parameters.Add("@tbl_Segment02Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment02Id"].Value = segment05FormUI.Tbl_Segment02Id;
                sqlCmd.Parameters.Add("@tbl_Segment03Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment03Id"].Value = segment05FormUI.Tbl_Segment03Id;
                sqlCmd.Parameters.Add("@tbl_Segment04Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment04Id"].Value = segment05FormUI.Tbl_Segment04Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddSegment05()";
            logExcpUIobj.ResourceName = "Segment05FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment05FormDAL : AddSegment05] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateSegment05(Segment05FormUI segment05FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment05_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = segment05FormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = segment05FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = segment05FormUI.Number;
                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = segment05FormUI.Description;
                sqlCmd.Parameters.Add("@tbl_Segment01Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment01Id"].Value = segment05FormUI.Tbl_Segment01Id;
                sqlCmd.Parameters.Add("@tbl_Segment02Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment02Id"].Value = segment05FormUI.Tbl_Segment02Id;
                sqlCmd.Parameters.Add("@tbl_Segment03Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment03Id"].Value = segment05FormUI.Tbl_Segment03Id;
                sqlCmd.Parameters.Add("@tbl_Segment04Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment04Id"].Value = segment05FormUI.Tbl_Segment04Id;
                sqlCmd.Parameters.Add("@tbl_Segment05Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment05Id"].Value = segment05FormUI.Tbl_Segment05Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateSegment05()";
            logExcpUIobj.ResourceName = "Segment05FormDAL.CS";
            logExcpUIobj.RecordId = segment05FormUI.Tbl_Segment05Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment05FormDAL : UpdateSegment05] An error occured in the processing of Record Id : " + segment05FormUI.Tbl_Segment05Id + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteSegment05(Segment05FormUI segment05FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment05_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_Segment05Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment05Id"].Value = segment05FormUI.Tbl_Segment05Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSegment05()";
            logExcpUIobj.ResourceName = "Segment05FormDAL.CS";
            logExcpUIobj.RecordId = segment05FormUI.Tbl_Segment05Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment05FormDAL : DeleteSegment05] An error occured in the processing of Record Id : " + segment05FormUI.Tbl_Segment05Id + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}