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
/// Summary description for POBasedInvoiceDetailsFormDAL
/// </summary>
public class POBasedInvoiceDetailsFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public POBasedInvoiceDetailsFormDAL()
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
            logExcpUIobj.MethodName = "POBasedInvoiceDetailsFormDAL()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDetailsFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[POBasedInvoiceDetailsFormDAL : POBasedInvoiceDetailsFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public DataTable GetPOBasedInvoiceDetailsListById(POBasedInvoiceDetailsFormUI pOBasedInvoiceDetailsFormUI)
    {


        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDetails_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceDetailsId"].Value = pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId;

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
                audit_IUD.WebServiceSelectInsert("tbl_POBasedInvoiceDetails", pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPOBasedInvoiceDetailsListById()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDetailsFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDetailsFormDAL : GetPOBasedInvoiceDetailsListById] An error occured in the processing of Record Id : " + pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPOBasedInvoiceDetails(POBasedInvoiceDetailsFormUI pOBasedInvoiceDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDetails_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = pOBasedInvoiceDetailsFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pOBasedInvoiceDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceId"].Value = pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceId;

                sqlCmd.Parameters.Add("@tbl_POId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POId"].Value = pOBasedInvoiceDetailsFormUI.Tbl_POId;

                sqlCmd.Parameters.Add("@UOM", SqlDbType.NVarChar);
                sqlCmd.Parameters["@UOM"].Value = pOBasedInvoiceDetailsFormUI.UOM;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = pOBasedInvoiceDetailsFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = pOBasedInvoiceDetailsFormUI.Tbl_LocationId;

                sqlCmd.Parameters.Add("@QuantityInvoice", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityInvoice"].Value = pOBasedInvoiceDetailsFormUI.QuantityInvoice;

                sqlCmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@UnitCost"].Value = pOBasedInvoiceDetailsFormUI.UnitCost;

                sqlCmd.Parameters.Add("@ExtendedCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExtendedCost"].Value = pOBasedInvoiceDetailsFormUI.ExtendedCost;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceDetailsId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_POBasedInvoiceDetailsId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recordID = Convert.ToString(sqlCmd.Parameters["@tbl_POBasedInvoiceDetailsId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_POBasedInvoiceDetails";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(pOBasedInvoiceDetailsFormUI);
                    audit_IUD.WebServiceInsert(pOBasedInvoiceDetailsFormUI.Tbl_OrganizationId, tableName, recordID, pOBasedInvoiceDetailsFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "POBasedInvoiceDetailsFormDAL()";
            logExcpUIobj.ResourceName = "AssetFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDetailsFormDAL : AddPOBasedInvoiceDetails] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePOBasedInvoiceDetails(POBasedInvoiceDetailsFormUI pOBasedInvoiceDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDetails_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = pOBasedInvoiceDetailsFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pOBasedInvoiceDetailsFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceDetailsId"].Value = pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceId"].Value = pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceId;

                sqlCmd.Parameters.Add("@tbl_POId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POId"].Value = pOBasedInvoiceDetailsFormUI.Tbl_POId;

                sqlCmd.Parameters.Add("@UOM", SqlDbType.NVarChar);
                sqlCmd.Parameters["@UOM"].Value = pOBasedInvoiceDetailsFormUI.UOM;

                sqlCmd.Parameters.Add("@Description", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Description"].Value = pOBasedInvoiceDetailsFormUI.Description;

                sqlCmd.Parameters.Add("@tbl_LocationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_LocationId"].Value = pOBasedInvoiceDetailsFormUI.Tbl_LocationId;

                sqlCmd.Parameters.Add("@QuantityInvoice", SqlDbType.Decimal);
                sqlCmd.Parameters["@QuantityInvoice"].Value = pOBasedInvoiceDetailsFormUI.QuantityInvoice;

                sqlCmd.Parameters.Add("@UnitCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@UnitCost"].Value = pOBasedInvoiceDetailsFormUI.UnitCost;

                sqlCmd.Parameters.Add("@ExtendedCost", SqlDbType.Decimal);
                sqlCmd.Parameters["@ExtendedCost"].Value = pOBasedInvoiceDetailsFormUI.ExtendedCost;


                result = sqlCmd.ExecuteNonQuery();

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(pOBasedInvoiceDetailsFormUI);
                    audit_IUD.WebServiceUpdate(pOBasedInvoiceDetailsFormUI.Tbl_OrganizationId, "tbl_POBasedInvoiceDetails", pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId, pOBasedInvoiceDetailsFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePOBasedInvoiceDetails()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDetailsFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDetailsFormDAL : UpdatePOBasedInvoiceDetails] An error occured in the processing of Record Id : " + pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePOBasedInvoiceDetails(POBasedInvoiceDetailsFormUI pOBasedInvoiceDetailsFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_POBasedInvoiceDetails_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POBasedInvoiceDetailsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POBasedInvoiceDetailsId"].Value = pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_POBasedInvoiceDetails", pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePOBasedInvoiceDetails()";
            logExcpUIobj.ResourceName = "POBasedInvoiceDetailsFormDAL.CS";
            logExcpUIobj.RecordId = pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POBasedInvoiceDetailsFormDAL : DeletePOBasedInvoiceDetails] An error occured in the processing of Record Id : " + pOBasedInvoiceDetailsFormUI.Tbl_POBasedInvoiceDetailsId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}