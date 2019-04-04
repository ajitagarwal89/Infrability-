using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for POFormBAL
/// </summary>
public class POFormBAL
{
    POFormDAL pOFormDAL = new POFormDAL();
    public POFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPOListById(POFormUI pOFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = pOFormDAL.GetPOListById(pOFormUI);
        return dtb;
    }
    public int AddPO(POFormUI pOFormUI)
    {
        int resutl = 0;
        resutl = pOFormDAL.AddPO(pOFormUI);
        return resutl;
    }

    public int UpdatePO(POFormUI pOFormUI)
    {
        int resutl = 0;
        resutl = pOFormDAL.UpdatePO(pOFormUI);
        return resutl;
    }

    public int DeletePO(POFormUI pOFormUI)
    {
        int resutl = 0;
        resutl = pOFormDAL.DeletePO(pOFormUI);
        return resutl;
    }
}