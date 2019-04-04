using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for ReceivableSetupPeriodFormBAL
/// </summary>
public class ReceivableSetupPeriodFormBAL
{
    ReceivableSetupPeriodForm_DAL receivableSetupPeriodForm_DAL = new ReceivableSetupPeriodForm_DAL();
    public ReceivableSetupPeriodFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int AddReceivableSetupPeriod(ReceivableSetupPeriod_FormUI receivableSetupPeriod_FormUI)
    {
        int resutl = 0;
        resutl = receivableSetupPeriodForm_DAL.AddReceivableSetupPeriod(receivableSetupPeriod_FormUI);
        return resutl;
    }

    public int UpdateReceivalbeSetupPeriod(ReceivableSetupPeriod_FormUI receivableSetupPeriod_FormUI)
    {
        int resutl = 0;
        resutl = receivableSetupPeriodForm_DAL.UpdateReceivalbeSetupPeriod(receivableSetupPeriod_FormUI);
        return resutl;
    }

    public int DeleteReceivalbeSetupPeriod(ReceivableSetupPeriod_FormUI receivableSetupPeriod_FormUI)
    {
        int resutl = 0;
        resutl = receivableSetupPeriodForm_DAL.DeleteReceivalbeSetupPeriod(receivableSetupPeriod_FormUI);
        return resutl;
    }
    public DataTable GetReceivableSetupPeriodList()
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupPeriodForm_DAL.GetReceivableSetupPeriodList();
        return dtb;
    }
    }