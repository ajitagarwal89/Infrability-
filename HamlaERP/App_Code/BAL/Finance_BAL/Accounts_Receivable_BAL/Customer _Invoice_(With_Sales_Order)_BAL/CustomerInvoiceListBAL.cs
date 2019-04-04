using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for CustomerInvoiceListBAL
/// </summary>
public class CustomerInvoiceListBAL
{
    CustomerInvoiceListDAL customerInvoiceListDAL = new CustomerInvoiceListDAL();

    public CustomerInvoiceListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetCustomerInvoiceList()
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceListDAL.GetCustomerInvoiceList();
        return dtb;
    }

    public DataTable GetCustomerInvoiceListById(CustomerInvoiceListUI customerInvoiceListUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceListDAL.GetCustomerInvoiceListById(customerInvoiceListUI);
        return dtb;
    }

    public DataTable GetCustomerInvoiceListBySearchParameters(CustomerInvoiceListUI customerInvoiceListUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceListDAL.GetCustomerInvoiceListBySearchParameters(customerInvoiceListUI);
        return dtb;
    }

    public DataTable GetCustomerInvoiceListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceListDAL.GetCustomerInvoiceListForExportToExcel();
        return dtb;
    }

    public int DeleteCustomerInvoice(CustomerInvoiceListUI customerInvoiceListUI)
    {
        int result = 0;
        result = customerInvoiceListDAL.DeleteCustomerInvoice(customerInvoiceListUI);
        return result;
    }
}