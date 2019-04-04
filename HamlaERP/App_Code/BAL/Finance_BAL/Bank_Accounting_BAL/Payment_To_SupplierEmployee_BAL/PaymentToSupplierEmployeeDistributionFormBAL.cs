using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PaymentToSupplierEmployeeDistributionFormBAL
/// </summary>
public class PaymentToSupplierEmployeeDistributionFormBAL
{
    PaymentToSupplierEmployeeDistributionFormDAL paymentToSupplierEmployeeDistributionFormDAL = new PaymentToSupplierEmployeeDistributionFormDAL();
    public PaymentToSupplierEmployeeDistributionFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentToSupplierEmployeeDistributionListById(PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeDistributionFormDAL.GetPaymentToSupplierEmployeeDistributionListById(paymentToSupplierEmployeeDistributionFormUI);
        return dtb;
    }

    public int AddPaymentToSupplierEmployeeDistribution(PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierEmployeeDistributionFormDAL.AddPaymentToSupplierEmployeeDistribution(paymentToSupplierEmployeeDistributionFormUI);
        return resutl;
    }
    public int UpdatePaymentToSupplierEmployeeDistribution(PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierEmployeeDistributionFormDAL.UpdatePaymentToSupplierEmployeeDistribution(paymentToSupplierEmployeeDistributionFormUI);
        return resutl;
    }

    public int DeletePaymentToSupplierEmployeeDistribution(PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI)
    {
        int resutl = 0;
        resutl = paymentToSupplierEmployeeDistributionFormDAL.DeletePaymentToSupplierEmployeeDistribution(paymentToSupplierEmployeeDistributionFormUI);
        return resutl;
    }

    public DataTable GetGetPaymentToSupplierEmployeeDistribution_SelectByPaymentToEmployeeId(PaymentToSupplierEmployeeDistributionFormUI paymentToSupplierEmployeeDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentToSupplierEmployeeDistributionFormDAL.GetPaymentToSupplierEmployeeDistribution_SelectByPaymentToEmployeeId(paymentToSupplierEmployeeDistributionFormUI);
        return dtb;
    }
}