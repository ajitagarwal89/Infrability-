using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for AccountFormatDetailsListBAL
/// </summary>
public class AccountFormatDetailsListBAL
{
    AccountFormatDetailsListDAL accountFormatDetailsListDAL = new AccountFormatDetailsListDAL();

    public AccountFormatDetailsListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetAccountFormatDetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = accountFormatDetailsListDAL.GetAccountFormatDetailsList();
        return dtb;
    }


    public DataTable GetAccountFormatDetailsListById(AccountFormatDetailsListUI accountFormatDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = accountFormatDetailsListDAL.GetAccountFormatDetailsListById(accountFormatDetailsListUI);
        return dtb;
    }

    public DataTable GetAccountFormatDetailsListByAccountFormatId(AccountFormatDetailsListUI accountFormatDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = accountFormatDetailsListDAL.GetAccountFormatDetailsListByAccountFormatId(accountFormatDetailsListUI);
        return dtb;
    }


    public DataTable GetAccountFormatDetailsListBySearchParameters(AccountFormatDetailsListUI accountFormatDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = accountFormatDetailsListDAL.GetAccountFormatDetailsListBySearchParameters(accountFormatDetailsListUI);
        return dtb;
    }

    public int DeleteAccountFormatDetails(AccountFormatDetailsListUI accountFormatDetailsListUI)
    {
        int result = 0;
        result = accountFormatDetailsListDAL.DeleteAccountFormatDetails(accountFormatDetailsListUI);
        return result;
    }

    public DataTable GetAccountFormatDetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = accountFormatDetailsListDAL.GetAccountFormatDetailsListExportToExcel();
        return dtb;
    }
}