using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentFromCustomerListBAL
/// </summary>
public class PaymentFromCustomerListBAL
{
    PaymentFromCustomerListDAL PaymentFromCustomerListDAL = new PaymentFromCustomerListDAL();
    public PaymentFromCustomerListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentFromCustomerList()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerListDAL.GetPaymentFromCustomerList();
        return dtb;
    }
    public DataTable GetPaymentFromCustomerListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerListDAL.GetPaymentFromCustomerListForExportToExcel();
        return dtb;
    }
    public DataTable GetPaymentFromCustomerListById(PaymentFromCustomerListUI PaymentFromCustomerListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerListDAL.GetPaymentFromCustomerListById(PaymentFromCustomerListUI);
        return dtb;
    }

    public DataTable GetPaymentFromCustomerListBySearchParameters(PaymentFromCustomerListUI PaymentFromCustomerListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerListDAL.GetPaymentFromCustomerListBySearchParameters(PaymentFromCustomerListUI);
        return dtb;
    }

    public int DeletePaymentFromCustomer(PaymentFromCustomerListUI PaymentFromCustomerListUI)
    {
        int result = 0;
        result = PaymentFromCustomerListDAL.DeletePaymentFromCustomer(PaymentFromCustomerListUI);
        return result;
    }

}