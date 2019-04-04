using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssetBookGroupSetupListUI
/// </summary>
public class AssetBookGroupSetupListUI
{
    public AssetBookGroupSetupListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_AssetBookGroupSetupId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }

    public string AssetBookGroupSetupCode { get; set; }
    public string Tbl_AssetBookSetupId { get; set; }
    public string Tbl_AssetGroupId { get; set; }

    public int opt_DepreciationMethod { get; set; }
  public int opt_AveragingConvention { get; set; }

    public int OriginalLifeYear { get; set; }
    public int OriginalLifeDay { get; set; }

    public decimal ScrapValue { get; set; }

    public string Search { get; set; }


}
