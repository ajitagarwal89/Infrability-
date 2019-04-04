using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PayableSetupGroupListBAL
/// </summary>
public class PayableSetupGroupListBAL
{
    PayableSetupGroupListDAL payableSetupGroupListDAL = new PayableSetupGroupListDAL();
    public PayableSetupGroupListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPayableSetupGroup_List()
    {
        DataTable dtb = new DataTable();
        dtb = payableSetupGroupListDAL.GetPayableSetupGroup_List();
        return dtb;
    }

    public DataTable GetPayableSetupGroupListById(PayableSetupGroupListUI payableSetupGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = payableSetupGroupListDAL.GetPayableSetupGroupListById(payableSetupGroupListUI);
        return dtb;
    }

    public DataTable GetPayableSetupGroupListBySearchParameters(PayableSetupGroupListUI payableSetupGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = payableSetupGroupListDAL.GetPayableSetupGroupListBySearchParameters(payableSetupGroupListUI);
        return dtb;
    }

    public DataTable GetPayableSetupGroupListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = payableSetupGroupListDAL.GetPayableSetupGroupListForExportToExcel();
        return dtb;
    }

    public int DeletePayableSetupGroup(PayableSetupGroupListUI payableSetupGroupListUI)
    {
        int result = 0;
        result = payableSetupGroupListDAL.DeletePayableSetupGroup(payableSetupGroupListUI);
        return result;
    }
}