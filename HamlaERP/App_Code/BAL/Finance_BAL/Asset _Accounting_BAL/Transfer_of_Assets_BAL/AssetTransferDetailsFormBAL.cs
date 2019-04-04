using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetTransferDetailsFormBAL
/// </summary>
public class AssetTransferDetailsFormBAL
{
    AssetTransferDetailsFormDAL assetTransferDetailsFormDAL = new AssetTransferDetailsFormDAL();
    public AssetTransferDetailsFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAssetTransferDetailsListById(AssetTransferDetailsFormUI assetTransferDetailsFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetTransferDetailsFormDAL.GetAssetTransferDetailsListById(assetTransferDetailsFormUI);
        return dtb;
    }

    public int AddAssetTransferDetails(AssetTransferDetailsFormUI assetTransferDetailsFormUI)
    {
        int resutl = 0;
        resutl = assetTransferDetailsFormDAL.AddAssetTransferDetails(assetTransferDetailsFormUI);
        return resutl;
    }

    public int UpdateAssetTransferDetails(AssetTransferDetailsFormUI assetTransferDetailsFormUI)
    {
        int resutl = 0;
        resutl = assetTransferDetailsFormDAL.UpdateAssetTransferDetails(assetTransferDetailsFormUI);
        return resutl;
    }

    public int DeleteAssetTransferDetails(AssetTransferDetailsFormUI assetTransferDetailsFormUI)
    {
        int resutl = 0;
        resutl = assetTransferDetailsFormDAL.DeleteAssetTransferDetails(assetTransferDetailsFormUI);
        return resutl;
    }

}