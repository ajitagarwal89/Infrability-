using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetDisposalDetailsFormBAL
/// </summary>
public class AssetDisposalDetailsFormBAL
{
    AssetDisposalDetailsFormDAL assetDisposalDetailsFormDAL = new AssetDisposalDetailsFormDAL();
    public AssetDisposalDetailsFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetDisposalDetailsListById(AssetDisposalDetailsFormUI assetDisposalDetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetDisposalDetailsFormDAL.GetAssetDisposalDetailsListById(assetDisposalDetailsFormUI);
        return dtb;
    }

    public int AddAssetDisposalDetails(AssetDisposalDetailsFormUI assetDisposalDetailsFormUI)
    {
        int resutl = 0;
        resutl = assetDisposalDetailsFormDAL.AddAssetDisposalDetails(assetDisposalDetailsFormUI);
        return resutl;
    }

    public int UpdateAssetDisposalDetails(AssetDisposalDetailsFormUI assetDisposalDetailsFormUI)
    {
        int resutl = 0;
        resutl = assetDisposalDetailsFormDAL.UpdateAssetDisposalDetails(assetDisposalDetailsFormUI);
        return resutl;
    }

    public int DeleteAssetDisposalDetails(AssetDisposalDetailsFormUI assetDisposalDetailsFormUI)
    {
        int resutl = 0;
        resutl = assetDisposalDetailsFormDAL.DeleteAssetDisposalDetails(assetDisposalDetailsFormUI);
        return resutl;
    }

}