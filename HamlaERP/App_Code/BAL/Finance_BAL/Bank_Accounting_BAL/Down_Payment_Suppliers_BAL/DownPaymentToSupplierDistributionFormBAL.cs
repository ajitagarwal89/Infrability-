using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DownPaymentToSupplierDistributionFormBAL
/// </summary>
public class DownPaymentToSupplierDistributionFormBAL
{
    DownPaymentToSupplierDistributionFormDAL downPaymentToSupplierDistributionFormDAL = new DownPaymentToSupplierDistributionFormDAL();
    public DownPaymentToSupplierDistributionFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetDownPaymentToSupplierDistributionListById(DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierDistributionFormDAL.GetDownPaymentToSupplierDistributionListById(downPaymentToSupplierDistributionFormUI);
        return dtb;
    }

    public int AddDownPaymentToSupplierDistribution(DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI)
    {
        int resutl = 0;
        resutl = downPaymentToSupplierDistributionFormDAL.AddDownPaymentToSupplierDistribution(downPaymentToSupplierDistributionFormUI);
        return resutl;
    }
    public int UpdateDownPaymentToSupplierDistribution(DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI)
    {
        int resutl = 0;
        resutl = downPaymentToSupplierDistributionFormDAL.UpdateDownPaymentToSupplierDistribution(downPaymentToSupplierDistributionFormUI);
        return resutl;
    }

    public int DeleteDownPaymentToSupplierDistribution(DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI)
    {
        int resutl = 0;
        resutl = downPaymentToSupplierDistributionFormDAL.DeleteDownPaymentToSupplierDistribution(downPaymentToSupplierDistributionFormUI);
        return resutl;
    }
    public DataTable GetDownPaymentToSupplierDistribution_SelectByDownPaymentToSupplierId(DownPaymentToSupplierDistributionFormUI downPaymentToSupplierDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierDistributionFormDAL.GetDownPaymentToSupplierDistribution_SelectByDownPaymentToSupplierId(downPaymentToSupplierDistributionFormUI);
        return dtb;
    }
}