using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EmployeeAndGroupAccountListBLL
/// </summary>
public class EmployeeAndGroupAccountListBAL
{
    EmployeeAndGroupAccountListDAL employeeAndGroupAccountListDAL = new EmployeeAndGroupAccountListDAL();
	public EmployeeAndGroupAccountListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetEmployeeAndGroupAccountList()
    {
        DataTable dtb = new DataTable();
        dtb = employeeAndGroupAccountListDAL.GetEmployeeAndGroupAccountList();
        return dtb;
    }

    public DataTable GetEmployeeAndGroupAccountListById(EmployeeAndGroupAccountListUI employeeAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeAndGroupAccountListDAL.GetEmployeeAndGroupAccountListById(employeeAndGroupAccountListUI);
        return dtb;
    }

    public DataTable GetEmployeeAndGroupAccountListBySearchParameters(EmployeeAndGroupAccountListUI employeeAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeAndGroupAccountListDAL.GetEmployeeAndGroupAccountListBySearchParameters(employeeAndGroupAccountListUI);
        return dtb;
    }

    public int DeleteEmployeeAndGroupAccount(EmployeeAndGroupAccountListUI employeeAndGroupAccountListUI)
    {
        int result = 0;
        result = employeeAndGroupAccountListDAL.DeleteEmployeeAndGroupAccount(employeeAndGroupAccountListUI);
        return result;
    }
}