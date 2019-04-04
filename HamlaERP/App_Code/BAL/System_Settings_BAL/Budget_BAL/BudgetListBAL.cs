using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BudgetListBAL
/// </summary>
public class BudgetListBAL
{
    BudgetListDAL budgetListDAL = new BudgetListDAL();

	public BudgetListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetBudgetList()
    {
        DataTable dtb = new DataTable();
        dtb = budgetListDAL.GetBudgetList();
        return dtb;
    }
    public DataTable GetBudgetListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = budgetListDAL.GetBudgetListForExportToExcel();
        return dtb;
    }
    public DataTable GetBudgetListById(BudgetListUI budgetListUI)
    {
        DataTable dtb = new DataTable();
        dtb = budgetListDAL.GetBudgetListById(budgetListUI);
        return dtb;
    }

    public DataTable GetBudgetListBySearchParameters(BudgetListUI budgetListUI)
    {
        DataTable dtb = new DataTable();
        dtb = budgetListDAL.GetBudgetListBySearchParameters(budgetListUI);
        return dtb;
    }

    public int DeleteBudget(BudgetListUI budgetListUI)
    {
        int result = 0;
        result = budgetListDAL.DeleteBudget(budgetListUI);
        return result;
    }
}