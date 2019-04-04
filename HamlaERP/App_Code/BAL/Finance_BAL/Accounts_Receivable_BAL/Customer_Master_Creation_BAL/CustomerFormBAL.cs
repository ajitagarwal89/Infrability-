using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CustomerFormBLL
/// </summary>
public class CustomerFormBAL
{
    CustomerFormDAL customerFormDAL = new CustomerFormDAL();

	public CustomerFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetCustomerListById(CustomerFormUI customerFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerFormDAL.GetCustomerListById(customerFormUI);
        return dtb;
    }

    public int AddCustomer(CustomerFormUI customerFormUI)
    {
        int resutl = 0;
        resutl = customerFormDAL.AddCustomer(customerFormUI);
        return resutl;
    }

    public int UpdateCustomer(CustomerFormUI customerFormUI)
    {
        int resutl = 0;
        resutl = customerFormDAL.UpdateCustomer(customerFormUI);
        return resutl;
    }

    public int DeleteCustomer(CustomerFormUI customerFormUI)
    {
        int resutl = 0;
        resutl = customerFormDAL.DeleteCustomer(customerFormUI);
        return resutl;
    }
}