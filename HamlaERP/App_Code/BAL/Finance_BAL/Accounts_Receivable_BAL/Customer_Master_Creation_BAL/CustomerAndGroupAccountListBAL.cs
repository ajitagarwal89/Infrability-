using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CustomerAndGroupAccountListBLL
/// </summary>
public class CustomerAndGroupAccountListBAL
{
    CustomerAndGroupAccountListDAL customerAndGroupAccountListDAL = new CustomerAndGroupAccountListDAL();

    public CustomerAndGroupAccountListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetCustomerAndGroupAccountList()
    {
        DataTable dtb = new DataTable();
        dtb = customerAndGroupAccountListDAL.GetCustomerAndGroupAccountList();
        return dtb;
    }

    public DataTable GetCustomerAndGroupAccountListById(CustomerAndGroupAccountListUI customerAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerAndGroupAccountListDAL.GetCustomerAndGroupAccountListById(customerAndGroupAccountListUI);
        return dtb;
    }

    public DataTable GetCustomerAndGroupAccountListBySearchParameters(CustomerAndGroupAccountListUI customerAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerAndGroupAccountListDAL.GetCustomerAndGroupAccountListBySearchParameters(customerAndGroupAccountListUI);
        return dtb;
    }

    public DataTable GetCustomerAndGroupAccountListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = customerAndGroupAccountListDAL.GetCustomerAndGroupAccountListForExportToExcel();
        return dtb;
    }

    public int DeleteCustomerAndGroupAccount(CustomerAndGroupAccountListUI customerAndGroupAccountListUI)
    {
        int result = 0;
        result = customerAndGroupAccountListDAL.DeleteCustomerAndGroupAccount(customerAndGroupAccountListUI);
        return result;
    }
}