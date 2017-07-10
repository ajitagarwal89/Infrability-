using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for CustomerInvoiceProcessListBAL
/// </summary>
public class CustomerInvoiceProcessListBAL
{
    CustomerInvoiceProcessListDAL customerInvoiceProcessListDAL = new CustomerInvoiceProcessListDAL();

    public CustomerInvoiceProcessListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetCustomerInvoiceProcessList()
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceProcessListDAL.GetCustomerInvoiceProcessList();
        return dtb;
    }

    public DataTable GetCustomerInvoiceProcessListById(CustomerInvoiceProcessListUI customerInvoiceProcessListUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceProcessListDAL.GetCustomerInvoiceProcessListById(customerInvoiceProcessListUI);
        return dtb;
    }

    public DataTable GetCustomerInvoiceProcessListBySearchParameters(CustomerInvoiceProcessListUI customerInvoiceProcessListUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceProcessListDAL.GetCustomerInvoiceProcessListBySearchParameters(customerInvoiceProcessListUI);
        return dtb;
    }

    public DataTable GetCustomerInvoiceProcessListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceProcessListDAL.GetCustomerInvoiceProcessListForExportToExcel();
        return dtb;
    }

    public int DeleteCustomerInvoiceProcess(CustomerInvoiceProcessListUI customerInvoiceProcessListUI)
    {
        int result = 0;
        result = customerInvoiceProcessListDAL.DeleteCustomerInvoiceProcess(customerInvoiceProcessListUI);
        return result;
    }
}