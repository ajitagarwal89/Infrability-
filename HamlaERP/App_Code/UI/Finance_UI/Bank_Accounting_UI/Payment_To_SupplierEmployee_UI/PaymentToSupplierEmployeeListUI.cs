using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaymentToSupplierEmployeeListUI
/// </summary>
public class PaymentToSupplierEmployeeListUI
{
    public PaymentToSupplierEmployeeListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_PaymentToSupplierEmployeeId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Search { get; set; }
    public string PaymentNumber { get; set; }
    public DateTime PaymentDate { get; set; }
    public string Tbl_BatchId { get; set; }
    public string Tbl_SupplierEmployeeId { get; set; }
    public string Tbl_CurrencyId { get; set; }
    public string Tbl_PayablesId_BankTransfer { get; set; }
    public Decimal BankTransferAmount { get; set; }
    public string Tbl_PayablesId_Cash { get; set; }
    public Decimal CashAmount { get; set; }
    public string Tbl_PayablesId_Cheque { get; set; }
    public Decimal ChequeAmount { get; set; }
    public string Tbl_PayablesId_CreditCard { get; set; }
    public Decimal CreditCardAmount { get; set; }
    public Decimal Unapplied { get; set; }
    public Decimal Applied { get; set; }
    public Decimal Total { get; set; }

    public Boolean IsAutoApplyTo { get; set; }
    public Boolean IsPosted { get; set; }
   
    public DateTime ApplyDate { get; set; }
    public string Tbl_SourceDocumentId { get; set; }
    public Int32 opt_DocumentType { get; set; }
}