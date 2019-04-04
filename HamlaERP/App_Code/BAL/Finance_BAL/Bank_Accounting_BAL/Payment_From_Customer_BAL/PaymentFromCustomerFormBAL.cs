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
    PaymentFromCustomerFormDAL paymentFromCustomerFormDAL = new PaymentFromCustomerFormDAL();
    public PaymentFromCustomerFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPaymentFromCustomerListById(PaymentFromCustomerFormUI paymentFromCustomerFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentFromCustomerFormDAL.GetPaymentFromCustomerListById(paymentFromCustomerFormUI);
        return dtb;
    }

    public int AddPaymentFromCustomer(PaymentFromCustomerFormUI paymentFromCustomerFormUI)
    {
        int resutl = 0;
        resutl = paymentFromCustomerFormDAL.AddPaymentFromCustomer(paymentFromCustomerFormUI);
        return resutl;
    }
    public int UpdatePaymentFromCustomer(PaymentFromCustomerFormUI paymentFromCustomerFormUI)
    {
        int resutl = 0;
        resutl = paymentFromCustomerFormDAL.UpdatePaymentFromCustomer(paymentFromCustomerFormUI);
        return resutl;
    }

    public int DeletePaymentFromCustomer(PaymentFromCustomerFormUI paymentFromCustomerFormUI)
    {
        int resutl = 0;
        resutl = paymentFromCustomerFormDAL.DeletePaymentFromCustomer(paymentFromCustomerFormUI);
        return resutl;
    }

    public int UpdatePostingPaymentFromCustomer(PaymentFromCustomerFormUI paymentFromCustomerFormUI)
    {
        int resutl = 0;
        resutl = paymentFromCustomerFormDAL.UpdatePostingPaymentFromCustomer(paymentFromCustomerFormUI);
        return resutl;
    }

}