using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for PaymentToSupplierFormBLL
/// </summary>
public class PaymentToSupplierFormBAL
{
    PaymentToSupplierFormDAL paymentToSupplierFormDAL = new PaymentToSupplierFormDAL();

	public PaymentToSupplierFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetPaymentToSupplierListById(PaymentToSupplierFormUI paymentToSupplierFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierFormDAL.GetPaymentToSupplierListById(paymentToSupplierFormUI);
        return dtb;
    }

    public int AddPaymentToSupplier(PaymentToSupplierFormUI paymentToSupplierFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierFormDAL.AddPaymentToSupplier(paymentToSupplierFormUI);
        return resutl;
    }

    public int UpdatePaymentToSupplier(PaymentToSupplierFormUI paymentToSupplierFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierFormDAL.UpdatePaymentToSupplier(paymentToSupplierFormUI);
        return resutl;
    }

    public int DeletePaymentToSupplier(PaymentToSupplierFormUI paymentToSupplierFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierFormDAL.DeletePaymentToSupplier(paymentToSupplierFormUI);
        return resutl;
    }

    public int UpdatePostingPaymentToSupplier(PaymentToSupplierFormUI paymentToSupplierFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierFormDAL.UpdatePostingPaymentToSupplier(paymentToSupplierFormUI);
        return resutl;
    }
    public DataTable GetSerialNumber()
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierFormDAL.GetSerialNumber();
        return dtb;
    }
}