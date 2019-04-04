using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PaymentToSupplierEmployeeListBAL
/// </summary>
public class PaymentToSupplierEmployeeListBAL
{
    PaymentToSupplierEmployeeListDAL paymentToSupplierEmployeeListDAL = new PaymentToSupplierEmployeeListDAL();
    public PaymentToSupplierEmployeeListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentToSupplierEmployeeList()
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeListDAL.GetPaymentToSupplierEmployeeList();
        return dtb;
    }
    public DataTable GetPaymentToSupplierEmployeeListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeListDAL.GetPaymentToSupplierEmployeeListForExportToExcel();
        return dtb;
    }
    public DataTable GetPaymentToSupplierEmployeeListById(PaymentToSupplierEmployeeListUI paymentToSupplierEmployeeListUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeListDAL.GetPaymentToSupplierEmployeeListById(paymentToSupplierEmployeeListUI);
        return dtb;
    }

    public DataTable GetPaymentToSupplierEmployeeListBySearchParameters(PaymentToSupplierEmployeeListUI paymentToSupplierEmployeeListUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeListDAL.GetPaymentToSupplierEmployeeListBySearchParameters(paymentToSupplierEmployeeListUI);
        return dtb;
    }

    public int DeletePaymentToSupplierEmployee(PaymentToSupplierEmployeeListUI paymentToSupplierEmployeeListUI)
    {
        int result = 0;
        result = paymentToSupplierEmployeeListDAL.DeletePaymentToSupplierEmployee(paymentToSupplierEmployeeListUI);
        return result;
    }

}