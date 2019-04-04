using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GLAccountListUI
/// </summary>
public class GLAccountListUI
{
	public GLAccountListUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_GLAccountId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }
    public string AccountNumber { get; set; }

    public Boolean IsActive { get; set; }

    public Boolean AllowAccountEntry { get; set; }
    public string Tbl_GLAccountCategoryId { get; set; }
    public Boolean PostingType { get; set; }
    public Boolean TypicalBalance { get; set; }
    public Boolean AppearInFinance { get; set; }
    public Boolean AppearInHR { get; set; }
    public Boolean AppearInProcurement { get; set; }
    public Boolean AppearInSystemSettingss { get; set; }

    public string Tbl_Segment10Id { get; set; }
    public string Tbl_Segment09Id { get; set; }
    public string Tbl_Segment08Id { get; set; }
    public string Tbl_Segment07Id { get; set; }
    public string Tbl_Segment06Id { get; set; }
    public string Tbl_Segment05Id { get; set; }
    public string Tbl_Segment04Id { get; set; }
    public string Tbl_Segment03Id { get; set; }
    public string Tbl_Segment02Id { get; set; }
    public string Tbl_Segment01Id { get; set; }

    public string Search { get; set; }
}