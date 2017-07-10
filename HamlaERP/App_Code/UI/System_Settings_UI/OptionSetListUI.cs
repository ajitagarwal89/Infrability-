using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OptionSetListUI
/// </summary>
public class OptionSetListUI
{
	public OptionSetListUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_OptionSetId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string TableName { get; set; }

    public string ParentOptionSetValue { get; set; }
    public string OptionSetName { get; set; }
    public string OptionSetLable { get; set; }
    public Int64 OptionSetValue { get; set; }
    public string TableObjectId { get; set; }
    public string Search { get; set; }
    public string ColumnId { get; set; }

}