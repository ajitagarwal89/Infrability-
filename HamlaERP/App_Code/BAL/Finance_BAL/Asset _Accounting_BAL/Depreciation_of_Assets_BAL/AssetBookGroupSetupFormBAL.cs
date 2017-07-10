using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetBookGroupSetupFormBAL
/// </summary>
public class AssetBookGroupSetupFormBAL
{

    AssetBookGroupSetupFormDAL assetBookGroupSetupFormDAL = new AssetBookGroupSetupFormDAL();
    public AssetBookGroupSetupFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetBookGroupSetupListById(AssetBookGroupSetupFormUI assetBookGroupSetupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetBookGroupSetupFormDAL.GetAssetBookGroupSetupListById(assetBookGroupSetupFormUI);
        return dtb;
    }
    public int AddAssetBookGroupSetup(AssetBookGroupSetupFormUI assetBookGroupSetupFormUI)
    {
        int resutl = 0;
        resutl = assetBookGroupSetupFormDAL.AddAssetBookGroupSetup(assetBookGroupSetupFormUI);
        return resutl;
    }

    public int UpdateAssetBookGroupSetup(AssetBookGroupSetupFormUI assetBookGroupSetupFormUI)
    {
        int resutl = 0;
        resutl = assetBookGroupSetupFormDAL.UpdateAssetBookGroupSetup(assetBookGroupSetupFormUI);
        return resutl;
    }

    public int DeleteAssetBookGroupSetup(AssetBookGroupSetupFormUI assetBookGroupSetupFormUI)
    {
        int result = 0;
        result = assetBookGroupSetupFormDAL.DeleteAssetBookGroupSetup(assetBookGroupSetupFormUI);
        return result;
    }
}