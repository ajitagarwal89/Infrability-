using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment03ListBLL
/// </summary>
public class Segment03ListBAL
{
    Segment03ListDAL segment03ListDAL = new Segment03ListDAL();

    public Segment03ListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSegment03List()
    {
        DataTable dtb = new DataTable();
        dtb = segment03ListDAL.GetSegment03List();
        return dtb;
    }

    public DataTable GetSegment03ListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = segment03ListDAL.GetSegment03ListForExportToExcel();
        return dtb;
    }

    public DataTable GetSegment03ListById(Segment03ListUI segment03ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment03ListDAL.GetSegment03ListById(segment03ListUI);
        return dtb;
    }

    public DataTable GetSegment03ListBySearchParameters(Segment03ListUI segment03ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment03ListDAL.GetSegment03ListBySearchParameters(segment03ListUI);
        return dtb;
    }

    public DataTable GetSegment03ListBySegment02(Segment03ListUI segment03ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment03ListDAL.GetSegment03ListBySegment02(segment03ListUI);
        return dtb;
    }

    public int DeleteSegment03(Segment03ListUI segment03ListUI)
    {
        int result = 0;
        result = segment03ListDAL.DeleteSegment03(segment03ListUI);
        return result;
    }
}