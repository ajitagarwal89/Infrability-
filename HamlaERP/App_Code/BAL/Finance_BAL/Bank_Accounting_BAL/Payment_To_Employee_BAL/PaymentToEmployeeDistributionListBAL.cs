using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentToEmployeeDistributionListBAL
/// </summary>
public class PaymentToEmployeeDistributionListBAL
{
    PaymentToEmployeeDistributionListDAL PaymentToEmployeeDistributionListDAL = new PaymentToEmployeeDistributionListDAL();
    public PaymentToEmployeeDistributionListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentToEmployeeDistributionList()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeDistributionListDAL.GetPaymentToEmployeeDistributionList();
        return dtb;
    }
    public DataTable GetPaymentToEmployeeDistributionListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeDistributionListDAL.GetPaymentToEmployeeDistributionListForExportToExcel();
        return dtb;
    }
    public DataTable GetPaymentToEmployeeDistributionListById(PaymentToEmployeeDistributionListUI PaymentToEmployeeDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeDistributionListDAL.GetPaymentToEmployeeDistributionListById(PaymentToEmployeeDistributionListUI);
        return dtb;
    }

    public DataTable GetPaymentToEmployeeDistributionListBySearchParameters(PaymentToEmployeeDistributionListUI PaymentToEmployeeDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeDistributionListDAL.GetPaymentToEmployeeDistributionListBySearchParameters(PaymentToEmployeeDistributionListUI);
        return dtb;
    }

    public int DeletePaymentToEmployeeDistribution(PaymentToEmployeeDistributionListUI PaymentToEmployeeDistributionListUI)
    {
        int result = 0;
        result = PaymentToEmployeeDistributionListDAL.DeletePaymentToEmployeeDistribution(PaymentToEmployeeDistributionListUI);
        return result;
    }

}