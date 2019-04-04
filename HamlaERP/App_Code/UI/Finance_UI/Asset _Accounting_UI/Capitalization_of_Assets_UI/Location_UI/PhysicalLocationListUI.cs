using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PhysicalLocationListUI
/// </summary>
public class PhysicalLocationListUI
{
    public PhysicalLocationListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_PhysicalLocationId { get; set; }
    public string Tbl_LocationId { get; set; }

    public string ModifiedBy { get; set; }
    public string CreatedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Description { get; set; }
    public DateTime LastInventoryDate { get; set; }
    public string Search { get; set; }
}