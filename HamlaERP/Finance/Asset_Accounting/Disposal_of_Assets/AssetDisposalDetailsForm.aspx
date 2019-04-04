<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssetDisposalDetailsForm.aspx.cs" Inherits="Finance_Asset__Accounting_Disposal_of_Assets_AssetDisposalDetailsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Asset%20_Accounting_JS/Disposal_of_Assets_JS/AssetDisposalDetailsForm.js"></script>
    <script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">

      <div id="content" class="ui-content ui-content-aside-overlay">

        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate" />
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
                                <asp:Literal runat="server" ID="ltrAssetDisposalDetailsInformation" Text="<%$ Resources:GlobalResource, AssetDisposalDetails_ltrAssetDisposalDetailsInformation%>"></asp:Literal></h5>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAssetDisposalId" Text="<%$ Resources:GlobalResource, AssetDisposalDetails_lblAssetDisposalId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtAssetDisposal" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon1">
                                     <a href="#" data-toggle="modal" data-target="#basicModalAssetDisposalSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetDisposalRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetDisposalGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                      
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblQuantity" Text="<%$ Resources:GlobalResource, AssetDisposalDetails_lblQuantity %>"></asp:Label>
                            <asp:TextBox   type="text" runat="server" ID="txtQuantity" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                            
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCost" Text="<%$ Resources:GlobalResource,AssetDisposalDetails_lblCost %>"></asp:Label>
                            <asp:TextBox  type="text" runat="server" ID="txtCost" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                      <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPercent" Text="<%$ Resources:GlobalResource,AssetDisposalDetails_lblPercent %>"></asp:Label>
                            <asp:TextBox   type="text" runat="server" ID="txtPercent" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                      <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCashProceeds" Text="<%$ Resources:GlobalResource,AssetDisposalDetails_lblCashProceeds %>"></asp:Label>
                            <asp:TextBox   type="text" runat="server" ID="txtCashProceeds" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblNonCashProceeds" Text="<%$ Resources:GlobalResource,AssetDisposalDetails_lblNonCashProceeds %>"></asp:Label>
                            <asp:TextBox    type="text" runat="server" ID="txtNonCashProceeds" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblExpensesOfSales" Text="<%$ Resources:GlobalResource,AssetDisposalDetails_lblExpensesOfSales %>"></asp:Label>
                            <asp:TextBox   type="text" runat="server" ID="txtExpensesOfSales" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOriginatingAmount" Text="<%$ Resources:GlobalResource,AssetDisposalDetails_lblOriginatingAmount %>"></asp:Label>
                            <asp:TextBox   type="text" runat="server" ID="txtOriginatingAmount" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div class="modal fade" id="basicModalAssetDisposalSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalAssetDisposalTitle"><span>
                        <asp:Literal runat="server" ID="ltrAssetDisposalTitle" Text="<%$ Resources:GlobalResource, AssetDisposalDetails_lblAssetDisposalTitle%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlAssetDisposal">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlAssetDisposal" DefaultButton="btnAssetDisposalSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtAssetDisposalSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlAssetDisposalSearch" onclick="CallAssetDisposalSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlAssetDisposalClose" visible="false" onclick="ClearAssetDisposalSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnAssetDisposalSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAssetDisposalSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearAssetDisposalSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAssetDisposalSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divAssetDisposalSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblAssetDisposalSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divAssetDisposalSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblAssetDisposalSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgAssetDisposalData" AssociatedUpdatePanelID="updpnlgvAssetDisposalSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvAssetDisposalSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAssetDisposalRefresh" ClientIDMode="Static" OnClick="btnAssetDisposalRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvAssetDisposalSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetDisposalDetails_htAssetDisposalCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetAssetDisposalDetails('<%#Eval("AssetDisposalCode")%>','<%#Eval("tbl_AssetDisposalId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvAssetDisposalCode" Text='<%# Bind("AssetDisposalCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                   <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetDisposalDetails_htAsset %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvAsset" runat="server" Text='<%# Bind("tbl_Asset") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetDisposalDetails_htAssetDisposalGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvAssetDisposalGuid" runat="server" Text='<%# Bind("tbl_AssetDisposalId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAssetDisposalSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAssetDisposalSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divAssetDisposalFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblAssetDisposalClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

