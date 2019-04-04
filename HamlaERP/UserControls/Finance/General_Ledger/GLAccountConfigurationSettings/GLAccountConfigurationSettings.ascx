<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GLAccountConfigurationSettings.ascx.cs" Inherits="UserControls_Finance_General_Ledger_GLAccountConfigurationSettings_GLAccountConfigurationSettings" %>

<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxGLAccountConfigurationSettings_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxGLAccountConfigurationSettings_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxGLAccountConfigurationSettings_ltrParagraph%>"></asp:Literal>
            </p>
            <div class="row">
                <a class="btn btn-success btn-md" style="width: 200px" href="../../../../Finance/General_Ledger/GLAccountConfigurationSettings/GLAccountConfigurationSettingsForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrGLAccountNew" Text="<%$ Resources:GlobalResource,ascxGLAccountConfigurationSettings_btnGLAccountConfigurationSettings%>"></asp:Literal>
                </a>
             
            </div>
         
        </div>
    </div>
    <div class="col-md-2"></div>
</div>
