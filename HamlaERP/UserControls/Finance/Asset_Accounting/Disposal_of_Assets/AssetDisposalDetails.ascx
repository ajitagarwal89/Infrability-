<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssetDisposalDetails.ascx.cs" Inherits="UserControls_Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetails" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxAssetDisposalDetails_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxAssetDisposalDetails_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxAssetDisposalDetails_ltrParagraph%>"></asp:Literal>
            </p>
            <div class="row">
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/Asset_Accounting/Disposal_of_Assets/AssetDisposalForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAssetDisposal" Text="<%$ Resources:GlobalResource, ascxAssetDisposalDetails_btnAssetDisposal%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:250px"  href="../../../../Finance/Asset_Accounting/Disposal_of_Assets/AssetDisposalDetailsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAssetDisposalDetails" Text="<%$ Resources:GlobalResource, ascxAssetDisposalDetails_btnAssetDisposalDetails%>"></asp:Literal>
                </a>
                  
            </div>
        </div>
    </div>
  
</div>
