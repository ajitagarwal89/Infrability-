using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for AssetDisposalListBAL
/// </summary>
public class AssetDisposalListBAL
{
    AssetDisposalListDAL assetDisposalListDAL = new AssetDisposalListDAL();
    public AssetDisposalListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetDisposalList()
    {
        DataTable dtb = new DataTable();
        dtb = assetDisposalListDAL.GetAssetDisposalList();
        return dtb;
    }

    public DataTable GetAssetDisposalListById(AssetDisposalListUI assetDisposalListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetDisposalListDAL.GetAssetDisposalListById(assetDisposalListUI);
        return dtb;
    }

    public DataTable GetAssetDisposalListSearchParameters(AssetDisposalListUI assetDisposalListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetDisposalListDAL.GetAssetDisposalListSearchParameters(assetDisposalListUI);
        return dtb;
    }

    public int DeleteAssetDisposal(AssetDisposalListUI assetDisposalListUI)
    {
        int result = 0;
        result = assetDisposalListDAL.DeleteAssetDisposal(assetDisposalListUI);
        return result;
    }

    public DataTable GetAssetDisposalListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = assetDisposalListDAL.GetAssetDisposalListForExportToExcel();
        return dtb;
    }

}