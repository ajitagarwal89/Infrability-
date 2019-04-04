using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for NonPOBasedInvoiceDistributionForm
/// </summary>
public class NonPOBasedInvoiceDistributionFormBAL
{

    NonPOBasedInvoiceDistributionFormDAL nonPOBasedInvoiceDistributionFormDAL = new NonPOBasedInvoiceDistributionFormDAL();

    public NonPOBasedInvoiceDistributionFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetNonPOBasedInvoiceDistributionListById(NonPOBasedInvoiceDistributionFormUI nonPOBasedInvoiceDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = nonPOBasedInvoiceDistributionFormDAL.GetNonPOBasedInvoiceDistributionListById(nonPOBasedInvoiceDistributionFormUI);
        return dtb;
    }

    public int AddNonPOBasedInvoiceDistribution(NonPOBasedInvoiceDistributionFormUI nonPOBasedInvoiceDistributionFormUI)
    {
        int resutl = 0;
        resutl = nonPOBasedInvoiceDistributionFormDAL.AddNonPOBasedInvoiceDistribution(nonPOBasedInvoiceDistributionFormUI);
        return resutl;
    }

    public int UpdateNonPOBasedInvoiceDistribution(NonPOBasedInvoiceDistributionFormUI nonPOBasedInvoiceDistributionFormUI)
    {
        int resutl = 0;
        resutl = nonPOBasedInvoiceDistributionFormDAL.UpdateNonPOBasedInvoiceDistribution(nonPOBasedInvoiceDistributionFormUI);
        return resutl;
    }

    public int DeleteNonPOBasedInvoiceDistribution(NonPOBasedInvoiceDistributionFormUI nonPOBasedInvoiceDistributionFormUI)
    {
        int resutl = 0;
        resutl = nonPOBasedInvoiceDistributionFormDAL.DeleteNonPOBasedInvoiceDistribution(nonPOBasedInvoiceDistributionFormUI);
        return resutl;
    }

    public DataTable GetNonPOBasedInvoiceDistribution_SelectByNonPOBasedInvoiceId(NonPOBasedInvoiceDistributionFormUI nonPOBasedInvoiceDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = nonPOBasedInvoiceDistributionFormDAL.GetNonPOBasedInvoiceDistribution_SelectByNonPOBasedInvoiceId(nonPOBasedInvoiceDistributionFormUI);
        return dtb;
    }
}