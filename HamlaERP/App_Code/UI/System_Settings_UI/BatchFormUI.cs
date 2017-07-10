using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BatchFormUI
/// </summary>
public class BatchFormUI
{
	public BatchFormUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_BatchId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public int Opt_BatchType { get; set; }

    public string BatchName { get; set; }

    public string Comment { get; set; }

    public int Opt_Origin { get; set; }

    public DateTime PostingDate { get; set; }

    public Int64 PostingDate_Hijri { get; set; }

    public int Opt_Frequency { get; set; }

    public Boolean BreakDownAllocation { get; set; }

    public int RecurringPosting { get; set; }

    public int DaysToIncrement { get; set; }

    public DateTime LastDatePosted { get; set; }

    public int NumberOfTimesPosted { get; set; }

    public int ControlJournalEntries { get; set; }

    public int ActualJournalEntries { get; set; }

    public Boolean IsApproved { get; set; }

    public string Tbl_UserId_ApprovedBy { get; set; }

    public DateTime ApprovedDate { get; set; }

    public Int64 ApprovedDate_Hijri { get; set; }

    public string Search { get; set; }
}