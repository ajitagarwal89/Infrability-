using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for AssetBookListBAL
/// </summary>
public class AssetBookListBAL
{
    AssetBookListDAL assetBookListDAL = new AssetBookListDAL();

    public AssetBookListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetBookList()
    {
        DataTable dtb = new DataTable();
        dtb = assetBookListDAL.GetAssetBookList();
        return dtb;
    }
    public DataTable GetAssetBookListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = assetBookListDAL.GetAssetBookListForExportToExcel();
        return dtb;
    }
    public DataTable GetAssetBookListById(AssetBookListUI assetBookListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetBookListDAL.GetAssetBookListById(assetBookListUI);
        return dtb;
    }

    public DataTable GetAssetBookListBySearchParameters(AssetBookListUI assetBookListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetBookListDAL.GetAssetBookListBySearchParameters(assetBookListUI);
        return dtb;
    }

    public int DeleteAssetBook(AssetBookListUI assetBookListUI)
    {
        int result = 0;
        result = assetBookListDAL.DeleteAssetBook(assetBookListUI);
        return result;
    }
}