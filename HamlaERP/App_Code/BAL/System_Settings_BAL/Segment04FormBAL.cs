using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment04FormBLL
/// </summary>
public class Segment04FormBAL
{
    Segment04FormDAL segment04FormDAL = new Segment04FormDAL();

	public Segment04FormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSegment04ListById(Segment04FormUI segment04FormUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment04FormDAL.GetSegment04ListById(segment04FormUI);
        return dtb;
    }

    public int AddSegment04(Segment04FormUI segment04FormUI)
    {
        int resutl = 0;
        resutl = segment04FormDAL.AddSegment04(segment04FormUI);
        return resutl;
    }

    public int UpdateSegment04(Segment04FormUI segment04FormUI)
    {
        int resutl = 0;
        resutl = segment04FormDAL.UpdateSegment04(segment04FormUI);
        return resutl;
    }

    public int DeleteSegment04(Segment04FormUI segment04FormUI)
    {
        int resutl = 0;
        resutl = segment04FormDAL.DeleteSegment04(segment04FormUI);
        return resutl;
    }
}