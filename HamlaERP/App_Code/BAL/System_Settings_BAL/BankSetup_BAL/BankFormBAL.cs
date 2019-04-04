using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BankFormBAL
/// </summary>
public class BankFormBAL
{
    BankFormDAL bankFormDAL = new BankFormDAL();

	public BankFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetBankListById(BankFormUI bankFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = bankFormDAL.GetBankListById(bankFormUI);
        return dtb;
    }

    public int AddBank(BankFormUI bankFormUI)
    {
        int resutl = 0;
        resutl = bankFormDAL.AddBank(bankFormUI);
        return resutl;
    }

    public int UpdateBank(BankFormUI bankFormUI)
    {
        int resutl = 0;
        resutl = bankFormDAL.UpdateBank(bankFormUI);
        return resutl;
    }

    public int DeleteBank(BankFormUI bankFormUI)
    {
        int resutl = 0;
        resutl = bankFormDAL.DeleteBank(bankFormUI);
        return resutl;
    }
}