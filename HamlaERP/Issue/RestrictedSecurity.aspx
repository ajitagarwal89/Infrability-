<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="RestrictedSecurity.aspx.cs" Inherits="Finware.RestrictedSecurity" Title="System User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div class="row" style="margin-top: 100px;">
            <div class="col-md-2"></div>
            <div class="col-md-3 startimg slideDown">
                <img src="../images/restricted.png" height="270" /></div>
            <div class="col-md-5">
                <div class="jumbotron slideUp">
                    <div style="font-size: 25pt; color: #333; margin-bottom: -40px;">Oops!</div>
                    <br />
                    <div style="font-size: 38pt; font-weight: bold; color: #e26f63;">Restricted Security</div>
                    <p>Please contact your Administrator for more information.</p>
                    .
                </div>
            </div>
            <div class="col-md-2"></div>
        </div>
    </div>
   </asp:Content>
