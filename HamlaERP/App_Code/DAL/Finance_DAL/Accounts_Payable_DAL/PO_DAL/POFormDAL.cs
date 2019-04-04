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
/// Summary description for POFormDAL
/// </summary>
public class POFormDAL : IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
  
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public POFormDAL()
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
            logExcpUIobj.MethodName = "POFormDAL()";
            logExcpUIobj.ResourceName = "POFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[POFormDAL : POFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }


    public DataTable GetPOListById(POFormUI pOFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PO_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POId"].Value = pOFormUI.Tbl_POId;

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
                audit_IUD.WebServiceSelectInsert("tbl_PO", pOFormUI.Tbl_POId, selectedValue);
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPOListById()";
            logExcpUIobj.ResourceName = "POFormDAL.CS";
            logExcpUIobj.RecordId = pOFormUI.Tbl_POId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POFormDAL : GetPOListById] An error occured in the processing of Record Id : " + pOFormUI.Tbl_POId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPO(POFormUI  pOFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PO_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = pOFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pOFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = pOFormUI.opt_Type;

                sqlCmd.Parameters.Add("@PONumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PONumber"].Value = pOFormUI.PONumber;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = pOFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@tbl_UserId_Buyer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_UserId_Buyer"].Value = pOFormUI.Tbl_UserId_Buyer;

                sqlCmd.Parameters.Add("@Date", SqlDbType.DateTime);
                sqlCmd.Parameters["@Date"].Value = pOFormUI.Date;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = pOFormUI.Tbl_CurrencyId;


                sqlCmd.Parameters.Add("@AllowSales", SqlDbType.Bit);
                sqlCmd.Parameters["@AllowSales"].Value = pOFormUI.AllowSales;

                sqlCmd.Parameters.Add("@RequisitionDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@RequisitionDate"].Value = pOFormUI.RequisitionDate;

                sqlCmd.Parameters.Add("@PurchaseOrderDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PurchaseOrderDate"].Value = pOFormUI.PurchaseOrderDate;

                sqlCmd.Parameters.Add("@LastEditDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastEditDate"].Value = pOFormUI.LastEditDate;

                sqlCmd.Parameters.Add("@LastPrintedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastPrintedDate"].Value = pOFormUI.LastPrintedDate;

                sqlCmd.Parameters.Add("@ContractExpirationDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ContractExpirationDate"].Value = pOFormUI.ContractExpirationDate;

                sqlCmd.Parameters.Add("@DatePlacedOnHold", SqlDbType.DateTime);
                sqlCmd.Parameters["@DatePlacedOnHold"].Value = pOFormUI.DatePlacedOnHold;

                sqlCmd.Parameters.Add("@DateHoldRemoved", SqlDbType.DateTime);
                sqlCmd.Parameters["@DateHoldRemoved"].Value = pOFormUI.DateHoldRemoved;


                sqlCmd.Parameters.Add("@tbl_UserId_PlacedOnHoldBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_UserId_PlacedOnHoldBy"].Value = pOFormUI.Tbl_UserId_PlacedOnHoldBy;

                sqlCmd.Parameters.Add("@tbl_UserId_HoldRemovedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_UserId_HoldRemovedBy"].Value = pOFormUI.Tbl_UserId_HoldRemovedBy;

                sqlCmd.Parameters.Add("@RemainingSubTotal", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingSubTotal"].Value = pOFormUI.RemainingSubTotal;

                sqlCmd.Parameters.Add("@SubTotal", SqlDbType.Decimal);
                sqlCmd.Parameters["@SubTotal"].Value = pOFormUI.SubTotal;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = pOFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Freight", SqlDbType.Decimal);
                sqlCmd.Parameters["@Freight"].Value = pOFormUI.Freight;

                sqlCmd.Parameters.Add("@Miscellaneous", SqlDbType.Decimal);
                sqlCmd.Parameters["@Miscellaneous"].Value = pOFormUI.Miscellaneous;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = pOFormUI.Total;

                sqlCmd.Parameters.Add("@tbl_CommentsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CommentsId"].Value = pOFormUI.Tbl_CommentsId;

                sqlCmd.Parameters.Add("@Version", SqlDbType.Int);
                sqlCmd.Parameters["@Version"].Value = pOFormUI.Version;

                sqlCmd.Parameters.Add("@opt_Status", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Status"].Value = pOFormUI.opt_Status;

                sqlCmd.Parameters.Add("@tbl_POId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_POId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string recoredId = Convert.ToString(sqlCmd.Parameters["@tbl_POId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(pOFormUI);
                    audit_IUD.WebServiceInsert(pOFormUI.Tbl_OrganizationId, "tbl_PO", recoredId, pOFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddPO()";
            logExcpUIobj.ResourceName = "POFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POFormDAL : AddPO] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdatePO(POFormUI pOFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PO_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POId"].Value = pOFormUI.Tbl_POId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = pOFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = pOFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = pOFormUI.opt_Type;

                sqlCmd.Parameters.Add("@PONumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@PONumber"].Value = pOFormUI.PONumber;

                sqlCmd.Parameters.Add("@tbl_SupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_SupplierId"].Value = pOFormUI.Tbl_SupplierId;

                sqlCmd.Parameters.Add("@tbl_UserId_Buyer", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_UserId_Buyer"].Value = pOFormUI.Tbl_UserId_Buyer;

                sqlCmd.Parameters.Add("@Date", SqlDbType.DateTime);
                sqlCmd.Parameters["@Date"].Value = pOFormUI.Date;

                sqlCmd.Parameters.Add("@tbl_CurrencyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CurrencyId"].Value = pOFormUI.Tbl_CurrencyId;


                sqlCmd.Parameters.Add("@AllowSales", SqlDbType.Bit);
                sqlCmd.Parameters["@AllowSales"].Value = pOFormUI.AllowSales;

                sqlCmd.Parameters.Add("@RequisitionDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@RequisitionDate"].Value = pOFormUI.RequisitionDate;

                sqlCmd.Parameters.Add("@PurchaseOrderDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@PurchaseOrderDate"].Value = pOFormUI.PurchaseOrderDate;

                sqlCmd.Parameters.Add("@LastEditDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastEditDate"].Value = pOFormUI.LastEditDate;

                sqlCmd.Parameters.Add("@LastPrintedDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@LastPrintedDate"].Value = pOFormUI.LastPrintedDate;

                sqlCmd.Parameters.Add("@ContractExpirationDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@ContractExpirationDate"].Value = pOFormUI.ContractExpirationDate;

                sqlCmd.Parameters.Add("@DatePlacedOnHold", SqlDbType.DateTime);
                sqlCmd.Parameters["@DatePlacedOnHold"].Value = pOFormUI.DatePlacedOnHold;

                sqlCmd.Parameters.Add("@DateHoldRemoved", SqlDbType.DateTime);
                sqlCmd.Parameters["@DateHoldRemoved"].Value = pOFormUI.DateHoldRemoved;


                sqlCmd.Parameters.Add("@tbl_UserId_PlacedOnHoldBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_UserId_PlacedOnHoldBy"].Value = pOFormUI.Tbl_UserId_PlacedOnHoldBy;

                sqlCmd.Parameters.Add("@tbl_UserId_HoldRemovedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_UserId_HoldRemovedBy"].Value = pOFormUI.Tbl_UserId_HoldRemovedBy;

                sqlCmd.Parameters.Add("@RemainingSubTotal", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingSubTotal"].Value = pOFormUI.RemainingSubTotal;

                sqlCmd.Parameters.Add("@SubTotal", SqlDbType.Decimal);
                sqlCmd.Parameters["@SubTotal"].Value = pOFormUI.SubTotal;

                sqlCmd.Parameters.Add("@TradeDiscount", SqlDbType.Decimal);
                sqlCmd.Parameters["@TradeDiscount"].Value = pOFormUI.TradeDiscount;

                sqlCmd.Parameters.Add("@Freight", SqlDbType.Decimal);
                sqlCmd.Parameters["@Freight"].Value = pOFormUI.Freight;

                sqlCmd.Parameters.Add("@Miscellaneous", SqlDbType.Decimal);
                sqlCmd.Parameters["@Miscellaneous"].Value = pOFormUI.Miscellaneous;

                sqlCmd.Parameters.Add("@Total", SqlDbType.Decimal);
                sqlCmd.Parameters["@Total"].Value = pOFormUI.Total;

                sqlCmd.Parameters.Add("@tbl_CommentsId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CommentsId"].Value = pOFormUI.Tbl_CommentsId;

                sqlCmd.Parameters.Add("@Version", SqlDbType.Int);
                sqlCmd.Parameters["@Version"].Value = pOFormUI.Version;

                sqlCmd.Parameters.Add("@opt_Status", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Status"].Value = pOFormUI.opt_Status;


                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(pOFormUI);
                    audit_IUD.WebServiceUpdate(pOFormUI.Tbl_OrganizationId, "tbl_PO", pOFormUI.Tbl_POId, pOFormUI.ModifiedBy, newValue);
                }

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePO()";
            logExcpUIobj.ResourceName = "POFormDAL.CS";
            logExcpUIobj.RecordId = pOFormUI.Tbl_POId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POFormDAL : UpdatePO] An error occured in the processing of Record Id : " + pOFormUI.Tbl_POId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeletePO(POFormUI pOFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PO_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_POId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_POId"].Value = pOFormUI.Tbl_POId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_PO", pOFormUI.Tbl_POId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePO()";
            logExcpUIobj.ResourceName = "POFormDAL.CS";
            logExcpUIobj.RecordId = pOFormUI.Tbl_POId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[POFormDAL : DeletePO] An error occured in the processing of Record Id : " + pOFormUI.Tbl_POId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}