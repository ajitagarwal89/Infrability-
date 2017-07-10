using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssetDisposalFormUI
/// </summary>
public class AssetDisposalFormUI
{
    public AssetDisposalFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_AssetDisposalId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }

    public string AssetDisposalCode { get; set; }
    public string Tbl_AssetId { get; set; }
    public DateTime RetirementDate { get; set; }
    public int opt_RetirementType { get; set; }
    public string RetirementEvent { get; set; }
    public string Tbl_CurrencyId { get; set; }

    public string Search { get; set; }
}