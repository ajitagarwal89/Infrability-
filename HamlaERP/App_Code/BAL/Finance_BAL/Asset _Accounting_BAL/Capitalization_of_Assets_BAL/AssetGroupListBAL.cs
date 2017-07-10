using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetGroupListBLL
/// </summary>
public class AssetGroupListBAL
{

    AssetGroupListDAL assetGroupListDAL = new AssetGroupListDAL();

    public AssetGroupListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetGroupList()
    {
        DataTable dtb = new DataTable();
        dtb = assetGroupListDAL.GetAssetGroupList();
        return dtb;
    }

    public DataTable GetAssetGroupListById(AssetGroupListUI assetGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetGroupListDAL.GetAssetGroupListById(assetGroupListUI);
        return dtb;
    }

    public DataTable GetAssetGroupListBySearchParameters(AssetGroupListUI assetGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetGroupListDAL.GetAssetGroupListBySearchParameters(assetGroupListUI);
        return dtb;
    }

    public int DeleteAssetGroup(AssetGroupListUI assetGroupListUI)
    {
        int result = 0;
        result = assetGroupListDAL.DeleteAssetGroup(assetGroupListUI);
        return result;
    }

    public DataTable GetAssetGroupListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = assetGroupListDAL.GetAssetGroupListForExportToExcel();
        return dtb;
    }

    public DataTable AssetGroupListBySearchParameters(AssetGroupListUI assetGroupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetGroupListDAL.AssetGroupListBySearchParameters(assetGroupListUI);
        return dtb;
    }

}