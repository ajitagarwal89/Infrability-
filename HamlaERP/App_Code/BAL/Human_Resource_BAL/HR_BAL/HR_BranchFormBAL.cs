using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HR_BranchFormBAL
/// </summary>
public class HR_BranchFormBAL
{
    HR_BranchFormDAL hR_BranchFormDAL = new HR_BranchFormDAL();

    public HR_BranchFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetHR_BranchListById(HR_BranchFormUI hR_BranchFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = hR_BranchFormDAL.GetHR_BranchListById(hR_BranchFormUI);
        return dtb;
    }

    public int AddHR_Branch(HR_BranchFormUI hR_BranchFormUI)
    {
        int resutl = 0;
        resutl = hR_BranchFormDAL.AddHR_Branch(hR_BranchFormUI);
        return resutl;
    }

    public int UpdateHR_Branch(HR_BranchFormUI hR_BranchFormUI)
    {
        int resutl = 0;
        resutl = hR_BranchFormDAL.UpdateHR_Branch(hR_BranchFormUI);
        return resutl;
    }

    public int DeleteHR_Branch(HR_BranchFormUI hR_BranchFormUI)
    {
        int resutl = 0;
        resutl = hR_BranchFormDAL.DeleteHR_Branch(hR_BranchFormUI);
        return resutl;
    }

}