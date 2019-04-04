using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HRDivisionForm
/// </summary>
public class HRDivisionFormBAL
{

    HRDivisionFormDAL hRDivisionFormDAL = new HRDivisionFormDAL();

    public HRDivisionFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetHRDivisionListById(HRDivisionFormUI hRDivisionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = hRDivisionFormDAL.GetHRDivisionListById(hRDivisionFormUI);
        return dtb;
    }

    public int AddHRDivision(HRDivisionFormUI hRDivisionFormUI)
    {
        int resutl = 0;
        resutl = hRDivisionFormDAL.AddHRDivision(hRDivisionFormUI);
        return resutl;
    }

    public int UpdateHRDivision(HRDivisionFormUI hRDivisionFormUI)
    {
        int resutl = 0;
        resutl = hRDivisionFormDAL.UpdateHRDivision(hRDivisionFormUI);
        return resutl;
    }

    public int DeleteHRDivision(HRDivisionFormUI hRDivisionFormUI)
    {
        int resutl = 0;
        resutl = hRDivisionFormDAL.DeleteHRDivision(hRDivisionFormUI);
        return resutl;
    }
}