<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DownPaymentToSupplierList.aspx.cs" Inherits="Finance_Bank_Accounting_Down_Payment_Suppliers_DownPaymentToSupplierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Bank_Accounting_JS/Down_Payment_Suppliers_JS/DownPaymentToSupplierList.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
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
                        <asp:Literal runat="server" ID="ltrSearch" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrDownPaymentToSuppliers %>"></asp:Literal></h3>
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
                                        <asp:BoundColumn DataField="tbl_DownPaymentToSupplierId" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplier_htPaymentNumber%>" DataField="PaymentNumber"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplier_htPaymentDate%>" DataField="PaymentDate"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplier_htBatchName%>" DataField="BatchName"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplier_htSupplierName%>" DataField="SupplierName"></asp:BoundColumn>
                                          <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, DownPaymentToSupplier_htPayablesType%>" DataField="PayablesType"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="CurrencyName" Visible="false"></asp:BoundColumn>
                                          <asp:BoundColumn DataField="tbl_PayablesId_BankTransfer" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="BankTransferAmount" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="tbl_PayablesId_Cash" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="tbl_PayablesId_Cheque" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="tbl_PayablesId_CreditCard" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="CashAmount" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="ChequeAmount" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="CreditCardAmount" Visible="false"></asp:BoundColumn>               
                                        <asp:BoundColumn DataField="Unapplied" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Applied" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn DataField="Total" Visible="false"></asp:BoundColumn>
                                      

                                        <asp:TemplateColumn HeaderImageUrl="~/images/eye.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <button id="lnkView_<%# Container.DataSetIndex + 1 %>" type="button" data-toggle="modal" data-target="#divBasicModal" data-keyboard="false" data-backdrop="static" class="btn btn-default btn-sm btn-block" onclick="SetDetails('<%#Eval("PaymentNumber")%>','<%#Eval("PaymentDate")%>','<%#Eval("BatchName")%>','<%#Eval("SupplierName")%>','<%#Eval("CurrencyName")%>','<%#Eval("BankName")%>','<%#Eval("BankTransferAmount")%>','<%#Eval("PayablesTypeCash")%>','<%#Eval("CashAmount")%>','<%#Eval("PayablesTypeCheque")%>','<%#Eval("ChequeAmount")%>','<%#Eval("CardName")%>','<%#Eval("CreditCardAmount")%>','<%#Eval("Unapplied")%>','<%#Eval("Applied")%>','<%#Eval("Total")%>','lnkview_<%# Container.DataSetIndex + 1 %>');">
                                                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, ltrView%>"></asp:Literal></button>
                                                <button id="lnkViewNextPrev_<%# Container.DataSetIndex + 1 %>" style="display: none;" type="button" class="btn btn-default btn-sm" onclick="SetDetails('<%#Eval("PaymentNumber")%>','<%#Eval("PaymentDate")%>','<%#Eval("BatchName")%>','<%#Eval("SupplierName")%>','<%#Eval("CurrencyName")%>','<%#Eval("BankName")%>','<%#Eval("BankTransferAmount")%>','<%#Eval("PayablesTypeCash")%>','<%#Eval("CashAmount")%>','<%#Eval("PayablesTypeCheque")%>','<%#Eval("ChequeAmount")%>','<%#Eval("CardName")%>','<%#Eval("CreditCardAmount")%>','<%#Eval("Unapplied")%>','<%#Eval("Applied")%>','<%#Eval("Total")%>','lnkview_<%# Container.DataSetIndex + 1 %>');"></button>
                                                </ItemTemplate>
                                                
                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="gvColLnkBtn" class="btn btn-default btn-sm btn-block" OnClick="gvColLnkBtn_Click" CommandArgument='<%#Eval("tbl_DownPaymentToSupplierId") %>'>
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
                        <asp:Literal runat="server" ID="ltrDetails" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrDetails %>"></asp:Literal></span></h4>
                </div>
                <div class="modal-body">
                    <table class="table table-striped" style="width: 100%; font-size: 9.5pt;">
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPaymentNumber" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrPaymentNumber%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPaymentDate" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrPaymentDate%>"></asp:Literal></td>

                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrBatchName" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrBatchName%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPaymentNumber" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblPaymentDate" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblBatchName" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrSupplierName" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrSupplierName%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCurrencyName" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrCurrencyName%>"></asp:Literal></td>
                          
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrBankName" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrBankName%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblSupplierName" runat="server" ClientIDMode="Static"></asp:Label></td>
                             <td>
                                <asp:Label ID="lblCurrencyName" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblBankName" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                           <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrBankTransferAmount" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrBankTransferAmount%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPayablesTypeCash" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrPayablesTypeCash%>"></asp:Literal></td>
                          
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCashAmount" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrCashAmount%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBankTransferAmount" runat="server" ClientIDMode="Static"></asp:Label></td>
                             <td>
                                <asp:Label ID="lblPayablesTypeCash" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblCashAmount" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                           <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrPayablesTypeCheque" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrPayablesTypeCheque%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrChequeAmount" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrChequeAmount%>"></asp:Literal></td>
                          
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCardName" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrCardName%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblPayablesTypeCheque" runat="server" ClientIDMode="Static"></asp:Label></td>
                             <td>
                                <asp:Label ID="lblChequeAmount" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblCardName" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>

                            <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCreditCardAmount" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrCreditCardAmount%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrUnaplied" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrUnapplied%>"></asp:Literal></td>
                          
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrApplied" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrApplied%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCreditCardAmount" runat="server" ClientIDMode="Static"></asp:Label></td>
                             <td>
                                <asp:Label ID="lblUnaplied" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblApplied" runat="server" ClientIDMode="Static"></asp:Label></td>

                        </tr>
                           <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrTotal" Text="<%$ Resources:GlobalResource, DownPaymentToSupplier_ltrTotal%>"></asp:Literal></td>
                           </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTotal" runat="server" ClientIDMode="Static"></asp:Label></td>
                             
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

