using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for RolePageMappingBAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class RolePageMappingListBAL
    {
        RolePageMappingListDAL rolePageMappingListDAL = new RolePageMappingListDAL();

        public RolePageMappingListBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetRolePageMappingList(int rowId)
        {
            DataTable dtb = new DataTable();
            dtb = rolePageMappingListDAL.GetRolePageMappingListDAL(rowId);
            return dtb;
        }

        public int RemovePageMapping(int profileId)
        {
            int result = 0;
            result = rolePageMappingListDAL.RemovePageMapping(profileId);
            return result;
        }
    }
}