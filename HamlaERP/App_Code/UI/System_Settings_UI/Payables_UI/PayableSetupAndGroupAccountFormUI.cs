using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PayableSetupGroupAccountFormUI
/// </summary>
public class PayableSetupAndGroupAccountFormUI
{
    public PayableSetupAndGroupAccountFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string tbl_PayableSetupAndGroupAccountId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string tbl_PayableSetup { get; set; }
    public string tbl_PayableSetupGroupId { get; set; }
    public string tbl_ChequeBookId { get; set; }
    public int Opt_AccountType { get; set; }
    public Boolean PaymentMode { get; set; }
    public string tbl_GLAccountId_Cash { get; set; }
    public string tbl_GLAccountId_AccountReceivable { get; set; }
    public string tbl_GLAccountId_Sales { get; set; }
    public string tbl_GLAccountId_CostOfSales { get; set; }
    public string tbl_GLAccountId_Inventory { get; set; }
    public string tbl_GLAccountId_AccuralDifferedA_C { get; set; }


}