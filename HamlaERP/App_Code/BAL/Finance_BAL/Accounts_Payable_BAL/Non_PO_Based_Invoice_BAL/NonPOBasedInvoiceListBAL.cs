using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for NonPOBasedInvoiceListBLL
/// </summary>
public class NonPOBasedInvoiceListBAL
{
    NonPOBasedInvoiceListDAL nonPOBasedInvoiceListDAL = new NonPOBasedInvoiceListDAL();

	public NonPOBasedInvoiceListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetNonPOBasedInvoiceList()
    {
        DataTable dtb = new DataTable();
        dtb = nonPOBasedInvoiceListDAL.GetNonPOBasedInvoiceList();
        return dtb;
    }
    public DataTable GetNonPOBasedInvoiceListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = nonPOBasedInvoiceListDAL.GetNonPOBasedInvoiceListForExportToExcel();
        return dtb;
    }
    public DataTable GetNonPOBasedInvoiceListById(NonPOBasedInvoiceListUI nonPOBasedInvoiceListUI)
    {
        DataTable dtb = new DataTable();
        dtb = nonPOBasedInvoiceListDAL.GetNonPOBasedInvoiceListById(nonPOBasedInvoiceListUI);
        return dtb;
    }

    public DataTable GetNonPOBasedInvoiceListBySearchParameters(NonPOBasedInvoiceListUI nonPOBasedInvoiceListUI)
    {
        DataTable dtb = new DataTable();
        dtb = nonPOBasedInvoiceListDAL.GetNonPOBasedInvoiceListBySearchParameters(nonPOBasedInvoiceListUI);
        return dtb;
    }

    public int DeleteNonPOBasedInvoice(NonPOBasedInvoiceListUI nonPOBasedInvoiceListUI)
    {
        int result = 0;
        result = nonPOBasedInvoiceListDAL.DeleteNonPOBasedInvoice(nonPOBasedInvoiceListUI);
        return result;
    }
}