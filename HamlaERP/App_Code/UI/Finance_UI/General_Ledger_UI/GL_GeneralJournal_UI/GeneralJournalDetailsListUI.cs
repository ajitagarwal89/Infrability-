using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GeneralJournalDetailsListUI
/// </summary>
public class GeneralJournalDetailsListUI
{
	public GeneralJournalDetailsListUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    public string Tbl_GeneralJournalDetailsId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string Tbl_GLAccountId { get; set; }
    public string Tbl_GeneralJournalId { get; set; }

    public Decimal Debit { get; set; }
    public Decimal Credit { get; set; }

    public string Search { get; set; }

    public string Description { get; set; }
    public string DistributionReference { get; set; }
    public string CompanyId { get; set; }
    public Decimal TotalDebit { get; set; }
    public Decimal TotalCredit { get; set; }
    public Decimal Difference { get; set; }
    public bool Status { get; set; }
}