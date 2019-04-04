using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for PaymentToEmployeeListBAL
/// </summary>
public class PaymentToEmployeeListBAL
{
    PaymentToEmployeeListDAL PaymentToEmployeeListDAL = new PaymentToEmployeeListDAL();
    public PaymentToEmployeeListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPaymentToEmployeeList()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeListDAL.GetPaymentToEmployeeList();
        return dtb;
    }
    public DataTable GetPaymentToEmployeeListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeListDAL.GetPaymentToEmployeeListForExportToExcel();
        return dtb;
    }
    public DataTable GetPaymentToEmployeeListById(PaymentToEmployeeListUI PaymentToEmployeeListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeListDAL.GetPaymentToEmployeeListById(PaymentToEmployeeListUI);
        return dtb;
    }

    public DataTable GetPaymentToEmployeeListBySearchParameters(PaymentToEmployeeListUI PaymentToEmployeeListUI)
    {
        DataTable dtb = new DataTable();
        dtb = PaymentToEmployeeListDAL.GetPaymentToEmployeeListBySearchParameters(PaymentToEmployeeListUI);
        return dtb;
    }

    public int DeletePaymentToEmployee(PaymentToEmployeeListUI PaymentToEmployeeListUI)
    {
        int result = 0;
        result = PaymentToEmployeeListDAL.DeletePaymentToEmployee(PaymentToEmployeeListUI);
        return result;
    }

}