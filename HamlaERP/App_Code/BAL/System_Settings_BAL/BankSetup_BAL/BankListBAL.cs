using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for BankListBAL
/// </summary>
public class BankListBAL
{
    BankListDAL bankListDAL = new BankListDAL();

    public BankListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetBankList()
    {
        DataTable dtb = new DataTable();
        dtb = bankListDAL.GetBankList();
        return dtb;
    }

    public DataTable GetBankListById(BankListUI bankListUI)
    {
        DataTable dtb = new DataTable();
        dtb = bankListDAL.GetBankListById(bankListUI);
        return dtb;
    }

    public DataTable GetBankListBySearchParameters(BankListUI bankListUI)
    {
        DataTable dtb = new DataTable();
        dtb = bankListDAL.GetBankListBySearchParameters(bankListUI);
        return dtb;
    }

    public int DeleteBank(BankListUI bankListUI)
    {
        int result = 0;
        result = bankListDAL.DeleteBank(bankListUI);
        return result;
    }

    public DataTable GetBankListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = bankListDAL.GetBankListForExportToExcel();
        return dtb;
    }
}
