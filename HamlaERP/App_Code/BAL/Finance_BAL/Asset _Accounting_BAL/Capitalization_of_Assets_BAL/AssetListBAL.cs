using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for AssetListBAL
/// </summary>
public class AssetListBAL
{
    AssetListDAL assetListDAL = new AssetListDAL();
    public AssetListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetList()
    {
        DataTable dtb = new DataTable();
        dtb = assetListDAL.GetAssetList();
        return dtb;
    }

    public DataTable GetAssetListById(AssetListUI assetListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetListDAL.GetAssetListById(assetListUI);
        return dtb;
    }

    public DataTable GetAssetListSearchParameters(AssetListUI assetListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetListDAL.GetAssetListSearchParameters(assetListUI);
        return dtb;
    }

    public int DeleteAsset(AssetListUI assetListUI)
    {
        int result = 0;
        result = assetListDAL.DeleteAsset(assetListUI);
        return result;
    }

    public DataTable GetAssetListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = assetListDAL.GetAssetListForExportToExcel();
        return dtb;
    }
}