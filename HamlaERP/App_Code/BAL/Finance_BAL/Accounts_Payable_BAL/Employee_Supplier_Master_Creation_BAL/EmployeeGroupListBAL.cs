using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EmployeeGroupListBLL
/// </summary>
public class EmployeeGroupListBAL
{
    EmployeeGroupListDAL employeeGroupListDAL = new EmployeeGroupListDAL();

	public EmployeeGroupListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetEmployeeGroupList()
    {
        DataTable dtb = new DataTable();
        dtb = employeeGroupListDAL.GetEmployeeGroupList();
        return dtb;
    }

    public DataTable GetEmployeeGroupListById(EmployeeGroupListUI employeeGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeGroupListDAL.GetEmployeeGroupListById(employeeGroupListUI);
        return dtb;
    }

    public DataTable GetEmployeeGroupListBySearchParameters(EmployeeGroupListUI employeeGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeGroupListDAL.GetEmployeeGroupListBySearchParameters(employeeGroupListUI);
        return dtb;
    }

    public int DeleteEmployeeGroup(EmployeeGroupListUI employeeGroupListUI)
    {
        int result = 0;
        result = employeeGroupListDAL.DeleteEmployeeGroup(employeeGroupListUI);
        return result;
    }
    public DataTable GetEmployeeGroupListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = employeeGroupListDAL.GetEmployeeGroupListForExportToExcel();
        return dtb;
    }
}