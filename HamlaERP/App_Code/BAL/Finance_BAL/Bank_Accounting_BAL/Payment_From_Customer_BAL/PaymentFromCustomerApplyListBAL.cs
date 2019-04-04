using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DownPaymentFromCustomerApplyListBAL
/// </summary>
public class PaymentFromCustomerApplyListBAL
{
    PaymentFromCustomerApplyListDAL PaymentFromCustomerApplyListDAL = new PaymentFromCustomerApplyListDAL();
    public PaymentFromCustomerApplyListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentFromCustomerApplyList()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerApplyListDAL.GetPaymentFromCustomerApplyList();
        return dtb;
    }
    public DataTable GetPaymentFromCustomerApplyListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerApplyListDAL.GetPaymentFromCustomerApplyListForExportToExcel();
        return dtb;
    }
    public DataTable GetPaymentFromCustomerApplyListById(PaymentFromCustomerApplyListUI PaymentFromCustomerApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerApplyListDAL.GetPaymentFromCustomerApplyListById(PaymentFromCustomerApplyListUI);
        return dtb;
    }

    public DataTable GetPaymentFromCustomerApplyListBySearchParameters(PaymentFromCustomerApplyListUI PaymentFromCustomerApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerApplyListDAL.GetPaymentFromCustomerApplyListBySearchParameters(PaymentFromCustomerApplyListUI);
        return dtb;
    }

    public int DeletePaymentFromCustomerApply(PaymentFromCustomerApplyListUI PaymentFromCustomerApplyListUI)
    {
        int result = 0;
        result = PaymentFromCustomerApplyListDAL.DeletePaymentFromCustomerApply(PaymentFromCustomerApplyListUI);
        return result;
    }
    public DataTable GetPaymentFromCustomerApplyListByPaymentFromCustomerId(PaymentFromCustomerApplyListUI paymentFromCustomerApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentFromCustomerApplyListDAL.GetPaymentFromCustomerApplyListByPaymentFromCustomerId(paymentFromCustomerApplyListUI);
        return dtb;
    }
}