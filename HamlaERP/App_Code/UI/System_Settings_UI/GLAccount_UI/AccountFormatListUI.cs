using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AccountFormatListUI
/// </summary>
public class AccountFormatListUI
{
	public AccountFormatListUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_AccountFormatId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public int MaximumAccountLength { get; set; }

    public int AccountLength { get; set; }

    public int MaximumSegment { get; set; }

    public int Segment { get; set; }

    public string Search { get; set; }
}