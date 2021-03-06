﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for DownPaymentToSupplierFormDAL
/// </summary>
public class DownPaymentToSupplierFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public DownPaymentToSupplierFormDAL()
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
            logExcpUIobj.MethodName = "DownPaymentToSupplierFormDAL()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[DownPaymentToSupplierFormDAL : DownPaymentToSupplierFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetDownPaymentToSupplierListById(DownPaymentToSupplierFormUI downPaymentToSupplierFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplier_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierId"].Value = downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId;

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
            logExcpUIobj.MethodName = "GetDownPaymentToSupplierListById()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentToSupplierFormDAL : GetDownPaymentToSupplierListById] An error occured in the processing of Record Id : " + downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddDownPaymentToSupplier(DownPaymentToSupplierFormUI downPaymentToSupplierFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplier_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = downPaymentToSupplierFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = downPaymentToSupplierFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@PaymentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentNumber"].Value = downPaymentToSupplierFormUI.PaymentNumber;

                sqlCmd.Parameters.Add("@PaymentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PaymentDate"].Value = downPaymentToSupplierFormUI.PaymentDate;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = downPaymentToSupplierFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = downPaymentToSupplierFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = downPaymentToSupplierFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PayablesId_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_BankTransfer"].Value = downPaymentToSupplierFormUI.Tbl_PayablesId_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = downPaymentToSupplierFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = downPaymentToSupplierFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = downPaymentToSupplierFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = downPaymentToSupplierFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = downPaymentToSupplierFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = downPaymentToSupplierFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = downPaymentToSupplierFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = downPaymentToSupplierFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@Comments", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comments"].Value = downPaymentToSupplierFormUI.Comments;


                sqlCmd.Parameters.Add("@Unapplied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Unapplied"].Value = downPaymentToSupplierFormUI.Unapplied;


                sqlCmd.Parameters.Add("@Applied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Applied"].Value = downPaymentToSupplierFormUI.Applied;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = downPaymentToSupplierFormUI.Total;

                sqlCmd.Parameters.Add("@IsAutoAppliyTo", SqlDbType.Bit);
                sqlCmd.Parameters["@IsAutoAppliyTo"].Value = downPaymentToSupplierFormUI.IsAutoAppliyTo;

                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = downPaymentToSupplierFormUI.IsPosted;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = downPaymentToSupplierFormUI.PostingDate;

                sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ApplyDate"].Value = downPaymentToSupplierFormUI.ApplyDate;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = downPaymentToSupplierFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DocumentType"].Value = downPaymentToSupplierFormUI.opt_DocumentType;


                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddDownPaymentToSupplier()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[DownPaymentToSupplierFormDAL : AddDownPaymentToSupplier] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdateDownPaymentToSupplier(DownPaymentToSupplierFormUI downPaymentToSupplierFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplier_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = downPaymentToSupplierFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = downPaymentToSupplierFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_DownPaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_DownPaymentToSupplierId"].Value = downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId;

                sqlCmd.Parameters.Add("@PaymentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PaymentNumber"].Value = downPaymentToSupplierFormUI.PaymentNumber;

                sqlCmd.Parameters.Add("@PaymentDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PaymentDate"].Value = downPaymentToSupplierFormUI.PaymentDate;

                sqlCmd.Parameters.Add("@tbl_BatchId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_BatchId"].Value = downPaymentToSupplierFormUI.Tbl_BatchId;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = downPaymentToSupplierFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = downPaymentToSupplierFormUI.Tbl_CurrencyId;

                sqlCmd.Parameters.Add("@tbl_PayablesId_BankTransfer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_BankTransfer"].Value = downPaymentToSupplierFormUI.Tbl_PayablesId_BankTransfer;

                sqlCmd.Parameters.Add("@BankTransferAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@BankTransferAmount"].Value = downPaymentToSupplierFormUI.BankTransferAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cash", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cash"].Value = downPaymentToSupplierFormUI.Tbl_PayablesId_Cash;

                sqlCmd.Parameters.Add("@CashAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CashAmount"].Value = downPaymentToSupplierFormUI.CashAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_Cheque", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_Cheque"].Value = downPaymentToSupplierFormUI.Tbl_PayablesId_Cheque;

                sqlCmd.Parameters.Add("@ChequeAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ChequeAmount"].Value = downPaymentToSupplierFormUI.ChequeAmount;

                sqlCmd.Parameters.Add("@tbl_PayablesId_CreditCard", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayablesId_CreditCard"].Value = downPaymentToSupplierFormUI.Tbl_PayablesId_CreditCard;

                sqlCmd.Parameters.Add("@CreditCardAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@CreditCardAmount"].Value = downPaymentToSupplierFormUI.CreditCardAmount;

                sqlCmd.Parameters.Add("@DocumentNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@DocumentNumber"].Value = downPaymentToSupplierFormUI.DocumentNumber;

                sqlCmd.Parameters.Add("@Comments", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Comments"].Value = downPaymentToSupplierFormUI.Comments;

                sqlCmd.Parameters.Add("@Unapplied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Unapplied"].Value = downPaymentToSupplierFormUI.Unapplied;

                sqlCmd.Parameters.Add("@Applied", SqlDbType.Decimal);
                sqlCmd.Parameters["@Applied"].Value = downPaymentToSupplierFormUI.Applied;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = downPaymentToSupplierFormUI.Total;

                sqlCmd.Parameters.Add("@IsAutoAppliyTo", SqlDbType.Bit);
                sqlCmd.Parameters["@IsAutoAppliyTo"].Value = downPaymentToSupplierFormUI.IsAutoAppliyTo;


                sqlCmd.Parameters.Add("@IsPosted", SqlDbType.Bit);
                sqlCmd.Parameters["@IsPosted"].Value = downPaymentToSupplierFormUI.IsPosted;

                sqlCmd.Parameters.Add("@PostingDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PostingDate"].Value = downPaymentToSupplierFormUI.PostingDate;

                sqlCmd.Parameters.Add("@ApplyDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ApplyDate"].Value = downPaymentToSupplierFormUI.ApplyDate;

                sqlCmd.Parameters.Add("@tbl_SourceDocumentId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SourceDocumentId"].Value = downPaymentToSupplierFormUI.Tbl_SourceDocumentId;

                sqlCmd.Parameters.Add("@opt_DocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_DocumentType"].Value = downPaymentToSupplierFormUI.opt_DocumentType;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateDownPaymentToSupplier()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[DownPaymentToSupplierFormDAL : UpdateDownPaymentToSupplier] An error occured in the processing of Record Id : " + downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteDownPaymentToSupplier(DownPaymentToSupplierFormUI downPaymentToSupplierFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplier_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierId"].Value = downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteDownPaymentToSupplier()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentToSupplierFormDAL : DeleteDownPaymentToSupplier] An error occured in the processing of Record Id : " + downPaymentToSupplierFormUI.Tbl_DownPaymentToSupplierId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}