using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for FiscalPeriodDetailsFormBAL
/// </summary>
public class FiscalPeriodDetailsFormBAL
{
    FiscalPeriodDetailsFormDAL fiscalPeriodDetailsFormDAL = new FiscalPeriodDetailsFormDAL();

    public FiscalPeriodDetailsFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetFiscalPeriodDetailsListById(FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = fiscalPeriodDetailsFormDAL.GetFiscalPeriodDetailsListById(fiscalPeriodDetailsFormUI);
        return dtb;
    }

    public int AddFiscalPeriodDetails(FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI)
    {
        int resutl = 0;
        resutl = fiscalPeriodDetailsFormDAL.AddFiscalPeriodDetails(fiscalPeriodDetailsFormUI);
        return resutl;
    }

    public int UpdateFiscalPeriodDetails(FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI)
    {
        int resutl = 0;
        resutl = fiscalPeriodDetailsFormDAL.UpdateFiscalPeriodDetails(fiscalPeriodDetailsFormUI);
        return resutl;
    }

    public int UpdateFiscalPeriodDetailsClosingModules(FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI)
    {
        int resutl = 0;
        resutl = fiscalPeriodDetailsFormDAL.UpdateFiscalPeriodDetailsClosingModules(fiscalPeriodDetailsFormUI);
        return resutl;
    }

    public int DeleteFiscalPeriodDetails(FiscalPeriodDetailsFormUI fiscalPeriodDetailsFormUI)
    {
        int resutl = 0;
        resutl = fiscalPeriodDetailsFormDAL.DeleteFiscalPeriodDetails(fiscalPeriodDetailsFormUI);
        return resutl;
    }


}