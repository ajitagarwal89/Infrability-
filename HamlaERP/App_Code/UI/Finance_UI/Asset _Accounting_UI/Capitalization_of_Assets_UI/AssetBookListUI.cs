using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssetBookListUI
/// </summary>
public class AssetBookListUI
{
    public AssetBookListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_AssetBookId { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Tbl_AssetId { get; set; }
    public string AssetBookCode { get; set; }
    public DateTime PlaceInServiceDate { get; set; }
    public DateTime DepreciatedDueDate { get; set; }
    public Decimal BeginYearCost { get; set; }
    public Decimal CostBasis { get; set; }
    public Decimal ScrapValue { get; set; }
    public Decimal YearlyDepreciationRate { get; set; }
    public Decimal CurrentDepreciation { get; set; }
    public Decimal NetBookValue { get; set; }
    public int opt_DepreciationMethod { get; set; }
    public int opt_AveragingConvention { get; set; }
    public Boolean FullDepreciationFlag { get; set; }
    public int opt_Status { get; set; }
    public int OriginalLifeYear { get; set; }
    public int OriginalLifeDay { get; set; }
    public string Search { get; set; }
}