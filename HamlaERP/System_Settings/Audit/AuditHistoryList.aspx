<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AuditHistoryList.aspx.cs" Inherits="System_Settings_AuditHistoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <div class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:LinkButton runat="server" ID="lnkBack" CssClass="btn btn-success" OnClick="lnkBack_Click">
                        <asp:Literal runat="server" ID="ltrBack" Text="<%$Resources:GlobalResource, AuditHistory_ltrBack%>"></asp:Literal>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad">
                        <asp:Literal runat="server" ID="ltrAuditHistoryList" Text="<%$ Resources:GlobalResource, AuditHistoryList_ltrAuditHistoryList %>"></asp:Literal></h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblError"></asp:Label>
                        </div>
                        <div runat="server" id="divSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                        </div>
                        <div class="table-responsive">
                            <asp:DataGrid ID="gvData" ClientIDMode="Static" Font-Size="10pt" Font-Names="Arial" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" runat="server" Width="100%" GridLines="None" BorderStyle="None">
                                <Columns>
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, AuditHistoryList_CreatedOn%>" DataField="HeldOn" ItemStyle-Width="10%" HeaderStyle-Width="10%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, AuditHistoryList_CreatedBy%>" DataField="UserName" ItemStyle-Width="10%" HeaderStyle-Width="10%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, AuditHistoryList_Operation%>" DataField="Operation" ItemStyle-Width="10%" HeaderStyle-Width="10%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, AuditHistoryList_htOldValue%>" DataField="OldValue" ItemStyle-Width="30%" HeaderStyle-Width="30%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, AuditHistoryList_htNewValue%>" DataField="NewValue" ItemStyle-Width="30%" HeaderStyle-Width="30%"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, AuditHistoryList_htOrganizationName%>" DataField="OrganizationName" ItemStyle-Width="10%" HeaderStyle-Width="10%"></asp:BoundColumn>
                                </Columns>
                                <HeaderStyle BorderStyle="Solid" />
                            </asp:DataGrid>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
