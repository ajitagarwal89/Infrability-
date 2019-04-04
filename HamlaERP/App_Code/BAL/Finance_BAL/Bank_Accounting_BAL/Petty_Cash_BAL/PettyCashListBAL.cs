using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PettyCashListBAL
/// </summary>
public class PettyCashListBAL
{

    PettyCashListDAL pettyCashListDAL = new PettyCashListDAL();

    public PettyCashListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPettyCashList()
    {
        DataTable dtb = new DataTable();
        dtb = pettyCashListDAL.GetPettyCashList();
        return dtb;
    }

    public DataTable GetPettyCashListById(PettyCashListUI pettyCashListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pettyCashListDAL.GetPettyCashListById(pettyCashListUI);
        return dtb;
    }

    public DataTable GetPettyCashListBySearchParameters(PettyCashListUI pettyCashListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pettyCashListDAL.GetPettyCashListBySearchParameters(pettyCashListUI);
        return dtb;
    }

    public int DeletePettyCash(PettyCashListUI pettyCashListUI)
    {
        int result = 0;
        result = pettyCashListDAL.DeletePettyCash(pettyCashListUI);
        return result;
    }

    public DataTable GetPettyCashListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = pettyCashListDAL.GetPettyCashListForExportToExcel();
        return dtb;
    }

}