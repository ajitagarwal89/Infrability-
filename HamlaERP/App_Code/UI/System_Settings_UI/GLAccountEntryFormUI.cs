using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GLAccountEntryFormUI
/// </summary>
public class GLAccountEntryFormUI
{
	public GLAccountEntryFormUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_GLAccountEntryId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string JournalEntry { get; set; }

    public string Tbl_BatchId { get; set; }

    public Boolean TransactionType { get; set; }

    public DateTime TransactionDate { get; set; }

    public Int64 TransactionDate_Hijri { get; set; }

    public string Tbl_SourceDocument { get; set; }

    public string Reference { get; set; }

    public string Tbl_CurrencyId { get; set; }

    public string Search { get; set; }
}