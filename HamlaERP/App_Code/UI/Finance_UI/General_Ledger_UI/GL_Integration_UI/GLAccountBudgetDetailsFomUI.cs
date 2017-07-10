using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GLAccountBudgetDetailsFomUI
/// </summary>
public class GLAccountBudgetDetailsFomUI
{
	public GLAccountBudgetDetailsFomUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_GLAccountBudgetDetailsId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string Tbl_GLAccountBudgetId { get; set; }

    public string Tbl_FiscalPeriodId { get; set; }

    public int Period { get; set; }

    public string PeriodName { get; set; }

    public DateTime PeriodDate { get; set; }

    public Int64 PeriodDate_Hijri { get; set; }

    public Decimal Amount { get; set; }

    public string Search { get; set; }
}