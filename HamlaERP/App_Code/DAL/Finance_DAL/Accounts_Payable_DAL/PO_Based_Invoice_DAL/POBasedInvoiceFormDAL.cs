using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for POBasedInvoiceFormDAL
/// </summary>
public class POBasedInvoiceFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
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

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = pOBasedInvoiceFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = pOBasedInvoiceFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = pOBasedInvoiceFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = pOBasedInvoiceFormUI.PostingDate;           

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

                sqlCmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TotalAmount"].Value = pOBasedInvoiceFormUI.TotalAmount;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
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

                sqlCmd.Parameters.Add("@Tbl_POBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_POBasedInvoiceId"].Value = pOBasedInvoiceFormUI.Tbl_POBasedInvoiceId;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = pOBasedInvoiceFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = pOBasedInvoiceFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@ReceiptNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ReceiptNumber"].Value = pOBasedInvoiceFormUI.ReceiptNumber;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = pOBasedInvoiceFormUI.PostingDate;

                //sqlCmd.Parameters.Add("@PostingDate_Hijri", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@PostingDate_Hijri"].Value = pOBasedInvoiceFormUI.PostingDate_Hijri;

                sqlCmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceDate"].Value = pOBasedInvoiceFormUI.InvoiceDate;

                //sqlCmd.Parameters.Add("@InvoiceDate_Hijri", SqlDbType.NVarChar);
                //sqlCmd.Parameters["@InvoiceDate_Hijri"].Value = pOBasedInvoiceFormUI.InvoiceDate_Hijri;

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

                sqlCmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TotalAmount"].Value = pOBasedInvoiceFormUI.TotalAmount;

                result = sqlCmd.ExecuteNonQuery();

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
}