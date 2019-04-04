using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HR_SupervisorListBAL
/// </summary>
public class HR_SupervisorListBAL
{

    HR_SupervisorListDAL hR_SupervisorListDAL = new HR_SupervisorListDAL();

    public HR_SupervisorListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetHR_SupervisorList()
    {
        DataTable dtb = new DataTable();
        dtb = hR_SupervisorListDAL.GetHR_SupervisorList();
        return dtb;
    }
    public DataTable GetHR_SupervisorListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = hR_SupervisorListDAL.GetHR_SupervisorListForExportToExcel();
        return dtb;
    }
    public DataTable GetHR_SupervisorListById(HR_SupervisorListUI hR_SupervisorListUI)
    {
        DataTable dtb = new DataTable();
        dtb = hR_SupervisorListDAL.GetHR_SupervisorListById(hR_SupervisorListUI);
        return dtb;
    }

    public DataTable GetHR_SupervisorListBySearchParameters(HR_SupervisorListUI hR_SupervisorListUI)
    {
        DataTable dtb = new DataTable();
        dtb = hR_SupervisorListDAL.GetHR_SupervisorListBySearchParameters(hR_SupervisorListUI);
        return dtb;
    }

    public int DeleteHR_Supervisor(HR_SupervisorListUI hR_SupervisorListUI)
    {
        int result = 0;
        result = hR_SupervisorListDAL.DeleteHR_Supervisor(hR_SupervisorListUI);
        return result;
    }
}