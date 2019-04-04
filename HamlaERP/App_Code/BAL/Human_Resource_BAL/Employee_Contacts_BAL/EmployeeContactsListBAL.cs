using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for EmployeeContactsListBAL
/// </summary>
public class EmployeeContactsListBAL
{
    EmployeeContactsListDAL employeeContactsListDAL = new EmployeeContactsListDAL();

    public EmployeeContactsListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetEmployeeContactsList()
    {
        DataTable dtb = new DataTable();
        dtb = employeeContactsListDAL.GetEmployeeContactsList();
        return dtb;
    }
    public DataTable GetEmployeeContactsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = employeeContactsListDAL.GetEmployeeContactsListForExportToExcel();
        return dtb;
    }
    public DataTable GetEmployeeContactsListById(EmployeeContactsListUI employeeContactsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeContactsListDAL.GetEmployeeContactsListById(employeeContactsListUI);
        return dtb;
    }

    public DataTable GetEmployeeContactsListBySearchParameters(EmployeeContactsListUI employeeContactsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeContactsListDAL.GetEmployeeContactsListBySearchParameters(employeeContactsListUI);
        return dtb;
    }

    public int DeleteEmployeeContacts(EmployeeContactsListUI employeeContactsListUI)
    {
        int result = 0;
        result = employeeContactsListDAL.DeleteEmployeeContacts(employeeContactsListUI);
        return result;
    }
}