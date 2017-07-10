using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssetBookGroupSetupListBAL
/// </summary>
public class AssetBookGroupSetupListBAL
{
    AssetBookGroupSetupListDAL assetBookGroupSetupListDAL = new AssetBookGroupSetupListDAL();
    public AssetBookGroupSetupListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetBookGroupSetupList()
    {
        DataTable dtb = new DataTable();
        dtb = assetBookGroupSetupListDAL.GetAssetBookGroupSetupList();
        return dtb;
    }

    public DataTable GetAssetBookGroupSetupListById(AssetBookGroupSetupListUI assetBookGroupSetupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetBookGroupSetupListDAL.GetAssetBookGroupSetupListById(assetBookGroupSetupListUI);
        return dtb;
    }
   
    public DataTable GetAssetBookGroupSetupListBySearchParameters(AssetBookGroupSetupListUI assetBookGroupSetupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetBookGroupSetupListDAL.GetAssetBookGroupSetupListSearchParameters(assetBookGroupSetupListUI);
        return dtb;
    }

    public int DeleteAssetBookGroupSetup(AssetBookGroupSetupListUI assetBookGroupSetupListUI)
    {
        int result = 0;
        result = assetBookGroupSetupListDAL.DeleteAssetBookGroupSetup(assetBookGroupSetupListUI);
        return result;
    }

    public DataTable GetAssetBookGroupSetupListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = assetBookGroupSetupListDAL.GetAssetBookGroupSetupListForExportToExcel();
        return dtb;
    }

}