using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for BankAccountingSetupFormBAL
/// </summary>
public class BankAccountingSetupFormBAL
{
    BankAccountingSetupFormDAL bankAccountingSetupFormBAL = new BankAccountingSetupFormDAL();
    BankAccountingSetupFormUI bankAccountingSetupFormUI = new BankAccountingSetupFormUI();
    public BankAccountingSetupFormBAL()
    {

    }

    public DataTable GetBankAccountingSetupById(BankAccountingSetupFormUI bankAccountingSetupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = bankAccountingSetupFormBAL.GetBankAccountingSetupListById(bankAccountingSetupFormUI);
        return dtb;


    }
    public int AddBankAccountingSetup(BankAccountingSetupFormUI bankAccountingSetupFormUI)
    {
        int resutl = 0;
        resutl = bankAccountingSetupFormBAL.AddBankAccountingSetup(bankAccountingSetupFormUI);
        return resutl;
    }

    public int UpdateBankAccountingSetup(BankAccountingSetupFormUI bankAccountingSetupFormUI)
    {
        int resutl = 0;
        resutl = bankAccountingSetupFormBAL.UpdateBankAccountingSetup(bankAccountingSetupFormUI);
        return resutl;
    }

    public int DeleteBankAccountingSetup(BankAccountingSetupFormUI bankAccountingSetupFormUI)
    {
        int resutl = 0;
        resutl = bankAccountingSetupFormBAL.DeleteBankAccountingSetup(bankAccountingSetupFormUI);
        return resutl;
    }

}