using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for CustomerInvoiceFormDAL
/// </summary>
public class CustomerInvoiceFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public CustomerInvoiceFormDAL()
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
            logExcpUIobj.MethodName = "CustomerInvoiceFormDAL()";
            logExcpUIobj.ResourceName = "CustomerInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[CustomerInvoiceFormDAL : CustomerInvoiceFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetCustomerInvoiceListById(CustomerInvoiceFormUI customerInvoiceFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoice_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CustomerInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerInvoiceId"].Value = customerInvoiceFormUI.Tbl_CustomerInvoiceId;

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
            logExcpUIobj.MethodName = "getCustomerInvoiceListById()";
            logExcpUIobj.ResourceName = "CustomerInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = customerInvoiceFormUI.Tbl_CustomerInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerInvoiceFormDAL : getCustomerInvoiceListById] An error occured in the processing of Record Id : " + customerInvoiceFormUI.Tbl_CustomerInvoiceId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddCustomerInvoice(CustomerInvoiceFormUI customerInvoiceFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoice_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = customerInvoiceFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = customerInvoiceFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DocumentDate"].Value = customerInvoiceFormUI.DocumentDate;           

                sqlCmd.Parameters.Add("@Opt_InvoiceAndOrderType", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_InvoiceAndOrderType"].Value = customerInvoiceFormUI.Opt_InvoiceAndOrderType;

                sqlCmd.Parameters.Add("@tbl_InvoiceAndOrderTypeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_InvoiceAndOrderTypeId"].Value = customerInvoiceFormUI.Tbl_InvoiceAndOrderTypeId;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = customerInvoiceFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = customerInvoiceFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_CustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerId"].Value = customerInvoiceFormUI.Tbl_CustomerId;

                sqlCmd.Parameters.Add("@tbl_SitesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SitesId"].Value = customerInvoiceFormUI.Tbl_SitesId;

                sqlCmd.Parameters.Add("@CustomerPONumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CustomerPONumber"].Value = customerInvoiceFormUI.CustomerPONumber;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = customerInvoiceFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@AmountReceived", SqlDbType.Decimal);
                sqlCmd.Parameters["@AmountReceived"].Value = customerInvoiceFormUI.AmountReceived;

                sqlCmd.Parameters.Add("@OnAccount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OnAccount"].Value = customerInvoiceFormUI.OnAccount;

                sqlCmd.Parameters.Add("@SubTotalAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@SubTotalAmount"].Value = customerInvoiceFormUI.SubTotalAmount;

                sqlCmd.Parameters.Add("@TradeDiscountAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscountAmount"].Value = customerInvoiceFormUI.TradeDiscountAmount;

                sqlCmd.Parameters.Add("@FreightAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@FreightAmount"].Value = customerInvoiceFormUI.FreightAmount;

                sqlCmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TotalAmount"].Value = customerInvoiceFormUI.TotalAmount;

                sqlCmd.Parameters.Add("@Opt_DocumentStatus", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_DocumentStatus"].Value = customerInvoiceFormUI.Opt_DocumentStatus;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = customerInvoiceFormUI.PostingDate;

               

                sqlCmd.Parameters.Add("@QuoteDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@QuoteDate"].Value = customerInvoiceFormUI.QuoteDate;

              

                sqlCmd.Parameters.Add("@OrderDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@OrderDate"].Value = customerInvoiceFormUI.OrderDate;

               

                sqlCmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceDate"].Value = customerInvoiceFormUI.InvoiceDate;

             

                sqlCmd.Parameters.Add("@BackOrderDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@BackOrderDate"].Value = customerInvoiceFormUI.BackOrderDate;

            
                sqlCmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReturnDate"].Value = customerInvoiceFormUI.ReturnDate;

             
                sqlCmd.Parameters.Add("@RequestedShipDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@RequestedShipDate"].Value = customerInvoiceFormUI.RequestedShipDate;

            

                sqlCmd.Parameters.Add("@DateFulfilled", SqlDbType.DateTime);
                sqlCmd.Parameters["@DateFulfilled"].Value = customerInvoiceFormUI.DateFulfilled;

                sqlCmd.Parameters.Add("@ActualShipDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ActualShipDate"].Value = customerInvoiceFormUI.ActualShipDate;

              
                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddCustomerInvoice()";
            logExcpUIobj.ResourceName = "CustomerInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerInvoiceFormDAL : AddCustomerInvoice] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateCustomerInvoice(CustomerInvoiceFormUI customerInvoiceFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoice_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = customerInvoiceFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_CustomerInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerInvoiceId"].Value = customerInvoiceFormUI.Tbl_CustomerInvoiceId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = customerInvoiceFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@DocumentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DocumentDate"].Value = customerInvoiceFormUI.DocumentDate;

                //sqlCmd.Parameters.Add("@DocumentDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@DocumentDate_Hijri"].Value = customerInvoiceFormUI.DocumentDate_Hijri;

                sqlCmd.Parameters.Add("@Opt_InvoiceAndOrderType", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_InvoiceAndOrderType"].Value = customerInvoiceFormUI.Opt_InvoiceAndOrderType;

                sqlCmd.Parameters.Add("@tbl_InvoiceAndOrderTypeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_InvoiceAndOrderTypeId"].Value = customerInvoiceFormUI.Tbl_InvoiceAndOrderTypeId;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = customerInvoiceFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = customerInvoiceFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_CustomerId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerId"].Value = customerInvoiceFormUI.Tbl_CustomerId;

                sqlCmd.Parameters.Add("@tbl_SitesId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SitesId"].Value = customerInvoiceFormUI.Tbl_SitesId;

                sqlCmd.Parameters.Add("@CustomerPONumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CustomerPONumber"].Value = customerInvoiceFormUI.CustomerPONumber;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = customerInvoiceFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@AmountReceived", SqlDbType.Decimal);
                sqlCmd.Parameters["@AmountReceived"].Value = customerInvoiceFormUI.AmountReceived;

                sqlCmd.Parameters.Add("@OnAccount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OnAccount"].Value = customerInvoiceFormUI.OnAccount;

                sqlCmd.Parameters.Add("@SubTotalAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@SubTotalAmount"].Value = customerInvoiceFormUI.SubTotalAmount;

                sqlCmd.Parameters.Add("@TradeDiscountAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscountAmount"].Value = customerInvoiceFormUI.TradeDiscountAmount;

                sqlCmd.Parameters.Add("@FreightAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@FreightAmount"].Value = customerInvoiceFormUI.FreightAmount;

                sqlCmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TotalAmount"].Value = customerInvoiceFormUI.TotalAmount;

                sqlCmd.Parameters.Add("@Opt_DocumentStatus", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_DocumentStatus"].Value = customerInvoiceFormUI.Opt_DocumentStatus;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = customerInvoiceFormUI.PostingDate;

                //sqlCmd.Parameters.Add("@PostingDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@PostingDate_Hijri"].Value = customerInvoiceFormUI.PostingDate_Hijri;

                sqlCmd.Parameters.Add("@QuoteDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@QuoteDate"].Value = customerInvoiceFormUI.QuoteDate;

                //sqlCmd.Parameters.Add("@QuoteDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@QuoteDate_Hijri"].Value = customerInvoiceFormUI.QuoteDate_Hijri;

                sqlCmd.Parameters.Add("@OrderDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@OrderDate"].Value = customerInvoiceFormUI.OrderDate;

                //sqlCmd.Parameters.Add("@OrderDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@OrderDate_Hijri"].Value = customerInvoiceFormUI.OrderDate_Hijri;

                sqlCmd.Parameters.Add("@InvoiceDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@InvoiceDate"].Value = customerInvoiceFormUI.InvoiceDate;

                //sqlCmd.Parameters.Add("@InvoiceDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@InvoiceDate_Hijri"].Value = customerInvoiceFormUI.InvoiceDate_Hijri;

                sqlCmd.Parameters.Add("@BackOrderDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@BackOrderDate"].Value = customerInvoiceFormUI.BackOrderDate;

                //sqlCmd.Parameters.Add("@BackOrderDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@BackOrderDate_Hijri"].Value = customerInvoiceFormUI.BackOrderDate_Hijri;

                sqlCmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ReturnDate"].Value = customerInvoiceFormUI.ReturnDate;

                //sqlCmd.Parameters.Add("@ReturnDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@ReturnDate_Hijri"].Value = customerInvoiceFormUI.ReturnDate_Hijri;

                sqlCmd.Parameters.Add("@RequestedShipDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@RequestedShipDate"].Value = customerInvoiceFormUI.RequestedShipDate;

                //sqlCmd.Parameters.Add("@RequestedShipDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@RequestedShipDate_Hijri"].Value = customerInvoiceFormUI.RequestedShipDate_Hijri;

                sqlCmd.Parameters.Add("@DateFulfilled", SqlDbType.DateTime);
                sqlCmd.Parameters["@DateFulfilled"].Value = customerInvoiceFormUI.DateFulfilled;

                //sqlCmd.Parameters.Add("@DateFulfilled_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@DateFulfilled_Hijri"].Value = customerInvoiceFormUI.DateFulfilled_Hijri;

                sqlCmd.Parameters.Add("@ActualShipDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ActualShipDate"].Value = customerInvoiceFormUI.ActualShipDate;

                //sqlCmd.Parameters.Add("@ActualShipDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@ActualShipDate_Hijri"].Value = customerInvoiceFormUI.ActualShipDate_Hijri;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateCustomerInvoice()";
            logExcpUIobj.ResourceName = "CustomerInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = customerInvoiceFormUI.Tbl_CustomerInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerInvoiceFormDAL : UpdateCustomerInvoice] An error occured in the processing of Record Id : " + customerInvoiceFormUI.Tbl_CustomerInvoiceId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteCustomerInvoice(CustomerInvoiceFormUI customerInvoiceFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_CustomerInvoice_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CustomerInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CustomerInvoiceId"].Value = customerInvoiceFormUI.Tbl_CustomerInvoiceId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteCustomerInvoice()";
            logExcpUIobj.ResourceName = "CustomerInvoiceFormDAL.CS";
            logExcpUIobj.RecordId = customerInvoiceFormUI.Tbl_CustomerInvoiceId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CustomerInvoiceFormDAL : DeleteCustomerInvoice] An error occured in the processing of Record Id : " + customerInvoiceFormUI.Tbl_CustomerInvoiceId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}