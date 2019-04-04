using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FiscalPeriodFormUI
/// </summary>
public class FiscalPeriodFormUI
{
    public FiscalPeriodFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_FiscalPeriodId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }

    public int Opt_Year { get; set; }

    public DateTime FirstDayDate { get; set; }

    public Int64 FirstDayDate_Hijri { get; set; }

    public DateTime LastDayDate { get; set; }

    public Int64 LastDayDate_Hijri { get; set; }

    public Boolean HistoricalYear { get; set; }

    public int NumberOfPeriod { get; set; }

    public string Search { get; set; }
}