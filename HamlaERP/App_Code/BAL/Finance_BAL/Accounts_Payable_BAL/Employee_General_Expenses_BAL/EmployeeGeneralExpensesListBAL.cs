using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EmployeeGeneralExpensesListBLL
/// </summary>
public class EmployeeGeneralExpensesListBAL
{
    EmployeeGeneralExpensesListDAL employeeGeneralExpensesListDAL = new EmployeeGeneralExpensesListDAL();
	public EmployeeGeneralExpensesListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetEmployeeGeneralExpensesList()
    {
        DataTable dtb = new DataTable();
        dtb = employeeGeneralExpensesListDAL.GetEmployeeGeneralExpensesList();
        return dtb;
    }

    public DataTable GetEmployeeGeneralExpensesListById(EmployeeGeneralExpensesListUI employeeGeneralExpensesListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeGeneralExpensesListDAL.GetEmployeeGeneralExpensesListById(employeeGeneralExpensesListUI);
        return dtb;
    }

    public DataTable GetEmployeeGeneralExpensesListBySearchParameters(EmployeeGeneralExpensesListUI employeeGeneralExpensesListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeGeneralExpensesListDAL.GetEmployeeGeneralExpensesListBySearchParameters(employeeGeneralExpensesListUI);
        return dtb;
    }

    public int DeleteEmployeeGeneralExpenses(EmployeeGeneralExpensesListUI employeeGeneralExpensesListUI)
    {
        int result = 0;
        result = employeeGeneralExpensesListDAL.DeleteEmployeeGeneralExpenses(employeeGeneralExpensesListUI);
        return result;
    }

    public DataTable GetEmployeeGeneralExpensesListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = employeeGeneralExpensesListDAL.GetEmployeeGeneralExpensesListForExportToExcel();
        return dtb;
    }

}