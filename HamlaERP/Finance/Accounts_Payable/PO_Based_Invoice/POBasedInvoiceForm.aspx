<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="POBasedInvoiceForm.aspx.cs" Inherits="Finance_Accounts_Payable_PO_Based_Invoice_POBasedInvoiceForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/PO_Based_Invoice_JS/POBasedInvoiceForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" Runat="Server">
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, POBasedInvoice_ltrInformation%>"></asp:Literal></h5>
                        </div>
                        
                        
                          <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblSupplier" Text="<%$ Resources:GlobalResource, POBasedInvoice_lblSupplier %>"></asp:Label>
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
                                <asp:Label runat="server" ID="lblCurrency" Text="<%$ Resources:GlobalResource, POBasedInvoice_lblCurrency %>"></asp:Label>
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

                            <asp:Label runat="server" ID="lblReceiptNmber" Text="<%$ Resources:GlobalResource, POBasedInvoice_lblReceiptNumber%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtReceiptNumber" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblPostingDate" Text="<%$ Resources:GlobalResource, POBasedInvoice_lblPostingDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtPostingDate" TextMode="Date"  ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        
                        </div>


                           <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblInvoiceDate" Text="<%$ Resources:GlobalResource, POBasedInvoice_lblInvoiceDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtInvoiceDate" TextMode="Date"  ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblBatch" Text="<%$ Resources:GlobalResource, POBasedInvoice_lblBatch %>"></asp:Label>
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

                            <div>
                                <asp:Label runat="server" ID="lblPaymentTerms" Text="<%$ Resources:GlobalResource, POBasedInvoice_lblPaymentTerms %>"></asp:Label>
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

                            <asp:Label runat="server" ID="lblSubTotalAmount" Text="<%$ Resources:GlobalResource, POBasedInvoice_lblSubTotalAmount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtSubTotalAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblTradeDiscountAmount" Text="<%$ Resources:GlobalResource, POBasedInvoice_lblTradeDiscountAmount%>"></asp:Label>
                        <asp:TextBox type="text" runat="server" ID="txtTradeDiscountAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>

                          <div class="form-group col-md-4 col-sm-4">

                        <asp:Label runat="server" ID="lblFreightAmount" Text="<%$ Resources:GlobalResource, POBasedInvoice_lblFreightAmount%>"></asp:Label>
                        <asp:TextBox type="text" runat="server" ID="txtFreightAmount" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                    </div>

                        
                        <div class="form-group col-md-4 col-sm-4">

                            <asp:Label runat="server" ID="lblTotalAmount" Text="<%$ Resources:GlobalResource, POBasedInvoice_lblTotalAmount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtTotalAmount"  ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

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
                        <asp:Literal runat="server" ID="ltrSupplierTitle" Text="<%$ Resources:GlobalResource, POBasedInvoice_ltrSupplierTitle %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, POBasedInvoice_htSupplierCode%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetSupplierDetails('<%#Eval("Name")%>','<%#Eval("tbl_SupplierId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvSupplierType" Text='<%# Bind("SupplierCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, POBasedInvoice_htSupplierName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSupplierName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, POBasedInvoice_htSupplierGuid%>" Visible="false">
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
                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, POBasedInvoice_ltrSupplierInformation %>"></asp:Literal>
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

                                           <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,POBasedInvoice_htCurrencyCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, POBasedInvoice_htCurrencyName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyName" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, POBasedInvoice_htCurrencyGuid%>" Visible="false">
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
       
      <div class="modal fade" id="basicModalBatchSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalBatchTitle"><span>
                        <asp:Literal runat="server" ID="ltrBatchTitle" Text="<%$ Resources:GlobalResource, POBasedInvoice_ltrBatchTitle %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlBatchSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlBatchSearch" DefaultButton="btnBatchSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtBatchSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, POBasedInvoice_htBatchType%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetBatchDetails('<%#Eval("BatchName")%>','<%#Eval("tbl_BatchId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvBatchType" Text='<%# Bind("Opt_BatchType") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, POBasedInvoice_htBatchName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchName" runat="server" Text='<%# Bind("BatchName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, POBasedInvoice_htBatchGuid%>" Visible="false">
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

     <div class="modal fade" id="basicModalPaymentTermsSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPaymentTermsTitle"><span>
                        <asp:Literal runat="server" ID="ltrPaymentTermsTitle" Text="<%$ Resources:GlobalResource, POBasedInvoice_ltrPaymentTermsTitle %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, POBasedInvoice_htPaymentTermsName%>">
                                            <ItemTemplate>
                                                 <a href="#" data-dismiss="modal" onclick="SetPaymentTermsDetails('<%#Eval("PaymentTermsName")%>','<%#Eval("tbl_PaymentTermsId")%>');">
                                                   
                                               <asp:Literal runat="server" ID="ltrgvPaymentTermsType" Text='<%# Bind("PaymentTermsName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, POBasedInvoice_htPaymentTermsGuid%>" Visible="false">
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
</asp:Content>

