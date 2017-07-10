using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EmployeeAndGroupAccountFormBLL
/// </summary>
public class EmployeeAndGroupAccountFormBAL
{
    EmployeeAndGroupAccountFormDAL employeeAndGroupAccountFormDAL = new EmployeeAndGroupAccountFormDAL();
	public EmployeeAndGroupAccountFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetEmployeeAndGroupAccountListById(EmployeeAndGroupAccountFormUI employeeAndGroupAccountFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeAndGroupAccountFormDAL.GetEmployeeAndGroupAccountListById(employeeAndGroupAccountFormUI);
        return dtb;
    }

    public int AddEmployeeAndGroupAccount(EmployeeAndGroupAccountFormUI employeeAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = employeeAndGroupAccountFormDAL.AddEmployeeAndGroupAccount(employeeAndGroupAccountFormUI);
        return resutl;
    }

    public int UpdateEmployeeAndGroupAccount(EmployeeAndGroupAccountFormUI employeeAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = employeeAndGroupAccountFormDAL.UpdateEmployeeAndGroupAccount(employeeAndGroupAccountFormUI);
        return resutl;
    }

    public int DeleteEmployeeAndGroupAccount(EmployeeAndGroupAccountFormUI employeeAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = employeeAndGroupAccountFormDAL.DeleteEmployeeAndGroupAccount(employeeAndGroupAccountFormUI);
        return resutl;
    }
}