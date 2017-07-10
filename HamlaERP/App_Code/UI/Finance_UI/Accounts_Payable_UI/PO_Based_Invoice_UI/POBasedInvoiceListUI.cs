using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for POBasedInvoiceListUI
/// </summary>
public class POBasedInvoiceListUI
{
	public POBasedInvoiceListUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string Tbl_POBasedInvoiceId { get; set; }

    public DateTime CreatedOn { get; set; }


    public Int64 CreatedOn_Hijri { get; set; }


    public string CreatedBy { get; set; }


    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }


    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }


    public string Tbl_SupplierId { get; set; }


    public string Tbl_CurrencyId { get; set; }


    public string ReceiptNumber { get; set; }


    public DateTime PostingDate { get; set; }

    public Int64 PostingDate_Hijri { get; set; }


    public DateTime InvoiceDate { get; set; }

    public Int64 InvoiceDate_Hijri { get; set; }

    public string Tbl_BatchId { get; set; }

    public string Tbl_PaymentTermsId { get; set; }

    public Decimal SubTotalAmount { get; set; }


    public Decimal TradeDiscountAmount { get; set; }

    public Decimal FreightAmount { get; set; }

    public Decimal TotalAmount { get; set; }

    public string Search { get; set; }

}