using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountListBLL
/// </summary>
public class GLAccountListBAL
{

    GLAccountListDAL gLAccountListDAL = new GLAccountListDAL();

	public GLAccountListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountList()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountListDAL.GetGLAccountList();
        return dtb;
    }

    public DataTable GetGLAccountListById(GLAccountListUI gLAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountListDAL.GetGLAccountListById(gLAccountListUI);
        return dtb;
    }

    public DataTable GetGLAccountListBySearchParameters(GLAccountListUI gLAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountListDAL.GetGLAccountListBySearchParameters(gLAccountListUI);
        return dtb;
    }

    public int DeleteGLAccount(GLAccountListUI gLAccountListUI)
    {
        int result = 0;
        result = gLAccountListDAL.DeleteGLAccount(gLAccountListUI);
        return result;
    }

    public DataTable GetGLAccountListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountListDAL.GetGLAccountListForExportToExcel();
        return dtb;
    }

}