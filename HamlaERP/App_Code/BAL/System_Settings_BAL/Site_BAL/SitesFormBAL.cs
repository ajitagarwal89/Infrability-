using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SitesFormBLL
/// </summary>
public class SitesFormBAL
{
    SitesFormDAL sitesFormDAL = new SitesFormDAL();

	public SitesFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSitesListById(SitesFormUI sitesFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = sitesFormDAL.GetSitesListById(sitesFormUI);
        return dtb;
    }

    public int AddSites(SitesFormUI sitesFormUI)
    {
        int resutl = 0;
        resutl = sitesFormDAL.AddSites(sitesFormUI);
        return resutl;
    }

    public int UpdateSites(SitesFormUI sitesFormUI)
    {
        int resutl = 0;
        resutl = sitesFormDAL.UpdateSites(sitesFormUI);
        return resutl;
    }

    public int DeleteSites(SitesFormUI sitesFormUI)
    {
        int resutl = 0;
        resutl = sitesFormDAL.DeleteSites(sitesFormUI);
        return resutl;
    }
}