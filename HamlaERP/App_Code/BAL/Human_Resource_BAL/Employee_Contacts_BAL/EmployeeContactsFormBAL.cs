using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for EmployeeContactsFormBAL
/// </summary>
public class EmployeeContactsFormBAL
{
    EmployeeContactsFormDAL employeeContactsFormDAL = new EmployeeContactsFormDAL();

    public EmployeeContactsFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetEmployeeContactsListById(EmployeeContactsFormUI employeeContactsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeContactsFormDAL.GetEmployeeContactsListById(employeeContactsFormUI);
        return dtb;
    }

    public int AddEmployeeContacts(EmployeeContactsFormUI employeeContactsFormUI)
    {
        int resutl = 0;
        resutl = employeeContactsFormDAL.AddEmployeeContacts(employeeContactsFormUI);
        return resutl;
    }

    public int UpdateEmployeeContacts(EmployeeContactsFormUI employeeContactsFormUI)
    {
        int resutl = 0;
        resutl = employeeContactsFormDAL.UpdateEmployeeContacts(employeeContactsFormUI);
        return resutl;
    }

    public int DeleteEmployeeContacts(EmployeeContactsFormUI employeeContactsFormUI)
    {
        int resutl = 0;
        resutl = employeeContactsFormDAL.DeleteEmployeeContacts(employeeContactsFormUI);
        return resutl;
    }

}