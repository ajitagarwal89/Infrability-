using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment08FormBLL
/// </summary>
public class Segment08FormBAL
{
    Segment08FormDAL segment08FormDAL = new Segment08FormDAL();

	public Segment08FormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSegment08ListById(Segment08FormUI segment08FormUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment08FormDAL.GetSegment08ListById(segment08FormUI);
        return dtb;
    }

    public int AddSegment08(Segment08FormUI segment08FormUI)
    {
        int resutl = 0;
        resutl = segment08FormDAL.AddSegment08(segment08FormUI);
        return resutl;
    }

    public int UpdateSegment08(Segment08FormUI segment08FormUI)
    {
        int resutl = 0;
        resutl = segment08FormDAL.UpdateSegment08(segment08FormUI);
        return resutl;
    }

    public int DeleteSegment08(Segment08FormUI segment08FormUI)
    {
        int resutl = 0;
        resutl = segment08FormDAL.DeleteSegment08(segment08FormUI);
        return resutl;
    }
}