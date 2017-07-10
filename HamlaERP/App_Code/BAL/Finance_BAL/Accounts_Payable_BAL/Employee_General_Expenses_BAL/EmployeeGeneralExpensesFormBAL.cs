using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EmployeeGeneralExpensesFormBLL
/// </summary>
public class EmployeeGeneralExpensesFormBAL
{
    EmployeeGeneralExpensesFormDAL employeeGeneralExpensesFormDAL = new EmployeeGeneralExpensesFormDAL();
	public EmployeeGeneralExpensesFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetEmployeeGeneralExpensesListById(EmployeeGeneralExpensesFormUI employeeGeneralExpensesFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeGeneralExpensesFormDAL.GetEmployeeGeneralExpensesListById(employeeGeneralExpensesFormUI);
        return dtb;
    }
    public int AddEmployeeGeneralExpenses(EmployeeGeneralExpensesFormUI employeeGeneralExpensesFormUI)
    {
        int resutl = 0;
        resutl = employeeGeneralExpensesFormDAL.AddEmployeeGeneralExpenses(employeeGeneralExpensesFormUI);
        return resutl;
    }

    public int UpdateEmployeeGeneralExpenses(EmployeeGeneralExpensesFormUI employeeGeneralExpensesFormUI)
    {
        int resutl = 0;
        resutl = employeeGeneralExpensesFormDAL.UpdateEmployeeGeneralExpenses(employeeGeneralExpensesFormUI);
        return resutl;
    }

    public int DeleteEmployeeGeneralExpenses(EmployeeGeneralExpensesFormUI employeeGeneralExpensesFormUI)
    {
        int resutl = 0;
        resutl = employeeGeneralExpensesFormDAL.DeleteEmployeeGeneralExpenses(employeeGeneralExpensesFormUI);
        return resutl;
    }
}