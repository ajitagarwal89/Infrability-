using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for POBasedInvoiceDetailsListBAL
/// </summary>
public class POBasedInvoiceDetailsListBAL
{
    POBasedInvoiceDetailsListDAL pOBasedInvoiceDetailsListDAL = new POBasedInvoiceDetailsListDAL();
    public POBasedInvoiceDetailsListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public DataTable GetPOBasedInvoiceDetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceDetailsListDAL.GetPOBasedInvoiceDetailsList();
        return dtb;
    }
    public DataTable GetPOBasedInvoiceDetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceDetailsListDAL.GetPOBasedInvoiceDetailsListForExportToExcel();
        return dtb;
    }
    public DataTable GetPOBasedInvoiceListById(POBasedInvoiceDetailsListUI pOBasedInvoiceDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceDetailsListDAL.GetPOBasedInvoiceDetailsListById(pOBasedInvoiceDetailsListUI);
        return dtb;
    }

    public DataTable GetPOBasedInvoiceDetailsListSearchParameters(POBasedInvoiceDetailsListUI pOBasedInvoiceDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceDetailsListDAL.GetPOBasedInvoiceDetailsListSearchParameters(pOBasedInvoiceDetailsListUI);
        return dtb;
    }

    public int DeletePOBasedInvoiceDetails(POBasedInvoiceDetailsListUI pOBasedInvoiceDetailsListUI)
    {
        int result = 0;
        result = pOBasedInvoiceDetailsListDAL.DeletePOBasedInvoiceDetails(pOBasedInvoiceDetailsListUI);
        return result;
    }
}