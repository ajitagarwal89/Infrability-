using System;
using System.Data.SqlClient;
using System.Data;
using log4net;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web.SessionState;
using System.Web;
using Finware;
/// <summary>
/// Summary description for UserFormDAL
/// </summary>
public class UserFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public UserFormDAL()
    {
        try
        {
            GlobalConfigurations objConfig = new GlobalConfigurations();
            objConfig.InitilizeConnectionString();
            connectionString = objConfig.connectionString;
            commandTimeout = Convert.ToInt32(objConfig.commandTimeout);
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UserFormDAL()";
            logExcpUIobj.ResourceName = "UserFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[UserFormDAL : UserFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetUserListById(UserFormUI UserFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_User_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_UserId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_UserId"].Value = UserFormUI.Tbl_UserId;

                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    adapter.Fill(ds);
                }
            }
            if (ds.Tables.Count > 0)
                dtbl = ds.Tables[0];
            if (SessionContext.GlobalAuditEnabledStatus == true)
            {
                string selectedValue;
                selectedValue = JsonConvert.SerializeObject(dtbl);
                audit_IUD.WebServiceSelectInsert("tbl_User", UserFormUI.Tbl_UserId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getUserListById()";
            logExcpUIobj.ResourceName = "UserFormDAL.CS";
            logExcpUIobj.RecordId = UserFormUI.Tbl_UserId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[UserFormDAL : getUserListById] An error occured in the processing of Record Id : " + UserFormUI.Tbl_UserId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddUser(UserFormUI UserFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_User_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = UserFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = UserFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@FullName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FullName"].Value = UserFormUI.FullName;

                sqlCmd.Parameters.Add("@EmployeeCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@EmployeeCode"].Value = UserFormUI.EmployeeCode;

                sqlCmd.Parameters.Add("@DOB", SqlDbType.DateTime);
                sqlCmd.Parameters["@DOB"].Value = UserFormUI.DOB;
               
                sqlCmd.Parameters.Add("@PermanentAddress", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PermanentAddress"].Value = UserFormUI.PermanentAddress;

                sqlCmd.Parameters.Add("@CorrespondanceAddress", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CorrespondanceAddress"].Value = UserFormUI.CorrespondanceAddress;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = UserFormUI.City;

                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = UserFormUI.State;

                sqlCmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PostalCode"].Value = UserFormUI.PostalCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = UserFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@PhoneNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PhoneNo"].Value = UserFormUI.PhoneNo;

                sqlCmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FaxNo"].Value = UserFormUI.FaxNo;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = UserFormUI.Mobile;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = UserFormUI.Email;

                sqlCmd.Parameters.Add("@Opt_Department", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Department"].Value = UserFormUI.Opt_Department;

                sqlCmd.Parameters.Add("@DateOfJoining", SqlDbType.DateTime);
                sqlCmd.Parameters["@DateOfJoining"].Value = UserFormUI.DateOfJoining;
                
                sqlCmd.Parameters.Add("@Opt_Designation", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Designation"].Value = UserFormUI.Opt_Designation;

                sqlCmd.Parameters.Add("@UserName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@UserName"].Value = UserFormUI.UserName;

                sqlCmd.Parameters.Add("@Password", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Password"].Value = UserFormUI.Password;

               // sqlCmd.Parameters.Add("@IsActive", SqlDbType.Bit);
               // sqlCmd.Parameters["@IsActive"].Value = UserFormUI.IsActive;

               // sqlCmd.Parameters.Add("@IsLocked", SqlDbType.Bit);
               // sqlCmd.Parameters["@IsLocked"].Value = UserFormUI.IsLocked;

               // sqlCmd.Parameters.Add("@FailedLoginCount", SqlDbType.Int);
               // sqlCmd.Parameters["@FailedLoginCount"].Value = UserFormUI.FailedLoginCount;

               // sqlCmd.Parameters.Add("@LastLogin", SqlDbType.DateTime);
               // sqlCmd.Parameters["@LastLogin"].Value = UserFormUI.LastLogin;

               // sqlCmd.Parameters.Add("@LastLogin_Hijri", SqlDbType.BigInt);
               // sqlCmd.Parameters["@LastLogin_Hijri"].Value = UserFormUI.LastLogin_Hijri;

               // sqlCmd.Parameters.Add("@Opt_SystemRoleType", SqlDbType.TinyInt);
               // sqlCmd.Parameters["@Opt_SystemRoleType"].Value = UserFormUI.Opt_SystemRoleType;

               // sqlCmd.Parameters.Add("@IsDeleted", SqlDbType.Bit);
               // sqlCmd.Parameters["@IsDeleted"].Value = UserFormUI.IsDeleted;

               // sqlCmd.Parameters.Add("@DeletedOn", SqlDbType.DateTime);
               // sqlCmd.Parameters["@DeletedOn"].Value = UserFormUI.DeletedOn;

               // //sqlCmd.Parameters.Add("@DeletedOn_Hijri", SqlDbType.BigInt);
               // //sqlCmd.Parameters["@DeletedOn_Hijri"].Value = UserFormUI.DeletedOn_Hijri;

               //// sqlCmd.Parameters.Add("@DeletedBy", SqlDbType.NVarChar);
               //// sqlCmd.Parameters["@DeletedBy"].Value = UserFormUI.DeletedBy;

               // sqlCmd.Parameters.Add("@ReasonForDeletion", SqlDbType.NVarChar);
               // sqlCmd.Parameters["@ReasonForDeletion"].Value = UserFormUI.ReasonForDeletion;

               // sqlCmd.Parameters.Add("@ChangePassword", SqlDbType.Bit);
               // sqlCmd.Parameters["@ChangePassword"].Value = UserFormUI.ChangePassword;

                sqlCmd.Parameters.Add("@tbl_UserId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_UserId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_UserId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_User";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(UserFormUI);
                    audit_IUD.WebServiceInsert(UserFormUI.Tbl_OrganizationId, tableName, RecoredID, UserFormUI.CreatedBy, newValue);
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
        catch (Exception exp)
        {
              logExcpUIobj.MethodName = "AddUser()";
            logExcpUIobj.ResourceName = "UserFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[UserFormDAL : AddUser] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateUser(UserFormUI UserFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_User_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;


                sqlCmd.Parameters.Add("@tbl_UserId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_UserId"].Value = UserFormUI.Tbl_UserId;


                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = UserFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = UserFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@FullName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FullName"].Value = UserFormUI.FullName;

                sqlCmd.Parameters.Add("@EmployeeCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@EmployeeCode"].Value = UserFormUI.EmployeeCode;

                sqlCmd.Parameters.Add("@DOB", SqlDbType.DateTime);
                sqlCmd.Parameters["@DOB"].Value = UserFormUI.DOB;
                
                sqlCmd.Parameters.Add("@PermanentAddress", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PermanentAddress"].Value = UserFormUI.PermanentAddress;

                sqlCmd.Parameters.Add("@CorrespondanceAddress", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CorrespondanceAddress"].Value = UserFormUI.CorrespondanceAddress;

                sqlCmd.Parameters.Add("@City", SqlDbType.NVarChar);
                sqlCmd.Parameters["@City"].Value = UserFormUI.City;

                sqlCmd.Parameters.Add("@State", SqlDbType.NVarChar);
                sqlCmd.Parameters["@State"].Value = UserFormUI.State;

                sqlCmd.Parameters.Add("@PostalCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PostalCode"].Value = UserFormUI.PostalCode;

                sqlCmd.Parameters.Add("@tbl_CountryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CountryId"].Value = UserFormUI.Tbl_CountryId;

                sqlCmd.Parameters.Add("@PhoneNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PhoneNo"].Value = UserFormUI.PhoneNo;

                sqlCmd.Parameters.Add("@FaxNo", SqlDbType.NVarChar);
                sqlCmd.Parameters["@FaxNo"].Value = UserFormUI.FaxNo;

                sqlCmd.Parameters.Add("@Mobile", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Mobile"].Value = UserFormUI.Mobile;

                sqlCmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Email"].Value = UserFormUI.Email;

                sqlCmd.Parameters.Add("@Opt_Department", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Department"].Value = UserFormUI.Opt_Department;

                sqlCmd.Parameters.Add("@DateOfJoining", SqlDbType.DateTime);
                sqlCmd.Parameters["@DateOfJoining"].Value = UserFormUI.DateOfJoining;

                           sqlCmd.Parameters.Add("@Opt_Designation", SqlDbType.TinyInt);
                sqlCmd.Parameters["@Opt_Designation"].Value = UserFormUI.Opt_Designation;

                sqlCmd.Parameters.Add("@UserName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@UserName"].Value = UserFormUI.UserName;

                sqlCmd.Parameters.Add("@Password", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Password"].Value = UserFormUI.Password;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(UserFormUI);
                    audit_IUD.WebServiceUpdate(UserFormUI.Tbl_OrganizationId, "tbl_User", UserFormUI.Tbl_UserId, UserFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
             logExcpUIobj.MethodName = "UpdateUser()";
            logExcpUIobj.ResourceName = "UserFormDAL.CS";
            logExcpUIobj.RecordId = UserFormUI.Tbl_UserId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[UserFormDAL : UpdateUser] An error occured in the processing of Record Id : " + UserFormUI.Tbl_UserId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteUser(UserFormUI UserFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_User_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_UserId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_UserId"].Value = UserFormUI.Tbl_UserId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_User", UserFormUI.Tbl_UserId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
              logExcpUIobj.MethodName = "DeleteUser()";
            logExcpUIobj.ResourceName = "UserFormDAL.CS";
            logExcpUIobj.RecordId = UserFormUI.Tbl_UserId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[UserFormDAL : DeleteUser] An error occured in the processing of Record Id : " + UserFormUI.Tbl_UserId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}