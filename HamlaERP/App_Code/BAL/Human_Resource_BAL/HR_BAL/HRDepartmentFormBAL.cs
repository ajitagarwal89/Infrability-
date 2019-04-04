using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HRDepartmentFormBAL
/// </summary>
public class HRDepartmentFormBAL
{
    HRDepartmentFormDAL hRDepartmentFormDAL = new HRDepartmentFormDAL();
    public HRDepartmentFormBAL()
    {
        
    }

    public DataTable GetHRDepartmentListById(HRDepartmentFormUI HRDepartmentFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = hRDepartmentFormDAL.GetHRDepartmentListById(HRDepartmentFormUI);
        return dtb;
    }

    public int AddHRDepartment(HRDepartmentFormUI hRDepartmentFormUI)
    {
        int resutl = 0;
        resutl = hRDepartmentFormDAL.AddHRDepartment(hRDepartmentFormUI);
        return resutl;
    }

    public int UpdateHRDepartment(HRDepartmentFormUI hRDepartmentFormUI)
    {
        int resutl = 0;
        resutl = hRDepartmentFormDAL.UpdateHRDepartment(hRDepartmentFormUI);
        return resutl;
    }

    public int DeleteHRDepartment(HRDepartmentFormUI hRDepartmentFormUI)
    {
        int resutl = 0;
        resutl = hRDepartmentFormDAL.DeleteHRDepartment(hRDepartmentFormUI);
        return resutl;
    }
}