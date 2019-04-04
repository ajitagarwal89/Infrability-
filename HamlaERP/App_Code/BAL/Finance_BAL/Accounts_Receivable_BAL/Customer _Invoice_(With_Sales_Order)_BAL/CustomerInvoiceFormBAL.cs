using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for CustomerInvoiceFormBAL
/// </summary>
public class CustomerInvoiceFormBAL
{
    CustomerInvoiceFormDAL customerInvoiceFormDAL = new CustomerInvoiceFormDAL();

	public CustomerInvoiceFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetCustomerInvoiceListById(CustomerInvoiceFormUI customerInvoiceFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceFormDAL.GetCustomerInvoiceListById(customerInvoiceFormUI);
        return dtb;
    }

    public int AddCustomerInvoice(CustomerInvoiceFormUI customerInvoiceFormUI)
    {
        int resutl = 0;
        resutl = customerInvoiceFormDAL.AddCustomerInvoice(customerInvoiceFormUI);
        return resutl;
    }

    public int UpdateCustomerInvoice(CustomerInvoiceFormUI customerInvoiceFormUI)
    {
        int resutl = 0;
        resutl = customerInvoiceFormDAL.UpdateCustomerInvoice(customerInvoiceFormUI);
        return resutl;
    }

    public int DeleteCustomerInvoice(CustomerInvoiceFormUI customerInvoiceFormUI)
    {
        int resutl = 0;
        resutl = customerInvoiceFormDAL.DeleteCustomerInvoice(customerInvoiceFormUI);
        return resutl;
    }

    public int UpdatePostingCustomerInvoice(CustomerInvoiceFormUI customerInvoiceFormUI)
    {
        int resutl = 0;
        resutl = customerInvoiceFormDAL.UpdatePostingCustomerInvoice(customerInvoiceFormUI);
        return resutl;
    }
    public DataTable GetSerialNumber(CustomerInvoiceFormUI customerInvoiceFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceFormDAL.GetSerialNumber(customerInvoiceFormUI);
        return dtb;
    }
}