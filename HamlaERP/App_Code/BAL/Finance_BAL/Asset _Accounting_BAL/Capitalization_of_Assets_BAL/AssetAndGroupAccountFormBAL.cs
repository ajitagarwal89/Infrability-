using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetAndGroupAccountFormBAL
/// </summary>
public class AssetAndGroupAccountFormBAL
{
    AssetAndGroupAccountFormDAL assetAndGroupAccountFormDAL = new AssetAndGroupAccountFormDAL();
    public AssetAndGroupAccountFormBAL()
    {
       
    }

    public DataTable GetAssetAndGroupAccountListById(AssetAndGroupAccountFormUI assetAndGroupAccountFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetAndGroupAccountFormDAL.GetAssetAndGroupAccountListById(assetAndGroupAccountFormUI);
        return dtb;
    }
    public int AddAssetAndGroupAccount(AssetAndGroupAccountFormUI assetAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = assetAndGroupAccountFormDAL.AddAssetAndGroupAccount(assetAndGroupAccountFormUI);
        return resutl;
    }

    public int UpdateAssetAndGroupAccount(AssetAndGroupAccountFormUI assetAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = assetAndGroupAccountFormDAL.UpdateAssetAndGroupAccount(assetAndGroupAccountFormUI);
        return resutl;
    }

    public int DeleteAssetAndGroupAccount(AssetAndGroupAccountFormUI assetAndGroupAccountFormUI)
    {
        int resutl = 0;
        resutl = assetAndGroupAccountFormDAL.DeleteAssetAndGroupAccount(assetAndGroupAccountFormUI);
        return resutl;
    }
}