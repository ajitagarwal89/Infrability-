using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaymentTermsListUI
/// </summary>
public class PaymentTermsListUI
{
	public PaymentTermsListUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_PaymentTermsId { get; set; }

    public DateTime CreatedOn { get; set; }


    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }


    public DateTime ModifiedOn { get; set; }


    public Int64 ModifiedOn_Hijri { get; set; }


    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }


    public string PaymentTermsName { get; set; }


    public int DueInDays { get; set; }


    public int DiscountInDays { get; set; }

    public int Opt_DiscountType { get; set; }


    public Decimal DiscountTypeValue { get; set; }


    public Boolean SalesOrPurchase { get; set; }

    public string Search { get; set; }
}