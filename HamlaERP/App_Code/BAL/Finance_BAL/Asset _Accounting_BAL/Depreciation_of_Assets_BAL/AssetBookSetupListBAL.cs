using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AssetBookSetupListBAL
/// </summary>
public class AssetBookSetupListBAL
{

    AssetBookSetupListDAL assetBookSetupListDAL = new AssetBookSetupListDAL();
    public AssetBookSetupListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAssetBookSetupList()
    {
        DataTable dtb = new DataTable();
        dtb = assetBookSetupListDAL.GetAssetBookSetupList();
        return dtb;
    }

    public DataTable GetAssetBookSetupListById(AssetBookSetupListUI assetBookSetupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetBookSetupListDAL.GetAssetBookSetupListById(assetBookSetupListUI);
        return dtb;
    }

    public DataTable GetAssetBookSetupListSearchParameters(AssetBookSetupListUI assetBookSetupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetBookSetupListDAL.GetAssetBookSetupListSearchParameters(assetBookSetupListUI);
        return dtb;
    }

    public int DeleteAssetBookSetup(AssetBookSetupListUI assetBookSetupListUI)
    {
        int result = 0;
        result = assetBookSetupListDAL.DeleteAssetBookSetup(assetBookSetupListUI);
        return result;
    }
    public DataTable GetAssetBookSetupListForRecordId(AssetBookSetupListUI assetBookSetupListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetBookSetupListDAL.GetAssetBookSetupListForRecordId(assetBookSetupListUI);
        return dtb;
    }
    public DataTable GetAssetBookSetupListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = assetBookSetupListDAL.GetAssetBookSetupListForExportToExcel();
        return dtb;
    }
}