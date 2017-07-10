using System;
using System.Data.SqlClient;
using System.Data;
using log4net;


/// <summary>
/// Summary description for ChequeBookFormDAL
/// </summary>
public class ChequeBookFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public ChequeBookFormDAL()
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
            logExcpUIobj.MethodName = "ChequeBookFormDAL()";
            logExcpUIobj.ResourceName = "ChequeBookFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[ChequeBookFormDAL : ChequeBookFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetChequeBookListById(ChequeBookFormUI chequeBookFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_ChequeBook_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ChequeBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ChequeBookId"].Value = chequeBookFormUI.Tbl_ChequeBookId;

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
            logExcpUIobj.MethodName = "getChequeBookListById()";
            logExcpUIobj.ResourceName = "ChequeBookFormDAL.CS";
            logExcpUIobj.RecordId = chequeBookFormUI.Tbl_ChequeBookId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChequeBookFormDAL : getChequeBookListById] An error occured in the processing of Record Id : " + chequeBookFormUI.Tbl_ChequeBookId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddChequeBook(ChequeBookFormUI chequeBookFormUI)
    {
                int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ChequeBook_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = chequeBookFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chequeBookFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@ChequeBookName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ChequeBookName"].Value = chequeBookFormUI.ChequeBookName;

                sqlCmd.Parameters.Add("@ChequeBookNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ChequeBookNumber"].Value = chequeBookFormUI.ChequeBookNumber;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddChequeBook()";
            logExcpUIobj.ResourceName = "ChequeBookFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChequeBookFormDAL : AddChequeBook] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateChequeBook(ChequeBookFormUI chequeBookFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ChequeBook_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = chequeBookFormUI.ModifiedBy;

                sqlCmd.Parameters.Add("@tbl_ChequeBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ChequeBookId"].Value = chequeBookFormUI.Tbl_ChequeBookId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = chequeBookFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@ChequeBookName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ChequeBookName"].Value = chequeBookFormUI.ChequeBookName;

                sqlCmd.Parameters.Add("@ChequeBookNumber", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ChequeBookNumber"].Value = chequeBookFormUI.ChequeBookNumber;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateChequeBook()";
            logExcpUIobj.ResourceName = "ChequeBookFormDAL.CS";
            logExcpUIobj.RecordId = chequeBookFormUI.Tbl_ChequeBookId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChequeBookFormDAL : UpdateChequeBook] An error occured in the processing of Record Id : " + chequeBookFormUI.Tbl_ChequeBookId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteChequeBook(ChequeBookFormUI chequeBookFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_ChequeBook_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_ChequeBookId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_ChequeBookId"].Value = chequeBookFormUI.Tbl_ChequeBookId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteChequeBook()";
            logExcpUIobj.ResourceName = "ChequeBookFormDAL.CS";
            logExcpUIobj.RecordId = chequeBookFormUI.Tbl_ChequeBookId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[ChequeBookFormDAL : DeleteChequeBook] An error occured in the processing of Record Id : " + chequeBookFormUI.Tbl_ChequeBookId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}