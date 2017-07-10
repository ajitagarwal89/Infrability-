using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for Segment06FormDAL
/// </summary>
public class Segment06FormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public Segment06FormDAL()
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
            logExcpUIobj.MethodName = "Segment06FormDAL()";
            logExcpUIobj.ResourceName = "Segment06FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[Segment06FormDAL : Segment06FormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetSegment06ListById(Segment06FormUI segment06FormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Segment06_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_Segment06Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment06Id"].Value = segment06FormUI.Tbl_Segment06Id;

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
            logExcpUIobj.MethodName = "getSegment06ListById()";
            logExcpUIobj.ResourceName = "Segment06FormDAL.CS";
            logExcpUIobj.RecordId = segment06FormUI.Tbl_Segment06Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment06FormDAL : getSegment06ListById] An error occured in the processing of Record Id : " + segment06FormUI.Tbl_Segment06Id + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddSegment06(Segment06FormUI segment06FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment06_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = segment06FormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = segment06FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = segment06FormUI.Number;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = segment06FormUI.Description;

                sqlCmd.Parameters.Add("@tbl_Segment01Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment01Id"].Value = segment06FormUI.Tbl_Segment01Id;

                sqlCmd.Parameters.Add("@tbl_Segment02Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment02Id"].Value = segment06FormUI.Tbl_Segment02Id;

                sqlCmd.Parameters.Add("@tbl_Segment03Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment03Id"].Value = segment06FormUI.Tbl_Segment03Id;


                sqlCmd.Parameters.Add("@tbl_Segment04Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment04Id"].Value = segment06FormUI.Tbl_Segment04Id;

                sqlCmd.Parameters.Add("@tbl_Segment05Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment05Id"].Value = segment06FormUI.Tbl_Segment05Id;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddSegment06()";
            logExcpUIobj.ResourceName = "Segment06FormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment06FormDAL : AddSegment06] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateSegment06(Segment06FormUI segment06FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment06_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = segment06FormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = segment06FormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = segment06FormUI.Number;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = segment06FormUI.Description;

                sqlCmd.Parameters.Add("@tbl_Segment01Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment01Id"].Value = segment06FormUI.Tbl_Segment01Id;

                sqlCmd.Parameters.Add("@tbl_Segment02Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment02Id"].Value = segment06FormUI.Tbl_Segment02Id;

                sqlCmd.Parameters.Add("@tbl_Segment03Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment03Id"].Value = segment06FormUI.Tbl_Segment03Id;


                sqlCmd.Parameters.Add("@tbl_Segment04Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment04Id"].Value = segment06FormUI.Tbl_Segment04Id;

                sqlCmd.Parameters.Add("@tbl_Segment05Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment05Id"].Value = segment06FormUI.Tbl_Segment05Id;

                sqlCmd.Parameters.Add("@tbl_Segment06Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment06Id"].Value = segment06FormUI.Tbl_Segment06Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateSegment06()";
            logExcpUIobj.ResourceName = "Segment06FormDAL.CS";
            logExcpUIobj.RecordId = segment06FormUI.Tbl_Segment06Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment06FormDAL : UpdateSegment06] An error occured in the processing of Record Id : " + segment06FormUI.Tbl_Segment06Id + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteSegment06(Segment06FormUI segment06FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Segment06_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_Segment06Id", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Segment06Id"].Value = segment06FormUI.Tbl_Segment06Id;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteSegment06()";
            logExcpUIobj.ResourceName = "Segment06FormDAL.CS";
            logExcpUIobj.RecordId = segment06FormUI.Tbl_Segment06Id;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[Segment06FormDAL : DeleteSegment06] An error occured in the processing of Record Id : " + segment06FormUI.Tbl_Segment06Id + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}