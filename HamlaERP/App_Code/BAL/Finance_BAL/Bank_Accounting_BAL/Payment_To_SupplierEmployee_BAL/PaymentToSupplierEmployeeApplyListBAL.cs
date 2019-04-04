using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentToSupplierEmployeeApplyListBAL
/// </summary>
public class PaymentToSupplierEmployeeApplyListBAL
{
    PaymentToSupplierEmployeeApplyListDAL paymentToSupplierEmployeeApplyListDAL = new PaymentToSupplierEmployeeApplyListDAL();
    public PaymentToSupplierEmployeeApplyListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentToSupplierEmployeeApplyList()
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeApplyListDAL.GetPaymentToSupplierEmployeeApplyList();
        return dtb;
    }
    public DataTable GetPaymentToSupplierEmployeeApplyListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeApplyListDAL.GetPaymentToSupplierEmployeeApplyListForExportToExcel();
        return dtb;
    }
    public DataTable GetPaymentToSupplierEmployeeApplyListById(PaymentToSupplierEmployeeApplyListUI paymentToSupplierEmployeeApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeApplyListDAL.GetPaymentToSupplierEmployeeApplyListById(paymentToSupplierEmployeeApplyListUI);
        return dtb;
    }

    public DataTable GetPaymentToSupplierEmployeeApplyListBySearchParameters(PaymentToSupplierEmployeeApplyListUI paymentToSupplierEmployeeApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeApplyListDAL.GetPaymentToSupplierEmployeeApplyListBySearchParameters(paymentToSupplierEmployeeApplyListUI);
        return dtb;
    }

    public DataTable GetPaymentToSupplierEmployeeApplyListByPaymentToEmployeeId(PaymentToSupplierEmployeeApplyListUI paymentToSupplierEmployeeApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeApplyListDAL.GetPaymentToSupplierEmployeeApplyListByPaymentToEmployeeId(paymentToSupplierEmployeeApplyListUI);
        return dtb;
    }

    public int DeletePaymentToSupplierEmployeeApply(PaymentToSupplierEmployeeApplyListUI paymentToSupplierEmployeeApplyListUI)
    {
        int result = 0;
        result = paymentToSupplierEmployeeApplyListDAL.DeletePaymentToSupplierEmployeeApply(paymentToSupplierEmployeeApplyListUI);
        return result;
    }
}