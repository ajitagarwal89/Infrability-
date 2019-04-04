using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DownPaymentToSupplierDistributionListBAL
/// </summary>
public class DownPaymentToSupplierDistributionListBAL
{
    DownPaymentToSupplierDistributionListDAL downPaymentToSupplierDistributionListDAL = new DownPaymentToSupplierDistributionListDAL();
    public DownPaymentToSupplierDistributionListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetDownPaymentToSupplierDistributionList()
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierDistributionListDAL.GetDownPaymentToSupplierDistributionList();
        return dtb;
    }
    public DataTable GetDownPaymentToSupplierDistributionListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierDistributionListDAL.GetDownPaymentToSupplierDistributionListForExportToExcel();
        return dtb;
    }
    public DataTable GetDownPaymentToSupplierDistributionListById(DownPaymentToSupplierDistributionListUI downPaymentToSupplierDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierDistributionListDAL.GetDownPaymentToSupplierDistributionListById(downPaymentToSupplierDistributionListUI);
        return dtb;
    }

    public DataTable GetDownPaymentToSupplierDistributionListBySearchParameters(DownPaymentToSupplierDistributionListUI downPaymentToSupplierDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentToSupplierDistributionListDAL.GetDownPaymentToSupplierDistributionListBySearchParameters(downPaymentToSupplierDistributionListUI);
        return dtb;
    }

    public int DeleteDownPaymentToSupplierDistribution(DownPaymentToSupplierDistributionListUI downPaymentToSupplierDistributionListUI)
    {
        int result = 0;
        result = downPaymentToSupplierDistributionListDAL.DeleteDownPaymentToSupplierDistribution(downPaymentToSupplierDistributionListUI);
        return result;
    }

}