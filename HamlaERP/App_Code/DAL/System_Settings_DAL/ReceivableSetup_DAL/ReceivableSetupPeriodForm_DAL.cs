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
/// Summary description for ReceivableSetupPeriodForm_DAL
/// </summary>
public class ReceivableSetupPeriodForm_DAL: IRequiresSessionState
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    Audit_IUD audit_IUD = new Audit_IUD();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public ReceivableSetupPeriodForm_DAL()
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
            logExcpUIobj.MethodName = "ReceivableSetupPeriodForm_DAL()";
            logExcpUIobj.ResourceName = "ReceivableSetupPeriodForm_DAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[ReceivableSetupPeriodForm_DAL : ReceivableSetupPeriodForm_DAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }

    public int AddReceivableSetupPeriod(ReceivableSetupPeriod_FormUI receivableSetupPeriod_FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupPeriod_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = receivableSetupPeriod_FormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = receivableSetupPeriod_FormUI.Tbl_OrganizationId;          

               
                sqlCmd.Parameters.Add("@CurrentPeriod", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CurrentPeriod"].Value = receivableSetupPeriod_FormUI.CurrentPeriod;

                sqlCmd.Parameters.Add("@From", SqlDbType.Int);
                sqlCmd.Parameters["@From"].Value = receivableSetupPeriod_FormUI.From;

                sqlCmd.Parameters.Add("@To", SqlDbType.Int);
                sqlCmd.Parameters["@To"].Value = receivableSetupPeriod_FormUI.To;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupId"].Value = receivableSetupPeriod_FormUI.Tbl_ReceivableSetupId;
                

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupPeriodId", SqlDbType.UniqueIdentifier);
                sqlCmd.Parameters["@tbl_ReceivableSetupPeriodId"].Direction = ParameterDirection.Output;

                result = sqlCmd.ExecuteNonQuery();

                string RecoredID = Convert.ToString(sqlCmd.Parameters["@tbl_ReceivalbeSetupPeriodId"].Value);

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {

                    string tableName = "tbl_ReceivalbeSetupPeriodId";

                    sqlCmd.Dispose();
                    SupportCon.Close();
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(receivableSetupPeriod_FormUI);
                    audit_IUD.WebServiceInsert(receivableSetupPeriod_FormUI.Tbl_OrganizationId, tableName, RecoredID, receivableSetupPeriod_FormUI.CreatedBy, newValue);
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
            logExcpUIobj.MethodName = "AddReceivableSetupPeriod()";
            logExcpUIobj.ResourceName = "ReceivableSetupPeriodForm_DAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupPeriodForm_DAL : AddReceivableSetupPeriod] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateReceivalbeSetupPeriod(ReceivableSetupPeriod_FormUI receivableSetupPeriod_FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupPeriod_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupPeriodId"].Value = receivableSetupPeriod_FormUI.Tbl_ReceivableSetupPeriodId;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = receivableSetupPeriod_FormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = receivableSetupPeriod_FormUI.Tbl_OrganizationId;               

                sqlCmd.Parameters.Add("@CurrentPeriod", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CurrentPeriod"].Value = receivableSetupPeriod_FormUI.CurrentPeriod;

                sqlCmd.Parameters.Add("@From", SqlDbType.Int);
                sqlCmd.Parameters["@From"].Value = receivableSetupPeriod_FormUI.From;

                sqlCmd.Parameters.Add("@To", SqlDbType.Int);
                sqlCmd.Parameters["@To"].Value = receivableSetupPeriod_FormUI.To;

                sqlCmd.Parameters.Add("@tbl_ReceivableSetupId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivableSetupId"].Value = receivableSetupPeriod_FormUI.Tbl_ReceivableSetupId;

                result = sqlCmd.ExecuteNonQuery();
                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    SerializeInputParameters obj = new SerializeInputParameters();
                    string newValue = obj.GetSerializedString(receivableSetupPeriod_FormUI);
                    audit_IUD.WebServiceUpdate(receivableSetupPeriod_FormUI.Tbl_OrganizationId, "tbl_ReceivalbeSetupPeriod", receivableSetupPeriod_FormUI.Tbl_ReceivableSetupPeriodId, receivableSetupPeriod_FormUI.ModifiedBy, newValue);
                }


                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateReceivalbeSetupPeriod()";
            logExcpUIobj.ResourceName = "ReceivableSetupPeriodForm_DAL.CS";
            logExcpUIobj.RecordId = receivableSetupPeriod_FormUI.Tbl_ReceivableSetupPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupPeriodForm_DAL : UpdateReceivalbeSetupPeriod] An error occured in the processing of Record Id : " + receivableSetupPeriod_FormUI.Tbl_ReceivableSetupPeriodId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteReceivalbeSetupPeriod(ReceivableSetupPeriod_FormUI receivableSetupPeriod_FormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupPeriod_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ReceivalbeSetupPeriodId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ReceivalbeSetupPeriodId"].Value = receivableSetupPeriod_FormUI.Tbl_ReceivableSetupPeriodId;

                result = sqlCmd.ExecuteNonQuery();

                if (SessionContext.GlobalAuditEnabledStatus == true)
                {
                    audit_IUD.WebServiceDelete("tbl_ReceivalbeSetupPeriod", receivableSetupPeriod_FormUI.Tbl_ReceivableSetupPeriodId);
                }
                sqlCmd.Dispose();
                SupportCon.Close();

            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteReceivalbeSetupPeriod()";
            logExcpUIobj.ResourceName = "ReceivableSetupPeriodForm_DAL.CS";
            logExcpUIobj.RecordId = receivableSetupPeriod_FormUI.Tbl_ReceivableSetupPeriodId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupPeriodForm_DAL : DeleteReceivalbeSetupPeriod] An error occured in the processing of Record Id : " + receivableSetupPeriod_FormUI.Tbl_ReceivableSetupPeriodId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public DataTable GetReceivableSetupPeriodList()
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();       
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_ReceivableSetupPeriod_Select", SupportCon);
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
            logExcpUIobj.MethodName = "GetReceivableSetupPeriodList()";
            logExcpUIobj.ResourceName = "ReceivableSetupPeriodForm_DAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ReceivableSetupPeriodForm_DAL : GetReceivableSetupPeriodList] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;
    }
}