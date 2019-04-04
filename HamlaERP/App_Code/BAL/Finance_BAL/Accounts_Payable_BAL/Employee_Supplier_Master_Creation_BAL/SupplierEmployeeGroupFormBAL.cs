using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for SupplierEmployeeGroupFormBAL
/// </summary>
public class SupplierEmployeeGroupFormBAL
{
    SupplierEmployeeGroupFormDAL supplierEmployeeGroupFormDAL = new SupplierEmployeeGroupFormDAL();
    public SupplierEmployeeGroupFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSupplierEmployeeGroupListById(SupplierEmployeeGroupFormUI supplierEmployeeGroupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeGroupFormDAL.GetSupplierEmployeeGroupListById(supplierEmployeeGroupFormUI);
        return dtb;
    }

    public int AddSupplierEmployeeGroup(SupplierEmployeeGroupFormUI supplierEmployeeGroupFormUI)
    {
        int resutl = 0;
        resutl = supplierEmployeeGroupFormDAL.AddSupplierEmployeeGroup(supplierEmployeeGroupFormUI);
        return resutl;
    }

    public int UpdateSupplierEmployeeGroup(SupplierEmployeeGroupFormUI supplierEmployeeGroupFormUI)
    {
        int resutl = 0;
        resutl = supplierEmployeeGroupFormDAL.UpdateSupplierEmployeeGroup(supplierEmployeeGroupFormUI);
        return resutl;
    }

    public int DeleteSupplierEmployeeGroup(SupplierEmployeeGroupFormUI supplierEmployeeGroupFormUI)
    {
        int resutl = 0;
        resutl = supplierEmployeeGroupFormDAL.DeleteSupplierEmployeeGroup(supplierEmployeeGroupFormUI);
        return resutl;
    }
}