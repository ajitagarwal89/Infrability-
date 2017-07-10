using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for CustomerGroupListBLL
/// </summary>
public class CustomerGroupListBAL
{
    CustomerGroupListDAL customerGroupListDAL = new CustomerGroupListDAL();

    public CustomerGroupListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetCustomerGroupList()
    {
        DataTable dtb = new DataTable();
        dtb = customerGroupListDAL.GetCustomerGroupList();
        return dtb;
    }

    public DataTable GetCustomerGroupListById(CustomerGroupListUI customerGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerGroupListDAL.GetCustomerGroupListById(customerGroupListUI);
        return dtb;
    }

    public DataTable GetCustomerGroupListBySearchParameters(CustomerGroupListUI customerGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerGroupListDAL.GetCustomerGroupListBySearchParameters(customerGroupListUI);
        return dtb;
    }

    public int DeleteCustomerGroup(CustomerGroupListUI customerGroupListUI)
    {
        int result = 0;
        result = customerGroupListDAL.DeleteCustomerGroup(customerGroupListUI);
        return result;
    }

    public DataTable GetCustomerGroupListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = customerGroupListDAL.GetCustomerGroupListForExportToExcel();
        return dtb;
    }

}