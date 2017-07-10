using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for FiscalPeriodFormBLL
/// </summary>
public class FiscalPeriodFormBAL
{
    FiscalPeriodFormDAL fiscalPeriodFormDAL = new FiscalPeriodFormDAL();

    public FiscalPeriodFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetFiscalPeriodListById(FiscalPeriodFormUI fiscalPeriodFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = fiscalPeriodFormDAL.GetFiscalPeriodListById(fiscalPeriodFormUI);
        return dtb;
    }

    public int AddFiscalPeriod(FiscalPeriodFormUI fiscalPeriodFormUI)
    {
        int resutl = 0;
        resutl = fiscalPeriodFormDAL.AddFiscalPeriod(fiscalPeriodFormUI);
        return resutl;
    }

    public int UpdateFiscalPeriod(FiscalPeriodFormUI fiscalPeriodFormUI)
    {
        int resutl = 0;
        resutl = fiscalPeriodFormDAL.UpdateFiscalPeriod(fiscalPeriodFormUI);
        return resutl;
    }

    public int DeleteFiscalPeriod(FiscalPeriodFormUI fiscalPeriodFormUI)
    {
        int resutl = 0;
        resutl = fiscalPeriodFormDAL.DeleteFiscalPeriod(fiscalPeriodFormUI);
        return resutl;
    }
}