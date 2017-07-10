using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FiscalPeriodDetailsListUI
/// </summary>
public class FiscalPeriodDetailsListUI
{

    public FiscalPeriodDetailsListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_FiscalPeriodDetailsId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public string Tbl_FiscalPeriodId { get; set; }

    public int Period { get; set; }

    public string PeriodName { get; set; }

    public DateTime PeriodDate { get; set; }

    public Int64 PeriodDate_Hijri { get; set; }

    public Boolean ClosingFinancial { get; set; }

    public Boolean ClosingHR { get; set; }

    public Boolean ClosingProcurement { get; set; }

    public string Search { get; set; }

}