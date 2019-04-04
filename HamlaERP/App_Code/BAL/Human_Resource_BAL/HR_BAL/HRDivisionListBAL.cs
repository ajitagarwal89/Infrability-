using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HRDivisionListBLL
/// </summary>
public class HRDivisionListBAL
{

    HRDivisionListDAL hRDivisionListDAL = new HRDivisionListDAL();

    public HRDivisionListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetHRDivisionList()
    {
        DataTable dtb = new DataTable();
        dtb = hRDivisionListDAL.GetHRDivisionList();
        return dtb;
    }

    public DataTable GetHRDivisionListById(HRDivisionListUI hRDivisionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = hRDivisionListDAL.GetHRDivisionListById(hRDivisionListUI);
        return dtb;
    }

    public DataTable GetHRDivisionListBySearchParameters(HRDivisionListUI hRDivisionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = hRDivisionListDAL.GetHRDivisionListBySearchParameters(hRDivisionListUI);
        return dtb;
    }

    public int DeleteHRDivision(HRDivisionListUI hRDivisionListUI)
    {
        int result = 0;
        result = hRDivisionListDAL.DeleteHRDivision(hRDivisionListUI);
        return result;
    }

    public DataTable GetHRDivisionListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = hRDivisionListDAL.GetHRDivisionListForExportToExcel();
        return dtb;
    }

}