using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for FiscalPeriodDetailsListBAL
/// </summary>
public class FiscalPeriodDetailsListBAL
{

    FiscalPeriodDetailsListDAL fiscalPeriodDetailsListDAL = new FiscalPeriodDetailsListDAL();

    public FiscalPeriodDetailsListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetFiscalPeriodDetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = fiscalPeriodDetailsListDAL.GetFiscalPeriodDetailsList();
        return dtb;
    }

    public DataTable GetFiscalPeriodDetailsListById(FiscalPeriodDetailsListUI fiscalPeriodDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = fiscalPeriodDetailsListDAL.GetFiscalPeriodDetailsListById(fiscalPeriodDetailsListUI);
        return dtb;
    }

    public DataTable GetFiscalPeriodDetailsListByFiscalPeriodId(FiscalPeriodDetailsListUI fiscalPeriodDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = fiscalPeriodDetailsListDAL.GetFiscalPeriodDetailsListByFiscalPeriodId(fiscalPeriodDetailsListUI);
        return dtb;
    }

    public DataTable GetFiscalPeriodDetailsListBySearchParameters(FiscalPeriodDetailsListUI fiscalPeriodDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = fiscalPeriodDetailsListDAL.GetFiscalPeriodDetailsListBySearchParameters(fiscalPeriodDetailsListUI);
        return dtb;
    }

    public int DeleteFiscalPeriodDetails(FiscalPeriodDetailsListUI fiscalPeriodDetailsListUI)
    {
        int result = 0;
        result = fiscalPeriodDetailsListDAL.DeleteFiscalPeriodDetails(fiscalPeriodDetailsListUI);
        return result;
    }

    public DataTable GetFiscalPeriodDetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = fiscalPeriodDetailsListDAL.GetFiscalPeriodDetailsListForExportToExcel();
        return dtb;
    }

}