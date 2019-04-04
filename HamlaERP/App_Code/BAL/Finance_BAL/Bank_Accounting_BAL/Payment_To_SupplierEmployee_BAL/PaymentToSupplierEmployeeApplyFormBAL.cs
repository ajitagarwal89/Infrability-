using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentToSupplierEmployeeApplyFormBAL
/// </summary>
public class PaymentToSupplierEmployeeApplyFormBAL
{
    PaymentToSupplierEmployeeApplyFormDAL paymentToSupplierEmployeeApplyFormDAL = new PaymentToSupplierEmployeeApplyFormDAL();
    public PaymentToSupplierEmployeeApplyFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPaymentToSupplierEmployeeApplyListById(PaymentToSupplierEmployeeApplyFormUI paymentToSupplierEmployeeApplyFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeApplyFormDAL.GetPaymentToSupplierEmployeeApplyListById(paymentToSupplierEmployeeApplyFormUI);
        return dtb;
    }

    public int AddPaymentToSupplierEmployeeApply(PaymentToSupplierEmployeeApplyFormUI paymentToSupplierEmployeeApplyFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierEmployeeApplyFormDAL.AddPaymentToSupplierEmployeeApply(paymentToSupplierEmployeeApplyFormUI);
        return resutl;
    }
    public int UpdatePaymentToSupplierEmployeeApply(PaymentToSupplierEmployeeApplyFormUI paymentToSupplierEmployeeApplyFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierEmployeeApplyFormDAL.UpdatePaymentToSupplierEmployeeApply(paymentToSupplierEmployeeApplyFormUI);
        return resutl;
    }

    public int DeletePaymentToSupplierEmployeeApply(PaymentToSupplierEmployeeApplyFormUI paymentToSupplierEmployeeApplyFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierEmployeeApplyFormDAL.DeletePaymentToSupplierEmployeeApply(paymentToSupplierEmployeeApplyFormUI);
        return resutl;
    }

}