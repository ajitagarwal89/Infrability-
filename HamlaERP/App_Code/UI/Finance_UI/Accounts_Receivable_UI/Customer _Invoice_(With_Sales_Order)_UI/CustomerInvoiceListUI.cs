using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerInvoiceListUI
/// </summary>
public class CustomerInvoiceListUI
{
	public CustomerInvoiceListUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_CustomerInvoiceId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public DateTime DocumentDate { get; set; }

    public Int64 DocumentDate_Hijri { get; set; }

    public int Opt_InvoiceAndOrderType { get; set; }

    public string Tbl_InvoiceAndOrderTypeId { get; set; }

    public string DocumentNumber { get; set; }

    public string Tbl_BatchId { get; set; }
    public string Tbl_CustomerId { get; set; }

    public string Tbl_SitesId { get; set; }

    public string CustomerPONumber { get; set; }

    public string Tbl_CurrencyId { get; set; }


    public Decimal AmountReceived { get; set; }

    public Decimal OnAccount { get; set; }

    public Decimal SubTotalAmount { get; set; }

    public Decimal TradeDiscountAmount { get; set; }

    public Decimal FreightAmount { get; set; }

    public Decimal TotalAmount { get; set; }

    public int Opt_DocumentStatus { get; set; }

    public DateTime PostingDate { get; set; }

    public Int64 PostingDate_Hijri { get; set; }

    public DateTime QuoteDate { get; set; }

    public Int64 QuoteDate_Hijri { get; set; }

    public DateTime OrderDate { get; set; }

    public Int64 OrderDate_Hijri { get; set; }

    public DateTime InvoiceDate { get; set; }

    public Int64 InvoiceDate_Hijri { get; set; }
    public DateTime BackOrderDate { get; set; }

    public Int64 BackOrderDate_Hijri { get; set; }

    public DateTime ReturnDate { get; set; }

    public Int64 ReturnDate_Hijri { get; set; }

    public DateTime RequestedShipDate { get; set; }

    public Int64 RequestedShipDate_Hijri { get; set; }
    public DateTime DateFulfilled { get; set; }

    public Int64 DateFulfilled_Hijri { get; set; }

    public DateTime ActualShipDate { get; set; }

    public Int64 ActualShipDate_Hijri { get; set; }

    public string Search { get; set; }
}