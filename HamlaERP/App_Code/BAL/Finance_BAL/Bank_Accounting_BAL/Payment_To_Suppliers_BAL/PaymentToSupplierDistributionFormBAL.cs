using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentToSupplierDistributionFormBAL
/// </summary>
public class PaymentToSupplierDistributionFormBAL
{
    PaymentToSupplierDistributionFormDAL PaymentToSupplierDistributionFormDAL = new PaymentToSupplierDistributionFormDAL();
    public PaymentToSupplierDistributionFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentToSupplierDistributionListById(PaymentToSupplierDistributionFormUI PaymentToSupplierDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToSupplierDistributionFormDAL.GetPaymentToSupplierDistributionListById(PaymentToSupplierDistributionFormUI);
        return dtb;
    }

    public int AddPaymentToSupplierDistribution(PaymentToSupplierDistributionFormUI PaymentToSupplierDistributionFormUI)
    {
        int resutl = 0;
        resutl = PaymentToSupplierDistributionFormDAL.AddPaymentToSupplierDistribution(PaymentToSupplierDistributionFormUI);
        return resutl;
    }
    public int UpdatePaymentToSupplierDistribution(PaymentToSupplierDistributionFormUI PaymentToSupplierDistributionFormUI)
    {
        int resutl = 0;
        resutl = PaymentToSupplierDistributionFormDAL.UpdatePaymentToSupplierDistribution(PaymentToSupplierDistributionFormUI);
        return resutl;
    }

    public int DeletePaymentToSupplierDistribution(PaymentToSupplierDistributionFormUI PaymentToSupplierDistributionFormUI)
    {
        int resutl = 0;
        resutl = PaymentToSupplierDistributionFormDAL.DeletePaymentToSupplierDistribution(PaymentToSupplierDistributionFormUI);
        return resutl;
    }
    public DataTable GetPaymentToSupplierDistribution_SelectByDownPaymentToSupplierId(PaymentToSupplierDistributionFormUI paymentToSupplierDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToSupplierDistributionFormDAL.GetPaymentToSupplierDistribution_SelectByPaymentToSupplierId(paymentToSupplierDistributionFormUI);
        return dtb;
    }
}