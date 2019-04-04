using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Infra.Security.AESEncryptionLibrary;

/// <summary>
/// Summary description for GlobalConfigurations
/// </summary>
public class GlobalConfigurations
{
    #region Data Memebers

    public string connectionString = "";
    public string commandTimeout = "";

    #endregion

    #region Constructor
    public GlobalConfigurations()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #endregion

    /// <summary>
    /// Connection String
    /// </summary>
    public void InitilizeConnectionString()
    {
        try
        {
            connectionString = ConfigurationManager.AppSettings.Get("ConnectionString").ToString();
            connectionString = RidjindalEncryption.Decrypt(connectionString);

            commandTimeout = ConfigurationManager.AppSettings.Get("CommandTimeout").ToString();
        }
        catch (Exception exp)
        {
            throw new Exception("Config File Issue: Please check if the DB Connection String is defined correclty in the web.config file. System Error: " + exp.ToString());
        }
    }

}