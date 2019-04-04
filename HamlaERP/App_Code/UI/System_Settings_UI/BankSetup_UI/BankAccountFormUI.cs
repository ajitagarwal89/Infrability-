using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BankAccountFormUI
/// </summary>
public class BankAccountFormUI
{
    public BankAccountFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_BankAccountId { get; set; }


    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string RowVersion { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string BankAccountId { get; set; }

    public string Description { get; set; }

    public Boolean IsInactive { get; set; }

    public string IBAN { get; set; }

    public string Tbl_CurrencyId { get; set; }

    public Decimal CurrentChequebookBalance { get; set; }

    public Decimal CashAccountBalance { get; set; }

    public string Tbl_GLAccount_CashAccount { get; set; }

    public Int64 NextChequeNumber { get; set; }

    public Int64 NextDepositNumber { get; set; }

    public Decimal LastReconciledBalance { get; set; }

    public DateTime LastReconciledDate { get; set; }

    public Int64 LastReconciledDate_Hijri { get; set; }

    public string AccountNumber { get; set; }

    public string Tbl_BankId { get; set; }

    public string DuplicateChequeNumber { get; set; }

    public string OverrideChequeNumber { get; set; }

    public bool EnableAudit { get; set; }

}