using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentToEmployeeApplyFormBAL
/// </summary>
public class PaymentToEmployeeApplyFormBAL
{
    PaymentToEmployeeApplyFormDAL PaymentToEmployeeApplyFormDAL = new PaymentToEmployeeApplyFormDAL();
    public PaymentToEmployeeApplyFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPaymentToEmployeeApplyListById(PaymentToEmployeeApplyFormUI PaymentToEmployeeApplyFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeApplyFormDAL.GetPaymentToEmployeeApplyListById(PaymentToEmployeeApplyFormUI);
        return dtb;
    }

    public int AddPaymentToEmployeeApply(PaymentToEmployeeApplyFormUI PaymentToEmployeeApplyFormUI)
    {
        int resutl = 0;
        resutl = PaymentToEmployeeApplyFormDAL.AddPaymentToEmployeeApply(PaymentToEmployeeApplyFormUI);
        return resutl;
    }
    public int UpdatePaymentToEmployeeApply(PaymentToEmployeeApplyFormUI PaymentToEmployeeApplyFormUI)
    {
        int resutl = 0;
        resutl = PaymentToEmployeeApplyFormDAL.UpdatePaymentToEmployeeApply(PaymentToEmployeeApplyFormUI);
        return resutl;
    }

    public int DeletePaymentToEmployeeApply(PaymentToEmployeeApplyFormUI PaymentToEmployeeApplyFormUI)
    {
        int resutl = 0;
        resutl = PaymentToEmployeeApplyFormDAL.DeletePaymentToEmployeeApply(PaymentToEmployeeApplyFormUI);
        return resutl;
    }

}