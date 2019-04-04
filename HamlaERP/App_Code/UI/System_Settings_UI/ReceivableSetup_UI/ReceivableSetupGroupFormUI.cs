using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReceivableSetupGroupFormUI
/// </summary>
public class ReceivableSetupGroupFormUI
{
    public ReceivableSetupGroupFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_ReceivableSetupGroupId { get; set; }

    public string Tbl_ReceivableSetupId { get; set; }


    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string Tbl_ReceivableSetupGroupId_Self { get; set; }
    public string Description { get; set; }
     public Boolean ISDefault { get; set; }
    public Boolean ISBalanceType { get; set; }
    public Int32 opt_MinimumPayment { get; set; }
    public decimal MinimumPayment  { get; set; }
    public Int32 opt_CreditLimit  { get; set; }
     public decimal CreditLimit  { get; set; }
    public Int32 opt_WriteOff  { get; set; }
    public decimal WriteOff  { get; set; }
    public decimal TradeDiscount  { get; set; }
    public string  Tbl_PaymentTermsId  { get; set; }
    public Boolean IsCalendar  { get; set; }
    public Boolean IsFiscalYear  { get; set; }
    public Boolean IsTransaction  { get; set; }
    public Boolean IsDistribution  { get; set; }
    public Int32 Opt_StatementCycle  { get; set; }
    public string Search { get; set; }





}