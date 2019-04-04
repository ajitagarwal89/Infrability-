using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for SupplierGroupFormBLL
/// </summary>
public class SupplierGroupFormBAL
{
    SupplierGroupFormDAL supplierGroupFormDAL = new SupplierGroupFormDAL();

	public SupplierGroupFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSupplierGroupListById(SupplierGroupFormUI supplierGroupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierGroupFormDAL.GetSupplierGroupListById(supplierGroupFormUI);
        return dtb;
    }

    public int AddSupplierGroup(SupplierGroupFormUI supplierGroupFormUI)
    {
        int resutl = 0;
        resutl = supplierGroupFormDAL.AddSupplierGroup(supplierGroupFormUI);
        return resutl;
    }

    public int UpdateSupplierGroup(SupplierGroupFormUI supplierGroupFormUI)
    {
        int resutl = 0;
        resutl = supplierGroupFormDAL.UpdateSupplierGroup(supplierGroupFormUI);
        return resutl;
    }

    public int DeleteSupplierGroup(SupplierGroupFormUI supplierGroupFormUI)
    {
        int resutl = 0;
        resutl = supplierGroupFormDAL.DeleteSupplierGroup(supplierGroupFormUI);
        return resutl;
    }
}