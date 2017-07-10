using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for InvoiceAndOrderTypeFormBLL
/// </summary>
public class InvoiceAndOrderTypeFormBAL
{
    InvoiceAndOrderTypeFormDAL invoiceAndOrderTypeFormDAL = new InvoiceAndOrderTypeFormDAL();

	public InvoiceAndOrderTypeFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetInvoiceAndOrderTypeListById(InvoiceAndOrderTypeFormUI invoiceAndOrderTypeFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = invoiceAndOrderTypeFormDAL.GetInvoiceAndOrderTypeListById(invoiceAndOrderTypeFormUI);
        return dtb;
    }

    public int AddInvoiceAndOrderType(InvoiceAndOrderTypeFormUI invoiceAndOrderTypeFormUI)
    {
        int resutl = 0;
        resutl = invoiceAndOrderTypeFormDAL.AddInvoiceAndOrderType(invoiceAndOrderTypeFormUI);
        return resutl;
    }

    public int UpdateInvoiceAndOrderType(InvoiceAndOrderTypeFormUI invoiceAndOrderTypeFormUI)
    {
        int resutl = 0;
        resutl = invoiceAndOrderTypeFormDAL.UpdateInvoiceAndOrderType(invoiceAndOrderTypeFormUI);
        return resutl;
    }

    public int DeleteInvoiceAndOrderType(InvoiceAndOrderTypeFormUI invoiceAndOrderTypeFormUI)
    {
        int resutl = 0;
        resutl = invoiceAndOrderTypeFormDAL.DeleteInvoiceAndOrderType(invoiceAndOrderTypeFormUI);
        return resutl;
    }
}