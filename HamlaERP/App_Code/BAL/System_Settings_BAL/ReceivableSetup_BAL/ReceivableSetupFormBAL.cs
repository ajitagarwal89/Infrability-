using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ReceivableSetupFormBAL
/// </summary>
public class ReceivableSetupFormBAL
{
    ReceivableSetupFormDAL receivableSetupFormDAL = new ReceivableSetupFormDAL();
    ReceivableSetupFormUI receivableSetupFormUI = new ReceivableSetupFormUI();
    public ReceivableSetupFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetReceivalbeSetupPeriodIdListById(ReceivableSetupFormUI receivableSetupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupFormDAL.GetReceivalbeSetupPeriodIdListById(receivableSetupFormUI);
        return dtb;
    }
    public DataTable GetReceivableSetupListById(ReceivableSetupFormUI receivableSetupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupFormDAL.GetReceivableSetupListById(receivableSetupFormUI);
        return dtb;
    }

    public int AddReceivableSetup(ReceivableSetupFormUI receivableSetupFormUI)
    {
        int resutl = 0;
        resutl = receivableSetupFormDAL.AddReceivableSetup(receivableSetupFormUI);
        return resutl;
    }

    public int UpdateReceivableSetup(ReceivableSetupFormUI receivableSetupFormUI)
    {
        int resutl = 0;
        resutl = receivableSetupFormDAL.UpdateReceivableSetup(receivableSetupFormUI);
        return resutl;
    }

    public int DeleteReceivableSetup(ReceivableSetupFormUI receivableSetupFormUI)
    {
        int resutl = 0;
        resutl = receivableSetupFormDAL.DeleteReceivableSetup(receivableSetupFormUI);
        return resutl;
    }
}