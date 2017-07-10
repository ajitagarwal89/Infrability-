using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentFromCustomerDistributionListBAL
/// </summary>
public class PaymentFromCustomerDistributionListBAL
{
    PaymentFromCustomerDistributionListDAL PaymentFromCustomerDistributionListDAL = new PaymentFromCustomerDistributionListDAL();
    public PaymentFromCustomerDistributionListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentFromCustomerDistributionList()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerDistributionListDAL.GetPaymentFromCustomerDistributionList();
        return dtb;
    }
    public DataTable GetPaymentFromCustomerDistributionListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerDistributionListDAL.GetPaymentFromCustomerDistributionListForExportToExcel();
        return dtb;
    }
    public DataTable GetPaymentFromCustomerDistributionListById(PaymentFromCustomerDistributionListUI PaymentFromCustomerDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerDistributionListDAL.GetPaymentFromCustomerDistributionListById(PaymentFromCustomerDistributionListUI);
        return dtb;
    }

    public DataTable GetPaymentFromCustomerDistributionListBySearchParameters(PaymentFromCustomerDistributionListUI PaymentFromCustomerDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerDistributionListDAL.GetPaymentFromCustomerDistributionListBySearchParameters(PaymentFromCustomerDistributionListUI);
        return dtb;
    }

    public int DeletePaymentFromCustomerDistribution(PaymentFromCustomerDistributionListUI PaymentFromCustomerDistributionListUI)
    {
        int result = 0;
        result = PaymentFromCustomerDistributionListDAL.DeletePaymentFromCustomerDistribution(PaymentFromCustomerDistributionListUI);
        return result;
    }

}