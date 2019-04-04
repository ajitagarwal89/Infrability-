using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetGroupForm
/// </summary>
public class AssetGroupFormBAL
{

    AssetGroupFormDAL assetGroupFormDAL = new AssetGroupFormDAL();

    public AssetGroupFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetGroupListById(AssetGroupFormUI assetGroupFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetGroupFormDAL.GetAssetGroupListById(assetGroupFormUI);
        return dtb;
    }

    public int AddAssetGroup(AssetGroupFormUI assetGroupFormUI)
    {
        int resutl = 0;
        resutl = assetGroupFormDAL.AddAssetGroup(assetGroupFormUI);
        return resutl;
    }

    public int UpdateAssetGroup(AssetGroupFormUI assetGroupFormUI)
    {
        int resutl = 0;
        resutl = assetGroupFormDAL.UpdateAssetGroup(assetGroupFormUI);
        return resutl;
    }

    public int DeleteAssetGroup(AssetGroupFormUI assetGroupFormUI)
    {
        int resutl = 0;
        resutl = assetGroupFormDAL.DeleteAssetGroup(assetGroupFormUI);
        return resutl;
    }
}