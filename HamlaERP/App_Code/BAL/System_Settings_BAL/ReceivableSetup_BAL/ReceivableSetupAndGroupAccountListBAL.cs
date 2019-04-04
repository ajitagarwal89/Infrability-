using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ReceivableSetupAndGroupAccountListBAL
/// </summary>
public class ReceivableSetupAndGroupAccountListBAL
{
    ReceivableSetupAndGroupAccountListDAL receivableSetupAndGroupAccountListDAL = new ReceivableSetupAndGroupAccountListDAL();
    public ReceivableSetupAndGroupAccountListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetReceivableSetupAndGroupAccountList()
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupAndGroupAccountListDAL.GetReceivableSetupAndGroupAccountList();
        return dtb;
    }

    public DataTable GetReceivableSetupAndGroupAccountListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupAndGroupAccountListDAL.GetReceivableSetupAndGroupAccountListForExportToExcel();
        return dtb;
    }
    public DataTable GetBatchListById(ReceivableSetupAndGroupAccountListUI receivableSetupAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupAndGroupAccountListDAL.GetReceivableSetupAndGroupAccountListById(receivableSetupAndGroupAccountListUI);
        return dtb;
    }

    public DataTable GetReceivableSetupAndGroupAccountListBySearchParameters(ReceivableSetupAndGroupAccountListUI receivableSetupAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupAndGroupAccountListDAL.GetReceivableSetupAndGroupAccountListBySearchParameters(receivableSetupAndGroupAccountListUI);
        return dtb;
    }

    public int DeleteReceivableSetupAndGroupAccount(ReceivableSetupAndGroupAccountListUI receivableSetupAndGroupAccountListUI)
    {
        int result = 0;
        result = receivableSetupAndGroupAccountListDAL.DeleteReceivableSetupAndGroupAccount(receivableSetupAndGroupAccountListUI);
        return result;
    }
}