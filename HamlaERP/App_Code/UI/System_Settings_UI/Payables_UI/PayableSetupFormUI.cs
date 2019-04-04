using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Payable_Management_FormUI
/// </summary>
public class PayableSetupFormUI
{
    public PayableSetupFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_PayableSetupId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public Boolean AgingPeriods { get; set; }
    public Boolean ApplyBy { get; set; }
    public int Opt_SummaryView { get; set; }
    public string Tbl_ChequeBookId { get; set; }
    public string RemoveVendorHold { get; set; }
    public string ExceedMaxInvoiceAmount { get; set; }
    public string ExceedMaxWriteOffAmount { get; set; }
    public Boolean PrintHistoricalAgedTrialBalance { get; set; }
    public Boolean DeleteUnpostedPrintedDocuments { get; set; }
    public Boolean AllowDuplicateInvoicesPerVendor { get; set; }
    public string InvoiceDescription { get; set; }
    public string InvoiceCode { get; set; }
    public string ReturnDescription { get; set; }
    public string ReturnCode { get; set; }
    public string CreditMemoDescription { get; set; }
    public string CreditMemoCode { get; set; }
    public string PaymentDescription { get; set; }
    public string PaymentCode { get; set; }
    public string Tbl_PayableSetupGroupId { get; set; }
    public string Tbl_PayableSetupAndGroupAccountId { get; set; }
    public string Tbl_GLAccountId_Cash { get; set; }
    public string Tbl_GLAccountId_AccountReceivable { get; set; }
    public string Tbl_GLAccountId_Sales { get; set; }
    public string Tbl_GLAccountId_CostOfSales { get; set; }
    public string Tbl_GLAccountId_Inventory { get; set; }
    public string Tbl_GLAccountId_AccuralDifferedA_C { get; set; }



    


}