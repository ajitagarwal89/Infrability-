using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PaymentTermsListBLL
/// </summary>
public class PaymentTermsListBAL
{
    PaymentTermsListDAL paymentTermsListDAL = new PaymentTermsListDAL();

    public PaymentTermsListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPaymentTermsList()
    {
        DataTable dtb = new DataTable();
        dtb = paymentTermsListDAL.GetPaymentTermsList();
        return dtb;
    }
    public DataTable GetPaymentTermsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = paymentTermsListDAL.GetPaymentTermsListForExportToExcel();
        return dtb;
    }
    public DataTable GetPaymentTermsListById(PaymentTermsListUI paymentTermsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentTermsListDAL.GetPaymentTermsListById(paymentTermsListUI);
        return dtb;
    }

    public DataTable GetPaymentTermsListBySearchParameters(PaymentTermsListUI paymentTermsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = paymentTermsListDAL.GetPaymentTermsListBySearchParameters(paymentTermsListUI);
        return dtb;
    }

    public int DeletePaymentTerms(PaymentTermsListUI paymentTermsListUI)
    {
        int result = 0;
        result = paymentTermsListDAL.DeletePaymentTerms(paymentTermsListUI);
        return result;
    }
}