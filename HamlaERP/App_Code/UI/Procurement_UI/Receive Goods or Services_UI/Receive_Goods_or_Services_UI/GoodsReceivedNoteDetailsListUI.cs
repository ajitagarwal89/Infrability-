using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GoodsReceivedNoteDetailsListUI
/// </summary>
public class GoodsReceivedNoteDetailsListUI
{
    public GoodsReceivedNoteDetailsListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_GoodsReceivedNoteDetailsId { get; set; }
    public string Tbl_GoodsReceivedNoteId { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Tbl_POId { get; set; }
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
    public string Tbl_PODetailsId { get; set; }
    public string Search { get; set; }
}