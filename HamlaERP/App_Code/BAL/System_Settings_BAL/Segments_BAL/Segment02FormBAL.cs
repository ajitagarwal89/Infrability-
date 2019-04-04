using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment02FormBLL
/// </summary>
public class Segment02FormBAL
{
    Segment02FormDAL segment02FormDAL = new Segment02FormDAL();

	public Segment02FormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSegment02ListById(Segment02FormUI segment02FormUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment02FormDAL.GetSegment02ListById(segment02FormUI);
        return dtb;
    }

    public int AddSegment02(Segment02FormUI segment02FormUI)
    {
        int resutl = 0;
        resutl = segment02FormDAL.AddSegment02(segment02FormUI);
        return resutl;
    }

    public int UpdateSegment02(Segment02FormUI segment02FormUI)
    {
        int resutl = 0;
        resutl = segment02FormDAL.UpdateSegment02(segment02FormUI);
        return resutl;
    }

    public int DeleteSegment02(Segment02FormUI segment02FormUI)
    {
        int resutl = 0;
        resutl = segment02FormDAL.DeleteSegment02(segment02FormUI);
        return resutl;
    }
}