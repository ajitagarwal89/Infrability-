using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment03FormBLL
/// </summary>
public class Segment03FormBAL
{
    Segment03FormDAL segment03FormDAL = new Segment03FormDAL();

	public Segment03FormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSegment03ListById(Segment03FormUI segment03FormUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment03FormDAL.GetSegment03ListById(segment03FormUI);
        return dtb;
    }

    public int AddSegment03(Segment03FormUI segment03FormUI)
    {
        int resutl = 0;
        resutl = segment03FormDAL.AddSegment03(segment03FormUI);
        return resutl;
    }

    public int UpdateSegment03(Segment03FormUI segment03FormUI)
    {
        int resutl = 0;
        resutl = segment03FormDAL.UpdateSegment03(segment03FormUI);
        return resutl;
    }

    public int DeleteSegment03(Segment03FormUI segment03FormUI)
    {
        int resutl = 0;
        resutl = segment03FormDAL.DeleteSegment03(segment03FormUI);
        return resutl;
    }
}