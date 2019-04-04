using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BankFormBAL
/// </summary>
public class BankAccountFormBAL
{
    BankAccountFormDAL bankAccountFormDAL = new BankAccountFormDAL();

    public BankAccountFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetBankAccountListById(BankAccountFormUI bankAccountFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = bankAccountFormDAL.GetBankAccountListById(bankAccountFormUI);
        return dtb;
    }


    public int AddBankAccount(BankAccountFormUI bankAccountFormUI)
    {
        int resutl = 0;
        resutl = bankAccountFormDAL.AddBankAccount(bankAccountFormUI);
        return resutl;
    }

    public int UpdateBankAccount(BankAccountFormUI bankAccountFormUI)
    {
        int resutl = 0;
        resutl = bankAccountFormDAL.UpdateBankAccount(bankAccountFormUI);
        return resutl;
    }

    public int DeleteBankAccount(BankAccountFormUI bankAccountFormUI)
    {
        int resutl = 0;
        resutl = bankAccountFormDAL.DeleteBankAccount(bankAccountFormUI);
        return resutl;
    }
}