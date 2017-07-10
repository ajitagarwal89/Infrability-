using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DownPaymentFromCustomerDistributionListBAL
/// </summary>
public class DownPaymentFromCustomerDistributionListBAL
{
    DownPaymentFromCustomerDistributionListDAL downPaymentFromCustomerDistributionListDAL = new DownPaymentFromCustomerDistributionListDAL();
    public DownPaymentFromCustomerDistributionListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetDownPaymentFromCustomerDistributionList()
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerDistributionListDAL.GetDownPaymentFromCustomerDistributionList();
        return dtb;
    }
    public DataTable GetDownPaymentFromCustomerDistributionListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerDistributionListDAL.GetDownPaymentFromCustomerDistributionListForExportToExcel();
        return dtb;
    }
    public DataTable GetDownPaymentFromCustomerDistributionListById(DownPaymentFromCustomerDistributionListUI downPaymentFromCustomerDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerDistributionListDAL.GetDownPaymentFromCustomerDistributionListById(downPaymentFromCustomerDistributionListUI);
        return dtb;
    }

    public DataTable GetDownPaymentFromCustomerDistributionListBySearchParameters(DownPaymentFromCustomerDistributionListUI downPaymentFromCustomerDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerDistributionListDAL.GetDownPaymentFromCustomerDistributionListBySearchParameters(downPaymentFromCustomerDistributionListUI);
        return dtb;
    }

    public int DeleteDownPaymentFromCustomerDistribution(DownPaymentFromCustomerDistributionListUI downPaymentFromCustomerDistributionListUI)
    {
        int result = 0;
        result = downPaymentFromCustomerDistributionListDAL.DeleteDownPaymentFromCustomerDistribution(downPaymentFromCustomerDistributionListUI);
        return result;
    }

}