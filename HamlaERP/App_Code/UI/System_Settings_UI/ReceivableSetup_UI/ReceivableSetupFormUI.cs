using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReceivableSetupFormUI
/// </summary>
public class ReceivableSetupFormUI
{
    public ReceivableSetupFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Tbl_ReceivableSetupId { get; set; }
    public Boolean IsDelete { get; set; }
    public Boolean IsAgingPeriods { get; set; }
    public string Tbl_ReceivalbeSetupPeriodId { get; set; }
    public string CurrentPeriod { get; set; }
    public Int32 FROM { get; set; }
    public Int32 TO { get; set; }
    public string FROMPeriod { get; set; }
    public string TOPeriod { get; set; }
    public decimal ExceedCardLimit { get; set; }
    public string RemoveCustomerHold { get; set; }
    public decimal ExceedMaximumWriteOffs { get; set; }
    public Boolean IsApplyBy { get; set; }
    public string Tbl_CheckBookId { get; set; }
    public int Opt_DocumentFormate { get; set; }
    public int Opt_SummaryView { get; set; }
    public Boolean IsReprintStatements { get; set; }
    public Boolean IsPrintTrialBalance { get; set; }
    public Boolean IsDeleteUnposted { get; set; }
    public string SaleInvoiceDescription { get; set; }
    public string SaleInvoiceCode { get; set; }
    public string SaleInvoiceNextNumber { get; set; }
    public string DebitMemoDescription { get; set; }
    public string DebitMemoCode { get; set; }
    public string DebitMemoNextNumber { get; set; }
    public string CreditMemoDescription { get; set; }
    public string CreditMemoCode { get; set; }
    public string CreditMemoNextNumber { get; set; }
    public string WriteoffCreditMemoNextNumber { get; set; }
    public string ReturnDescription { get; set; }
    public string ReturnCode { get; set; }
    public string ReturnNextNumber { get; set; }
    public string CashReceiptDescription { get; set; }
    public string CashReceiptCode { get; set; }
    public string CashReceiptNextNumber { get; set; }
    public DateTime StatementsPrintedDate { get; set; }
    public DateTime BalanceForwardAccountsAgedDate { get; set; }
    public DateTime OpenitemAccountsAgedDate { get; set; }
    public Boolean Sales { get; set; }
    public Boolean Discount { get; set; }
    public Boolean Freight { get; set; }
    public string Tbl_ReceivableSetupGroupId { get; set; }
    public string Tbl_ReceivableSetupAndGroupAccountId { get; set; }
    public string Tbl_GLAccountId_Cash { get; set; }
    public string Tbl_GLAccountId_AccountReceivable { get; set; }
    public string Tbl_GLAccountId_Sales { get; set; }
    public string Tbl_GLAccountId_CostOfSales { get; set; }
    public string Tbl_GLAccountId_Inventory { get; set; }
    public string Tbl_GLAccountId_AccuralDifferedA_C { get; set; }
    public string Search { get; set; }
}