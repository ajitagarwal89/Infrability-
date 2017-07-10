using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountFormatFormBAL
/// </summary>
public class GLAccountFormatFormBAL
{
    GLAccountFormatFormDAL gLAccountFormatFormDAL = new GLAccountFormatFormDAL();

	public GLAccountFormatFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountFormatListById(GLAccountFormatFormUI gLAccountFormatFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormatFormDAL.GetGLAccountFormatListById(gLAccountFormatFormUI);
        return dtb;
    }

    public int AddGLAccountFormat(GLAccountFormatFormUI gLAccountFormatFormUI)
    {
        int resutl = 0;
        resutl = gLAccountFormatFormDAL.AddGLAccountFormat(gLAccountFormatFormUI);
        return resutl;
    }

    public int UpdateGLAccountFormat(GLAccountFormatFormUI gLAccountFormatFormUI)
    {
        int resutl = 0;
        resutl = gLAccountFormatFormDAL.UpdateGLAccountFormat(gLAccountFormatFormUI);
        return resutl;
    }

    public int DeleteGLAccountFormat(GLAccountFormatFormUI gLAccountFormatFormUI)
    {
        int resutl = 0;
        resutl = gLAccountFormatFormDAL.DeleteGLAccountFormat(gLAccountFormatFormUI);
        return resutl;
    }

    public DataTable GetGLAccountFormatFormSelectByGLAccountFormatId(GLAccountFormatFormUI gLAccountFormatFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormatFormDAL.GetGLAccountFormatFormSelectByGLAccountFormatId(gLAccountFormatFormUI);
        return dtb;
    }

    public DataTable GetGLAccountFormatDetails_SelectBySegmentLenght(GLAccountFormatFormUI gLAccountFormatFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormatFormDAL.GetGLAccountFormatDetails_SelectBySegmentLenght(gLAccountFormatFormUI);
        return dtb;
    }


}