using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetTransferListBAL
/// </summary>
public class AssetTransferListBAL
{

    AssetTransferListDAL assetTransferListDAL = new AssetTransferListDAL();

    public AssetTransferListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetTransferList()
    {
        DataTable dtb = new DataTable();
        dtb = assetTransferListDAL.GetAssetTransferList();
        return dtb;
    }

    public DataTable GetAssetTransferListById(AssetTransferListUI assetTransferListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetTransferListDAL.GetAssetTransferListById(assetTransferListUI);
        return dtb;
    }

    public DataTable GetAssetTransferListBySearchParameters(AssetTransferListUI assetTransferListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetTransferListDAL.GetAssetTransferListBySearchParameters(assetTransferListUI);
        return dtb;
    }

    public int DeleteAssetTransfer(AssetTransferListUI assetTransferListUI)
    {
        int result = 0;
        result = assetTransferListDAL.DeleteAssetTransfer(assetTransferListUI);
        return result;
    }

    public DataTable GetAssetTransferListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = assetTransferListDAL.GetAssetTransferListForExportToExcel();
        return dtb;
    }

}