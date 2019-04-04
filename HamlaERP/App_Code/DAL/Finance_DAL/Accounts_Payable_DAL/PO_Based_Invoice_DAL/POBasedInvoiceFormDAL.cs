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
/// Summary description for POBasedInvoiceFormDAL
/// </summary>
public class POBasedInvoiceFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public POBasedInvoiceFormDAL()
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
            logExcpUIobj.MethodName = "POBasedInvoiceFormDAL()";
            logExcpUIobj.ResourceName = "POBasedInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[POBasedInvoiceFormDAL : POBasedInvoiceFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetPOBasedInvoiceListById(POBasedInvoiceFormUI pOBasedInvoiceFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoice_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceId"].Value = pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId;

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
                audit_IUD.WebServiceSelectInsert("tbl_POBasedInvoice", pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getPOBasedInvoiceListById()";
            logExcpUIobj.ResourceName = "POBasedInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceFormDAL : getPOBasedInvoiceListById] An error occured in the processing of Record Id : " + pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetSerialNumber(POBasedInvoiceFormUI pOBasedInvoiceFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoice_SerialNumber", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;
                sqlCmd.Parameters.Add("@RecordType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@RecordType"].Value = pOBasedInvoiceFormUI.InvoiceType;

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
                audit_IUD.WebServiceSelectInsert("tbl_POBasedInvoice", pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetSerialNumber()";
            logExcpUIobj.ResourceName = "POBasedInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceFormDAL : GetSerialNumber] An error occured in the processing of Record Id : " + pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPOBasedInvoice(POBasedInvoiceFormUI pOBasedInvoiceFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoice_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = pOBasedInvoiceFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pOBasedInvoiceFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteId"].Value = pOBasedInvoiceFormUI.Tbl_GoodsReceivedNoteId;

                sqlCmd.Parameters.Add("@tbl_POId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POId"].Value = pOBasedInvoiceFormUI.Tbl_POId;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = pOBasedInvoiceFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = pOBasedInvoiceFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = pOBasedInvoiceFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@SupplierDocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SupplierDocumentNumber"].Value = pOBasedInvoiceFormUI.SupplierDocumentNumber;



                sqlCmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceDate"].Value = pOBasedInvoiceFormUI.InvoiceDate;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = pOBasedInvoiceFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = pOBasedInvoiceFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@SubTotalAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@SubTotalAmount"].Value = pOBasedInvoiceFormUI.SubTotalAmount;

                sqlCmd.Parameters.Add("@TradeDiscountAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscountAmount"].Value = pOBasedInvoiceFormUI.TradeDiscountAmount;

                sqlCmd.Parameters.Add("@FreightAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@FreightAmount"].Value = pOBasedInvoiceFormUI.FreightAmount;
                sqlCmd.Parameters.Add("@Miscellaneous", SqlDbType.Decimal);
                sqlCmd.Parameters["@Miscellaneous"].Value = pOBasedInvoiceFormUI.Miscellaneous;

                sqlCmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TotalAmount"].Value = pOBasedInvoiceFormUI.TotalAmount;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_POBasedInvoiceId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_POBasedInvoiceId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_POBasedInvoice";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(pOBasedInvoiceFormUI);
                    audit_IUD.WebServiceInsert(pOBasedInvoiceFormUI.Tbl_OrganizationId, tableName, recordID, pOBasedInvoiceFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddPOBasedInvoice()";
            logExcpUIobj.ResourceName = "POBasedInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceFormDAL : AddPOBasedInvoice] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePOBasedInvoice(POBasedInvoiceFormUI pOBasedInvoiceFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoice_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = pOBasedInvoiceFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pOBasedInvoiceFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceId"].Value = pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId;

                sqlCmd.Parameters.Add("@tbl_GoodsReceivedNoteId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GoodsReceivedNoteId"].Value = pOBasedInvoiceFormUI.Tbl_GoodsReceivedNoteId;

                sqlCmd.Parameters.Add("@tbl_POId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POId"].Value = pOBasedInvoiceFormUI.Tbl_POId;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = pOBasedInvoiceFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = pOBasedInvoiceFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = pOBasedInvoiceFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@SupplierDocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@SupplierDocumentNumber"].Value = pOBasedInvoiceFormUI.SupplierDocumentNumber;



                sqlCmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceDate"].Value = pOBasedInvoiceFormUI.InvoiceDate;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = pOBasedInvoiceFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_PaymentTermsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentTermsId"].Value = pOBasedInvoiceFormUI.Tbl_PaymentTermsId;

                sqlCmd.Parameters.Add("@SubTotalAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@SubTotalAmount"].Value = pOBasedInvoiceFormUI.SubTotalAmount;

                sqlCmd.Parameters.Add("@TradeDiscountAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscountAmount"].Value = pOBasedInvoiceFormUI.TradeDiscountAmount;

                sqlCmd.Parameters.Add("@FreightAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@FreightAmount"].Value = pOBasedInvoiceFormUI.FreightAmount;

                sqlCmd.Parameters.Add("@Miscellaneous", SqlDbType.Decimal);
                sqlCmd.Parameters["@Miscellaneous"].Value = pOBasedInvoiceFormUI.Miscellaneous;

                sqlCmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TotalAmount"].Value = pOBasedInvoiceFormUI.TotalAmount;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(pOBasedInvoiceFormUI);
                    audit_IUD.WebServiceUpdate(pOBasedInvoiceFormUI.Tbl_OrganizationId, "tbl_POBasedInvoice", pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId, pOBasedInvoiceFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePOBasedInvoice()";
            logExcpUIobj.ResourceName = "POBasedInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceFormDAL : UpdatePOBasedInvoice] An error occured in the processing of Record Id : " + pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePOBasedInvoice(POBasedInvoiceFormUI pOBasedInvoiceFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoice_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceId"].Value = pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_POBasedInvoice", pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePOBasedInvoice()";
            logExcpUIobj.ResourceName = "POBasedInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceFormDAL : DeletePOBasedInvoice] An error occured in the processing of Record Id : " + pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePostingPOBasedInvoice(POBasedInvoiceFormUI pOBasedInvoiceFormUI)
    {
        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoice_UpdatePosting", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceId"].Value = pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = pOBasedInvoiceFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pOBasedInvoiceFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = pOBasedInvoiceFormUI.IsPosted;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(pOBasedInvoiceFormUI);
                    audit_IUD.WebServiceUpdate(pOBasedInvoiceFormUI.Tbl_OrganizationId, "tbl_POBasedInvoice", pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId, pOBasedInvoiceFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();

            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePostingPOBasedInvoice()";
            logExcpUIobj.ResourceName = "POBasedInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[POBasedInvoiceFormDAL : UpdatePostingPOBasedInvoice] An error occured in the processing of Record Id : " + pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId + ". Details : [" + exp.ToString() + "]");
        }


        return result;

    }
}