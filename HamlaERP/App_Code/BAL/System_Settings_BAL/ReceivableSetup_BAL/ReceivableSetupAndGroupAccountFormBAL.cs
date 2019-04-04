using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ReceivableSetupAndGroupAccountFormBAL
/// </summary>
public class ReceivableSetupAndGroupAccountFormBAL
{
    ReceivableSetupAndGroupAccountFormDAL receivableSetupAndGroupAccountFormDAL = new ReceivableSetupAndGroupAccountFormDAL();
    public ReceivableSetupAndGroupAccountFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetReceivableSetupAndGroupAccountListById(ReceivableSetupAndGroupAccountFormUI receivableSetupAndGroupAccountFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupAndGroupAccountFormDAL.GetReceivableSetupAndGroupAccountListById(receivableSetupAndGroupAccountFormUI);
        return dtb;
    }

    public int AddReceivableSetupAndGroupAccount(ReceivableSetupAndGroupAccountFormUI receivableSetupAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = receivableSetupAndGroupAccountFormDAL.AddReceivableSetupAndGroupAccount(receivableSetupAndGroupAccountFormUI);
        return resutl;
    }

    public int UpdateReceivableSetupAndGroupAccount(ReceivableSetupAndGroupAccountFormUI receivableSetupAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = receivableSetupAndGroupAccountFormDAL.UpdateReceivableSetupAndGroupAccount(receivableSetupAndGroupAccountFormUI);
        return resutl;
    }

    public int DeleteReceivableSetupAndGroupAccount(ReceivableSetupAndGroupAccountFormUI receivableSetupAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = receivableSetupAndGroupAccountFormDAL.DeleteReceivableSetupAndGroupAccount(receivableSetupAndGroupAccountFormUI);
        return resutl;
    }
}