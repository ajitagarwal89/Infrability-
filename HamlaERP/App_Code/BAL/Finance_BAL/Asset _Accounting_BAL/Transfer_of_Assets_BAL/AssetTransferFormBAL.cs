using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetTransferForm
/// </summary>
public class AssetTransferFormBAL
{

    AssetTransferFormDAL assetTransferFormDAL = new AssetTransferFormDAL();

    public AssetTransferFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetTransferListById(AssetTransferFormUI assetTransferFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetTransferFormDAL.GetAssetTransferListById(assetTransferFormUI);
        return dtb;
    }

    public int AddAssetTransfer(AssetTransferFormUI assetTransferFormUI)
    {
        int resutl = 0;
        resutl = assetTransferFormDAL.AddAssetTransfer(assetTransferFormUI);
        return resutl;
    }

    public int UpdateAssetTransfer(AssetTransferFormUI assetTransferFormUI)
    {
        int resutl = 0;
        resutl = assetTransferFormDAL.UpdateAssetTransfer(assetTransferFormUI);
        return resutl;
    }

    public int DeleteAssetTransfer(AssetTransferFormUI assetTransferFormUI)
    {
        int resutl = 0;
        resutl = assetTransferFormDAL.DeleteAssetTransfer(assetTransferFormUI);
        return resutl;
    }

    public DataTable GetSerialNumber(AssetTransferFormUI assetTransferFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetTransferFormDAL.GetSerialNumber(assetTransferFormUI);
        return dtb;
    }
    public int UpdatePostingAssetTransfer(AssetTransferFormUI assetTransferFormUI)
    {
        int resutl = 0;
        resutl = assetTransferFormDAL.UpdatePostingAssetTransfer(assetTransferFormUI);
        return resutl;
    }
}