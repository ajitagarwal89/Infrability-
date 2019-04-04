using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GoodsReceivedNoteDistributionFormBAL
/// </summary>
public class GoodsReceivedNoteDistributionFormBAL
{
    GoodsReceivedNoteDistributionFormDAL goodsReceivedNoteDistributionFormDAL = new GoodsReceivedNoteDistributionFormDAL();

    public GoodsReceivedNoteDistributionFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetGoodsReceivedNoteDistributionListById(GoodsReceivedNoteDistributionFormUI goodsReceivedNoteDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteDistributionFormDAL.GetGoodsReceivedNoteDistributionListById(goodsReceivedNoteDistributionFormUI);
        return dtb;
    }

    public int AddGoodsReceivedNoteDistribution(GoodsReceivedNoteDistributionFormUI goodsReceivedNoteDistributionFormUI)
    {
        int resutl = 0;
        resutl = goodsReceivedNoteDistributionFormDAL.AddGoodsReceivedNoteDistribution(goodsReceivedNoteDistributionFormUI);
        return resutl;
    }

    public int UpdateGoodsReceivedNoteDistribution(GoodsReceivedNoteDistributionFormUI goodsReceivedNoteDistributionFormUI)
    {
        int resutl = 0;
        resutl = goodsReceivedNoteDistributionFormDAL.UpdateGoodsReceivedNoteDistribution(goodsReceivedNoteDistributionFormUI);
        return resutl;
    }

    public int DeleteGoodsReceivedNoteDistribution(GoodsReceivedNoteDistributionFormUI goodsReceivedNoteDistributionFormUI)
    {
        int resutl = 0;
        resutl = goodsReceivedNoteDistributionFormDAL.DeleteGoodsReceivedNoteDistribution(goodsReceivedNoteDistributionFormUI);
        return resutl;
    }

}