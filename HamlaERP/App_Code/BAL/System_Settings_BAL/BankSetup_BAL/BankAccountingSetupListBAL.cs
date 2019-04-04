using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BankAccountingSetupListBAL
/// </summary>
public class BankAccountingSetupListBAL
{
    BankAccountingSetupListDAL bankAccountingSetupListDAL = new BankAccountingSetupListDAL();
    BankAccountingSetupListUI bankAccountingSetupListUI = new BankAccountingSetupListUI();
    public BankAccountingSetupListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetBankAccountingSetupList()
    {
        DataTable dtb = new DataTable();
        dtb = bankAccountingSetupListDAL.GetBankAccountingSetupList();
        return dtb;
    }

    public DataTable GetBankAccountingSetuphListById(BankAccountingSetupListUI bankAccountingSetupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = bankAccountingSetupListDAL.GetBankAccountingSetuphListById(bankAccountingSetupListUI);
        return dtb;
    }

    public DataTable GetBankAccountListBySearchParameters(BankAccountingSetupListUI bankAccountingSetupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = bankAccountingSetupListDAL.GetBankAccountingSetupListBySearchParameters(bankAccountingSetupListUI);
        return dtb;
    }

    public int DeleteBankAccountingSetup(BankAccountingSetupListUI bankAccountingSetupListUI)
    {
        int result = 0;
        result = bankAccountingSetupListDAL.DeleteBankAccountingSetup(bankAccountingSetupListUI);
        return result;
    }

    public DataTable GetBankAccountingSetupListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = bankAccountingSetupListDAL.GetBankAccountingSetupListForExportToExcel();
        return dtb;
    }
}