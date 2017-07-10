using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for Segment04FormDAL
/// </summary>
public class Segment04FormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public Segment04FormDAL()
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
            logExcpUIobj.MethodName = "Segment04FormDAL()";
            logExcpUIobj.ResourceName = "Segment04FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[Segment04FormDAL : Segment04FormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetSegment04ListById(Segment04FormUI segment04FormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[SP_Segment04_SelectById]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_Segment04Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment04Id"].Value = segment04FormUI.Tbl_Segment04Id;

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
            logExcpUIobj.MethodName = "getSegment04ListById()";
            logExcpUIobj.ResourceName = "Segment04FormDAL.CS";
            logExcpUIobj.RecordId = segment04FormUI.Tbl_Segment04Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment04FormDAL : getSegment04ListById] An error occured in the processing of Record Id : " + segment04FormUI.Tbl_Segment04Id + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddSegment04(Segment04FormUI segment04FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment04_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = segment04FormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = segment04FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = segment04FormUI.Number;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = segment04FormUI.Description;
                sqlCmd.Parameters.Add("@tbl_Segment01Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment01Id"].Value = segment04FormUI.Tbl_Segment01Id;
                sqlCmd.Parameters.Add("@tbl_Segment02Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment02Id"].Value = segment04FormUI.Tbl_Segment02Id;

                sqlCmd.Parameters.Add("@tbl_Segment03Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment03Id"].Value = segment04FormUI.Tbl_Segment03Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddSegment04()";
            logExcpUIobj.ResourceName = "Segment04FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment04FormDAL : AddSegment04] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateSegment04(Segment04FormUI segment04FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment04_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = segment04FormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = segment04FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = segment04FormUI.Number;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = segment04FormUI.Description;
                sqlCmd.Parameters.Add("@tbl_Segment01Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment01Id"].Value = segment04FormUI.Tbl_Segment01Id;
                sqlCmd.Parameters.Add("@tbl_Segment02Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment02Id"].Value = segment04FormUI.Tbl_Segment02Id;
                sqlCmd.Parameters.Add("@tbl_Segment03Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment03Id"].Value = segment04FormUI.Tbl_Segment03Id;
                sqlCmd.Parameters.Add("@tbl_Segment04Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment04Id"].Value = segment04FormUI.Tbl_Segment04Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateSegment04()";
            logExcpUIobj.ResourceName = "Segment04FormDAL.CS";
            logExcpUIobj.RecordId = segment04FormUI.Tbl_Segment04Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment04FormDAL : UpdateSegment04] An error occured in the processing of Record Id : " + segment04FormUI.Tbl_Segment04Id + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteSegment04(Segment04FormUI segment04FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment04_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_Segment04Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment04Id"].Value = segment04FormUI.Tbl_Segment04Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSegment04()";
            logExcpUIobj.ResourceName = "Segment04FormDAL.CS";
            logExcpUIobj.RecordId = segment04FormUI.Tbl_Segment04Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment04FormDAL : DeleteSegment04] An error occured in the processing of Record Id : " + segment04FormUI.Tbl_Segment04Id + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}