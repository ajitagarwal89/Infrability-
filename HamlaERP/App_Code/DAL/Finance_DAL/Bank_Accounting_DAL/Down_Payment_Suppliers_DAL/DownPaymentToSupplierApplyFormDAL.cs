using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using log4net;
/// <summary>
/// Summary description for DownPaymentToSupplierApplyFormDAL
/// </summary>
public class DownPaymentToSupplierApplyFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public DownPaymentToSupplierApplyFormDAL()
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
            logExcpUIobj.MethodName = "DownPaymentToSupplierApplyFormDAL()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierApplyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[DownPaymentToSupplierApplyFormDAL : DownPaymentToSupplierApplyFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
    }
    public DataTable GetDownPaymentToSupplierApplyListById(DownPaymentToSupplierApplyFormUI downPaymentToSupplierApplyFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierApply_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierApplyId"].Value = downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId;

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
            logExcpUIobj.MethodName = "GetDownPaymentToSupplierApplyListById()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierApplyFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentToSupplierApplyFormDAL : GetDownPaymentToSupplierApplyListById] An error occured in the processing of Record Id : " + downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddDownPaymentToSupplierApply(DownPaymentToSupplierApplyFormUI downPaymentToSupplierApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierApply_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = downPaymentToSupplierApplyFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = downPaymentToSupplierApplyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierId"].Value = downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierId;

                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = downPaymentToSupplierApplyFormUI.opt_ApplyToDocumentType;


                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = downPaymentToSupplierApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = downPaymentToSupplierApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = downPaymentToSupplierApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = downPaymentToSupplierApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = downPaymentToSupplierApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = downPaymentToSupplierApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = downPaymentToSupplierApplyFormUI.DiscountDate;
                
                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddDownPaymentToSupplierApply()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierApplyFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[DownPaymentToSupplierApplyFormDAL : AddDownPaymentToSupplierApply] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }
    //pending below
    public int UpdateDownPaymentToSupplierApply(DownPaymentToSupplierApplyFormUI downPaymentToSupplierApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierApply_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = downPaymentToSupplierApplyFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = downPaymentToSupplierApplyFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@Tbl_DownPaymentToSupplierApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@Tbl_DownPaymentToSupplierApplyId"].Value = downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId;

                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierId"].Value = downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierId;

                sqlCmd.Parameters.Add("@tbl_ApplyToDocument", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ApplyToDocument"].Value = downPaymentToSupplierApplyFormUI.Tbl_ApplyToDocument;

                sqlCmd.Parameters.Add("@DueDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DueDate"].Value = downPaymentToSupplierApplyFormUI.DueDate;

                sqlCmd.Parameters.Add("@RemainingAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@RemainingAmount"].Value = downPaymentToSupplierApplyFormUI.RemainingAmount;

                sqlCmd.Parameters.Add("@ApplyAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@ApplyAmount"].Value = downPaymentToSupplierApplyFormUI.ApplyAmount;

                sqlCmd.Parameters.Add("@opt_ApplyToDocumentType", SqlDbType.TinyInt);
                sqlCmd.Parameters["@opt_ApplyToDocumentType"].Value = downPaymentToSupplierApplyFormUI.opt_ApplyToDocumentType;

                sqlCmd.Parameters.Add("@opt_Type", SqlDbType.Int);
                sqlCmd.Parameters["@opt_Type"].Value = downPaymentToSupplierApplyFormUI.opt_Type;

                sqlCmd.Parameters.Add("@OrignalDocumentAmount", SqlDbType.Decimal);
                sqlCmd.Parameters["@OrignalDocumentAmount"].Value = downPaymentToSupplierApplyFormUI.OrignalDocumentAmount;

                sqlCmd.Parameters.Add("@DiscountDate", SqlDbType.DateTime);
                sqlCmd.Parameters["@DiscountDate"].Value = downPaymentToSupplierApplyFormUI.DiscountDate;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateDownPaymentToSupplierApply()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierApplyFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[DownPaymentToSupplierApplyFormDAL : UpdateDownPaymentToSupplierApply] An error occured in the processing of Record Id : " + downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteDownPaymentToSupplierApply(DownPaymentToSupplierApplyFormUI downPaymentToSupplierApplyFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_DownPaymentToSupplierApply_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_DownPaymentToSupplierApplyId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_DownPaymentToSupplierApplyId"].Value = downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteDownPaymentToSupplierApply()";
            logExcpUIobj.ResourceName = "DownPaymentToSupplierApplyFormDAL.CS";
            logExcpUIobj.RecordId = downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);
            log.Error("[DownPaymentToSupplierApplyFormDAL : DeleteDownPaymentToSupplierApply] An error occured in the processing of Record Id : " + downPaymentToSupplierApplyFormUI.Tbl_DownPaymentToSupplierApplyId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}