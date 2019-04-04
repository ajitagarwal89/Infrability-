using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeContactsFormUI
/// </summary>
public class EmployeeContactsFormUI
{
    public EmployeeContactsFormUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_EmployeeContactsId { get; set; }
    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }
    public string ModifiedBy { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public string Tbl_EmployeeId { get; set; }
    public string Contact { get; set; }
    public string Tbl_CountryId { get; set; }
    public string Relationship { get; set; }
    public string HomePhone { get; set; }
    public string WorkPhone { get; set; }
    public string Ext { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Search { get; set; }

}