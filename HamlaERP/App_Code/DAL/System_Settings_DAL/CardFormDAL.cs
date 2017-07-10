using System;
using System.Data.SqlClient;
using System.Data;
using log4net;

/// <summary>
/// Summary description for CardFormDAL
/// </summary>
public class CardFormDAL
{
    string connectionString = string.Empty;
    int commandTimeout = 0;
    LogExceptionUI logExcpUIobj = new LogExceptionUI();
    LogException logExcpDALobj = new LogException();
    protected static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

	public CardFormDAL()
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
            logExcpUIobj.MethodName = "CardFormDAL()";
            logExcpUIobj.ResourceName = "CardFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            throw new Exception("[CardFormDAL : CardFormDAL] ERROR: An error occured while connection to staging database. Please check the connection settings : [" + exp.ToString() + "]");
        }
	}

    public DataTable GetCardListById(CardFormUI cardFormUI)
    {

        DataSet ds = new DataSet();
        DataTable dtbl = new DataTable();
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("SP_Card_SelectById", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CardId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CardId"].Value = cardFormUI.Tbl_CardId;

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
            logExcpUIobj.MethodName = "getCardListById()";
            logExcpUIobj.ResourceName = "CardFormDAL.CS";
            logExcpUIobj.RecordId = cardFormUI.Tbl_CardId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CardFormDAL : getCardListById] An error occured in the processing of Record Id : " + cardFormUI.Tbl_CardId + ". Details : [" + exp.ToString() + "]");
        }
        finally
        {
            ds.Dispose();
        }

        return dtbl;

    }

    public int AddCard(CardFormUI cardFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Card_Insert", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CreatedBy"].Value = cardFormUI.CreatedBy;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = cardFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@CardCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CardCode"].Value = cardFormUI.CardCode;

                sqlCmd.Parameters.Add("@CardName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CardName"].Value = cardFormUI.CardName;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "AddCard()";
            logExcpUIobj.ResourceName = "CardFormDAL.CS";
            logExcpUIobj.RecordId = "";
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CardFormDAL : AddCard] An error occured in the processing of Record. Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int UpdateCard(CardFormUI cardFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Card_Update", SupportCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@ModifiedBy", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ModifiedBy"].Value = cardFormUI.ModifiedBy;
                sqlCmd.Parameters.Add("@tbl_CardId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CardId"].Value = cardFormUI.Tbl_CardId;

                sqlCmd.Parameters.Add("@tbl_OrganizationId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_OrganizationId"].Value = cardFormUI.Tbl_OrganizationId;

                sqlCmd.Parameters.Add("@CardCode", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CardCode"].Value = cardFormUI.CardCode;

                sqlCmd.Parameters.Add("@CardName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@CardName"].Value = cardFormUI.CardName;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "UpdateCard()";
            logExcpUIobj.ResourceName = "CardFormDAL.CS";
            logExcpUIobj.RecordId = cardFormUI.Tbl_CardId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CardFormDAL : UpdateCard] An error occured in the processing of Record Id : " + cardFormUI.Tbl_CardId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }

    public int DeleteCard(CardFormUI cardFormUI)
    {

        int result = 0;
        try
        {
            using (SqlConnection SupportCon = new SqlConnection(connectionString))
            {
                SupportCon.Open();
                SqlCommand sqlCmd = new SqlCommand("SP_Card_Delete", SupportCon);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.Parameters.Add("@tbl_CardId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@tbl_CardId"].Value = cardFormUI.Tbl_CardId;

                result = sqlCmd.ExecuteNonQuery();

                sqlCmd.Dispose();
                SupportCon.Close();
            }
        }
        catch (Exception exp)
        {
            logExcpUIobj.MethodName = "DeleteCard()";
            logExcpUIobj.ResourceName = "CardFormDAL.CS";
            logExcpUIobj.RecordId = cardFormUI.Tbl_CardId;
            logExcpUIobj.ExceptionDetails = "Error Occured. System Generated Error is: " + exp.ToString();
            logExcpDALobj.SaveExceptionToDB(logExcpUIobj);

            log.Error("[CardFormDAL : DeleteCard] An error occured in the processing of Record Id : " + cardFormUI.Tbl_CardId + ". Details : [" + exp.ToString() + "]");
        }

        return result;
    }
}