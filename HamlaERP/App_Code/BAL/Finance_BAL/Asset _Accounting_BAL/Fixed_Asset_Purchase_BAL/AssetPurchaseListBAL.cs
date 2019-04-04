using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for AssetPurchaseListBAL
/// </summary>
public class AssetPurchaseListBAL
{
    AssetPurchaseListDAL assetPurchaseListDAL = new AssetPurchaseListDAL();
    public AssetPurchaseListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAssetPurchaseList()
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseListDAL.GetAssetPurchaseList();
        return dtb;
    }
    public DataTable GetAssetPurchaseListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseListDAL.GetAssetPurchaseListForExportToExcel();
        return dtb;
    }
    public DataTable GetAssetPurchaseListById(AssetPurchaseListUI assetPurchaseListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseListDAL.GetAssetPurchaseListById(assetPurchaseListUI);
        return dtb;
    }

    public DataTable GetAssetPurchaseListBySearchParameters(AssetPurchaseListUI assetPurchaseListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseListDAL.GetAssetPurchaseListBySearchParameters(assetPurchaseListUI);
        return dtb;
    }

    public int DeleteAssetPurchase(AssetPurchaseListUI assetPurchaseListUI)
    {
        int result = 0;
        result = assetPurchaseListDAL.DeleteAssetPurchase(assetPurchaseListUI);
        return result;
    }

    public DataTable GetAssetPurchaseListSearchParameters(AssetPurchaseListUI assetPurchaseListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseListDAL.GetAssetPurchaseListSearchParameters(assetPurchaseListUI);
        return dtb;
    }
}