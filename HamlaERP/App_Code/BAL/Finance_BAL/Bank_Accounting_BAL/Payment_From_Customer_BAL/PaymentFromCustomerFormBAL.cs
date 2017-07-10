using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentFromCustomerFormBAL
/// </summary>
public class PaymentFromCustomerFormBAL
{
    PaymentFromCustomerFormDAL PaymentFromCustomerFormDAL = new PaymentFromCustomerFormDAL();
    public PaymentFromCustomerFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPaymentFromCustomerListById(PaymentFromCustomerFormUI PaymentFromCustomerFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerFormDAL.GetPaymentFromCustomerListById(PaymentFromCustomerFormUI);
        return dtb;
    }

    public int AddPaymentFromCustomer(PaymentFromCustomerFormUI PaymentFromCustomerFormUI)
    {
        int resutl = 0;
        resutl = PaymentFromCustomerFormDAL.AddPaymentFromCustomer(PaymentFromCustomerFormUI);
        return resutl;
    }
    public int UpdatePaymentFromCustomer(PaymentFromCustomerFormUI PaymentFromCustomerFormUI)
    {
        int resutl = 0;
        resutl = PaymentFromCustomerFormDAL.UpdatePaymentFromCustomer(PaymentFromCustomerFormUI);
        return resutl;
    }

    public int DeletePaymentFromCustomer(PaymentFromCustomerFormUI PaymentFromCustomerFormUI)
    {
        int resutl = 0;
        resutl = PaymentFromCustomerFormDAL.DeletePaymentFromCustomer(PaymentFromCustomerFormUI);
        return resutl;
    }

}