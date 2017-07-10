using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerAndGroupAccountListUI
/// </summary>
public class CustomerAndGroupAccountListUI
{
	public CustomerAndGroupAccountListUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Tbl_CustomerAndGroupAccountId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string Tbl_CustomerGroupId { get; set; }

    public string Tbl_ChequeBookId { get; set; }

    public int Opt_AccountType { get; set; }

    public Boolean PaymentMode { get; set; }

    public string Tbl_GLAccountId_Cash { get; set; }

    public string Tbl_GLAccountId_AccountReceivable { get; set; }
    public string Tbl_GLAccountId_Sales { get; set; }

    public string Tbl_GLAccountId_CostOfSales { get; set; }

    public string Tbl_GLAccountId_Inventory { get; set; }

    public string Tbl_GLAccountId_AccuralDifferedA_C { get; set; }

    public string Search { get; set; }
}