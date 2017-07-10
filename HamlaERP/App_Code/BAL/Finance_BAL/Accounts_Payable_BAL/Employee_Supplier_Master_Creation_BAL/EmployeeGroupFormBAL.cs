using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EmployeeGroupFormBLL
/// </summary>
public class EmployeeGroupFormBAL
{
    EmployeeGroupFormDAL employeeGroupFormDAL = new EmployeeGroupFormDAL();
	public EmployeeGroupFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetEmployeeGroupListById(EmployeeGroupFormUI employeeGroupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeGroupFormDAL.GetEmployeeGroupListById(employeeGroupFormUI);
        return dtb;
    }

    public int AddEmployeeGroup(EmployeeGroupFormUI employeeGroupFormUI)
    {
        int resutl = 0;
        resutl = employeeGroupFormDAL.AddEmployeeGroup(employeeGroupFormUI);
        return resutl;
    }

    public int UpdateEmployeeGroup(EmployeeGroupFormUI employeeGroupFormUI)
    {
        int resutl = 0;
        resutl = employeeGroupFormDAL.UpdateEmployeeGroup(employeeGroupFormUI);
        return resutl;
    }

    public int DeleteEmployeeGroup(EmployeeGroupFormUI employeeGroupFormUI)
    {
        int resutl = 0;
        resutl = employeeGroupFormDAL.DeleteEmployeeGroup(employeeGroupFormUI);
        return resutl;
    }
}