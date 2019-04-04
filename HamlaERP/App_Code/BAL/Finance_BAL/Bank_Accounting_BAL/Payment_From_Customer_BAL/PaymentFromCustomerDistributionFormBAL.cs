using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PaymentFromCustomerDistributionFormBAL
/// </summary>
public class PaymentFromCustomerDistributionFormBAL
{
    PaymentFromCustomerDistributionFormDAL PaymentFromCustomerDistributionFormDAL = new PaymentFromCustomerDistributionFormDAL();
    public PaymentFromCustomerDistributionFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentFromCustomerDistributionListById(PaymentFromCustomerDistributionFormUI PaymentFromCustomerDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerDistributionFormDAL.GetPaymentFromCustomerDistributionListById(PaymentFromCustomerDistributionFormUI);
        return dtb;
    }

    public int AddPaymentFromCustomerDistribution(PaymentFromCustomerDistributionFormUI PaymentFromCustomerDistributionFormUI)
    {
        int resutl = 0;
        resutl = PaymentFromCustomerDistributionFormDAL.AddPaymentFromCustomerDistribution(PaymentFromCustomerDistributionFormUI);
        return resutl;
    }
    public int UpdatePaymentFromCustomerDistribution(PaymentFromCustomerDistributionFormUI PaymentFromCustomerDistributionFormUI)
    {
        int resutl = 0;
        resutl = PaymentFromCustomerDistributionFormDAL.UpdatePaymentFromCustomerDistribution(PaymentFromCustomerDistributionFormUI);
        return resutl;
    }

    public int DeletePaymentFromCustomerDistribution(PaymentFromCustomerDistributionFormUI PaymentFromCustomerDistributionFormUI)
    {
        int resutl = 0;
        resutl = PaymentFromCustomerDistributionFormDAL.DeletePaymentFromCustomerDistribution(PaymentFromCustomerDistributionFormUI);
        return resutl;
    }
    public DataTable GetPaymentFromCustomerDistribution_SelectByPaymentFromCustomerId(PaymentFromCustomerDistributionFormUI paymentFromCustomerDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerDistributionFormDAL.GetPaymentFromCustomerDistribution_SelectByPaymentFromCustomerId(paymentFromCustomerDistributionFormUI);
        return dtb;
    }

}