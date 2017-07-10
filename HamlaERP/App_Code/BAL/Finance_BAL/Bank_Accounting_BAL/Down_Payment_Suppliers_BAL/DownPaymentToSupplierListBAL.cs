using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DownPaymentToSupplierListBAL
/// </summary>
public class DownPaymentToSupplierListBAL
{
    DownPaymentToSupplierListDAL downPaymentToSupplierListDAL = new DownPaymentToSupplierListDAL();
    public DownPaymentToSupplierListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetDownPaymentToSupplierList()
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierListDAL.GetDownPaymentToSupplierList();
        return dtb;
    }
    public DataTable GetDownPaymentToSupplierListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierListDAL.GetDownPaymentToSupplierListForExportToExcel();
        return dtb;
    }
    public DataTable GetDownPaymentToSupplierListById(DownPaymentToSupplierListUI downPaymentToSupplierListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierListDAL.GetDownPaymentToSupplierListById(downPaymentToSupplierListUI);
        return dtb;
    }

    public DataTable GetDownPaymentToSupplierListBySearchParameters(DownPaymentToSupplierListUI downPaymentToSupplierListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierListDAL.GetDownPaymentToSupplierListBySearchParameters(downPaymentToSupplierListUI);
        return dtb;
    }

    public int DeleteDownPaymentToSupplier(DownPaymentToSupplierListUI downPaymentToSupplierListUI)
    {
        int result = 0;
        result = downPaymentToSupplierListDAL.DeleteDownPaymentToSupplier(downPaymentToSupplierListUI);
        return result;
    }

}