using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeDependentsListUI
/// </summary>
public class EmployeeDependentsListUI
{
    public EmployeeDependentsListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_EmployeeDependentsId { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string Tbl_EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime DOB { get; set; }
    public string Tbl_HR_DepartmentId { get; set; }
    public int Gender { get; set; }
    public int Opt_Relationship { get; set; }
    public string Tbl_CountryId { get; set; }
    public string HomePhone { get; set; }
    public string WorkPhone { get; set; }
    public string Ext { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Search { get; set; }
}