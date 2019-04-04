using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PayableSetupPeriod_FormBal
/// </summary>
public class PayableSetupPeriodFormBAL
{
    PayableSetupPeriodFormDAL payableSetupPeriodFormDAL = new PayableSetupPeriodFormDAL();
    public PayableSetupPeriodFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int AddPayableSetupPeriod(PayableSetupPeriod_FormUI payableSetupPeriodFormUI)
    {
        int resutl = 0;
        resutl = payableSetupPeriodFormDAL.AddPayableSetupPeriod(payableSetupPeriodFormUI);
        return resutl;
    }
    public int UpdatePayableSetupPeriod(PayableSetupPeriod_FormUI payableSetupPeriodFormUI)
    {
        int resutl = 0;
        resutl = payableSetupPeriodFormDAL.UpdatePayableSetupPeriod(payableSetupPeriodFormUI);
        return resutl;
    }

    public DataTable GetPayableSetupPeriodById(PayableSetupFormUI payableSetupFormUI)
    {

        DataTable dtb = new DataTable();
        dtb = payableSetupPeriodFormDAL.GetPayableSetupPeriodById(payableSetupFormUI);
        return dtb;

      
    }
    public DataTable GetPayableSetupId()
    {

        DataTable dtb = new DataTable();
        dtb = payableSetupPeriodFormDAL.GetPayableSetupId();
        return dtb;


    }


}