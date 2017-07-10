using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerInvoiceDistributionListUI
/// </summary>
public class CustomerInvoiceDistributionListUI
{
    public CustomerInvoiceDistributionListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_OrganizationId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_CustomerInvoiceDistributionId { get; set; }

    public string Tbl_CustomerInvoiceId { get; set; }

    public string Search { get; set; }

    public string Tbl_GLAccountId { get; set; }

    public Int16 Opt_GLAccountType { get; set; }

    public string Description { get; set; }

    public string DistributionReference { get; set; }

    public decimal Debit { get; set; }

    public decimal Credit { get; set; }

    public decimal OriginatingDebit { get; set; }

    public decimal OriginatingCredit { get; set; }

    public decimal ExchangeRate { get; set; }
}