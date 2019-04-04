using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment01FormBLL
/// </summary>
public class Segment01FormBAL
{
    Segment01FormDAL segment01FormDAL = new Segment01FormDAL();

	public Segment01FormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSegment01ListById(Segment01FormUI segment01FormUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment01FormDAL.GetSegment01ListById(segment01FormUI);
        return dtb;
    }

    public int AddSegment01(Segment01FormUI segment01FormUI)
    {
        int resutl = 0;
        resutl = segment01FormDAL.AddSegment01(segment01FormUI);
        return resutl;
    }

    public int UpdateSegment01(Segment01FormUI segment01FormUI)
    {
        int resutl = 0;
        resutl = segment01FormDAL.UpdateSegment01(segment01FormUI);
        return resutl;
    }

    public int DeleteSegment01(Segment01FormUI segment01FormUI)
    {
        int resutl = 0;
        resutl = segment01FormDAL.DeleteSegment01(segment01FormUI);
        return resutl;
    }
}