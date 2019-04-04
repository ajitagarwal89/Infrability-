<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AuditSettingForm.aspx.cs" Inherits="System_Settings_AuditSettingForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate" />
                    <asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" formnovalidate="formnovalidate"></asp:Button>
                </div>
            </div>
        </div>

        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad">
                        <asp:Label runat="server" ID="lblHeading"></asp:Label></h3>
                    <div class="col-md-12 col-sm-12 colformstyle">
                        <div runat="server" id="divError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblError"></asp:Label>
                        </div>
                        <div runat="server" id="divSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                        </div>
                        <div class="form-group col-md-12" style="background-color: #f6f6f6">
                            <h5>
                                <asp:Literal runat="server" ID="ltrBatchInformation" Text="<%$ Resources:GlobalResource, AuditSetting_ltrInformation%>"></asp:Literal></h5>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTables" Text="<%$ Resources:GlobalResource, OptionSet_lblTablesName%>"></asp:Label>
                            <asp:DropDownList ID="ddlTables" runat="server" ClientIDMode="Static" class="form-control " placeholder=""
                                required="required" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label ID="lblObjectName" runat="server" Text="<%$ Resources:GlobalResource, AuditSetting_lblObjectName %>"></asp:Label>
                            <asp:TextBox ID="txtObjectName" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" autofocus="autofocus" ReadOnly="true"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblEnableAudit" Text="<%$ Resources:GlobalResource, AuditSetting_lblEnableAudit %>"></asp:Label>

                            <asp:CheckBox ID="chkEnableAudit" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                        </div>

                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

