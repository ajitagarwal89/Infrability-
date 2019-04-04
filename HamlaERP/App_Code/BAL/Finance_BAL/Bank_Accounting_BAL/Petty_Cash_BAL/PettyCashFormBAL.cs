using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PettyCashFormBAL
/// </summary>
public class PettyCashFormBAL
{

    PettyCashFormDAL pettyCashFormDAL = new PettyCashFormDAL();

    public PettyCashFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPettyCashListById(PettyCashFormUI pettyCashFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = pettyCashFormDAL.GetPettyCashListById(pettyCashFormUI);
        return dtb;
    }

    public int AddPettyCash(PettyCashFormUI pettyCashFormUI)
    {
        int resutl = 0;
        resutl = pettyCashFormDAL.AddPettyCash(pettyCashFormUI);
        return resutl;
    }

    public int UpdatePettyCash(PettyCashFormUI pettyCashFormUI)
    {
        int resutl = 0;
        resutl = pettyCashFormDAL.UpdatePettyCash(pettyCashFormUI);
        return resutl;
    }

    public int DeletePettyCash(PettyCashFormUI pettyCashFormUI)
    {
        int resutl = 0;
        resutl = pettyCashFormDAL.DeletePettyCash(pettyCashFormUI);
        return resutl;
    }
}