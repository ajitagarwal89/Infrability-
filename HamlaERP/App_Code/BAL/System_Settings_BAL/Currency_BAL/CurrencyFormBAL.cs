using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for CurrencyFormBLL
/// </summary>
public class CurrencyFormBAL
{
    CurrencyFormDAL currencyFormDAL = new CurrencyFormDAL();

	public CurrencyFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetCurrencyListById(CurrencyFormUI currencyFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = currencyFormDAL.GetCurrencyListById(currencyFormUI);
        return dtb;
    }

    public int AddCurrency(CurrencyFormUI currencyFormUI)
    {
        int resutl = 0;
        resutl = currencyFormDAL.AddCurrency(currencyFormUI);
        return resutl;
    }

    public int UpdateCurrency(CurrencyFormUI currencyFormUI)
    {
        int resutl = 0;
        resutl = currencyFormDAL.UpdateCurrency(currencyFormUI);
        return resutl;
    }

    public int DeleteCurrency(CurrencyFormUI currencyFormUI)
    {
        int resutl = 0;
        resutl = currencyFormDAL.DeleteCurrency(currencyFormUI);
        return resutl;
    }
}