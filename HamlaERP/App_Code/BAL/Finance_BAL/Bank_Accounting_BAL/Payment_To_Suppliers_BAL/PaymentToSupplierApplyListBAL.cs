using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentToSupplierApplyListBAL
/// </summary>
public class PaymentToSupplierApplyListBAL
{
    PaymentToSupplierApplyListDAL PaymentToSupplierApplyListDAL = new PaymentToSupplierApplyListDAL();
    public PaymentToSupplierApplyListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentToSupplierApplyList()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToSupplierApplyListDAL.GetPaymentToSupplierApplyList();
        return dtb;
    }
    public DataTable GetPaymentToSupplierApplyListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToSupplierApplyListDAL.GetPaymentToSupplierApplyListForExportToExcel();
        return dtb;
    }
    public DataTable GetPaymentToSupplierApplyListById(PaymentToSupplierApplyListUI PaymentToSupplierApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToSupplierApplyListDAL.GetPaymentToSupplierApplyListById(PaymentToSupplierApplyListUI);
        return dtb;
    }

    public DataTable GetPaymentToSupplierApplyListBySearchParameters(PaymentToSupplierApplyListUI PaymentToSupplierApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToSupplierApplyListDAL.GetPaymentToSupplierApplyListBySearchParameters(PaymentToSupplierApplyListUI);
        return dtb;
    }

    public DataTable GetPaymentToSupplierApplyListByPaymentToSupplierId(PaymentToSupplierApplyListUI paymentToSupplierApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToSupplierApplyListDAL.GetPaymentToSupplierApplyListByPaymentToSupplierId(paymentToSupplierApplyListUI);
        return dtb;
    }

    public int DeletePaymentToSupplierApply(PaymentToSupplierApplyListUI PaymentToSupplierApplyListUI)
    {
        int result = 0;
        result = PaymentToSupplierApplyListDAL.DeletePaymentToSupplierApply(PaymentToSupplierApplyListUI);
        return result;
    }

}