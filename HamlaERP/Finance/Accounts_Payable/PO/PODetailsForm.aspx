<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PODetailsForm.aspx.cs" Inherits="Finance_Accounts_Payable_PO_PODetailsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/PO_JS/PODetailsForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" formnovalidate="formnovalidate" />
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
                                <asp:Literal runat="server" ID="ltrPODetails" Text="<%$ Resources:GlobalResource, PODetails_ltrInformation%>"></asp:Literal></h5>
                        </div>



                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblPOId" Text="<%$ Resources:GlobalResource, PODetails_lblPOId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPOId" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPOSearch" data-keyboard="false" data-backdrop="static" onclick="CallPORefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPOIdGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblAssetId" Text="<%$ Resources:GlobalResource, PODetails_lblAssetId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtAssetId" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon1">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAssetSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetIdGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblUOM" Text="<%$ Resources:GlobalResource, PODetails_lblUOM%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtUOM" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, PODetails_lblDescription%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDescription" TextMode="MultiLine" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        
                       <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblLocationId" Text="<%$ Resources:GlobalResource, PODetails_lblLocationId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtLocation" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon2">
                                    <a href="#" data-toggle="modal" data-target="#basicModalLocationSearch" data-keyboard="false" data-backdrop="static" onclick="CallLocationRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtLocationGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                       <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblQuantityOrdered" Text="<%$ Resources:GlobalResource, PODetails_lblQuantityOrdered%>"></asp:Label>
                           <asp:TextBox type="text" runat="server" ID="txtQuantityOrdered"  ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                       </div>

                        
                       <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblQuantityCanceled" Text="<%$ Resources:GlobalResource, PODetails_lblQuantityCanceled%>"></asp:Label>
                           <asp:TextBox type="text" runat="server" ID="txtQuantityCanceled"  ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                       </div>

                       <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblUnitCost" Text="<%$ Resources:GlobalResource, PODetails_lblUnitCost%>"></asp:Label>
                           <asp:TextBox type="text" runat="server" ID="txtUnitCost"  ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                       </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblExtendedCost" Text="<%$ Resources:GlobalResource, PODetails_lblExtendedCost%>"></asp:Label>
                           <asp:TextBox type="text" runat="server" ID="txtExtendedCost"  ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                       </div>
                       
                           </div>
                    </div>
                </div>
            </div>
        </div>

     <div class="modal fade" id="basicModalPOSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPOTitle"><span>
                        <asp:Literal runat="server" ID="ltr_PO_information1" Text="<%$ Resources:GlobalResource, PoDetails_ltrPOinformation %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPOSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPOSearch" DefaultButton="btnPOSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPOSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPOSearch" onclick="CallPOSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPOClose" visible="false" onclick="ClearPOSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPOSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPOSearch_Click" formnovalidate="formnovalidate"/>
                                <asp:Button runat="server" ID="btnClearPOSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPOSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPOSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPOSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPOSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="POSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPOData" AssociatedUpdatePanelID="updpnlgvPOSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPOSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPORefresh" ClientIDMode="Static" OnClick="btnPORefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPOSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PODetails_htPONumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPODetails('<%#Eval("PONumber")%>','<%#Eval("tbl_POId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvPOType" Text='<%# Bind("PONumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PODetails_htPOGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPOGuid" runat="server" Text='<%# Bind("tbl_POId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPOSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPOSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrPOClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="ltr_Asset_information1" Text="<%$ Resources:GlobalResource, PODetails_ltrAssetinformation %>"></asp:Literal>
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
                                <asp:Button runat="server" ID="btnAssetSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAssetSearch_Click" formnovalidate="formnovalidate"/>
                                <asp:Button runat="server" ID="btnClearAssetSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAssetSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divAssetSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblAssetSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divAssetSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="AssetSearchSuccess"></asp:Label>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PODetails_htAssetCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetAssetDetails('<%#Eval("AssetCode")%>','<%#Eval("tbl_AssetId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvAssetType" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PODetails_htDescription%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvAssetName" runat="server" Text='<%# Bind("AssetCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PODetails_htAssetGuid%>" Visible="false">
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
                        <asp:Literal runat="server" ID="ltr_Location_information1" Text="<%$ Resources:GlobalResource, PODetails_ltrLocationinformation %>"></asp:Literal>
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
                                <asp:Button runat="server" ID="btnLocationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnLocationSearch_Click" formnovalidate="formnovalidate"/>
                                <asp:Button runat="server" ID="btnClearLocationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearLocationSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divLocationSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblLocationSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divLocationSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="LocationSearchSuccess"></asp:Label>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PODetails_htLocationCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetLocationDetails('<%#Eval("LocationCode")%>','<%#Eval("tbl_LocationId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvLocationType" Text='<%# Bind("City") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PODetails_htLocationCity%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvLocationName" runat="server" Text='<%# Bind("LocationCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PODetails_htLocationGuid%>" Visible="false">
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
                <div class="modal-footer row" runat="server" id="div2">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrLocationClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    </asp:Content>