using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for GLAccountFormatFormDAL
/// </summary>
public class GLAccountFormatFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public GLAccountFormatFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountFormatFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountFormatFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountFormatFormDAL : GLAccountFormatFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetGLAccountFormatListById(GLAccountFormatFormUI gLAccountFormatFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormat_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountFormatId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountFormatId"].Value = gLAccountFormatFormUI.Tbl_GLAccountFormatId;

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
            logExcpUIobj.MethodName = "getGLAccountFormatListById()";
            logExcpUIobj.ResourceName = "GLAccountFormatFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountFormatFormUI.Tbl_GLAccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatFormDAL : getGLAccountFormatListById] An error occured in the processing of Record Id : " + gLAccountFormatFormUI.Tbl_GLAccountFormatId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGLAccountFormat(GLAccountFormatFormUI gLAccountFormatFormUI)
    {

        int result = 0;
        string results = string.Empty;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormat_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountFormatFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountFormatFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@MaximumAccountLength", SqlDbType.Int);
                sqlCmd.Parameters["@MaximumAccountLength"].Value = gLAccountFormatFormUI.MaximumAccountLength;

                sqlCmd.Parameters.Add("@AccountLength", SqlDbType.Int);
                sqlCmd.Parameters["@AccountLength"].Value = gLAccountFormatFormUI.AccountLength;

                sqlCmd.Parameters.Add("@MaximumSegmentLength", SqlDbType.Int);
                sqlCmd.Parameters["@MaximumSegmentLength"].Value = gLAccountFormatFormUI.MaximumSegmentLength;

                sqlCmd.Parameters.Add("@SegmentLength", SqlDbType.Int);
                sqlCmd.Parameters["@SegmentLength"].Value = gLAccountFormatFormUI.SegmentLength;

                sqlCmd.Parameters.Add("@MainSegment", SqlDbType.Int);
                sqlCmd.Parameters["@MainSegment"].Value = gLAccountFormatFormUI.MainSegmentGuid;

                sqlCmd.Parameters.Add("@SeparatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SeparatedBy"].Value = gLAccountFormatFormUI.SeparatedBy;
                result = sqlCmd.ExecuteNonQuery();        
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GLAccountFormatFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountFormatFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatFormDAL : AddGLAccountFormat] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccountFormat(GLAccountFormatFormUI gLAccountFormatFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormat_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountFormatId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountFormatId"].Value = gLAccountFormatFormUI.Tbl_GLAccountFormatId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountFormatFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountFormatFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@MaximumAccountLength", SqlDbType.Int);
                sqlCmd.Parameters["@MaximumAccountLength"].Value = gLAccountFormatFormUI.MaximumAccountLength;

                sqlCmd.Parameters.Add("@AccountLength", SqlDbType.Int);
                sqlCmd.Parameters["@AccountLength"].Value = gLAccountFormatFormUI.AccountLength;

                sqlCmd.Parameters.Add("@MaximumSegmentLength", SqlDbType.Int);
                sqlCmd.Parameters["@MaximumSegmentLength"].Value = gLAccountFormatFormUI.MaximumSegmentLength;

                sqlCmd.Parameters.Add("@SegmentLength", SqlDbType.Int);
                sqlCmd.Parameters["@SegmentLength"].Value = gLAccountFormatFormUI.SegmentLength;

                sqlCmd.Parameters.Add("@MainSegment", SqlDbType.Int);
                sqlCmd.Parameters["@MainSegment"].Value = gLAccountFormatFormUI.MainSegment;

                sqlCmd.Parameters.Add("@SeparatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SeparatedBy"].Value = gLAccountFormatFormUI.SeparatedBy;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccountFormat()";
            logExcpUIobj.ResourceName = "GLAccountFormatFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountFormatFormUI.Tbl_GLAccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatFormDAL : UpdateGLAccountFormat] An error occured in the processing of Record Id : " + gLAccountFormatFormUI.Tbl_GLAccountFormatId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGLAccountFormat(GLAccountFormatFormUI gLAccountFormatFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccountFormat_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountFormatId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountFormatId"].Value = gLAccountFormatFormUI.Tbl_GLAccountFormatId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccountFormat()";
            logExcpUIobj.ResourceName = "GLAccountFormatFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountFormatFormUI.Tbl_GLAccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatFormDAL : DeleteGLAccountFormat] An error occured in the processing of Record Id : " + gLAccountFormatFormUI.Tbl_GLAccountFormatId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetGLAccountFormatFormSelectByGLAccountFormatId(GLAccountFormatFormUI gLAccountFormatFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_GLAccountFormatDetails_SelectByGLAccountFormatId]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@MainSegment", SqlDbType.NVarChar);
                sqlCmd.Parameters["@MainSegment"].Value = gLAccountFormatFormUI.MainSegmentGuid;

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
            logExcpUIobj.MethodName = "GetGLAccountFormatFormSelectByGLAccountFormatId()";
            logExcpUIobj.ResourceName = "GLAccountFormatFormDAL.CS";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatFormDAL : GetGLAccountFormatFormSelectByGLAccountFormatId] An error occured in the processing of Record Search = " + gLAccountFormatFormUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetGLAccountFormatDetails_SelectBySegmentLenght(GLAccountFormatFormUI gLAccountFormatFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_GLAccountFormatDetails_SelectBySegmentLenght]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@SegmentLenght", SqlDbType.Int);
                sqlCmd.Parameters["@SegmentLenght"].Value = gLAccountFormatFormUI.SegmentLength;

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
            logExcpUIobj.MethodName = "GetGLAccountFormatDetails_SelectBySegmentLenght()";
            logExcpUIobj.ResourceName = "GLAccountFormatFormDAL.CS";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormatFormDAL : GetGLAccountFormatDetails_SelectBySegmentLenght] An error occured in the processing of Record Search = " + gLAccountFormatFormUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }

}