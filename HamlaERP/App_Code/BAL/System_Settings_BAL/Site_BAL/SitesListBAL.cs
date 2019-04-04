using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SitesListBLL
/// </summary>
public class SitesListBAL
{
    SitesListDAL sitesListDAL = new SitesListDAL();

	public SitesListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSitesList()
    {
        DataTable dtb = new DataTable();
        dtb = sitesListDAL.GetSitesList();
        return dtb;
    }

    public DataTable GetSitesListById(SitesListUI sitesListUI)
    {
        DataTable dtb = new DataTable();
        dtb = sitesListDAL.GetSitesListById(sitesListUI);
        return dtb;
    }

    public DataTable GetSitesListBySearchParameters(SitesListUI sitesListUI)
    {
        DataTable dtb = new DataTable();
        dtb = sitesListDAL.GetSitesListBySearchParameters(sitesListUI);
        return dtb;
    }

    public int DeleteSites(SitesListUI sitesListUI)
    {
        int result = 0;
        result = sitesListDAL.DeleteSites(sitesListUI);
        return result;
    }

    public DataTable GetSitesListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = sitesListDAL.GetSitesListForExportToExcel();
        return dtb;
    }

}