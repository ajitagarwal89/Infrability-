using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for POBasedInvoiceDistributionListBAL
/// </summary>
public class POBasedInvoiceDistributionListBAL
{
    POBasedInvoiceDistributionListDAL pOBasedInvoiceDistributionListDAL = new POBasedInvoiceDistributionListDAL();

    public POBasedInvoiceDistributionListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPOBasedInvoiceDistributionList()
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceDistributionListDAL.GetPOBasedInvoiceDistributionList();
        return dtb;
    }
    public DataTable GetPOBasedInvoiceDistributionListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceDistributionListDAL.GetPOBasedInvoiceDistributionListForExportToExcel();
        return dtb;
    }
    public DataTable GetPOBasedInvoiceDistributionListById(POBasedInvoiceDistributionListUI pOBasedInvoiceDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceDistributionListDAL.GetPOBasedInvoiceDistributionListById(pOBasedInvoiceDistributionListUI);
        return dtb;
    }

    public DataTable GetPOBasedInvoiceDistributionListBySearchParameters(POBasedInvoiceDistributionListUI pOBasedInvoiceDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pOBasedInvoiceDistributionListDAL.GetPOBasedInvoiceDistributionListBySearchParameters(pOBasedInvoiceDistributionListUI);
        return dtb;
    }

    public int DeletePOBasedInvoiceDistribution(POBasedInvoiceDistributionListUI pOBasedInvoiceDistributionListUI)
    {
        int result = 0;
        result = pOBasedInvoiceDistributionListDAL.DeletePOBasedInvoiceDistribution(pOBasedInvoiceDistributionListUI);
        return result;
    }

}