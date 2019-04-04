using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HRDepartmentListBAL
/// </summary>
public class HRDepartmentListBAL
{
    HRDepartmentListDAL hRDepartmentListDAL = new HRDepartmentListDAL();
    public HRDepartmentListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetHRDepartmentList()
    {
        DataTable dtb = new DataTable();
        dtb = hRDepartmentListDAL.GetHRDepartmentList();
        return dtb;
    }

    public DataTable GetHRDepartmentListById(HRDepartmentListUI hRDepartmentListUI)
    {
        DataTable dtb = new DataTable();
        dtb = hRDepartmentListDAL.GetHRDepartmentListById(hRDepartmentListUI);
        return dtb;
    }

    public DataTable GetHRDepartmentListBySearchParameters(HRDepartmentListUI hRDepartmentListUI)
    {
        DataTable dtb = new DataTable();
        dtb = hRDepartmentListDAL.GetHRDepartmentListBySearchParameters(hRDepartmentListUI);
        return dtb;
    }

    public int DeleteHRDepartment(HRDepartmentListUI hRDepartmentListUI)
    {
        int result = 0;
        result = hRDepartmentListDAL.DeleteHRDepartment(hRDepartmentListUI);
        return result;
    }

    public DataTable GetHRDepartmentListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = hRDepartmentListDAL.GetHRDepartmentListForExportToExcel();
        return dtb;
    }
}