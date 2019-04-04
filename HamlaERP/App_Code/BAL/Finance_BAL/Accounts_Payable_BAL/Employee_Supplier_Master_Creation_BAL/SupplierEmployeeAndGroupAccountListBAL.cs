using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SupplierEmployeeAndGroupAccountListBAL
/// </summary>
public class SupplierEmployeeAndGroupAccountListBAL
{
    SupplierEmployeeAndGroupAccountListDAL supplierEmployeeAndGroupAccountListDAL = new SupplierEmployeeAndGroupAccountListDAL();
    public SupplierEmployeeAndGroupAccountListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSupplierEmployeeAndGroupAccountList()
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeAndGroupAccountListDAL.GetSupplierEmployeeAndGroupAccountList();
        return dtb;
    }

    public DataTable GetSupplierEmployeeAndGroupAccountListById(SupplierEmployeeAndGroupAccountListUI supplierEmployeeAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeAndGroupAccountListDAL.GetSupplierEmployeeAndGroupAccountListById(supplierEmployeeAndGroupAccountListUI);
        return dtb;
    }

    public DataTable GetSupplierEmployeeAndGroupAccountListBySearchParameters(SupplierEmployeeAndGroupAccountListUI supplierEmployeeAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeAndGroupAccountListDAL.GetSupplierEmployeeAndGroupAccountListBySearchParameters(supplierEmployeeAndGroupAccountListUI);
        return dtb;
    }

    public int DeleteSupplierEmployeeAndGroupAccount(SupplierEmployeeAndGroupAccountListUI supplierEmployeeAndGroupAccountListUI)
    {
        int result = 0;
        result = supplierEmployeeAndGroupAccountListDAL.DeleteSupplierEmployeeAndGroupAccount(supplierEmployeeAndGroupAccountListUI);
        return result;
    }
}