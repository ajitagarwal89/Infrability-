using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for GoodsReceivedNoteDistributionListBAL
/// </summary>
public class GoodsReceivedNoteDistributionListBAL
{
    GoodsReceivedNoteDistributionListDAL goodsReceivedNoteDistributionListDAL = new GoodsReceivedNoteDistributionListDAL();

    public GoodsReceivedNoteDistributionListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetGoodsReceivedNoteDistributionList()
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteDistributionListDAL.GetGoodsReceivedNoteDistributionList();
        return dtb;
    }
    public DataTable GetGoodsReceivedNoteDistributionListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteDistributionListDAL.GetGoodsReceivedNoteDistributionListForExportToExcel();
        return dtb;
    }
    public DataTable GetGoodsReceivedNoteDistributionListById(GoodsReceivedNoteDistributionListUI goodsReceivedNoteDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteDistributionListDAL.GetGoodsReceivedNoteDistributionListById(goodsReceivedNoteDistributionListUI);
        return dtb;
    }

    public DataTable GetGoodsReceivedNoteDistributionListBySearchParameters(GoodsReceivedNoteDistributionListUI goodsReceivedNoteDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = goodsReceivedNoteDistributionListDAL.GetGoodsReceivedNoteDistributionListBySearchParameters(goodsReceivedNoteDistributionListUI);
        return dtb;
    }

    public int DeleteGoodsReceivedNoteDistribution(GoodsReceivedNoteDistributionListUI goodsReceivedNoteDistributionListUI)
    {
        int result = 0;
        result = goodsReceivedNoteDistributionListDAL.DeleteGoodsReceivedNoteDistribution(goodsReceivedNoteDistributionListUI);
        return result;
    }
}