using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ProfilePageMappingInsertBAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class ProfilePageMappingInsertBAL
    {
        ProfilePageMappingInsertDAL profilePageMappingInsertDAL = new ProfilePageMappingInsertDAL();

        public ProfilePageMappingInsertBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int AddProfilePageMapping(int profileId, int pageId, int read)
        {
            int result = 0;
            result = profilePageMappingInsertDAL.AddProfilePageMapping(profileId, pageId, read);
            return result;
        }
    }
}