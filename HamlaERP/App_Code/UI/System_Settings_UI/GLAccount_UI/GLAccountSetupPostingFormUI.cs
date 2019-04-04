using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GLAccountSetupPostingUI
/// </summary>
public class GLAccountSetupPostingFormUI
{
    public GLAccountSetupPostingFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_GLAccountSetupPostingId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public int opt_Series { get; set; }
    public int opt_Origin { get; set; }
    public Boolean PostToGL { get; set; }
    public int Opt_AccountType { get; set; }
    public Boolean PaymentMode { get; set; }
    public Boolean PostThroughGLFile { get; set; }
    public Boolean AllowTransactionPosting { get; set; }
    public Boolean IncludeMultiCurrencyInfo { get; set; }
    public Boolean VerifyNumberOfTransaction { get; set; }
    public Boolean VerifyBatchAmount { get; set; }
    public Boolean Transaction { get; set; }
    public Boolean Batch { get; set; }
    public Boolean UseAccountSetting { get; set; }
    public Boolean PostingDateFromBatch { get; set; }
    public Boolean PostingDateFromTrx { get; set; }
    public Boolean IfExistingBatchAppend { get; set; }
    public Boolean IfExistingBatchCreateNew { get; set; }
    public Boolean RequireBatchApproval { get; set; }
    public string BatchApprovalPassword { get; set; }
   

}