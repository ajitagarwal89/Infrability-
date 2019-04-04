using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeFormUI
/// </summary>
public class EmployeeFormUI
{
    public EmployeeFormUI()
    {
        //
        // TODO: Add constructor logic here
        //

    }
    public string Tbl_EmployeeId {get; set; }
    public DateTime CreatedOn {get; set; }
    public Int64 CreatedOn_Hijri {get; set; }
    public string CreatedBy {get; set; }
    public DateTime ModifiedOn {get; set; }
    public Int64 ModifiedOn_Hijri {get; set; }
    public string ModifiedBy {get; set; }
    public string Tbl_OrganizationId {get; set; }
    public string EmployeeCode {get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Contact { get; set; }
    public int Opt_EmployeeNationalType { get; set; }
    public string IqamaBathaqaNumber { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Tbl_CountryId { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string FaxNo { get; set; }
    public string Email { get; set; }
    public string Tbl_HR_DivisionId { get; set; }
    public string Tbl_HR_DepartmentId { get; set; }
    public string Tbl_HR_PositionId { get; set; }
    public string Tbl_HR_BranchId { get; set; }
    public string Tbl_HR_SupervisorId { get; set; }
    public DateTime SeniorityDate { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime AdjustedHireDate { get; set; }
    public DateTime LastWorkingDay { get; set; }
    public DateTime InactivatedDate { get; set; }
    public string Reason { get; set; }
    public string Tbl_Country_Nationality { get; set; }
    public string Name {get; set; }
    public string ShortName {get; set; }
    public string ChequeName { get; set; }
    public int HRStatus { get; set; }
    public int opt_EmploymentType { get; set; }
    public DateTime DOB { get; set; }
    public int Gender { get; set; }
    public int MaritalStatus { get; set; }
    public int WorkHoursPerYear { get; set; }
    public string PassportNumber { get; set; }
    public DateTime PassportExp { get; set; }
    public DateTime IqamaBathaqaExp { get; set; }
    public string Search { get; set; }

    public int InvoiceType { get; set; }

}