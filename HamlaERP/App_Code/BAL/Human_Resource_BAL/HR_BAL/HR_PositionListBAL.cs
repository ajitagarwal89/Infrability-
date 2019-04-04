using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HR_PositionListBAL
/// </summary>
public class HR_PositionListBAL
{

    HR_PositionListDAL hR_PositionListDAL = new HR_PositionListDAL();

    public HR_PositionListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetHR_PositionList()
    {
        DataTable dtb = new DataTable();
        dtb = hR_PositionListDAL.GetHR_PositionList();
        return dtb;
    }
    public DataTable GetHR_PositionListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = hR_PositionListDAL.GetHR_PositionListForExportToExcel();
        return dtb;
    }
    public DataTable GetHR_PositionListById(HR_PositionListUI hR_PositionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = hR_PositionListDAL.GetHR_PositionListById(hR_PositionListUI);
        return dtb;
    }

    public DataTable GetHR_PositionListBySearchParameters(HR_PositionListUI hR_PositionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = hR_PositionListDAL.GetHR_PositionListBySearchParameters(hR_PositionListUI);
        return dtb;
    }

    public int DeleteHR_Position(HR_PositionListUI hR_PositionListUI)
    {
        int result = 0;
        result = hR_PositionListDAL.DeleteHR_Position(hR_PositionListUI);
        return result;
    }
}