using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserLoginFormUI
/// </summary>
namespace Infra.SecuritySystem
{
    public class UserLoginFormUI
    {
        public UserLoginFormUI()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        string userId;
        string userGuid;
        string password;
        int systemUser;
        string userIP;
        string userBrowser;
        DateTime createdOn = DateTime.Now;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string UserGuid
        {
            get { return userGuid; }
            set { userGuid = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public int SystemUser
        {
            get { return systemUser; }
            set { systemUser = value; }
        }

        public string UserIP
        {
            get { return userIP; }
            set { userIP = value; }
        }

        public string UserBrowser
        {
            get { return userBrowser; }
            set { userBrowser = value; }
        }

        public DateTime CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }
        public string Tbl_OrganizationId { get; set; }

        public string Year { get; set; }
    }
}