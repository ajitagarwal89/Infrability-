<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TransferofAssets.ascx.cs" Inherits="UserControls_Finance_Asset__Accounting_Transfer_of_Assets_Transfer_of_Assets" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxTransferofAssets_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxTransferofAssets_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxTransferofAssets_ltrParagraph%>"></asp:Literal>
            </p>

            <p>
               
              <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/Asset_Accounting/Transfer_of_Assets/AssetTransferForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAssetTransfer" Text="<%$ Resources:GlobalResource,ascxTransferofAssets_btnAssetTransfer%>"></asp:Literal>
                </a>
              <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/Asset_Accounting/Transfer_of_Assets/AssetTransferDetailsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAssetTransferDetails" Text="<%$ Resources:GlobalResource, ascxTransferofAssets_btnAssetTransferDetails%>"></asp:Literal>
                </a> 

            </p>
        </div>
    </div>
   
</div>