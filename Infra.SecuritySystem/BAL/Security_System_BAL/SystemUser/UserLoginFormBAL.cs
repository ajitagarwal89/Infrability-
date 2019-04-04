using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UserLoginFormBAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class UserLoginFormBAL
    {
        UserLoginFormDAL userLoginFormDAL = new UserLoginFormDAL();

        public UserLoginFormBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetUser(UserLoginFormUI userLoginFormUI)
        {
            DataTable dtb = new DataTable();
            dtb = userLoginFormDAL.GetUser(userLoginFormUI);
            return dtb;
        }

        public DataSet GetSystemSettings(UserLoginFormUI userLoginFormUI)
        {
            DataSet ds = new DataSet();
            ds = userLoginFormDAL.GetSystemSettings(userLoginFormUI);
            return ds;
        }
    }
}