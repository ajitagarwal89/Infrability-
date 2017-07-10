using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment07ListBLL
/// </summary>
public class Segment07ListBAL
{
    Segment07ListDAL segment07ListDAL = new Segment07ListDAL();

    public Segment07ListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSegment07List()
    {
        DataTable dtb = new DataTable();
        dtb = segment07ListDAL.GetSegment07List();
        return dtb;
    }

    public DataTable GetSegment07ListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = segment07ListDAL.GetSegment07ListForExportToExcel();
        return dtb;
    }

    public DataTable GetSegment07ListById(Segment07ListUI segment07ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment07ListDAL.GetSegment07ListById(segment07ListUI);
        return dtb;
    }

    public DataTable GetSegment07ListBySearchParameters(Segment07ListUI segment07ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment07ListDAL.GetSegment07ListBySearchParameters(segment07ListUI);
        return dtb;
    }

    public DataTable GetSegment07ListBySegment06(Segment07ListUI segment07ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment07ListDAL.GetSegment07ListBySegment06(segment07ListUI);
        return dtb;
    }

    public int DeleteSegment07(Segment07ListUI segment07ListUI)
    {
        int result = 0;
        result = segment07ListDAL.DeleteSegment07(segment07ListUI);
        return result;
    }
}