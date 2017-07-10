using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for GLAccountBudgetListBLL
/// </summary>
public class GLAccountBudgetListBAL
{
    GLAccountBudgetListDAL gLAccountBudgetListDAL = new GLAccountBudgetListDAL();

	public GLAccountBudgetListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetGLAccountBudgetList()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountBudgetListDAL.GetGLAccountBudgetList();
        return dtb;
    }
    public DataTable GetGLAccountBudgetListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountBudgetListDAL.GetGLAccountBudgetListForExportToExcel();
        return dtb;
    }
    public DataTable GetGLAccountBudgetListById(GLAccountBudgetListUI gLAccountBudgetListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountBudgetListDAL.GetGLAccountBudgetListById(gLAccountBudgetListUI);
        return dtb;
    }

    public DataTable GetGLAccountBudgetListBySearchParameters(GLAccountBudgetListUI gLAccountBudgetListUI)
    {
        DataTable dtb = new DataTable();
        dtb = gLAccountBudgetListDAL.GetGLAccountBudgetListBySearchParameters(gLAccountBudgetListUI);
        return dtb;
    }

    public int DeleteGLAccountBudget(GLAccountBudgetListUI gLAccountBudgetListUI)
    {
        int result = 0;
        result = gLAccountBudgetListDAL.DeleteGLAccountBudget(gLAccountBudgetListUI);
        return result;
    }
}