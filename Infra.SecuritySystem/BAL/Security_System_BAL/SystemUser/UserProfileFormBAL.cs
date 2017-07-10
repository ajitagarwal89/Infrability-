using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UserProfileFormBAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class UserProfileFormBAL
    {
        UserProfileFormDAL userProfileFormDAL = new UserProfileFormDAL();

        public UserProfileFormBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int AddUser(UserProfileFormUI userProfileFormUI, ref int newUserId)
        {
            int result = 0;
            result = userProfileFormDAL.AddUser(userProfileFormUI, ref newUserId);
            return result;
        }

        public int UpdateUser(UserProfileFormUI userProfileFormUI, int id)
        {
            int result = 0;
            result = userProfileFormDAL.UpdateUser(userProfileFormUI, id);
            return result;
        }

        public int DeleteUser(UserProfileFormUI userProfileFormUI, int id)
        {
            int result = 0;
            result = userProfileFormDAL.DeleteUser(userProfileFormUI, id);
            return result;
        }

        public DataTable GetOrganisation()
        {
            DataTable dtb = new DataTable();
            dtb = userProfileFormDAL.GetOrganisation();
            return dtb;
        }
    }
}