using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for AccountFormatListBLL
/// </summary>
public class AccountFormatListBAL
{
    AccountFormatListDAL accountFormatListDAL = new AccountFormatListDAL();

	public AccountFormatListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetAccountFormatList()
    {
        DataTable dtb = new DataTable();
        dtb = accountFormatListDAL.GetAccountFormatList();
        return dtb;
    }

    public DataTable GetAccountFormatListById(AccountFormatListUI accountFormatListUI)
    {
        DataTable dtb = new DataTable();
        dtb = accountFormatListDAL.GetAccountFormatListById(accountFormatListUI);
        return dtb;
    }

    public DataTable GetAccountFormatListBySearchParameters(AccountFormatListUI accountFormatListUI)
    {
        DataTable dtb = new DataTable();
        dtb = accountFormatListDAL.GetAccountFormatListBySearchParameters(accountFormatListUI);
        return dtb;
    }

    public int DeleteAccountFormat(AccountFormatListUI accountFormatListUI)
    {
        int result = 0;
        result = accountFormatListDAL.DeleteAccountFormat(accountFormatListUI);
        return result;
    }
}