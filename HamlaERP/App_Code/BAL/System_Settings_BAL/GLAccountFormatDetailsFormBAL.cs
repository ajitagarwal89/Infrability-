using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountFormatDetailsFormBAL
/// </summary>
public class GLAccountFormatDetailsFormBAL
{
    GLAccountFormatDetailsFormDAL gLAccountFormatDetailsFormDAL = new GLAccountFormatDetailsFormDAL();

    public GLAccountFormatDetailsFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountFormatDetailsListById(GLAccountFormatDetailsFormUI gLAccountFormatDetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormatDetailsFormDAL.GetGLAccountFormatDetailsListById(gLAccountFormatDetailsFormUI);
        return dtb;
    }

    public int AddGLAccountFormatDetails(GLAccountFormatDetailsFormUI gLAccountFormatDetailsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountFormatDetailsFormDAL.AddGLAccountFormatDetails(gLAccountFormatDetailsFormUI);
        return resutl;
    }

    public int UpdateGLAccountFormatDetails(GLAccountFormatDetailsFormUI gLAccountFormatDetailsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountFormatDetailsFormDAL.UpdateGLAccountFormatDetails(gLAccountFormatDetailsFormUI);
        return resutl;
    }

    public int UpdateGLAccountFormatDetailsSegmentLenght(GLAccountFormatDetailsFormUI gLAccountFormatDetailsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountFormatDetailsFormDAL.UpdateGLAccountFormatDetailsSegmentLenght(gLAccountFormatDetailsFormUI);
        return resutl;
    }

    public int DeleteGLAccountFormatDetails(GLAccountFormatDetailsFormUI gLAccountFormatDetailsFormUI)
    {
        int resutl = 0;
        resutl = gLAccountFormatDetailsFormDAL.DeleteGLAccountFormatDetails(gLAccountFormatDetailsFormUI);
        return resutl;
    }
    public DataTable GetGLAccountFormatDetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormatDetailsFormDAL.GetGLAccountFormatDetailsListForExportToExcel();
        return dtb;
    }



}