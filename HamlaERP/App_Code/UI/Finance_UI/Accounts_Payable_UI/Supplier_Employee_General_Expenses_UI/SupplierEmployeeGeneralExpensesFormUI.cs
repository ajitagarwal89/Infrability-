using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplierEmployeeGeneralExpensesUI
/// </summary>
public class SupplierEmployeeGeneralExpensesFormUI
{
    public SupplierEmployeeGeneralExpensesFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_SupplierEmployeeGeneralExpensesId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string VoucherNumber { get; set; }

    public Boolean InterCompany { get; set; }

    public string Tbl_BatchId { get; set; }

    public int Opt_DocumentType { get; set; }

    public int Opt_PayablesType { get; set; }

    public DateTime DocumentDate { get; set; }

    public Int64 DocumentDate_Hijri { get; set; }

    public string Description { get; set; }

   

    
    public DateTime InvoiceDate { get; set; }

    public Int64 InvoiceDate_Hijri { get; set; }

    public DateTime ReceivedDate { get; set; }

    public Int64 ReceivedDate_Hijri { get; set; }

    public string Tbl_SupplierEmployeeId { get; set; }

    public string Tbl_CurrencyId { get; set; }

    public Decimal Expenses { get; set; }

    public string Tbl_Payables_BankTransfer { get; set; }

    public Decimal BankTransferAmount { get; set; }

    public string Tbl_Payables_Cash { get; set; }

    public Decimal Cash { get; set; }

    public string Tbl_Payables_Cheque { get; set; }

    public Decimal Cheque { get; set; }

    public string Tbl_Payables_CreditCard { get; set; }

    public Decimal CreditCard { get; set; }

    public Decimal OnAccount { get; set; }

    public string Search { get; set; }

    public int InvoiceType { get; set; }

    public bool IsPosted { get; set; }

}