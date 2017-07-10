using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BudgetFormUI
/// </summary>
public class BudgetFormUI
{
	public BudgetFormUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_BudgetId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string BudgetNumber { get; set; }

    public string Description { get; set; }

    public int Opt_BasedOn { get; set; }

    public int Opt_BudgetYear { get; set; }

    public Boolean AnnualCapital { get; set; }

    public string Tbl_GLAccountId { get; set; }

    public Boolean Display { get; set; }

    public string Search { get; set; }
}