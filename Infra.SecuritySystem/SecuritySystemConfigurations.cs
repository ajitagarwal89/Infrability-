using Infra.Security.AESEncryptionLibrary;
using System;
using System.Configuration;

/// <summary>
/// Summary description for GlobalConfigurations
/// </summary>
namespace Infra.SecuritySystem
{
    public class SecuritySystemConfigurations
    {
        #region Data Memebers

        public string connectionString = "";
        public string commandTimeout = "";

        #endregion

        #region Constructor
        public SecuritySystemConfigurations()
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
}