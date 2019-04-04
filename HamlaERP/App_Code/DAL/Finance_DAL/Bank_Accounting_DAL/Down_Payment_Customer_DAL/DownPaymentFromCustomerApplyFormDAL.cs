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
/// Summary description for DownPaymentFromCustomerApplyForm_DAL
/// </summary>
public class DownPaymentFromCustomerApplyFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public DownPaymentFromCustomerApplyFormDAL()
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
            logExcpUIobj.MethodName = "DownPaymentFromCustomerApplyFormDAL()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerApplyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[DownPaymentFromCustomerApplyFormDAL : DownPaymentFromCustomerApplyFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetDownPaymentFromCustomerApplyListById(DownPaymentFromCustomerApplyFormUI downPaymentFromCustomerApplyFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerApply_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerApplyId"].Value = downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId;

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
                audit_IUD.WebServiceSelectInsert("tbl_DownPaymentFromCustomerApply", downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetDownPaymentFromCustomerApplyListById()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerApplyFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerApplyFormDAL : GetDownPaymentFromCustomerApplyListById] An error occured in the processing of Record Id : " + downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddDownPaymentFromCustomerApply(DownPaymentFromCustomerApplyFormUI downPaymentFromCustomerApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerApply_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = downPaymentFromCustomerApplyFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = downPaymentFromCustomerApplyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerId"].Value = downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerId;

                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = downPaymentFromCustomerApplyFormUI.opt_ApplyToDocumentType;

                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = downPaymentFromCustomerApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = downPaymentFromCustomerApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = downPaymentFromCustomerApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = downPaymentFromCustomerApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = downPaymentFromCustomerApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = downPaymentFromCustomerApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = downPaymentFromCustomerApplyFormUI.DiscountDate;

                sqlCmd.Parameters.Add("@tbl_CurrencyId_ApplyToCurrency", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId_ApplyToCurrency"].Value = downPaymentFromCustomerApplyFormUI.Tbl_CurrencyId_ApplyToCurrency;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerApplyId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerApplyId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_DownPaymentFromCustomerApplyId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_DownPaymentFromCustomerApply";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(downPaymentFromCustomerApplyFormUI);
                    audit_IUD.WebServiceInsert(downPaymentFromCustomerApplyFormUI.Tbl_OrganizationId, tableName, RecoredID, downPaymentFromCustomerApplyFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddDownPaymentFromCustomerApply()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerApplyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerApplyFormDAL : AddDownPaymentFromCustomerApply] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdateDownPaymentFromCustomerApply(DownPaymentFromCustomerApplyFormUI downPaymentFromCustomerApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerApply_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = downPaymentFromCustomerApplyFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = downPaymentFromCustomerApplyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerApplyId"].Value = downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerId"].Value = downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerId;

                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = downPaymentFromCustomerApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = downPaymentFromCustomerApplyFormUI.opt_ApplyToDocumentType;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = downPaymentFromCustomerApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = downPaymentFromCustomerApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = downPaymentFromCustomerApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = downPaymentFromCustomerApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = downPaymentFromCustomerApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = downPaymentFromCustomerApplyFormUI.DiscountDate;

                sqlCmd.Parameters.Add("@tbl_CurrencyId_ApplyToCurrency", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId_ApplyToCurrency"].Value = downPaymentFromCustomerApplyFormUI.Tbl_CurrencyId_ApplyToCurrency;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(downPaymentFromCustomerApplyFormUI);
                    audit_IUD.WebServiceUpdate(downPaymentFromCustomerApplyFormUI.Tbl_OrganizationId, "tbl_DownPaymentFromCustomerApply", downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId, downPaymentFromCustomerApplyFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateDownPaymentFromCustomerApply()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerApplyFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerApplyFormDAL : UpdateDownPaymentFromCustomerApply] An error occured in the processing of Record Id : " + downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int DeleteDownPaymentFromCustomerApply(DownPaymentFromCustomerApplyFormUI downPaymentFromCustomerApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentFromCustomerApply_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentFromCustomerApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentFromCustomerApplyId"].Value = downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_DownPaymentFromCustomerApply", downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteDownPaymentFromCustomerApply()";
            logExcpUIobj.ResourceName = "DownPaymentFromCustomerApplyFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentFromCustomerApplyFormDAL : DeleteDownPaymentFromCustomerApply] An error occured in the processing of Record Id : " + downPaymentFromCustomerApplyFormUI.Tbl_DownPaymentFromCustomerApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}