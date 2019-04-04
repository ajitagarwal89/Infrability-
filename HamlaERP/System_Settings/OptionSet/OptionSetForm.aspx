﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="OptionSetForm.aspx.cs" Inherits="System_Settings_OptionSetForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../infra_ui/js/System_Settings_JS/OptionSetForm.js"></script>
    <script src="../infra_ui/js/CommonJS/CommonValidations.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button runat="server" ID="btnAuditHistory" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnAuditHistory%>" formnovalidate="formnovalidate" OnClick="btnAuditHistory_Click" />
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
                                <asp:Literal runat="server" ID="ltrBatchInformation" Text="<%$ Resources:GlobalResource, OptionSet_ltrOptionSetInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTables" Text="<%$ Resources:GlobalResource, OptionSet_lblTablesName%>"></asp:Label>
                            <asp:DropDownList ID="ddlTables" runat="server" ClientIDMode="Static" class="form-control " placeholder=""
                                required="required" AutoPostBack="True" OnSelectedIndexChanged="ddlTables_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTableName" Text="<%$ Resources:GlobalResource, OptionSet_lblSelecetdTable %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtTableName" ReadOnly="true" ClientIDMode="Static" class="form-control "></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTableObjectId" Text="<%$ Resources:GlobalResource, OptionSet_lblTableObjectId %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtTableObjectId" ReadOnly="true" ClientIDMode="Static" class="form-control "></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblColumnsByTables" Text="<%$ Resources:GlobalResource, OptionSet_lblColumnsByTables%>"></asp:Label>
                            <asp:DropDownList ID="ddlColoumnByTable" runat="server" ClientIDMode="Static" class="form-control " placeholder=""
                                required="required" AutoPostBack="True" OnSelectedIndexChanged="ddlColoumnByTable_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOptionSetName" Text="<%$ Resources:GlobalResource, OptionSet_lblOptionSetName%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtOptionSetName" ReadOnly="true" ClientIDMode="Static" AutoPostBack="true" onkeypress="return isAddress(this);" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblColumn" Text="<%$ Resources:GlobalResource, OptionSet_lblColumn%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtColumn" ReadOnly="true" ClientIDMode="Static" class="form-control "></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOptionSetLable" Text="<%$ Resources:GlobalResource, OptionSet_lblOptionSetLable%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtOptionSetLable" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOptionSetValue" Text="<%$ Resources:GlobalResource, OptionSet_lblOptionSetValue%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtOptionSetValue" ClientIDMode="Static" class="form-control" TextMode="Number" onkeypress="return isNumberKey(this);" placeholder="" required="required"></asp:TextBox>
                        </div>



                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

