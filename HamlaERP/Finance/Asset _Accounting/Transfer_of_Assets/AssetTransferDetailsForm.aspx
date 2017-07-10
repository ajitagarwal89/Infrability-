<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssetTransferDetailsForm.aspx.cs" Inherits="Finance_Asset__Accounting_Transfer_of_Assets_AssetTransferDetailsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Asset%20_Accounting_JS/Transfer_of_Assets_JS/AssetTransferDetailsForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrAssetTransferDetailsInformation" Text="<%$ Resources:GlobalResource, AssetTransferDetails_ltrAssetTransferDetailsInformation%>"></asp:Literal></h5>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAssetTransferId" Text="<%$ Resources:GlobalResource, AssetTransferDetails_lblAssetTransferId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtAssetTransfer" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon1">
                                     <a href="#" data-toggle="modal" data-target="#basicModalAssetTransferSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetTransferRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetTransferGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAssetId" Text="<%$ Resources:GlobalResource, AssetTransferDetails_lblAssetId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtAsset" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon2">
                                     <a href="#" data-toggle="modal" data-target="#basicModalAssetSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblUOM" Text="<%$ Resources:GlobalResource, AssetTransferDetails_lblUOM %>"></asp:Label>
                             <asp:TextBox MaxLength="500" type="text" runat="server" ID="txtUOM" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        
                        
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblQuantity" Text="<%$ Resources:GlobalResource, AssetTransferDetails_lblQuantity %>"></asp:Label>
                             <asp:TextBox MaxLength="500" type="text" runat="server" ID="txtQuantity" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, AssetTransferDetails_lblDescription %>"></asp:Label>
                            <asp:TextBox MaxLength="500" TextMode="MultiLine" type="text" runat="server" ID="txtDescription" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        

                            <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblLocationId_From" Text="<%$ Resources:GlobalResource, AssetTransferDetails_lblLocationId_From%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtLocationId_From" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon3">
                                     <a href="#" data-toggle="modal" data-target="#basicModalLocationFromSearch" data-keyboard="false" data-backdrop="static" onclick="CallLocationFromRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtLocation_FromGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                            <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblLocationTo" Text="<%$ Resources:GlobalResource, AssetTransferDetails_lblLocationId_To%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtLocationId_To" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon4">
                                     <a href="#" data-toggle="modal" data-target="#basicModalLocationToSearch" data-keyboard="false" data-backdrop="static" onclick="CallLocationToRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtLocation_ToGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                                                                       
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSubTotal" Text="<%$ Resources:GlobalResource,AssetTransferDetails_lblSubTotal %>"></asp:Label>
                            <asp:TextBox MaxLength="500"  type="text" runat="server" ID="txtSubTotal" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblQuantityAvailable" Text="<%$ Resources:GlobalResource, AssetTransferDetails_lblQuantityAvailable %>"></asp:Label>
                             <asp:TextBox MaxLength="500" type="text" runat="server" ID="txtQuantityAvailable" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                    
                    </div>
                </div>
            </div>

        </div>
    </div>

    <div class="modal fade" id="basicModalAssetTransferSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalAssetTransferTitle"><span>
                        <asp:Literal runat="server" ID="ltrAssetTransferTitle" Text="<%$ Resources:GlobalResource, AssetTransferDetails_lblAssetTransferTitle%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlAssetTransfer">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlAssetTransfer" DefaultButton="btnAssetTransferSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtAssetTransferSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlAssetTransferSearch" onclick="CallAssetTransferSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlAssetTransferClose" visible="false" onclick="ClearAssetTransferSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnAssetTransferSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAssetTransferSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearAssetTransferSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAssetTransferSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divAssetTransferSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblAssetTransferSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divAssetTransferSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblAssetTransferSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgAssetTransferData" AssociatedUpdatePanelID="updpnlgvAssetTransferSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvAssetTransferSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAssetTransferRefresh" ClientIDMode="Static" OnClick="btnAssetTransferRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvAssetTransferSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransferDetails_htDocumentType%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetAssetTransferDetails('<%#Eval("DocumentType")%>','<%#Eval("tbl_AssetTransferId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvDocumentType" Text='<%# Bind("DocumentType") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransferDetails_htNumber %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvNumber" runat="server" Text='<%# Bind("Number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransferDetails_htBatch %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchName" runat="server" Text='<%# Bind("tbl_Batch") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransferDetails_htAssetTransferGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvAssetTransferGuid" runat="server" Text='<%# Bind("tbl_AssetTransferId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAssetTransferSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAssetTransferSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divAssetTransferFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblAssetTransferClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="ltrAssetTitle" Text="<%$ Resources:GlobalResource, AssetTransferDetails_lblAssetTitle%>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransferDetails_htAssetCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetAssetDetails('<%#Eval("Description")%>','<%#Eval("tbl_AssetId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvAssetCode" Text='<%# Bind("AssetCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                   <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransferDetails_htDescription %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvDescription" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransferDetails_htAssetGuid %>" Visible="false">
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

    <div class="modal fade" id="basicModalLocationFromSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalLocationFromTitle"><span>
                        <asp:Literal runat="server" ID="ltrLocationFromTitle" Text="<%$ Resources:GlobalResource, AssetTransferDetails_lblLocationFromTitle%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlLocationFrom">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlLocationFrom" DefaultButton="btnLocationFromSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtLocationFromSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlLocationFromSearch" onclick="CallLocationFromSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlLocationFromClose" visible="false" onclick="ClearLocationFromSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnLocationFromSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnLocationFromSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearLocationFromSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearLocationFromSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divLocationFromSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblLocationFromSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divLocationFromSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblLocationFromSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgLocationFromData" AssociatedUpdatePanelID="updpnlgvLocationFromSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvLocationFromSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnLocationFromRefresh" ClientIDMode="Static" OnClick="btnLocationFromRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvLocationFromSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransferDetails_htLocationCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetLocationFromDetails('<%#Eval("City")%>','<%#Eval("tbl_LocationId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvLocationCode" Text='<%# Bind("LocationCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransferDetails_htCity %>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransferDetails_htLocationFromGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvLocationFromGuid" runat="server" Text='<%# Bind("tbl_LocationId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnLocationFromSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearLocationFromSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divLocationFromFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblLocationFromClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalLocationToSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalLocationToTitle"><span>
                        <asp:Literal runat="server" ID="ltrLocationToTitle" Text="<%$ Resources:GlobalResource, AssetTransferDetails_lblLocationToTitle%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlLocationTo">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlLocationTo" DefaultButton="btnLocationToSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtLocationToSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlLocationToSearch" onclick="CallLocationToSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlLocationToClose" visible="false" onclick="ClearLocationToSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnLocationToSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnLocationToSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearLocationToSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearLocationToSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divLocationToSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblLocationToSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divLocationToSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblLocationToSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgLocationToData" AssociatedUpdatePanelID="updpnlgvLocationToSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvLocationToSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnLocationToRefresh" ClientIDMode="Static" OnClick="btnLocationToRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvLocationToSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransferDetails_htLocationCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetLocationToDetails('<%#Eval("City")%>','<%#Eval("tbl_LocationId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvLocationCode" Text='<%# Bind("LocationCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransferDetails_htCity%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCity" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, AssetTransferDetails_htLocationToGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvLocationToGuid" runat="server" Text='<%# Bind("tbl_LocationId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnLocationToSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearLocationToSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divLocationToFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblLocationToClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

