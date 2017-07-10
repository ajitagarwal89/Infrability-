using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PODetailsFormBAL
/// </summary>
   public class PODetailsFormBAL
   {
     PODetailsFormDAL pODetailsFormDAL = new PODetailsFormDAL();
    public PODetailsFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPODetailsListById(PODetailsFormUI pODetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = pODetailsFormDAL.GetPODetailsListById(pODetailsFormUI);
        return dtb;
    }

    public int AddPODetails(PODetailsFormUI pODetailsFormUI)
    {
        int resutl = 0;
        resutl = pODetailsFormDAL.AddPODetails(pODetailsFormUI);
        return resutl;
    }

    public int UpdatePODetails(PODetailsFormUI pODetailsFormUI)
    {
        int resutl = 0;
        resutl = pODetailsFormDAL.UpdatePODetails(pODetailsFormUI);
        return resutl;
    }

    public int DeletePODetails(PODetailsFormUI pODetailsFormUI)
    {
        int resutl = 0;
        resutl = pODetailsFormDAL.DeletePODetails(pODetailsFormUI);
        return resutl;
    }
}