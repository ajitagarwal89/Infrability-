using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrganizationTypeFormUI
/// </summary>
public class OrganizationTypeFormUI
{
	public OrganizationTypeFormUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_OrganizationTypeId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string OrganizationType { get; set; }

    public string Search { get; set; }
}