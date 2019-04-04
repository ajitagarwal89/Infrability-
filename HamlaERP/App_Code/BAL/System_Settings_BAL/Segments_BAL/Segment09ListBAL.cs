using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment09ListBLL
/// </summary>
public class Segment09ListBAL
{
    Segment09ListDAL segment09ListDAL = new Segment09ListDAL();

    public Segment09ListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSegment09List()
    {
        DataTable dtb = new DataTable();
        dtb = segment09ListDAL.GetSegment09List();
        return dtb;
    }

    public DataTable GetSegment09ListById(Segment09ListUI segment09ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment09ListDAL.GetSegment09ListById(segment09ListUI);
        return dtb;
    }

    public DataTable GetSegment09ListBySearchParameters(Segment09ListUI segment09ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment09ListDAL.GetSegment09ListBySearchParameters(segment09ListUI);
        return dtb;
    }

    public DataTable GetSegment09ListBySegment08(Segment09ListUI segment09ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment09ListDAL.GetSegment09ListBySegment08(segment09ListUI);
        return dtb;
    }

    public DataTable GetSegment09ListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = segment09ListDAL.GetSegment09ListForExportToExcel();
        return dtb;
    }

    public int DeleteSegment09(Segment09ListUI segment09ListUI)
    {
        int result = 0;
        result = segment09ListDAL.DeleteSegment09(segment09ListUI);
        return result;
    }
}