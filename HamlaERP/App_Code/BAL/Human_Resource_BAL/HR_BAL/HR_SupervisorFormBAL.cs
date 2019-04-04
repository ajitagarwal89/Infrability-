using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HR_SupervisorFormBAL
/// </summary>
public class HR_SupervisorFormBAL
{
    HR_SupervisorFormDAL hR_SupervisorFormDAL = new HR_SupervisorFormDAL();

    public HR_SupervisorFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetHR_SupervisorListById(HR_SupervisorFormUI hR_SupervisorFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = hR_SupervisorFormDAL.GetHR_SupervisorListById(hR_SupervisorFormUI);
        return dtb;
    }

    public int AddHR_Supervisor(HR_SupervisorFormUI hR_SupervisorFormUI)
    {
        int resutl = 0;
        resutl = hR_SupervisorFormDAL.AddHR_Supervisor(hR_SupervisorFormUI);
        return resutl;
    }

    public int UpdateHR_Supervisor(HR_SupervisorFormUI hR_SupervisorFormUI)
    {
        int resutl = 0;
        resutl = hR_SupervisorFormDAL.UpdateHR_Supervisor(hR_SupervisorFormUI);
        return resutl;
    }

    public int DeleteHR_Supervisor(HR_SupervisorFormUI hR_SupervisorFormUI)
    {
        int resutl = 0;
        resutl = hR_SupervisorFormDAL.DeleteHR_Supervisor(hR_SupervisorFormUI);
        return resutl;
    }

}