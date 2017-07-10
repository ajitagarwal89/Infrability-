using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for NonPOBasedInvoiceDistributionListBAL
/// </summary>
public class NonPOBasedInvoiceDistributionListBAL
{

    NonPOBasedInvoiceDistributionListDAL nonPOBasedInvoiceDistributionListDAL = new NonPOBasedInvoiceDistributionListDAL();

    public NonPOBasedInvoiceDistributionListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetNonPOBasedInvoiceDistributionList()
    {
        DataTable dtb = new DataTable();
        dtb = nonPOBasedInvoiceDistributionListDAL.GetNonPOBasedInvoiceDistributionList();
        return dtb;
    }

    public DataTable GetNonPOBasedInvoiceDistributionListById( NonPOBasedInvoiceDistributionListUI nonPOBasedInvoiceDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = nonPOBasedInvoiceDistributionListDAL.GetNonPOBasedInvoiceDistributionListById(nonPOBasedInvoiceDistributionListUI);
        return dtb;
    }

    public DataTable GetNonPOBasedInvoiceDistributionListBySearchParameters( NonPOBasedInvoiceDistributionListUI nonPOBasedInvoiceDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = nonPOBasedInvoiceDistributionListDAL.GetNonPOBasedInvoiceDistributionListBySearchParameters(nonPOBasedInvoiceDistributionListUI);
        return dtb;
    }

    public int DeleteNonPOBasedInvoiceDistribution(NonPOBasedInvoiceDistributionListUI nonPOBasedInvoiceDistributionListUI)
    {
        int result = 0;
        result = nonPOBasedInvoiceDistributionListDAL.DeleteNonPOBasedInvoiceDistribution(nonPOBasedInvoiceDistributionListUI);
        return result;
    }

    public DataTable GetNonPOBasedInvoiceDistributionListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = nonPOBasedInvoiceDistributionListDAL.GetNonPOBasedInvoiceDistributionListForExportToExcel();
        return dtb;
    }

}