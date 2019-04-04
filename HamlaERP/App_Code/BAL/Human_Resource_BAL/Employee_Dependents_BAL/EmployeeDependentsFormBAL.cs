using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EmployeeDependentsFormBLL
/// </summary>
public class EmployeeDependentsFormBAL
{
    EmployeeDependentsFormDAL employeeDependentsFormDAL = new EmployeeDependentsFormDAL();
	public EmployeeDependentsFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetEmployeeDependentsListById(EmployeeDependentsFormUI employeeDependentsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeDependentsFormDAL.GetEmployeeDependentsListById(employeeDependentsFormUI);
        return dtb;
    }

    public int AddEmployeeDependents(EmployeeDependentsFormUI employeeDependentsFormUI)
    {
        int resutl = 0;
        resutl = employeeDependentsFormDAL.AddEmployeeDependents(employeeDependentsFormUI);
        return resutl;
    }

    public int UpdateEmployeeDependents(EmployeeDependentsFormUI employeeDependentsFormUI)
    {
        int resutl = 0;
        resutl = employeeDependentsFormDAL.UpdateEmployeeDependents(employeeDependentsFormUI);
        return resutl;
    }

    public int DeleteEmployeeDependents(EmployeeDependentsFormUI employeeDependentsFormUI)
    {
        int resutl = 0;
        resutl = employeeDependentsFormDAL.DeleteEmployeeDependents(employeeDependentsFormUI);
        return resutl;
    }
}