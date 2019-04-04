using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for FiscalPeriodListBLL
/// </summary>
public class FiscalPeriodListBAL
{
    FiscalPeriodListDAL fiscalPeriodListDAL = new FiscalPeriodListDAL();

    public FiscalPeriodListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetFiscalPeriodList()
    {
        DataTable dtb = new DataTable();
        dtb = fiscalPeriodListDAL.GetFiscalPeriodList();
        return dtb;
    }

    public DataTable GetFiscalPeriodListById(FiscalPeriodListUI fiscalPeriodListUI)
    {
        DataTable dtb = new DataTable();
        dtb = fiscalPeriodListDAL.GetFiscalPeriodListById(fiscalPeriodListUI);
        return dtb;
    }

    public DataTable GetFiscalPeriodListBySearchParameters(FiscalPeriodListUI fiscalPeriodListUI)
    {
        DataTable dtb = new DataTable();
        dtb = fiscalPeriodListDAL.GetFiscalPeriodListBySearchParameters(fiscalPeriodListUI);
        return dtb;
    }

    public int DeleteFiscalPeriod(FiscalPeriodListUI fiscalPeriodListUI)
    {
        int result = 0;
        result = fiscalPeriodListDAL.DeleteFiscalPeriod(fiscalPeriodListUI);
        return result;
    }

    public DataTable GetFiscalPeriodListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = fiscalPeriodListDAL.GetFiscalPeriodListForExportToExcel();
        return dtb;
    }

}