using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DownPaymentFromCustomerListBAL
/// </summary>
public class DownPaymentFromCustomerListBAL
{
    DownPaymentFromCustomerListDAL downPaymentFromCustomerListDAL = new DownPaymentFromCustomerListDAL();
    public DownPaymentFromCustomerListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetDownPaymentFromCustomerList()
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerListDAL.GetDownPaymentFromCustomerList();
        return dtb;
    }
    public DataTable GetDownPaymentFromCustomerListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerListDAL.GetDownPaymentFromCustomerListForExportToExcel();
        return dtb;
    }
    public DataTable GetDownPaymentFromCustomerListById(DownPaymentFromCustomerListUI downPaymentFromCustomerListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerListDAL.GetDownPaymentFromCustomerListById(downPaymentFromCustomerListUI);
        return dtb;
    }

    public DataTable GetDownPaymentFromCustomerListBySearchParameters(DownPaymentFromCustomerListUI downPaymentFromCustomerListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerListDAL.GetDownPaymentFromCustomerListBySearchParameters(downPaymentFromCustomerListUI);
        return dtb;
    }

    public int DeleteDownPaymentFromCustomer(DownPaymentFromCustomerListUI downPaymentFromCustomerListUI)
    {
        int result = 0;
        result = downPaymentFromCustomerListDAL.DeleteDownPaymentFromCustomer(downPaymentFromCustomerListUI);
        return result;
    }

}