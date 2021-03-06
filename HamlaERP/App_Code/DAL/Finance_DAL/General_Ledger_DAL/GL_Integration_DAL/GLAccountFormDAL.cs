﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for GLAccountFormDAL
/// </summary>
public class GLAccountFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public GLAccountFormDAL()
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
            logExcpUIobj.MethodName = "GLAccountFormDAL()";
            logExcpUIobj.ResourceName = "GLAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[GLAccountFormDAL : GLAccountFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetGLAccountListById(GLAccountFormUI gLAccountFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccount_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = gLAccountFormUI.Tbl_GLAccountId;

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
            logExcpUIobj.MethodName = "getGLAccountListById()";
            logExcpUIobj.ResourceName = "GLAccountFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountFormUI.Tbl_GLAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormDAL : getGLAccountListById] An error occured in the processing of Record Id : " + gLAccountFormUI.Tbl_GLAccountId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddGLAccount(GLAccountFormUI gLAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccount_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = gLAccountFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@AccountNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AccountNumber"].Value = gLAccountFormUI.AccountNumber;

                sqlCmd.Parameters.Add("@IsActive", SqlDbType.Bit);
                sqlCmd.Parameters["@IsActive"].Value = gLAccountFormUI.IsActive;

                sqlCmd.Parameters.Add("@AllowAccountEntry", SqlDbType.Bit);
                sqlCmd.Parameters["@AllowAccountEntry"].Value = gLAccountFormUI.AllowAccountEntry;

                sqlCmd.Parameters.Add("@tbl_GLAccountCategoryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountCategoryId"].Value = gLAccountFormUI.Tbl_GLAccountCategoryId;

                sqlCmd.Parameters.Add("@PostingType", SqlDbType.Bit);
                sqlCmd.Parameters["@PostingType"].Value = gLAccountFormUI.PostingType;

                sqlCmd.Parameters.Add("@TypicalBalance", SqlDbType.Bit);
                sqlCmd.Parameters["@TypicalBalance"].Value = gLAccountFormUI.TypicalBalance;

                sqlCmd.Parameters.Add("@AppearInFinance", SqlDbType.Bit);
                sqlCmd.Parameters["@AppearInFinance"].Value = gLAccountFormUI.AppearInFinance;

                sqlCmd.Parameters.Add("@AppearInHR", SqlDbType.Bit);
                sqlCmd.Parameters["@AppearInHR"].Value = gLAccountFormUI.AppearInHR;

                sqlCmd.Parameters.Add("@AppearInProcurement", SqlDbType.Bit);
                sqlCmd.Parameters["@AppearInProcurement"].Value = gLAccountFormUI.AppearInProcurement;

                sqlCmd.Parameters.Add("@AppearInSystemSettingss", SqlDbType.Bit);
                sqlCmd.Parameters["@AppearInSystemSettingss"].Value = gLAccountFormUI.AppearInSystemSettingss;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddGLAccount()";
            logExcpUIobj.ResourceName = "GLAccountFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormDAL : AddGLAccount] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateGLAccount(GLAccountFormUI gLAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccount_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = gLAccountFormUI.Tbl_GLAccountId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = gLAccountFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = gLAccountFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@AccountNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@AccountNumber"].Value = gLAccountFormUI.AccountNumber;

                sqlCmd.Parameters.Add("@IsActive", SqlDbType.Bit);
                sqlCmd.Parameters["@IsActive"].Value = gLAccountFormUI.IsActive;

                sqlCmd.Parameters.Add("@AllowAccountEntry", SqlDbType.Bit);
                sqlCmd.Parameters["@AllowAccountEntry"].Value = gLAccountFormUI.AllowAccountEntry;

                sqlCmd.Parameters.Add("@tbl_GLAccountCategoryId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountCategoryId"].Value = gLAccountFormUI.Tbl_GLAccountCategoryId;

                sqlCmd.Parameters.Add("@PostingType", SqlDbType.Bit);
                sqlCmd.Parameters["@PostingType"].Value = gLAccountFormUI.PostingType;

                sqlCmd.Parameters.Add("@TypicalBalance", SqlDbType.Bit);
                sqlCmd.Parameters["@TypicalBalance"].Value = gLAccountFormUI.TypicalBalance;

                sqlCmd.Parameters.Add("@AppearInFinance", SqlDbType.Bit);
                sqlCmd.Parameters["@AppearInFinance"].Value = gLAccountFormUI.AppearInFinance;

                sqlCmd.Parameters.Add("@AppearInHR", SqlDbType.Bit);
                sqlCmd.Parameters["@AppearInHR"].Value = gLAccountFormUI.AppearInHR;

                sqlCmd.Parameters.Add("@AppearInProcurement", SqlDbType.Bit);
                sqlCmd.Parameters["@AppearInProcurement"].Value = gLAccountFormUI.AppearInProcurement;

                sqlCmd.Parameters.Add("@AppearInSystemSettingss", SqlDbType.Bit);
                sqlCmd.Parameters["@AppearInSystemSettingss"].Value = gLAccountFormUI.AppearInSystemSettingss;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateGLAccount()";
            logExcpUIobj.ResourceName = "GLAccountFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountFormUI.Tbl_GLAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormDAL : UpdateGLAccount] An error occured in the processing of Record Id : " + gLAccountFormUI.Tbl_GLAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteGLAccount(GLAccountFormUI gLAccountFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_GLAccount_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_GLAccountId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_GLAccountId"].Value = gLAccountFormUI.Tbl_GLAccountId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteGLAccount()";
            logExcpUIobj.ResourceName = "GLAccountFormDAL.CS";
            logExcpUIobj.RecordId = gLAccountFormUI.Tbl_GLAccountId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[GLAccountFormDAL : DeleteGLAccount] An error occured in the processing of Record Id : " + gLAccountFormUI.Tbl_GLAccountId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}