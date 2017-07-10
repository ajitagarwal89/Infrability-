﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DownPaymentFromCustomerApplyList_UI
/// </summary>
public class DownPaymentFromCustomerApplyListUI
{
    public DownPaymentFromCustomerApplyListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_DownPaymentFromCustomerApplyId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Search { get; set; }
    public string Tbl_DownPaymentFromCustomerId { get; set; }
    public DateTime ApplyDate { get; set; }
    public DateTime ApplyDate_Hijri { get; set; }
    public string Tbl_SourceDocumentId { get; set; }
    public int opt_DocumentType { get; set; }
    public string Tbl_ApplyToDocument { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime DueDate_Hijri { get; set; }
    public Decimal RemainingAmount { get; set; }
    public Decimal ApplyAmount { get; set; }
    public int opt_Type { get; set; }
    public Decimal OrignalDocumentAmount { get; set; }
    public DateTime DiscountDate { get; set; }
    public DateTime DiscountDate_Hijri { get; set; }
    public string Tbl_CurrencyId_ApplyToCurrency { get; set; }


}