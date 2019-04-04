using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetTransferDetailsListBAL
/// </summary>
public class AssetTransferDetailsListBAL
{
    AssetTransferDetailsListDAL assetTransferDetailsListDAL = new AssetTransferDetailsListDAL();

    public AssetTransferDetailsListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAssetTransferDetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = assetTransferDetailsListDAL.GetAssetTransferDetailsList();
        return dtb;
    }
    public DataTable GetAssetTransferDetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = assetTransferDetailsListDAL.GetAssetTransferDetailsListForExportToExcel();
        return dtb;
    }
    public DataTable GetAssetTransferDetailsListById(AssetTransferDetailsListUI assetTransferDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetTransferDetailsListDAL.GetAssetTransferDetailsListById(assetTransferDetailsListUI);
        return dtb;
    }

    public DataTable GetAssetTransferDetailsListBySearchParameters(AssetTransferDetailsListUI assetTransferDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetTransferDetailsListDAL.GetAssetTransferDetailsListBySearchParameters(assetTransferDetailsListUI);
        return dtb;
    }

    public int DeleteAssetTransferDetails(AssetTransferDetailsListUI assetTransferDetailsListUI)
    {
        int result = 0;
        result = assetTransferDetailsListDAL.DeleteAssetTransferDetails(assetTransferDetailsListUI);
        return result;
    }

}