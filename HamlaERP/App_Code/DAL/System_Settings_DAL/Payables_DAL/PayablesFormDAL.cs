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
/// Summary description for PayablesFormDAL
/// </summary>
public class PayablesFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PayablesFormDAL()
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
            logExcpUIobj.MethodName = "PayablesFormDAL()";
            logExcpUIobj.ResourceName = "PayablesFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PayablesFormDAL : PayablesFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetPayablesListById(PayablesFormUI payablesFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Payables_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PayablesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId"].Value = payablesFormUI.Tbl_PayablesId;

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
                audit_IUD.WebServiceSelectInsert("tbl_Payables", payablesFormUI.Tbl_PayablesId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getPayablesListById()";
            logExcpUIobj.ResourceName = "PayablesFormDAL.CS";
            logExcpUIobj.RecordId = payablesFormUI.Tbl_PayablesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayablesFormDAL : getPayablesListById] An error occured in the processing of Record Id : " + payablesFormUI.Tbl_PayablesId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPayables(PayablesFormUI payablesFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Payables_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = payablesFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = payablesFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Opt_PayablesType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_PayablesType"].Value = payablesFormUI.Opt_PayablesType;

                sqlCmd.Parameters.Add("@Opt_ProcessType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_ProcessType"].Value = payablesFormUI.Opt_ProcessType;

                sqlCmd.Parameters.Add("@tbl_Bank_AccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Bank_AccountId"].Value = payablesFormUI.Tbl_Bank_AccountId;

                sqlCmd.Parameters.Add("@tbl_CardId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CardId"].Value = payablesFormUI.Tbl_CardId;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = payablesFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = payablesFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@ChequeNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ChequeNumber"].Value = payablesFormUI.ChequeNumber;

                sqlCmd.Parameters.Add("@PayablesDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PayablesDate"].Value = payablesFormUI.PayablesDate;                

                sqlCmd.Parameters.Add("@PaymentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentNumber"].Value = payablesFormUI.PaymentNumber;

                sqlCmd.Parameters.Add("@tbl_PayablesId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_PayablesId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_PayablesId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_Payables";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(payablesFormUI);
                    audit_IUD.WebServiceInsert(payablesFormUI.Tbl_OrganizationId, tableName, RecoredID, payablesFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddPayables()";
            logExcpUIobj.ResourceName = "PayablesFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayablesFormDAL : AddPayables] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePayables(PayablesFormUI payablesFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Payables_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = payablesFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = payablesFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PayablesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId"].Value = payablesFormUI.Tbl_PayablesId;


                sqlCmd.Parameters.Add("@Opt_PayablesType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_PayablesType"].Value = payablesFormUI.Opt_PayablesType;

                sqlCmd.Parameters.Add("@Opt_ProcessType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_ProcessType"].Value = payablesFormUI.Opt_ProcessType;

                sqlCmd.Parameters.Add("@tbl_Bank_AccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_Bank_AccountId"].Value = payablesFormUI.Tbl_Bank_AccountId;

                sqlCmd.Parameters.Add("@tbl_CardId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CardId"].Value = payablesFormUI.Tbl_CardId;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = payablesFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = payablesFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@ChequeNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ChequeNumber"].Value = payablesFormUI.ChequeNumber;

                sqlCmd.Parameters.Add("@PayablesDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PayablesDate"].Value = payablesFormUI.PayablesDate;               

                sqlCmd.Parameters.Add("@PaymentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentNumber"].Value = payablesFormUI.PaymentNumber;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(payablesFormUI);
                    audit_IUD.WebServiceUpdate(payablesFormUI.Tbl_OrganizationId, "tbl_Payables", payablesFormUI.Tbl_PayablesId, payablesFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePayables()";
            logExcpUIobj.ResourceName = "PayablesFormDAL.CS";
            logExcpUIobj.RecordId = payablesFormUI.Tbl_PayablesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayablesFormDAL : UpdatePayables] An error occured in the processing of Record Id : " + payablesFormUI.Tbl_PayablesId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePayables(PayablesFormUI payablesFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Payables_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PayablesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId"].Value = payablesFormUI.Tbl_PayablesId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_Payables", payablesFormUI.Tbl_PayablesId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePayables()";
            logExcpUIobj.ResourceName = "PayablesFormDAL.CS";
            logExcpUIobj.RecordId = payablesFormUI.Tbl_PayablesId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayablesFormDAL : DeletePayables] An error occured in the processing of Record Id : " + payablesFormUI.Tbl_PayablesId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}