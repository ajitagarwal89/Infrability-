using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GoodsReceivedNoteFormBAL
/// </summary>
public class GoodsReceivedNoteFormBAL
{

    GoodsReceivedNoteFormDAL goodsReceivedNoteFormDAL = new GoodsReceivedNoteFormDAL();
    public GoodsReceivedNoteFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetGoodsReceivedNoteListById(GoodsReceivedNoteFormUI goodsReceivedNoteFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteFormDAL.GetGoodsReceivedNoteListById(goodsReceivedNoteFormUI);
        return dtb;
    }

    public int AddGoodsReceivedNote(GoodsReceivedNoteFormUI goodsReceivedNoteFormUI)
    {
        int resutl = 0;
        resutl = goodsReceivedNoteFormDAL.AddGoodsReceivedNote(goodsReceivedNoteFormUI);
        return resutl;
    }

    public int UpdateGoodsReceivedNote(GoodsReceivedNoteFormUI goodsReceivedNoteFormUI)
    {
        int resutl = 0;
        resutl = goodsReceivedNoteFormDAL.UpdateGoodsReceivedNote(goodsReceivedNoteFormUI);
        return resutl;
    }

    public int DeleteGoodsReceivedNote(GoodsReceivedNoteFormUI goodsReceivedNoteFormUI)
    {
        int resutl = 0;
        resutl = goodsReceivedNoteFormDAL.DeleteGoodsReceivedNote(goodsReceivedNoteFormUI);
        return resutl;
    }
    public int UpdatePostingGoodsReceivedNote(GoodsReceivedNoteFormUI goodsReceivedNoteFormUI)
    {
        int resutl = 0;
        resutl = goodsReceivedNoteFormDAL.UpdatePostingGoodsReceivedNote(goodsReceivedNoteFormUI);
        return resutl;
    }

}