using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CurrencyFormUI
/// </summary>
public class CurrencyFormUI
{
	public CurrencyFormUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public string Tbl_CurrencyId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string CurrencyCode { get; set; }

    public string CurrencyName { get; set; }

    public string Tbl_CountryId { get; set; }

    public string Search { get; set; }
}