using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for AccountFormatDetailsFormBAL
/// </summary>
public class AccountFormatDetailsFormBAL
{
    AccountFormatDetailsFormDAL accountFormatDetailsFormDAL = new AccountFormatDetailsFormDAL();

    public AccountFormatDetailsFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetAccountFormatDetailsListById(AccountFormatDetailsFormUI accountFormatDetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = accountFormatDetailsFormDAL.GetAccountFormatDetailsListById(accountFormatDetailsFormUI);
        return dtb;
    }

    public int AddAccountFormatDetails(AccountFormatDetailsFormUI accountFormatDetailsFormUI)
    {
        int resutl = 0;
        resutl = accountFormatDetailsFormDAL.AddAccountFormatDetails(accountFormatDetailsFormUI);
        return resutl;
    }

    public int UpdateAccountFormatDetails(AccountFormatDetailsFormUI accountFormatDetailsFormUI)
    {
        int resutl = 0;
        resutl = accountFormatDetailsFormDAL.UpdateAccountFormatDetails(accountFormatDetailsFormUI);
        return resutl;
    }

    public int UpdateAccountFormatDetailsSegmentLenght(AccountFormatDetailsFormUI accountFormatDetailsFormUI)
    {
        int resutl = 0;
        resutl = accountFormatDetailsFormDAL.UpdateAccountFormatDetailsSegmentLenght(accountFormatDetailsFormUI);
        return resutl;
    }

    public int DeleteAccountFormatDetails(AccountFormatDetailsFormUI accountFormatDetailsFormUI)
    {
        int resutl = 0;
        resutl = accountFormatDetailsFormDAL.DeleteAccountFormatDetails(accountFormatDetailsFormUI);
        return resutl;
    }
    public DataTable GetAccountFormatDetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = accountFormatDetailsFormDAL.GetAccountFormatDetailsListForExportToExcel();
        return dtb;
    }



}