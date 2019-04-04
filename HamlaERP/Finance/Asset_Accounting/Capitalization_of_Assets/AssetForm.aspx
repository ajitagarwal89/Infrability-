<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssetForm.aspx.cs" Inherits="Assets_Asset_AssetForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Asset%20_Accounting_JS/Capitalization_of_Assets_JS/AssetForm.js"></script>
    <script src="../../../infra_ui/js/CommonJS/CommonValidations.js"></script>
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
                                <asp:Literal runat="server" ID="ltrAssetInformation" Text="<%$ Resources:GlobalResource, Asset_ltrinformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAssetCode" Text="<%$ Resources:GlobalResource, Asset_lblAssetCode%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAssetCode" ClientIDMode="Static" onkeypress="return isAlphaNumberKey(this);" MaxLength="20"  class="form-control"  placeholder="" required="required"></asp:TextBox>
                        </div>

                      

                    
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblShortName" Text="<%$ Resources:GlobalResource, Asset_lblShortName%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtShortName" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="50" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblAssetGroupId" Text="<%$ Resources:GlobalResource,Asset_lblAssetGroupId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtAssetGroup"  runat="server" CssClass="form-control" ClientIDMode="Static" ReadOnly="true" OnTextChanged="txtAssetGroup_TextChanged1"></asp:TextBox>
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
                            <asp:TextBox runat="server" ID="txtAcquisitionDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                            </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAcquisitionCost" Text="<%$ Resources:GlobalResource, Asset_lblAcquisitionCost%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAcquisitionCost" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
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
                            <asp:TextBox runat="server" ID="txtAssetBarcode" ClientIDMode="Static" onkeypress="return isAlphaNumberKey(this);" MaxLength="50" class="form-control" placeholder="" required="required"></asp:TextBox>
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
                            <asp:TextBox runat="server" ID="txtManufacturerName" ClientIDMode="Static" onkeypress="return isAlphaKey(this);" MaxLength="50"  class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblQuantity" Text="<%$ Resources:GlobalResource,  Asset_lblQuantity%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtQuantity" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblLastMaintenanceDate" Text="<%$ Resources:GlobalResource, Asset_lblLastMaintenanceDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtLastMaintenanceDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDateAdded" Text="<%$ Resources:GlobalResource, Asset_lblDateAdded%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDateAdded" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblopt_Status" Text="<%$ Resources:GlobalResource, Asset_lblopt_Status %>"></asp:Label>
                            <asp:DropDownList ID="ddlopt_Status" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSerialNumber" Text="<%$ Resources:GlobalResource, Asset_lblSerialNumber%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtSerialNumber" ClientIDMode="Static" ReadOnly="true" onkeypress="return isAlphaNumberKey(this);" MaxLength="30" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblModalNumber" Text="<%$ Resources:GlobalResource, Asset_lblModalNumber%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtModalNumber" ClientIDMode="Static"  onkeypress="return isAlphaNumberKey(this);" MaxLength="20" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblWarrantyDate" Text="<%$ Resources:GlobalResource, Asset_lblWarrantyDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtWarrantyDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, Asset_lblDescription%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDescription" ClientIDMode="Static" onkeypress="return isAddress(this);" MaxLength="50" class="form-control " TextMode="MultiLine" placeholder="" required="required"></asp:TextBox>
                        </div>
                            <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblExtendedDescription" Text="<%$ Resources:GlobalResource, Asset_lblExtendedDescription%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtExtendedDescription" ClientIDMode="Static" onkeypress="return isAddress(this);" MaxLength="50" class="form-control " TextMode="MultiLine" placeholder="" required="required"></asp:TextBox>
                        </div>
                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccount_DepreciationExpense" Text="<%$ Resources:GlobalResource,Asset_lblGLAccount_DepreciationExpense %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtDepreciationExpense" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon1">
                                    <a href="#" data-toggle="modal" data-target="#basicModalDepreciationExpenseSearch" data-keyboard="false" data-backdrop="static" onclick="CallDepreciationExpenseRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtDepreciationExpenseGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccount_AccumulatedDepreciation" Text="<%$ Resources:GlobalResource,Asset_lblGLAccount_AccumulatedDepreciation %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtAccumulatedDepreciation" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon2">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAccumulatedDepreciationSearch" data-keyboard="false" data-backdrop="static" onclick="CallAccumulatedDepreciationRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAccumulatedDepreciationGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccount_PriorYearDepreciation" Text="<%$ Resources:GlobalResource, Asset_lblGLAccount_PriorYearDepreciation %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPriorYearDepreciation" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon5">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPriorYearDepreciationSearch" data-keyboard="false" data-backdrop="static" onclick="CallPriorYearDepreciationRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPriorYearDepreciationGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccount_AssetCost" Text="<%$ Resources:GlobalResource,Asset_lblGLAccount_AssetCost %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtAssetCost" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon10">
                                    <a href="#" data-toggle="modal" data-target="#basicModalAssetCostSearch" data-keyboard="false" data-backdrop="static" onclick="CallAssetCostRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtAssetCostGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

                        </div>                       
                                               
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccount_Clearing" Text="<%$ Resources:GlobalResource,Asset_lblGLAccount_Clearing%>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtClearing" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon9">
                                    <a href="#" data-toggle="modal" data-target="#basicModalClearingSearch" data-keyboard="false" data-backdrop="static" onclick="CallClearingRefreshButton();">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtClearingGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>

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
                                                <a href="#" data-dismiss="modal" onclick="SetEmployeeDetails('<%#Eval("EmployeeName")%>','<%#Eval("tbl_EmployeeId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvEmployeeCode" Text='<%# Bind("EmployeeCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htEmployeeName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvEmployeeName" runat="server" Text='<%# Bind("EmployeeName") %>'></asp:Label>
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

                     <%-- Modal Popup for basicModalDepreciationExpense Search --%>
            <div class="modal fade" id="basicModalDepreciationExpenseSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="hdrModalDepreciationExpenseTitle"><span>
                                <asp:Literal runat="server" ID="ltr_DepreciationExpense_Infomation" Text="<%$ Resources:GlobalResource, Asset_ltrDepreciationExpenseInformation%>"></asp:Literal>
                            </span>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="updpnlDepreciationExpenseSearch">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="pnlDepreciationExpenseSearch" DefaultButton="btnDepreciationExpenseSearch">
                                        <div class="col-md-4 col-xs-5">
                                            <div class="icon-addon addon-md">
                                                <asp:TextBox runat="server" ID="txtDepreciationExpenseSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                <a runat="server" id="btnHtmlDepreciationExpenseSearch" onclick="CallDepreciationExpenseSearch();" class="fa fa-search"></a>
                                                <a runat="server" id="btnHtmlDepreciationExpenseClose" visible="false" onclick="ClearDepreciationExpenseSearch();" class="fa fa-close closex"></a>
                                            </div>
                                        </div>
                                        <asp:Button runat="server" ID="btnDepreciationExpenseSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnDepreciationExpenseSearch_Click" formnovalidate="formnovalidate" />
                                        <asp:Button runat="server" ID="btnClearDepreciationExpenseSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearDepreciationExpenseSearch_Click" formnovalidate="formnovalidate" />

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divDepreciationExpenseSearchError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblDepreciationExpenseSearchError"></asp:Label>
                                </div>
                                <div runat="server" id="divDepreciationExpenseSearchSuccess" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblDepreciationExpenseSearchSuccess"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress runat="server" ID="updProgData" AssociatedUpdatePanelID="updpnlgvDepreciationExpenseSearch">
                                    <ProgressTemplate>
                                        Loading...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updpnlgvDepreciationExpenseSearch">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnDepreciationExpenseRefresh" ClientIDMode="Static" OnClick="btnDepreciationExpenseRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                        <asp:GridView ID="gvDepreciationExpenseSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htDepreciationExpense%>">
                                                    <ItemTemplate>
                                                        <a href="#" data-dismiss="modal" onclick="SetDepreciationExpenseDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                            <asp:Literal runat="server" ID="ltrgvDepreciationExpenseNumber" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htDepreciationExpenseGuid %>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_DepreciationExpenseId" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnDepreciationExpenseSearch" />
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearDepreciationExpenseSearch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer row" runat="server" id="div5">
                            <div class="pull-left">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    <asp:Literal runat="server" ID="ltrDepreciationExpenseClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%-- Modal Popup for AccumulatedDepreciation Search --%>

            <div class="modal fade" id="basicModalAccumulatedDepreciationSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="hdrModalAccumulatedDepreciationTitle"><span>
                                <asp:Literal runat="server" ID="ltrAccumulatedDepreciationTitle" Text="<%$ Resources:GlobalResource,Asset_ltrAccumulatedDepreciationInformation%>"></asp:Literal>
                            </span>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="updpnlAccumulatedDepreciation">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="pnlAccumulatedDepreciation" DefaultButton="btnAccumulatedDepreciationSearch">
                                        <div class="col-md-4 col-xs-5">
                                            <div class="icon-addon addon-md">
                                                <asp:TextBox runat="server" ID="txtAccumulatedDepreciationSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                <a runat="server" id="btnHtmlAccumulatedDepreciationSearch" onclick="CallAccumulatedDepreciationSearch();" class="fa fa-search"></a>
                                                <a runat="server" id="btnHtmlAccumulatedDepreciationClose" visible="false" onclick="ClearAccumulatedDepreciationSearch();" class="fa fa-close closex"></a>
                                            </div>
                                        </div>

                                        <asp:Button runat="server" ID="btnAccumulatedDepreciationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAccumulatedDepreciationSearch_Click" formnovalidate="formnovalidate " />
                                        <asp:Button runat="server" ID="btnClearAccumulatedDepreciationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAccumulatedDepreciationSearch_Click" formnovalidate="formnovalidate" />

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divAccumulatedDepreciationSearchError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblAccumulatedDepreciationSearchError"></asp:Label>
                                </div>
                                <div runat="server" id="divAccumulatedDepreciationSearchSucces" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblAccumulatedDepreciationSearchSucces"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress runat="server" ID="updProgAccumulatedDepreciationData" AssociatedUpdatePanelID="updpnlgvAccumulatedDepreciationSearch">
                                    <ProgressTemplate>
                                        Loading...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updpnlgvAccumulatedDepreciationSearch">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnAccumulatedDepreciationRefresh" ClientIDMode="Static" OnClick="btnAccumulatedDepreciationRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                        <asp:GridView ID="gvAccumulatedDepreciationSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,Asset_htAccumulatedDepreciation%>">
                                                    <ItemTemplate>
                                                        <a href="#" data-dismiss="modal" onclick="SetAccumulatedDepreciationDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                            <asp:Literal runat="server" ID="ltrgvAccumulatedDepreciationNumber" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htAccumulatedDepreciationGuid%>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAccumulatedDepreciationGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAccumulatedDepreciationSearch" />
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAccumulatedDepreciationSearch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer row" runat="server" id="divAccumulatedDepreciationFooter">
                            <div class="pull-left">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    <asp:Literal runat="server" ID="lblAccumulatedDepreciationClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <%-- Modal Popup forPriorYearDepreciation Search --%>

            <div class="modal fade" id="basicModalPriorYearDepreciationSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="hdrModalPriorYearDepreciationTitle"><span>
                                <asp:Literal runat="server" ID="ltrPriorYearDepreciationTitle" Text="<%$ Resources:GlobalResource, Asset_ltrPriorYearDepreciationInformation%>"></asp:Literal>
                            </span>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="updpnlPriorYearDepreciation">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="pnlPriorYearDepreciation" DefaultButton="btnPriorYearDepreciationSearch">
                                        <div class="col-md-4 col-xs-5">
                                            <div class="icon-addon addon-md">
                                                <asp:TextBox runat="server" ID="txtPriorYearDepreciationSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                <a runat="server" id="btnHtmlPriorYearDepreciationSearch" onclick="CallPriorYearDepreciationSearch();" class="fa fa-search"></a>
                                                <a runat="server" id="btnHtmlPriorYearDepreciationClose" visible="false" onclick="ClearPriorYearDepreciationSearch();" class="fa fa-close closex"></a>
                                            </div>
                                        </div>

                                        <asp:Button runat="server" ID="btnPriorYearDepreciationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPriorYearDepreciationSearch_Click" formnovalidate="formnovalidate" />
                                        <asp:Button runat="server" ID="btnClearPriorYearDepreciationSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPriorYearDepreciationSearch_Click" formnovalidate="formnovalidate" />

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divPriorYearDepreciationSearchError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblPriorYearDepreciationSearchError"></asp:Label>
                                </div>
                                <div runat="server" id="divPriorYearDepreciationSearchSucces" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblPriorYearDepreciationSearchSucces"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress runat="server" ID="updProgPriorYearDepreciationData" AssociatedUpdatePanelID="updpnlgvPriorYearDepreciationSearch">
                                    <ProgressTemplate>
                                        Loading...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updpnlgvPriorYearDepreciationSearch">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnPriorYearDepreciationRefresh" ClientIDMode="Static" OnClick="btnPriorYearDepreciationRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                        <asp:GridView ID="gvPriorYearDepreciationSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htPriorYearDepreciation%>">
                                                    <ItemTemplate>
                                                        <a href="#" data-dismiss="modal" onclick="SetPriorYearDepreciationDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                            <asp:Literal runat="server" ID="ltrgvPriorYearDepreciationCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, Asset_htPriorYearDepreciationGuid%>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvPriorYearDepreciationGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPriorYearDepreciationSearch" />
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPriorYearDepreciationSearch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer row" runat="server" id="divPriorYearDepreciationFooter">
                            <div class="pull-left">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    <asp:Literal runat="server" ID="lblPriorYearDepreciationClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%--- Modal Popup for AssetCost Search ----%>

            <div class="modal fade" id="basicModalAssetCostSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="hdrModalAssetCostTitle"><span>
                                <asp:Literal runat="server" ID="ltrAssetCostTitle" Text="<%$ Resources:GlobalResource, Asset_ltrAssetCostInformation%>"></asp:Literal>
                            </span>
                            </h4>
                        </div>
                        <div class="modal-body">
                            <asp:UpdatePanel runat="server" ID="updpnlAssetCost">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="pnlAssetCost" DefaultButton="btnAssetCostSearch">
                                        <div class="col-md-4 col-xs-5">
                                            <div class="icon-addon addon-md">
                                                <asp:TextBox runat="server" ID="txtAssetCostSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                <a runat="server" id="btnHtmlAssetCostSearch" onclick="CallAssetCostSearch();" class="fa fa-search"></a>
                                                <a runat="server" id="btnHtmlAssetCostClose" visible="false" onclick="ClearAssetCostSearch();" class="fa fa-close closex"></a>
                                            </div>
                                        </div>
                                        <asp:Button runat="server" ID="btnAssetCostSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnAssetCostSearch_Click" formnovalidate="formnovalidate" />
                                        <asp:Button runat="server" ID="btnClearAssetCostSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearAssetCostSearch_Click" formnovalidate="formnovalidate" />

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divAssetCostSearchError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblAssetCostSearchError"></asp:Label>
                                </div>
                                <div runat="server" id="divAssetCostSearchSucces" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblAssetCostSearchSucces"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress runat="server" ID="updProgAssetCosteData" AssociatedUpdatePanelID="updpnlgvAssetCostSearch">
                                    <ProgressTemplate>
                                        Loading...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updpnlgvAssetCostSearch">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnAssetCostRefresh" ClientIDMode="Static" OnClick="btnAssetCostRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                        <asp:GridView ID="gvAssetCostSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,Asset_htAssetCost%>">
                                                    <ItemTemplate>
                                                        <a href="#" data-dismiss="modal" onclick="SetAssetCostDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                            <asp:Literal runat="server" ID="ltrgvAssetCostCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:GlobalResource,Asset_htAssetCostGuid %>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvAssetCostGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnAssetCostSearch" />
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearAssetCostSearch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer row" runat="server" id="divAssetCostFooter">
                            <div class="pull-left">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    <asp:Literal runat="server" ID="lblAssetCostClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

           
            <%--Modal Popup for Clearing	 setSearch   --%>
            <div class="modal fade" id="basicModalClearingSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header" style="text-align: left;">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title" id="hdrModalClearingTitle"><span>
                                <asp:Literal runat="server" ID="ltrClearingTitle" Text="<%$ Resources:GlobalResource, Asset_ltrClearingInformation%>"></asp:Literal>
                            </span>
                            </h4>
                        </div>
                        <div class="modal-body">

                            <asp:UpdatePanel runat="server" ID="updpnlClearing">
                                <ContentTemplate>
                                    <asp:Panel runat="server" ID="pnlClearing" DefaultButton="btnClearingSearch">
                                        <div class="col-md-4 col-xs-5">
                                            <div class="icon-addon addon-md">
                                                <asp:TextBox runat="server" ID="txtClearingSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                                <a runat="server" id="btnHtmlClearingSearch" onclick="CallClearingSearch();" class="fa fa-search"></a>
                                                <a runat="server" id="btnHtmlClearingClose" visible="false" onclick="ClearClearingSearch();" class="fa fa-close closex"></a>
                                            </div>
                                        </div>
                                        <asp:Button runat="server" ID="btnClearingSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearingSearch_Click" formnovalidate="formnovalidate" />
                                        <asp:Button runat="server" ID="btnClearClearingSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearClearingSearch_Click" formnovalidate="formnovalidate" />

                                    </asp:Panel>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <div class="col-md-12 col-sm-12 colformstyle3">
                                <div runat="server" id="divClearingSearchError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblClearingSearchError"></asp:Label>
                                </div>
                                <div runat="server" id="divClearingSucces" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblClearingSearchSucces"></asp:Label>
                                </div>
                            </div>
                            <div>
                                <asp:UpdateProgress runat="server" ID="updProgClearingData" AssociatedUpdatePanelID="updpnlgClearingSearch">
                                    <ProgressTemplate>
                                        Loading...
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <asp:UpdatePanel runat="server" ID="updpnlgClearingSearch">
                                    <ContentTemplate>
                                        <asp:Button runat="server" ID="btnClearingRefresh" ClientIDMode="Static" OnClick="btnClearingRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                        <asp:GridView ID="gvClearingSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                            EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,Asset_htClearing%>">
                                                    <ItemTemplate>

                                                        <a href="#" data-dismiss="modal" onclick="SetClearingDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                            <asp:Literal runat="server" ID="ltrClearingCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                        </a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$Resources:GlobalResource,Asset_htClearingGuid %>" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgvClearingGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearingSearch" />
                                        <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearClearingSearch" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer row" runat="server" id="divClearingFooter">
                            <div class="pull-left">
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    <asp:Literal runat="server" ID="lblClearingClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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

