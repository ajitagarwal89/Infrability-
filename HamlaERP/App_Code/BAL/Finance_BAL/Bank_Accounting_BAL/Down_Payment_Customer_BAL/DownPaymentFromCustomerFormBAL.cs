using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DownPaymentFromCustomerFormBAL
/// </summary>
public class DownPaymentFromCustomerFormBAL
{
    DownPaymentFromCustomerFormDAL downPaymentFromCustomerFormDAL = new DownPaymentFromCustomerFormDAL();
    public DownPaymentFromCustomerFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetDownPaymentFromCustomerListById(DownPaymentFromCustomerFormUI downPaymentFromCustomerFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerFormDAL.GetDownPaymentFromCustomerListById(downPaymentFromCustomerFormUI);
        return dtb;
    }
    public DataTable GetFiscalPeriod(DownPaymentFromCustomerFormUI downPaymentFromCustomerFormUI)
    { DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerFormDAL.GetFiscalPeriod(downPaymentFromCustomerFormUI);
            return dtb;
    }

    public int AddDownPaymentFromCustomer(DownPaymentFromCustomerFormUI downPaymentFromCustomerFormUI)
    {
        int resutl = 0;
        resutl =downPaymentFromCustomerFormDAL.AddDownPaymentFromCustomer(downPaymentFromCustomerFormUI);
        return resutl;
    }
    public int UpdateDownPaymentFromCustomer(DownPaymentFromCustomerFormUI downPaymentFromCustomerFormUI)
    {
        int resutl = 0;
        resutl =downPaymentFromCustomerFormDAL.UpdateDownPaymentFromCustomer(downPaymentFromCustomerFormUI);
        return resutl;
    }

    public int DeleteDownPaymentFromCustomer(DownPaymentFromCustomerFormUI downPaymentFromCustomerFormUI)
    {
        int resutl = 0;
        resutl = downPaymentFromCustomerFormDAL.DeleteDownPaymentFromCustomer(downPaymentFromCustomerFormUI);
        return resutl;
    }

    public int UpdatePostingDownPaymentFromCustomer(DownPaymentFromCustomerFormUI downPaymentFromCustomerFormUI)
    {
        int resutl = 0;
        resutl = downPaymentFromCustomerFormDAL.UpdatePostingDownPaymentFromCustomer(downPaymentFromCustomerFormUI);
        return resutl;
    }
    public DataTable GetSerialNumber(DownPaymentFromCustomerFormUI downPaymentFromCustomerFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = downPaymentFromCustomerFormDAL.GetSerialNumber(downPaymentFromCustomerFormUI);
        return dtb;
    }
}