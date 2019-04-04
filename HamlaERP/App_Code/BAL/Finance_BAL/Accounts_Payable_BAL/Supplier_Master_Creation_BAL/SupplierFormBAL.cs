using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SupplierFormBLL
/// </summary>
public class SupplierFormBAL
{
    SupplierFormDAL supplierFormDAL = new SupplierFormDAL();

	public SupplierFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSupplierListById(SupplierFormUI supplierFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierFormDAL.GetSupplierListById(supplierFormUI);
        return dtb;
    }

    public int AddSupplier(SupplierFormUI supplierFormUI)
    {
        int resutl = 0;
        resutl = supplierFormDAL.AddSupplier(supplierFormUI);
        return resutl;
    }

    public int UpdateSupplier(SupplierFormUI supplierFormUI)
    {
        int resutl = 0;
        resutl = supplierFormDAL.UpdateSupplier(supplierFormUI);
        return resutl;
    }

    public int DeleteSupplier(SupplierFormUI supplierFormUI)
    {
        int resutl = 0;
        resutl = supplierFormDAL.DeleteSupplier(supplierFormUI);
        return resutl;
    }
    public DataTable GetSerialNumber()
    {
        DataTable dtb = new DataTable();
        dtb = supplierFormDAL.GetSerialNumber();
        return dtb;
    }
}