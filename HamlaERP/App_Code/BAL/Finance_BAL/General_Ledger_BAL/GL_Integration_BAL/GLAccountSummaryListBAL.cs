using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountSummaryListBLL
/// </summary>
public class GLAccountSummaryListBAL
{

    GLAccountSummaryListDAL gLAccountSummaryListDAL = new GLAccountSummaryListDAL();

	public GLAccountSummaryListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountSummaryList()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSummaryListDAL.GetGLAccountSummaryList();
        return dtb;
    }

    public DataTable GetGLAccountSummaryListById(GLAccountSummaryListUI gLAccountSummaryListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSummaryListDAL.GetGLAccountSummaryListById(gLAccountSummaryListUI);
        return dtb;
    }

    public DataTable GetGLAccountSummaryListBySearchParameters(GLAccountSummaryListUI gLAccountSummaryListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSummaryListDAL.GetGLAccountSummaryListBySearchParameters(gLAccountSummaryListUI);
        return dtb;
    }

    public int DeleteGLAccountSummary(GLAccountSummaryListUI gLAccountSummaryListUI)
    {
        int result = 0;
        result = gLAccountSummaryListDAL.DeleteGLAccountSummary(gLAccountSummaryListUI);
        return result;
    }

    public DataTable GetGLAccountSummaryListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSummaryListDAL.GetGLAccountSummaryListForExportToExcel();
        return dtb;
    }

}
