using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UserRolesBAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class UserRolesBAL
    {
        UserRolesDAL userRolesDAL = new UserRolesDAL();

        public UserRolesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public int AddRoles(UserRolesFormUI userRolesFormUI)
        {
            int result = 0;
            result = userRolesDAL.AddRoles(userRolesFormUI);
            return result;
        }

        public int RemoveRoles(int id)
        {
            int result = 0;
            result = userRolesDAL.RemoveRoles(id);
            return result;
        }

        public DataTable GetRoles()
        {
            DataTable dtb = new DataTable();
            dtb = userRolesDAL.GetRoles();
            return dtb;
        }
    }
}