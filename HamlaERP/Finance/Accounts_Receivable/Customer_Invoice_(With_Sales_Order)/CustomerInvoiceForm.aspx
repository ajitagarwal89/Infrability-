<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CustomerInvoiceForm.aspx.cs" Inherits="Finance_Accounts_Receivable_Customer__Invoice__With_Sales_Order_CustomerInvoiceForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Receivable_JS/Customer%20_Invoice_(With_Sales_Order)_JS/CustomerInvoiceForm.js"></script>
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
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" formnovalidate="formnovalidate"></asp:Button>
                     <asp:Button runat="server" ID="btnAuditHistory" CssClass="btn btn-success" Text="<%$ Resources:GlobalResource, btnAuditHistory%>" formnovalidate="formnovalidate" OnClick="btnAuditHistory_Click" />
					 <asp:Button runat="server" ID="btnPost" CssClass="btn btn-success" OnClick="btnPost_Click" Text="<%$ Resources:GlobalResource, btnPost%>" formnovalidate="formnovalidate"></asp:Button>
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
                                <asp:Literal runat="server" ID="ltrInformation" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrInformation%>"></asp:Literal></h5>
                        </div>
                       

						 <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCustomerPONumber" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblCustomerPONumber%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCustomerPONumber" ClientIDMode="Static" onkeypress="return isAlphaNumberKey(this);" MaxLength="20" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDocumentDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblDocumentDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDocumentDate" ClientIDMode="Static" class="form-control" TextMode="Date" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDocumentNumber" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblDocumentNumber%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDocumentNumber" ClientIDMode="Static" ReadOnly="true" onkeypress="return isAlphaNumberKey(this);" MaxLength="20"  class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblInvoiceAndOrderTypeId" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblInvoiceAndOrderTypeId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtInvoiceAndOrderType" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon2">
                                     <a href="#" data-toggle="modal" data-target="#basicModalInvoiceAndOrderTypeSearch" data-keyboard="false" data-backdrop="static" onclick="CallInvoiceAndOrderTypeRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtInvoiceAndOrderTypeGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblInvoiceAndOrderType" TabIndex="1" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblInvoiceAndOrderTypeId%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_InvoiceAndOrderType" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                      
                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblBatchId" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblBatchId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtBatch" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control "></asp:TextBox>
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
                                <asp:Label runat="server" ID="lblCustomerId" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblCustomerId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCustomer" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control "></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonCustomer">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCustomerSearch" data-keyboard="false" data-backdrop="static" onclick="CallCustomerRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtCustomerGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                             <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrencyId" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblCurrencyId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCurrency" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control "></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon_Cuurency">
                                     <a href="#" data-toggle="modal" data-target="#basicModalCurrencySearch" data-keyboard="false" data-backdrop="static" onclick="CallCurrencyRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtCurrencyGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblSitesId" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblSitesId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtSites" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonSites">
                                     <a href="#" data-toggle="modal" data-target="#basicModalSitesSearch" data-keyboard="false" data-backdrop="static" onclick="CallSitesRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtSitesGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>
                       


                   
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOpt_DocumentStatus" TabIndex="1" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblOpt_DocumentStatus%>" display="none"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_DocumentStatus" runat="server" ClientIDMode="Static" class="form-control " placeholder="" required="required" display="none">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPostingDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblPostingDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtPostingDate" ClientIDMode="Static" class="form-control " TextMode="Date" placeholder="" required="required"></asp:TextBox>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblQuoteDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblQuoteDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtQuoteDate" ClientIDMode="Static" class="form-control " TextMode="Date" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOrderDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblOrderDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtOrderDate" ClientIDMode="Static" class="form-control " TextMode="Date" placeholder="" required="required"></asp:TextBox>
                        </div>
						<asp:UpdatePanel ID="uplInvoiceDate" runat="server" >
							<ContentTemplate>
								  <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblInvoiceDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblInvoiceDate %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtInvoiceDate" ClientIDMode="Static" class="form-control" TextMode="Date" AutoPostBack="true"  placeholder="" required="required" OnTextChanged="txtInvoiceDate_TextChanged"></asp:TextBox>
                        </div>
							</ContentTemplate>
						</asp:UpdatePanel>                     


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblBackOrderDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblBackOrderDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtBackOrderDate" ClientIDMode="Static" class="form-control" TextMode="Date" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblReturnDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblReturnDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtReturnDate" ClientIDMode="Static" class="form-control " TextMode="Date" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblRequestedShipDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblRequestedShipDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtRequestedShipDate" ClientIDMode="Static" class="form-control" TextMode="Date" placeholder="" required="required"></asp:TextBox>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDateFulfilled" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblDateFulfilled%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDateFulfilled" ClientIDMode="Static" class="form-control " TextMode="Date" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblActualShipDate" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblActualShipDate%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtActualShipDate" ClientIDMode="Static" class="form-control " TextMode="Date" placeholder="" required="required"></asp:TextBox>
                        </div>
						<div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblAmountReceived" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblAmountReceived%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtAmountReceived" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOnAccount" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblOnAccount%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtOnAccount" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblSubTotalAmount" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblSubTotalAmount%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtSubTotalAmount" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTradeDiscountAmount" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblTradeDiscountAmount%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtTradeDiscountAmount" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblFreightAmount" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblFreightAmount%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtFreightAmount" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTotalAmount" Text="<%$ Resources:GlobalResource, CustomerInvoice_lblTotalAmount%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtTotalAmount" ClientIDMode="Static" onkeypress="return isNumberKeyPoint(this);" MaxLength="9" class="form-control " placeholder="" required="required"></asp:TextBox>
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
                        <asp:Literal runat="server" ID="ltrBatchTitle" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrBatch_List %>"></asp:Literal>
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
                        <asp:UpdateProgress runat="server" ID="updProgData" AssociatedUpdatePanelID="updpnlgvBatchSearch">
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htBatch%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetBatchDetails('<%#Eval("BatchName")%>','<%#Eval("tbl_BatchId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvBatchType" Text='<%# Bind("Opt_BatchType") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htBatchName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchName" runat="server" Text='<%# Bind("BatchName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htBatchGuid %>" Visible="false">
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
    <div class="modal fade" id="basicModalCurrencySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCurrencyTitle"><span>
                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrCurrency%>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,CustomerInvoice_htCurrency%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htCode%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyCode" runat="server" Text='<%# Bind("CurrencyCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htCurrencyGuid %>"  Visible="false">
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
    <div class="modal fade" id="basicModalCustomerSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCustomerTitle"><span>
                        <asp:Literal runat="server" ID="ltr_CustomerInfomation" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltr_CustomerInfomation %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCustomerSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCustomerSearch" DefaultButton="btnCustomerSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCustomerSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCustomerSearch" onclick="CallCustomerSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCustomerClose" visible="false" onclick="ClearCustomerSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCustomerSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCustomerSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCustomerSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCustomerSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divCustomerSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblCustomerSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divCustomerSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblCustomerSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateProgress" AssociatedUpdatePanelID="updpnlgvCustomerSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvCustomerSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnCustomerRefresh" ClientIDMode="Static" OnClick="btnCustomerRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvCustomerSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_ht_tbl_CustomerName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCustomerDetails('<%#Eval("Name")%>','<%#Eval("tbl_CustomerId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCustomerCode" Text='<%# Bind("Name") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,CustomerInvoice_ht_tbl_CustomerCode%>">
                                            <ItemTemplate>

                                                <asp:Literal runat="server" ID="ltrgvCustomerCode" Text='<%# Bind("CustomerCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htCustomerGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgv_CustomerId" runat="server" Text='<%# Bind("tbl_CustomerId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnCustomerSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearCustomerSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div1">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrCustomerClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="basicModalSitesSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalSitesTitle"><span>
                        <asp:Literal runat="server" ID="ltrSitesTitle" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrSitesInfomation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlSites">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlSites" DefaultButton="btnSitesSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSitesSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlSitesSearch" onclick="CallSitesSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlSitesClose" visible="false" onclick="ClearSitesSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnSitesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnSitesSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearSitesSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearSitesSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divSitesSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblSitesSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divSitesSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblSitesSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgSitesData" AssociatedUpdatePanelID="updpnlgvSitesSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvSitesSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnSitesRefresh" ClientIDMode="Static" OnClick="btnSitesRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvSitesSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,CustomerInvoice_ht_tbl_SiteName%>">
                                            <ItemTemplate>

                                                <a href="#" data-dismiss="modal" onclick="SetSitesDetails('<%#Eval("Description")%>','<%#Eval("tbl_SitesId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvSiteNumber" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htSitesNumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSiteNumber" runat="server" Text='<%# Bind("SiteNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htSitesGuid %>"  Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSitesuid" runat="server" Text='<%# Bind("tbl_SitesId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSitesSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearSitesSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divSitesFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblSitesClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="basicModalInvoiceAndOrderTypeSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrInvoiceAndOrderTypeTitle"><span>
                        <asp:Literal runat="server" ID="ltrInvoiceAndOrderType" Text="<%$ Resources:GlobalResource, CustomerInvoice_ltrInvoiceAndOrderType %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlInvoiceAndOrderType">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlInvoiceAndOrderType" DefaultButton="btnInvoiceAndOrderTypeSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtInvoiceAndOrderTypeSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlInvoiceAndOrderTypeSearch" onclick="CallInvoiceAndOrderTypeSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlInvoiceAndOrderTypeClose" visible="false" onclick="ClearInvoiceAndOrderTypeSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnInvoiceAndOrderTypeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnInvoiceAndOrderTypeSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearInvoiceAndOrderTypeSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearInvoiceAndOrderTypeSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divInvoiceAndOrderTypeSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblInvoiceAndOrderTypeSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divInvoiceAndOrderTypeSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblInvoiceAndOrderTypeSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="UpdateInvoiceAndOrderTypeProgress" AssociatedUpdatePanelID="updpnlgvInvoiceAndOrderTypeSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvInvoiceAndOrderTypeSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnInvoiceAndOrderTypeRefresh" ClientIDMode="Static" OnClick="btnInvoiceAndOrderTypeRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvInvoiceAndOrderTypeSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_htInvoiceAndOrderType%> ">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetInvoiceAndOrderTypeDetails('<%#Eval("InvoiceAndOrderType")%>','<%#Eval("tbl_InvoiceAndOrderTypeId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvInvoiceAndOrderTypeNumber" Text='<%# Bind("InvoiceAndOrderType") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, CustomerInvoice_ht_Number%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoiceAndOrderTypeNumber" runat="server" Text='<%# Bind("Number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$  Resources:GlobalResource,CustomerInvoice_htInvoiceAndOrderTypeGuid %>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoiceAndOrderTypeId" runat="server" Text='<%# Bind("tbl_InvoiceAndOrderTypeId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnInvoiceAndOrderTypeSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearInvoiceAndOrderTypeSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div2">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrInvoiceAndOrderTypeClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

