using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Audit_IUDListUI
/// </summary>
public class Audit_IUDListUI
{
    public Audit_IUDListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Tbl_Audit_IUDId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string tbl_OrganizationId { get; set; }
    public string TableName { get; set; }
    public string Tbl_UserId { get; set; }
    public int Operation { get; set; }
    public string Tbl_RecordId { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public string IPAddress { get; set; }
    public string Browser { get; set; }
    public string Search { get; set; }
}