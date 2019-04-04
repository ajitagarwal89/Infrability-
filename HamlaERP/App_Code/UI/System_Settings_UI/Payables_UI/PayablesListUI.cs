using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PayablesListUI
/// </summary>
public class PayablesListUI
{
	public PayablesListUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string Tbl_PayablesId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public int Opt_PayablesType { get; set; }

    public int Opt_ProcessType { get; set; }

    public string Tbl_Bank_AccountId { get; set; }

    public string Tbl_CardId { get; set; }

    public string DocumentNumber { get; set; }

    public string ReceiptNumber { get; set; }

    public string ChequeNumber { get; set; }

    public DateTime PayablesDate { get; set; }

    public Int64 PayablesDate_Hijri { get; set; }

    public string PaymentNumber { get; set; }

    public string Search { get; set; }
}