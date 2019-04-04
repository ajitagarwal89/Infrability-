using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HRTeamForm
/// </summary>
public class HRTeamFormBAL
{

    HRTeamFormDAL hRTeamFormDAL = new HRTeamFormDAL();

    public HRTeamFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetHRTeamListById(HRTeamFormUI hRTeamFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = hRTeamFormDAL.GetHRTeamListById(hRTeamFormUI);
        return dtb;
    }

    public int AddHRTeam(HRTeamFormUI hRTeamFormUI)
    {
        int resutl = 0;
        resutl = hRTeamFormDAL.AddHRTeam(hRTeamFormUI);
        return resutl;
    }

    public int UpdateHRTeam(HRTeamFormUI hRTeamFormUI)
    {
        int resutl = 0;
        resutl = hRTeamFormDAL.UpdateHRTeam(hRTeamFormUI);
        return resutl;
    }

    public int DeleteHRTeam(HRTeamFormUI hRTeamFormUI)
    {
        int resutl = 0;
        resutl = hRTeamFormDAL.DeleteHRTeam(hRTeamFormUI);
        return resutl;
    }
}