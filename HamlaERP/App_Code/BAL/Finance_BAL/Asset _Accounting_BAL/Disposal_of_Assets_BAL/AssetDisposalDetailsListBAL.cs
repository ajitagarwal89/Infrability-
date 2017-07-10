using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetDisposalDetailsListBAL
/// </summary>
public class AssetDisposalDetailsListBAL
{
    AssetDisposalDetailsListDAL assetDisposalDetailsListDAL = new AssetDisposalDetailsListDAL();
    public AssetDisposalDetailsListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetDisposalDetailsList()
    {
        DataTable dtb = new DataTable();
        dtb = assetDisposalDetailsListDAL.GetAssetDisposalDetailsList();
        return dtb;
    }
    public DataTable GetAssetDisposalDetailsListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = assetDisposalDetailsListDAL.GetAssetDisposalDetailsListForExportToExcel();
        return dtb;
    }
    public DataTable GetAssetDisposalDetailsListById(AssetDisposalDetailsListUI assetDisposalDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetDisposalDetailsListDAL.GetAssetDisposalDetailsListById(assetDisposalDetailsListUI);
        return dtb;
    }

    public DataTable GetAssetDisposalDetailsListBySearchParameters(AssetDisposalDetailsListUI assetDisposalDetailsListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetDisposalDetailsListDAL.GetAssetDisposalDetailsListBySearchParameters(assetDisposalDetailsListUI);
        return dtb;
    }

    public int DeleteAssetDisposalDetails(AssetDisposalDetailsListUI assetDisposalDetailsListUI)
    {
        int result = 0;
        result = assetDisposalDetailsListDAL.DeleteAssetDisposalDetails(assetDisposalDetailsListUI);
        return result;
    }

}