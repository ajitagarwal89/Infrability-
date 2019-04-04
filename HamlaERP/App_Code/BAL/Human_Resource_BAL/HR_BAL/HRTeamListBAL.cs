using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HRTeamListBLL
/// </summary>
public class HRTeamListBAL
{

    HRTeamListDAL hRTeamListDAL = new HRTeamListDAL();

    public HRTeamListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetHRTeamList()
    {
        DataTable dtb = new DataTable();
        dtb = hRTeamListDAL.GetHRTeamList();
        return dtb;
    }

    public DataTable GetHRTeamListById(HRTeamListUI hRTeamListUI)
    {
        DataTable dtb = new DataTable();
        dtb = hRTeamListDAL.GetHRTeamListById(hRTeamListUI);
        return dtb;
    }

    public DataTable GetHRTeamListBySearchParameters(HRTeamListUI hRTeamListUI)
    {
        DataTable dtb = new DataTable();
        dtb = hRTeamListDAL.GetHRTeamListBySearchParameters(hRTeamListUI);
        return dtb;
    }

    public int DeleteHRTeam(HRTeamListUI hRTeamListUI)
    {
        int result = 0;
        result = hRTeamListDAL.DeleteHRTeam(hRTeamListUI);
        return result;
    }

    public DataTable GetHRTeamListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = hRTeamListDAL.GetHRTeamListForExportToExcel();
        return dtb;
    }

}