using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for InvoiceAndOrderTypeListBLL
/// </summary>
public class InvoiceAndOrderTypeListBAL
{
    InvoiceAndOrderTypeListDAL invoiceAndOrderTypeListDAL = new InvoiceAndOrderTypeListDAL();

	public InvoiceAndOrderTypeListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetInvoiceAndOrderTypeList()
    {
        DataTable dtb = new DataTable();
        dtb = invoiceAndOrderTypeListDAL.GetInvoiceAndOrderTypeList();
        return dtb;
    }
    public DataTable GetInvoiceAndOrderTypeListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = invoiceAndOrderTypeListDAL.GetInvoiceAndOrderTypeListForExportToExcel();
        return dtb;
    }
    public DataTable GetInvoiceAndOrderTypeListById(InvoiceAndOrderTypeListUI invoiceAndOrderTypeListUI)
    {
        DataTable dtb = new DataTable();
        dtb = invoiceAndOrderTypeListDAL.GetInvoiceAndOrderTypeListById(invoiceAndOrderTypeListUI);
        return dtb;
    }

    public DataTable GetInvoiceAndOrderTypeListBySearchParameters(InvoiceAndOrderTypeListUI invoiceAndOrderTypeListUI)
    {
        DataTable dtb = new DataTable();
        dtb = invoiceAndOrderTypeListDAL.GetInvoiceAndOrderTypeListBySearchParameters(invoiceAndOrderTypeListUI);
        return dtb;
    }

    public int DeleteInvoiceAndOrderType(InvoiceAndOrderTypeListUI invoiceAndOrderTypeListUI)
    {
        int result = 0;
        result = invoiceAndOrderTypeListDAL.DeleteInvoiceAndOrderType(invoiceAndOrderTypeListUI);
        return result;
    }
}