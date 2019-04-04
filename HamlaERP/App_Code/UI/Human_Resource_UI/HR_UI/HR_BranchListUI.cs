using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HR_BranchListUI
/// </summary>
public class HR_BranchListUI
{
    public HR_BranchListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_HR_BranchId { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Search { get; set; }
    public string BranchCode { get; set; }
    public string Description { get; set; }
    public int opt_CurrentyFiscalYear { get; set; }
    public int opt_DepreciatedPeriod { get; set; }

}