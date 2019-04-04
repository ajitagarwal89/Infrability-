using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EmployeeListBLL
/// </summary>
public class EmployeeListBAL
{
    EmployeeListDAL employeeListDAL = new EmployeeListDAL();

    public EmployeeListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetEmployeeList()
    {
        DataTable dtb = new DataTable();
        dtb = employeeListDAL.GetEmployeeList();
        return dtb;
    }

    public DataTable GetEmployeeListById(EmployeeListUI employeeListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeListDAL.GetEmployeeListById(employeeListUI);
        return dtb;
    }

    public DataTable GetEmployeeListBySearchParameters(EmployeeListUI employeeListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeListDAL.GetEmployeeListBySearchParameters(employeeListUI);
        return dtb;
    }

    public DataTable GetEmployeeListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = employeeListDAL.GetEmployeeListForExportToExcel();
        return dtb;
    }

    public int DeleteEmployee(EmployeeListUI employeeListUI)
    {
        int result = 0;
        result = employeeListDAL.DeleteEmployee(employeeListUI);
        return result;
    }

}