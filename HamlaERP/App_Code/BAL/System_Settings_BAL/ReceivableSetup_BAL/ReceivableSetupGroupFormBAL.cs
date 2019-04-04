using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for ReceivableSetupGroupFormBAL
/// </summary>
public class ReceivableSetupGroupFormBAL
{
    ReceivableSetupGroupFormDAL receivableSetupGroupFormDAL = new ReceivableSetupGroupFormDAL();
    ReceivableSetupGroupFormUI receivableSetupGroupFormUI = new ReceivableSetupGroupFormUI();
    public ReceivableSetupGroupFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetReceivableSetupGroupListById(ReceivableSetupGroupFormUI receivableSetupGroupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = receivableSetupGroupFormDAL.GetReceivableSetupGroupListById(receivableSetupGroupFormUI);
        return dtb;
    }

    public int AddRecievableSetupGroup(ReceivableSetupGroupFormUI receivableSetupGroupFormUI)
    {
        int resutl = 0;
        resutl = receivableSetupGroupFormDAL.AddReceivableSetupGroup(receivableSetupGroupFormUI);
        return resutl;
    }

    public int UpdateReceivableSetupGroup(ReceivableSetupGroupFormUI receivableSetupGroupFormUI)
    {
        int resutl = 0;
        resutl = receivableSetupGroupFormDAL.UpdateReceivableSetupGroup(receivableSetupGroupFormUI);
        return resutl;
    }

    public int DeleteRecievableSetupGroup(ReceivableSetupGroupFormUI receivableSetupGroupFormUI)
    {
        int resutl = 0;
        resutl = receivableSetupGroupFormDAL.DeleteReceivableSetupGroup(receivableSetupGroupFormUI);
        return resutl;
    }
}