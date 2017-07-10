<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Organisation.ascx.cs" Inherits="UserControls_SystemSettings_Organisation" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 startimg slideDown">
        <img src="../../../../images/organisation.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideUp">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYour" Text="<%$ Resources:GlobalResource, ascxOrganisation_ltrAddYour%>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, ascxOrganisation_ltrInformation%>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource, ascxOrganisation_ltrParagraph%>"></asp:Literal>
            </p>
            <div class="row">

                <a class="btn btn-success btn-md" href="../../System_Settings/OrganizationForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrOrganizationNew" Text="<%$ Resources:GlobalResource, btnOrganization%>"></asp:Literal>
                </a>
                <a class="btn btn-success btn-md" href="../../System_Settings/OrganizationTypeForm.aspx" role="button">
                    <asp:Literal runat="server" ID="ltrOrganizationTypeNew" Text="<%$ Resources:GlobalResource, btnOrganizationType%>"></asp:Literal>
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
