<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SupplierForm.aspx.cs" Inherits="Finance_Accounts_Payable_Supplier_Master_Creation_SupplierForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/Supplier_Master_Creation_JS/SupplierForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, Supplier_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSupplierCode" Text="<%$ Resources:GlobalResource, Supplier_lblSupplierCode %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtSupplierCode" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblName" Text="<%$ Resources:GlobalResource, Supplier_lblName %>">></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtName" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblShortName" Text="<%$ Resources:GlobalResource, Supplier_lblShortName %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtShortName" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblChequeName" Text="<%$ Resources:GlobalResource, Supplier_lblChequeName %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtChequeName" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblContact" Text="<%$ Resources:GlobalResource, Supplier_lblContact %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtContact" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAddress" Text="<%$ Resources:GlobalResource, Supplier_lblAddress %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtAddress" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCity" Text="<%$ Resources:GlobalResource, Supplier_lblCity %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtCity" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCountry" Text="<%$ Resources:GlobalResource, Supplier_lblCountry%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCountry" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon2">
                                     <a href="#" data-toggle="modal" data-target="#basicModalCountrySearch" data-keyboard="false" data-backdrop="static" onclick="CallRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox runat="server" ID="txtCountryGuid" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblZipCode" Text="<%$ Resources:GlobalResource, Supplier_lblZipCode %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtZipCode" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>

                       

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPhone" Text="<%$ Resources:GlobalResource, Supplier_lblPhone %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtPhone" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblMobile" Text="<%$ Resources:GlobalResource, Supplier_lblMobile %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtMobile" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFaxNo" Text="<%$ Resources:GlobalResource, Supplier_lblFaxNo %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtFaxNo" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblEmail" Text="<%$ Resources:GlobalResource, Supplier_lblEmail %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtEmail" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblComment1" Text="<%$ Resources:GlobalResource, Supplier_lblComment1 %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtComment1" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblComment2" Text="<%$ Resources:GlobalResource, Supplier_lblComment2 %>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtComment2" ClientIDMode="Static" class="form-control " placeholder="" required></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblSupplierGroup" Text="<%$ Resources:GlobalResource, Supplier_lblSupplierGroup%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtSupplierGroup" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="spnSupplierGroup">
                                    <a href="#" data-toggle="modal" data-target="#basicModalSupplierGroupSearch" data-keyboard="false" data-backdrop="static" onclick="CallSupplierGroupRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>
                                <asp:TextBox runat="server" ID="txtSupplierGroupGuid" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-8 col-sm-8">
                            <div class="form-group col-md-4 col-sm-4">
                                <asp:Label runat="server" ID="lblStatus" Text="<%$ Resources:GlobalResource, Supplier_lblStatus%>"></asp:Label>
                                <asp:DropDownList ID="ddlStatus" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required>
                                </asp:DropDownList>
                            </div>

                            <div class="form-group col-md-4 col-sm-4">
                                <asp:Label runat="server" ID="lblOnHold" Text="<%$ Resources:GlobalResource, Supplier_chkOnHold%>"></asp:Label>
                                <asp:CheckBox ID="chkOnHold" runat="server"   ClientIDMode="Static" class="form-control " placeholder="" required />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalCountrySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCountryTitle"><span>
                        <asp:Literal runat="server" ID="ltrCountryTitle" Text="<%$ Resources:GlobalResource, ltrCountry %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCountrySearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCountrySearch" DefaultButton="btnCountrySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCountrySearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
                                        <a runat="server" id="btnHtmlCountrySearch" onclick="CallCountrySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCountryClose" visible="false" onclick="ClearCountrySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCountrySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCountrySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCountrySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCountrySearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCountrySearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCountrySearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCountrySearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCountrySearchSuccess"></asp:Label>
                        </div>
                    </div>

                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgData" AssociatedUpdatePanelID="updpnlgvCountrySearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCountrySearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCountryRefresh" ClientIDMode="Static" OnClick="btnCountryRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCountrySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,htCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCountryDetails('<%#Eval("CountryName")%>','<%#Eval("tbl_CountryId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCountryCode" Text='<%# Bind("CountryCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,htName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCountryName" runat="server" Text='<%# Bind("CountryName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Country Guid" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCountryGuid" runat="server" Text='<%# Bind("tbl_CountryId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCountrySearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCountrySearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrCountryClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalSupplierGroupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalSupplierGroupTitle"><span>
                        <asp:Literal runat="server" ID="ltrSupplierGroupTitle" Text="<%$ Resources:GlobalResource, Supplier_ltrSupplierGroup%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlSupplierGroup">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlSupplierGroup" DefaultButton="btnSupplierGroupSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSupplierGroupSearch" CssClass="form-control" placeholder="Search..." autofocus></asp:TextBox>
                                        <a runat="server" id="btnHtmlSupplierGroupSearch" onclick="CallSupplierGroupSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlSupplierGroupClose" visible="false" onclick="ClearSupplierGroupSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnSupplierGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnSupplierGroupSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearSupplierGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearSupplierGroupSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divSupplierGroupSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblSupplierGroupSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divSupplierGroupSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSupplierGroupSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgSupplierGroupData" AssociatedUpdatePanelID="updpnlgvSupplierGroupSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvSupplierGroupSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnSupplierGroupRefresh" ClientIDMode="Static" OnClick="btnSupplierGroupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvSupplierGroupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,htName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetSupplierGroupDetails('<%#Eval("Description")%>','<%#Eval("tbl_SupplierGroupId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvSupplierGroupCode" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Supplier Group Guid" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSupplierGroupGuid" runat="server" Text='<%# Bind("tbl_SupplierGroupId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSupplierGroupSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearSupplierGroupSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divSupplierGroupFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblSupplierGroupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

