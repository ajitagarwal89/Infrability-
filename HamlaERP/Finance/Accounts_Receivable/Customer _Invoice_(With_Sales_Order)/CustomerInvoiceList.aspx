﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomerInvoiceList.aspx.cs" Inherits="Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Receivable_JS/Customer%20_Invoice_(With_Sales_Order)_JS/CustomerInvoiceList.js"></script>
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
                        <asp:Literal runat="server" ID="ltrSearch" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrList %>"></asp:Literal></h3>
                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblError"></asp:Label>
                        </div>
                        <div runat="server" id="divSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSuccess"></asp:Label>
                        </div>

                        <asp:UpdatePanel runat="server" ID="updPanelData">
                            <ContentTemplate>

                                <asp:DataGrid runat="server" ClientIDMode="Static" Font-Size="10pt" ID="gvData" AutoGenerateColumns="false" Width="100%" GridLines="None" BorderStyle="None" CssClass="table table-hover">
                                    <Columns>
                                        <asp:TemplateColumn>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRow" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="tbl_CustomerInvoiceId" Visible="false"></asp:BoundColumn>

                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htDocumentNumber%>" DataField="DocumentNumber"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htBatchName%>" DataField="BatchName"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htName%>" DataField="CustomerName"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htCurrencyName%>" DataField="CurrencyName"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htAmountReceived%>" DataField="AmountReceived"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htTotalAmount%>" DataField="TotalAmount"></asp:BoundColumn>

                                        <asp:TemplateColumn HeaderImageUrl="~/images/eye.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <button id="lnkView_<%# Container.DataSetIndex + 1 %>" type="button" data-toggle="modal" data-target="#divBasicModal" data-keyboard="false" data-backdrop="static" class="btn btn-default btn-sm btn-block" onclick="SetDetails('<%#Eval("DocumentDate")%>','<%#Eval("Opt_InvoiceAndOrderTypeLable")%>','<%#Eval("DocumentNumber")%>','<%#Eval("BatchName")%>','<%#Eval("CustomerName")%>','<%#Eval("SiteNumber")%>','<%#Eval("CustomerPONumber")%>','<%#Eval("CurrencyName")%>','<%#Eval("AmountReceived")%>','<%#Eval("OnAccount")%>','<%#Eval("SubTotalAmount")%>','<%#Eval("TradeDiscountAmount")%>','<%#Eval("FreightAmount")%>','<%#Eval("TotalAmount")%>','<%#Eval("PostingDate")%>','<%#Eval("QuoteDate")%>','<%#Eval("OrderDate")%>','<%#Eval("InvoiceDate")%>','<%#Eval("BackOrderDate")%>','<%#Eval("ReturnDate")%>','<%#Eval("RequestedShipDate")%>','<%#Eval("DateFulfilled")%>','<%#Eval("ActualShipDate")%>','lnkview_<%# Container.DataSetIndex + 1 %>');">
                                                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, ltrView%>"></asp:Literal></button>
                                                <button id="lnkViewNextPrev_<%# Container.DataSetIndex + 1 %>" style="display: none;" type="button" class="btn btn-default btn-sm" onclick="SetDetails('<%#Eval("DocumentDate")%>','<%#Eval("Opt_InvoiceAndOrderTypeLable")%>','<%#Eval("DocumentNumber")%>','<%#Eval("BatchName")%>','<%#Eval("CustomerName")%>','<%#Eval("SiteNumber")%>','<%#Eval("CustomerPONumber")%>','<%#Eval("CurrencyName")%>','<%#Eval("AmountReceived")%>','<%#Eval("OnAccount")%>','<%#Eval("SubTotalAmount")%>','<%#Eval("TradeDiscountAmount")%>','<%#Eval("FreightAmount")%>','<%#Eval("TotalAmount")%>','<%#Eval("PostingDate")%>','<%#Eval("QuoteDate")%>','<%#Eval("OrderDate")%>','<%#Eval("InvoiceDate")%>','<%#Eval("BackOrderDate")%>','<%#Eval("ReturnDate")%>','<%#Eval("RequestedShipDate")%>','<%#Eval("DateFulfilled")%>','<%#Eval("ActualShipDate")%>','lnkview_<%# Container.DataSetIndex + 1 %>');"></button>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="gvColLnkBtn" class="btn btn-default btn-sm btn-block" OnClick="gvColLnkBtn_Click" CommandArgument='<%#Eval("tbl_CustomerInvoiceId") %>'>
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
                        <asp:Literal runat="server" ID="ltrRecordDetails" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrList %>"></asp:Literal></span></h4>
                </div>
                <div class="modal-body">
                    <table class="table table-striped" style="width: 100%; font-size: 9.5pt;">
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDocumentDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrDocumentDate%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrInvoiceAndOrderTypeLable" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrInvoiceAndOrderTypeLable%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDocumentNumber" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrDocumentNumber%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDocumentDate" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblopt_InvoiceAndOrderTypeLable" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblDocumentNumber" runat="server" ClientIDMode="Static"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrBatchName" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrBatchName%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCustomerName" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrCustomerName%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrSiteNumber" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrSiteNumber%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBatchName" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblCustomerName" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblSiteNumber" runat="server" ClientIDMode="Static"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCustomerPONumbe" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrCustomerPONumber%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCurrencyName" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrCurrencyName%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrAmountReceived" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrAmountReceived%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCustomerPONumber" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblCurrencyName" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblAmountReceived" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrOnAccount" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrOnAccount%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrSubTotalAmount" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrSubTotalAmount%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrTradeDiscountAmount" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrTradeDiscountAmount%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblOnAccount" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblSubTotalAmount" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblTradeDiscountAmount" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrFreightAmount" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrFreightAmount%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrTotalAmount" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrTotalAmount%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPostingDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrPostingDate%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFreightAmount" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblTotalAmount" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblPostingDate" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrQuoteDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrQuoteDate%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrOrderDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrOrderDate%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrInvoiceDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrInvoiceDate%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblQuoteDate" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblOrderDate" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblInvoiceDate" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrBackOrderDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrBackOrderDate%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrReturnDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrReturnDate%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrRequestedShipDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrRequestedShipDate%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBackOrderDate" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblReturnDate" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblRequestedShipDate" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDateFulfilled" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrDateFulfilled%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrActualShipDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrActualShipDate%>"></asp:Literal></td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDateFulfilled" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblActualShipDate" runat="server" ClientIDMode="Static"></asp:Label></td>


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

