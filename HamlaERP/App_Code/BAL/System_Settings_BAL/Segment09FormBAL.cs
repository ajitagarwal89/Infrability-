using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment09FormBLL
/// </summary>
public class Segment09FormBAL
{
    Segment09FormDAL segment09FormDAL = new Segment09FormDAL();

	public Segment09FormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSegment09ListById(Segment09FormUI segment09FormUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment09FormDAL.GetSegment09ListById(segment09FormUI);
        return dtb;
    }

    public int AddSegment09(Segment09FormUI segment09FormUI)
    {
        int resutl = 0;
        resutl = segment09FormDAL.AddSegment09(segment09FormUI);
        return resutl;
    }

    public int UpdateSegment09(Segment09FormUI segment09FormUI)
    {
        int resutl = 0;
        resutl = segment09FormDAL.UpdateSegment09(segment09FormUI);
        return resutl;
    }

    public int DeleteSegment09(Segment09FormUI segment09FormUI)
    {
        int resutl = 0;
        resutl = segment09FormDAL.DeleteSegment09(segment09FormUI);
        return resutl;
    }
}