using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for PODetailsListBAL
/// </summary>
public class PODetailsListBAL
{

    PODetailsListDAL pODetailsListDAL = new PODetailsListDAL();

    public PODetailsListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetPODetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = pODetailsListDAL.GetPODetailsList();
        return dtb;
    }

    public DataTable GetPODetailsListById(PODetailsListUI pODetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pODetailsListDAL.GetPODetailsListById(pODetailsListUI);
        return dtb;
    }

    public DataTable GetPODetailsListBySearchParameters(PODetailsListUI pODetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = pODetailsListDAL.GetPODetailsListBySearchParameters(pODetailsListUI);
        return dtb;
    }

    public int DeletePODetails(PODetailsListUI pODetailsListUI)
    {
        int result = 0;
        result = pODetailsListDAL.DeletePODetails(pODetailsListUI);
        return result;
    }

    public DataTable GetPODetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = pODetailsListDAL.GetPODetailsListForExportToExcel();
        return dtb;
    }

}