using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for CountryListBLL
/// </summary>
public class CountryListBAL
{


    CountryListDAL countryListDAL = new CountryListDAL();

    public CountryListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetCountryList()
    {
        DataTable dtb = new DataTable();
        dtb = countryListDAL.GetCountryList();
        return dtb;
    }
    public DataTable GetCountryListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = countryListDAL.GetCountryListForExportToExcel();
        return dtb;
    }
    public DataTable GetCountryListById(CountryListUI countryListUI)
    {
        DataTable dtb = new DataTable();
        dtb = countryListDAL.GetCountryListById(countryListUI);
        return dtb;
    }

    public int DeleteCountry(CountryListUI countryListUI)
    {
        int result = 0;
        result = countryListDAL.DeleteCountry(countryListUI);
        return result;
    }

    public DataTable GetCountryListBySearchParameters(CountryListUI countryListUI)
    {
        DataTable dtb = new DataTable();
        dtb = countryListDAL.GetCountryListBySearchParameters(countryListUI);
        return dtb;
    }

    
}