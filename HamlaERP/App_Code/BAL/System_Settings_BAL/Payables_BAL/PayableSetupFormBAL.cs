using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Payable_Management_FormBal
/// </summary>
public class PayableSetupFormBAL
{
    PayableSetupFormDAL payableSetupFormDAL = new PayableSetupFormDAL();

    public PayableSetupFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPayableSetupListById(PayableSetupFormUI payableSetupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = payableSetupFormDAL.GetPayableSetupListById(payableSetupFormUI);
        return dtb;
    }

    public int AddPayableSetup(PayableSetupFormUI payableSetupFormUI)
    {
        int resutl = 0;
        resutl = payableSetupFormDAL.AddPayableSetup(payableSetupFormUI);
        return resutl;
    }
    public int UpdatePayableSetup(PayableSetupFormUI payableSetupFormUI)
    {
        int resutl = 0;
        resutl = payableSetupFormDAL.UpdatePayableSetup(payableSetupFormUI);
        return resutl;
    }
    public int DeletePayableSetup(PayableSetupFormUI payableSetupFormUI)
    {
        int resutl = 0;
        resutl = payableSetupFormDAL.DeletePayableSetup(payableSetupFormUI);
        return resutl;
    }
}