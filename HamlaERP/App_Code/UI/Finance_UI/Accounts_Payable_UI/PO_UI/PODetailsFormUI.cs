using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PODetailsFormUI
/// </summary>
public class PODetailsFormUI
{
    public PODetailsFormUI()
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

    public string Tbl_PODetailsId { get; set; }

    public string Tbl_POId { get; set; }

    public string Tbl_AssetId_FixedAsset { get; set; }

    public string Search { get; set; }

    public string UOM { get; set; }

    public string Description { get; set; }

    public string Tbl_LocationId { get; set; }

    public decimal QuantityOrdered { get; set; }

    public decimal QuantityCanceled { get; set; }

    public decimal UnitCost { get; set; }

    public decimal ExtendedCost { get; set; }

}