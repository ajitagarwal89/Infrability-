using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DownPaymentToSupplierApplyListBAL
/// </summary>
public class DownPaymentToSupplierApplyListBAL
{
    DownPaymentToSupplierApplyListDAL downPaymentToSupplierApplyListDAL = new DownPaymentToSupplierApplyListDAL();
    public DownPaymentToSupplierApplyListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetDownPaymentToSupplierApplyList()
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierApplyListDAL.GetDownPaymentToSupplierApplyList();
        return dtb;
    }
    public DataTable GetDownPaymentToSupplierApplyListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierApplyListDAL.GetDownPaymentToSupplierApplyListForExportToExcel();
        return dtb;
    }
    public DataTable GetDownPaymentToSupplierApplyListById(DownPaymentToSupplierApplyListUI downPaymentToSupplierApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierApplyListDAL.GetDownPaymentToSupplierApplyListById(downPaymentToSupplierApplyListUI);
        return dtb;
    }

    public DataTable GetDownPaymentToSupplierApplyListBySearchParameters(DownPaymentToSupplierApplyListUI downPaymentToSupplierApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierApplyListDAL.GetDownPaymentToSupplierApplyListBySearchParameters(downPaymentToSupplierApplyListUI);
        return dtb;
    }

    public DataTable GetDownPaymentToSupplierApplyListByDownPaymentToSupplierId(DownPaymentToSupplierApplyListUI downPaymentToSupplierApplyListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierApplyListDAL.GetDownPaymentToSupplierApplyListByDownPaymentToSupplierId(downPaymentToSupplierApplyListUI);
        return dtb;
    }
    public int DeleteDownPaymentToSupplierApply(DownPaymentToSupplierApplyListUI downPaymentToSupplierApplyListUI)
    {
        int result = 0;
        result = downPaymentToSupplierApplyListDAL.DeleteDownPaymentToSupplierApply(downPaymentToSupplierApplyListUI);
        return result;
    }

}