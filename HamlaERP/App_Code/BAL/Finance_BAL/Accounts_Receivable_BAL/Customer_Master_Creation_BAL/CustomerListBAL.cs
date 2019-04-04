using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CustomerListBLL
/// </summary>
public class CustomerListBAL
{
    CustomerListDAL customerListDAL = new CustomerListDAL();

    public CustomerListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetCustomerList()
    {
        DataTable dtb = new DataTable();
        dtb = customerListDAL.GetCustomerList();
        return dtb;
    }

    public DataTable GetCustomerListById(CustomerListUI customerListUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerListDAL.GetCustomerListById(customerListUI);
        return dtb;
    }

    public DataTable GetCustomerListBySearchParameters(CustomerListUI customerListUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerListDAL.GetCustomerListBySearchParameters(customerListUI);
        return dtb;
    }

    public DataTable GetCustomerListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = customerListDAL.GetCustomerListForExportToExcel();
        return dtb;
    }

    public int DeleteCustomer(CustomerListUI customerListUI)
    {
        int result = 0;
        result = customerListDAL.DeleteCustomer(customerListUI);
        return result;
    }
}