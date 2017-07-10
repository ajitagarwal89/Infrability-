using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GLAccountBudgetListUI
/// </summary>
public class GLAccountBudgetListUI
{
	public GLAccountBudgetListUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_GLAccountBudgetId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string Tbl_GLAccountId { get; set; }

    public string Tbl_BudgetId { get; set; }

    public int Opt_BasedOn { get; set; }

    public int Opt_BudgetYear { get; set; }

    public int Opt_CalculationMethod { get; set; }

    public int Year { get; set; }

    public string Tbl_ButdetId_SourceBudgetId { get; set; }

    public Decimal Percentage { get; set; }

    public Decimal Amount { get; set; }

    public Boolean IsIncrease { get; set; }

    public Boolean Display { get; set; }

    public Boolean IncludeBiginningBalance { get; set; }

    public string Search { get; set; }
}