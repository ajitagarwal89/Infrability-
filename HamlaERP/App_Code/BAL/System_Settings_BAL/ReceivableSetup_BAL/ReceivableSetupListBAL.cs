using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ReceivableSetupListBAL
/// </summary>
public class ReceivableSetupListBAL
{

    ReceivableSetupListDAL receivableSetupListDAL = new ReceivableSetupListDAL();
    ReceivableSetupListUI receivableSetupListUI = new ReceivableSetupListUI();

    public ReceivableSetupListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetReceivableSetupList()
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupListDAL.GetReceivableSetupList();
        return dtb;
    }

    public DataTable GetReceivableSetupListById(ReceivableSetupListUI receivableSetupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupListDAL.GetReceivableSetupListById(receivableSetupListUI);
        return dtb;
    }

    public DataTable GetReceivableSetupListBySearchParameters(ReceivableSetupListUI receivableSetupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupListDAL.GetReceivableSetupListBySearchParameters(receivableSetupListUI);
        return dtb;
    }

    public int DeleteReceivableSetup(ReceivableSetupListUI receivableSetupListUI)
    {
        int result = 0;
        result = receivableSetupListDAL.DeleteReceivableSetup(receivableSetupListUI);
        return result;
    }

    public DataTable GetReceivableSetup_SelectExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupListDAL.GetReceivableSetup_SelectExportToExcel();
        return dtb;
    }

}