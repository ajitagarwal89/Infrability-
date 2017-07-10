using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountFormBLL
/// </summary>
public class GLAccountFormBAL
{
    GLAccountFormDAL gLAccountFormDAL = new GLAccountFormDAL();

	public GLAccountFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountListById(GLAccountFormUI gLAccountFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormDAL.GetGLAccountListById(gLAccountFormUI);
        return dtb;
    }

    public int AddGLAccount(GLAccountFormUI gLAccountFormUI)
    {
        int resutl = 0;
        resutl = gLAccountFormDAL.AddGLAccount(gLAccountFormUI);
        return resutl;
    }

    public int UpdateGLAccount(GLAccountFormUI gLAccountFormUI)
    {
        int resutl = 0;
        resutl = gLAccountFormDAL.UpdateGLAccount(gLAccountFormUI);
        return resutl;
    }

    public int DeleteGLAccount(GLAccountFormUI gLAccountFormUI)
    {
        int resutl = 0;
        resutl = gLAccountFormDAL.DeleteGLAccount(gLAccountFormUI);
        return resutl;
    }
}