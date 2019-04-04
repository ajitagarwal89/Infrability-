using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GLAccountSummaryFormUI
/// </summary>
public class GLAccountSummaryFormUI
{
	public GLAccountSummaryFormUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_GLAccountSummaryId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string Tbl_GLAccountId { get; set; }

    public string Tbl_FiscalPeriodId { get; set; }

    public string Search { get; set; }
}