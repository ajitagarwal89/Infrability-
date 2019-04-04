using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for AccountFormatFormBAL
/// </summary>
public class AccountFormatFormBAL
{
    AccountFormatFormDAL accountFormatFormDAL = new AccountFormatFormDAL();

	public AccountFormatFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetAccountFormatListById(AccountFormatFormUI accountFormatFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = accountFormatFormDAL.GetAccountFormatListById(accountFormatFormUI);
        return dtb;
    }

    public int AddAccountFormat(AccountFormatFormUI accountFormatFormUI)
    {
        int resutl = 0;
        resutl = accountFormatFormDAL.AddAccountFormat(accountFormatFormUI);
        return resutl;
    }

    public int UpdateAccountFormat(AccountFormatFormUI accountFormatFormUI)
    {
        int resutl = 0;
        resutl = accountFormatFormDAL.UpdateAccountFormat(accountFormatFormUI);
        return resutl;
    }

    public int DeleteAccountFormat(AccountFormatFormUI accountFormatFormUI)
    {
        int resutl = 0;
        resutl = accountFormatFormDAL.DeleteAccountFormat(accountFormatFormUI);
        return resutl;
    }

    public int AccountFormatDetails_DeleteByAccountFormatId(AccountFormatFormUI accountFormatFormUI)
    {
        int resutl = 0;
        resutl = accountFormatFormDAL.DeleteAccountFormat(accountFormatFormUI);
        return resutl;
    }
    public DataTable GetAccountFormatFormSelectByAccountFormatId(AccountFormatFormUI accountFormatFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = accountFormatFormDAL.GetAccountFormatFormSelectByAccountFormatId(accountFormatFormUI);
        return dtb;
    }

    public DataTable GetAccountFormatDetails_SelectBySegmentLenght(AccountFormatFormUI accountFormatFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = accountFormatFormDAL.GetAccountFormatDetails_SelectBySegmentLenght(accountFormatFormUI);
        return dtb;
    }
   

}