using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PageControlListEditBAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class PrivilegesDetailsBAL
    {
        PrivilegesDetailsDAL privilegesDetailsDAL = new PrivilegesDetailsDAL();

        public PrivilegesDetailsBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetPrivilegesDetails(int securityProfile, int pageMapping)
        {
            DataTable dtb = new DataTable();
            dtb = privilegesDetailsDAL.GetPrivilegesDetails(securityProfile, pageMapping);
            return dtb;
        }

        public int AddProfilePageControlMapping(int profileId, int pageId, int controlId, string privelege)
        {
            int result = 0;
            result = privilegesDetailsDAL.AddProfilePageControlMapping(profileId, pageId, controlId, privelege);
            return result;
        }

        public int RemoveProfilePageControlMapping(int profileId, int pageMapping)
        {
            int result = 0;
            result = privilegesDetailsDAL.RemoveProfilePageControlMapping(profileId, pageMapping);
            return result;
        }
    }
}