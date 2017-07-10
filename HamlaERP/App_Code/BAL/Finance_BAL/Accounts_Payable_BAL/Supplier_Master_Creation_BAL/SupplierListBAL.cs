using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for SupplierListBLL
/// </summary>
public class SupplierListBAL
{
    SupplierListDAL supplierListDAL = new SupplierListDAL();

    public SupplierListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSupplierList()
    {
        DataTable dtb = new DataTable();
        dtb = supplierListDAL.GetSupplierList();
        return dtb;
    }

    public DataTable GetSupplierListById(SupplierListUI supplierListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierListDAL.GetSupplierListById(supplierListUI);
        return dtb;
    }

    public DataTable GetSupplierListBySearchParameters(SupplierListUI supplierListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierListDAL.GetSupplierListBySearchParameters(supplierListUI);
        return dtb;
    }

    public DataTable GetSupplierListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = supplierListDAL.GetSupplierListForExportToExcel();
        return dtb;
    }


    public int DeleteSupplier(SupplierListUI supplierListUI)
    {
        int result = 0;
        result = supplierListDAL.DeleteSupplier(supplierListUI);
        return result;
    }
}