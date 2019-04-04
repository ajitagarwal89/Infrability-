using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using log4net;
using Newtonsoft.Json;
using Finware;
using System.Data.SqlClient;

/// <summary>
/// Summary description for PayableSetupPeriod_FormDal
/// </summary>
public class PayableSetupPeriodFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    PayableSetupPeriod_FormUI payableSetupPeriodFormUI = new PayableSetupPeriod_FormUI();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public PayableSetupPeriodFormDAL()
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
            logExcpUIobj.MethodName = "PayableSetupPeriodFormDAL()";
            logExcpUIobj.ResourceName = "PayableSetupPeriodFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PayableSetupPeriodFormDAL : PayableSetupPeriodFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public int AddPayableSetupPeriod(PayableSetupPeriod_FormUI payableSetupPeriodFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupPeriod_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = payableSetupPeriodFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = payableSetupPeriodFormUI.Tbl_OrganizationId;
               
                sqlCmd.Parameters.Add("@tbl_PayableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupId"].Value = payableSetupPeriodFormUI.Tbl_PayableSetupId;

                sqlCmd.Parameters.Add("@CurrentPeriod", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CurrentPeriod"].Value = payableSetupPeriodFormUI.CurrentPeriod;

                sqlCmd.Parameters.Add("@From", SqlDbType.NVarChar);
                sqlCmd.Parameters["@From"].Value = payableSetupPeriodFormUI.From;

                sqlCmd.Parameters.Add("@To", SqlDbType.TinyInt);
                sqlCmd.Parameters["@To"].Value = payableSetupPeriodFormUI.To;    
                
                sqlCmd.Parameters.Add("@tbl_PayableSetupPeriodId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_PayableSetupPeriodId"].Direction = ParameterDirection.Output;


                result = sqlCmd.ExecuteNonQuery();

                string recoredID = Convert.ToString(sqlCmd.Parameters["@tbl_PayableSetupPeriodId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_PayableSetupPeriod";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(payableSetupPeriodFormUI);
                    audit_IUD.WebServiceInsert(payableSetupPeriodFormUI.Tbl_OrganizationId, tableName, recoredID, payableSetupPeriodFormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddPayableSetupPeriod()";
            logExcpUIobj.ResourceName = "PayableSetupPeriodFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupPeriodFormDAL : AddPayableSetupPeriod] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;

    }
    public int UpdatePayableSetupPeriod(PayableSetupPeriod_FormUI payableSetupPeriodFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupPeriod_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = payableSetupPeriodFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = payableSetupPeriodFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_PayableSetupPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupPeriodId"].Value = payableSetupPeriodFormUI.Tbl_PayableSetupPeriodId;

                sqlCmd.Parameters.Add("@tbl_PayableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupId"].Value = payableSetupPeriodFormUI.Tbl_PayableSetupId;

                sqlCmd.Parameters.Add("@CurrentPeriod", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CurrentPeriod"].Value = payableSetupPeriodFormUI.CurrentPeriod;

                sqlCmd.Parameters.Add("@From", SqlDbType.Int);
                sqlCmd.Parameters["@From"].Value = payableSetupPeriodFormUI.From;

                sqlCmd.Parameters.Add("@To", SqlDbType.Int);
                sqlCmd.Parameters["@To"].Value = payableSetupPeriodFormUI.To;


                


                result = sqlCmd.ExecuteNonQuery();

               

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(payableSetupPeriodFormUI);
                    audit_IUD.WebServiceUpdate(payableSetupPeriodFormUI.Tbl_OrganizationId, "tbl_PayableSetupPeriod", payableSetupPeriodFormUI.Tbl_PayableSetupPeriodId, payableSetupPeriodFormUI.ModifiedBy, newValue);

                    
                }
                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePayableSetupPeriod()";
            logExcpUIobj.ResourceName = "PayableSetupPeriodFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupPeriodFormDAL : UpdatePayableSetupPeriod] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;

    }

    public DataTable GetPayableSetupPeriodById(PayableSetupFormUI payableSetupFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupPeriod_SelectByPayableSetupId", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PayableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PayableSetupId"].Value = payableSetupFormUI.Tbl_PayableSetupId;

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
                audit_IUD.WebServiceSelectInsert("tbl_PayableSetup", payableSetupFormUI.Tbl_PayableSetupId, selectedValue);
            }

        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "GetPayableSetupPeriodById()";
            logExcpUIobj.ResourceName = "PayableSetupPeriod_FormDal.CS";
            logExcpUIobj.RecordId = payableSetupFormUI.Tbl_PayableSetupId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupPeriod_FormDal : GetPayableSetupPeriodById] An error occured in the processing of Record Id : " + payableSetupFormUI.Tbl_PayableSetupId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public DataTable GetPayableSetupId()
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
       
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PayableSetupPeriod_SelectbyNewID", SupportCon);
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
            logExcpUIobj.MethodName = "GetPayableSetupId()";
            logExcpUIobj.ResourceName = "PayableSetupPeriodFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[PayableSetupPeriodFormDAL : GetPayableSetupId] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }
}