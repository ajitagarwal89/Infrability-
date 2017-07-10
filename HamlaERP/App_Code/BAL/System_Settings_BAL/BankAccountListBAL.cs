using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BankAccountListBAL
/// </summary>
public class BankAccountListBAL
{

    BankAccountListDAL bankAccountListDAL = new BankAccountListDAL();
    public BankAccountListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetBankAccountList()
    {
        DataTable dtb = new DataTable();
        dtb = bankAccountListDAL.GetBankAccountList();
        return dtb;
    }

    public DataTable GetBankAccountListById(BankAccountListUI bankAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = bankAccountListDAL.GetBankAccountListById(bankAccountListUI);
        return dtb;
    }

    public DataTable GetBankAccountListBySearchParameters(BankAccountListUI bankAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = bankAccountListDAL.GetBankAccountListBySearchParameters(bankAccountListUI);
        return dtb;
    }

    public int DeleteBankAccount(BankAccountListUI bankAccountListUI)
    {
        int result = 0;
        result = bankAccountListDAL.DeleteBankAccount(bankAccountListUI);
        return result;
    }

    public DataTable GetBankAccountListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = bankAccountListDAL.GetBankAccountListForExportToExcel();
        return dtb;
    }
}