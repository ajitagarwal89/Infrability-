<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssetDisposalForm.aspx.cs" Inherits="Assets_AssetDisposal_AssetDisposalForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../infra_ui/js/Asset/AssetDisposal_JS/AssetDisposalForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrAssetDisposalInformation" Text="<%$ Resources:GlobalResource, AssetDisposal_ltrAssetDisposalInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAssetDisposalCode" Text="<%$ Resources:GlobalResource, AssetDisposal_lblAssetDisposalCode%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtAssetDisposalCode" ClientIDMode="Static" ReadOnly="true" class="form-control " placeholder="" required=""></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAssetId" Text="<%$ Resources:GlobalResource, AssetDisposal_lblAssetId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtAsset" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_Asset">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAssetSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrencyId" Text="<%$ Resources:GlobalResource, AssetDisposal_lblCurrencyId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCurrency" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_Cuurency">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCurrencySearch" data-keyboard="false" data-backdrop="static" onclick="CallCurrencyRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtCurrencyGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblRetirementDate" Text="<%$ Resources:GlobalResource, AssetDisposal_lblRetirementDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtRetirementDate" ClientIDMode="Static" TextMode="Date" class="form-control " placeholder="" required=""></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_RetirementType" Text="<%$ Resources:GlobalResource, AssetDisposal_lblopt_RetirementType %>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_RetirementType" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblRetirementEvent" Text="<%$ Resources:GlobalResource, AssetDisposal_lblRetirementEvent%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtRetirementEvent" ClientIDMode="Static" class="form-control " placeholder="" required=""></asp:TextBox>
                        </div>
                    </div>

                    <div class="modal fade" id="basicModalAssetSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header" style="text-align: left;">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title" id="hdrModalAssetTitle"><span>
                                        <asp:Literal runat="server" ID="ltrAssetTitle" Text="<%$ Resources:GlobalResource, AssetDisposal_ltrAssetTitle %>"></asp:Literal>
                                    </span>
                                    </h4>
                                </div>
                                <div class="modal-body">

                                    <asp:UpdatePanel runat="server" ID="updpnlAssetSearch">
                                        <ContentTemplate>
                                            <asp:Panel runat="server" ID="pnlAssetSearch" DefaultButton="btnAssetSearch">
                                                <div class="col-md-4 col-xs-5">
                                                    <div class="icon-addon addon-md">
                                                        <asp:TextBox runat="server" ID="txtAssetSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                        <a runat="server" id="btnHtmlAssetSearch" onclick="CallAssetSearch();" class="fa fa-search"></a>
                                                        <a runat="server" id="btnHtmlAssetClose" visible="false" onclick="ClearAssetSearch();" class="fa fa-close closex"></a>
                                                    </div>
                                                </div>
                                                <asp:Button runat="server" ID="btnAssetSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAssetSearch_Click" formnovalidate="formnovalidate" />
                                                <asp:Button runat="server" ID="btnClearAssetSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAssetSearch_Click" formnovalidate="formnovalidate" />

                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <div class="col-md-12 col-sm-12 colformstyle3">
                                        <div runat="server" id="divAssetSearchError" visible="false" class="alert alert-danger" role="alert">
                                            <asp:Label runat="server" ID="lblAssetSearchError"></asp:Label>
                                        </div>
                                        <div runat="server" id="divAssetSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                            <asp:Label runat="server" ID="lblAssetSearchSuccess"></asp:Label>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:UpdateProgress runat="server" ID="updProgAssetData" AssociatedUpdatePanelID="updpnlgvAssetSearch">
                                            <ProgressTemplate>
                                                Loading...
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdatePanel runat="server" ID="updpnlgvAssetSearch">
                                            <ContentTemplate>
                                                <asp:Button runat="server" ID="btnAssetRefresh" ClientIDMode="Static" OnClick="btnAssetRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                                <asp:GridView ID="gvAssetSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetDisposal_htAssetCode%>">
                                                            <ItemTemplate>
                                                                <a href="#" data-dismiss="modal" onclick="SetAssetDetails('<%#Eval("Description")%>','<%#Eval("tbl_AssetId")%>');">

                                                                    <asp:Literal runat="server" ID="ltrgvAssetCode" Text='<%# Bind("AssetCode") %>'></asp:Literal>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,AssetDisposal_htAssetName%>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvAssetName" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetDisposal_htAssetGuid%>" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvAssetGuid" runat="server" Text='<%# Bind("tbl_AssetId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAssetSearch" />
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAssetSearch" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="modal-footer row" runat="server" id="div1">
                                    <div class="pull-left">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">
                                            <asp:Literal runat="server" ID="ltrAssetClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal fade" id="basicModalCurrencySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header" style="text-align: left;">
                                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                    <h4 class="modal-title" id="hdrModalCurrencyTitle"><span>
                                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, AssetDisposal_ltrCurrencyInformation %>"></asp:Literal>
                                    </span>
                                    </h4>
                                </div>
                                <div class="modal-body">

                                    <asp:UpdatePanel runat="server" ID="updpnlCurrency">
                                        <ContentTemplate>
                                            <asp:Panel runat="server" ID="pnlCurrency" DefaultButton="btnCurrencySearch">
                                                <div class="col-md-4 col-xs-5">
                                                    <div class="icon-addon addon-md">
                                                        <asp:TextBox runat="server" ID="txtCurrencySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                        <a runat="server" id="btnHtmlCurrencySearch" onclick="CallCurrencySearch();" class="fa fa-search"></a>
                                                        <a runat="server" id="btnHtmlCurrencyClose" visible="false" onclick="ClearCurrencySearch();" class="fa fa-close closex"></a>
                                                    </div>
                                                </div>
                                                <asp:Button runat="server" ID="btnCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCurrencySearch_Click" formnovalidate="formnovalidate" />
                                                <asp:Button runat="server" ID="btnClearCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCurrencySearch_Click" formnovalidate="formnovalidate" />

                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                    <div class="col-md-12 col-sm-12 colformstyle3">
                                        <div runat="server" id="divCurrencySearchError" visible="false" class="alert alert-danger" role="alert">
                                            <asp:Label runat="server" ID="lblCurrencySearchError"></asp:Label>
                                        </div>
                                        <div runat="server" id="divCurrencySearchSucces" visible="false" class="alert alert-success" role="alert">
                                            <asp:Label runat="server" ID="lblCurrencySearchSucces"></asp:Label>
                                        </div>
                                    </div>
                                    <div>
                                        <asp:UpdateProgress runat="server" ID="updProgCurrencyData" AssociatedUpdatePanelID="updpnlgvCurrencySearch">
                                            <ProgressTemplate>
                                                Loading...
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdatePanel runat="server" ID="updpnlgvCurrencySearch">
                                            <ContentTemplate>
                                                <asp:Button runat="server" ID="btnCurrencyRefresh" ClientIDMode="Static" OnClick="btnCurrencyRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                                <asp:GridView ID="gvCurrencySearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,AssetDisposal_htCurrencyCode%>">
                                                            <ItemTemplate>
                                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyCode") %>'></asp:Literal>
                                                                </a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetDisposal_htCurrencyName%>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvCurrencyName" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetDisposal_htCurrencyGuid%>" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblgvCurrencyGuid" runat="server" Text='<%# Bind("tbl_CurrencyId") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCurrencySearch" />
                                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCurrencySearch" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="modal-footer row" runat="server" id="divCurrencyFooter">
                                    <div class="pull-left">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">
                                            <asp:Literal runat="server" ID="lblCurrencyClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

