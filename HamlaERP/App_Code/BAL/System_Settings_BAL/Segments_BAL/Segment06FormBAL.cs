using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment06FormBLL
/// </summary>
public class Segment06FormBAL
{
    Segment06FormDAL segment06FormDAL = new Segment06FormDAL();

	public Segment06FormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSegment06ListById(Segment06FormUI segment06FormUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment06FormDAL.GetSegment06ListById(segment06FormUI);
        return dtb;
    }

    public int AddSegment06(Segment06FormUI segment06FormUI)
    {
        int resutl = 0;
        resutl = segment06FormDAL.AddSegment06(segment06FormUI);
        return resutl;
    }

    public int UpdateSegment06(Segment06FormUI segment06FormUI)
    {
        int resutl = 0;
        resutl = segment06FormDAL.UpdateSegment06(segment06FormUI);
        return resutl;
    }

    public int DeleteSegment06(Segment06FormUI segment06FormUI)
    {
        int resutl = 0;
        resutl = segment06FormDAL.DeleteSegment06(segment06FormUI);
        return resutl;
    }
}