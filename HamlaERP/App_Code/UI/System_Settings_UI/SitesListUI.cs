using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SitesListUI
/// </summary>
public class SitesListUI
{
	public SitesListUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_SitesId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }
    public string SiteNumber { get; set; }
    public string Description { get; set; }

    public string Search { get; set; }
}