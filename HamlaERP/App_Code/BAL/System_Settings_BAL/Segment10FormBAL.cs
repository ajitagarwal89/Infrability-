using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Segment10FormBLL
/// </summary>
public class Segment10FormBAL
{
    Segment10FormDAL segment10FormDAL = new Segment10FormDAL();

	public Segment10FormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSegment10ListById(Segment10FormUI segment10FormUI)
    {
        DataTable dtb = new DataTable();
        dtb = segment10FormDAL.GetSegment10ListById(segment10FormUI);
        return dtb;
    }

    public int AddSegment10(Segment10FormUI segment10FormUI)
    {
        int resutl = 0;
        resutl = segment10FormDAL.AddSegment10(segment10FormUI);
        return resutl;
    }

    public int UpdateSegment10(Segment10FormUI segment10FormUI)
    {
        int resutl = 0;
        resutl = segment10FormDAL.UpdateSegment10(segment10FormUI);
        return resutl;
    }

    public int DeleteSegment10(Segment10FormUI segment10FormUI)
    {
        int resutl = 0;
        resutl = segment10FormDAL.DeleteSegment10(segment10FormUI);
        return resutl;
    }
}