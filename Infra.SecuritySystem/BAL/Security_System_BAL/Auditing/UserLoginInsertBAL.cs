using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UserLoginInsertBAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class UserLoginInsertBAL
    {
        UserLoginInsertDAL objUserLoginInsertDAL = new UserLoginInsertDAL();

        public UserLoginInsertBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int AddUser(UserLoginFormUI userLoginFormUI)
        {
            int result = 0;
            result = objUserLoginInsertDAL.CreateLogForUserLogin(userLoginFormUI);
            return result;
        }
    }
}