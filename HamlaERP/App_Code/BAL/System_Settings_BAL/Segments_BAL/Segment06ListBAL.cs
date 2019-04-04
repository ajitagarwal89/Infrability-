using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment06ListBLL
/// </summary>
public class Segment06ListBAL
{
    Segment06ListDAL segment06ListDAL = new Segment06ListDAL();

	public Segment06ListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSegment06List()
    {
        DataTable dtb = new DataTable();
        dtb = segment06ListDAL.GetSegment06List();
        return dtb;
    }

    public DataTable GetSegment06ListById(Segment06ListUI segment06ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment06ListDAL.GetSegment06ListById(segment06ListUI);
        return dtb;
    }

    public DataTable GetSegment06ListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = segment06ListDAL.GetSegment06ListForExportToExcel();
        return dtb;
    }

    public DataTable GetSegment06ListBySearchParameters(Segment06ListUI segment06ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment06ListDAL.GetSegment06ListBySearchParameters(segment06ListUI);
        return dtb;
    }

    public DataTable GetSegment06ListBySegment05(Segment06ListUI segment06ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment06ListDAL.GetSegment06ListBySegment05(segment06ListUI);
        return dtb;
    }

    public int DeleteSegment06(Segment06ListUI segment06ListUI)
    {
        int result = 0;
        result = segment06ListDAL.DeleteSegment06(segment06ListUI);
        return result;
    }
}