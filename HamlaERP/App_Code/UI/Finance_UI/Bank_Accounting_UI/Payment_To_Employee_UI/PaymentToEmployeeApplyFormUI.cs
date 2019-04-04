using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaymentToEmployeeApplyFormUI
/// </summary>
public class PaymentToEmployeeApplyFormUI
{
    public PaymentToEmployeeApplyFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_PaymentToEmployeeApplyId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Search { get; set; }
    public string Tbl_PaymentToEmployeeId { get; set; }
    
    public string Tbl_ApplyToDocument { get; set; }
    public int opt_ApplyToDocumentType { get; set; }
    public DateTime DueDate { get; set; }
    public Decimal RemainingAmount { get; set; }
    public Decimal ApplyAmount { get; set; }
    public int opt_Type { get; set; }
    public Decimal OrignalDocumentAmount { get; set; }
    public DateTime DiscountDate { get; set; }

}