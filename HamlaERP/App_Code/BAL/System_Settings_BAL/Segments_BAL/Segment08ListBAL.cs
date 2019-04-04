using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment08ListBLL
/// </summary>
public class Segment08ListBAL
{
    Segment08ListDAL segment08ListDAL = new Segment08ListDAL();

    public Segment08ListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSegment08List()
    {
        DataTable dtb = new DataTable();
        dtb = segment08ListDAL.GetSegment08List();
        return dtb;
    }

    public DataTable GetSegment08ListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = segment08ListDAL.GetSegment08ListForExportToExcel();
        return dtb;
    }

    public DataTable GetSegment08ListById(Segment08ListUI segment08ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment08ListDAL.GetSegment08ListById(segment08ListUI);
        return dtb;
    }

    public DataTable GetSegment08ListBySearchParameters(Segment08ListUI segment08ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment08ListDAL.GetSegment08ListBySearchParameters(segment08ListUI);
        return dtb;
    }

    public DataTable GetSegment08ListBySegment07(Segment08ListUI segment08ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment08ListDAL.GetSegment08ListBySegment07(segment08ListUI);
        return dtb;
    }

    public int DeleteSegment08(Segment08ListUI segment08ListUI)
    {
        int result = 0;
        result = segment08ListDAL.DeleteSegment08(segment08ListUI);
        return result;
    }
}