using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PONumberListBAL
/// </summary>
public class PONumberListBAL
{
    PONumberListDAL pONumberListDAL = new PONumberListDAL();
    public PONumberListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPONumberList()
    {
        DataTable dtb = new DataTable();
        dtb = pONumberListDAL.GetPONumberList();
        return dtb;
    }

    public DataTable GetPONumberListById(PONumberListUI pONumberListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pONumberListDAL.GetPONumberListById(pONumberListUI);
        return dtb;
    }

    public DataTable GetPONumberListSearchParameters(PONumberListUI pONumberListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pONumberListDAL.GetPONumberListBySearchParameters(pONumberListUI);
        return dtb;
    }
}