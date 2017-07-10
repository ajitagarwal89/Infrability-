using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentToSupplierApplyFormBAL
/// </summary>
public class PaymentToSupplierApplyFormBAL
{
    PaymentToSupplierApplyFormDAL PaymentToSupplierApplyFormDAL = new PaymentToSupplierApplyFormDAL();
    public PaymentToSupplierApplyFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPaymentToSupplierApplyListById(PaymentToSupplierApplyFormUI PaymentToSupplierApplyFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToSupplierApplyFormDAL.GetPaymentToSupplierApplyListById(PaymentToSupplierApplyFormUI);
        return dtb;
    }

    public int AddPaymentToSupplierApply(PaymentToSupplierApplyFormUI PaymentToSupplierApplyFormUI)
    {
        int resutl = 0;
        resutl = PaymentToSupplierApplyFormDAL.AddPaymentToSupplierApply(PaymentToSupplierApplyFormUI);
        return resutl;
    }
    public int UpdatePaymentToSupplierApply(PaymentToSupplierApplyFormUI PaymentToSupplierApplyFormUI)
    {
        int resutl = 0;
        resutl = PaymentToSupplierApplyFormDAL.UpdatePaymentToSupplierApply(PaymentToSupplierApplyFormUI);
        return resutl;
    }

    public int DeletePaymentToSupplierApply(PaymentToSupplierApplyFormUI PaymentToSupplierApplyFormUI)
    {
        int resutl = 0;
        resutl = PaymentToSupplierApplyFormDAL.DeletePaymentToSupplierApply(PaymentToSupplierApplyFormUI);
        return resutl;
    }

}