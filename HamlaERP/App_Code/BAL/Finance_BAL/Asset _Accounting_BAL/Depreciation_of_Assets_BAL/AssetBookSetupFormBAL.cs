using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetBookSetupFormBAL
/// </summary>
public class AssetBookSetupFormBAL
{
    AssetBookSetupFormDAL assetBookSetupFormDAL = new AssetBookSetupFormDAL();

    public AssetBookSetupFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAssetBookSetupListById(AssetBookSetupFormUI assetBookSetupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetBookSetupFormDAL.GetAssetBookSetupListById(assetBookSetupFormUI);
        return dtb;
    }
    public int AddAssetBookSetup(AssetBookSetupFormUI assetBookSetupFormUI)
    {
        int resutl = 0;
        resutl = assetBookSetupFormDAL.AddAssetBookSetup(assetBookSetupFormUI);
        return resutl;
    }

    public int UpdateAssetBookSetup(AssetBookSetupFormUI assetBookSetupFormUI)
    {
        int resutl = 0;
        resutl = assetBookSetupFormDAL.UpdateAssetBookSetup(assetBookSetupFormUI);
        return resutl;
    }

    public int DeleteAssetBookSetup(AssetBookSetupFormUI assetBookSetupFormUI)
    {
        int resutl = 0;
        resutl = assetBookSetupFormDAL.DeleteAssetBookSetup(assetBookSetupFormUI);
        return resutl;
    }
}