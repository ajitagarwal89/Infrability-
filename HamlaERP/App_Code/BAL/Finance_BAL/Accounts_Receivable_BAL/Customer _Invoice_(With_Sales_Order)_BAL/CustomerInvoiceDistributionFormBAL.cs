using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for CustomerInvoiceDistributionFormBAL
/// </summary>
public class CustomerInvoiceDistributionFormBAL
{

    CustomerInvoiceDistributionFormDAL customerInvoiceDistributionFormDAL = new CustomerInvoiceDistributionFormDAL();

    public CustomerInvoiceDistributionFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetCustomerInvoiceDistributionListById(CustomerInvoiceDistributionFormUI customerInvoiceDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceDistributionFormDAL.GetCustomerInvoiceDistributionListById(customerInvoiceDistributionFormUI);
        return dtb;
    }

    public int AddCustomerInvoiceDistribution(CustomerInvoiceDistributionFormUI customerInvoiceDistributionFormUI)
    {
        int resutl = 0;
        resutl = customerInvoiceDistributionFormDAL.AddCustomerInvoiceDistribution(customerInvoiceDistributionFormUI);
        return resutl;
    }

    public int UpdateCustomerInvoiceDistribution(CustomerInvoiceDistributionFormUI customerInvoiceDistributionFormUI)
    {
        int resutl = 0;
        resutl = customerInvoiceDistributionFormDAL.UpdateCustomerInvoiceDistribution(customerInvoiceDistributionFormUI);
        return resutl;
    }

    public int DeleteCustomerInvoiceDistribution(CustomerInvoiceDistributionFormUI customerInvoiceDistributionFormUI)
    {
        int resutl = 0;
        resutl = customerInvoiceDistributionFormDAL.DeleteCustomerInvoiceDistribution(customerInvoiceDistributionFormUI);
        return resutl;
    }

    public DataTable GetCustomerInvoiceDistribution_SelectByCustomerInvoiceId(CustomerInvoiceDistributionFormUI customerInvoiceDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = customerInvoiceDistributionFormDAL.GetCustomerInvoiceDistribution_SelectByCustomerInvoiceId(customerInvoiceDistributionFormUI);
        return dtb;
    }
}