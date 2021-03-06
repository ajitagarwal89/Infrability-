﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Segment08Form.aspx.cs" Inherits="System_Settings_Segment08Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../infra_ui/js/System_Settings_JS/Segment08Form.js"></script>
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
                                <asp:Literal runat="server" ID="ltrSegment08Information" Text="<%$ Resources:GlobalResource, Segment08_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblNumber" Text="<%$ Resources:GlobalResource, Segment08_lblNumber%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtNumber" ClientIDMode="Static" class="form-control" placeholder="" required="required" autofocus="autofocus" onkeypress="CheckNumeric(event);"  ></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, Segment08_lblDescription%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDescription" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSegment01" Text="<%$ Resources:GlobalResource, Segment02_lblSegment01%>"></asp:Label>
                            <asp:DropDownList ID="ddlSegment01" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required" OnSelectedIndexChanged="ddlSegment01_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSegment02" Text="<%$ Resources:GlobalResource, Segment02_lblSegment01%>"></asp:Label>
                            <asp:DropDownList ID="ddlSegment02" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required" OnSelectedIndexChanged="ddlSegment02_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSegment03" Text="<%$ Resources:GlobalResource, Segment02_lblSegment01%>"></asp:Label>
                            <asp:DropDownList ID="ddlSegment03" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required" OnSelectedIndexChanged="ddlSegment03_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSegment04" Text="<%$ Resources:GlobalResource, Segment02_lblSegment01%>"></asp:Label>
                            <asp:DropDownList ID="ddlSegment04" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required" OnSelectedIndexChanged="ddlSegment04_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSegment05" Text="<%$ Resources:GlobalResource, Segment02_lblSegment01%>"></asp:Label>
                            <asp:DropDownList ID="ddlSegment05" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required" OnSelectedIndexChanged="ddlSegment05_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSegment06" Text="<%$ Resources:GlobalResource, Segment02_lblSegment01%>"></asp:Label>
                            <asp:DropDownList ID="ddlSegment06" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required" OnSelectedIndexChanged="ddlSegment06_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSegment07" Text="<%$ Resources:GlobalResource, Segment02_lblSegment01%>"></asp:Label>
                            <asp:DropDownList ID="ddlSegment07" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>


</asp:Content>

