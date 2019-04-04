<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssetPurchaseDetailsForm.aspx.cs" Inherits="Assets_AssetPurchaseDetails_AssetPurchaseDetailsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Asset%20_Accounting_JS/Fixed_Asset_Purchase_JS/AssetPurchaseDetailsForm.js"></script>
	<script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
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
                                <asp:Literal runat="server" ID="ltrAssetPurchaseDetailsInformation" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_ltrInformation%>"></asp:Literal></h5>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                              <div>
                         <div>
                                <asp:Label runat="server" ID="lblAssetPurchase" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_lblAssetPurchase %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtAssetPurchase" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon1">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAssetPurchaseSearch" data-keyboard="false" data-backdrop="static" onclick="CallPONumberRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetPurchaseGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                                  </div>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                              <div>
                         <div>
                                <asp:Label runat="server" ID="lblPONumber" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_lblPONumber %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPONumber" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPONumberSearch" data-keyboard="false" data-backdrop="static" onclick="CallPONumberRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPONumberGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                                  </div>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAssetId" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_lblAssetId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtAsset" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_Cuurency">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAssetSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblLocationId" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_lblLocationId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtLocation" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon6">
                                    <a href="#" data-toggle="modal" data-target="#basicModalLocationSearch" data-keyboard="false" data-backdrop="static" onclick="CallLocationRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtLocationGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblUOM" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_lblUOM%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtUOM" ClientIDMode="Static" class="form-control " placeholder=""  onkeypress="return isAlphaKey(this);" maxlength="20" required="required"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_lblDescription%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" ClientIDMode="Static" class="form-control " placeholder="" onkeypress="return isAddress(this);" maxlength="100" required="required"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblQuantityOrdered" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_lblQuantityOrdered%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtQuantityOrdered" ClientIDMode="Static" class="form-control " placeholder="" onkeypress="return isNumberKeyPoint(this);" maxlength="9" required="required"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblQuantityShipped" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_lblQuantityShipped%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtQuantityShipped" ClientIDMode="Static" class="form-control " placeholder="" onkeypress="return isNumberKeyPoint(this);" maxlength="9" required="required"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblQuantityInvoiced" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_lblQuantityInvoiced%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtQuantityInvoiced" ClientIDMode="Static" class="form-control " placeholder="" onkeypress="return isNumberKeyPoint(this);" maxlength="9" required="required"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPreviouslyShipped" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_lblPreviouslyShipped%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPreviouslyShipped" ClientIDMode="Static" class="form-control " placeholder=""  onkeypress="return isNumberKeyPoint(this);" maxlength="9" required="required"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPreviouslyInvoiced" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_lblPreviouslyInvoiced%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPreviouslyInvoiced" ClientIDMode="Static" class="form-control " placeholder="" onkeypress="return isNumberKeyPoint(this);" maxlength="9" required="required"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblUnitCost" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_lblUnitCost%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtUnitCost" ClientIDMode="Static" class="form-control " placeholder="" onkeypress="return isNumberKeyPoint(this);" maxlength="9" required="required"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblExtendedCost" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_lblExtendedCost%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtExtendedCost" ClientIDMode="Static" class="form-control " placeholder="" onkeypress="return isNumberKeyPoint(this);" maxlength="9" required="required"></asp:TextBox>
                        </div>   
                        
                                            
                      <div class="modal fade" id="basicModalAssetPurchaseSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="hdrModalAssetPurchaseTitle"><span>
                                <asp:Literal runat="server" ID="ltrAssetPurchaseTitle" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_ltrAssetPurchaseTitle %>"></asp:Literal>
                            </span>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="updpnlAssetPurchaseSearch">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="pnlAssetPurchaseSearch" DefaultButton="btnAssetPurchaseSearch">
                                        <div class="col-md-4 col-xs-5">
                                            <div class="icon-addon addon-md">
                                                <asp:TextBox runat="server" ID="txtAssetPurchaseSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                <a runat="server" id="btnHtmlAssetPurchaseSearch" onclick="CallAssetPurchaseSearch();" class="fa fa-search"></a>
                                                <a runat="server" id="btnHtmlAssetPurchaseClose" visible="false" onclick="ClearAssetPurchaseSearch();" class="fa fa-close closex"></a>
                                            </div>
                                        </div>
                                        <asp:Button runat="server" ID="btnAssetPurchaseSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAssetPurchaseSearch_Click" formnovalidate="formnovalidate" />
                                        <asp:Button runat="server" ID="btnClearAssetPurchaseSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAssetPurchaseSearch_Click" formnovalidate="formnovalidate" />

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divAssetPurchaseSearchError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblAssetPurchaseSearchError"></asp:Label>
                                </div>
                                <div runat="server" id="divAssetPurchaseSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblAssetPurchaseSearchSuccess"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress runat="server" ID="updProgAssetPurchaseData" AssociatedUpdatePanelID="updpnlgvAssetPurchaseSearch">
                                    <ProgressTemplate>
                                        Loading...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updpnlgvAssetPurchaseSearch">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnAssetPurchaseRefresh" ClientIDMode="Static" OnClick="btnAssetPurchaseRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                        <asp:GridView ID="gvAssetPurchaseSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetPurchaseDetails_htAssetPurchaseCode%>">
                                                    <ItemTemplate>
                                                        <a href="#" data-dismiss="modal" onclick="SetAssetPurchaseDetails('<%#Eval("ReceiptNumber")%>','<%#Eval("tbl_AssetPurchaseId")%>');">

                                                            <asp:Literal runat="server" ID="ltrgvAssetPurchaseCode" Text='<%# Bind("ReceiptNumber") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                             <%--   <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,AssetPurchaseDetails_htAssetPurchaseName%>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAssetPurchaseName" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetPurchaseDetails_htAssetPurchaseGuid%>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAssetPurchaseGuid" runat="server" Text='<%# Bind("tbl_AssetPurchaseId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAssetPurchaseSearch" />
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAssetPurchaseSearch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer row" runat="server" id="div4">
                            <div class="pull-left">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    <asp:Literal runat="server" ID="ltrAssetPurchaseClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


                     <div class="modal fade" id="basicModalPONumberSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="hdrModalPONumberTitle"><span>
                                <asp:Literal runat="server" ID="ltrPONumberTitle" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_ltrPONumberTitle %>"></asp:Literal>
                            </span>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="updpnlPONumberSearch">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="pnlPONumberSearch" DefaultButton="btnPONumberSearch">
                                        <div class="col-md-4 col-xs-5">
                                            <div class="icon-addon addon-md">
                                                <asp:TextBox runat="server" ID="txtPONumberSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                <a runat="server" id="btnHtmlPONumberSearch" onclick="CallPONumberSearch();" class="fa fa-search"></a>
                                                <a runat="server" id="btnHtmlPONumberClose" visible="false" onclick="ClearPONumberSearch();" class="fa fa-close closex"></a>
                                            </div>
                                        </div>
                                        <asp:Button runat="server" ID="btnPONumberSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPONumberSearch_Click" formnovalidate="formnovalidate" />
                                        <asp:Button runat="server" ID="btnClearPONumberSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPONumberSearch_Click" formnovalidate="formnovalidate" />

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divPONumberSearchError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblPONumberSearchError"></asp:Label>
                                </div>
                                <div runat="server" id="divPONumberSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblPONumberSearchSuccess"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress runat="server" ID="updProgPONumberData" AssociatedUpdatePanelID="updpnlgvPONumberSearch">
                                    <ProgressTemplate>
                                        Loading...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updpnlgvPONumberSearch">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnPONumberRefresh" ClientIDMode="Static" OnClick="btnPONumberRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                        <asp:GridView ID="gvPONumberSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetPurchaseDetails_htPONumberCode%>">
                                                    <ItemTemplate>
                                                        <a href="#" data-dismiss="modal" onclick="SetPONumberDetails('<%#Eval("PONumber")%>','<%#Eval("tbl_POId")%>');">

                                                            <asp:Literal runat="server" ID="ltrgvPONumberCode" Text='<%# Bind("PONumber") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               <%-- <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,AssetPurchaseDetails_htPONumberName%>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPONumberName" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetPurchaseDetails_htPONumberGuid%>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPONumberGuid" runat="server" Text='<%# Bind("tbl_POId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPONumberSearch" />
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPONumberSearch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer row" runat="server" id="div2">
                            <div class="pull-left">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    <asp:Literal runat="server" ID="ltrPONumberClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                                <asp:Literal runat="server" ID="ltrAssetTitle" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_ltrAssetTitle %>"></asp:Literal>
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
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetPurchaseDetails_htAssetCode%>">
                                                    <ItemTemplate>
                                                        <a href="#" data-dismiss="modal" onclick="SetAssetDetails('<%#Eval("Description")%>','<%#Eval("tbl_AssetId")%>');">

                                                            <asp:Literal runat="server" ID="ltrgvAssetCode" Text='<%# Bind("AssetCode") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,AssetPurchaseDetails_htAssetName%>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAssetName" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetPurchaseDetails_htAssetGuid%>" Visible="false">
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

                    <div class="modal fade" id="basicModalLocationSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="hdrModalLocationTitle"><span>
                                <asp:Literal runat="server" ID="ltrLocationTitle" Text="<%$ Resources:GlobalResource, AssetPurchaseDetails_ltrLocationTitle %>"></asp:Literal>
                            </span>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="updpnlLocationSearch">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="pnlLocationSearch" DefaultButton="btnLocationSearch">
                                        <div class="col-md-4 col-xs-5">
                                            <div class="icon-addon addon-md">
                                                <asp:TextBox runat="server" ID="txtLocationSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                <a runat="server" id="btnHtmlLocationSearch" onclick="CallLocationSearch();" class="fa fa-search"></a>
                                                <a runat="server" id="btnHtmlLocationClose" visible="false" onclick="ClearLocationSearch();" class="fa fa-close closex"></a>
                                            </div>
                                        </div>
                                        <asp:Button runat="server" ID="btnLocationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnLocationSearch_Click" formnovalidate="formnovalidate" />
                                        <asp:Button runat="server" ID="btnClearLocationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearLocationSearch_Click" formnovalidate="formnovalidate" />

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divLocationSearchError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblLocationSearchError"></asp:Label>
                                </div>
                                <div runat="server" id="divLocationSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblLocationSearchSuccess"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress runat="server" ID="updProgLocationData" AssociatedUpdatePanelID="updpnlgvLocationSearch">
                                    <ProgressTemplate>
                                        Loading...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updpnlgvLocationSearch">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnLocationRefresh" ClientIDMode="Static" OnClick="btnLocationRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                        <asp:GridView ID="gvLocationSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetPurchaseDetails_htLocationCode%>">
                                                    <ItemTemplate>
                                                        <a href="#" data-dismiss="modal" onclick="SetLocationDetails('<%#Eval("Description")%>','<%#Eval("tbl_LocationId")%>');">

                                                            <asp:Literal runat="server" ID="ltrgvLocationCode" Text='<%# Bind("LocationCode") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,AssetPurchaseDetails_htLocationName%>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvLocationName" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetPurchaseDetails_htLocationGuid%>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvLocationGuid" runat="server" Text='<%# Bind("tbl_LocationId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnLocationSearch" />
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearLocationSearch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer row" runat="server" id="div3">
                            <div class="pull-left">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    <asp:Literal runat="server" ID="ltrLocationClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                            </div>
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

