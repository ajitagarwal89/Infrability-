using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplierEmployeeGeneralExpensesListBAL
/// </summary>
public class SupplierEmployeeGeneralExpensesListBAL
{
    SupplierEmployeeGeneralExpensesListDAL supplierEmployeeGeneralExpensesListDAL = new SupplierEmployeeGeneralExpensesListDAL();
    public SupplierEmployeeGeneralExpensesListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetSupplierEmployeeGeneralExpensesList()
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeGeneralExpensesListDAL.GetSupplierEmployeeGeneralExpensesList();
        return dtb;
    }

    public DataTable GetSupplierEmployeeGeneralExpensesListById(SupplierEmployeeGeneralExpensesListUI supplierEmployeeGeneralExpensesListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeGeneralExpensesListDAL.GetSupplierEmployeeGeneralExpensesListById(supplierEmployeeGeneralExpensesListUI);
        return dtb;
    }

    public DataTable GetSupplierEmployeeGeneralExpensesListBySearchParameters(SupplierEmployeeGeneralExpensesListUI supplierEmployeeGeneralExpensesListUI)
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeGeneralExpensesListDAL.GetSupplierEmployeeGeneralExpensesListBySearchParameters(supplierEmployeeGeneralExpensesListUI);
        return dtb;
    }

    public int DeleteEmployeeGeneralExpenses(SupplierEmployeeGeneralExpensesListUI supplierEmployeeGeneralExpensesListUI)
    {
        int result = 0;
        result = supplierEmployeeGeneralExpensesListDAL.DeleteSupplierEmployeeGeneralExpenses(supplierEmployeeGeneralExpensesListUI);
        return result;
    }

    public DataTable GetSupplierEmployeeGeneralExpensesForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = supplierEmployeeGeneralExpensesListDAL.GetSupplierEmployeeGeneralExpensesForExportToExcel();
        return dtb;
    }
}