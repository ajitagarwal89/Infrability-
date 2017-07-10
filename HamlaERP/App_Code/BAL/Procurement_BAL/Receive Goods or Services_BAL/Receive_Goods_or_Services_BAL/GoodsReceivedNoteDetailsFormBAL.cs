using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GoodsReceivedNoteDetailsFormBAL
/// </summary>
public class GoodsReceivedNoteDetailsFormBAL
{
    GoodsReceivedNoteDetailsFormDAL goodsReceivedNoteDetailsFormDAL = new GoodsReceivedNoteDetailsFormDAL();

    public GoodsReceivedNoteDetailsFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetGoodsReceivedNoteDetailsListById(GoodsReceivedNoteDetailsFormUI goodsReceivedNoteDetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteDetailsFormDAL.GetGoodsReceivedNoteDetailsListById(goodsReceivedNoteDetailsFormUI);
        return dtb;
    }

    public int AddGoodsReceivedNoteDetails(GoodsReceivedNoteDetailsFormUI goodsReceivedNoteDetailsFormUI)
    {
        int resutl = 0;
        resutl = goodsReceivedNoteDetailsFormDAL.AddGoodsReceivedNoteDetails(goodsReceivedNoteDetailsFormUI);
        return resutl;
    }

    public int UpdateGoodsReceivedNoteDetails(GoodsReceivedNoteDetailsFormUI goodsReceivedNoteDetailsFormUI)
    {
        int resutl = 0;
        resutl = goodsReceivedNoteDetailsFormDAL.UpdateGoodsReceivedNoteDetails(goodsReceivedNoteDetailsFormUI);
        return resutl;
    }

    public int DeleteGoodsReceivedNoteDetails(GoodsReceivedNoteDetailsFormUI goodsReceivedNoteDetailsFormUI)
    {
        int resutl = 0;
        resutl = goodsReceivedNoteDetailsFormDAL.DeleteGoodsReceivedNoteDetails(goodsReceivedNoteDetailsFormUI);
        return resutl;
    }

}