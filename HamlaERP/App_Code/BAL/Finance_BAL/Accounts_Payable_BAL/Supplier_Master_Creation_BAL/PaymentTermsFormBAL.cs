using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PaymentTermsFormBLL
/// </summary>
public class PaymentTermsFormBAL
{
    PaymentTermsFormDAL paymentTermsFormDAL = new PaymentTermsFormDAL();

	public PaymentTermsFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetPaymentTermsListById(PaymentTermsFormUI paymentTermsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentTermsFormDAL.GetPaymentTermsListById(paymentTermsFormUI);
        return dtb;
    }

    public int AddPaymentTerms(PaymentTermsFormUI paymentTermsFormUI)
    {
        int resutl = 0;
        resutl = paymentTermsFormDAL.AddPaymentTerms(paymentTermsFormUI);
        return resutl;
    }

    public int UpdatePaymentTerms(PaymentTermsFormUI paymentTermsFormUI)
    {
        int resutl = 0;
        resutl = paymentTermsFormDAL.UpdatePaymentTerms(paymentTermsFormUI);
        return resutl;
    }

    public int DeletePaymentTerms(PaymentTermsFormUI paymentTermsFormUI)
    {
        int resutl = 0;
        resutl = paymentTermsFormDAL.DeletePaymentTerms(paymentTermsFormUI);
        return resutl;
    }
}