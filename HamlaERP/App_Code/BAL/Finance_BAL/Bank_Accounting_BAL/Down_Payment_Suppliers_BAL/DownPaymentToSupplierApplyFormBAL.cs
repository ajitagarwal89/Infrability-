using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DownPaymentToSupplierApplyFormBAL
/// </summary>
public class DownPaymentToSupplierApplyFormBAL
{
    DownPaymentToSupplierApplyFormDAL downPaymentToSupplierApplyFormDAL = new DownPaymentToSupplierApplyFormDAL();
    public DownPaymentToSupplierApplyFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetDownPaymentToSupplierApplyListById(DownPaymentToSupplierApplyFormUI downPaymentToSupplierApplyFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierApplyFormDAL.GetDownPaymentToSupplierApplyListById(downPaymentToSupplierApplyFormUI);
        return dtb;
    }

    public int AddDownPaymentToSupplierApply(DownPaymentToSupplierApplyFormUI downPaymentToSupplierApplyFormUI)
    {
        int resutl = 0;
        resutl = downPaymentToSupplierApplyFormDAL.AddDownPaymentToSupplierApply(downPaymentToSupplierApplyFormUI);
        return resutl;
    }
    public int UpdateDownPaymentToSupplierApply(DownPaymentToSupplierApplyFormUI downPaymentToSupplierApplyFormUI)
    {
        int resutl = 0;
        resutl = downPaymentToSupplierApplyFormDAL.UpdateDownPaymentToSupplierApply(downPaymentToSupplierApplyFormUI);
        return resutl;
    }

    public int DeleteDownPaymentToSupplierApply(DownPaymentToSupplierApplyFormUI downPaymentToSupplierApplyFormUI)
    {
        int resutl = 0;
        resutl = downPaymentToSupplierApplyFormDAL.DeleteDownPaymentToSupplierApply(downPaymentToSupplierApplyFormUI);
        return resutl;
    }
}