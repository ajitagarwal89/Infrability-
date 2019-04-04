using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for CurrencyListBLL
/// </summary>
public class CurrencyListBAL
{
    CurrencyListDAL currencyListDAL = new CurrencyListDAL();

	public CurrencyListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetCurrencyList()
    {
        DataTable dtb = new DataTable();
        dtb = currencyListDAL.GetCurrencyList();
        return dtb;
    }
    public DataTable GetCurrencyListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = currencyListDAL.GetCurrencyListForExportToExcel();
        return dtb;
    }
    public DataTable GetCurrencyListById(CurrencyListUI currencyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = currencyListDAL.GetCurrencyListById(currencyListUI);
        return dtb;
    }

    public DataTable GetCurrencyListBySearchParameters(CurrencyListUI currencyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = currencyListDAL.GetCurrencyListBySearchParameters(currencyListUI);
        return dtb;
    }

    public int DeleteCurrency(CurrencyListUI currencyListUI)
    {
        int result = 0;
        result = currencyListDAL.DeleteCurrency(currencyListUI);
        return result;
    }
}