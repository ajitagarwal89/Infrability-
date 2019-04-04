<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CapitalizationofAssets.ascx.cs" Inherits="UserControls_Finance_Asset__Accounting_Capitalization_of_Assets_Capitalization_of_Assets" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxCapitalizationofAssets_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxCapitalizationofAssets_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxCapitalizationofAssets_ltrParagraph%>"></asp:Literal>
            </p>

            <p>
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/Asset_Accounting/Capitalization_of_Assets/AssetAndGroupAccountForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAssetAndGroupAccount" Text="<%$ Resources:GlobalResource, ascxCapitalizationofAssets_btnAssetAndGroupAccount%>"></asp:Literal>
                </a>
              
                    <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/Asset_Accounting/Capitalization_of_Assets/AssetForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAssetNew" Text="<%$ Resources:GlobalResource,ascxCapitalizationofAssets_btnAsset %>"></asp:Literal>
                </a>
                   <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/Asset_Accounting/Capitalization_of_Assets/AssetGroupForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAssetGroupNew" Text="<%$ Resources:GlobalResource,ascxCapitalizationofAssets_btnAssetGroup %>"></asp:Literal>
                </a>                                 

            </p>
        </div>
    </div>
   
</div>
