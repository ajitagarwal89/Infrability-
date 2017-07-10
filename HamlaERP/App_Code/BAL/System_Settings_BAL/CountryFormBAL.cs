using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CountryFormBLL
/// </summary>
public class CountryFormBAL
{
	

    CountryFormDAL countryFormDAL = new CountryFormDAL();

    public CountryFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetCountryListById(CountryFormUI countryFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = countryFormDAL.GetCountryListById(countryFormUI);
        return dtb;
    }

    public int AddCountry(CountryFormUI countryFormUI)
    {
        int resutl = 0;
        resutl = countryFormDAL.AddCountry(countryFormUI);
        return resutl;
    }

    public int UpdateCountry(CountryFormUI countryFormUI)
    {
        int resutl = 0;
        resutl = countryFormDAL.UpdateCountry(countryFormUI);
        return resutl;
    }

    public int DeleteCountry(CountryFormUI countryFormUI)
    {
        int resutl = 0;
        resutl = countryFormDAL.DeleteCountry(countryFormUI);
        return resutl;
    }
}