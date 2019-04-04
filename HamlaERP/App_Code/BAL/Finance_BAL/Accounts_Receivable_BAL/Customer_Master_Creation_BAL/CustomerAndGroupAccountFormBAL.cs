using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for CustomerAndGroupAccountFormBLL
/// </summary>
public class CustomerAndGroupAccountFormBAL
{
    CustomerAndGroupAccountFormDAL customerAndGroupAccountFormDAl = new CustomerAndGroupAccountFormDAL();

	public CustomerAndGroupAccountFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetCustomerAndGroupAccountListById(CustomerAndGroupAccountFormUI customerAndGroupAccountFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerAndGroupAccountFormDAl.GetCustomerAndGroupAccountListById(customerAndGroupAccountFormUI);
        return dtb;
    }

    public int AddCustomerAndGroupAccount(CustomerAndGroupAccountFormUI customerAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = customerAndGroupAccountFormDAl.AddCustomerAndGroupAccount(customerAndGroupAccountFormUI);
        return resutl;
    }

    public int UpdateCustomerAndGroupAccount(CustomerAndGroupAccountFormUI customerAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = customerAndGroupAccountFormDAl.UpdateCustomerAndGroupAccount(customerAndGroupAccountFormUI);
        return resutl;
    }

    public int DeleteCustomerAndGroupAccount(CustomerAndGroupAccountFormUI customerAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = customerAndGroupAccountFormDAl.DeleteCustomerAndGroupAccount(customerAndGroupAccountFormUI);
        return resutl;
    }

}