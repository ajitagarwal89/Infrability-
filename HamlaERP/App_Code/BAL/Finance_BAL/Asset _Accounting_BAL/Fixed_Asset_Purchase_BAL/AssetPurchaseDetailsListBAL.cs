using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for AssetPurchaseDetailsListBAL
/// </summary>
public class AssetPurchaseDetailsListBAL
{
    AssetPurchaseDetailsListDAL assetPurchaseDetailsListDAL = new AssetPurchaseDetailsListDAL();

    public AssetPurchaseDetailsListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetPurchaseDetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseDetailsListDAL.GetAssetPurchaseDetailsList();
        return dtb;
    }

    public DataTable GeAssetPurchaseDetailsListById(AssetPurchaseDetailsListUI assetPurchaseDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseDetailsListDAL.GetAssetPurchaseDetailsListById(assetPurchaseDetailsListUI);
        return dtb;
    }

    public DataTable GetAssetPurchaseDetailsListSearchParameters(AssetPurchaseDetailsListUI assetPurchaseDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseDetailsListDAL.GetAssetPurchaseDetailsListSearchParameters(assetPurchaseDetailsListUI);
        return dtb;
    }

    public int DeleteAssetPurchaseDetails(AssetPurchaseDetailsListUI assetPurchaseDetailsListUI)
    {
        int result = 0;
        result = assetPurchaseDetailsListDAL.DeleteAssetPurchaseDetails(assetPurchaseDetailsListUI);
        return result;
    }

    public DataTable GetAssetPurchaseDetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseDetailsListDAL.GetAssetPurchaseDetailsListForExportToExcel();
        return dtb;
    }
}