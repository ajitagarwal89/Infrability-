using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountSummaryDetailsListBLL
/// </summary>
public class GLAccountSummaryDetailsListBAL
{
    GLAccountSummaryDetailsListDAL gLAccountSummaryDetailsListDAL = new GLAccountSummaryDetailsListDAL();

	public GLAccountSummaryDetailsListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountSummaryDetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSummaryDetailsListDAL.GetGLAccountSummaryDetailsList();
        return dtb;
    }

    public DataTable GetGLAccountSummaryDetailsListById(GLAccountSummaryDetailsListUI gLAccountSummaryDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSummaryDetailsListDAL.GetGLAccountSummaryDetailsListById(gLAccountSummaryDetailsListUI);
        return dtb;
    }

    public DataTable GetGLAccountSummaryDetailsListBySearchParameters(GLAccountSummaryDetailsListUI gLAccountSummaryDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSummaryDetailsListDAL.GetGLAccountSummaryDetailsListBySearchParameters(gLAccountSummaryDetailsListUI);
        return dtb;
    }

    public int DeleteGLAccountSummaryDetails(GLAccountSummaryDetailsListUI gLAccountSummaryDetailsListUI)
    {
        int result = 0;
        result = gLAccountSummaryDetailsListDAL.DeleteGLAccountSummaryDetails(gLAccountSummaryDetailsListUI);
        return result;
    }

    public DataTable GetGLAccountSummaryDetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountSummaryDetailsListDAL.GetGLAccountSummaryDetailsListForExportToExcel();
        return dtb;
    }

}