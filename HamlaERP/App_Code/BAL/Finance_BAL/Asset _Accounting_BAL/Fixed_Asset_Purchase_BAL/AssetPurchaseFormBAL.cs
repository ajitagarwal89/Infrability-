using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for AssetPurchaseFormBAL
/// </summary>
public class AssetPurchaseFormBAL
{
    AssetPurchaseFormDAL assetPurchaseFormDAL = new AssetPurchaseFormDAL();
    public AssetPurchaseFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetPurchaseListById(AssetPurchaseFormUI assetPurchaseFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseFormDAL.GetAssetPurchaseListById(assetPurchaseFormUI);
        return dtb;
    }

    public int AddAssetPurchase(AssetPurchaseFormUI assetPurchaseFormUI)
    {
        int resutl = 0;
        resutl = assetPurchaseFormDAL.AddAssetPurchase(assetPurchaseFormUI);
        return resutl;
    }

    public int UpdateAssetPurchase(AssetPurchaseFormUI assetPurchaseFormUI)
    {
        int resutl = 0;
        resutl = assetPurchaseFormDAL.UpdateAssetPurchase(assetPurchaseFormUI);
        return resutl;
    }

    public int DeleteAssetPurchase(AssetPurchaseFormUI assetPurchaseFormUI)
    {
        int resutl = 0;
        resutl = assetPurchaseFormDAL.DeleteAssetPurchase(assetPurchaseFormUI);
        return resutl;
    }

}