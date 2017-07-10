using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplierGroupListUI
/// </summary>
public class SupplierGroupListUI
{
	public SupplierGroupListUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_SupplierGroupId { get; set; }

    public DateTime CreatedOn { get; set; }


    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }


    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string Tbl_SupplierGroupId_Self { get; set; }

    public string Description { get; set; }

    public string Tbl_CurrencyId { get; set; }

    public string Tbl_PaymentTermsId { get; set; }

    public Decimal TradeDiscount { get; set; }

    public int Opt_MinimumPayment { get; set; }

    public int Opt_MaximumInvoiceAmount { get; set; }

    public int Opt_CreditLimit { get; set; }

    public int Opt_Writeoff { get; set; }

    public Boolean CalendarYear { get; set; }

    public Boolean FiscalYear { get; set; }

    public Boolean Transaction { get; set; }

    public Boolean Distribution { get; set; }

    public string Search { get; set; }

}