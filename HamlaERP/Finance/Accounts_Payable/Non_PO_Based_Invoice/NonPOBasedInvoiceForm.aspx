<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="NonPOBasedInvoiceForm.aspx.cs" Inherits="Finance_Accounts_Payable_Non_PO_Based_Invoice_NonPOBasedInvoiceForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/Non_PO_Based_Invoice_JS/NonPOBasedInvoiceForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblVoucherNumber" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblVoucherNumber%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtVoucherNumber" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblInterCompany" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblInterCompany%>"></asp:Label>

                            <asp:CheckBox ID="chkInterCompany" runat="server"  ClientIDMode="Static" class="form-control" placeholder="" required="required"/>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblBatch" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblBatchId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtBatch" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalBatchSearch" data-keyboard="false" data-backdrop="static" onclick="CallBatchRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtBatchGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lbOpt_DocumentType" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblOpt_DocumentType %>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_DocumentType" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDocumentDate" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblDocumentDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDocumentDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblDescription%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDescription" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblPostingDate" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblPostingDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtPostingDate" TextMode="Date"  ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblInvoiceDate" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblInvoiceDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtInvoiceDate" TextMode="Date"  ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblReceivedDate" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblReceivedDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtReceivedDate" TextMode="Date"  ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>


                          <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblSupplier" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblSupplier %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtSupplier" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon3">
                                    <a href="#" data-toggle="modal" data-target="#basicModalSupplierSearch" data-keyboard="false" data-backdrop="static" onclick="CallSupplierRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtSupplierGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                           <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrencyId" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblCurrencyId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCurrency" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_Cuurency">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCurrencySearch" data-keyboard="false" data-backdrop="static" onclick="CallCurrencyRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtCurrencyGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                   
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblDocumentNumber" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblDocumentNumber%>"></asp:Label>
                        <asp:TextBox type="text" runat="server" ID="txtDocumentNumber" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblPONumber" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblPONumber%>"></asp:Label>
                        <asp:TextBox type="text" runat="server" ID="txtPONumber" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>


                           <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblPaymentTerms" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblPaymentTerms %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPaymentTerms" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon5">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPaymentTermsSearch" data-keyboard="false" data-backdrop="static" onclick="CallPaymentTermsRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPaymentTermsGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblPurchase" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblPurchase%>"></asp:Label>
                        <asp:TextBox type="text" runat="server" ID="txtPurchase" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblTradeDiscount" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblTradeDiscount%>"></asp:Label>
                        <asp:TextBox type="text" runat="server" ID="txtTradeDiscount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblFreight" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblFreight%>"></asp:Label>
                        <asp:TextBox type="text" runat="server" ID="txtFreight" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblTotal" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblTotal%>"></asp:Label>
                        <asp:TextBox type="text" runat="server" ID="txtTotal" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>
                    
                           <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblPayablesId_BankTransfer" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblPayablesId_BankTransfer %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPayablesBank" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon6">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPayablesBankSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayablesBankRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayablesBankGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                     <div class="form-group col-md-4 col-sm-4">
                       <asp:Label runat="server" ID="lblBankTransferAmount" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblBankTransferAmount%>"></asp:Label>
                        <asp:TextBox type="text" runat="server" ID="txtBankTransferAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>
                   
                          <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblPayablesId_Cash" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblPayablesId_Cash %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPayablesCash" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon7">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPayablesCashSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayablesCashRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayablesCashGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                              
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblCashAmount" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblCashAmount%>"></asp:Label>
                        <asp:TextBox type="text" runat="server" ID="txtCashAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>


                          <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblPayablesId_Cheque" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblPayablesId_Cheque %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPayablesCheque" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon8">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPayablesChequeSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayablesChequeRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayablesChequeGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                              
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblChequeAmount" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblChequeAmount%>"></asp:Label>
                        <asp:TextBox type="text" runat="server" ID="txtChequeAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>


                          <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblPayablesId_CreditCard" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblPayablesId_CreditCard %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtPayablesCreditCard" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon9">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPayablesCreditCardSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayablesCreditCardRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayablesCreditCardGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCreditCardAmount" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblCreditCardAmount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtCreditCardAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                   
                    <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblOnAccount" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_lblOnAccount%>"></asp:Label>
                        <asp:TextBox type="text" runat="server" ID="txtOnAccount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>

                </div>
            </div>
        </div>
    </div>
        </div>
    
    <div class="modal fade" id="basicModalBatchSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalBatchTitle"><span>
                        <asp:Literal runat="server" ID="ltrBatchTitle" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_ltrBatchTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlBatchSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlBatchSearch" DefaultButton="btnBatchSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtBatchSearch" CssClass="form-control" placeholder="Search..." autofocu></asp:TextBox>
                                        <a runat="server" id="btnHtmlBatchSearch" onclick="CallBatchSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlBatchClose" visible="false" onclick="ClearBatchSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnBatchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnBatchSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearBatchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearBatchSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divBatchSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblBatchSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divBatchSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblBatchSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgBatchData" AssociatedUpdatePanelID="updpnlgvBatchSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvBatchSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnBatchRefresh" ClientIDMode="Static" OnClick="btnBatchRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvBatchSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htBatchType%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetBatchDetails('<%#Eval("BatchName")%>','<%#Eval("tbl_BatchId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvBatchType" Text='<%# Bind("Opt_BatchType") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htBatchName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchName" runat="server" Text='<%# Bind("BatchName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htBatchGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchGuid" runat="server" Text='<%# Bind("tbl_BatchId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnBatchSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearBatchSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrBatchClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalSupplierSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalSupplierTitle"><span>
                        <asp:Literal runat="server" ID="ltrSupplierTitle" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_ltrSupplierTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlSupplierSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlSupplierSearch" DefaultButton="btnSupplierSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSupplierSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlSupplierSearch" onclick="CallSupplierSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlSupplierClose" visible="false" onclick="ClearSupplierSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnSupplierSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnSupplierSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearSupplierSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearSupplierSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divSupplierSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblSupplierSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divSupplierSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSupplierSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgSupplierData" AssociatedUpdatePanelID="updpnlgvSupplierSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvSupplierSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnSupplierRefresh" ClientIDMode="Static" OnClick="btnSupplierRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvSupplierSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htSupplierCode%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetSupplierDetails('<%#Eval("Name")%>','<%#Eval("tbl_SupplierId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvSupplierType" Text='<%# Bind("SupplierCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htSupplierName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSupplierName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htSupplierGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSupplierGuid" runat="server" Text='<%# Bind("tbl_SupplierId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSupplierSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearSupplierSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrSupplierClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
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
                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_ltrSupplierInrfomation %>"></asp:Literal>
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

                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,NonPOBasedInvoice_htCurrencyCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htCurrencyName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyName" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htCurrencyGuid%>" Visible="false">
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

     <div class="modal fade" id="basicModalPaymentTermsSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPaymentTermsTitle"><span>
                        <asp:Literal runat="server" ID="ltrPaymentTermsTitle" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_ltrPaymentTermsTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPaymentTermsSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPaymentTermsSearch" DefaultButton="btnPaymentTermsSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPaymentTermsSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPaymentTermsSearch" onclick="CallPaymentTermsSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPaymentTermsClose" visible="false" onclick="ClearPaymentTermsSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPaymentTermsSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPaymentTermsSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPaymentTermsSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPaymentTermsSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPaymentTermsSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPaymentTermsSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPaymentTermsSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPaymentTermsSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPaymentTermsData" AssociatedUpdatePanelID="updpnlgvPaymentTermsSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPaymentTermsSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPaymentTermsRefresh" ClientIDMode="Static" OnClick="btnPaymentTermsRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPaymentTermsSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htPaymentTermsName%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetPaymentTermsDetails('<%#Eval("PaymentTermsName")%>','<%#Eval("tbl_PaymentTermsId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvPaymentTermsType" Text='<%# Bind("PaymentTermsName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField  HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htPaymentTermsGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPaymentTermsGuid" runat="server" Text='<%# Bind("tbl_PaymentTermsId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPaymentTermsSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPaymentTermsSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div2">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrPaymentTermsClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <div class="modal fade" id="basicModalPayablesBankSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPayablesBankTitle"><span>
                        <asp:Literal runat="server" ID="ltrPayablesBankTitle" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_ltrPayablesBank %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPayablesBankSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPayablesBankSearch" DefaultButton="btnPayablesBankSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPayablesBankSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPayablesBankSearch" onclick="CallPayablesBankSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPayablesBankClose" visible="false" onclick="ClearPayablesBankSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPayablesBankSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPayablesBankSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPayablesBankSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPayablesBankSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPayablesBankSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPayablesBankSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPayablesBankSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPayablesBankSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPayablesBankData" AssociatedUpdatePanelID="updpnlgvPayablesBankSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPayablesBankSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPayablesBankRefresh" ClientIDMode="Static" OnClick="btnPayablesBankRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPayablesBankSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htPayablesBankName%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetPayablesBankDetails('<%#Eval("BankName")%>','<%#Eval("tbl_PayablesId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvPayablesBankName" Text='<%# Bind("BankName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htPaymentNumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesBankPaymentNumber" runat="server" Text='<%# Bind("PaymentNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htPayablesType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesBankPayablesType" runat="server" Text='<%# Bind("PayablesType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htProcessType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesBankProcessType" runat="server" Text='<%# Bind("ProcessType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htPayablesBankGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesBankGuid" runat="server" Text='<%# Bind("tbl_PayablesId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPayablesBankSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPayablesBankSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div3">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrPayablesBankClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalPayablesCashSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPayablesCashTitle"><span>
                        <asp:Literal runat="server" ID="ltrPayablesCashTitle" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_ltrPayablesCashTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPayablesCashSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPayablesCashSearch" DefaultButton="btnPayablesCashSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPayablesCashSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPayablesCashSearch" onclick="CallPayablesCashSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPayablesCashClose" visible="false" onclick="ClearPayablesCashSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPayablesCashSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPayablesCashSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPayablesCashSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPayablesCashSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPayablesCashSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPayablesCashSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPayablesCashSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPayablesCashSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPayablesCashData" AssociatedUpdatePanelID="updpnlgvPayablesCashSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPayablesCashSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPayablesCashRefresh" ClientIDMode="Static" OnClick="btnPayablesCashRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPayablesCashSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                      <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,NonPOBasedInvoice_htPayablesType %>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetPayablesCashDetails('<%#Eval("PayablesType")%>','<%#Eval("tbl_PayablesId")%>');">
                                               
                                                      <asp:Literal ID="ltrgvCashPayablesType" runat="server" Text='<%# Bind("PayablesType") %>'></asp:Literal>    
                                               
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htPaymentNumber%>">
                                            <ItemTemplate>
                                               <asp:Label runat="server" ID="lblgvPaymentNumber" Text='<%# Bind("PaymentNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htProcessType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesCashProcessType" runat="server" Text='<%# Bind("ProcessType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htPayablesCashGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesCashGuid" runat="server" Text='<%# Bind("tbl_PayablesId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPayablesCashSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPayablesCashSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div4">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrPayablesCashClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalPayablesChequeSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPayablesChequeTitle"><span>
                        <asp:Literal runat="server" ID="ltrPayablesChequeTitle" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_htSupplierType %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPayablesChequeSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPayablesChequeSearch" DefaultButton="btnPayablesChequeSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPayablesChequeSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPayablesChequeSearch" onclick="CallPayablesChequeSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPayablesChequeClose" visible="false" onclick="ClearPayablesChequeSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPayablesChequeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPayablesChequeSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPayablesChequeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPayablesChequeSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPayablesChequeSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPayablesChequeSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPayablesChequeSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPayablesChequeSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPayablesChequeData" AssociatedUpdatePanelID="updpnlgvPayablesChequeSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPayablesChequeSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPayablesChequeRefresh" ClientIDMode="Static" OnClick="btnPayablesChequeRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPayablesChequeSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,NonPOBasedInvoice_htPayablesType %>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetPayablesChequeDetails('<%#Eval("PayablesType")%>','<%#Eval("tbl_PayablesId")%>');">
                                                <asp:Literal ID="lblgvPayablesPayablestype" runat="server" Text='<%# Bind("PayablesType") %>'></asp:Literal>   
                                               
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htPaymentNumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesPaymentNumber" runat="server" Text='<%# Bind("PaymentNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,NonPOBasedInvoice_htChequeNumber %>">
                                            <ItemTemplate>
                                               <asp:Label runat="server" ID="ltrgvChequeNumber" Text='<%# Bind("ChequeNumber") %>'></asp:Label> 
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htProcessType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesProcesstype" runat="server" Text='<%# Bind("ProcessType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htPayablesGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesGuid" runat="server" Text='<%# Bind("tbl_PayablesId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPayablesChequeSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPayablesChequeSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div5">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrPayablesChequeClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

     <div class="modal fade" id="basicModalPayablesCreditCardSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPayablesCreditCardTitle"><span>
                        <asp:Literal runat="server" ID="ltrPayablesCreditCardTitle" Text="<%$ Resources:GlobalResource, NonPOBasedInvoice_htSupplierType %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlPayablesCreditCardSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlPayablesCreditCardSearch" DefaultButton="btnPayablesCreditCardSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtPayablesCreditCardSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlPayablesCreditCardSearch" onclick="CallPayablesCreditCardSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlPayablesCreditCardClose" visible="false" onclick="ClearPayablesCreditCardSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnPayablesCreditCardSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnPayablesCreditCardSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearPayablesCreditCardSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearPayablesCreditCardSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divPayablesCreditCardSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblPayablesCreditCardSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divPayablesCreditCardSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblPayablesCreditCardSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgPayablesCreditCardData" AssociatedUpdatePanelID="updpnlgvPayablesCreditCardSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvPayablesCreditCardSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnPayablesCreditCardRefresh" ClientIDMode="Static" OnClick="btnPayablesCreditCardRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvPayablesCreditCardSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                      <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htCreditCardName%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetPayablesCreditCardDetails('<%#Eval("CardName")%>','<%#Eval("tbl_PayablesId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvChequeNumber" Text='<%# Bind("CardName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htPaymentNumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCreditCardPaymentNumber" runat="server" Text='<%# Bind("PaymentNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htPayablesType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCreditCardPayablestype" runat="server" Text='<%# Bind("PayablesType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htProcessType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCreditCardProcesstype" runat="server" Text='<%# Bind("ProcessType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, NonPOBasedInvoice_htPayablesCreditCardGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesCreditCardGuid" runat="server" Text='<%# Bind("tbl_PayablesId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>       
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnPayablesCreditCardSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearPayablesCreditCardSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div6">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrPayablesCreditCardClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

