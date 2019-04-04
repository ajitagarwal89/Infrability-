using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplierEmployeeGeneralExpensesFormBAL
/// </summary>
public class SupplierEmployeeGeneralExpensesFormBAL
{
    SupplierEmployeeGeneralExpensesFormDAL supplierEmployeeGeneralExpensesFormDAL = new SupplierEmployeeGeneralExpensesFormDAL();
    SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI = new SupplierEmployeeGeneralExpensesFormUI();
    public SupplierEmployeeGeneralExpensesFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetSupplierEmployeeGeneralExpensesListById(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeGeneralExpensesFormDAL.GetSupplierEmployeeGeneralExpensesListById(supplierEmployeeGeneralExpensesFormUI);
        return dtb;
    }
    public int AddSupplierEmployeeGeneralExpenses(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {
        int resutl = 0;
        resutl = supplierEmployeeGeneralExpensesFormDAL.AddSupplierEmployeeGeneralExpenses(supplierEmployeeGeneralExpensesFormUI);
        return resutl;
    }

    public int UpdateSupplierEmployeeGeneralExpenses(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {
        int resutl = 0;
        resutl = supplierEmployeeGeneralExpensesFormDAL.UpdateSupplierEmployeeGeneralExpenses(supplierEmployeeGeneralExpensesFormUI);
        return resutl;
    }

    public int DeleteSupplierEmployeeGeneralExpenses(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {
        int resutl = 0;
        resutl = supplierEmployeeGeneralExpensesFormDAL.DeleteSupplierEmployeeGeneralExpenses(supplierEmployeeGeneralExpensesFormUI);
        return resutl;
    }

    public int UpdatePostingSupplierEmployeeGeneralExpenses(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {
        int resutl = 0;
        resutl = supplierEmployeeGeneralExpensesFormDAL.UpdatePostingSupplierEmployeeGeneralExpenses(supplierEmployeeGeneralExpensesFormUI);
        return resutl;
    }
    public DataTable GetSerialNumber(SupplierEmployeeGeneralExpensesFormUI supplierEmployeeGeneralExpensesFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeGeneralExpensesFormDAL.GetSerialNumber(supplierEmployeeGeneralExpensesFormUI);
        return dtb;
    }
}