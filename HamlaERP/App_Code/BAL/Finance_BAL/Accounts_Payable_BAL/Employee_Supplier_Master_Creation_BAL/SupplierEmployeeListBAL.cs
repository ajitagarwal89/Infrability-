using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SupplierEmployeeListBAL
/// </summary>
public class SupplierEmployeeListBAL
{
    SupplierEmployeeListDAL supplierEmployeeListDAL = new SupplierEmployeeListDAL();
    public SupplierEmployeeListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSupplierEmployeeList()
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeListDAL.GetSupplierEmployeeList();
        return dtb;
    }

    public DataTable GetSupplierEmployeeListById(SupplierEmployeeListUI supplierEmployeeListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeListDAL.GetSupplierEmployeeListById(supplierEmployeeListUI);
        return dtb;
    }

    public DataTable GetSupplierEmployeeListBySearchParameters(SupplierEmployeeListUI supplierEmployeeListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeListDAL.GetSupplierEmployeeListBySearchParameters(supplierEmployeeListUI);
        return dtb;
    }

    public DataTable GetSupplierEmployeeListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeListDAL.GetSupplierEmployeeListForExportToExcel();
        return dtb;
    }

    public int DeleteSupplierEmployee(SupplierEmployeeListUI supplierEmployeeListUI)
    {
        int result = 0;
        result = supplierEmployeeListDAL.DeleteSupplierEmployee(supplierEmployeeListUI);
        return result;
    }
}