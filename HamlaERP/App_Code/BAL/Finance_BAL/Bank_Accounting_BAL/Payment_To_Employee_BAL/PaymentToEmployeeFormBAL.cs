using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentToEmployeeFormBAL
/// </summary>
public class PaymentToEmployeeFormBAL
{
    PaymentToEmployeeFormDAL PaymentToEmployeeFormDAL = new PaymentToEmployeeFormDAL();
    public PaymentToEmployeeFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPaymentToEmployeeListById(PaymentToEmployeeFormUI PaymentToEmployeeFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeFormDAL.GetPaymentToEmployeeListById(PaymentToEmployeeFormUI);
        return dtb;
    }

    public int AddPaymentToEmployee(PaymentToEmployeeFormUI PaymentToEmployeeFormUI)
    {
        int resutl = 0;
        resutl = PaymentToEmployeeFormDAL.AddPaymentToEmployee(PaymentToEmployeeFormUI);
        return resutl;
    }
    public int UpdatePaymentToEmployee(PaymentToEmployeeFormUI PaymentToEmployeeFormUI)
    {
        int resutl = 0;
        resutl = PaymentToEmployeeFormDAL.UpdatePaymentToEmployee(PaymentToEmployeeFormUI);
        return resutl;
    }

    public int DeletePaymentToEmployee(PaymentToEmployeeFormUI PaymentToEmployeeFormUI)
    {
        int resutl = 0;
        resutl = PaymentToEmployeeFormDAL.DeletePaymentToEmployee(PaymentToEmployeeFormUI);
        return resutl;
    }

    public int UpdatePostingPaymentToEmployee(PaymentToEmployeeFormUI PaymentToEmployeeFormUI)
    {
        int resutl = 0;
        resutl = PaymentToEmployeeFormDAL.UpdatePostingPaymentToEmployee(PaymentToEmployeeFormUI);
        return resutl;
    }
    public DataTable GetSerialNumber(PaymentToEmployeeFormUI PaymentToEmployeeFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeFormDAL.GetSerialNumber(PaymentToEmployeeFormUI);
        return dtb;
    }

}