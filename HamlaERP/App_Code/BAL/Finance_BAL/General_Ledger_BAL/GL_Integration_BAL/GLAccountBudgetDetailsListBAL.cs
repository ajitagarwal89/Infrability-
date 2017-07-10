using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountBudgetDetailsListBLL
/// </summary>
public class GLAccountBudgetDetailsListBAL
{
    GLAccountBudgetDetailsListDAL gLAccountBudgetDetailsListDAL = new GLAccountBudgetDetailsListDAL();

	public GLAccountBudgetDetailsListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountBudgetDetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountBudgetDetailsListDAL.GetGLAccountBudgetDetailsListForExportToExcel();
        return dtb;
    }
    public DataTable GetGLAccountBudgetDetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountBudgetDetailsListDAL.GetGLAccountBudgetDetailsList();
        return dtb;
    }

    public DataTable GetGLAccountBudgetDetailsListById(GLAccountBudgetDetailsListUI gLAccountBudgetDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountBudgetDetailsListDAL.GetGLAccountBudgetDetailsListById(gLAccountBudgetDetailsListUI);
        return dtb;
    }

    public DataTable GetGLAccountBudgetDetailsListBySearchParameters(GLAccountBudgetDetailsListUI gLAccountBudgetDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountBudgetDetailsListDAL.GetGLAccountBudgetDetailsListBySearchParameters(gLAccountBudgetDetailsListUI);
        return dtb;
    }

    public int DeleteGLAccountBudgetDetails(GLAccountBudgetDetailsListUI gLAccountBudgetDetailsListUI)
    {
        int result = 0;
        result = gLAccountBudgetDetailsListDAL.DeleteGLAccountBudgetDetails(gLAccountBudgetDetailsListUI);
        return result;
    }
}