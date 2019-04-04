using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for POFormUI
/// </summary>
public class POFormUI
{
    public POFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_POId { get; set; }

    public DateTime CreatedOn { get; set; }


    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }


    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public int opt_Type { get; set; }

    public string PONumber { get; set; }

    public string Tbl_SupplierId { get; set; }

    public string Tbl_UserId_Buyer { get; set; }

    public DateTime Date { get; set; }

    public string Tbl_CurrencyId { get; set; }


    public Boolean AllowSales { get; set; }

    public DateTime RequisitionDate { get; set; }

    public DateTime PurchaseOrderDate { get; set; }

    public DateTime LastEditDate { get; set; }

    public DateTime LastPrintedDate { get; set; }

    public DateTime ContractExpirationDate { get; set; }

    public DateTime DatePlacedOnHold { get; set; }

    public DateTime DateHoldRemoved { get; set; }

    public string Tbl_UserId_PlacedOnHoldBy { get; set; }

    public string Tbl_UserId_HoldRemovedBy { get; set; }

    public Decimal RemainingSubTotal { get; set; }
    public Decimal SubTotal { get; set; }

    public Decimal TradeDiscount { get; set; }
    public Decimal Freight { get; set; }
    public Decimal Miscellaneous { get; set; }
    public Decimal Total { get; set; }

    public string Search { get; set; }

    public string Tbl_CommentsId { get; set; }
    public int Version { get; set; }

    public int opt_Status { get; set; }
}