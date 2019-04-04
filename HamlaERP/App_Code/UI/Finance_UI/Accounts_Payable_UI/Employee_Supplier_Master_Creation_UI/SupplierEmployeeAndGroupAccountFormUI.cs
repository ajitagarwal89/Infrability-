using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplierEmployeeAndGroupAccountFormUI
/// </summary>
public class SupplierEmployeeAndGroupAccountFormUI
{
    public SupplierEmployeeAndGroupAccountFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_SupplierEmployeeAndGroupAccountId { get; set; }


    public DateTime CreatedOn { get; set; }


    public Int64 CreatedOn_Hijri { get; set; }


    public string CreatedBy { get; set; }


    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }


    public string Tbl_SupplierEmployeeGroupId { get; set; }

    public int Opt_AccountType { get; set; }

    public Boolean PaymentMode { get; set; }

    public string Tbl_GLAccountId_Cash { get; set; }


    public string Tbl_GLAccountId_AccountPayable { get; set; }


    public string Tbl_GLAccountId_Purchase { get; set; }

    public string Tbl_GLAccountId_TradeDiscount { get; set; }


    public string Tbl_GLAccountId_Freight { get; set; }


    public string Tbl_GLAccountId_AccruedPurchase { get; set; }

    public string Search { get; set; }
}