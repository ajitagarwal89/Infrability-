using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for AssetFormBAL
/// </summary>
public class AssetFormBAL
{
    AssetFormDAL assetFormDAL = new AssetFormDAL();

    public AssetFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetListById(AssetFormUI assetFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetFormDAL.GetAssetListById(assetFormUI);
        return dtb;
    }
    public int AddAsset(AssetFormUI assetFormUI)
    {
        int resutl = 0;
        resutl = assetFormDAL.AddAsset(assetFormUI);
        return resutl;
    }

    public int UpdateAsset(AssetFormUI assetFormUI)
    {
        int resutl = 0;
        resutl = assetFormDAL.UpdateAsset(assetFormUI);
        return resutl;
    }

    public int DeleteAsset(AssetFormUI assetFormUI)
    {
        int resutl = 0;
        resutl = assetFormDAL.DeleteAsset(assetFormUI);
        return resutl;
    }
}