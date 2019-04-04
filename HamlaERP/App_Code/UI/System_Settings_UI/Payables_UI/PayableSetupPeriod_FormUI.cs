using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PayableSetupPeriod_FormUI
/// </summary>
public class PayableSetupPeriod_FormUI
{
    public PayableSetupPeriod_FormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_PayableSetupPeriodId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Tbl_PayableSetupId { get; set; }
    public string CurrentPeriod { get; set; }
    public int From { get; set; }
    public int To { get; set; }
   
}