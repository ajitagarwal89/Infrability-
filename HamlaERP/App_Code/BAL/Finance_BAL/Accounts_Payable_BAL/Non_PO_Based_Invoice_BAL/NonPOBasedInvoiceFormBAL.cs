using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for NonPOBasedInvoiceFormBLL
/// </summary>
public class NonPOBasedInvoiceFormBAL
{
    NonPOBasedInvoiceFormDAL nonPOBasedInvoiceFormDAL = new NonPOBasedInvoiceFormDAL();

    public NonPOBasedInvoiceFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetNonPOBasedInvoiceListById(NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = nonPOBasedInvoiceFormDAL.GetNonPOBasedInvoiceListById(nonPOBasedInvoiceFormUI);
        return dtb;
    }

    public DataTable GetSerialNumber(NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = nonPOBasedInvoiceFormDAL.GetSerialNumber(nonPOBasedInvoiceFormUI);
        return dtb;
    }

    public int AddNonPOBasedInvoice(NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI)
    {
        int resutl = 0;
        resutl = nonPOBasedInvoiceFormDAL.AddNonPOBasedInvoice(nonPOBasedInvoiceFormUI);
        return resutl;
    }

    public int UpdateNonPOBasedInvoice(NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI)
    {
        int resutl = 0;
        resutl = nonPOBasedInvoiceFormDAL.UpdateNonPOBasedInvoice(nonPOBasedInvoiceFormUI);
        return resutl;
    }

    public int DeleteNonPOBasedInvoice(NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI)
    {
        int resutl = 0;
        resutl = nonPOBasedInvoiceFormDAL.DeleteNonPOBasedInvoice(nonPOBasedInvoiceFormUI);
        return resutl;
    }

    public int UpdatePostingNonPOBasedInvoice(NonPOBasedInvoiceFormUI nonPOBasedInvoiceFormUI)
    {
        int resutl = 0;
        resutl = nonPOBasedInvoiceFormDAL.UpdatePostingNonPOBasedInvoice(nonPOBasedInvoiceFormUI);
        return resutl;
    }

}





