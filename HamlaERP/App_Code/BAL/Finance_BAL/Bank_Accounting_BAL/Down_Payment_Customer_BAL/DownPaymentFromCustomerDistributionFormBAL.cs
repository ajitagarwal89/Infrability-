using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for DownPaymentFromCustomerDistributionFormBAL
/// </summary>
public class DownPaymentFromCustomerDistributionFormBAL
{
    DownPaymentFromCustomerDistributionFormDAL downPaymentFromCustomerDistributionFormDAL = new DownPaymentFromCustomerDistributionFormDAL();
    public DownPaymentFromCustomerDistributionFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetDownPaymentFromCustomerDistributionListById(DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerDistributionFormDAL.GetDownPaymentFromCustomerDistributionListById(downPaymentFromCustomerDistributionFormUI);
        return dtb;
    }

    public int AddDownPaymentFromCustomerDistribution(DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI)
    {
        int resutl = 0;
        resutl = downPaymentFromCustomerDistributionFormDAL.AddDownPaymentFromCustomerDistribution(downPaymentFromCustomerDistributionFormUI);
        return resutl;
    }
    public int UpdateDownPaymentFromCustomerDistribution(DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI)
    {
        int resutl = 0;
        resutl = downPaymentFromCustomerDistributionFormDAL.UpdateDownPaymentFromCustomerDistribution(downPaymentFromCustomerDistributionFormUI);
        return resutl;
    }

    public int DeleteDownPaymentFromCustomerDistribution(DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI)
    {
        int resutl = 0;
        resutl = downPaymentFromCustomerDistributionFormDAL.DeleteDownPaymentFromCustomerDistribution(downPaymentFromCustomerDistributionFormUI);
        return resutl;
    }

    public DataTable GetDownPaymentFromCustomerDistribution_SelectByDownPaymentFromCustomerId(DownPaymentFromCustomerDistributionFormUI downPaymentFromCustomerDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerDistributionFormDAL.GetDownPaymentFromCustomerDistribution_SelectByDownPaymentFromCustomerId(downPaymentFromCustomerDistributionFormUI);
        return dtb;
    }

}