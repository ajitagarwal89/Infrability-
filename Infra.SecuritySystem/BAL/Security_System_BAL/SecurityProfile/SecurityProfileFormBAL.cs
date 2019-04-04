using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SecurityProfileForm
/// </summary>
namespace Infra.SecuritySystem
{
    public class SecurityProfileFormBAL
    {
        SecurityProfileFormDAL securityProfileFormDAL = new SecurityProfileFormDAL();

        public SecurityProfileFormBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int AddSecurityProfile(SecurityProfileFormUI securityProfileFormUI, ref int newProfileId)
        {
            int result = 0;
            result = securityProfileFormDAL.AddSecurityProfile(securityProfileFormUI, ref newProfileId);
            return result;
        }

        public int UpdateSecurityProfile(SecurityProfileFormUI securityProfileFormUI, int id)
        {
            int result = 0;
            result = securityProfileFormDAL.UpdateSecurityProfile(securityProfileFormUI, id);
            return result;
        }

        public int DeleteSecurityProfile(int id)
        {
            int result = 0;
            result = securityProfileFormDAL.DeleteSecurityProfile(id);
            return result;
        }
    }
}