using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace InfraWebServices
{
    public class LogException
    {
        public void SaveExceptionToDB(LogExceptionUI LEobj)
        {
            SqlConnection sqlCon = null;
            SqlCommand sqlCmd = null;

            try
            {

                GlobalConfigurations objConfig = new GlobalConfigurations();
                objConfig.InitilizeConnectionString();

                objConfig.InitilizeConnectionString();
                string connectionString = objConfig.connectionString;
                int commandTimeout = Convert.ToInt32(objConfig.commandTimeout);


                sqlCon = new SqlConnection(connectionString);

                sqlCon.Open();
                sqlCmd = new SqlCommand("SP_LogException", sqlCon);

                sqlCmd.Parameters.Add("@MethodName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@MethodName"].Value = LEobj.MethodName;

                sqlCmd.Parameters.Add("@ResourceName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ResourceName"].Value = LEobj.ResourceName;

                sqlCmd.Parameters.Add("@RecordId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@RecordId"].Value = LEobj.RecordId;

                sqlCmd.Parameters.Add("@ExceptionDetails", SqlDbType.NText);
                sqlCmd.Parameters["@ExceptionDetails"].Value = LEobj.ExceptionDetails;

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.ExecuteNonQuery();

                sqlCon.Close();
                sqlCon.Dispose();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                //Since these variables are in local scope it'll be auto dispose once thread exits the mehtod.
                //However good to add it explicitly.
                try
                {
                    if (sqlCmd != null)
                    {
                        sqlCmd.Dispose();
                    }
                }
                catch { }
                try
                {
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                }
                catch { }
            }
        }

        public static void SaveExceptionToDB(string methodName, string resourceName, string recordId, string exceptionDetails)
        {
            SqlConnection sqlCon = null;
            SqlCommand sqlCmd = null;

            try
            {

                GlobalConfigurations objConfig = new GlobalConfigurations();
                objConfig.InitilizeConnectionString();

                objConfig.InitilizeConnectionString();
                string connectionString = objConfig.connectionString;
                int commandTimeout = Convert.ToInt32(objConfig.commandTimeout);

                sqlCon = new SqlConnection(connectionString);

                sqlCon.Open();
                sqlCmd = new SqlCommand("SP_LogException", sqlCon);

                sqlCmd.Parameters.Add("@MethodName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@MethodName"].Value = methodName;

                sqlCmd.Parameters.Add("@ResourceName", SqlDbType.NVarChar);
                sqlCmd.Parameters["@ResourceName"].Value = resourceName;

                sqlCmd.Parameters.Add("@RecordId", SqlDbType.NVarChar);
                sqlCmd.Parameters["@RecordId"].Value = recordId;

                sqlCmd.Parameters.Add("@ExceptionDetails", SqlDbType.NText);
                sqlCmd.Parameters["@ExceptionDetails"].Value = exceptionDetails;

                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandTimeout = commandTimeout;

                sqlCmd.ExecuteNonQuery();

                sqlCon.Close();
                sqlCon.Dispose();
            }
            catch (Exception exp)
            {
                exp.ToString();
            }
            finally
            {
                //Since these variables are in local scope it'll be auto dispose once thread exits the mehtod.
                //However good to add it explicitly.
                try
                {
                    if (sqlCmd != null)
                    {
                        sqlCmd.Dispose();
                    }
                }
                catch { }
                try
                {
                    if (sqlCon != null)
                    {
                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                }
                catch { }
            }
        }
    }
}