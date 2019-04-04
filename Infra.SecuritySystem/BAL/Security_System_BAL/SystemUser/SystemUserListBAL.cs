using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SystemUserListBAL
/// </summary>
namespace Infra.SecuritySystem
{
    public class SystemUserListBAL
    {
        SystemUserListDAL systemUserListDAL = new SystemUserListDAL();

        public SystemUserListBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataTable GetUserList()
        {
            DataTable dtb = new DataTable();
            dtb = systemUserListDAL.GetUserList();
            return dtb;
        }

        public DataTable GetUser(int id)
        {
            DataTable dtb = new DataTable();
            dtb = systemUserListDAL.GetUser(id);
            return dtb;
        }

        public int DeleteUser(string id)
        {
            int result = 0;
            result = systemUserListDAL.DeleteUser(id);
            return result;
        }

        public DataTable GetRoles(int id)
        {
            DataTable dtb = new DataTable();
            dtb = systemUserListDAL.GetRoles(id);
            return dtb;
        }

        public int LockUser(int userId, int num)
        {
            int result = 0;
            result = systemUserListDAL.LockUser(userId, num);
            return result;
        }

        public int ActivateUser(int userId, int num)
        {
            int result = 0;
            result = systemUserListDAL.ActivateUser(userId, num);
            return result;
        }

        public int ResetPassword(int id)
        {
            int result = 0;
            result = systemUserListDAL.ResetPassword(id);
            return result;
        }

        public DataTable CheckUserExists(string userId)
        {
            DataTable dtb = new DataTable();
            dtb = systemUserListDAL.CheckUserExists(userId);
            return dtb;
        }
    }
}