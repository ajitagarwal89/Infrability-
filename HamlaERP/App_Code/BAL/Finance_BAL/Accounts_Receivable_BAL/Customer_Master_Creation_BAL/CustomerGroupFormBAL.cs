using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for CustomerGroupFormBLL
/// </summary>
public class CustomerGroupFormBAL
{

    CustomerGroupFormDAL customerGroupFormDAL = new CustomerGroupFormDAL();

	public CustomerGroupFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetCustomerGroupListById(CustomerGroupFormUI customerGroupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerGroupFormDAL.GetCustomerGroupListById(customerGroupFormUI);
        return dtb;
    }

    public int AddCustomerGroup(CustomerGroupFormUI customerGroupFormUI)
    {
        int resutl = 0;
        resutl = customerGroupFormDAL.AddCustomerGroup(customerGroupFormUI);
        return resutl;
    }

    public int UpdateCustomerGroup(CustomerGroupFormUI customerGroupFormUI)
    {
        int resutl = 0;
        resutl = customerGroupFormDAL.UpdateCustomerGroup(customerGroupFormUI);
        return resutl;
    }

    public int DeleteCustomerGroup(CustomerGroupFormUI customerGroupFormUI)
    {
        int resutl = 0;
        resutl = customerGroupFormDAL.DeleteCustomerGroup(customerGroupFormUI);
        return resutl;
    }
}