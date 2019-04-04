using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserFormUI
/// </summary>
public class UserFormUI
{
	public UserFormUI()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public string Tbl_UserId { get; set; }

    public DateTime CreatedOn { get; set; }

    public Int64 CreatedOn_Hijri { get; set; }

    public string CreatedBy { get; set; }

    public DateTime ModifiedOn { get; set; }

    public Int64 ModifiedOn_Hijri { get; set; }

    public string ModifiedBy { get; set; }

    public string Tbl_OrganizationId { get; set; }
    public string FullName { get; set; }
    public string EmployeeCode { get; set; }
    public DateTime DOB { get; set; }
    public Int64 DOB_Hijri { get; set; }
    public string PermanentAddress { get; set; }
    public string CorrespondanceAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Tbl_CountryId { get; set; }
    public string PhoneNo { get; set; }
    public string FaxNo { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public int Opt_Department { get; set; }
    public DateTime DateOfJoining { get; set; }
    public Int64 DateOfJoining_Hijri { get; set; }
    public int Opt_Designation { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public Boolean IsActive { get; set; }
    public Boolean IsLocked { get; set; }
    public int FailedLoginCount { get; set; }
    public DateTime LastLogin { get; set; }
    public Int64 LastLogin_Hijri { get; set; }
    public int Opt_SystemRoleType { get; set; }
    public Boolean IsDeleted { get; set; }
    public DateTime DeletedOn { get; set; }
    public Int64 DeletedOn_Hijri { get; set; }
    public string DeletedBy { get; set; }
    public string ReasonForDeletion { get; set; }
    public Boolean ChangePassword { get; set; }

    public string Search { get; set; }
}