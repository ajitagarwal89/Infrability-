using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HR_PositionFormBAL
/// </summary>
public class HR_PositionFormBAL
{

    HR_PositionFormDAL hR_PositionFormDAL = new HR_PositionFormDAL();

    public HR_PositionFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetHR_PositionListById(HR_PositionFormUI hR_PositionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = hR_PositionFormDAL.GetHR_PositionListById(hR_PositionFormUI);
        return dtb;
    }

    public int AddHR_Position(HR_PositionFormUI hR_PositionFormUI)
    {
        int resutl = 0;
        resutl = hR_PositionFormDAL.AddHR_Position(hR_PositionFormUI);
        return resutl;
    }

    public int UpdateHR_Position(HR_PositionFormUI hR_PositionFormUI)
    {
        int resutl = 0;
        resutl = hR_PositionFormDAL.UpdateHR_Position(hR_PositionFormUI);
        return resutl;
    }

    public int DeleteHR_Position(HR_PositionFormUI hR_PositionFormUI)
    {
        int resutl = 0;
        resutl = hR_PositionFormDAL.DeleteHR_Position(hR_PositionFormUI);
        return resutl;
    }

}