using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetPurchaseDistributionListBAL
/// </summary>
public class AssetPurchaseDistributionListBAL
{
    AssetPurchaseDistributionListDAL assetPurchaseDistributionListDAL = new AssetPurchaseDistributionListDAL();
    public AssetPurchaseDistributionListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetPurchaseDistributionList()
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseDistributionListDAL.GetAssetPurchaseDistributionList();
        return dtb;
    }
    public DataTable GetAssetPurchaseDistributionListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseDistributionListDAL.GetAssetPurchaseDistributionListForExportToExcel();
        return dtb;
    }
    public DataTable GetAssetPurchaseDistributionListById(AssetPurchaseDistributionListUI assetPurchaseDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseDistributionListDAL.GetAssetPurchaseDistributionListById(assetPurchaseDistributionListUI);
        return dtb;
    }

    public DataTable GetAssetPurchaseDistributionListBySearchParameters(AssetPurchaseDistributionListUI assetPurchaseDistributionListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseDistributionListDAL.GetAssetPurchaseDistributionListBySearchParameters(assetPurchaseDistributionListUI);
        return dtb;
    }

    public int DeleteAssetPurchaseDistribution(AssetPurchaseDistributionListUI assetPurchaseDistributionListUI)
    {
        int result = 0;
        result = assetPurchaseDistributionListDAL.DeleteAssetPurchaseDistribution(assetPurchaseDistributionListUI);
        return result;
    }

}