using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for SupplierGroupListBLL
/// </summary>
public class SupplierGroupListBAL
{
    SupplierGroupListDAL supplierGroupListDAL = new SupplierGroupListDAL();

	public SupplierGroupListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetSupplierGroupList()
    {
        DataTable dtb = new DataTable();
        dtb = supplierGroupListDAL.GetSupplierGroupList();
        return dtb;
    }

    public DataTable GetSupplierGroupListById(SupplierGroupListUI supplierGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierGroupListDAL.GetSupplierGroupListById(supplierGroupListUI);
        return dtb;
    }

    public DataTable GetSupplierGroupListBySearchParameters(SupplierGroupListUI supplierGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierGroupListDAL.GetSupplierGroupListBySearchParameters(supplierGroupListUI);
        return dtb;
    }

    public int DeleteSupplierGroup(SupplierGroupListUI supplierGroupListUI)
    {
        int result = 0;
        result = supplierGroupListDAL.DeleteSupplierGroup(supplierGroupListUI);
        return result;
    }

    public DataTable GetSupplierGroupListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = supplierGroupListDAL.GetSupplierGroupListForExportToExcel();
        return dtb;
    }

}