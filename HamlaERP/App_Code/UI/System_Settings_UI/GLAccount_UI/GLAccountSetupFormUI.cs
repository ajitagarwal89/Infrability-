using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GLAccountSetupFormUI
/// </summary>
public class GLAccountSetupFormUI
{
    public GLAccountSetupFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_GLAccountSetupId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public Boolean Display { get; set; }
    public Boolean CloseToDivisionalAccountSegments { get; set; }
    public string Tbl_CloseToDivisionalAccountSegmentsId { get; set; }
    public string Tbl_GLAccountId_Account { get; set; }
    public Boolean Accounts { get; set; }
    public Boolean Transactions { get; set; }
    public Boolean PostingToHistory { get; set; }
    public Boolean DeletionOfSavedTransactions { get; set; }
    public string Search { get; set; }
}