using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for LocationFormBAL
/// </summary>
public class LocationFormBAL
{
    LocationFormDAL locationFormDAL = new LocationFormDAL();

    public LocationFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetLocationListById(LocationFormUI locationFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = locationFormDAL.GetLocationListById(locationFormUI);
        return dtb;
    }

    public int AddLocation(LocationFormUI locationFormUI)
    {
        int resutl = 0;
        resutl = locationFormDAL.AddLocation(locationFormUI);
        return resutl;
    }

    public int UpdateLocation(LocationFormUI locationFormUI)
    {
        int resutl = 0;
        resutl = locationFormDAL.UpdateLocation(locationFormUI);
        return resutl;
    }

    public int DeleteLocation(LocationFormUI locationFormUI)
    {
        int resutl = 0;
        resutl = locationFormDAL.DeleteLocation(locationFormUI);
        return resutl;
    }
}