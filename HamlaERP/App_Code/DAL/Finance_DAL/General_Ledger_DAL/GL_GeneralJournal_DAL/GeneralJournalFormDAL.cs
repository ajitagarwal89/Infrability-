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
/// Summary description for GeneralJournalFormDAL
/// </summary>
public class GeneralJournalFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public GeneralJournalFormDAL()
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
            logExcpUIobj.MethodName = "GeneralJournalFormDAL()";
            logExcpUIobj.ResourceName = "GeneralJournalFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GeneralJournalFormDAL : GeneralJournalFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public int UpdatePostingGeneralJournal(GeneralJournalFormUI generalJournalFormUI)
    {
        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GeneralJournal_UpdatePosting", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GeneralJournalId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GeneralJournalId"].Value = generalJournalFormUI.Tbl_GeneralJournalId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = generalJournalFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = generalJournalFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = generalJournalFormUI.IsPosted;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(generalJournalFormUI);
                    audit_IUD.WebServiceUpdate(generalJournalFormUI.Tbl_OrganizationId, "tbl_GeneralJournal", generalJournalFormUI.Tbl_GeneralJournalId, generalJournalFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();

            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePostingAssetPurchase()";
            logExcpUIobj.ResourceName = "GeneralJournalFormDAL.CS";
            logExcpUIobj.RecordId = generalJournalFormUI.Tbl_GeneralJournalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[GeneralJournalFormDAL : UpdatePostingAssetPurchase] An error occured in the processing of Record Id : " + generalJournalFormUI.Tbl_GeneralJournalId + ". Details : [" + exp.ToString() + "]");
        }


        return result;

    }
    public DataTable GetSerialNoGeneralJournal()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GeneralJournal_SerialNumber", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
                if (ds.Tables.Count > 0)
                    dtbl = ds.Tables[0];
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSerialNoGeneralJournal()";
            logExcpUIobj.ResourceName = "GeneralJournalFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GeneralJournalFormDAL : GetSerialNoGeneralJournal] An error occured in the processing of Record Id  Details : [" + exp.ToString() + "]");
        }
        return dtbl;

    }

    public DataTable GetGeneralJournalListById(GeneralJournalFormUI generalJournalFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GeneralJournal_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GeneralJournalId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GeneralJournalId"].Value = generalJournalFormUI.Tbl_GeneralJournalId;

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
                audit_IUD.WebServiceSelectInsert("tbl_GeneralJournal", generalJournalFormUI.Tbl_GeneralJournalId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetGeneralJournalListById()";
            logExcpUIobj.ResourceName = "GeneralJournalFormDAL.CS";
            logExcpUIobj.RecordId = generalJournalFormUI.Tbl_GeneralJournalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GeneralJournalFormDAL : GetGeneralJournalListById] An error occured in the processing of Record Id : " + generalJournalFormUI.Tbl_GeneralJournalId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGeneralJournal(GeneralJournalFormUI generalJournalFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GeneralJournal_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = generalJournalFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = generalJournalFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@JournalEntry", SqlDbType.NVarChar);
                sqlCmd.Parameters["@JournalEntry"].Value = generalJournalFormUI.JournalEntry;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = generalJournalFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@TransactionType", SqlDbType.Bit);
                sqlCmd.Parameters["@TransactionType"].Value = generalJournalFormUI.TransactionType;

                sqlCmd.Parameters.Add("@TransactionDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@TransactionDate"].Value = generalJournalFormUI.TransactionDate;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = generalJournalFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@Reference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Reference"].Value = generalJournalFormUI.Reference;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = generalJournalFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@Opt_GeneralJournalType", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Opt_GeneralJournalType"].Value = generalJournalFormUI.Opt_GeneralJournalType;

                sqlCmd.Parameters.Add("@tbl_GeneralJournalId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GeneralJournalId_Self"].Value = generalJournalFormUI.Tbl_GeneralJournalId_Self;              

                sqlCmd.Parameters.Add("@tbl_GeneralJournalId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_GeneralJournalId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_GeneralJournalId"].Value);
                HttpContext.Current.Session["GeneralJournalId"] = RecoredID;
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_GeneralJournal";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(generalJournalFormUI);
                    audit_IUD.WebServiceInsert(generalJournalFormUI.Tbl_OrganizationId, tableName, RecoredID, generalJournalFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddGeneralJournal()";
            logExcpUIobj.ResourceName = "GeneralJournalFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GeneralJournalFormDAL : AddGeneralJournal] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGeneralJournal(GeneralJournalFormUI generalJournalFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GeneralJournal_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = generalJournalFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_GeneralJournalId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GeneralJournalId"].Value = generalJournalFormUI.Tbl_GeneralJournalId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = generalJournalFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@JournalEntry", SqlDbType.NVarChar);
                sqlCmd.Parameters["@JournalEntry"].Value = generalJournalFormUI.JournalEntry;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = generalJournalFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@TransactionType", SqlDbType.Bit);
                sqlCmd.Parameters["@TransactionType"].Value = generalJournalFormUI.TransactionType;

                sqlCmd.Parameters.Add("@TransactionDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@TransactionDate"].Value = generalJournalFormUI.TransactionDate;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = generalJournalFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@Reference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Reference"].Value = generalJournalFormUI.Reference;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = generalJournalFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@Opt_GeneralJournalType", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Opt_GeneralJournalType"].Value = generalJournalFormUI.Opt_GeneralJournalType;

                sqlCmd.Parameters.Add("@tbl_GeneralJournalId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GeneralJournalId_Self"].Value = generalJournalFormUI.Tbl_GeneralJournalId_Self;

                              
                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(generalJournalFormUI);
                    audit_IUD.WebServiceUpdate(generalJournalFormUI.Tbl_OrganizationId, "tbl_GeneralJournal", generalJournalFormUI.Tbl_GeneralJournalId, generalJournalFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGeneralJournal()";
            logExcpUIobj.ResourceName = "GeneralJournalFormDAL.CS";
            logExcpUIobj.RecordId = generalJournalFormUI.Tbl_GeneralJournalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GeneralJournalFormDAL : UpdateGeneralJournal] An error occured in the processing of Record Id : " + generalJournalFormUI.Tbl_GeneralJournalId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGeneralJournal(GeneralJournalFormUI generalJournalFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GeneralJournal_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GeneralJournalId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GeneralJournalId"].Value = generalJournalFormUI.Tbl_GeneralJournalId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_GeneralJournal", generalJournalFormUI.Tbl_GeneralJournalId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGeneralJournal()";
            logExcpUIobj.ResourceName = "GeneralJournalFormDAL.CS";
            logExcpUIobj.RecordId = generalJournalFormUI.Tbl_GeneralJournalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GeneralJournalFormDAL : DeleteGeneralJournal] An error occured in the processing of Record Id : " + generalJournalFormUI.Tbl_GeneralJournalId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}