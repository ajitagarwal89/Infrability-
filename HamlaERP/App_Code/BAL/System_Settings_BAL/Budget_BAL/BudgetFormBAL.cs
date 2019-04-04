using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BudgetFormBAL
/// </summary>
public class BudgetFormBAL
{
    BudgetFormDAL budgetFormDAL = new BudgetFormDAL();

	public BudgetFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetBudgetListById(BudgetFormUI budgetFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = budgetFormDAL.GetBudgetListById(budgetFormUI);
        return dtb;
    }

    public int AddBudget(BudgetFormUI budgetFormUI)
    {
        int resutl = 0;
        resutl = budgetFormDAL.AddBudget(budgetFormUI);
        return resutl;
    }

    public int UpdateBudget(BudgetFormUI budgetFormUI)
    {
        int resutl = 0;
        resutl = budgetFormDAL.UpdateBudget(budgetFormUI);
        return resutl;
    }

    public int DeleteBudget(BudgetFormUI budgetFormUI)
    {
        int resutl = 0;
        resutl = budgetFormDAL.DeleteBudget(budgetFormUI);
        return resutl;
    }
}