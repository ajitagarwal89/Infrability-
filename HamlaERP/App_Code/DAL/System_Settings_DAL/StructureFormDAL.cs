﻿using System;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for StructureFormDAL
/// </summary>
public class StructureFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public StructureFormDAL()
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
            logExcpUIobj.MethodName = "StructureFormDAL()";
            logExcpUIobj.ResourceName = "StructureFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[StructureFormDAL : StructureFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetStructureListById(StructureFormUI structureFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("[SP_Structure_SelectById]", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_StructureId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_StructureId"].Value = structureFormUI.Tbl_StructureId;

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
            logExcpUIobj.MethodName = "getStructureListById()";
            logExcpUIobj.ResourceName = "StructureFormDAL.CS";
            logExcpUIobj.RecordId = structureFormUI.Tbl_StructureId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[StructureFormDAL : getStructureListById] An error occured in the processing of Record Id : " + structureFormUI.Tbl_StructureId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddStructure(StructureFormUI structureFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Structure_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = structureFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = structureFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@StructureCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@StructureCode"].Value = structureFormUI.StructureCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = structureFormUI.Description;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddStructure()";
            logExcpUIobj.ResourceName = "StructureFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[StructureFormDAL : AddStructure] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateStructure(StructureFormUI structureFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Structure_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = structureFormUI.ModifiedBy;
                sqlCmd.Parameters.Add("@tbl_StructureId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_StructureId"].Value = structureFormUI.Tbl_StructureId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = structureFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@StructureCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@StructureCode"].Value = structureFormUI.StructureCode;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = structureFormUI.Description;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateStructure()";
            logExcpUIobj.ResourceName = "StructureFormDAL.CS";
            logExcpUIobj.RecordId = structureFormUI.Tbl_StructureId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[StructureFormDAL : UpdateStructure] An error occured in the processing of Record Id : " + structureFormUI.Tbl_StructureId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteStructure(StructureFormUI structureFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Structure_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_StructureId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_StructureId"].Value = structureFormUI.Tbl_StructureId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteStructure()";
            logExcpUIobj.ResourceName = "StructureFormDAL.CS";
            logExcpUIobj.RecordId = structureFormUI.Tbl_StructureId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[StructureFormDAL : DeleteStructure] An error occured in the processing of Record Id : " + structureFormUI.Tbl_StructureId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}