using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GoodsReceivedNoteListBAL
/// </summary>
public class GoodsReceivedNoteListBAL
{
    GoodsReceivedNoteListDAL goodsReceivedNoteListDAL = new GoodsReceivedNoteListDAL();
    public GoodsReceivedNoteListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetGoodsReceivedNoteList()
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteListDAL.GetGoodsReceivedNoteList();
        return dtb;
    }
    public DataTable GetGoodsReceivedNoteListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteListDAL.GetGoodsReceivedNoteListForExportToExcel();
        return dtb;
    }
    public DataTable GetGoodsReceivedNoteListById(GoodsReceivedNoteListUI goodsReceivedNoteListUI)
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteListDAL.GetGoodsReceivedNoteListById(goodsReceivedNoteListUI);
        return dtb;
    }

    public DataTable GetGoodsReceivedNoteListBySearchParameters(GoodsReceivedNoteListUI goodsReceivedNoteListUI)
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteListDAL.GetGoodsReceivedNoteListBySearchParameters(goodsReceivedNoteListUI);
        return dtb;
    }

    public int DeleteGoodsReceivedNote(GoodsReceivedNoteListUI goodsReceivedNoteListUI)
    {
        int result = 0;
        result = goodsReceivedNoteListDAL.DeleteGoodsReceivedNote(goodsReceivedNoteListUI);
        return result;
    }

}