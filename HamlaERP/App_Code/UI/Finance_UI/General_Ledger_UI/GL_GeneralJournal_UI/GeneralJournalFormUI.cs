using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GeneralJournalFormUI
/// </summary>
public class GeneralJournalFormUI
{
    public GeneralJournalFormUI()
    {
      
    }

    public string Tbl_GeneralJournalId { get; set; }

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

    public string Tbl_SourceDocumentId { get; set; }

    public string Reference { get; set; }

    public string Tbl_CurrencyId { get; set; }

    public int Opt_GeneralJournalType { get; set; }

    public string Tbl_GeneralJournalId_Self { get; set; }

    public bool IsPosted { get; set; }

    public DateTime PostingDate { get; set; }

    public string Search { get; set; }
}