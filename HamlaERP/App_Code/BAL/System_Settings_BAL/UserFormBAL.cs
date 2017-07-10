using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for UserFormBLL
/// </summary>
public class UserFormBAL
{
    UserFormDAL userFormDAL = new UserFormDAL();
	public UserFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetUserListById(UserFormUI userFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = userFormDAL.GetUserListById(userFormUI);
        return dtb;
    }

    public int AddUser(UserFormUI userFormUI)
    {
        int resutl = 0;
        resutl = userFormDAL.AddUser(userFormUI);
        return resutl;
    }

    public int UpdateUser(UserFormUI userFormUI)
    {
        int resutl = 0;
        resutl = userFormDAL.UpdateUser(userFormUI);
        return resutl;
    }

    public int DeleteUser(UserFormUI userFormUI)
    {
        int resutl = 0;
        resutl = userFormDAL.DeleteUser(userFormUI);
        return resutl;
    }
}