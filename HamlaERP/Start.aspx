<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Start.aspx.cs" Inherits="Start" %>
<%@ Register Src="~/usercontrols/System_Settings/Organisation.ascx" TagName="ucst" TagPrefix="ucs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <asp:PlaceHolder runat="server" ID="ph"></asp:PlaceHolder>
    </div>
</asp:Content>

