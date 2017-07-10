using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for AssetDisposalFormBAL
/// </summary>
public class AssetDisposalFormBAL
{
    AssetDisposalFormDAL assetDisposalFormDAL = new AssetDisposalFormDAL();
    public AssetDisposalFormBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetAssetDisposalListById(AssetDisposalFormUI assetDisposalFormUI)
    {
        DataTable dtb = new DataTable();
        dtb = assetDisposalFormDAL.GetAssetDisposalListById(assetDisposalFormUI);
        return dtb;
    }
    public int AddAssetDisposal(AssetDisposalFormUI assetDisposalFormUI)
    {
        int resutl = 0;
        resutl = assetDisposalFormDAL.AddAssetDisposal(assetDisposalFormUI);
        return resutl;
    }

    public int UpdateAssetDisposal(AssetDisposalFormUI assetDisposalFormUI)
    {
        int resutl = 0;
        resutl = assetDisposalFormDAL.UpdateAssetDisposal(assetDisposalFormUI);
        return resutl;
    }

    public int DeleteAssetDisposal(AssetDisposalFormUI assetDisposalFormUI)
    {
        int resutl = 0;
        resutl = assetDisposalFormDAL.DeleteAssetDisposal(assetDisposalFormUI);
        return resutl;
    }
}