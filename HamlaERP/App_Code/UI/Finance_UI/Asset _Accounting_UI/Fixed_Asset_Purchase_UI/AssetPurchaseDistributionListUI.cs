using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssetPurchaseDistributionListUI
/// </summary>
public class AssetPurchaseDistributionListUI
{
    public AssetPurchaseDistributionListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_AssetPurchaseDistributionId { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Tbl_AssetPurchaseId { get; set; }
    public string Tbl_GLAccountId { get; set; }
    public int opt_GLAccountType { get; set; }
    public string Description { get; set; }
    public string DistributionReference { get; set; }
    public Decimal Debit { get; set; }
    public Decimal Credit { get; set; }
    public string Search { get; set; }

}