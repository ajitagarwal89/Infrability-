using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentToSupplierDistributionListBAL
/// </summary>
public class PaymentToSupplierDistributionListBAL
{
    PaymentToSupplierDistributionListDAL PaymentToSupplierDistributionListDAL = new PaymentToSupplierDistributionListDAL();
    public PaymentToSupplierDistributionListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentToSupplierDistributionList()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToSupplierDistributionListDAL.GetPaymentToSupplierDistributionList();
        return dtb;
    }
    public DataTable GetPaymentToSupplierDistributionListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToSupplierDistributionListDAL.GetPaymentToSupplierDistributionListForExportToExcel();
        return dtb;
    }
    public DataTable GetPaymentToSupplierDistributionListById(PaymentToSupplierDistributionListUI PaymentToSupplierDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToSupplierDistributionListDAL.GetPaymentToSupplierDistributionListById(PaymentToSupplierDistributionListUI);
        return dtb;
    }

    public DataTable GetPaymentToSupplierDistributionListBySearchParameters(PaymentToSupplierDistributionListUI PaymentToSupplierDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToSupplierDistributionListDAL.GetPaymentToSupplierDistributionListBySearchParameters(PaymentToSupplierDistributionListUI);
        return dtb;
    }

    public int DeletePaymentToSupplierDistribution(PaymentToSupplierDistributionListUI PaymentToSupplierDistributionListUI)
    {
        int result = 0;
        result = PaymentToSupplierDistributionListDAL.DeletePaymentToSupplierDistribution(PaymentToSupplierDistributionListUI);
        return result;
    }

}