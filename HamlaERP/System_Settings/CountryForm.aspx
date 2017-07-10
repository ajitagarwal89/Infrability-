<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CountryForm.aspx.cs" Inherits="System_Settings_CountryForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../infra_ui/js/System_Settings_JS/CountryForm.js"></script>
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
                      <asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" formnovalidate="formnovalidate" ></asp:Button>
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
                                <asp:Literal runat="server" ID="ltr_Countryinformation" Text="<%$ Resources:GlobalResource, Country_ltrinformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-xs-12">
                            <asp:Label ID="lblCountryCode" runat="server"  Text="<%$ Resources:GlobalResource, Country_lblCode %>"></asp:Label>
                            <asp:TextBox ID="txtCountryCode" runat="server"  ClientIDMode="Static" class="form-control" placeholder="" autofocus="autofocus" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-xs-12">
                            <asp:Label runat="server" ID="lblCountryName" Text="<%$ Resources:GlobalResource, Country_lblName %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtCountryName" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

