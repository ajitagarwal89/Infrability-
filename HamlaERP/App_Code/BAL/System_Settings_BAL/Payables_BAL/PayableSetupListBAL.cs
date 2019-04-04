using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Payable_Setup_ListBal
/// </summary>
public class PayableSetupListBAL
{
    PayableSetupListDAL payablesetupListDAL = new PayableSetupListDAL();
    public PayableSetupListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPayableSetupList()
    {
        DataTable dtb = new DataTable();
        dtb = payablesetupListDAL.GetPayable_Setup_List();
        return dtb;
    }
    public DataTable GetPayableSetupPeriodList()
    {
        DataTable dtb = new DataTable();
        dtb = payablesetupListDAL.GetPayableSetupPeriod_List();
        return dtb;
    }
    public DataTable GetPayableSetupListById(PayableSetupListUI payableSetupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = payablesetupListDAL.GetPayableSetupListById(payableSetupListUI);
        return dtb;
    }

    public DataTable GetPayableSetupListtBySearchParameters(PayableSetupListUI payableSetupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = payablesetupListDAL.GetPayableSetupListtBySearchParameters(payableSetupListUI);
        return dtb;
    }

    public int DeletePayableSetup(PayableSetupListUI payableSetupListUI)
    {
        int result = 0;
        result = payablesetupListDAL.DeletePayableSetup(payableSetupListUI);
        return result;
    }

    public DataTable GetPayableSetupListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = payablesetupListDAL.GetPayableSetupListForExportToExcel();
        return dtb;
    }
}