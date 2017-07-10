using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for Segment09FormDAL
/// </summary>
public class Segment09FormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public Segment09FormDAL()
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
            logExcpUIobj.MethodName = "Segment09FormDAL()";
            logExcpUIobj.ResourceName = "Segment09FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[Segment09FormDAL : Segment09FormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetSegment09ListById(Segment09FormUI segment09FormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Segment09_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_Segment09Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment09Id"].Value = segment09FormUI.Tbl_Segment09Id;

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
            logExcpUIobj.MethodName = "getSegment09ListById()";
            logExcpUIobj.ResourceName = "Segment09FormDAL.CS";
            logExcpUIobj.RecordId = segment09FormUI.Tbl_Segment09Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment09FormDAL : getSegment09ListById] An error occured in the processing of Record Id : " + segment09FormUI.Tbl_Segment09Id + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddSegment09(Segment09FormUI segment09FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment09_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = segment09FormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = segment09FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = segment09FormUI.Number;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = segment09FormUI.Description;

                sqlCmd.Parameters.Add("@tbl_Segment01Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment01Id"].Value = segment09FormUI.Tbl_Segment01Id;

                sqlCmd.Parameters.Add("@tbl_Segment02Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment02Id"].Value = segment09FormUI.Tbl_Segment02Id;

                sqlCmd.Parameters.Add("@tbl_Segment03Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment03Id"].Value = segment09FormUI.Tbl_Segment03Id;

                sqlCmd.Parameters.Add("@tbl_Segment04Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment04Id"].Value = segment09FormUI.Tbl_Segment04Id;

                sqlCmd.Parameters.Add("@tbl_Segment05Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment05Id"].Value = segment09FormUI.Tbl_Segment05Id;

                sqlCmd.Parameters.Add("@tbl_Segment06Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment06Id"].Value = segment09FormUI.Tbl_Segment06Id;

                sqlCmd.Parameters.Add("@tbl_Segment07Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment07Id"].Value = segment09FormUI.Tbl_Segment07Id;

                sqlCmd.Parameters.Add("@tbl_Segment08Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment08Id"].Value = segment09FormUI.Tbl_Segment08Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddSegment09()";
            logExcpUIobj.ResourceName = "Segment09FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment09FormDAL : AddSegment09] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateSegment09(Segment09FormUI segment09FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment09_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = segment09FormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = segment09FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = segment09FormUI.Number;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = segment09FormUI.Description;

                sqlCmd.Parameters.Add("@tbl_Segment01Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment01Id"].Value = segment09FormUI.Tbl_Segment01Id;

                sqlCmd.Parameters.Add("@tbl_Segment02Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment02Id"].Value = segment09FormUI.Tbl_Segment02Id;

                sqlCmd.Parameters.Add("@tbl_Segment03Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment03Id"].Value = segment09FormUI.Tbl_Segment03Id;

                sqlCmd.Parameters.Add("@tbl_Segment04Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment04Id"].Value = segment09FormUI.Tbl_Segment04Id;

                sqlCmd.Parameters.Add("@tbl_Segment05Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment05Id"].Value = segment09FormUI.Tbl_Segment05Id;

                sqlCmd.Parameters.Add("@tbl_Segment06Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment06Id"].Value = segment09FormUI.Tbl_Segment06Id;

                sqlCmd.Parameters.Add("@tbl_Segment07Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment07Id"].Value = segment09FormUI.Tbl_Segment07Id;

                sqlCmd.Parameters.Add("@tbl_Segment08Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment08Id"].Value = segment09FormUI.Tbl_Segment08Id;

                sqlCmd.Parameters.Add("@tbl_Segment09Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment09Id"].Value = segment09FormUI.Tbl_Segment09Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateSegment09()";
            logExcpUIobj.ResourceName = "Segment09FormDAL.CS";
            logExcpUIobj.RecordId = segment09FormUI.Tbl_Segment09Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment09FormDAL : UpdateSegment09] An error occured in the processing of Record Id : " + segment09FormUI.Tbl_Segment09Id + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteSegment09(Segment09FormUI segment09FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment09_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_Segment09Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment09Id"].Value = segment09FormUI.Tbl_Segment09Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSegment09()";
            logExcpUIobj.ResourceName = "Segment09FormDAL.CS";
            logExcpUIobj.RecordId = segment09FormUI.Tbl_Segment09Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment09FormDAL : DeleteSegment09] An error occured in the processing of Record Id : " + segment09FormUI.Tbl_Segment09Id + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}