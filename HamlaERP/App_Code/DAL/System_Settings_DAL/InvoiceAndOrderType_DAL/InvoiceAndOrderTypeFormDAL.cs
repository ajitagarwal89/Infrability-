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
/// Summary description for InvoiceAndOrderTypeFormDAL
/// </summary>
public class InvoiceAndOrderTypeFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    Audit_IUDListDAL audit_IUDListDAL = new Audit_IUDListDAL();
    Audit_IUDListUI audit_IUDListUI = new Audit_IUDListUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public InvoiceAndOrderTypeFormDAL()
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
            logExcpUIobj.MethodName = "InvoiceAndOrderTypeFormDAL()";
            logExcpUIobj.ResourceName = "InvoiceAndOrderTypeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[InvoiceAndOrderTypeFormDAL : InvoiceAndOrderTypeFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetInvoiceAndOrderTypeListById(InvoiceAndOrderTypeFormUI invoiceAndOrderTypeFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_InvoiceAndOrderType_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_InvoiceAndOrderTypeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_InvoiceAndOrderTypeId"].Value = invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId;

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
                audit_IUD.WebServiceSelectInsert("tbl_InvoiceAndOrderType", invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId, selectedValue);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "getInvoiceAndOrderTypeListById()";
            logExcpUIobj.ResourceName = "InvoiceAndOrderTypeFormDAL.CS";
            logExcpUIobj.RecordId = invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[InvoiceAndOrderTypeFormDAL : getInvoiceAndOrderTypeListById] An error occured in the processing of Record Id : " + invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddInvoiceAndOrderType(InvoiceAndOrderTypeFormUI invoiceAndOrderTypeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                
                SqlCommand sqlCmd = new SqlCommand("SP_InvoiceAndOrderType_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = invoiceAndOrderTypeFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = invoiceAndOrderTypeFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = invoiceAndOrderTypeFormUI.Number;

                sqlCmd.Parameters.Add("@Opt_InvoiceAndOrderType", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_InvoiceAndOrderType"].Value = invoiceAndOrderTypeFormUI.Opt_InvoiceAndOrderType;

                sqlCmd.Parameters.Add("@tbl_InvoiceAndOrderTypeId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_InvoiceAndOrderTypeId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_InvoiceAndOrderTypeId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_InvoiceAndOrderType";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(invoiceAndOrderTypeFormUI);
                    audit_IUD.WebServiceInsert(invoiceAndOrderTypeFormUI.Tbl_OrganizationId, tableName, RecoredID, invoiceAndOrderTypeFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddInvoiceAndOrderType()";
            logExcpUIobj.ResourceName = "InvoiceAndOrderTypeFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[InvoiceAndOrderTypeFormDAL : AddInvoiceAndOrderType] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateInvoiceAndOrderType(InvoiceAndOrderTypeFormUI invoiceAndOrderTypeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_InvoiceAndOrderType_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = invoiceAndOrderTypeFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_InvoiceAndOrderTypeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_InvoiceAndOrderTypeId"].Value = invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId;


                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = invoiceAndOrderTypeFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Number", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Number"].Value = invoiceAndOrderTypeFormUI.Number;

                sqlCmd.Parameters.Add("@Opt_InvoiceAndOrderType", SqlDbType.Int);
                sqlCmd.Parameters["@Opt_InvoiceAndOrderType"].Value = invoiceAndOrderTypeFormUI.Opt_InvoiceAndOrderType;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(invoiceAndOrderTypeFormUI);
                    audit_IUD.WebServiceUpdate(invoiceAndOrderTypeFormUI.Tbl_OrganizationId, "tbl_InvoiceAndOrderType", invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId, invoiceAndOrderTypeFormUI.ModifiedBy, newValue);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateInvoiceAndOrderType()";
            logExcpUIobj.ResourceName = "InvoiceAndOrderTypeFormDAL.CS";
            logExcpUIobj.RecordId = invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[InvoiceAndOrderTypeFormDAL : UpdateInvoiceAndOrderType] An error occured in the processing of Record Id : " + invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteInvoiceAndOrderType(InvoiceAndOrderTypeFormUI invoiceAndOrderTypeFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_InvoiceAndOrderType_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_InvoiceAndOrderTypeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_InvoiceAndOrderTypeId"].Value = invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_InvoiceAndOrderType", invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteInvoiceAndOrderType()";
            logExcpUIobj.ResourceName = "InvoiceAndOrderTypeFormDAL.CS";
            logExcpUIobj.RecordId = invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[InvoiceAndOrderTypeFormDAL : DeleteInvoiceAndOrderType] An error occured in the processing of Record Id : " + invoiceAndOrderTypeFormUI.Tbl_InvoiceAndOrderTypeId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}