using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment01ListBAL
/// </summary>
public class Segment01ListBAL
{
    Segment01ListDAL segment01LsitDAL = new Segment01ListDAL();

    public Segment01ListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSegment01List()
    {
        DataTable dtb = new DataTable();
        dtb = segment01LsitDAL.GetSegment01List();
        return dtb;
    }

    public DataTable GetSegment01ListById(Segment01ListUI segment01ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment01LsitDAL.GetSegment01ListById(segment01ListUI);
        return dtb;
    }

    public DataTable GetSegment01ListBySearchParameters(Segment01ListUI segment01ListUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment01LsitDAL.GetSegment01ListBySearchParameters(segment01ListUI);
        return dtb;
    }
   
    public int DeleteSegment01(Segment01ListUI segment01ListUI)
    {
        int result = 0;
        result = segment01LsitDAL.DeleteSegment01(segment01ListUI);
        return result;
    }
}