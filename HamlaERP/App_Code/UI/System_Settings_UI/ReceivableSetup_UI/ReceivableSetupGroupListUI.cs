using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReceivableSetupGroupListUI
/// </summary>
public class ReceivableSetupGroupListUI
{
    public ReceivableSetupGroupListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
   
    public string Tbl_ReceivableSetupGroupId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string Tbl_CustomerId { get; set; }
    public string Description { get; set; }

    public Int32 ISBalanceType { get; set; }
    public Int32 IsMinimumPayment { get; set; }
    public decimal MinimumPayment { get; set; }
    public Int32 IsCreditLimit { get; set; }
    public decimal CreditLimit { get; set; }
    public Int32 IsWriteOff { get; set; }
    public decimal WriteOff { get; set; }
    public decimal TradeDiscount { get; set; }
    public string Tbl_PaymentTermsId { get; set; }
    public Int32 IsCalendar { get; set; }
    public Int32 IsFiscalYear { get; set; }
    public Int32 IsTransaction { get; set; }
    public Int32 IsDistribution { get; set; }
    public Int32 Opt_StatementCycle { get; set; }
    public string Search { get; set; }
}