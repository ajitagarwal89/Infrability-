using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PettyCashListUI
/// </summary>
public class PettyCashListUI
{
    public PettyCashListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_OrganizationId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string PettyCashId { get; set; }

    public string Description { get; set; }

    public Boolean IsInactive { get; set; }

    public string IBAN { get; set; }

    public string Tbl_CurrencyId { get; set; }

    public Decimal CurrentPettyCashBalance { get; set; }

    public Decimal CashAccountBalance { get; set; }

    public string Tbl_GLAccount_CashAccount { get; set; }

    public Int64 NextPettyCashNumber { get; set; }

    public Int64 NextDepositNumber { get; set; }

    public string AccountNumber { get; set; }

    public string DuplicateChequeNumber { get; set; }

    public string OverrideChequeNumber { get; set; }

    public string Tbl_PettyCashId { get; set; }
    public string Search { get; set; }
}