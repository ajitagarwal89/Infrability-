using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GLAccountFormatListUI
/// </summary>
public class GLAccountFormatListUI
{
	public GLAccountFormatListUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_GLAccountFormatId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public int MaximumAccountLength { get; set; }

    public int AccountLength { get; set; }

    public int MaximumSegmentLength { get; set; }

    public int SegmentLength { get; set; }

    public string Search { get; set; }
}