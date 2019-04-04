using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SupplierEmployeeAndGroupAccountFormBAL
/// </summary>
public class SupplierEmployeeAndGroupAccountFormBAL
{
    SupplierEmployeeAndGroupAccountFormDAL supplierEmployeeAndGroupAccountFormDAL = new SupplierEmployeeAndGroupAccountFormDAL();
    public SupplierEmployeeAndGroupAccountFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSupplierEmployeeAndGroupAccountListById(SupplierEmployeeAndGroupAccountFormUI supplierEmployeeAndGroupAccountFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeAndGroupAccountFormDAL.GetSupplierEmployeeAndGroupAccountListById(supplierEmployeeAndGroupAccountFormUI);
        return dtb;
    }

    public int AddSupplierEmployeeAndGroupAccount(SupplierEmployeeAndGroupAccountFormUI supplierEmployeeAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = supplierEmployeeAndGroupAccountFormDAL.AddSupplierEmployeeAndGroupAccount(supplierEmployeeAndGroupAccountFormUI);
        return resutl;
    }

    public int UpdateSupplierEmployeeAndGroupAccount(SupplierEmployeeAndGroupAccountFormUI supplierEmployeeAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = supplierEmployeeAndGroupAccountFormDAL.UpdateSupplierEmployeeAndGroupAccount(supplierEmployeeAndGroupAccountFormUI);
        return resutl;
    }

    public int DeleteSupplierEmployeeAndGroupAccount(SupplierEmployeeAndGroupAccountFormUI supplierEmployeeAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = supplierEmployeeAndGroupAccountFormDAL.DeleteSupplierEmployeeAndGroupAccount(supplierEmployeeAndGroupAccountFormUI);
        return resutl;
    }
}