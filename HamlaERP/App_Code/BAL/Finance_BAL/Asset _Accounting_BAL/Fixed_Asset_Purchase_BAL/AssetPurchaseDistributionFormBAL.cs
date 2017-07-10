using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetPurchaseDistributionFormBAL
/// </summary>
public class AssetPurchaseDistributionFormBAL
{
    AssetPurchaseDistributionFormDAL assetPurchaseDistributionFormDAL = new AssetPurchaseDistributionFormDAL();
    public AssetPurchaseDistributionFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAssetPurchaseDistributionListById(AssetPurchaseDistributionFormUI assetPurchaseDistributionFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseDistributionFormDAL.GetAssetPurchaseDistributionListById(assetPurchaseDistributionFormUI);
        return dtb;
    }

    public int AddAssetPurchaseDistribution(AssetPurchaseDistributionFormUI assetPurchaseDistributionFormUI)
    {
        int resutl = 0;
        resutl = assetPurchaseDistributionFormDAL.AddAssetPurchaseDistribution(assetPurchaseDistributionFormUI);
        return resutl;
    }

    public int UpdateAssetPurchaseDistribution(AssetPurchaseDistributionFormUI assetPurchaseDistributionFormUI)
    {
        int resutl = 0;
        resutl = assetPurchaseDistributionFormDAL.UpdateAssetPurchaseDistribution(assetPurchaseDistributionFormUI);
        return resutl;
    }

    public int DeleteAssetPurchaseDistribution(AssetPurchaseDistributionFormUI assetPurchaseDistributionFormUI)
    {
        int resutl = 0;
        resutl = assetPurchaseDistributionFormDAL.DeleteAssetPurchaseDistribution(assetPurchaseDistributionFormUI);
        return resutl;
    }
}