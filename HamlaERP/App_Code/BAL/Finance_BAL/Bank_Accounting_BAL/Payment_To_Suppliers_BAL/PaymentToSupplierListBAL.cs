using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for PaymentToSupplierListBLL
/// </summary>
public class PaymentToSupplierListBAL
{
    PaymentToSupplierListDAL paymentToSupplierListDAL = new PaymentToSupplierListDAL();

	public PaymentToSupplierListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetPaymentToSupplierList()
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierListDAL.GetPaymentToSupplierList();
        return dtb;
    }

    public DataTable GetPaymentToSupplierListById(PaymentToSupplierListUI paymentToSupplierListUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierListDAL.GetPaymentToSupplierListById(paymentToSupplierListUI);
        return dtb;
    }

    public DataTable GetPaymentToSupplierListBySearchParameters(PaymentToSupplierListUI paymentToSupplierListUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierListDAL.GetPaymentToSupplierListBySearchParameters(paymentToSupplierListUI);
        return dtb;
    }

    public int DeletePaymentToSupplier(PaymentToSupplierListUI paymentToSupplierListUI)
    {
        int result = 0;
        result = paymentToSupplierListDAL.DeletePaymentToSupplier(paymentToSupplierListUI);
        return result;
    }
}