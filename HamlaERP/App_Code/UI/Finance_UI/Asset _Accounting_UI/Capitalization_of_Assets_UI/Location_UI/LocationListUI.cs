using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LocationListUI
/// </summary>
public class LocationListUI
{
    public LocationListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_LocationId { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string LocationCode { get; set; }

    public string Description { get; set; }
    public string Tbl_CountryId { get; set; }
    public string City { get; set; }

    public string Search { get; set; }
}