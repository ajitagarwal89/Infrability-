using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetPurchaseDetailsFormBAL
/// </summary>
public class AssetPurchaseDetailsFormBAL
{
    AssetPurchaseDetailsFormDAL assetPurchaseDetailsFormDAL = new AssetPurchaseDetailsFormDAL();
    public AssetPurchaseDetailsFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetPurchaseDetailsListById(AssetPurchaseDetailsFormUI assetPurchaseDetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetPurchaseDetailsFormDAL.GetAssetPurchaseDetailsListById(assetPurchaseDetailsFormUI);
        return dtb;
    }
    public int AddAssetPurchaseDetails(AssetPurchaseDetailsFormUI assetPurchaseDetailsFormUI)
    {
        int resutl = 0;
        resutl = assetPurchaseDetailsFormDAL.AddAssetPurchaseDetails(assetPurchaseDetailsFormUI);
        return resutl;
    }

    public int UpdateAssetPurchaseDetails(AssetPurchaseDetailsFormUI assetPurchaseDetailsFormUI)
    {
        int resutl = 0;
        resutl = assetPurchaseDetailsFormDAL.UpdateAssetPurchaseDetails(assetPurchaseDetailsFormUI);
        return resutl;
    }

    public int DeleteAssetPurchaseDetails(AssetPurchaseDetailsFormUI assetPurchaseDetailsFormUI)
    {
        int resutl = 0;
        resutl = assetPurchaseDetailsFormDAL.DeleteAssetPurchaseDetails(assetPurchaseDetailsFormUI);
        return resutl;
    }
}