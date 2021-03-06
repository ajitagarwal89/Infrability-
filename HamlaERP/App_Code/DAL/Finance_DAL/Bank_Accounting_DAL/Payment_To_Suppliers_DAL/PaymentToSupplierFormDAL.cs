﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for PaymentToSupplierFormDAL
/// </summary>
public class PaymentToSupplierFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public PaymentToSupplierFormDAL()
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
            logExcpUIobj.MethodName = "PaymentToSupplierFormDAL()";
            logExcpUIobj.ResourceName = "PaymentToSupplierFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentToSupplierFormDAL : PaymentToSupplierFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetPaymentToSupplierListById(PaymentToSupplierFormUI paymentToSupplierFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplier_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierId"].Value = paymentToSupplierFormUI.Tbl_PaymentToSupplierId;

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
            logExcpUIobj.MethodName = "getPaymentToSupplierListById()";
            logExcpUIobj.ResourceName = "PaymentToSupplierFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierFormUI.Tbl_PaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToSupplierFormDAL : getPaymentToSupplierListById] An error occured in the processing of Record Id : " + paymentToSupplierFormUI.Tbl_PaymentToSupplierId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPaymentToSupplier(PaymentToSupplierFormUI paymentToSupplierFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplier_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = paymentToSupplierFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentToSupplierFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@PaymentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentNumber"].Value = paymentToSupplierFormUI.PaymentNumber;

                sqlCmd.Parameters.Add("@PaymentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PaymentDate"].Value = paymentToSupplierFormUI.PaymentDate;

                //sqlCmd.Parameters.Add("@PaymentDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@PaymentDate_Hijri"].Value = paymentToSupplierFormUI.PaymentDate_Hijri;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = paymentToSupplierFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = paymentToSupplierFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = paymentToSupplierFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PayablesId_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_BankTransfer"].Value = paymentToSupplierFormUI.Tbl_PayablesId_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = paymentToSupplierFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = paymentToSupplierFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = paymentToSupplierFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = paymentToSupplierFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = paymentToSupplierFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = paymentToSupplierFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = paymentToSupplierFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@Unapplied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Unapplied"].Value = paymentToSupplierFormUI.Unapplied;

                sqlCmd.Parameters.Add("@Applied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Applied"].Value = paymentToSupplierFormUI.Applied;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = paymentToSupplierFormUI.Total;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPaymentToSupplier()";
            logExcpUIobj.ResourceName = "PaymentToSupplierFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToSupplierFormDAL : AddPaymentToSupplier] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePaymentToSupplier(PaymentToSupplierFormUI paymentToSupplierFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplier_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = paymentToSupplierFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = paymentToSupplierFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierId"].Value = paymentToSupplierFormUI.Tbl_PaymentToSupplierId;

                sqlCmd.Parameters.Add("@PaymentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentNumber"].Value = paymentToSupplierFormUI.PaymentNumber;

                sqlCmd.Parameters.Add("@PaymentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PaymentDate"].Value = paymentToSupplierFormUI.PaymentDate;

                //sqlCmd.Parameters.Add("@PaymentDate_Hijri", SqlDbType.BigInt);
                //sqlCmd.Parameters["@PaymentDate_Hijri"].Value = paymentToSupplierFormUI.PaymentDate_Hijri;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = paymentToSupplierFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = paymentToSupplierFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = paymentToSupplierFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PayablesId_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_BankTransfer"].Value = paymentToSupplierFormUI.Tbl_PayablesId_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = paymentToSupplierFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = paymentToSupplierFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = paymentToSupplierFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = paymentToSupplierFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = paymentToSupplierFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = paymentToSupplierFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = paymentToSupplierFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@Unapplied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Unapplied"].Value = paymentToSupplierFormUI.Unapplied;

                sqlCmd.Parameters.Add("@Applied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Applied"].Value = paymentToSupplierFormUI.Applied;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = paymentToSupplierFormUI.Total;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentToSupplier()";
            logExcpUIobj.ResourceName = "PaymentToSupplierFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierFormUI.Tbl_PaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToSupplierFormDAL : UpdatePaymentToSupplier] An error occured in the processing of Record Id : " + paymentToSupplierFormUI.Tbl_PaymentToSupplierId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePaymentToSupplier(PaymentToSupplierFormUI paymentToSupplierFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToSupplier_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToSupplierId"].Value = paymentToSupplierFormUI.Tbl_PaymentToSupplierId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentToSupplier()";
            logExcpUIobj.ResourceName = "PaymentToSupplierFormDAL.CS";
            logExcpUIobj.RecordId = paymentToSupplierFormUI.Tbl_PaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PaymentToSupplierFormDAL : DeletePaymentToSupplier] An error occured in the processing of Record Id : " + paymentToSupplierFormUI.Tbl_PaymentToSupplierId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}