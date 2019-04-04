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
/// Summary description for ReceivableSetupGroupFormDAL
/// </summary>
public class ReceivableSetupGroupFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public ReceivableSetupGroupFormDAL()
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
            logExcpUIobj.MethodName = "ReceivableSetupGroupFormDAL()";
            logExcpUIobj.ResourceName = "ReceivableSetupGroupFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[ReceivableSetupGroupFormDAL : ReceivableSetupGroupFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }


    public DataTable GetReceivableSetupGroupListById(ReceivableSetupGroupFormUI receivableSetupGroupFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupGroup_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupGroupId"].Value = receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId;

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
                audit_IUD.WebServiceSelectInsert("tbl_ReceivableSetupGroup", receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetRecievableSetupGroupListById()";
            logExcpUIobj.ResourceName = "ReceivableSetupGroupFormUI.CS";
            logExcpUIobj.RecordId = receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupGroupFormUI : GetRecievableSetupGroupListById] An error occured in the processing of Record Id : " + receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddReceivableSetupGroup(ReceivableSetupGroupFormUI receivableSetupGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupGroup_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = receivableSetupGroupFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = receivableSetupGroupFormUI.Tbl_OrganizationId;


                sqlCmd.Parameters.Add("@tbl_ReceivableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupId"].Value = receivableSetupGroupFormUI.Tbl_ReceivableSetupId;


                sqlCmd.Parameters.Add("@tbl_ReceivableSetupGroupId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupGroupId_Self"].Value = receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId_Self;

                sqlCmd.Parameters.Add("@ISDefault", SqlDbType.Bit);
                sqlCmd.Parameters["@ISDefault"].Value = receivableSetupGroupFormUI.ISDefault;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = receivableSetupGroupFormUI.Description;

                sqlCmd.Parameters.Add("@ISBalanceType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@ISBalanceType"].Value = receivableSetupGroupFormUI.ISBalanceType;


                sqlCmd.Parameters.Add("@Opt_MinimumPayment", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_MinimumPayment"].Value = receivableSetupGroupFormUI.opt_MinimumPayment;

                sqlCmd.Parameters.Add("@MinimumPayment", SqlDbType.Decimal);
                sqlCmd.Parameters["@MinimumPayment"].Value = receivableSetupGroupFormUI.MinimumPayment;


                sqlCmd.Parameters.Add("@Opt_CreditLimit", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_CreditLimit"].Value = receivableSetupGroupFormUI.opt_CreditLimit;

                sqlCmd.Parameters.Add("@CreditLimit", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditLimit"].Value = receivableSetupGroupFormUI.CreditLimit;


                sqlCmd.Parameters.Add("@Opt_WriteOff", SqlDbType.Decimal);
                sqlCmd.Parameters["@Opt_WriteOff"].Value = receivableSetupGroupFormUI.opt_WriteOff;

                sqlCmd.Parameters.Add("@WriteOff", SqlDbType.Decimal);
                sqlCmd.Parameters["@WriteOff"].Value = receivableSetupGroupFormUI.WriteOff;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = receivableSetupGroupFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = receivableSetupGroupFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@IsCalendar", SqlDbType.Bit);
                sqlCmd.Parameters["@IsCalendar"].Value = receivableSetupGroupFormUI.IsCalendar;

                sqlCmd.Parameters.Add("@IsFiscalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@IsFiscalYear"].Value = receivableSetupGroupFormUI.IsFiscalYear;

                sqlCmd.Parameters.Add("@IsTransaction", SqlDbType.Bit);
                sqlCmd.Parameters["@IsTransaction"].Value = receivableSetupGroupFormUI.IsTransaction;

                sqlCmd.Parameters.Add("@IsDistribution", SqlDbType.Bit);
                sqlCmd.Parameters["@IsDistribution"].Value = receivableSetupGroupFormUI.IsDistribution;

                sqlCmd.Parameters.Add("@Opt_StatementCycle", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_StatementCycle"].Value = receivableSetupGroupFormUI.Opt_StatementCycle;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupGroupId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_ReceivableSetupGroupId"].Direction = ParameterDirection.Output;
                result = sqlCmd.ExecuteNonQuery();
                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_ReceivableSetupGroupId"].Value);
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    string tableName = "tbl_ReceivableSetupGroup";
                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(receivableSetupGroupFormUI);
                    audit_IUD.WebServiceInsert(receivableSetupGroupFormUI.Tbl_OrganizationId, tableName, RecoredID, receivableSetupGroupFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddRecievableSetupGroup()";
            logExcpUIobj.ResourceName = "ReceivableSetupGroupFormUI.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupGroupFormUI : AddRecievableSetupGroup] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateReceivableSetupGroup(ReceivableSetupGroupFormUI receivableSetupGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupGroup_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = receivableSetupGroupFormUI.ModifiedBy;


                sqlCmd.Parameters.Add("@tbl_ReceivableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupGroupId"].Value = receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = receivableSetupGroupFormUI.Tbl_OrganizationId;


                sqlCmd.Parameters.Add("@tbl_ReceivableSetupGroupId_Self", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupGroupId_Self"].Value = receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId_Self;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupId"].Value = receivableSetupGroupFormUI.Tbl_ReceivableSetupId;

                sqlCmd.Parameters.Add("@ISDefault", SqlDbType.Bit);
                sqlCmd.Parameters["@ISDefault"].Value = receivableSetupGroupFormUI.ISDefault;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = receivableSetupGroupFormUI.Description;

                sqlCmd.Parameters.Add("@ISBalanceType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@ISBalanceType"].Value = receivableSetupGroupFormUI.ISBalanceType;

                sqlCmd.Parameters.Add("@Opt_MinimumPayment", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_MinimumPayment"].Value = receivableSetupGroupFormUI.opt_MinimumPayment;

                sqlCmd.Parameters.Add("@MinimumPayment", SqlDbType.Decimal);
                sqlCmd.Parameters["@MinimumPayment"].Value = receivableSetupGroupFormUI.MinimumPayment;


                sqlCmd.Parameters.Add("@Opt_CreditLimit", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_CreditLimit"].Value = receivableSetupGroupFormUI.opt_CreditLimit;


                sqlCmd.Parameters.Add("@CreditLimit", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditLimit"].Value = receivableSetupGroupFormUI.CreditLimit;

                sqlCmd.Parameters.Add("@Opt_WriteOff", SqlDbType.Decimal);
                sqlCmd.Parameters["@Opt_WriteOff"].Value = receivableSetupGroupFormUI.opt_WriteOff;

                sqlCmd.Parameters.Add("@WriteOff", SqlDbType.Decimal);
                sqlCmd.Parameters["@WriteOff"].Value = receivableSetupGroupFormUI.WriteOff;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = receivableSetupGroupFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = receivableSetupGroupFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@IsCalendar", SqlDbType.Bit);
                sqlCmd.Parameters["@IsCalendar"].Value = receivableSetupGroupFormUI.IsCalendar;

                sqlCmd.Parameters.Add("@IsFiscalYear", SqlDbType.Bit);
                sqlCmd.Parameters["@IsFiscalYear"].Value = receivableSetupGroupFormUI.IsFiscalYear;

                sqlCmd.Parameters.Add("@IsTransaction", SqlDbType.Bit);
                sqlCmd.Parameters["@IsTransaction"].Value = receivableSetupGroupFormUI.IsTransaction;

                sqlCmd.Parameters.Add("@IsDistribution", SqlDbType.Bit);
                sqlCmd.Parameters["@IsDistribution"].Value = receivableSetupGroupFormUI.IsDistribution;

                sqlCmd.Parameters.Add("@Opt_StatementCycle", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_StatementCycle"].Value = receivableSetupGroupFormUI.Opt_StatementCycle;



                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(receivableSetupGroupFormUI);
                    audit_IUD.WebServiceUpdate(receivableSetupGroupFormUI.Tbl_OrganizationId, "tbl_RecievableSetupGroup", receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId, receivableSetupGroupFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "ReceivableSetupGroupFormUI()";
            logExcpUIobj.ResourceName = "UpdateRecievableSetupGroup.CS";
            logExcpUIobj.RecordId = receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupGroupFormUI : UpdateRecievableSetupGroup] An error occured in the processing of Record Id : " + receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteReceivableSetupGroup(ReceivableSetupGroupFormUI receivableSetupGroupFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupGroup_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupGroupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupGroupId"].Value = receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_ReceivableSetupGroup", receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteRecievableSetupGroup()";
            logExcpUIobj.ResourceName = "ReceivableSetupGroupFormUI.CS";
            logExcpUIobj.RecordId = receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupGroupFormUI : DeleteBank] An error occured in the processing of Record Id : " + receivableSetupGroupFormUI.Tbl_ReceivableSetupGroupId+ ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}