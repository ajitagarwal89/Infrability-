using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssetPurchaseDetailsFormUI
/// </summary>
public class AssetPurchaseDetailsFormUI
{
    public AssetPurchaseDetailsFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_AssetPurchaseDetailsId { get; set; }
    public string Tbl_AssetPurchaseId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }
    public string Tbl_PONumberId { get; set; }
    public string Tbl_AssetId { get; set; }
    public string UOM { get; set; }
    public string Tbl_LocationId { get; set; }
    public string Description { get; set; }

    public Decimal QuantityOrdered { get; set; }
    public Decimal QuantityShipped { get; set; }
    public Decimal QuantityInvoiced { get; set; }
    public Decimal PreviouslyShipped { get; set; }
    public Decimal PreviouslyInvoiced { get; set; }
    public Decimal UnitCost { get; set; }
    public Decimal ExtendedCost { get; set; }
    public string Search { get; set; }
}