using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for LocationListBAL
/// </summary>
public class LocationListBAL
{
    LocationListDAL locationListDAL = new LocationListDAL();
    public LocationListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetLocationList()
    {
        DataTable dtb = new DataTable();
        dtb = locationListDAL.GetLocationList();
        return dtb;
    }
    public DataTable GetLocationListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = locationListDAL.GetLocationListForExportToExcel();
        return dtb;
    }
    public DataTable GetLocationListById(LocationListUI locationListUI)
    {
        DataTable dtb = new DataTable();
        dtb = locationListDAL.GetLocationListById(locationListUI);
        return dtb;
    }

    public DataTable GetLocationListBySearchParameters(LocationListUI locationListUI)
    {
        DataTable dtb = new DataTable();
        dtb = locationListDAL.GetLocationListBySearchParameters(locationListUI);
        return dtb;
    }

    public int DeleteLocation(LocationListUI locationListUI)
    {
        int result = 0;
        result = locationListDAL.DeleteLocation(locationListUI);
        return result;
    }

}