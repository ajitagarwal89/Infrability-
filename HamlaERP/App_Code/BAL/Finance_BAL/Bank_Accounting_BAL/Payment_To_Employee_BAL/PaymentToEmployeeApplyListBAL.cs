using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentToEmployeeApplyListBAL
/// </summary>
public class PaymentToEmployeeApplyListBAL
{
    PaymentToEmployeeApplyListDAL PaymentToEmployeeApplyListDAL = new PaymentToEmployeeApplyListDAL();
    public PaymentToEmployeeApplyListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentToEmployeeApplyList()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeApplyListDAL.GetPaymentToEmployeeApplyList();
        return dtb;
    }
    public DataTable GetPaymentToEmployeeApplyListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeApplyListDAL.GetPaymentToEmployeeApplyListForExportToExcel();
        return dtb;
    }
    public DataTable GetPaymentToEmployeeApplyListById(PaymentToEmployeeApplyListUI PaymentToEmployeeApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeApplyListDAL.GetPaymentToEmployeeApplyListById(PaymentToEmployeeApplyListUI);
        return dtb;
    }

    public DataTable GetPaymentToEmployeeApplyListBySearchParameters(PaymentToEmployeeApplyListUI PaymentToEmployeeApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeApplyListDAL.GetPaymentToEmployeeApplyListBySearchParameters(PaymentToEmployeeApplyListUI);
        return dtb;
    }

    public DataTable GetPaymentToEmployeeApplyListByPaymentToEmployeeId(PaymentToEmployeeApplyListUI paymentToEmployeeApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeApplyListDAL.GetPaymentToEmployeeApplyListByPaymentToEmployeeId(paymentToEmployeeApplyListUI);
        return dtb;
    }

    public int DeletePaymentToEmployeeApply(PaymentToEmployeeApplyListUI PaymentToEmployeeApplyListUI)
    {
        int result = 0;
        result = PaymentToEmployeeApplyListDAL.DeletePaymentToEmployeeApply(PaymentToEmployeeApplyListUI);
        return result;
    }
}