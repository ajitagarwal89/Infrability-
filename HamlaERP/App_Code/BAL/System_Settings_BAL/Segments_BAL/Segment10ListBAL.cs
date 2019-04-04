using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment10ListBLL
/// </summary>
public class Segment10ListBAL
{
    Segment10ListDAL segment10ListDAL = new Segment10ListDAL();

    public Segment10ListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSegment10List()
    {
        DataTable dtb = new DataTable();
        dtb = segment10ListDAL.GetSegment10List();
        return dtb;
    }

    public DataTable GetSegment10ListById(Segment10ListUI segment10ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment10ListDAL.GetSegment10ListById(segment10ListUI);
        return dtb;
    }

    public DataTable GetSegment10ListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = segment10ListDAL.GetSegment10ListForExportToExcel();
        return dtb;
    }

    public DataTable GetSegment10ListBySearchParameters(Segment10ListUI segment10ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment10ListDAL.GetSegment10ListBySearchParameters(segment10ListUI);
        return dtb;
    }

    public DataTable GetSegment10ListBySegment09(Segment10ListUI segment10ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment10ListDAL.GetSegment10ListBySegment09(segment10ListUI);
        return dtb;
    }

    public int DeleteSegment10(Segment10ListUI segment10ListUI)
    {
        int result = 0;
        result = segment10ListDAL.DeleteSegment10(segment10ListUI);
        return result;
    }
}