using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SupplierAndGroupAccountListBLL
/// </summary>
public class SupplierAndGroupAccountListBAL
{
    SupplierAndGroupAccountListDAL supplierAndGroupAccountListDAL = new SupplierAndGroupAccountListDAL();

    public SupplierAndGroupAccountListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSupplierAndGroupAccountList()
    {
        DataTable dtb = new DataTable();
        dtb = supplierAndGroupAccountListDAL.GetSupplierAndGroupAccountList();
        return dtb;
    }

    public DataTable GetSupplierAndGroupAccountListById(SupplierAndGroupAccountListUI supplierAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierAndGroupAccountListDAL.GetSupplierAndGroupAccountListById(supplierAndGroupAccountListUI);
        return dtb;
    }

    public DataTable GetSupplierAndGroupAccountListBySearchParameters(SupplierAndGroupAccountListUI supplierAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierAndGroupAccountListDAL.GetSupplierAndGroupAccountListBySearchParameters(supplierAndGroupAccountListUI);
        return dtb;
    }

    public DataTable GetSupplierAndGroupAccountListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = supplierAndGroupAccountListDAL.GetSupplierAndGroupAccountListForExportToExcel();
        return dtb;
    }

    public int DeleteSupplierAndGroupAccount(SupplierAndGroupAccountListUI supplierAndGroupAccountListUI)
    {
        int result = 0;
        result = supplierAndGroupAccountListDAL.DeleteSupplierAndGroupAccount(supplierAndGroupAccountListUI);
        return result;
    }
}