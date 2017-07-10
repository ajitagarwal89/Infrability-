using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DownPaymentToSupplierFormBAL
/// </summary>
public class DownPaymentToSupplierFormBAL
{
    DownPaymentToSupplierFormDAL downPaymentToSupplierFormDAL = new DownPaymentToSupplierFormDAL();
    public DownPaymentToSupplierFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetDownPaymentToSupplierListById(DownPaymentToSupplierFormUI downPaymentToSupplierFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierFormDAL.GetDownPaymentToSupplierListById(downPaymentToSupplierFormUI);
        return dtb;
    }

    public int AddDownPaymentToSupplier(DownPaymentToSupplierFormUI downPaymentToSupplierFormUI)
    {
        int resutl = 0;
        resutl = downPaymentToSupplierFormDAL.AddDownPaymentToSupplier(downPaymentToSupplierFormUI);
        return resutl;
    }
    public int UpdateDownPaymentToSupplier(DownPaymentToSupplierFormUI downPaymentToSupplierFormUI)
    {
        int resutl = 0;
        resutl = downPaymentToSupplierFormDAL.UpdateDownPaymentToSupplier(downPaymentToSupplierFormUI);
        return resutl;
    }

    public int DeleteDownPaymentToSupplier(DownPaymentToSupplierFormUI downPaymentToSupplierFormUI)
    {
        int resutl = 0;
        resutl = downPaymentToSupplierFormDAL.DeleteDownPaymentToSupplier(downPaymentToSupplierFormUI);
        return resutl;
    }
}