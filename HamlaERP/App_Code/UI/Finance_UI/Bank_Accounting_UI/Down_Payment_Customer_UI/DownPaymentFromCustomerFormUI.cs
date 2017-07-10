using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DownPaymentFromCustomerForm_UI
/// </summary>
public class DownPaymentFromCustomerFormUI
{
    public DownPaymentFromCustomerFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_DownPaymentFromCustomerId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Search { get; set; }
    public string ReceiptNumber { get; set; }
    public DateTime ReceiptDate { get; set; }
    public DateTime ReceiptDate_Hijri { get; set; }
    public string Tbl_BatchId { get; set; }
    public string Tbl_CustomerId { get; set; }
    public string Tbl_CurrencyId { get; set; }
    public string Tbl_PayablesId_Cash { get; set; }
    public Decimal CashAmount { get; set; }
    public string Tbl_PayablesId_Cheque { get; set; }
    public Decimal ChequeAmount { get; set; }
    public string Tbl_PayablesId_CreditCard { get; set; }
    public Decimal CreditCardAmount { get; set; }
    public string DocumentNumber { get; set; }
    public string Comments { get; set; }
    public Boolean IsAutoAppliyTo { get; set; }
    public Boolean IsPosted { get; set; }
    public DateTime PostingDate { get; set; }
    public DateTime PostingDate_Hijri { get; set; }
    public DateTime ApplyDate { get; set; }
    public string Tbl_SourceDocumentId { get; set; }
    public int opt_DocumentType { get; set; }

    public Decimal TotalAmount { get; set; }

}