using System;
using System.Data.SqlClient;
using System.Data;
using log4net;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.SessionState;
using System.Web;
using Finware;

/// <summary>
/// Summary description for AccountFormatFormDAL
/// </summary>
public class AccountFormatFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public AccountFormatFormDAL()
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
            logExcpUIobj.MethodName = "AccountFormatFormDAL()";
            logExcpUIobj.ResourceName = "AccountFormatFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AccountFormatFormDAL : AccountFormatFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAccountFormatListById(AccountFormatFormUI accountFormatFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AccountFormat_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AccountFormatId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AccountFormatId"].Value = accountFormatFormUI.Tbl_AccountFormatId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl = ds.Tables[0];
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_AccountFormat", accountFormatFormUI.Tbl_AccountFormatId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetAccountFormatListById()";
            logExcpUIobj.ResourceName = "AccountFormatFormDAL.CS";
            logExcpUIobj.RecordId = accountFormatFormUI.Tbl_AccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AccountFormatFormDAL : GetAccountFormatListById] An error occured in the processing of Record Id : " + accountFormatFormUI.Tbl_AccountFormatId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }   

    public int AddAccountFormat(AccountFormatFormUI accountFormatFormUI)
    {

        int result = 0;
        string results = string.Empty;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AccountFormat_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = accountFormatFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = accountFormatFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@MaximumAccountLength", SqlDbType.Int);
                sqlCmd.Parameters["@MaximumAccountLength"].Value = accountFormatFormUI.MaximumAccountLength;

                sqlCmd.Parameters.Add("@AccountLength", SqlDbType.Int);
                sqlCmd.Parameters["@AccountLength"].Value = accountFormatFormUI.AccountLength;

                sqlCmd.Parameters.Add("@MaximumSegment", SqlDbType.Int);
                sqlCmd.Parameters["@MaximumSegment"].Value = accountFormatFormUI.MaximumSegment;

                sqlCmd.Parameters.Add("@Segment", SqlDbType.Int);
                sqlCmd.Parameters["@Segment"].Value = accountFormatFormUI.Segment;

                sqlCmd.Parameters.Add("@MainSegment", SqlDbType.Int);
                sqlCmd.Parameters["@MainSegment"].Value = accountFormatFormUI.MainSegmentGuid;

                sqlCmd.Parameters.Add("@SeparatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SeparatedBy"].Value = accountFormatFormUI.SeparatedBy;

                sqlCmd.Parameters.Add("@tbl_AccountFormatId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_AccountFormatId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_AccountFormatId"].Value);
                HttpContext.Current.Session["AccountFormatId"] = RecoredID;
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_AccountFormat";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(accountFormatFormUI);
                    audit_IUD.WebServiceInsert(accountFormatFormUI.Tbl_OrganizationId, tableName, RecoredID, accountFormatFormUI.CreatedBy, newValue);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AccountFormatFormDAL()";
            logExcpUIobj.ResourceName = "AccountFormatFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AccountFormatFormDAL : AddAccountFormat] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAccountFormat(AccountFormatFormUI accountFormatFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AccountFormat_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AccountFormatId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AccountFormatId"].Value = accountFormatFormUI.Tbl_AccountFormatId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = accountFormatFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = accountFormatFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@MaximumAccountLength", SqlDbType.Int);
                sqlCmd.Parameters["@MaximumAccountLength"].Value = accountFormatFormUI.MaximumAccountLength;

                sqlCmd.Parameters.Add("@AccountLength", SqlDbType.Int);
                sqlCmd.Parameters["@AccountLength"].Value = accountFormatFormUI.AccountLength;

                sqlCmd.Parameters.Add("@MaximumSegment", SqlDbType.Int);
                sqlCmd.Parameters["@MaximumSegment"].Value = accountFormatFormUI.MaximumSegment;

                sqlCmd.Parameters.Add("@Segment", SqlDbType.Int);
                sqlCmd.Parameters["@Segment"].Value = accountFormatFormUI.Segment;

                sqlCmd.Parameters.Add("@MainSegment", SqlDbType.Int);
                sqlCmd.Parameters["@MainSegment"].Value = accountFormatFormUI.MainSegment;

                sqlCmd.Parameters.Add("@SeparatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SeparatedBy"].Value = accountFormatFormUI.SeparatedBy;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(accountFormatFormUI);
                    audit_IUD.WebServiceUpdate(accountFormatFormUI.Tbl_OrganizationId, "tbl_AccountFormat", accountFormatFormUI.Tbl_AccountFormatId, accountFormatFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAccountFormat()";
            logExcpUIobj.ResourceName = "AccountFormatFormDAL.CS";
            logExcpUIobj.RecordId = accountFormatFormUI.Tbl_AccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AccountFormatFormDAL : UpdateAccountFormat] An error occured in the processing of Record Id : " + accountFormatFormUI.Tbl_AccountFormatId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteAccountFormat(AccountFormatFormUI accountFormatFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AccountFormat_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AccountFormatId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AccountFormatId"].Value = accountFormatFormUI.Tbl_AccountFormatId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_AccountFormat", accountFormatFormUI.Tbl_AccountFormatId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAccountFormat()";
            logExcpUIobj.ResourceName = "AccountFormatFormDAL.CS";
            logExcpUIobj.RecordId = accountFormatFormUI.Tbl_AccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AccountFormatFormDAL : DeleteAccountFormat] An error occured in the processing of Record Id : " + accountFormatFormUI.Tbl_AccountFormatId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int AccountFormatDetails_DeleteByAccountFormatId(AccountFormatFormUI accountFormatFormUI)
    {
        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AccountFormatDetails_DeleteByAccountFormatId", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AccountFormatId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AccountFormatId"].Value = accountFormatFormUI.Tbl_AccountFormatId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_AccountFormat", accountFormatFormUI.Tbl_AccountFormatId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAccountFormat()";
            logExcpUIobj.ResourceName = "AccountFormatFormDAL.CS";
            logExcpUIobj.RecordId = accountFormatFormUI.Tbl_AccountFormatId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AccountFormatFormDAL : AccountFormateDetailsDelete] An error occured in the processing of Record Id : " + accountFormatFormUI.Tbl_AccountFormatId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetAccountFormatFormSelectByAccountFormatId(AccountFormatFormUI accountFormatFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_AccountFormatDetails_SelectByAccountFormatId]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@MainSegment", SqlDbType.NVarChar);
                sqlCmd.Parameters["@MainSegment"].Value = accountFormatFormUI.MainSegmentGuid;

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
            logExcpUIobj.MethodName = "GetAccountFormatFormSelectByAccountFormatId()";
            logExcpUIobj.ResourceName = "AccountFormatFormDAL.CS";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AccountFormatFormDAL : GetAccountFormatFormSelectByAccountFormatId] An error occured in the processing of Record Search = " + accountFormatFormUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetAccountFormatDetails_SelectBySegmentLenght(AccountFormatFormUI accountFormatFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[dbo].[SP_AccountFormatDetails_SelectBySegment]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@Segment", SqlDbType.Int);
                sqlCmd.Parameters["@Segment"].Value = accountFormatFormUI.Segment;

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
            logExcpUIobj.MethodName = "GetAccountFormatDetails_SelectBySegmentLenght()";
            logExcpUIobj.ResourceName = "AccountFormatFormDAL.CS";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AccountFormatFormDAL : GetAccountFormatDetails_SelectBySegmentLenght] An error occured in the processing of Record Search = " + accountFormatFormUI.Search + " . Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }

}