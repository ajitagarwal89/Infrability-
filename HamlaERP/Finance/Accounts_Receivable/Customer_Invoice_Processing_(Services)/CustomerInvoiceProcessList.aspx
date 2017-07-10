<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomerInvoiceProcessList.aspx.cs" Inherits="Finance_Accounts_Receivable_Customer_Invoice_Processing__Services_CustomerInvoiceProcessList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Receivable_JS/Customer_Invoice_Processing_(Services)_JS/CustomerInvoiceProcessList.js"></script>
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
                        <asp:Literal runat="server" ID="ltrSearch" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrCustomerInvoiceProcess %>"></asp:Literal></h3>
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
                                        <asp:BoundColumn DataField="tbl_CustomerInvoiceProcessId" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceProcess_htDocumentType%>" DataField="Opt_DocumentTypeLable"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceProcess_htDocumentNumber%>" DataField="DocumentNumber"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceProcess_htDocumentDate%>" DataField="DocumentDate"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceProcess_htInvoiceDate%>" DataField="InvoiceDate"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, CustomerInvoiceProcess_htTotal%>" DataField="Total"></asp:BoundColumn>

                                        <asp:TemplateColumn HeaderImageUrl="~/images/eye.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <button id="lnkView_<%# Container.DataSetIndex + 1 %>" type="button" data-toggle="modal" data-target="#basicModalCustomerInvoiceProcessSearch" data-keyboard="false" data-backdrop="static" class="btn btn-default btn-sm btn-block" onclick="SetDetails('<%#Eval("Opt_DocumentTypeLable")%>','<%#Eval("BatchName")%>','<%#Eval("DocumentNumber")%>','<%#Eval("DocumentDate")%>','<%#Eval("Description")%>','<%#Eval("PostingDate")%>','<%#Eval("InvoiceDate")%>','<%#Eval("InvoiceIssueDate")%>','<%#Eval("CustomerName")%>','<%#Eval("CurrencyName")%>','<%#Eval("PaymentTermsName")%>','<%#Eval("PONumber")%>','<%#Eval("Cost")%>','<%#Eval("Sales")%>','<%#Eval("TradeDiscount")%>','<%#Eval("Freight")%>','<%#Eval("Total")%>','<%#Eval("PaymentNumberBank")%>','<%#Eval("BankTransferAmount")%>','<%#Eval("PayablesTypeCash")%>','<%#Eval("CashAmount")%>','<%#Eval("PayablesTypeCheque")%>','<%#Eval("ChequeAmount")%>','<%#Eval("PayablesTypeCard")%>','<%#Eval("CreditCardAmount")%>','<%#Eval("OnAccount")%>','lnkview_<%# Container.DataSetIndex + 1 %>');">
                                                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, ltrView%>"></asp:Literal></button>
                                                <button id="lnkViewNextPrev_<%# Container.DataSetIndex + 1 %>" style="display: none;" type="button" class="btn btn-default btn-sm" onclick="SetDetails('<%#Eval("Opt_DocumentTypeLable")%>','<%#Eval("BatchName")%>','<%#Eval("DocumentNumber")%>','<%#Eval("DocumentDate")%>','<%#Eval("Description")%>','<%#Eval("PostingDate")%>','<%#Eval("InvoiceDate")%>','<%#Eval("InvoiceIssueDate")%>','<%#Eval("CustomerName")%>','<%#Eval("CurrencyName")%>','<%#Eval("PaymentTermsName")%>','<%#Eval("PONumber")%>','<%#Eval("Cost")%>','<%#Eval("Sales")%>','<%#Eval("TradeDiscount")%>','<%#Eval("Freight")%>','<%#Eval("Total")%>','<%#Eval("PaymentNumberBank")%>','<%#Eval("BankTransferAmount")%>','<%#Eval("PayablesTypeCash")%>','<%#Eval("CashAmount")%>','<%#Eval("PayablesTypeCheque")%>','<%#Eval("ChequeAmount")%>','<%#Eval("PayablesTypeCard")%>','<%#Eval("CreditCardAmount")%>','<%#Eval("OnAccount")%>','lnkview_<%# Container.DataSetIndex + 1 %>');"></button>
                                            </ItemTemplate>
                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="gvColLnkBtn" class="btn btn-default btn-sm btn-block" OnClick="gvColLnkBtn_Click" CommandArgument='<%#Eval("tbl_CustomerInvoiceProcessId") %>'>
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
    <div class="modal fade" id="basicModalCustomerInvoiceProcessSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel"><span>
                        <asp:Literal runat="server" ID="ltrRecordDetails" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrCustomerInvoiceProcessDetails %>"></asp:Literal></span></h4>
                </div>
                <div class="modal-body">
                    <table class="table table-striped" style="width: 100%; font-size: 9.5pt;">
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="CustomerInvoiceProcess_ltrDocumentType" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrDocumentType%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="CustomerInvoiceProcess_ltrBatchId" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrBatchId%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="CustomerInvoiceProcess_ltrDocumentNumber" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrDocumentNumber%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblDocumentType" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblBatch" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblDocumentNumber" runat="server" ClientIDMode="Static"></asp:Label></td>
                        </tr>
                        <tr>

                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDocumentDate" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrDocumentDate%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDescription" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrDescription%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPostingDate" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrPostingDate%>"></asp:Literal></td>
                        </tr>
                        <tr>

                            <td>
                                <asp:Label ID="lblDocumentDate" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblDescription" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblPostingDate" runat="server" ClientIDMode="Static"></asp:Label></td>
                        </tr>

                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrInvoiceDate" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrInvoiceDate%>"></asp:Literal></td>

                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrInvoiceIssue" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrInvoiceIssueDate%>"></asp:Literal></td>

                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCustomerId" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrCustomerId%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblInvoiceDate" runat="server" ClientIDMode="Static"></asp:Label></td>

                            <td>
                                <asp:Label ID="lblInvoiceIssueDate" runat="server" ClientIDMode="Static"></asp:Label></td>

                            <td>
                                <asp:Label ID="lblCustomer" runat="server" ClientIDMode="Static"></asp:Label></td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCurrencyId" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrCurrencyId%>"></asp:Literal></td>
                           
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPaymentTermsId" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrPaymentTermsId%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPONumber" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrPONumber%>"></asp:Literal></td>
                            <td></td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCurrency" runat="server" ClientIDMode="Static"></asp:Label></td>
                             <td>
                                <asp:Label ID="lblPaymentTerms" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblPONumber" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCost" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrCost%>"></asp:Literal></td>
                           
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrSales" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrSales%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrTradeDiscount" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrTradeDiscount%>"></asp:Literal></td>
                            <td></td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCost" runat="server" ClientIDMode="Static"></asp:Label></td>
                             <td>
                                <asp:Label ID="lblSales" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblTradeDiscount" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrFreight" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrFreight%>"></asp:Literal></td>
                           
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrTotal" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrTotal%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPayablesId_BankTransfer" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrPayablesId_BankTransfer%>"></asp:Literal></td>
                            <td></td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblFreight" runat="server" ClientIDMode="Static"></asp:Label></td>
                             <td>
                                <asp:Label ID="lblTotalAmount" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblPayablesIdBankTransfer" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltBankTransferAmount" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrBankTransferAmount%>"></asp:Literal></td>
                           
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPayablesId_Cash" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrPayablesId_Cash%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="llrCashAmount" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_llrCashAmount%>"></asp:Literal></td>
                            <td></td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBankTransferAmount" runat="server" ClientIDMode="Static"></asp:Label></td>
                             <td>
                                <asp:Label ID="lblPayablesIdCash" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblCashAmount" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPayablesId_Cheque" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrPayablesId_Cheque%>"></asp:Literal></td>
                           
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrChequeAmount" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrChequeAmount%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPayablesId_CreditCard" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrPayablesId_CreditCard%>"></asp:Literal></td>
                            <td></td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPayablesIdCheque" runat="server" ClientIDMode="Static"></asp:Label></td>
                             <td>
                                <asp:Label ID="lblChequeAmount" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblPayablesIdCreditCard" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td></td>

                        </tr>
                                       <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCreditCardAmount" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrCreditCardAmount%>"></asp:Literal></td>
                           
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrOnAccount" Text="<%$ Resources:GlobalResource, CustomerInvoiceProcess_ltrOnAccount%>"></asp:Literal></td>
                       

                        </tr>
                        <tr>
                           <td>
                                <asp:Label ID="lblCreditCardAmount" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblOnAccount" runat="server" ClientIDMode="Static"></asp:Label></td>                   

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
