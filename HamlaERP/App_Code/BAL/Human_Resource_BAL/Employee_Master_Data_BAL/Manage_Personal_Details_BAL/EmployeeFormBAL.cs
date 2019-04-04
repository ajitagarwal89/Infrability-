using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EmployeeFormBLL
/// </summary>
public class EmployeeFormBAL
{
    EmployeeFormDAL employeeFormDAL = new EmployeeFormDAL();
	public EmployeeFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetEmployeeListById(EmployeeFormUI employeeFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeFormDAL.GetEmployeeListById(employeeFormUI);
        return dtb;
    }

    public int AddEmployee(EmployeeFormUI employeeFormUI)
    {
        int resutl = 0;
        resutl = employeeFormDAL.AddEmployee(employeeFormUI);
        return resutl;
    }

    public int UpdateEmployee(EmployeeFormUI employeeFormUI)
    {
        int resutl = 0;
        resutl = employeeFormDAL.UpdateEmployee(employeeFormUI);
        return resutl;
    }

    public int DeleteEmployee(EmployeeFormUI employeeFormUI)
    {
        int resutl = 0;
        resutl = employeeFormDAL.DeleteEmployee(employeeFormUI);
        return resutl;
    }
    public DataTable GetSerialNumber(EmployeeFormUI employeeFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeFormDAL.GetSerialNumber(employeeFormUI);
        return dtb;
    }

}