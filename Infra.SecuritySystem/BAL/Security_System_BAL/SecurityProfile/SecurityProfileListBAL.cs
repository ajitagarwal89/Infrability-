using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SecurityProfileListBAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class SecurityProfileListBAL
    {
        SecurityProfileListDAL securityProfileListDAL = new SecurityProfileListDAL();

        public SecurityProfileListBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetSecurityProfileList()
        {
            DataTable dtb = new DataTable();
            dtb = securityProfileListDAL.GetSecurityProfileListDAL();
            return dtb;
        }

        public DataTable GetSecurityProfile(int id)
        {
            DataTable dtb = new DataTable();
            dtb = securityProfileListDAL.GetSecurityProfileNameDAL(id);
            return dtb;
        }

        public int DeleteSecurityProfile(string id)
        {
            int result = 0;
            result = securityProfileListDAL.DeleteSecurityProfile(id);
            return result;
        }
    }
}