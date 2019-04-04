<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Auditing.ascx.cs" Inherits="UserControls_System_Settings_Auditing" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/organisation.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxAuditing_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxAuditing_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxAuditing_ltrParagraph%>"></asp:Literal>
            </p>
            <div class="row">
              
                <a class="btn btn-success btn-md"  style="width:250px" href="../../System_Settings/Audit/AuditSettingForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAuditSettingFormNew" Text="<%$ Resources:GlobalResource,ascxAuditing_btnAuditSetting%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md"  style="width:250px" href="../../System_Settings/Audit/Audit_IUDList.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrAuditHistoryList" Text="<%$ Resources:GlobalResource,ascxAuditing_btnAuditHistoryList%>"></asp:Literal>
                </a>               
            </div>
            <p>
            </p>
            <p>
            </p>
        </div>
    </div>
</div>
