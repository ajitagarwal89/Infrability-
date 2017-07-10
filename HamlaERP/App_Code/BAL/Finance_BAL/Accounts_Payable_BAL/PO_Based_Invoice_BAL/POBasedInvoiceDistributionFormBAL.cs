using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for POBasedInvoiceDistributionFormBAL
/// </summary>
public class POBasedInvoiceDistributionFormBAL
{
    POBasedInvoiceDistributionFormDAL pOBasedInvoiceDistributionFormDAL = new POBasedInvoiceDistributionFormDAL();

    public POBasedInvoiceDistributionFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPOBasedInvoiceDistributionListById(POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceDistributionFormDAL.GetPOBasedInvoiceDistributionListById(pOBasedInvoiceDistributionFormUI);
        return dtb;
    }

    public int AddPOBasedInvoiceDistribution(POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI)
    {
        int resutl = 0;
        resutl = pOBasedInvoiceDistributionFormDAL.AddPOBasedInvoiceDistribution(pOBasedInvoiceDistributionFormUI);
        return resutl;
    }

    public int UpdatePOBasedInvoiceDistribution(POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI)
    {
        int resutl = 0;
        resutl = pOBasedInvoiceDistributionFormDAL.UpdatePOBasedInvoiceDistribution(pOBasedInvoiceDistributionFormUI);
        return resutl;
    }

    public int DeletePOBasedInvoiceDistribution(POBasedInvoiceDistributionFormUI pOBasedInvoiceDistributionFormUI)
    {
        int resutl = 0;
        resutl = pOBasedInvoiceDistributionFormDAL.DeletePOBasedInvoiceDistribution(pOBasedInvoiceDistributionFormUI);
        return resutl;
    }

}