    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for POBasedInvoiceFormBLL
/// </summary>
public class POBasedInvoiceFormBAL
{
    POBasedInvoiceFormDAL pOBasedInvoiceFormDAL = new POBasedInvoiceFormDAL();

	public POBasedInvoiceFormBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable GetSerialNumber(POBasedInvoiceFormUI pOBasedInvoiceFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceFormDAL.GetSerialNumber(pOBasedInvoiceFormUI);
        return dtb;
    }

    public DataTable GetPOBasedInvoiceListById(POBasedInvoiceFormUI pOBasedInvoiceFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceFormDAL.GetPOBasedInvoiceListById(pOBasedInvoiceFormUI);
        return dtb;
    }

    public int AddPOBasedInvoice(POBasedInvoiceFormUI pOBasedInvoiceFormUI)
    {
        int resutl = 0;
        resutl = pOBasedInvoiceFormDAL.AddPOBasedInvoice(pOBasedInvoiceFormUI);
        return resutl;
    }

    public int UpdatePOBasedInvoice(POBasedInvoiceFormUI pOBasedInvoiceFormUI)
    {
        int resutl = 0;
        resutl = pOBasedInvoiceFormDAL.UpdatePOBasedInvoice(pOBasedInvoiceFormUI);
        return resutl;
    }

    public int DeletePOBasedInvoice(POBasedInvoiceFormUI pOBasedInvoiceFormUI)
    {
        int resutl = 0;
        resutl = pOBasedInvoiceFormDAL.DeletePOBasedInvoice(pOBasedInvoiceFormUI);
        return resutl;
    }

    public int UpdatePostingPOBasedInvoice(POBasedInvoiceFormUI pOBasedInvoiceFormUI)
    {
        int resutl = 0;
        resutl = pOBasedInvoiceFormDAL.UpdatePostingPOBasedInvoice(pOBasedInvoiceFormUI);
        return resutl;
    }
}