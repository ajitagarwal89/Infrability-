using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PaymentFromCustomerApplyFormBAL
/// </summary>
public class PaymentFromCustomerApplyFormBAL
{
    PaymentFromCustomerApplyFormDAL PaymentFromCustomerApplyFormDAL = new PaymentFromCustomerApplyFormDAL();
    public PaymentFromCustomerApplyFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPaymentFromCustomerApplyListById(PaymentFromCustomerApplyFormUI PaymentFromCustomerApplyFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerApplyFormDAL.GetPaymentFromCustomerApplyListById(PaymentFromCustomerApplyFormUI);
        return dtb;
    }

    public int AddPaymentFromCustomerApply(PaymentFromCustomerApplyFormUI PaymentFromCustomerApplyFormUI)
    {
        int resutl = 0;
        resutl = PaymentFromCustomerApplyFormDAL.AddPaymentFromCustomerApply(PaymentFromCustomerApplyFormUI);
        return resutl;
    }
    public int UpdatePaymentFromCustomerApply(PaymentFromCustomerApplyFormUI PaymentFromCustomerApplyFormUI)
    {
        int resutl = 0;
        resutl = PaymentFromCustomerApplyFormDAL.UpdatePaymentFromCustomerApply(PaymentFromCustomerApplyFormUI);
        return resutl;
    }

    public int DeletePaymentFromCustomerApply(PaymentFromCustomerApplyFormUI PaymentFromCustomerApplyFormUI)
    {
        int resutl = 0;
        resutl = PaymentFromCustomerApplyFormDAL.DeletePaymentFromCustomerApply(PaymentFromCustomerApplyFormUI);
        return resutl;
    }

}