using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment04ListBLL
/// </summary>
public class Segment04ListBAL
{
    Segment04ListDAL segment04ListDAL = new Segment04ListDAL();

    public Segment04ListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSegment04List()
    {
        DataTable dtb = new DataTable();
        dtb = segment04ListDAL.GetSegment04List();
        return dtb;
    }

    public DataTable GetSegment04ListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = segment04ListDAL.GetSegment04ListForExportToExcel();
        return dtb;
    }

    public DataTable GetSegment04ListById(Segment04ListUI segment04ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment04ListDAL.GetSegment04ListById(segment04ListUI);
        return dtb;
    }

    public DataTable GetSegment04ListBySearchParameters(Segment04ListUI segment04ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment04ListDAL.GetSegment04ListBySearchParameters(segment04ListUI);
        return dtb;
    }

    public DataTable GetSegment04ListBySegment03(Segment04ListUI segment04ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment04ListDAL.GetSegment04ListBySegment03(segment04ListUI);
        return dtb;
    }

    public int DeleteSegment04(Segment04ListUI segment04ListUI)
    {
        int result = 0;
        result = segment04ListDAL.DeleteSegment04(segment04ListUI);
        return result;
    }
}