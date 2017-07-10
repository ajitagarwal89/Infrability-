using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UserListBLL
/// </summary>
public class UserListBAL
{
    UserListDAL userListDAL = new UserListDAL();
	public UserListBAL()
	{
        //
        // TODO: Add constructor logic here
        //
	}

    public DataTable GetUserList()
    {
        DataTable dtb = new DataTable();
        dtb = userListDAL.GetUserList();
        return dtb;
    }

    public DataTable GetUserListById(UserListUI userListUI)
    {
        DataTable dtb = new DataTable();
        dtb = userListDAL.GetUserListById(userListUI);
        return dtb;
    }

    public DataTable GetUserListBySearchParameters(UserListUI userListUI)
    {
        DataTable dtb = new DataTable();
        dtb = userListDAL.GetUserListBySearchParameters(userListUI);
        return dtb;
    }

    public int DeleteUser(UserListUI userListUI)
    {
        int result = 0;
        result = userListDAL.DeleteUser(userListUI);
        return result;
    }

}