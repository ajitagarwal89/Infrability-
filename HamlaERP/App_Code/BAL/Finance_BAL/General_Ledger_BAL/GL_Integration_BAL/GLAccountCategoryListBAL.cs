using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountCategoryListBLL
/// </summary>
public class GLAccountCategoryListBAL
{

    GLAccountCategoryListDAL gLAccountCategoryListDAL = new GLAccountCategoryListDAL();

	public GLAccountCategoryListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountCategoryList()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountCategoryListDAL.GetGLAccountCategoryList();
        return dtb;
    }

    public DataTable GetGLAccountCategoryListById(GLAccountCategoryListUI gLAccountCategoryListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountCategoryListDAL.GetGLAccountCategoryListById(gLAccountCategoryListUI);
        return dtb;
    }

    public DataTable GetGLAccountCategoryListBySearchParameters(GLAccountCategoryListUI gLAccountCategoryListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountCategoryListDAL.GetGLAccountCategoryListBySearchParameters(gLAccountCategoryListUI);
        return dtb;
    }

    public int DeleteGLAccountCategory(GLAccountCategoryListUI gLAccountCategoryListUI)
    {
        int result = 0;
        result = gLAccountCategoryListDAL.DeleteGLAccountCategory(gLAccountCategoryListUI);
        return result;
    }

    public DataTable GetGLAccountCategoryListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountCategoryListDAL.GetGLAccountCategoryListForExportToExcel();
        return dtb;
    }

}