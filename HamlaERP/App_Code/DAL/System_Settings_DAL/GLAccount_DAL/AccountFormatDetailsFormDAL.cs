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
/// Summary description for AccountFormatDetailsFormDAL
/// </summary>
public class AccountFormatDetailsFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public AccountFormatDetailsFormDAL()
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
            logExcpUIobj.MethodName = "AccountFormatDetialsFormDAL()";
            logExcpUIobj.ResourceName = "AccountFormatDetialsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[AccountFormatDetialsFormDAL : AccountFormatDetialsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetAccountFormatDetailsListById(AccountFormatDetailsFormUI accountFormatDetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AccountFormatDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AccountFormatDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AccountFormatDetailsId"].Value = accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;

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
                audit_IUD.WebServiceSelectInsert("tbl_AccountFormatDetials", accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getAccountFormatDetialsListById()";
            logExcpUIobj.ResourceName = "AccountFormatDetailsFormDAL.CS";
            logExcpUIobj.RecordId = accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AccountFormatDetailsFormDAL : getAccountFormatDetialsListById] An error occured in the processing of Record Id : " + accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetAccountFormatDetailsListForExportToExcel()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        //Boolean result = false;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_AccountFormatDetails_SelectExportToExcel", SupportCon);
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
            logExcpUIobj.MethodName = "GetAccountFormatDetailsListForExportToExcel()";
            logExcpUIobj.ResourceName = "AccountFormatDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AccountFormatDetailsFormDAL : GetAccountFormatDetailsListForExportToExcel] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddAccountFormatDetails(AccountFormatDetailsFormUI accountFormatDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AccountFormatDetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = accountFormatDetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = accountFormatDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AccountFormatId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AccountFormatId"].Value = accountFormatDetailsFormUI.Tbl_AccountFormatId;

                sqlCmd.Parameters.Add("@SequenceNumber", SqlDbType.TinyInt);
                sqlCmd.Parameters["@SequenceNumber"].Value = accountFormatDetailsFormUI.SequenceNumber;

                sqlCmd.Parameters.Add("@SegmentNumber", SqlDbType.Int);
                sqlCmd.Parameters["@SegmentNumber"].Value = accountFormatDetailsFormUI.SegmentNumber;

                sqlCmd.Parameters.Add("@SegmentName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SegmentName"].Value = accountFormatDetailsFormUI.SegmentName;

                sqlCmd.Parameters.Add("@MaxLength", SqlDbType.Int);
                sqlCmd.Parameters["@MaxLength"].Value = accountFormatDetailsFormUI.MaxLength;

                sqlCmd.Parameters.Add("@Length", SqlDbType.Int);
                sqlCmd.Parameters["@Length"].Value = accountFormatDetailsFormUI.Length;

                sqlCmd.Parameters.Add("@IsActive", SqlDbType.Bit);
                sqlCmd.Parameters["@IsActive"].Value = accountFormatDetailsFormUI.@IsActive;

                sqlCmd.Parameters.Add("@tbl_AccountFormatDetailsId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_AccountFormatDetailsId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_AccountFormatDetailsId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_AccountFormatDetails";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(accountFormatDetailsFormUI);
                    audit_IUD.WebServiceInsert(accountFormatDetailsFormUI.Tbl_OrganizationId, tableName, RecoredID, accountFormatDetailsFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddAccountFormatDetails()";
            logExcpUIobj.ResourceName = "AccountFormatDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AccountFormatDetailsFormDAL : AddAccountFormatDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAccountFormatDetails(AccountFormatDetailsFormUI accountFormatDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AccountFormatDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = accountFormatDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = accountFormatDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AccountFormatDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AccountFormatDetailsId"].Value = accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;

                sqlCmd.Parameters.Add("@tbl_AccountFormatId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AccountFormatId"].Value = accountFormatDetailsFormUI.Tbl_AccountFormatId;

                sqlCmd.Parameters.Add("@SequenceNumber", SqlDbType.Int);
                sqlCmd.Parameters["@SequenceNumber"].Value = accountFormatDetailsFormUI.SequenceNumber;

                sqlCmd.Parameters.Add("@SegmentNumber", SqlDbType.Int);
                sqlCmd.Parameters["@SegmentNumber"].Value = accountFormatDetailsFormUI.SegmentNumber;

                sqlCmd.Parameters.Add("@SegmentName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SegmentName"].Value = accountFormatDetailsFormUI.SegmentName;

                sqlCmd.Parameters.Add("@MaxLength", SqlDbType.Int);
                sqlCmd.Parameters["@MaxLength"].Value = accountFormatDetailsFormUI.MaxLength;

                sqlCmd.Parameters.Add("@Length", SqlDbType.Int);
                sqlCmd.Parameters["@Length"].Value = accountFormatDetailsFormUI.Length;

                sqlCmd.Parameters.Add("@IsActive", SqlDbType.Bit);
                sqlCmd.Parameters["@IsActive"].Value = accountFormatDetailsFormUI.IsActive;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(accountFormatDetailsFormUI);
                    audit_IUD.WebServiceUpdate(accountFormatDetailsFormUI.Tbl_OrganizationId, "tbl_AccountFormatDetials", accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId, accountFormatDetailsFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAccountFormatDetails()";
            logExcpUIobj.ResourceName = "AccountFormatDetailsFormDAL.CS";
            logExcpUIobj.RecordId = accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AccountFormatDetailsFormDAL : UpdateAccountFormatDetails] An error occured in the processing of Record Id : " + accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateAccountFormatDetailsSegmentLenght(AccountFormatDetailsFormUI accountFormatDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AccountFormatDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = accountFormatDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = accountFormatDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_AccountFormatId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AccountFormatId"].Value = accountFormatDetailsFormUI.Tbl_AccountFormatId;

                sqlCmd.Parameters.Add("@tbl_AccountFormatDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AccountFormatDetailsId"].Value = accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;

                sqlCmd.Parameters.Add("@SequenceNumber", SqlDbType.TinyInt);
                sqlCmd.Parameters["@SequenceNumber"].Value = accountFormatDetailsFormUI.SequenceNumber;

                sqlCmd.Parameters.Add("@SegmentNumber", SqlDbType.Int);
                sqlCmd.Parameters["@SegmentNumber"].Value = accountFormatDetailsFormUI.SegmentNumber;

                sqlCmd.Parameters.Add("@SegmentName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SegmentName"].Value = accountFormatDetailsFormUI.SegmentName;

                sqlCmd.Parameters.Add("@MaxLength", SqlDbType.Int);
                sqlCmd.Parameters["@MaxLength"].Value = accountFormatDetailsFormUI.MaxLength;

                sqlCmd.Parameters.Add("@Length", SqlDbType.Int);
                sqlCmd.Parameters["@Length"].Value = accountFormatDetailsFormUI.Length;

                sqlCmd.Parameters.Add("@IsActive", SqlDbType.Bit);
                sqlCmd.Parameters["@IsActive"].Value = accountFormatDetailsFormUI.IsActive;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateAccountFormatDetailsSegmentLenght()";
            logExcpUIobj.ResourceName = "AccountFormatDetailsFormDAL.CS";
            logExcpUIobj.RecordId = accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AccountFormatDetailsFormDAL : UpdateAccountFormatDetailsSegmentLenght] An error occured in the processing of Record Id : " + accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }


    

    public int DeleteAccountFormatDetails(AccountFormatDetailsFormUI accountFormatDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_AccountFormatDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_AccountFormatDetialsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_AccountFormatDetialsId"].Value = accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_AccountFormatDetials", accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteAccountFormatDetails()";
            logExcpUIobj.ResourceName = "AccountFormatDetailsFormDAL.CS";
            logExcpUIobj.RecordId = accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[AccountFormatDetailsFormDAL : DeleteAccountFormatDetails] An error occured in the processing of Record Id : " + accountFormatDetailsFormUI.Tbl_AccountFormatDetialsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }


}