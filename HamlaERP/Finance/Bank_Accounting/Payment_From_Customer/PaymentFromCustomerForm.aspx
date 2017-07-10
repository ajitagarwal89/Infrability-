<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PaymentFromCustomerForm.aspx.cs" Inherits="Finance_Bank_Accounting_Payment_From_Customer_PaymentFromCustomerForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Bank_Accounting_JS/Payment_From_Customer/PaymentFromCustomerForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageContent" runat="Server">
    <div id="content" class="ui-content ui-content-aside-overlay">
        <!--page header start-->
        <div id="ButtonBar" class="page-head-wrap">
            <div class="row">
                <div class="btn-group col-md-12 col-xs-12 pull-left" role="group">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-success" OnClick="btnSave_Click" Text="<%$ Resources:GlobalResource, btnSave%>" />
                    <asp:Button runat="server" ID="btnUpdate" CssClass="btn btn-success" OnClick="btnUpdate_Click" Text="<%$ Resources:GlobalResource, btnUpdate%>" />
                    <asp:Button runat="server" ID="btnDelete" CssClass="btn btn-success" OnClick="btnDelete_Click" Text="<%$ Resources:GlobalResource, btnDelete%>" formnovalidate="formnovalidate" />
                    <asp:Button runat="server" ID="btnBack" CssClass="btn btn-success" OnClick="btnBack_Click" Text="<%$ Resources:GlobalResource, btnBack%>" formnovalidate="formnovalidate" />
                    <asp:Button runat="server" ID="btnClear" CssClass="btn btn-success" OnClientClick="return ClearForm();" Text="<%$ Resources:GlobalResource, btnClear%>" formnovalidate="formnovalidate"></asp:Button>
                     <asp:Button runat="server" ID="btnApply" CssClass="btn btn-success" OnClick="btnApply_Click" Text="<%$ Resources:GlobalResource, btnApply%>"  formnovalidate="formnovalidate"></asp:Button>
                    <asp:Button runat="server" ID="btnDistribution" CssClass="btn btn-success" OnClick="btnDistribution_Click" Text="<%$ Resources:GlobalResource, btnDistribution%>"  formnovalidate="formnovalidate"></asp:Button>

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
                                <asp:Literal runat="server" ID="ltrPaymentFromCustomer" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_ltrInformation%>"></asp:Literal></h5>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblReceiptNumber" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblReceiptNumber%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtReceiptNumber" ClientIDMode="Static" class="form-control" placeholder="" required="required" autofocus="autofocus"></asp:TextBox>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblReceiptDate" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblReceiptDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtReceiptDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                           <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblBatchId" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblBatchId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtBatchId" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon">
                                    <a href="#" data-toggle="modal" data-target="#basicModalBatchSearch" data-keyboard="false" data-backdrop="static" onclick="CallBatchRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtBatchIdGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCustomerId" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblCustomerId %>"></asp:Label>
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


                         <div class="col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrencyId" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblCurrencyId %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtCurrency" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon2">
                                    <a href="#" data-toggle="modal" data-target="#basicModalCurrencySearch" data-keyboard="false" data-backdrop="static" onclick="CallCurrencyRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtCurrencyGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                         <div class="col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPayablesCash" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblPayablesCash%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPayablesCash" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon4">
                                     <a href="#" data-toggle="modal" data-target="#basicModalPayablesCashSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayablesCashRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayablesCashGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                             <asp:Label runat="server" ID="lblCashAmount"  Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblCashAmount%>"></asp:Label>
                             <asp:TextBox type="text" runat="server" ID="txtCashAmount"  ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                         <div class="col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPayablesCheque" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblPayablesCheque%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPayablesCheque" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon5">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPayablesChequeSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayablesChequeRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayablesChequeGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                             <asp:Label runat="server" ID="lblChequeAmount"  Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblChequeAmount%>"></asp:Label>
                             <asp:TextBox type="text" runat="server" ID="txtChequeAmount"  ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                        <div class="col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPayablesCreditCard" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblPayablesCreditCard%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPayablesCreditCard" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon6">
                                    <a href="#" data-toggle="modal" data-target="#basicModalPayablesCreditCardSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayablesCreditCardRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayablesCreditCardGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                             <asp:Label runat="server" ID="lblCreditCardAmount"  Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblCreditCardAmount%>"></asp:Label>
                             <asp:TextBox type="text" runat="server" ID="txtCreditCardAmount"  ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                             <asp:Label runat="server" ID="lblDocumentNumber"  Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblDocumentNumber%>"></asp:Label>
                             <asp:TextBox type="text" runat="server" ID="txtDocumentNumber"  ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                             <asp:Label runat="server" ID="lblComments"  Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblComments%>"></asp:Label>
                             <asp:TextBox type="text" runat="server" ID="txtComments"  ClientIDMode="Static" TextMode="MultiLine" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                             <asp:Label runat="server" ID="lblIsAutoApplyTo"  Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblIsAutoApplyTo%>"></asp:Label>
                             <asp:CheckBox Checked="false" runat="server" ID="chckIsAutoApplyTo"  ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:CheckBox>
                        </div>

                          <div class="form-group col-md-4 col-sm-4">
                             <asp:Label runat="server" ID="lblIsPosted"  Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblIsPosted%>"></asp:Label>
                             <asp:CheckBox Checked="false" runat="server" ID="chckIsPosted"  ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:CheckBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                             <asp:Label runat="server" ID="lblPostingDate"  Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblPostingDate%>"></asp:Label>
                             <asp:TextBox type="text" runat="server" ID="txtPostingDate"  ClientIDMode="Static" TextMode="Date" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                             <asp:Label runat="server" ID="lblApplyDate"  Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblApplyDate%>"></asp:Label>
                             <asp:TextBox type="text" runat="server" ID="txtApplyDate"  ClientIDMode="Static" TextMode="Date" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblPaymentFromCustomer" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_SourceDocument%>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtSourceDocument" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon1">
                                    <a href="#" data-toggle="modal" data-target="#basicModalSourceDocumentSearch" data-keyboard="false" data-backdrop="static" onclick="CallSourceDocumentRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtSourceDocumentGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                       <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDocumentType" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblDocumentType%>"></asp:Label>
                              <asp:DropDownList ID="ddlOpt_DocumentType" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                             <asp:Label runat="server" ID="lblTotal"  Text="<%$ Resources:GlobalResource, PaymentFromCustomer_lblTotal%>"></asp:Label>
                             <asp:TextBox type="text" runat="server" ID="txtTotal"  ClientIDMode="Static"  class="form-control" placeholder="" required="required" ></asp:TextBox>
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
                        <asp:Literal runat="server" ID="ltr_Batch_information1" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_ltrBatchinformation %>"></asp:Literal>
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
                                <asp:Button runat="server" ID="btnBatchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnBatchSearch_Click" formnovalidate="formnovalidate"/>
                                <asp:Button runat="server" ID="btnClearBatchSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearBatchSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divBatchSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblBatchSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divBatchSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="BatchSearchSuccess"></asp:Label>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PaymentFromCustomer_htBatchType%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetBatchDetails('<%#Eval("BatchName")%>','<%#Eval("tbl_BatchId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvBatchType" Text='<%# Bind("Opt_BatchType") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htBatchName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchName" runat="server" Text='<%# Bind("BatchName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htBatchGuid%>" Visible="false">
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

     <div class="modal fade" id="basicModalCustomerSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCustomerTitle"><span>
                        <asp:Literal runat="server" ID="ltr_CustomerInfomation" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_ltrCustomerInfomation %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_CustomerName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCustomerDetails('<%#Eval("Name")%>','<%#Eval("tbl_CustomerId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCustomerCode" Text='<%# Bind("Name") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PaymentFromCustomer_CustomerCode%>">
                                            <ItemTemplate>

                                                <asp:Literal runat="server" ID="ltrgvCustomerCode" Text='<%# Bind("CustomerCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htCustomerGuid %>" Visible="false">
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

      <div class="modal fade" id="basicModalCurrencySearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalCurrencyTitle"><span>
                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_ltrCurrency%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlCurrencySearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlCurrencySearch" DefaultButton="btnCurrencySearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtCurrencySearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlCurrencySearch" onclick="CallCurrencySearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlCurrencyClose" visible="false" onclick="ClearCurrencySearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnCurrencySearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearCurrencySearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearCurrencySearch_Click" />
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htCurrencyCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,PaymentFromCustomer_htCurrencyName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyName" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htCurrencyGuid%>" Visible="false">
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

    <div class="modal fade" id="basicModalPayablesCashSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPayablesCashTitle"><span>
                        <asp:Literal runat="server" ID="ltrPayablesCashTitle" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_ltrPayablesCashTitle %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htPaymentNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPayablesCashDetails('<%#Eval("PaymentNumber")%>','<%#Eval("tbl_PayablesId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvPaymentNumber" Text='<%# Bind("PaymentNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htPayablesType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCashPayablesType" runat="server" Text='<%# Bind("PayablesType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htProcessType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesCashProcessType" runat="server" Text='<%# Bind("ProcessType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htPayablesCashGuid%>" Visible="false">
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
                        <asp:Literal runat="server" ID="ltrPayablesChequeTitle" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_htPayablesChequeTitle %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htChequeNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPayablesChequeDetails('<%#Eval("ChequeNumber")%>','<%#Eval("tbl_PayablesId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvChequeNumber" Text='<%# Bind("ChequeNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htPaymentNumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesPaymentNumber" runat="server" Text='<%# Bind("PaymentNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htPayablesType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesPayablestype" runat="server" Text='<%# Bind("PayablesType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htProcessType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesProcesstype" runat="server" Text='<%# Bind("ProcessType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,  PaymentFromCustomer_htPayablesGuid  %>" Visible="false">
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
                        <asp:Literal runat="server" ID="ltrPayablesCreditCardTitle" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_htpayablesCreditCard %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htCreditCardName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPayablesCreditCardDetails('<%#Eval("CardName")%>','<%#Eval("tbl_PayablesId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvChequeNumber" Text='<%# Bind("CardName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htPaymentNumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCreditCardPaymentNumber" runat="server" Text='<%# Bind("PaymentNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htPayablesType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCreditCardPayablestype" runat="server" Text='<%# Bind("PayablesType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htProcessType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCreditCardProcesstype" runat="server" Text='<%# Bind("ProcessType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htPayablesCreditCardGuid%>" Visible="false">
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

     <div class="modal fade" id="basicModalSourceDocumentSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalSourceDocumentTitle"><span>
                        <asp:Literal runat="server" ID="ltrSourceDocument" Text="<%$ Resources:GlobalResource, PaymentFromCustomer_ltrSourceDocumentInformation %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlSourceDocumentSearch">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlSourceDocumentSearch" DefaultButton="btnSourceDocumentSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtSourceDocumentSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlSourceDocumentSearch" onclick="CallSourceDocumentSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlSourceDocumentClose" visible="false" onclick="ClearSourceDocumentSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnSourceDocumentSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnSourceDocumentSearch_Click" formnovalidate="formnovalidate"/>
                                <asp:Button runat="server" ID="btnClearSourceDocumentSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearSourceDocumentSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divSourceDocumentSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblSourceDocumentSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divSourceDocumentSearchSuccess" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="SourceDocumentSearchSuccess"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgSourceDocumentData" AssociatedUpdatePanelID="updpnlgvSourceDocumentSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvSourceDocumentSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnSourceDocumentRefresh" ClientIDMode="Static" OnClick="btnSourceDocumentRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvSourceDocumentSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htDescription%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetSourceDocumentDetails('<%#Eval("DocumentNumber")%>','<%#Eval("tbl_SourceDocumentId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvSourceDocumentType" Text='<%# Bind("Description") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htDocumentNumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvDocumentNumber" runat="server" Text='<%# Bind("DocumentNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, PaymentFromCustomer_htSourceDocumentGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvSourceDocumentGuid" runat="server" Text='<%# Bind("tbl_SourceDocumentId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnSourceDocumentSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearSourceDocumentSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div2">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="ltrSourceDocumentClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>



  </asp:Content> 

