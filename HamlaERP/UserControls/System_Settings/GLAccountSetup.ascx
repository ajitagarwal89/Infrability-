<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GLAccountSetup.ascx.cs" Inherits="UserControls_System_Settings_GLAccountFormat" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 slideUp">
        <img src="../images/organisation.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideDown">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYyour" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_ltrAddYour %>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_ltrInformation %>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_ltrParagraph %>"></asp:Literal>
            </p>

            <a class="btn btn-success btn-md" style="width: 254px" href="../../System_Settings/GLAccount/AccountFormatForm.aspx" role="button">
                <asp:Literal runat="server" ID="ltrAccountFormat" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_btnAccountFormat %>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" style="width: 254px" href="../../System_Settings/GLAccount/AccountFormatDetailsForm.aspx" role="button">
                <asp:Literal runat="server" ID="ltrAccountFormatDetails" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_btnAccountFormatDetails %>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segments/Segment01Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment01" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_btnSegment01 %>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segments/Segment02Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment02" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_btnSegment02 %>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segments/Segment03Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment03" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_btnSegment03 %>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segments/Segment04Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment04" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_btnSegment04 %>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segments/Segment05Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment05" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_btnSegment05 %>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segments/Segment06Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment06" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_btnSegment06%>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segments/Segment07Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment07" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_btnSegment07%>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segments/Segment08Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment08" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_btnSegment08%>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" style="width: 254px" href="../../System_Settings/Segments/Segment09Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment09" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_btnSegment09%>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" style="width: 254px" href="../../System_Settings/Segments/Segment10Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment10" Text="<%$ Resources:GlobalResource,ascxGLAccountSetup_btnSegment10%>"></asp:Literal>
            </a>
           
        </div>
    </div>
    <div class="col-md-2"></div>
</div>
