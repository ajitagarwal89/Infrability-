﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AssetList.aspx.cs" Inherits="Assets_Asset_AssetList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Asset%20_Accounting_JS/Capitalization_of_Assets_JS/AssetList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnNew" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnNew%>" OnClick="btnNew_Click" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnDelete%>" OnClick="btnDelete_Click" />                    
                    <asp:LinkButton runat="server" ID="lnkExportToExcel" OnClick="lnkExportToExcel_Click" CssClass="btn btn-success">
                        <asp:Literal runat="server" ID="ltrExportToExcel" Text="<%$Resources:GlobalResource, ltrExportToExcel%>"></asp:Literal>
                    </asp:LinkButton>
                    <asp:UpdatePanel runat="server" ID="updpnlMainSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlMainSearch" DefaultButton="btnMainSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlSearch" onclick="CallMainSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlClose" visible="false" onclick="ClearMainSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnMainSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnMainSearch_Click" />
                                <asp:Button runat="server" ID="btnClearMainSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearMainSearch_Click" />
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <div class="ui-content-body">
            <div class="ui-container">
                <div class="row">
                    <h3 class="hepad">
                        <asp:Literal runat="server" ID="ltrSearch" Text="<%$ Resources:GlobalResource, Asset_ltrAssest%>"></asp:Literal></h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">

                        <asp:UpdatePanel runat="server" ID="updPanelData">
                            <ContentTemplate>
                                <div runat="server" id="divError" visible="false" class="alert alert-danger" role="alert">
                                    <asp:Label runat="server" ID="lblError"></asp:Label>
                                </div>
                                <div runat="server" id="divSuccess" visible="false" class="alert alert-success" role="alert">
                                    <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                                </div>
                                <asp:DataGrid runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvData" AutoGenerateColumns="false" Width="100%" GridLines="None" BorderStyle="None" CssClass="table table-hover">
                                    <Columns>
                                        <asp:TemplateColumn>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRow" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="tbl_AssetId" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, Asset_htAssetCode%>" DataField="AssetCode"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, Asset_httbl_Employee%>" DataField="tbl_Employee"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, Asset_htQuantity%>" DataField="Quantity"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, Asset_htDateAdded%>" DataField="DateAdded"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, Asset_htStatus%>" DataField="Status"></asp:BoundColumn>


                                        <asp:TemplateColumn HeaderImageUrl="~/images/eye.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <button id="lnkView_<%# Container.DataSetIndex + 1 %>" type="button" data-toggle="modal" data-target="#divBasicModal" data-keyboard="false" data-backdrop="static" class="btn btn-default btn-sm btn-block" onclick="SetDetails('<%#Eval("AssetCode")%>','<%#Eval("ShortName")%>','<%#Eval("tbl_AssetGroup")%>','<%#Eval("Type")%>','<%#Eval("tbl_AssetAndGroupAccount")%>','<%#Eval("AcquisitionDate")%>','<%#Eval("AcquisitionCost")%>','<%#Eval("CurrencyName")%>','<%#Eval("tbl_Location")%>','<%#Eval("tbl_PhysicalLocation")%>','<%#Eval("AssetBarcode")%>','<%#Eval("tbl_Employee")%>','<%#Eval("ManufacturerName")%>','<%#Eval("Quantity")%>','<%#Eval("LastMaintenanceDate")%>','<%#Eval("SerialNumber")%>','<%#Eval("ModalNumber")%>','<%#Eval("WarrantyDate")%>','<%#Eval("DepreciationExpense")%>','<%#Eval("AccumulatedDepreciation")%>','<%#Eval("PriorYearDepreciation")%>','<%#Eval("AssetCost")%>','<%#Eval("Clearing")%>','lnkview_<%# Container.DataSetIndex + 1 %>');">
                                                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, ltrView%>"></asp:Literal></button>
                                                <button id="lnkViewNextPrev_<%# Container.DataSetIndex + 1 %>" style="display: none;" type="button" class="btn btn-default btn-sm" onclick="SetDetails('<%#Eval("AssetCode")%>','<%#Eval("ShortName")%>','<%#Eval("tbl_AssetGroup")%>','<%#Eval("Type")%>','<%#Eval("tbl_AssetAndGroupAccount")%>','<%#Eval("AcquisitionDate")%>','<%#Eval("AcquisitionCost")%>','<%#Eval("CurrencyName")%>','<%#Eval("tbl_Location")%>','<%#Eval("tbl_PhysicalLocation")%>','<%#Eval("AssetBarcode")%>','<%#Eval("tbl_Employee")%>','<%#Eval("ManufacturerName")%>','<%#Eval("Quantity")%>','<%#Eval("LastMaintenanceDate")%>','<%#Eval("SerialNumber")%>','<%#Eval("ModalNumber")%>','<%#Eval("WarrantyDate")%>','<%#Eval("DepreciationExpense")%>','<%#Eval("AccumulatedDepreciation")%>','<%#Eval("PriorYearDepreciation")%>','<%#Eval("AssetCost")%>','<%#Eval("Clearing")%>','lnkview_<%# Container.DataSetIndex + 1 %>');"></button>
                                            </ItemTemplate>

                                            <%--<ItemTemplate>
                                                <button id="lnkView_<%# Container.DataSetIndex + 1 %>" type="button" data-toggle="modal" data-target="#divBasicModal" data-keyboard="false" data-backdrop="static" class="btn btn-default btn-sm btn-block" onclick="SetDetails('lnkview_<%# Container.DataSetIndex + 1 %>');">
                                                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, ltrView%>"></asp:Literal></button>
                                                <button id="lnkViewNextPrev_<%# Container.DataSetIndex + 1 %>" style="display: none;" type="button" class="btn btn-default btn-sm" onclick="SetDetails('lnkview_<%# Container.DataSetIndex + 1 %>');"></button>
                                            </ItemTemplate>--%>

                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="gvColLnkBtn" class="btn btn-default btn-sm btn-block" OnClick="gvColLnkBtn_Click" CommandArgument='<%#Eval("tbl_AssetId") %>'>
                                                    <asp:Literal runat="server" ID="ltrEdit" Text="<%$ Resources:GlobalResource, ltrEdit%>"></asp:Literal>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:DataGrid>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnMainSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearMainSearch" />

                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="divBasicModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel"><span>
                        <asp:Literal runat="server" ID="ltrDetails" Text="<%$ Resources:GlobalResource, Asset_ltrDetails %>"></asp:Literal></span></h4>
                </div>
                <div class="modal-body">
                    <table class="table table-striped" style="width: 100%; font-size: 9.5pt;">
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrAssetCode" Text="<%$ Resources:GlobalResource, Asset_ltrAssetCode%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrShortName" Text="<%$ Resources:GlobalResource, Asset_ltrShortName%>"></asp:Literal></td>

                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrtbl_AssetGroup" Text="<%$ Resources:GlobalResource, Asset_ltrtbl_AssetGroup%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAssetCode" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblShortName" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbltbl_AssetGroup" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrType" Text="<%$ Resources:GlobalResource, Asset_ltrType%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrtbl_AssetAndGroupAccount" Text="<%$ Resources:GlobalResource, Asset_ltrtbl_AssetAndGroupAccount%>"></asp:Literal></td>

                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrAcquisitionDate" Text="<%$ Resources:GlobalResource, Asset_ltrAcquisitionDate%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblType" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbltbl_AssetAndGroupAccount" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblAcquisitionDate" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrAcquisitionCost" Text="<%$ Resources:GlobalResource, Asset_ltrAcquisitionCost%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCurrencyName" Text="<%$ Resources:GlobalResource, Asset_ltrCurrencyName%>"></asp:Literal></td>

                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrtbl_Location" Text="<%$ Resources:GlobalResource, Asset_ltrtbl_Location%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAcquisitionCost" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblCurrencyName" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbltbl_Location" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrtbl_PhysicalLocation" Text="<%$ Resources:GlobalResource, Asset_ltrtbl_PhysicalLocation%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrAssetBarcode" Text="<%$ Resources:GlobalResource, Asset_ltrAssetBarcode%>"></asp:Literal></td>

                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrtbl_Employee" Text="<%$ Resources:GlobalResource, Asset_ltrtbl_Employee%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lbltbl_PhysicalLocation" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblAssetBarcode" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lbltbl_Employee" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrManufacturerName" Text="<%$ Resources:GlobalResource, Asset_ltrManufacturerName%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrQuantity" Text="<%$ Resources:GlobalResource, Asset_ltrQuantity%>"></asp:Literal></td>

                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrLastMaintenanceDate" Text="<%$ Resources:GlobalResource, Asset_ltrLastMaintenanceDate%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblManufacturerName" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblQuantity" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblLastMaintenanceDate" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrSerialNumber" Text="<%$ Resources:GlobalResource, Asset_ltrSerialNumber%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrModalNumber" Text="<%$ Resources:GlobalResource, Asset_ltrModalNumber%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltr_WarrantyDate" Text="<%$ Resources:GlobalResource, Asset_ltr_WarrantyDate%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSerialNumber" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblModalNumber" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblWarrantyDate" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDepreciationExpense" Text="<%$ Resources:GlobalResource, Asset_ltrDepreciationExpense%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrAccumulatedDepreciation" Text="<%$ Resources:GlobalResource, Asset_ltrAccumulatedDepreciation%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPriorYearDepreciation" Text="<%$ Resources:GlobalResource, Asset_ltrPriorYearDepreciation%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDepreciationExpense" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblAccumulatedDepreciation" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblPriorYearDepreciation" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                         <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrAssetCost" Text="<%$ Resources:GlobalResource, Asset_ltrAssetCost%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrClearing" Text="<%$ Resources:GlobalResource, Asset_ltrClearing%>"></asp:Literal></td>
                          
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAssetCost" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblClearing" runat="server" ClientIDMode="Static"></asp:Label></td>
                           

                        </tr>

                    </table>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="btn-group pull-right" role="group" aria-label="...">
                        <a id="btnPrevious" class="btn btn-default" role="button" onclick="showPrevRecord();"><i class="fa fa-chevron-circle-left"></i>
                            <asp:Literal runat="server" ID="ltrPrevious" Text="<%$ Resources:GlobalResource, btnPrevious%>"></asp:Literal></a>
                        <a id="btnNext" class="btn btn-default" role="button" onclick="showNextRecord();">
                            <asp:Literal runat="server" ID="ltrNext" Text="<%$ Resources:GlobalResource, btnNext%>"></asp:Literal>
                            <i class="fa fa-chevron-circle-right"></i></a>
                    </div>
                    <asp:Label ID="lblGvRowId" runat="server" Style="display: none;" ClientIDMode="Static"></asp:Label>
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrClose" Text="<%$ Resources:GlobalResource, ltrClose%>"></asp:Literal></button>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>

