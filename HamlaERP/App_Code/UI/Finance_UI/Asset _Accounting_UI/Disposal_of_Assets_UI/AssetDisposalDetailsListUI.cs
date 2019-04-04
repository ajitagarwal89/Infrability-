using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssetDisposalDetailsListUI
/// </summary>
public class AssetDisposalDetailsListUI
{
    public AssetDisposalDetailsListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_AssetDisposalDetailsId { get; set; }
    public string Tbl_AssetDisposalId { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public Decimal Quantity { get; set; }
    public Decimal Cost { get; set; }
    public Decimal Percent { get; set; }
    public Decimal CashProceeds { get; set; }
    public Decimal NonCashProceeds { get; set; }
    public Decimal ExpensesOfSales { get; set; }
    public Decimal OriginatingAmount { get; set; }
    public string Search { get; set; }


}