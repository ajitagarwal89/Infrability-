using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BudgetDetailsFormBAL
/// </summary>
public class BudgetDetailsFormBAL
{
    BudgetDetailsFormDAL budgetDetailsFormDAL = new BudgetDetailsFormDAL();

	public BudgetDetailsFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetBudgetDetailsListById(BudgetDetailsFormUI budgetDetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = budgetDetailsFormDAL.GetBudgetDetailsListById(budgetDetailsFormUI);
        return dtb;
    }

    public int AddBudgetDetails(BudgetDetailsFormUI budgetDetailsFormUI)
    {
        int resutl = 0;
        resutl = budgetDetailsFormDAL.AddBudgetDetails(budgetDetailsFormUI);
        return resutl;
    }

    public int UpdateBudgetDetails(BudgetDetailsFormUI budgetDetailsFormUI)
    {
        int resutl = 0;
        resutl = budgetDetailsFormDAL.UpdateBudgetDetails(budgetDetailsFormUI);
        return resutl;
    }

    public int DeleteBudgetDetails(BudgetDetailsFormUI budgetDetailsFormUI)
    {
        int resutl = 0;
        resutl = budgetDetailsFormDAL.DeleteBudgetDetails(budgetDetailsFormUI);
        return resutl;
    }
}