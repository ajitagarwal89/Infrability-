using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for SupplierAndGroupAccountFormBLL
/// </summary>
public class SupplierAndGroupAccountFormBAL
{
    SupplierAndGroupAccountFormDAL supplierAndGroupAccountFormDAL = new SupplierAndGroupAccountFormDAL();

	public SupplierAndGroupAccountFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSupplierAndGroupAccountListById(SupplierAndGroupAccountFormUI supplierAndGroupAccountFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierAndGroupAccountFormDAL.GetSupplierAndGroupAccountListById(supplierAndGroupAccountFormUI);
        return dtb;
    }

    public int AddSupplierAndGroupAccount(SupplierAndGroupAccountFormUI supplierAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = supplierAndGroupAccountFormDAL.AddSupplierAndGroupAccount(supplierAndGroupAccountFormUI);
        return resutl;
    }

    public int UpdateSupplierAndGroupAccount(SupplierAndGroupAccountFormUI supplierAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = supplierAndGroupAccountFormDAL.UpdateSupplierAndGroupAccount(supplierAndGroupAccountFormUI);
        return resutl;
    }

    public int DeleteSupplierAndGroupAccount(SupplierAndGroupAccountFormUI supplierAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = supplierAndGroupAccountFormDAL.DeleteSupplierAndGroupAccount(supplierAndGroupAccountFormUI);
        return resutl;
    }
}