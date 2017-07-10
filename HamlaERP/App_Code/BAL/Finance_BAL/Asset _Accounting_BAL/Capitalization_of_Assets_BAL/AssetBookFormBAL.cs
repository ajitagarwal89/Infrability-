using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetBookFormBAL
/// </summary>
public class AssetBookFormBAL
{
    AssetBookFormDAL assetBookFormDAL = new AssetBookFormDAL();
    public AssetBookFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetBookListById(AssetBookFormUI assetBookFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetBookFormDAL.GetAssetBookListById(assetBookFormUI);
        return dtb;
    }

    public int AddAssetBook(AssetBookFormUI assetBookFormUI)
    {
        int resutl = 0;
        resutl = assetBookFormDAL.AddAssetBook(assetBookFormUI);
        return resutl;
    }

    public int UpdateAssetBook(AssetBookFormUI assetBookFormUI)
    {
        int resutl = 0;
        resutl = assetBookFormDAL.UpdateAssetBook(assetBookFormUI);
        return resutl;
    }

    public int DeleteAssetBook(AssetBookFormUI assetBookFormUI)
    {
        int resutl = 0;
        resutl = assetBookFormDAL.DeleteAssetBook(assetBookFormUI);
        return resutl;
    }

}