using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment05FormBLL
/// </summary>
public class Segment05FormBAL
{
    Segment05FormDAL segment05FormDAL = new Segment05FormDAL();

	public Segment05FormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSegment05ListById(Segment05FormUI segment05FormUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment05FormDAL.GetSegment05ListById(segment05FormUI);
        return dtb;
    }

    public int AddSegment05(Segment05FormUI segment05FormUI)
    {
        int resutl = 0;
        resutl = segment05FormDAL.AddSegment05(segment05FormUI);
        return resutl;
    }

    public int UpdateSegment05(Segment05FormUI segment05FormUI)
    {
        int resutl = 0;
        resutl = segment05FormDAL.UpdateSegment05(segment05FormUI);
        return resutl;
    }

    public int DeleteSegment05(Segment05FormUI segment05FormUI)
    {
        int resutl = 0;
        resutl = segment05FormDAL.DeleteSegment05(segment05FormUI);
        return resutl;
    }
}