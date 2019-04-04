using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using log4net;

/// <summary>
/// Summary description for UserProfileFormDAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class UserProfileFormDAL
    {
        string connectionString = string.Empty;
        int commandTimeout = 0;
        SystemSecurityLogExceptionUI logExcpUIobj = new SystemSecurityLogExceptionUI();
        SystemSecurityLogException logExcpDALobj = new SystemSecurityLogException();
        protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserProfileFormDAL()
        {
            try
            {
                SecuritySystemConfigurations objConfig = new SecuritySystemConfigurations();
                objConfig.InitilizeConnectionString();
                connectionString = objConfig.connectionString;
                commandTimeout = Convert.ToInt32(objConfig.commandTimeout);
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "UserProfileFormDAL()";
                logExcpUIobj.ResourceName = "UserProfileFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                throw new Exception("[UserProfileFormDAL : UserProfileFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
            }
        }

        public int AddUser(UserProfileFormUI userProfileFormUI, ref int newUserId)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSystemNewUserInsert", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@IsActive", SqlDbType.Int);
                    sqlCmd.Parameters["@IsActive"].Value = userProfileFormUI.IsActive;

                    sqlCmd.Parameters.Add("@IsLocked", SqlDbType.Int);
                    sqlCmd.Parameters["@IsLocked"].Value = userProfileFormUI.IsLocked;

                    sqlCmd.Parameters.Add("@IsDeleted", SqlDbType.Int);
                    sqlCmd.Parameters["@IsDeleted"].Value = userProfileFormUI.IsDeleted;

                    sqlCmd.Parameters.Add("@FailedLoginCount", SqlDbType.Int);
                    sqlCmd.Parameters["@FailedLoginCount"].Value = userProfileFormUI.FailedLoginCount;

                    sqlCmd.Parameters.Add("@UserId", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@UserId"].Value = userProfileFormUI.UserId;

                    sqlCmd.Parameters.Add("@Password", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@Password"].Value = userProfileFormUI.Password;

                    sqlCmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@EmailAddress"].Value = userProfileFormUI.Email;

                    sqlCmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@FirstName"].Value = userProfileFormUI.FirstName;

                    sqlCmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@LastName"].Value = userProfileFormUI.LastName;

                    sqlCmd.Parameters.Add("@Phone", SqlDbType.VarChar, 20);
                    sqlCmd.Parameters["@Phone"].Value = userProfileFormUI.Phone;

                    sqlCmd.Parameters.Add("@OrgCode", SqlDbType.Int);
                    sqlCmd.Parameters["@OrgCode"].Value = userProfileFormUI.OrganizationCode;

                    sqlCmd.Parameters.Add("@Department", SqlDbType.Int);
                    sqlCmd.Parameters["@Department"].Value = userProfileFormUI.Department;

                    sqlCmd.Parameters.Add("@DateOfBirth", SqlDbType.VarChar, 10);
                    sqlCmd.Parameters["@DateOfBirth"].Value = userProfileFormUI.DateofBirth;

                    sqlCmd.Parameters.Add("@DateOfJoining", SqlDbType.DateTime);
                    sqlCmd.Parameters["@DateOfJoining"].Value = userProfileFormUI.DateofJoining;

                    sqlCmd.Parameters.Add("@PermanentAddress", SqlDbType.VarChar, 150);
                    sqlCmd.Parameters["@PermanentAddress"].Value = userProfileFormUI.PermanentAddress;

                    sqlCmd.Parameters.Add("@CorrespondanceAddress", SqlDbType.VarChar, 150);
                    sqlCmd.Parameters["@CorrespondanceAddress"].Value = userProfileFormUI.CorrespondenceAddress;

                    sqlCmd.Parameters.Add("@EducationQaulification", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@EducationQaulification"].Value = userProfileFormUI.EducationQualification;

                    sqlCmd.Parameters.Add("@Designation", SqlDbType.Int);
                    sqlCmd.Parameters["@Designation"].Value = userProfileFormUI.Designation;

                    sqlCmd.Parameters.Add("@CreatedBySystemUser", SqlDbType.Int);
                    sqlCmd.Parameters["@CreatedBySystemUser"].Value = userProfileFormUI.CreatedBySystemUser;

                    sqlCmd.Parameters.Add("@CreatedOnDate", SqlDbType.DateTime);
                    sqlCmd.Parameters["@CreatedOnDate"].Value = userProfileFormUI.CreatedOn;

                    sqlCmd.Parameters.Add("@UpdatedOnDate", SqlDbType.DateTime);
                    sqlCmd.Parameters["@UpdatedOnDate"].Value = userProfileFormUI.UpdatedOn;

                    sqlCmd.Parameters.Add("@SystemUser", SqlDbType.Int);
                    sqlCmd.Parameters["@SystemUser"].Direction = ParameterDirection.Output;

                    result = sqlCmd.ExecuteNonQuery();

                    if (result == -1)
                    {
                        newUserId = Convert.ToInt32(sqlCmd.Parameters["@SystemUser"].Value.ToString());
                    }
                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "AddUser()";
                logExcpUIobj.ResourceName = "UserProfileFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[UserProfileFormDAL : AddUser] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }
            return result;
        }

        public int UpdateUser(UserProfileFormUI userProfileFormUI, int id)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSystemNewUserUpdate", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@IsActive", SqlDbType.Int);
                    sqlCmd.Parameters["@IsActive"].Value = userProfileFormUI.IsActive;

                    sqlCmd.Parameters.Add("@FailedLoginCount", SqlDbType.Int);
                    sqlCmd.Parameters["@FailedLoginCount"].Value = userProfileFormUI.FailedLoginCount;

                    sqlCmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@EmailAddress"].Value = userProfileFormUI.Email;

                    sqlCmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@FirstName"].Value = userProfileFormUI.FirstName;

                    sqlCmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@LastName"].Value = userProfileFormUI.LastName;

                    sqlCmd.Parameters.Add("@Phone", SqlDbType.VarChar, 20);
                    sqlCmd.Parameters["@Phone"].Value = userProfileFormUI.Phone;

                    sqlCmd.Parameters.Add("@OrgCode", SqlDbType.Int);
                    sqlCmd.Parameters["@OrgCode"].Value = userProfileFormUI.OrganizationCode;

                    sqlCmd.Parameters.Add("@Department", SqlDbType.Int);
                    sqlCmd.Parameters["@Department"].Value = userProfileFormUI.Department;

                    sqlCmd.Parameters.Add("@DateOfBirth", SqlDbType.VarChar, 10);
                    sqlCmd.Parameters["@DateOfBirth"].Value = userProfileFormUI.DateofBirth;

                    sqlCmd.Parameters.Add("@DateOfJoining", SqlDbType.DateTime);
                    sqlCmd.Parameters["@DateOfJoining"].Value = userProfileFormUI.DateofJoining;

                    sqlCmd.Parameters.Add("@PermanentAddress", SqlDbType.VarChar, 150);
                    sqlCmd.Parameters["@PermanentAddress"].Value = userProfileFormUI.PermanentAddress;

                    sqlCmd.Parameters.Add("@CorrespondanceAddress", SqlDbType.VarChar, 150);
                    sqlCmd.Parameters["@CorrespondanceAddress"].Value = userProfileFormUI.CorrespondenceAddress;

                    sqlCmd.Parameters.Add("@EducationQaulification", SqlDbType.VarChar, 50);
                    sqlCmd.Parameters["@EducationQaulification"].Value = userProfileFormUI.EducationQualification;

                    sqlCmd.Parameters.Add("@Designation", SqlDbType.Int);
                    sqlCmd.Parameters["@Designation"].Value = userProfileFormUI.Designation;

                    sqlCmd.Parameters.Add("@UpdatedOnDate", SqlDbType.DateTime);
                    sqlCmd.Parameters["@UpdatedOnDate"].Value = userProfileFormUI.UpdatedOn;

                    sqlCmd.Parameters.Add("@SystemUser", SqlDbType.Int);
                    sqlCmd.Parameters["@SystemUser"].Value = id;

                    result = sqlCmd.ExecuteNonQuery();

                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "UpdateUser()";
                logExcpUIobj.ResourceName = "UserProfileFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[UserProfileFormDAL : UpdateUser] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public int DeleteUser(UserProfileFormUI userProfileFormUI, int id)
        {
            int result = 0;
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SupportCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("prSystemNewUserDelete", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    sqlCmd.Parameters.Add("@IsDeleted", SqlDbType.Int);
                    sqlCmd.Parameters["@IsDeleted"].Value = userProfileFormUI.IsDeleted;

                    sqlCmd.Parameters.Add("@DeletedOnDate", SqlDbType.DateTime);
                    sqlCmd.Parameters["@DeletedOnDate"].Value = userProfileFormUI.DeletedOn;

                    sqlCmd.Parameters.Add("@SystemUser", SqlDbType.Int);
                    sqlCmd.Parameters["@SystemUser"].Value = id;

                    result = sqlCmd.ExecuteNonQuery();


                    sqlCmd.Dispose();
                    SupportCon.Close();
                }
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "DeleteUser()";
                logExcpUIobj.ResourceName = "UserProfileFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[UserProfileFormDAL : DeleteUser] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
            }

            return result;
        }

        public DataTable GetOrganisation()
        {
            DataSet ds = new DataSet();
            DataTable dtbl = new DataTable();
            try
            {
                using (SqlConnection SupportCon = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCmd = new SqlCommand("prOrganizationDetailsSelect", SupportCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.CommandTimeout = commandTimeout;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                    {
                        adapter.Fill(ds);
                    }
                }
                if (ds.Tables.Count > 0)
                    dtbl = ds.Tables[0];
            }
            catch (Exception exp)
            {
                logExcpUIobj.MethodName = "getOrganisation()";
                logExcpUIobj.ResourceName = "UserProfileFormDAL.CS";
                logExcpUIobj.RecordId = "";
                logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
                logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

                log.Error("[UserProfileFormDAL : getOrganisation] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");

            }
            finally
            {
                ds.Dispose();
            }
            return dtbl;
        }
    }
}