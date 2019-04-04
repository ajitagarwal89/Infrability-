using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment07FormBLL
/// </summary>
public class Segment07FormBAL
{
    Segment07FormDAL segment07FormDAL = new Segment07FormDAL();

	public Segment07FormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSegment07ListById(Segment07FormUI segment07FormUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment07FormDAL.GetSegment07ListById(segment07FormUI);
        return dtb;
    }

    public int AddSegment07(Segment07FormUI segment07FormUI)
    {
        int resutl = 0;
        resutl = segment07FormDAL.AddSegment07(segment07FormUI);
        return resutl;
    }

    public int UpdateSegment07(Segment07FormUI segment07FormUI)
    {
        int resutl = 0;
        resutl = segment07FormDAL.UpdateSegment07(segment07FormUI);
        return resutl;
    }

    public int DeleteSegment07(Segment07FormUI segment07FormUI)
    {
        int resutl = 0;
        resutl = segment07FormDAL.DeleteSegment07(segment07FormUI);
        return resutl;
    }
}