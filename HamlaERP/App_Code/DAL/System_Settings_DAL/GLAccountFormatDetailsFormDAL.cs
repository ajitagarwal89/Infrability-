using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for GLAccountFormatDetailsFormDAL
/// </summary>
public class GLAccountFormatDetailsFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public GLAccountFormatDetailsFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountFormatDetialsFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetialsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountFormatDetialsFormDAL : GLAccountFormatDetialsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetGLAccountFormatDetailsListById(GLAccountFormatDetailsFormUI gLAccountFormatDetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormatDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountFormatDetialsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountFormatDetialsId"].Value = gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId;

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
            logExcpUIobj.MethodName = "getGLAccountFormatDetialsListById()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetailsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatDetailsFormDAL : getGLAccountFormatDetialsListById] An error occured in the processing of Record Id : " + gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetGLAccountFormatDetailsListForExportToExcel()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormatDetails_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetGLAccountFormatDetailsListForExportToExcel()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatDetailsFormDAL : GetGLAccountFormatDetailsListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGLAccountFormatDetails(GLAccountFormatDetailsFormUI gLAccountFormatDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormatDetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountFormatDetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountFormatDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountFormatId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountFormatId"].Value = gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatId;



                sqlCmd.Parameters.Add("@SegmentName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SegmentName"].Value = gLAccountFormatDetailsFormUI.SegmentName;

                sqlCmd.Parameters.Add("@MaxLength", SqlDbType.Int);
                sqlCmd.Parameters["@MaxLength"].Value = gLAccountFormatDetailsFormUI.MaxLength;

                sqlCmd.Parameters.Add("@Length", SqlDbType.Int);
                sqlCmd.Parameters["@Length"].Value = gLAccountFormatDetailsFormUI.Length;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddGLAccountFormatDetails()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatDetailsFormDAL : AddGLAccountFormatDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccountFormatDetails(GLAccountFormatDetailsFormUI gLAccountFormatDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormatDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountFormatDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountFormatDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountFormatDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountFormatDetailsId"].Value = gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId;

                sqlCmd.Parameters.Add("@tbl_GLAccountFormatId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountFormatId"].Value = gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatId;

                sqlCmd.Parameters.Add("@SequenceNumber", SqlDbType.Int);
                sqlCmd.Parameters["@SequenceNumber"].Value = gLAccountFormatDetailsFormUI.SequenceNumber;

                sqlCmd.Parameters.Add("@SegmentNumber", SqlDbType.Int);
                sqlCmd.Parameters["@SegmentNumber"].Value = gLAccountFormatDetailsFormUI.SegmentNumber;

                sqlCmd.Parameters.Add("@SegmentName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SegmentName"].Value = gLAccountFormatDetailsFormUI.SegmentName;

                sqlCmd.Parameters.Add("@MaxLength", SqlDbType.Int);
                sqlCmd.Parameters["@MaxLength"].Value = gLAccountFormatDetailsFormUI.MaxLength;

                sqlCmd.Parameters.Add("@Length", SqlDbType.Int);
                sqlCmd.Parameters["@Length"].Value = gLAccountFormatDetailsFormUI.Length;

                sqlCmd.Parameters.Add("@IsActive", SqlDbType.Bit);
                sqlCmd.Parameters["@IsActive"].Value = gLAccountFormatDetailsFormUI.IsActive;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountFormatDetails()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetailsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatDetailsFormDAL : UpdateGLAccountFormatDetails] An error occured in the processing of Record Id : " + gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccountFormatDetailsSegmentLenght(GLAccountFormatDetailsFormUI gLAccountFormatDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormatDetails_UpdateSegmentLenght", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountFormatDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountFormatDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GLAccountFormatDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountFormatDetailsId"].Value = gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId;              

                sqlCmd.Parameters.Add("@Length", SqlDbType.Int);
                sqlCmd.Parameters["@Length"].Value = gLAccountFormatDetailsFormUI.Length;

                sqlCmd.Parameters.Add("@IsActive", SqlDbType.Bit);
                sqlCmd.Parameters["@IsActive"].Value = gLAccountFormatDetailsFormUI.IsActive;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountFormatDetailsSegmentLenght()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetailsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatDetailsFormDAL : UpdateGLAccountFormatDetailsSegmentLenght] An error occured in the processing of Record Id : " + gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }


    

    public int DeleteGLAccountFormatDetails(GLAccountFormatDetailsFormUI gLAccountFormatDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormatDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountFormatDetialsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountFormatDetialsId"].Value = gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountFormatDetails()";
            logExcpUIobj.ResourceName = "GLAccountFormatDetailsFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatDetailsFormDAL : DeleteGLAccountFormatDetails] An error occured in the processing of Record Id : " + gLAccountFormatDetailsFormUI.Tbl_GLAccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }


}