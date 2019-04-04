using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PaymentToEmployeeDistributionFormBAL
/// </summary>
public class PaymentToEmployeeDistributionFormBAL
{
    PaymentToEmployeeDistributionFormDAL PaymentToEmployeeDistributionFormDAL = new PaymentToEmployeeDistributionFormDAL();
    public PaymentToEmployeeDistributionFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentToEmployeeDistributionListById(PaymentToEmployeeDistributionFormUI PaymentToEmployeeDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeDistributionFormDAL.GetPaymentToEmployeeDistributionListById(PaymentToEmployeeDistributionFormUI);
        return dtb;
    }

    public int AddPaymentToEmployeeDistribution(PaymentToEmployeeDistributionFormUI PaymentToEmployeeDistributionFormUI)
    {
        int resutl = 0;
        resutl = PaymentToEmployeeDistributionFormDAL.AddPaymentToEmployeeDistribution(PaymentToEmployeeDistributionFormUI);
        return resutl;
    }
    public int UpdatePaymentToEmployeeDistribution(PaymentToEmployeeDistributionFormUI PaymentToEmployeeDistributionFormUI)
    {
        int resutl = 0;
        resutl = PaymentToEmployeeDistributionFormDAL.UpdatePaymentToEmployeeDistribution(PaymentToEmployeeDistributionFormUI);
        return resutl;
    }

    public int DeletePaymentToEmployeeDistribution(PaymentToEmployeeDistributionFormUI PaymentToEmployeeDistributionFormUI)
    {
        int resutl = 0;
        resutl = PaymentToEmployeeDistributionFormDAL.DeletePaymentToEmployeeDistribution(PaymentToEmployeeDistributionFormUI);
        return resutl;
    }

    public DataTable GetGetPaymentToEmployeeDistribution_SelectByPaymentToEmployeeId(PaymentToEmployeeDistributionFormUI PaymentToEmployeeDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeDistributionFormDAL.GetPaymentToEmployeeDistribution_SelectByPaymentToEmployeeId(PaymentToEmployeeDistributionFormUI);
        return dtb;
    }
}