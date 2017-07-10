using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment05ListBLL
/// </summary>
public class Segment05ListBAL
{
    Segment05ListDAL segment05ListDAL = new Segment05ListDAL();

    public Segment05ListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSegment05List()
    {
        DataTable dtb = new DataTable();
        dtb = segment05ListDAL.GetSegment05List();
        return dtb;
    }

    public DataTable GetSegment05ListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = segment05ListDAL.GetSegment05ListForExportToExcel();
        return dtb;
    }

    public DataTable GetSegment05ListById(Segment05ListUI segment05ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment05ListDAL.GetSegment05ListById(segment05ListUI);
        return dtb;
    }

    public DataTable GetSegment05ListBySearchParameters(Segment05ListUI segment05ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment05ListDAL.GetSegment05ListBySearchParameters(segment05ListUI);
        return dtb;
    }

    public DataTable GetSegment05ListBySegment04(Segment05ListUI segment05ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment05ListDAL.GetSegment05ListBySegment04(segment05ListUI);
        return dtb;
    }

    public int DeleteSegment05(Segment05ListUI segment05ListUI)
    {
        int result = 0;
        result = segment05ListDAL.DeleteSegment05(segment05ListUI);
        return result;
    }
}