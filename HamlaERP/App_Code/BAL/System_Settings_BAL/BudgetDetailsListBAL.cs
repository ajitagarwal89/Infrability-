using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BudgetDetailsListBAL
/// </summary>
public class BudgetDetailsListBAL
{
    BudgetDetailsListDAL budgetDetailsListDAL = new BudgetDetailsListDAL();

	public BudgetDetailsListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetBudgetDetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = budgetDetailsListDAL.GetBudgetDetailsList();
        return dtb;
    }
    public DataTable GetBudgetDetailsForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = budgetDetailsListDAL.GetBudgetDetailsForExportToExcel();
        return dtb;
    }
    public DataTable GetBudgetDetailsListById(BudgetDetailsListUI budgetDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = budgetDetailsListDAL.GetBudgetDetailsListById(budgetDetailsListUI);
        return dtb;
    }

    public int DeleteBudgetDetails(BudgetDetailsListUI budgetDetailsListUI)
    {
        int result = 0;
        result = budgetDetailsListDAL.DeleteBudgetDetails(budgetDetailsListUI);
        return result;
    }


    public DataTable GetBudgetListBySearchParameters(BudgetDetailsListUI budgetDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = budgetDetailsListDAL.GetBudgetDetailsListBySearchParameters(budgetDetailsListUI);
        return dtb;
    }
}