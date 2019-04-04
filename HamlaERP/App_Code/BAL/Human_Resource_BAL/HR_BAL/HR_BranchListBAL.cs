using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HR_BranchListBAL
/// </summary>
public class HR_BranchListBAL
{
    HR_BranchListDAL hR_BranchListDAL = new HR_BranchListDAL();

    public HR_BranchListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetHR_BranchList()
    {
        DataTable dtb = new DataTable();
        dtb = hR_BranchListDAL.GetHR_BranchList();
        return dtb;
    }
    public DataTable GetHR_BranchListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = hR_BranchListDAL.GetHR_BranchListForExportToExcel();
        return dtb;
    }
    public DataTable GetHR_BranchListById(HR_BranchListUI hR_BranchListUI)
    {
        DataTable dtb = new DataTable();
        dtb = hR_BranchListDAL.GetHR_BranchListById(hR_BranchListUI);
        return dtb;
    }

    public DataTable GetHR_BranchListBySearchParameters(HR_BranchListUI hR_BranchListUI)
    {
        DataTable dtb = new DataTable();
        dtb = hR_BranchListDAL.GetHR_BranchListBySearchParameters(hR_BranchListUI);
        return dtb;
    }

    public int DeleteHR_Branch(HR_BranchListUI hR_BranchListUI)
    {
        int result = 0;
        result = hR_BranchListDAL.DeleteHR_Branch(hR_BranchListUI);
        return result;
    }
}