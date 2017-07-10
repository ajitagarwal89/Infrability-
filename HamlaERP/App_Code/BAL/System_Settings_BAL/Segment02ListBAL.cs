using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment02ListBLL
/// </summary>
public class Segment02ListBAL
{
    Segment02ListDAL segment02ListDAL = new Segment02ListDAL();

    public Segment02ListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSegment02List()
    {
        DataTable dtb = new DataTable();
        dtb = segment02ListDAL.GetSegment02List();
        return dtb;
    }

    public DataTable GetSegment02ListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = segment02ListDAL.GetSegment02ListForExportToExcel();
        return dtb;
    }

    public DataTable GetSegment02ListById(Segment02ListUI segment02ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment02ListDAL.GetSegment02ListById(segment02ListUI);
        return dtb;
    }

    public DataTable GetSegment02ListBySearchParameters(Segment02ListUI segment02ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment02ListDAL.GetSegment02ListBySearchParameters(segment02ListUI);
        return dtb;
    }

    public DataTable GetSegment02ListBySegment01(Segment02ListUI segment02ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment02ListDAL.GetSegment02ListBySegment01(segment02ListUI);
        return dtb;
    }

    public int DeleteSegment02(Segment02ListUI segment02ListUI)
    {
        int result = 0;
        result = segment02ListDAL.DeleteSegment02(segment02ListUI);
        return result;
    }
}