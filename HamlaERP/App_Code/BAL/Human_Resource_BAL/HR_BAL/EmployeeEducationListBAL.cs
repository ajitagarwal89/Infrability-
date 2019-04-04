using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeEducationListBAL
/// </summary>
public class EmployeeEducationListBAL
{
    EmployeeEducationListDAL employeeEducationListDAL = new EmployeeEducationListDAL();
    public EmployeeEducationListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetEmployeeEducationList()
    {
        DataTable dtb = new DataTable();
        dtb = employeeEducationListDAL.GetEmployeeEducationList();
        return dtb;
    }

    public DataTable GetEmployeeEducationListById(EmployeeEducationListUI employeeEducationListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeEducationListDAL.GetEmployeeEducationListById(employeeEducationListUI);
        return dtb;
    }

    public DataTable GetEmployeeEducationListBySearchParameters(EmployeeEducationListUI employeeEducationListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeEducationListDAL.GetEmployeeEducationListBySearchParameters(employeeEducationListUI);
        return dtb;
    }

    public int DeleteEmployeeEducation(EmployeeEducationListUI employeeEducationListUI)
    {
        int result = 0;
        result = employeeEducationListDAL.DeleteEmployeeEducationt(employeeEducationListUI);
        return result;
    }

    public DataTable GetEmployeeEducationListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = employeeEducationListDAL.GetEmployeeEducationListForExportToExcel();
        return dtb;
    }
}