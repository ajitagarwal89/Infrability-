using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PayableSetupGroupFormUI
/// </summary>
public class PayableSetupGroupFormUI
{
    public PayableSetupGroupFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_PayableSetupGroupId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string tbl_PayableSetup { get; set; }
    public string tbl_PayableSetupGroupId_Self { get; set; }
    public Boolean Default { get; set; }
    public string Description { get; set; }
    public string tbl_CurrencyId { get; set; }
    public string tbl_PaymentTermsId { get; set; }
    public string PaymentPriority { get; set; }
    public string MinimumOrder { get; set; }
    public string TradeDiscount { get; set; }
    public int Opt_MinimumPayment { get; set; }
    public int Opt_MaximumInvoiceAmt { get; set; }
    public int Opt_CreditLimit { get; set; }
    public int Opt_WriteOff { get; set; }
    public Boolean CalenderYear { get; set; }
    public Boolean Transaction { get; set; }
    public Boolean FiscalYear { get; set; }
    public Boolean Distribution { get; set; }
   



}