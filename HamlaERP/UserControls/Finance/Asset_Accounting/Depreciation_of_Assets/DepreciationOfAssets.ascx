<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DepreciationOfAssets.ascx.cs" Inherits="UserControls_Finance_Asset__Accounting_Depreciation_of_Assets_DepreciationOfAssets" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxDepreciationOfAssets_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxDepreciationOfAssets_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxDepreciationOfAssets_ltrParagraph%>"></asp:Literal>
            </p>
            <div class="row">
                <a class="btn btn-success btn-md"  style="width:250px"  href="../../../../Finance/Asset_Accounting/Depreciation_of_Assets/AssetBookGroupSetupForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAssetBookGroupSetupNew" Text="<%$ Resources:GlobalResource, ascxDepreciationOfAssets_btnAssetBookGroupSetup%>"></asp:Literal>
                </a>
                  <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/Asset_Accounting/Depreciation_of_Assets/AssetBookSetupForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAssetBookSetuptNew" Text="<%$ Resources:GlobalResource, ascxDepreciationOfAssets_btnAssetBookSetup%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/Asset_Accounting/Depreciation_of_Assets/AssetBookForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAssetBookNew" Text="<%$ Resources:GlobalResource,ascxDepreciationOfAssets_btnAssetBook %>"></asp:Literal>
                </a>
            </div>
        </div>
    </div>
  
</div>
