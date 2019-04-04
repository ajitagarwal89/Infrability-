<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SupplierEmployeeGeneralExpensesList.aspx.cs" Inherits="Finance_Accounts_Payable_Supplier_General_Expenses_SupplierEmployeeGeneralExpensesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/Supplier_Employee_General_Expenses_JS/SupplierEmployeeGeneralExpensesList.js"></script>
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
                        <%--<i class="fa fa-file-excel-o formBtnsFA"></i>--%>
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
                        <asp:Literal runat="server" ID="ltrSearch" Text="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_ltrEmployeeGeneralExpenses %>"></asp:Literal></h3>
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
                                        <asp:BoundColumn DataField="tbl_SupplierEmployeeGeneralExpensesId" Visible="false"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_htVoucherNumber%>" DataField="VoucherNumber"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_htDescription%>" DataField="Description"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_htDocumentType%>" DataField="Opt_DocumentTypeLable"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_htExpenses%>" DataField="Expenses"></asp:BoundColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_htPayableType%>" DataField="PayablesType"></asp:BoundColumn>
                                        

                                        <asp:TemplateColumn HeaderImageUrl="~/images/eye.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <button id="lnkView_<%# Container.DataSetIndex + 1 %>" type="button" data-toggle="modal" data-target="#basicModalSupplierEmployeeGeneralExpensesSearch" data-keyboard="false" data-backdrop="static" class="btn btn-default btn-sm btn-block" onclick="setDetails('<%#Eval("VoucherNumber")%>','<%#Eval("BatchName")%>','<%#Eval("Opt_DocumentTypeLable")%>','<%#Eval("SupplierEmployeeName")%>','<%#Eval("CurrencyName")%>','<%#Eval("Expenses")%>','<%#Eval("BankTransferAmount")%>','<%#Eval("Cash")%>','<%#Eval("Cheque")%>','<%#Eval("CreditCard")%>','<%#Eval("OnAccount")%>','lnkview_<%# Container.DataSetIndex + 1 %>');">
                                                    <asp:Literal runat="server" ID="ltrView" Text="<%$ Resources:GlobalResource, ltrView%>"></asp:Literal></button>
                                                <button id="lnkViewNextPrev_<%# Container.DataSetIndex + 1 %>" style="display: none;" type="button" class="btn btn-default btn-sm" onclick="setDetails('<%#Eval("VoucherNumber")%>','<%#Eval("BatchName")%>','<%#Eval("Opt_DocumentTypeLable")%>','<%#Eval("SupplierEmployeeName")%>','<%#Eval("CurrencyName")%>','<%#Eval("Expenses")%>','<%#Eval("BankTransferAmount")%>','<%#Eval("Cash")%>','<%#Eval("Cheque")%>','<%#Eval("CreditCard")%>','<%#Eval("OnAccount")%>','lnkview_<%# Container.DataSetIndex + 1 %>');">
                                            </ItemTemplate>
                                        </asp:TemplateColumn>

                                        <asp:TemplateColumn HeaderImageUrl="~/images/edit.png" HeaderStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="gvColLnkBtn" class="btn btn-default btn-sm btn-block" OnClick="gvColLnkBtn_Click" CommandArgument='<%#Eval("tbl_SupplierEmployeeGeneralExpensesId") %>'>
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

    <div class="modal fade" id="basicModalSupplierEmployeeGeneralExpensesSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="myModalLabel"><span>
                        <asp:Literal runat="server" ID="ltrRecordDetails" Text="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_ltrSupplierEmployeeGeneralExpensesDetails %>"></asp:Literal></span></h4>
                </div>
                <div class="modal-body">
                    <table class="table table-striped" style="width: 100%; font-size: 9.5pt;">
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrVoucherNumber" Text="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_ltrVoucherNumber%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrBatchId" Text="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_ltrBatchId%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrDocumentType" Text="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_ltrDocumentType%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblVoucherNumber" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblBatchId" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblDocumentType" runat="server" ClientIDMode="Static"></asp:Label></td>
                        </tr>
                       <tr>   
                        
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrSupplierId" Text="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_ltrSupplierId%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCurrencyId" Text="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_ltrCurrencyId%>"></asp:Literal></td>
                           <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrExpenses" Text="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_ltrExpenses%>"></asp:Literal></td>
                        </tr>
                        <tr>
                           
                            <td>
                                <asp:Label ID="lblSupplierId" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblCurrencyId" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>
                                <asp:Label ID="lblExpenses" runat="server" ClientIDMode="Static"></asp:Label></td>
                        </tr>                     
                       
                        <tr>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCash" Text="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_ltrCash%>"></asp:Literal></td>
                            
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCheque" Text="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_ltrCheque%>"></asp:Literal></td>
                            
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrOnAccount" Text="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpense_ltrOnAccount
%>"></asp:Literal></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCash" runat="server" ClientIDMode="Static"></asp:Label></td>
                           
                            <td>
                                <asp:Label ID="lblCheque" runat="server" ClientIDMode="Static"></asp:Label></td>
                           
                            <td>
                                <asp:Label ID="lblOnAccount" runat="server" ClientIDMode="Static"></asp:Label></td>
                        </tr>
                        <tr>
                             <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrBankTransferAmount" Text="<%$ Resources:GlobalResource, SupplierEmployeeGeneralExpenses_ltrBankTransferAmount%>"></asp:Literal></td>
                            <td class="auto-style1">
                                <asp:Literal runat="server" ID="ltrCreditCard" Text="<%$ Resources:GlobalResource,  SupplierEmployeeGeneralExpenses_ltrCreditCard%>"></asp:Literal></td>
                            <td>

                            </td>

                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblBankTransferAmount" runat="server" ClientIDMode="Static"></asp:Label></td>
                           
                            <td>
                                <asp:Label ID="lblCreditCard" runat="server" ClientIDMode="Static"></asp:Label></td>
                            <td>

                            </td>

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

