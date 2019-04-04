using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Audit_SettingListUI
/// </summary>
public class Audit_SettingListUI
{
    public Audit_SettingListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_Audit_SettingId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string SelectedValue { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string TableName { get; set; }
    public string ObjectName { get; set; }
    public bool EnableAudit { get; set; }
    public string Search { get; set; }
}