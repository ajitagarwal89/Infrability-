<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PayableSetup.ascx.cs" Inherits="UserControls_System_Settings_PayableSetup" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/supplier.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxPayableSetup_ltrAddYour%>"></asp:Literal>
            </div>

            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxPayableSetup_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxPayableSetup_ltrParagraph%>"></asp:Literal>
            </p>
            <div class="row">
                <a class="btn btn-success btn-md" style="width:200px"  href="../../System_Settings/Payables/PayablesForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrPayables" Text="<%$ Resources:GlobalResource, ascxPayableSetup_ltrPayables%>"></asp:Literal>
                </a>

                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/Payables/PayableSetupAndGroupAccountForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrPayableSetupAndGroupAccount" Text="<%$ Resources:GlobalResource, ascxPayableSetup_ltrPayableSetupAndGroupAccount%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" style="width:200px"  href="../../System_Settings/Payables/PayableSetupForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrPayableSetup" Text="<%$ Resources:GlobalResource, ascxPayableSetup_ltrPayableSetup%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:200px" href="../../System_Settings/Payables/PayableSetupGroupForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrPayableSetupGroup" Text="<%$ Resources:GlobalResource, ascxPayableSetup_ltrPayableSetupGroup%>"></asp:Literal>
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
