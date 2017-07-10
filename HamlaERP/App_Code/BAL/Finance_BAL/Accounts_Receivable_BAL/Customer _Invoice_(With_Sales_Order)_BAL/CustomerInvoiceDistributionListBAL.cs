using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CustomerInvoiceDistributionListBAL
/// </summary>
public class CustomerInvoiceDistributionListBAL
{

    CustomerInvoiceDistributionListDAL customerInvoiceDistributionListDAL = new CustomerInvoiceDistributionListDAL();

    public CustomerInvoiceDistributionListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetCustomerInvoiceDistributionList()
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceDistributionListDAL.GetCustomerInvoiceDistributionList();
        return dtb;
    }

    public DataTable GetCustomerInvoiceDistributionListById(CustomerInvoiceDistributionListUI customerInvoiceDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceDistributionListDAL.GetCustomerInvoiceDistributionListById(customerInvoiceDistributionListUI);
        return dtb;
    }

    public DataTable GetCustomerInvoiceDistributionListBySearchParameters(CustomerInvoiceDistributionListUI customerInvoiceDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceDistributionListDAL.GetCustomerInvoiceDistributionListBySearchParameters(customerInvoiceDistributionListUI);
        return dtb;
    }

    public int DeleteCustomerInvoiceDistribution(CustomerInvoiceDistributionListUI customerInvoiceDistributionListUI)
    {
        int result = 0;
        result = customerInvoiceDistributionListDAL.DeleteCustomerInvoiceDistribution(customerInvoiceDistributionListUI);
        return result;
    }

    public DataTable GetCustomerInvoiceDistributionListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceDistributionListDAL.GetCustomerInvoiceDistributionListForExportToExcel();
        return dtb;
    }

}