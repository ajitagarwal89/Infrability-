using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ReceivableSetupGroupListBAL
/// </summary>
public class ReceivableSetupGroupListBAL
{
    ReceivableSetupGroupListDAL receivableSetupGroupListDAL = new ReceivableSetupGroupListDAL();
    ReceivableSetupGroupListUI receivableSetupGroupListUI = new ReceivableSetupGroupListUI();
    public ReceivableSetupGroupListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetReceivableSetupGroupList()
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupGroupListDAL.GetReceivableSetupGroupList();
        return dtb;
    }

    public DataTable GetReceivableSetupGroupListById(ReceivableSetupGroupListUI receivableSetupGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupGroupListDAL.GetReceivableSetupGroupListById(receivableSetupGroupListUI);
        return dtb;
    }

    public DataTable GetReceivableSetupGroupListBySearchParameters(ReceivableSetupGroupListUI receivableSetupGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupGroupListDAL.GetReceivableSetupGroupListBySearchParameters(receivableSetupGroupListUI);
        return dtb;
    }

    public int DeleteReceivableSetupGroup(ReceivableSetupGroupListUI receivableSetupGroupListUI)
    {
        int result = 0;
        result = receivableSetupGroupListDAL.DeleteReceivableSetupGroup(receivableSetupGroupListUI);
        return result;
    }

    public DataTable GetReceivableSetupGroupListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupGroupListDAL.GetReceivableSetupGroupListForExportToExcel();
        return dtb;
    }
}