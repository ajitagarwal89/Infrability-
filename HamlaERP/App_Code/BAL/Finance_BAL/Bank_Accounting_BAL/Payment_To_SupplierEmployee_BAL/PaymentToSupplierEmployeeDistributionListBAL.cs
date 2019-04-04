using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PaymentToSupplierEmployeeDistributionListBAL
/// </summary>
public class PaymentToSupplierEmployeeDistributionListBAL
{
    PaymentToSupplierEmployeeDistributionListDAL paymentToSupplierEmployeeDistributionListDAL = new PaymentToSupplierEmployeeDistributionListDAL();
    public PaymentToSupplierEmployeeDistributionListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentToSupplierEmployeeDistributionList()
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeDistributionListDAL.GetPaymentToSupplierEmployeeDistributionList();
        return dtb;
    }
    public DataTable GetPaymentToSupplierEmployeeDistributionListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeDistributionListDAL.GetPaymentToSupplierEmployeeDistributionListForExportToExcel();
        return dtb;
    }
    public DataTable GetPaymentToSupplierEmployeeDistributionListById(PaymentToSupplierEmployeeDistributionListUI paymentToSupplierEmployeeDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeDistributionListDAL.GetPaymentToSupplierEmployeeDistributionListById(paymentToSupplierEmployeeDistributionListUI);
        return dtb;
    }

    public DataTable GetPaymentToSupplierEmployeeDistributionListBySearchParameters(PaymentToSupplierEmployeeDistributionListUI paymentToSupplierEmployeeDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeDistributionListDAL.GetPaymentToSupplierEmployeeDistributionListBySearchParameters(paymentToSupplierEmployeeDistributionListUI);
        return dtb;
    }

    public int DeletePaymentToSupplierEmployeeDistribution(PaymentToSupplierEmployeeDistributionListUI paymentToSupplierEmployeeDistributionListUI)
    {
        int result = 0;
        result = paymentToSupplierEmployeeDistributionListDAL.DeletePaymentToSupplierEmployeeDistribution(paymentToSupplierEmployeeDistributionListUI);
        return result;
    }

}