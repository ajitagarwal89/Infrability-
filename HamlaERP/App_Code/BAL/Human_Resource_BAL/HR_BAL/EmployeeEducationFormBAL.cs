using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmployeeEducationFormBAL
/// </summary>
public class EmployeeEducationFormBAL
{
    EmployeeEducationFormDAL employeeEducationFormDAL = new EmployeeEducationFormDAL();
    public EmployeeEducationFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetEmployeeEducationListById(EmployeeEducationFormUI employeeEducationFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = employeeEducationFormDAL.GetEmployeeEducationListById(employeeEducationFormUI);
        return dtb;
    }

    public int AddEmployeeEducation(EmployeeEducationFormUI employeeEducationFormUI)
    {
        int resutl = 0;
        resutl = employeeEducationFormDAL.AddEmployeeEducation(employeeEducationFormUI);
        return resutl;
    }

    public int UpdateEmployeeEducation(EmployeeEducationFormUI employeeEducationFormUI)
    {
        int resutl = 0;
        resutl = employeeEducationFormDAL.UpdateEmployeeEducation(employeeEducationFormUI);
        return resutl;
    }

    public int DeleteEmployeeEducation(EmployeeEducationFormUI employeeEducationFormUI)
    {
        int resutl = 0;
        resutl = employeeEducationFormDAL.DeleteEmployeeEducation(employeeEducationFormUI);
        return resutl;
    }
}