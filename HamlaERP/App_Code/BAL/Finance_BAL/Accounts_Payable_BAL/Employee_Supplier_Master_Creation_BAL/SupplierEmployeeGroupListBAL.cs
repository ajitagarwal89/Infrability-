using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for SupplierEmployeeGroupListBAL
/// </summary>
public class SupplierEmployeeGroupListBAL
{
    SupplierEmployeeGroupListDAL supplierEmployeeGroupListDAL = new SupplierEmployeeGroupListDAL();

    public SupplierEmployeeGroupListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSupplierEmployeeGroupList()
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeGroupListDAL.GetSupplierEmployeeGroupList();
        return dtb;
    }

    public DataTable GetSupplierEmployeeGroupListById(SupplierEmployeeGroupListUI supplierEmployeeGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeGroupListDAL.GetSupplierEmployeeGroupListById(supplierEmployeeGroupListUI);
        return dtb;
    }

    public DataTable GetSupplierEmployeeGroupListBySearchParameters(SupplierEmployeeGroupListUI supplierEmployeeGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeGroupListDAL.GetSupplierEmployeeGroupListBySearchParameters(supplierEmployeeGroupListUI);
        return dtb;
    }

    public int DeleteSupplierEmployeeGroup(SupplierEmployeeGroupListUI supplierEmployeeGroupListUI)
    {
        int result = 0;
        result = supplierEmployeeGroupListDAL.DeleteSupplierEmployeeGroup(supplierEmployeeGroupListUI);
        return result;
    }
    public DataTable GetSupplierEmployeeGroupListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeGroupListDAL.GetSupplierEmployeeGroupListForExportToExcel();
        return dtb;
    }
}