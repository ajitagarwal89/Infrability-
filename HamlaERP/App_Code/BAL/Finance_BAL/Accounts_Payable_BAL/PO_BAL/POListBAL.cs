using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for POListBAL
/// </summary>
public class POListBAL
{
    POListDAL pOListDAL = new POListDAL();
    public POListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetPOList()
    {
        DataTable dtb = new DataTable();
        dtb = pOListDAL.GetPOList();
        return dtb;
    }

    public DataTable GetPOListById(POListUI pOListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pOListDAL.GetPOListById(pOListUI);
        return dtb;
    }

    public DataTable GetPOListBySearchParameters(POListUI pOListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pOListDAL.GetPOListBySearchParameters(pOListUI);
        return dtb;
    }

    public int DeletePO(POListUI pOListUI)
    {
        int result = 0;
        result = pOListDAL.DeletePO(pOListUI);
        return result;
    }

    public DataTable GetPOListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = pOListDAL.GetPOListForExportToExcel();
        return dtb;
    }
}