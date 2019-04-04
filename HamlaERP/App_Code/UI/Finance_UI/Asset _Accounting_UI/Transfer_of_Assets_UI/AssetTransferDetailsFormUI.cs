using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssetTransferDetailsFormUI
/// </summary>
public class AssetTransferDetailsFormUI
{
    public AssetTransferDetailsFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_AssetTransferDetailsId { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Tbl_AssetTransferId { get; set; }
    public string Tbl_AssetId { get; set; }
    public string UOM { get; set; }
    public string Quantity{ get; set; }
    public string Description { get; set; }
    public string Tbl_LocationId_From { get; set; }
    public string Tbl_LocationId_To { get; set; }
    public Decimal SubTotal { get; set; }
    public int QuantityAvailable { get; set; }
    public string Search { get; set; }
}