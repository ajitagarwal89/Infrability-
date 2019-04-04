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
/// Summary description for GeneralJournalDetailsFormDAL
/// </summary>
public class GeneralJournalDetailsFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public GeneralJournalDetailsFormDAL()
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
            logExcpUIobj.MethodName = "GeneralJournalDetailsFormDAL()";
            logExcpUIobj.ResourceName = "GeneralJournalDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GeneralJournalDetailsFormDAL : GeneralJournalDetailsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetGeneralJournalListById(GeneralJournalFormUI generalJournalFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {

                SqlCommand sqlCmd = new SqlCommand("SP_GeneralJournalDetails_SelectByGeneralJournalId", SupportCon);
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
                audit_IUD.WebServiceSelectInsert("tbl_GeneralJournalDetails", generalJournalFormUI.Tbl_GeneralJournalId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetGeneralJournalDetailsListById()";
            logExcpUIobj.ResourceName = "GeneralJournalDetailsFormDAL.CS";
            logExcpUIobj.RecordId = generalJournalFormUI.Tbl_GeneralJournalId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GeneralJournalDetailsFormDAL : GetGeneralJournalDetailsListById] An error occured in the processing of Record Id : " + generalJournalFormUI.Tbl_GeneralJournalId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
    public DataTable GetGeneralJournalDetailsListById(GeneralJournalDetailsFormUI generalJournalDetailsFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {

                SqlCommand sqlCmd = new SqlCommand("SP_GeneralJournalDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GeneralJournalDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GeneralJournalDetailsId"].Value = generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId;

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
                audit_IUD.WebServiceSelectInsert("tbl_GeneralJournalDetails", generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetGeneralJournalDetailsListById()";
            logExcpUIobj.ResourceName = "GeneralJournalDetailsFormDAL.CS";
            logExcpUIobj.RecordId = generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GeneralJournalDetailsFormDAL : GetGeneralJournalDetailsListById] An error occured in the processing of Record Id : " + generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGeneralJournalDetails(GeneralJournalDetailsFormUI generalJournalDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GeneralJournalDetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = generalJournalDetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = generalJournalDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GeneralJournalId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GeneralJournalId"].Value = generalJournalDetailsFormUI.Tbl_GeneralJournalId;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = generalJournalDetailsFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Debit"].Value = generalJournalDetailsFormUI.Debit;

                sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
                sqlCmd.Parameters["@Credit"].Value = generalJournalDetailsFormUI.Credit;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = generalJournalDetailsFormUI.Description;

                sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DistributionReference"].Value = generalJournalDetailsFormUI.DistributionReference;

                sqlCmd.Parameters.Add("@tbl_OrganizationId_Company", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId_Company"].Value = generalJournalDetailsFormUI.Tbl_OrganizationId_Company;

                sqlCmd.Parameters.Add("@TotalDebit", SqlDbType.Decimal);
                sqlCmd.Parameters["@TotalDebit"].Value = generalJournalDetailsFormUI.TotalDebit;

                sqlCmd.Parameters.Add("@TotalCredit", SqlDbType.Decimal);
                sqlCmd.Parameters["@TotalCredit"].Value = generalJournalDetailsFormUI.TotalCredit;

                sqlCmd.Parameters.Add("@Difference", SqlDbType.Decimal);
                sqlCmd.Parameters["@Difference"].Value = generalJournalDetailsFormUI.Difference;
        
                sqlCmd.Parameters.Add("@tbl_GeneralJournalDetailsId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_GeneralJournalDetailsId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_GeneralJournalDetailsId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_GeneralJournalDetails";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(generalJournalDetailsFormUI);
                    audit_IUD.WebServiceInsert(generalJournalDetailsFormUI.Tbl_OrganizationId, tableName, RecoredID, generalJournalDetailsFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddGeneralJournalDetails()";
            logExcpUIobj.ResourceName = "GeneralJournalDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GeneralJournalDetailsFormDAL : AddGeneralJournalDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGeneralJournalDetails(GeneralJournalDetailsFormUI generalJournalDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GeneralJournalDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = generalJournalDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_GeneralJournalDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GeneralJournalDetailsId"].Value = generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = generalJournalDetailsFormUI.Tbl_OrganizationId;

        sqlCmd.Parameters.Add("@tbl_GeneralJournalId", SqlDbType.NVarChar);
        sqlCmd.Parameters["@tbl_GeneralJournalId"].Value = generalJournalDetailsFormUI.Tbl_GeneralJournalId;

        sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
        sqlCmd.Parameters["@tbl_GLAccountId"].Value = generalJournalDetailsFormUI.Tbl_GLAccountId;

        sqlCmd.Parameters.Add("@Debit", SqlDbType.Decimal);
        sqlCmd.Parameters["@Debit"].Value = generalJournalDetailsFormUI.Debit;

        sqlCmd.Parameters.Add("@Credit", SqlDbType.Decimal);
        sqlCmd.Parameters["@Credit"].Value = generalJournalDetailsFormUI.Credit;

        sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
        sqlCmd.Parameters["@Description"].Value = generalJournalDetailsFormUI.Description;

        sqlCmd.Parameters.Add("@DistributionReference", SqlDbType.NVarChar);
        sqlCmd.Parameters["@DistributionReference"].Value = generalJournalDetailsFormUI.DistributionReference;

        sqlCmd.Parameters.Add("@tbl_OrganizationId_Company", SqlDbType.NVarChar);
        sqlCmd.Parameters["@tbl_OrganizationId_Company"].Value = generalJournalDetailsFormUI.Tbl_OrganizationId_Company;

        sqlCmd.Parameters.Add("@TotalDebit", SqlDbType.Decimal);
        sqlCmd.Parameters["@TotalDebit"].Value = generalJournalDetailsFormUI.TotalDebit;

        sqlCmd.Parameters.Add("@TotalCredit", SqlDbType.Decimal);
        sqlCmd.Parameters["@TotalCredit"].Value = generalJournalDetailsFormUI.TotalCredit;

        sqlCmd.Parameters.Add("@Difference", SqlDbType.Decimal);
        sqlCmd.Parameters["@Difference"].Value = generalJournalDetailsFormUI.Difference;

        result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(generalJournalDetailsFormUI);
                    audit_IUD.WebServiceUpdate(generalJournalDetailsFormUI.Tbl_OrganizationId, "tbl_GeneralJournalDetails", generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId, generalJournalDetailsFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGeneralJournalDetails()";
            logExcpUIobj.RecordId = generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GeneralJournalDetailsFormDAL : UpdateGeneralJournalDetails] An error occured in the processing of Record Id : " + generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGeneralJournalDetails(GeneralJournalDetailsFormUI generalJournalDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GeneralJournalDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GeneralJournalDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GeneralJournalDetailsId"].Value = generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_GeneralJournalDetails", generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGeneralJournalDetails()";
            logExcpUIobj.ResourceName = "GeneralJournalFormDAL.CS";
            logExcpUIobj.RecordId = generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GeneralJournalFormDAL : DeleteGeneralJournalDetails] An error occured in the processing of Record Id : " + generalJournalDetailsFormUI.Tbl_GeneralJournalDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}