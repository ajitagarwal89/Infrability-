using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountFormatDetailsListBAL
/// </summary>
public class GLAccountFormatDetailsListBAL
{
    GLAccountFormatDetailsListDAL gLAccountFormatDetailsListDAL = new GLAccountFormatDetailsListDAL();

    public GLAccountFormatDetailsListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountFormatDetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormatDetailsListDAL.GetGLAccountFormatDetailsList();
        return dtb;
    }


    public DataTable GetGLAccountFormatDetailsListById(GLAccountFormatDetailsListUI gLAccountFormatDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormatDetailsListDAL.GetGLAccountFormatDetailsListById(gLAccountFormatDetailsListUI);
        return dtb;
    }

    public DataTable GetGLAccountFormatDetailsListByGLAccountFormatId(GLAccountFormatDetailsListUI gLAccountFormatDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormatDetailsListDAL.GetGLAccountFormatDetailsListByGLAccountFormatId(gLAccountFormatDetailsListUI);
        return dtb;
    }


    public DataTable GetGLAccountFormatDetailsListBySearchParameters(GLAccountFormatDetailsListUI gLAccountFormatDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormatDetailsListDAL.GetGLAccountFormatDetailsListBySearchParameters(gLAccountFormatDetailsListUI);
        return dtb;
    }

    public int DeleteGLAccountFormatDetails(GLAccountFormatDetailsListUI gLAccountFormatDetailsListUI)
    {
        int result = 0;
        result = gLAccountFormatDetailsListDAL.DeleteGLAccountFormatDetails(gLAccountFormatDetailsListUI);
        return result;
    }

    public DataTable GetGLAccountFormatDetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountFormatDetailsListDAL.GetGLAccountFormatDetailsListExportToExcel();
        return dtb;
    }
}