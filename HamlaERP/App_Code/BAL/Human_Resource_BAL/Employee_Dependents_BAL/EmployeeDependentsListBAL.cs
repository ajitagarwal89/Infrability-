using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EmployeeDependentsListBLL
/// </summary>
public class EmployeeDependentsListBAL
{
    EmployeeDependentsListDAL employeeDependentsListDAL = new EmployeeDependentsListDAL();
    public EmployeeDependentsListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetEmployeeDependentsList()
    {
        DataTable dtb = new DataTable();
        dtb = employeeDependentsListDAL.GetEmployeeDependentsList();
        return dtb;
    }

    public DataTable GetEmployeeDependentsListById(EmployeeDependentsListUI employeeDependentsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeDependentsListDAL.GetEmployeeDependentsListById(employeeDependentsListUI);
        return dtb;
    }

    public DataTable GetEmployeeDependentsListBySearchParameters(EmployeeDependentsListUI employeeDependentsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeDependentsListDAL.GetEmployeeDependentsListBySearchParameters(employeeDependentsListUI);
        return dtb;
    }

    public DataTable GetEmployeeDependentsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = employeeDependentsListDAL.GetEmployeeDependentsListForExportToExcel();
        return dtb;
    }

    public int DeleteEmployeeDependents(EmployeeDependentsListUI employeeDependentsListUI)
    {
        int result = 0;
        result = employeeDependentsListDAL.DeleteEmployeeDependents(employeeDependentsListUI);
        return result;
    }
}