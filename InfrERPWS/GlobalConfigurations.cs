using Infra.Security.AESEncryptionLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace InfrERPWS
{
    public class GlobalConfigurations
    {
        #region Data Member
        public string connectionString = "";
        public string commandTimeout = "";
        #endregion
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