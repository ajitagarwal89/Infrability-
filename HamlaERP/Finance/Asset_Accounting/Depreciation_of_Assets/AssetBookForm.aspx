<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssetBookForm.aspx.cs" Inherits="Asset_AssetBookForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Asset%20_Accounting_JS/Capitalization_of_Assets_JS/AssetBookForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrAssetBookInformation" Text="<%$ Resources:GlobalResource, AssetBook_ltrAssetBookInformation%>"></asp:Literal></h5>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAssetId" Text="<%$ Resources:GlobalResource, AssetBook_lblAssetId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtAsset" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon1">
                                     <a href="#" data-toggle="modal" data-target="#basicModalAssetSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                      
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAssetBookCode" Text="<%$ Resources:GlobalResource, AssetBook_lblAssetBookCode %>"></asp:Label>
                            <asp:TextBox   type="text" runat="server" ID="txtAssetBookCode" ClientIDMode="Static" ReadOnly="true" onkeypress="return isAlphaNumberKey(this);" MaxLength="20" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                            
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPlaceInServiceDate" Text="<%$ Resources:GlobalResource,AssetBook_lblPlaceInServiceDate %>"></asp:Label>
                            <asp:TextBox  TextMode="Date"  type="text" runat="server" ID="txtPlaceInServiceDate" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                      <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDepreciatedDueDate" Text="<%$ Resources:GlobalResource,AssetBook_lblDepreciatedDueDate %>"></asp:Label>
                            <asp:TextBox  TextMode="Date"  type="text" runat="server" ID="txtDepreciatedDueDate" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                      <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblBeginYearCost" Text="<%$ Resources:GlobalResource,AssetBook_lblBeginYearCost %>"></asp:Label>
                            <asp:TextBox  type="text" runat="server" ID="txtBeginYearCost" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCostBasis" Text="<%$ Resources:GlobalResource,AssetBook_lblCostBasis %>"></asp:Label>
                            <asp:TextBox   type="text" runat="server" ID="txtCostBasis" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblScrapValue" Text="<%$ Resources:GlobalResource,AssetBook_lblScrapValue %>"></asp:Label>
                            <asp:TextBox   type="text" runat="server" ID="txtScrapValue" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblYearlyDepreciationRate" Text="<%$ Resources:GlobalResource,AssetBook_lblYearlyDepreciationRate %>"></asp:Label>
                            <asp:TextBox    type="text" runat="server" ID="txtYearlyDepreciationRate" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCurrentDepreciation" Text="<%$ Resources:GlobalResource,AssetBook_lblCurrentDepreciation %>"></asp:Label>
                            <asp:TextBox  type="text" runat="server" ID="txtCurrentDepreciation" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblNetBookValue" Text="<%$ Resources:GlobalResource,AssetBook_lblNetBookValue %>"></asp:Label>
                            <asp:TextBox   type="text" runat="server" ID="txtNetBookValue" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                         </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_DepreciationMethod" Text="<%$ Resources:GlobalResource,AssetBook_lblopt_DepreciationMethod %>"></asp:Label>
                            <asp:DropDownList ID="ddlopt_DepreciationMethod" runat="server" ClientIDMode="Static"  class="form-control" required="required"></asp:DropDownList>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_AveragingConvention" Text="<%$ Resources:GlobalResource,AssetBook_lblopt_AveragingConvention %>"></asp:Label>
                             <asp:DropDownList ID="ddlopt_AveragingConvention" runat="server" ClientIDMode="Static" class="form-control" required="required"></asp:DropDownList>
                        </div>
                        
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFullDepreciationFlag" Text="<%$ Resources:GlobalResource, AssetBook_lblFullDepreciationFlag %>"></asp:Label>
                             <asp:CheckBox ID="chkFullDepreciationFlag" runat="server" ClientIDMode="Static" class="form-control" required="required" /> 
                        </div>                    
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_Status" Text="<%$ Resources:GlobalResource, AssetBook_lblopt_Status %>"></asp:Label>
                             <asp:DropDownList ID="ddlopt_Status" runat="server" ClientIDMode="Static" class="form-control" required="required"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOriginalLifeYear" Text="<%$ Resources:GlobalResource, AssetBook_lblOriginalLifeYear %>"></asp:Label>
                             <asp:TextBox  type="text" runat="server" ID="txtOriginalLifeYear" ClientIDMode="Static" onkeypress="return isNumberKey(this);" MaxLength="1" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOriginalLifeDay" Text="<%$ Resources:GlobalResource, AssetBook_lblOriginalLifeDay %>"></asp:Label>
                             <asp:TextBox  type="text" runat="server" ID="txtOriginalLifeDay" ClientIDMode="Static" onkeypress="return isNumberKey(this);" MaxLength="1" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                    
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div class="modal fade" id="basicModalAssetSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalAssetTitle"><span>
                        <asp:Literal runat="server" ID="ltrAssetTitle" Text="<%$ Resources:GlobalResource, AssetBook_lblAssetTitle%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlAsset">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlAsset" DefaultButton="btnAssetSearch">
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
                        <div runat="server" id="divAssetSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblAssetSearchSucces"></asp:Label>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetBook_htAssetCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetAssetDetails('<%#Eval("Description")%>','<%#Eval("tbl_AssetId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvAssetCode" Text='<%# Bind("AssetCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                   <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetBook_htDescription %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetBook_htAssetGuid %>" Visible="false">
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
                <div class="modal-footer row" runat="server" id="divAssetFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblAssetClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

