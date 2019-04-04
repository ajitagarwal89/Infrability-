using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountCategoryFormBLL
/// </summary>
public class GLAccountCategoryFormBAL
{
    GLAccountCategoryFormDAL gLAccountCategoryFormDAL = new GLAccountCategoryFormDAL();

	public GLAccountCategoryFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountCategoryListById(GLAccountCategoryFormUI gLAccountCategoryFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountCategoryFormDAL.GetGLAccountCategoryListById(gLAccountCategoryFormUI);
        return dtb;
    }

    public int AddGLAccountCategory(GLAccountCategoryFormUI gLAccountCategoryFormUI)
    {
        int resutl = 0;
        resutl = gLAccountCategoryFormDAL.AddGLAccountCategory(gLAccountCategoryFormUI);
        return resutl;
    }

    public int UpdateGLAccountCategory(GLAccountCategoryFormUI gLAccountCategoryFormUI)
    {
        int resutl = 0;
        resutl = gLAccountCategoryFormDAL.UpdateGLAccountCategory(gLAccountCategoryFormUI);
        return resutl;
    }

    public int DeleteGLAccountCategory(GLAccountCategoryFormUI gLAccountCategoryFormUI)
    {
        int resutl = 0;
        resutl = gLAccountCategoryFormDAL.DeleteGLAccountCategory(gLAccountCategoryFormUI);
        return resutl;
    }
}