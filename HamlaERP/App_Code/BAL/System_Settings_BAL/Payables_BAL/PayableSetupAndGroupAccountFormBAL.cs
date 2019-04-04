using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PayableSetupGroupAccountFormBAL
/// </summary>
public class PayableSetupAndGroupAccountFormBAL
{
    PayableSetupAndGroupAccountFormDAL payableSetupAndGroupAccountFormDAL = new PayableSetupAndGroupAccountFormDAL();
    public PayableSetupAndGroupAccountFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPayableSetupAndGroupAccountListById(PayableSetupAndGroupAccountFormUI payableSetupAndGroupAccountFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = payableSetupAndGroupAccountFormDAL.GetPayableSetupAndGroupAccountListById(payableSetupAndGroupAccountFormUI);
        return dtb;
    }

    public int AddPayableSetupAndGroupAccount(PayableSetupAndGroupAccountFormUI payableSetupAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = payableSetupAndGroupAccountFormDAL.AddPayableSetupAndGroupAccount(payableSetupAndGroupAccountFormUI);
        return resutl;
    }

    public int UpdatePayableSetupAndGroupAccount(PayableSetupAndGroupAccountFormUI payableSetupAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = payableSetupAndGroupAccountFormDAL.UpdatePayableSetupAndGroupAccount(payableSetupAndGroupAccountFormUI);
        return resutl;
    }

    public int DeletePayableSetupAndGroupAccount(PayableSetupAndGroupAccountFormUI payableSetupAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = payableSetupAndGroupAccountFormDAL.DeletePayableSetupAndGroupAccount(payableSetupAndGroupAccountFormUI);
        return resutl;
    }
}