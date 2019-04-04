using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PaymentToSupplierEmployeeFormBAL
/// </summary>
public class PaymentToSupplierEmployeeFormBAL
{
    PaymentToSupplierEmployeeFormDAL paymentToSupplierEmployeeFormDAL = new PaymentToSupplierEmployeeFormDAL();
    public PaymentToSupplierEmployeeFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPaymentToSupplierEmployeeListById(PaymentToSupplierEmployeeFormUI paymentToSupplierEmployeeFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeFormDAL.GetPaymentToSupplierEmployeeListById(paymentToSupplierEmployeeFormUI);
        return dtb;
    }

    public int AddPaymentToSupplierEmployee(PaymentToSupplierEmployeeFormUI paymentToSupplierEmployeeFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierEmployeeFormDAL.AddPaymentToSupplierEmployee(paymentToSupplierEmployeeFormUI);
        return resutl;
    }
    public int UpdatePaymentToSupplierEmployee(PaymentToSupplierEmployeeFormUI paymentToSupplierEmployeeFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierEmployeeFormDAL.UpdatePaymentToSupplierEmployee(paymentToSupplierEmployeeFormUI);
        return resutl;
    }

    public int DeletePaymentToSupplierEmployee(PaymentToSupplierEmployeeFormUI paymentToSupplierEmployeeFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierEmployeeFormDAL.DeletePaymentToSupplierEmployee(paymentToSupplierEmployeeFormUI);
        return resutl;
    }

    public int UpdatePostingPaymentToSupplierEmployee(PaymentToSupplierEmployeeFormUI paymentToSupplierEmployeeFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierEmployeeFormDAL.UpdatePostingPaymentToSupplierEmployee(paymentToSupplierEmployeeFormUI);
        return resutl;
    }

    public DataTable GetSerialNumber()
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeFormDAL.GetSerialNumber();
        return dtb;
    }

}