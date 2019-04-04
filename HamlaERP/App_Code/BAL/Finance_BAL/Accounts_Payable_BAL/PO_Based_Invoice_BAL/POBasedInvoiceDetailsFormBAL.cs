using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for POBasedInvoiceDetailsFormBAL
/// </summary>
public class POBasedInvoiceDetailsFormBAL
{
    POBasedInvoiceDetailsFormDAL pOBasedInvoiceDetailsFormDAL = new POBasedInvoiceDetailsFormDAL();

    public POBasedInvoiceDetailsFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPOBasedInvoiceDetailsListById(POBasedInvoiceDetailsFormUI pOBasedInvoiceDetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceDetailsFormDAL.GetPOBasedInvoiceDetailsListById(pOBasedInvoiceDetailsFormUI);
        return dtb;
    }

    public int AddPOBasedInvoiceDetails(POBasedInvoiceDetailsFormUI pOBasedInvoiceDetailsFormUI)
    {
        int resutl = 0;
        resutl = pOBasedInvoiceDetailsFormDAL.AddPOBasedInvoiceDetails(pOBasedInvoiceDetailsFormUI);
        return resutl;
    }

    public int UpdatePOBasedInvoiceDetails(POBasedInvoiceDetailsFormUI pOBasedInvoiceDetailsFormUI)
    {
        int resutl = 0;
        resutl = pOBasedInvoiceDetailsFormDAL.UpdatePOBasedInvoiceDetails(pOBasedInvoiceDetailsFormUI);
        return resutl;
    }

    public int DeletePOBasedInvoiceDetails(POBasedInvoiceDetailsFormUI pOBasedInvoiceDetailsFormUI)
    {
        int resutl = 0;
        resutl = pOBasedInvoiceDetailsFormDAL.DeletePOBasedInvoiceDetails(pOBasedInvoiceDetailsFormUI);
        return resutl;
    }
}