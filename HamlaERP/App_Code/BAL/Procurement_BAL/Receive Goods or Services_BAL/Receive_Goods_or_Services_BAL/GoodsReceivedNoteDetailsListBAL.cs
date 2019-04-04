using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GoodsReceivedNoteDetailsListBAL
/// </summary>
public class GoodsReceivedNoteDetailsListBAL
{
    GoodsReceivedNoteDetailsListDAL goodsReceivedNoteDetailsListDAL = new GoodsReceivedNoteDetailsListDAL();

    public GoodsReceivedNoteDetailsListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetGoodsReceivedNoteDetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteDetailsListDAL.GetGoodsReceivedNoteDetailsList();
        return dtb;
    }
    public DataTable GetGoodsReceivedNoteDetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteDetailsListDAL.GetGoodsReceivedNoteDetailsListForExportToExcel();
        return dtb;
    }
    public DataTable GetGoodsReceivedNoteDetailsListById(GoodsReceivedNoteDetailsListUI goodsReceivedNoteDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteDetailsListDAL.GetGoodsReceivedNoteDetailsListById(goodsReceivedNoteDetailsListUI);
        return dtb;
    }

    public DataTable GetGoodsReceivedNoteDetailsListBySearchParameters(GoodsReceivedNoteDetailsListUI goodsReceivedNoteDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteDetailsListDAL.GetGoodsReceivedNoteDetailsListBySearchParameters(goodsReceivedNoteDetailsListUI);
        return dtb;
    }

    public int DeleteGoodsReceivedNoteDetails(GoodsReceivedNoteDetailsListUI goodsReceivedNoteDetailsListUI)
    {
        int result = 0;
        result = goodsReceivedNoteDetailsListDAL.DeleteGoodsReceivedNoteDetails(goodsReceivedNoteDetailsListUI);
        return result;
    }

}