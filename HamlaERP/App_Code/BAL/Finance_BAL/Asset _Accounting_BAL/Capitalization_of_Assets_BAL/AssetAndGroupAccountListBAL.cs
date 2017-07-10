using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for AssetAndGroupAccountListBAL
/// </summary>
public class AssetAndGroupAccountListBAL
{
    AssetAndGroupAccountListDAL assetAndGroupAccountListDAL = new AssetAndGroupAccountListDAL();

    public AssetAndGroupAccountListBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAssetAndGroupAccountList()
    {
        DataTable dtb = new DataTable();
        dtb = assetAndGroupAccountListDAL.GetAssetAndGroupAccountList();
        return dtb;
    }

    public DataTable GetAssetAndGroupAccountListById(AssetAndGroupAccountListUI assetAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetAndGroupAccountListDAL.GetAssetAndGroupAccountListById(assetAndGroupAccountListUI);
        return dtb;
    }

    public DataTable GetAssetAndGroupAccountListBySearchParameters(AssetAndGroupAccountListUI assetAndGroupAccountListUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetAndGroupAccountListDAL.GetAssetAndGroupAccountListBySearchParameters(assetAndGroupAccountListUI);
        return dtb;
    }

    public int DeleteAssetAndGroupAccount(AssetAndGroupAccountListUI assetAndGroupAccountListUI)
    {
        int result = 0;
        result = assetAndGroupAccountListDAL.DeleteAssetAndGroupAccount(assetAndGroupAccountListUI);
        return result;
    }

    public DataTable GetAssetAndGroupAccountListForExportToExcel()
    {
        DataTable dtb = new DataTable();
        dtb = assetAndGroupAccountListDAL.GetAssetAndGroupAccountListForExportToExcel();
        return dtb;
    }
}