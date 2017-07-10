<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssetForm.aspx.cs" Inherits="Assets_Asset_AssetForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
     <script src="../../infra_ui/js/Asset/Asset_JS/AssetForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrAssetInformation" Text="<%$ Resources:GlobalResource, Asset_ltrinformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAssetCode" Text="<%$ Resources:GlobalResource, Asset_lblAssetCode%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtAssetCode" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, Asset_lblDescription%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDescription" ClientIDMode="Static" class="form-control " TextMode="MultiLine" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblExtendedDescription" Text="<%$ Resources:GlobalResource, Asset_lblExtendedDescription%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtExtendedDescription" ClientIDMode="Static" class="form-control " TextMode="MultiLine" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblShortName" Text="<%$ Resources:GlobalResource, Asset_lblShortName%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtShortName" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAssetGroupId" Text="<%$ Resources:GlobalResource,Asset_lblAssetGroupId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtAssetGroup" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAssetGroupSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetGroupRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetGroupGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_Type" Text="<%$ Resources:GlobalResource, Asset_lblopt_Type %>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_opt_Type" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAssetAndGroupAccountId" Text="<%$ Resources:GlobalResource, Asset_lblAssetAndGroupAccountId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtAssetAndGroupAccount" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon4">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAssetAndGroupAccountSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetAndGroupAccountRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetAndGroupAccountGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAcquisitionDate" Text="<%$ Resources:GlobalResource, Asset_lblAcquisitionDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtAcquisitionDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                            </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAcquisitionCost" Text="<%$ Resources:GlobalResource, Asset_lblAcquisitionCost%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtAcquisitionCost" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrencyId" Text="<%$ Resources:GlobalResource,Asset_lblCurrencyId %>"></asp:Label>
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

                            <div>
                                <asp:Label runat="server" ID="lblLocationId" Text="<%$ Resources:GlobalResource, Asset_lblLocationId %>"></asp:Label>
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

                            <div>
                                <asp:Label runat="server" ID="lblPhysicalLocationId" Text="<%$ Resources:GlobalResource, Asset_lblPhysicalLocationId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPhysicalLocation" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon7">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPhysicalLocationSearch" data-keyboard="false" data-backdrop="static" onclick="CallPhysicalLocationRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPhysicalLocationGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAssetBarcode" Text="<%$ Resources:GlobalResource, Asset_lblAssetBarcode%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtAssetBarcode" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblStructure" Text="<%$ Resources:GlobalResource, Asset_lblStructureId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtStructure" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon8">
                                    <a href="#" data-toggle="modal" data-target="#basicModalStructureSearch" data-keyboard="false" data-backdrop="static" onclick="CallStructureRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtStructureGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblEmployee" Text="<%$ Resources:GlobalResource, Asset_lblEmployeeId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtEmployee" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon3">
                                    <a href="#" data-toggle="modal" data-target="#basicModalEmployeeSearch" data-keyboard="false" data-backdrop="static" onclick="CallEmployeeRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtEmployeeGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblManufacturerName" Text="<%$ Resources:GlobalResource, Asset_lblManufacturerName%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtManufacturerName" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblQuantity" Text="<%$ Resources:GlobalResource,  Asset_lblQuantity%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtQuantity" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblLastMaintenanceDate" Text="<%$ Resources:GlobalResource, Asset_lblLastMaintenanceDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtLastMaintenanceDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDateAdded" Text="<%$ Resources:GlobalResource, Asset_lblDateAdded%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDateAdded" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_Status" Text="<%$ Resources:GlobalResource, Asset_lblopt_Status %>"></asp:Label>
                            <asp:DropDownList ID="ddlopt_Status" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSerialNumber" Text="<%$ Resources:GlobalResource, Asset_lblSerialNumber%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtSerialNumber" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblModalNumber" Text="<%$ Resources:GlobalResource, Asset_lblModalNumber%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtModalNumber" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblWarrantyDate" Text="<%$ Resources:GlobalResource, Asset_lblWarrantyDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtWarrantyDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                    </div>
             

         <div class="modal fade" id="basicModalAssetGroupSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalAssetGroupTitle"><span>
                        <asp:Literal runat="server" ID="ltrAssetGroupTitle" Text="<%$ Resources:GlobalResource, Asset_ltrAssetGroupTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlAssetGroupSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlAssetGroupSearch" DefaultButton="btnAssetGroupSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtAssetGroupSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlAssetGroupSearch" onclick="CallAssetGroupSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlAssetGroupClose" visible="false" onclick="ClearAssetGroupSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnAssetGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAssetGroupSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearAssetGroupSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAssetGroupSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divAssetGroupSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblAssetGroupSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divAssetGroupSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblAssetGroupSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgAssetGroupData" AssociatedUpdatePanelID="updpnlgvAssetGroupSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvAssetGroupSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAssetGroupRefresh" ClientIDMode="Static" OnClick="btnAssetGroupRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvAssetGroupSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htAssetGroupName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetAssetGroupDetails('<%#Eval("Description")%>','<%#Eval("tbl_AssetGroupId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvDescription" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htAssetGroupGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvAssetGroupGuid" runat="server" Text='<%# Bind("tbl_AssetGroupId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAssetGroupSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAssetGroupSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrAssetGroupClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

         <div class="modal fade" id="basicModalAssetAndGroupAccountSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrAssetAndGroupAccountTitle"><span>
                        <asp:Literal runat="server" ID="ltr_AssetAndGroupAccount" Text="<%$ Resources:GlobalResource, Asset_ltrAssetAndGroupAccount %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlAssetAndGroupAccount">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlAssetAndGroupAccountSearch" DefaultButton="btnAssetAndGroupAccountSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtAssetAndGroupAccountSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlAssetAndGroupAccountSearch" onclick="CallAssetAndGroupAccountSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlAssetAndGroupAccountClose" visible="false" onclick="ClearAssetAndGroupAccountSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnAssetAndGroupAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAssetAndGroupAccountSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearAssetAndGroupAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAssetAndGroupAccountSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divAssetAndGroupAccountSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblAssetAndGroupAccountSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divAssetAndGroupAccountSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblAssetAndGroupAccountSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateAssetAndGroupAccountProgress" AssociatedUpdatePanelID="updpnlgvAssetAndGroupAccountSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvAssetAndGroupAccountSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnAssetAndGroupAccountRefresh" ClientIDMode="Static" OnClick="btnAssetAndGroupAccountRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvAssetAndGroupAccountSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,Asset_htOpt_AccountType%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetAssetAndGroupAccountDetails('<%#Eval("AccountType")%>','<%#Eval("tbl_AssetAndGroupAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvtAssetAndGroupAccountNumber" Text='<%# Bind("Opt_AccountType") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htAssetAndGroupAccountName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAccountType" runat="server" Text='<%# Bind("AccountType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$Resources:GlobalResource, Asset_htAssetAndGroupAccountGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAssetAndGroupAccountId" runat="server" Text='<%# Bind("tbl_AssetAndGroupAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAssetAndGroupAccountSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAssetAndGroupAccountSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div2">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrAssetAndGroupAccountClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                                <asp:Literal runat="server" ID="ltrLocationTitle" Text="<%$ Resources:GlobalResource, Asset_ltrLocationTitle %>"></asp:Literal>
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
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htLocationCode%>">
                                                    <ItemTemplate>
                                                        <a href="#" data-dismiss="modal" onclick="SetLocationDetails('<%#Eval("Description")%>','<%#Eval("tbl_LocationId")%>');">

                                                            <asp:Literal runat="server" ID="ltrgvLocationCode" Text='<%# Bind("LocationCode") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,Asset_htLocationName%>">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvLocationName" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htLocationGuid%>" Visible="false">
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

         <div class="modal fade" id="basicModalPhysicalLocationSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPhysicalLocationTitle"><span>
                        <asp:Literal runat="server" ID="ltrPhysicalLocationTitle" Text="<%$ Resources:GlobalResource, Asset_ltrPhysicalLocationTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPhysicalLocationSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPhysicalLocationSearch" DefaultButton="btnPhysicalLocationSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPhysicalLocationSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPhysicalLocationSearch" onclick="CallPhysicalLocationSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPhysicalLocationClose" visible="false" onclick="ClearPhysicalLocationSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPhysicalLocationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPhysicalLocationSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPhysicalLocationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPhysicalLocationSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPhysicalLocationSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPhysicalLocationSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPhysicalLocationSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPhysicalLocationSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPhysicalLocationData" AssociatedUpdatePanelID="updpnlgvPhysicalLocationSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPhysicalLocationSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPhysicalLocationRefresh" ClientIDMode="Static" OnClick="btnPhysicalLocationRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPhysicalLocationSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htPhysicalLocationCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPhysicalLocationDetails('<%#Eval("Description")%>','<%#Eval("tbl_PhysicalLocationId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvPhysicalLocationType" Text='<%# Bind("tbl_Location") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,Asset_htPhysicalLocationName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPhysicalLocationName" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htPhysicalLocationGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPhysicalLocationGuid" runat="server" Text='<%# Bind("tbl_PhysicalLocationId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPhysicalLocationSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPhysicalLocationSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div4">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrPhysicalLocationClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

         <div class="modal fade" id="basicModalEmployeeSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalSupplierTitle"><span>
                        <asp:Literal runat="server" ID="ltrEmployeeTitle" Text="<%$ Resources:GlobalResource, Asset_ltrEmployeeTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlEmployeeSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlEmployeeSearch" DefaultButton="btnEmployeeSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtEmployeeSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlEmployeeSearch" onclick="CallEmployeeSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlEmployeeClose" visible="false" onclick="ClearEmployeeSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnEmployeeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnEmployeeSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearEmployeeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearEmployeeSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divEmployeeSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblEmployeeSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divEmployeeSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblEmployeeSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgEmployeeData" AssociatedUpdatePanelID="updpnlgvEmployeeSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvEmployeeSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnEmployeeRefresh" ClientIDMode="Static" OnClick="btnEmployeeRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvEmployeeSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htEmployeeCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetEmployeeDetails('<%#Eval("Name")%>','<%#Eval("tbl_EmployeeId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvEmployeeCode" Text='<%# Bind("EmployeeCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htEmployeeName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvEmployeeName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htEmployeeGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvEmployeeGuid" runat="server" Text='<%# Bind("tbl_EmployeeId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnEmployeeSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearEmployeeSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrEmployeeClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, Asset_ltrCurrencyInformation %>"></asp:Literal>
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

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,Asset_htCurrencyCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htCurrencyName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyName" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htCurrencyGuid%>" Visible="false">
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

                    <div class="modal fade" id="basicModalStructureSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalStructureTitle"><span>
                        <asp:Literal runat="server" ID="ltrStructureTitle" Text="<%$ Resources:GlobalResource, Asset_ltrStructureInformation %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlStructure">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlStructure" DefaultButton="btnStructureSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtStructureSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlStructureSearch" onclick="CallStructureSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlStructureClose" visible="false" onclick="ClearStructureSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnStructureSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnStructureSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearStructureSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearStructureSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divStructureSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblStructureSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divStructureSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblStructureSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgStructureData" AssociatedUpdatePanelID="updpnlgvStructureSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvStructureSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnStructureRefresh" ClientIDMode="Static" OnClick="btnStructureRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvStructureSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htStructureCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetStructureDetails('<%#Eval("Description")%>','<%#Eval("tbl_StructureId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvStructureCode" Text='<%# Bind("StructureCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htStructureName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvStructureName" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htStructureGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvStructureGuid" runat="server" Text='<%# Bind("tbl_StructureId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnStructureSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearStructureSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divStructureFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblStructureClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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

