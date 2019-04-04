using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserProfileFormUI
/// </summary>
namespace Infra.SecuritySystem
{
    public class UserProfileFormUI
    {
        public UserProfileFormUI()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        int isActive;
        int isLocked;
        int isDeleted;
        DateTime deleteOn;
        string reasonForDeletion;
        int failedLoginCount;
        DateTime lastLogin;
        int systemProfile;
        string email;
        string userId;
        string password;
        string firstName;
        string lastName;
        string phone;
        string extension;
        string fax;
        int department;
        DateTime dateOfJoining;
        string dateOfBirth;
        string permanentAddress;
        string correspondanceAddress;
        string educationQualification;
        int designation;
        int changePassword;
        string organizationCode;
        int createdBySystemUser;
        DateTime createdOn = DateTime.Now;
        DateTime updatedOn = DateTime.Now;
        int iid;

        public int IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public int IsLocked
        {
            get { return isLocked; }
            set { isLocked = value; }
        }

        public int IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }

        public int FailedLoginCount
        {
            get { return failedLoginCount; }
            set { failedLoginCount = value; }
        }

        public int SystemProfile
        {
            get { return systemProfile; }
            set { systemProfile = value; }
        }

        public int Department
        {
            get { return department; }
            set { department = value; }
        }

        public int Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        public string OrganizationCode
        {
            get { return organizationCode; }
            set { organizationCode = value; }
        }

        public int ChangePassword
        {
            get { return changePassword; }
            set { changePassword = value; }
        }

        public DateTime DeletedOn
        {
            get { return deleteOn; }
            set { deleteOn = value; }
        }

        public string ReasonForDeletion
        {
            get { return reasonForDeletion; }
            set { reasonForDeletion = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public DateTime DateofJoining
        {
            get { return dateOfJoining; }
            set { dateOfJoining = value; }
        }

        public string DateofBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public DateTime LastLogin
        {
            get { return lastLogin; }
            set { lastLogin = value; }
        }

        public string PermanentAddress
        {
            get { return permanentAddress; }
            set { permanentAddress = value; }
        }

        public string CorrespondenceAddress
        {
            get { return correspondanceAddress; }
            set { correspondanceAddress = value; }
        }

        public string EducationQualification
        {
            get { return educationQualification; }
            set { educationQualification = value; }
        }

        public DateTime CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }

        public DateTime UpdatedOn
        {
            get { return updatedOn; }
            set { updatedOn = value; }
        }

        public int CreatedBySystemUser
        {
            get { return createdBySystemUser; }
            set { createdBySystemUser = value; }
        }

        public int IID
        {
            get { return iid; }
            set { iid = value; }
        }
    }
}