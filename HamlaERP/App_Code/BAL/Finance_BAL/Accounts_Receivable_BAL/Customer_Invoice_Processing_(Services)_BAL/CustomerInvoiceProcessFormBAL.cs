using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for CustomerInvoiceProcessFormBAL
/// </summary>
public class CustomerInvoiceProcessFormBAL
{
    CustomerInvoiceProcessFormDAL customerInvoiceProcessFormDAL = new CustomerInvoiceProcessFormDAL();

	public CustomerInvoiceProcessFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetCustomerInvoiceProcessListById(CustomerInvoiceProcessFormUI customerInvoiceProcessFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceProcessFormDAL.GetCustomerInvoiceProcessListById(customerInvoiceProcessFormUI);
        return dtb;
    }

    public int AddCustomerInvoiceProcess(CustomerInvoiceProcessFormUI customerInvoiceProcessFormUI)
    {
        int resutl = 0;
        resutl = customerInvoiceProcessFormDAL.AddCustomerInvoiceProcess(customerInvoiceProcessFormUI);
        return resutl;
    }

    public int UpdateCustomerInvoiceProcess(CustomerInvoiceProcessFormUI customerInvoiceProcessFormUI)
    {
        int resutl = 0;
        resutl = customerInvoiceProcessFormDAL.UpdateCustomerInvoiceProcess(customerInvoiceProcessFormUI);
        return resutl;
    }

    public int DeleteCustomerInvoiceProcess(CustomerInvoiceProcessFormUI customerInvoiceProcessFormUI)
    {
        int resutl = 0;
        resutl = customerInvoiceProcessFormDAL.DeleteCustomerInvoiceProcess(customerInvoiceProcessFormUI);
        return resutl;
    }
}