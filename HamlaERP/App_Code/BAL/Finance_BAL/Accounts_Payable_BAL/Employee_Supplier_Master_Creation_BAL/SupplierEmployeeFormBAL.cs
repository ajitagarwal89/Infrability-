using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for SupplierEmployeeFormBAL
/// </summary>
public class SupplierEmployeeFormBAL
{
    SupplierEmployeeFormDAL supplierEmployeeFormDAL = new SupplierEmployeeFormDAL();
    public SupplierEmployeeFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetSupplierEmployeeListById(SupplierEmployeeFormUI supplierEmployeeFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeFormDAL.GetSupplierEmployeeListById(supplierEmployeeFormUI);
        return dtb;
    }

    public int AddSupplierEmployee(SupplierEmployeeFormUI supplierEmployeeFormUI)
    {
        int resutl = 0;
        resutl = supplierEmployeeFormDAL.AddSupplierEmployee(supplierEmployeeFormUI);
        return resutl;
    }

    public int UpdateSupplierEmployee(SupplierEmployeeFormUI supplierEmployeeFormUI)
    {
        int resutl = 0;
        resutl = supplierEmployeeFormDAL.UpdateSupplierEmployee(supplierEmployeeFormUI);
        return resutl;
    }

    public int DeleteSupplierEmployee(SupplierEmployeeFormUI supplierEmployeeFormUI)
    {
        int resutl = 0;
        resutl = supplierEmployeeFormDAL.DeleteSupplierEmployee(supplierEmployeeFormUI);
        return resutl;
    }
    public DataTable GetSerialNumber()
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeFormDAL.GetSerialNumber();
        return dtb;
    }

}