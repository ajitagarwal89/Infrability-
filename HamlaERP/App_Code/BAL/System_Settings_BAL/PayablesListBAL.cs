using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for PayablesListBLL
/// </summary>
public class PayablesListBAL
{
    PayablesListDAL payablesListDAL = new PayablesListDAL();

    public PayablesListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPayablesList()
    {
        DataTable dtb = new DataTable();
        dtb = payablesListDAL.GetPayablesList();
        return dtb;
    }

    public DataTable GetPayablesListById(PayablesListUI payablesListUI)
    {
        DataTable dtb = new DataTable();
        dtb = payablesListDAL.GetPayablesListById(payablesListUI);
        return dtb;
    }

    public DataTable GetPayablesListBySearchParameters(PayablesListUI payablesListUI)
    {
        DataTable dtb = new DataTable();
        dtb = payablesListDAL.GetPayablesListBySearchParameters(payablesListUI);
        return dtb;
    }

    public DataTable GetPayablesListByPayablesAndProcessType(PayablesListUI payablesListUI)
    {
        DataTable dtb = new DataTable();
        dtb = payablesListDAL.GetPayablesListByPayablesAndProcessType(payablesListUI);
        return dtb;
    }

    public DataTable GetPayablesListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = payablesListDAL.GetPayablesListForExportToExcel();
        return dtb;
    }

    public int DeletePayables(PayablesListUI payablesListUI)
    {
        int result = 0;
        result = payablesListDAL.DeletePayables(payablesListUI);
        return result;
    }
}