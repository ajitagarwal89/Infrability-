<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GLAccountFormat.ascx.cs" Inherits="UserControls_System_Settings_GLAccountFormat" %>
<div class="row" style="margin-top: 100px;">
    <div class="col-md-2"></div>
    <div class="col-md-3 slideUp">
        <img src="../images/organisation.png" height="290" />
    </div>
    <div class="col-md-5">
        <div class="jumbotron slideDown">
            <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">
                <asp:Literal runat="server" ID="ltrAddYyour" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_AddYour %>"></asp:Literal>
            </div>
            <br />
            <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">
                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_Information %>"></asp:Literal>
            </div>
            <p>
                <asp:Literal runat="server" ID="ltrParagraph" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_Paragraph %>"></asp:Literal>
            </p>

            <a class="btn btn-success btn-md" style="width: 254px" href="../../System_Settings/GLAccountFormatForm.aspx" role="button">
                <asp:Literal runat="server" ID="ltrGLAccountFormat" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_GLAccountFormat %>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" style="width: 254px" href="../../System_Settings/GLAccountFormatDetialsForm.aspx" role="button">
                <asp:Literal runat="server" ID="ltrGLAccountFormatDetails" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_GLAccountFormatDetails %>"></asp:Literal>
            </a>            
            <a class="btn btn-success btn-md" href="../../System_Settings/Segment01Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment01" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_Segment01 %>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segment02Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment02" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_Segment02 %>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segment03Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment03" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_Segment03 %>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segment04Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment04" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_Segment04 %>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segment05Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment05" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_Segment05 %>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segment06Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment06" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_Segment06%>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segment07Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment07" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_Segment07%>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" href="../../System_Settings/Segment08Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment08" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_Segment08%>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" style="width: 254px" href="../../System_Settings/Segment09Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment09" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_Segment09%>"></asp:Literal>
            </a>
            <a class="btn btn-success btn-md" style="width: 254px" href="../../System_Settings/Segment10Form.aspx" role="button">
                <asp:Literal runat="server" ID="ltrSegment10" Text="<%$ Resources:GlobalResource,ascxGLAccountFormat_Segment10%>"></asp:Literal>
            </a>

        </div>
    </div>
    <div class="col-md-2"></div>
</div>
