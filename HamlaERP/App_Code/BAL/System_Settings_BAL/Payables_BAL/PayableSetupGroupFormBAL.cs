using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PayableSetupGroupFormBAL
/// </summary>
public class PayableSetupGroupFormBAL
{
    PayableSetupGroupFormDAL payableSetupGroupFormDAL = new PayableSetupGroupFormDAL();
    public PayableSetupGroupFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPayableSetupGroupListById(PayableSetupGroupFormUI payableSetupGroupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = payableSetupGroupFormDAL.GetPayableSetupGroupListById(payableSetupGroupFormUI);
        return dtb;
    }

    public int AddPayableSetupGroup(PayableSetupGroupFormUI payableSetupGroupFormUI)
    {
        int resutl = 0;
        resutl = payableSetupGroupFormDAL.AddPayableSetupGroup(payableSetupGroupFormUI);
        return resutl;
    }

    public int UpdatePayableSetupGroup(PayableSetupGroupFormUI payableSetupGroupFormUI)
    {
        int resutl = 0;
        resutl = payableSetupGroupFormDAL.UpdatePayableSetupGroup(payableSetupGroupFormUI);
        return resutl;
    }

    public int DeletePayableSetupGroup(PayableSetupGroupFormUI payableSetupGroupFormUI)
    {
        int resutl = 0;
        resutl = payableSetupGroupFormDAL.DeletePayableSetupGroup(payableSetupGroupFormUI);
        return resutl;
    }
}