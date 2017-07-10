using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for PaymentToEmployeeApplyFormDAL
/// </summary>
public class PaymentToEmployeeApplyFormDAL
{

    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public PaymentToEmployeeApplyFormDAL()
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
            logExcpUIobj.MethodName = "PaymentToEmployeeApplyFormDAL()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeApplyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[PaymentToEmployeeApplyFormDAL : PaymentToEmployeeApplyFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetPaymentToEmployeeApplyListById(PaymentToEmployeeApplyFormUI PaymentToEmployeeApplyFormUI)
    {
        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeApply_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeApplyId"].Value = PaymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId;

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
            logExcpUIobj.MethodName = "GetPaymentToEmployeeApplyListById()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeApplyFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeApplyFormDAL : GetPaymentToEmployeeApplyListById] An error occured in the processing of Record Id : " + PaymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddPaymentToEmployeeApply(PaymentToEmployeeApplyFormUI PaymentToEmployeeApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeApply_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = PaymentToEmployeeApplyFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentToEmployeeApplyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentToEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentToEmployeeId"].Value = PaymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeId;

                
                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = PaymentToEmployeeApplyFormUI.opt_ApplyToDocumentType;

                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = PaymentToEmployeeApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = PaymentToEmployeeApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = PaymentToEmployeeApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = PaymentToEmployeeApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = PaymentToEmployeeApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = PaymentToEmployeeApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = PaymentToEmployeeApplyFormUI.DiscountDate;
                

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddPaymentToEmployeeApply()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeApplyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeApplyFormDAL : AddPaymentToEmployeeApply] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdatePaymentToEmployeeApply(PaymentToEmployeeApplyFormUI PaymentToEmployeeApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeApply_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = PaymentToEmployeeApplyFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = PaymentToEmployeeApplyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_PaymentToEmployeeApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentToEmployeeApplyId"].Value = PaymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId;

                sqlCmd.Parameters.Add("@Tbl_PaymentToEmployeeId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_PaymentToEmployeeId"].Value = PaymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeId;

                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.Int);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = PaymentToEmployeeApplyFormUI.opt_ApplyToDocumentType;

                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = PaymentToEmployeeApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = PaymentToEmployeeApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = PaymentToEmployeeApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = PaymentToEmployeeApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = PaymentToEmployeeApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = PaymentToEmployeeApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = PaymentToEmployeeApplyFormUI.DiscountDate;
                

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdatePaymentToEmployeeApply()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeApplyFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeApplyFormDAL : UpdatePaymentToEmployeeApply] An error occured in the processing of Record Id : " + PaymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    public int DeletePaymentToEmployeeApply(PaymentToEmployeeApplyFormUI PaymentToEmployeeApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_PaymentToEmployeeApply_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_PaymentToEmployeeApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_PaymentToEmployeeApplyId"].Value = PaymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeletePaymentToEmployeeApply()";
            logExcpUIobj.ResourceName = "PaymentToEmployeeApplyFormDAL.CS";
            logExcpUIobj.RecordId = PaymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[PaymentToEmployeeApplyFormDAL : DeletePaymentToEmployeeApply] An error occured in the processing of Record Id : " + PaymentToEmployeeApplyFormUI.Tbl_PaymentToEmployeeApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

}