<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FixedAssetPurchase.ascx.cs" Inherits="UserControls_Finance_Asset__Accounting_Fixed_Asset_Purchase_Fixed_Asset_Purchase" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxFixedAssetPurchase_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxFixedAssetPurchase_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxFixedAssetPurchase_ltrParagraph%>"></asp:Literal>
            </p>
            <div class="row">
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/Asset_Accounting/Fixed_Asset_Purchase/AssetPurchaseDetailsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAssetPurchaseDetailsNew" Text="<%$ Resources:GlobalResource, ascxFixedAssetPurchase_btnAssetPurchaseDetails%>"></asp:Literal>
                </a>
                  <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/Asset_Accounting/Fixed_Asset_Purchase/AssetPurchaseDistributionForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAssetPurchaseDistributionNew" Text="<%$ Resources:GlobalResource, ascxFixedAssetPurchase_btnAssetPurchaseDistribution%>"></asp:Literal>
                </a>

                   <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/Asset_Accounting/Fixed_Asset_Purchase/AssetPurchaseForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAssetPurchaseNew" Text="<%$ Resources:GlobalResource, ascxFixedAssetPurchase_btnAssetPurchase%>"></asp:Literal>
                </a>
            </div>
        </div>
    </div>
  
</div>