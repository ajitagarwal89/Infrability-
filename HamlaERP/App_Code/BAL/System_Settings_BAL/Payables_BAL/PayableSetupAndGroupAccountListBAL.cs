using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PayableSetupGroupAccountListBAL
/// </summary>
public class PayableSetupAndGroupAccountListBAL
{
    PayableSetupAndGroupAccountListDAL payableSetupAndGroupAccountListDAL = new PayableSetupAndGroupAccountListDAL();
    public PayableSetupAndGroupAccountListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPayableSetupAndGroupAccount_List()
    {
        DataTable dtb = new DataTable();
        dtb = payableSetupAndGroupAccountListDAL.GetPayableSetupAndGroupAccount_List();
        return dtb;
    }

    public DataTable GetPayableSetupAndGroupAccountListById(PayableSetupAndGroupAccountListUI payableSetupAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = payableSetupAndGroupAccountListDAL.GetPayableSetupAndGroupAccountListById(payableSetupAndGroupAccountListUI);
        return dtb;
    }

    public DataTable GetPayableSetupAndGroupAccountListBySearchParameters(PayableSetupAndGroupAccountListUI payableSetupAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = payableSetupAndGroupAccountListDAL.GetPayableSetupAndGroupAccountListBySearchParameters(payableSetupAndGroupAccountListUI);
        return dtb;
    }

    public DataTable GetPayableSetupAndGroupAccountListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = payableSetupAndGroupAccountListDAL.GetPayableSetupAndGroupAccountListForExportToExcel();
        return dtb;
    }

    public int DeletePayableSetupAndGroupAccount(PayableSetupAndGroupAccountListUI payableSetupAndGroupAccountListUI)
    {
        int result = 0;
        result = payableSetupAndGroupAccountListDAL.DeletePayableSetupAndGroupAccount(payableSetupAndGroupAccountListUI);
        return result;
    }
}