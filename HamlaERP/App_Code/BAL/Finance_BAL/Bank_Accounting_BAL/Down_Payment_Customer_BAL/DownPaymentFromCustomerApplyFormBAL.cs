using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DownPaymentFromCustomerApplyFormBAL
/// </summary>
public class DownPaymentFromCustomerApplyFormBAL
{
    DownPaymentFromCustomerApplyFormDAL downPaymentFromCustomerApplyFormDAL = new DownPaymentFromCustomerApplyFormDAL();
    public DownPaymentFromCustomerApplyFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetDownPaymentFromCustomerApplyListById(DownPaymentFromCustomerApplyFormUI downPaymentFromCustomerApplyFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerApplyFormDAL.GetDownPaymentFromCustomerApplyListById(downPaymentFromCustomerApplyFormUI);
        return dtb;
    }

    public int AddDownPaymentFromCustomerApply(DownPaymentFromCustomerApplyFormUI downPaymentFromCustomerApplyFormUI)
    {
        int resutl = 0;
        resutl = downPaymentFromCustomerApplyFormDAL.AddDownPaymentFromCustomerApply(downPaymentFromCustomerApplyFormUI);
        return resutl;
    }
    public int UpdateDownPaymentFromCustomerApply(DownPaymentFromCustomerApplyFormUI downPaymentFromCustomerApplyFormUI)
    {
        int resutl = 0;
        resutl = downPaymentFromCustomerApplyFormDAL.UpdateDownPaymentFromCustomerApply(downPaymentFromCustomerApplyFormUI);
        return resutl;
    }

    public int DeleteDownPaymentFromCustomerApply(DownPaymentFromCustomerApplyFormUI downPaymentFromCustomerApplyFormUI)
    {
        int resutl = 0;
        resutl = downPaymentFromCustomerApplyFormDAL.DeleteDownPaymentFromCustomerApply(downPaymentFromCustomerApplyFormUI);
        return resutl;
    }
}