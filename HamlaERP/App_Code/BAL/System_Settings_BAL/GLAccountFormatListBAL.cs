using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountFormatListBLL
/// </summary>
public class GLAccountFormatListBAL
{
    GLAccountFormatListDAL gLAccountFormatListDAL = new GLAccountFormatListDAL();

	public GLAccountFormatListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountFormatList()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormatListDAL.GetGLAccountFormatList();
        return dtb;
    }

    public DataTable GetGLAccountFormatListById(GLAccountFormatListUI gLAccountFormatListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormatListDAL.GetGLAccountFormatListById(gLAccountFormatListUI);
        return dtb;
    }

    public DataTable GetGLAccountFormatListBySearchParameters(GLAccountFormatListUI gLAccountFormatListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormatListDAL.GetGLAccountFormatListBySearchParameters(gLAccountFormatListUI);
        return dtb;
    }

    public int DeleteGLAccountFormat(GLAccountFormatListUI gLAccountFormatListUI)
    {
        int result = 0;
        result = gLAccountFormatListDAL.DeleteGLAccountFormat(gLAccountFormatListUI);
        return result;
    }
}