<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ReceivableSetup.ascx.cs" Inherits="UserControls_System_Settings_ReceivableSetup" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxReceivableSetup_ltrAddYour%>"></asp:Literal>
            </div>

            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxReceivableSetup_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxReceivableSetup_ltrParagraph%>"></asp:Literal>
            </p>
            <div class="row">
                
                <a class="btn btn-success btn-md" style="width:200px"  href="../../System_Settings/ReceivableSetup/ReceivableSetupAndGroupAccountForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrReceivableSetupAndGroupAccount" Text="<%$ Resources:GlobalResource, ascxReceivableSetup_ltrReceivableSetupAndGroupAccount%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width:200px"  href="../../System_Settings/ReceivableSetup/ReceivableConfigurationSettingForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrReceivableSetup" Text="<%$ Resources:GlobalResource, ascxReceivableSetup_ltrReceivableSetup%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width:200px"  href="../../System_Settings/ReceivableSetup/ReceivableSetupGroupForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrReceivableSetupGroup" Text="<%$ Resources:GlobalResource, ascxReceivableSetup_ltrReceivableSetupGroup%>"></asp:Literal>
                </a>
            </div>
            <p>
            </p>
            <p>
            </p>
        </div>
    </div>
    <div class="col-md-2"></div>
</div>
