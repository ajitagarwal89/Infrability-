using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for POBasedInvoiceListBLL
/// </summary>
public class POBasedInvoiceListBAL
{
    POBasedInvoiceListDAL pOBasedInvoiceListDAL = new POBasedInvoiceListDAL();

	public POBasedInvoiceListBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetPOBasedInvoiceList()
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceListDAL.GetPOBasedInvoiceList();
        return dtb;
    }
    public DataTable GetPOBasedInvoiceListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceListDAL.GetPOBasedInvoiceListForExportToExcel();
        return dtb;
    }
    public DataTable GetPOBasedInvoiceListById(POBasedInvoiceListUI pOBasedInvoiceListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceListDAL.GetPOBasedInvoiceListById(pOBasedInvoiceListUI);
        return dtb;
    }

    public DataTable GetPOBasedInvoiceListBySearchParameters(POBasedInvoiceListUI pOBasedInvoiceListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceListDAL.GetPOBasedInvoiceListBySearchParameters(pOBasedInvoiceListUI);
        return dtb;
    }

    public int DeletePOBasedInvoice(POBasedInvoiceListUI pOBasedInvoiceListUI)
    {
        int result = 0;
        result = pOBasedInvoiceListDAL.DeletePOBasedInvoice(pOBasedInvoiceListUI);
        return result;
    }
}