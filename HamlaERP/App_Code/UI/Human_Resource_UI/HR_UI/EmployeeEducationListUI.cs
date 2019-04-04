using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeEducationListUI
/// </summary>
public class EmployeeEducationListUI
{
    public EmployeeEducationListUI()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string Tbl_EmployeeEducationId { get; set; }
    public string Tbl_OrganizationId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Int64 CreatedOn_Hijri { get; set; }
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public Int64 ModifiedOn_Hijri { get; set; }
    public string Tbl_EmployeeId { get; set; }
    public string School { get; set; }
    public string Major { get; set; }
    public string Year { get; set; }
    public string Degree { get; set; }
    public decimal GPA { get; set; }
    public string Note { get; set; }
    public string Search { get; set; }
}