﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="EmployeeGeneralExpensesForm.aspx.cs" Inherits="Finance_Accounts_Payable_Employee_General_Expenses_EmployeeGeneralExpensesForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../../infra_ui/js/Finance_JS/Accounts_Payable_JS/Employee_General_Expenses_JS/EmployeeGeneralExpensesForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrEmployeeGeneralExpenses" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_ltrInformation%>"></asp:Literal></h5>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblVoucherNumber" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblVoucherNumber%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtVoucherNumber" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblInterCompany" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblInterCompany%>"></asp:Label>
                            <asp:CheckBox runat="server" ID="chckInterCompany" Checked="false" ClientIDMode="Static" class="form-control" placeholder="" required="required" />
                        </div>



                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDocumentType" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblDocumentType%>"></asp:Label>
                            <asp:DropDownList ID="ddlOpt_DocumentType" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required">
                            </asp:DropDownList>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblBatchId" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblBatchId %>"></asp:Label>
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

                        <div class="col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrencyId" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblCurrencyId %>"></asp:Label>
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

                        <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblEmployeeId" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblEmployeeId %>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtEmployeeId" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon1">
                                     <a href="#" data-toggle="modal" data-target="#basicModalEmployeeSearch" data-keyboard="false" data-backdrop="static" onclick="CallEmployeeRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtEmployeeIdGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDescription" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblDistribution%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDescription" ClientIDMode="Static" class="form-control" placeholder="" required="required" autofocus="autofocus"></asp:TextBox>
                        </div>





                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDocumentDate" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblDocumentDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtDocumentDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>



                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblPostingDate" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblPostingDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtPostingDate" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblInvoiceDate" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblInvoiceDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtInvoiceDate" TextMode="Date" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblReceivedDate" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblReceivedDate%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtReceivedDate" TextMode="Date" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>




                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblExpenses" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblExpenses%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtExpenses" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPayablesId_BankTransfer" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblPayablesBankTransfer %>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtPayablesBank" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addon3">
                                     <a href="#" data-toggle="modal" data-target="#basicModalPayablesBankTransferSearch" data-keyboard="false" data-backdrop="static" onclick="CallPayablesBankRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtPayablesBankGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPayablesCash" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblPayablesCash%>"></asp:Label>
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

                        <div class="col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPayablesCheque" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblPayablesCheque%>"></asp:Label>
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
                            <asp:Label runat="server" ID="lblBankTransferAmount" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblBankTransferAmount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtBankTransferAmount" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>



                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCash" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblCash%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtCash" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>





                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCheque" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblCheque%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtCheque" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>



                        <div class="col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblPayablesCreditCard" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblPayablesCreditCard%>"></asp:Label>
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
                            <asp:Label runat="server" ID="lblCreditCard" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblCreditCard%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtCreditCard" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOnAmount" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_lblOnAmount%>"></asp:Label>
                            <asp:TextBox type="text" runat="server" ID="txtOnAmount" ClientIDMode="Static" class="form-control " placeholder="" required="required"></asp:TextBox>
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
                        <asp:Literal runat="server" ID="ltr_Batch_information1" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_ltrinformation %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,EmployeeGeneralExpenses_htBatchType%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetBatchDetails('<%#Eval("BatchName")%>','<%#Eval("tbl_BatchId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvBatchType" Text='<%# Bind("Opt_BatchType") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htBatchName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBatchName" runat="server" Text='<%# Bind("BatchName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htBatchGuid%>" Visible="false">
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
                        <asp:Literal runat="server" ID="ltrCurrencyTitle" Text="<%$ Resources:GlobalResource, Currency_ltrCurrency%>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htCurrencyCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetCurrencyDetails('<%#Eval("CurrencyName")%>','<%#Eval("tbl_CurrencyId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvCurrencyCode" Text='<%# Bind("CurrencyCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,htName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCurrencyName" runat="server" Text='<%# Bind("CurrencyName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,EmployeeGeneralExpenses_htCurrencyGuid%>" Visible="false">
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

    <div class="modal fade" id="basicModalEmployeeSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalEmployeeTitle"><span>
                        <asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_ltrinformation %>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="UpdateEmployeeSearch">
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,EmployeeGeneralExpenses_htEmployeeCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetEmployeeDetails('<%#Eval("Name")%>','<%#Eval("tbl_EmployeeId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvEmployeeType" Text='<%# Bind("EmployeeCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htEmployeeName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvEmployeeName" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htEmployeeGuid%>" Visible="false">
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
                <div class="modal-footer row" runat="server" id="div3">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="Literal2" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalPayablesBankTransferSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalPayablesBankTitle"><span>
                        <asp:Literal runat="server" ID="ltrPayablesBankTitle" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_ltrPayablesBankTitle %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htPayablesBankName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPayablesBankDetails('<%#Eval("BankName")%>','<%#Eval("tbl_PayablesId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvPayablesBankName" Text='<%# Bind("BankName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htPaymentNumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesBankPaymentNumber" runat="server" Text='<%# Bind("PaymentNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htPayablesType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesBankPayablesType" runat="server" Text='<%# Bind("PayablesType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htProcessType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesBankProcessType" runat="server" Text='<%# Bind("ProcessType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htBankPayablesGuid%>" Visible="false">
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
                <div class="modal-footer row" runat="server" id="div1">
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
                        <asp:Literal runat="server" ID="ltrPayablesCashTitle" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_ltrPayablesCashTitle %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htPaymentNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPayablesCashDetails('<%#Eval("PaymentNumber")%>','<%#Eval("tbl_PayablesId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvPaymentNumber" Text='<%# Bind("PaymentNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htPayablesType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCashPayablesType" runat="server" Text='<%# Bind("PayablesType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htProcessType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesCashProcessType" runat="server" Text='<%# Bind("ProcessType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htPayablesCashGuid%>" Visible="false">
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
                        <asp:Literal runat="server" ID="ltrPayablesChequeTitle" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htPayablesChequeTitle %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htChequeNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPayablesChequeDetails('<%#Eval("ChequeNumber")%>','<%#Eval("tbl_PayablesId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvChequeNumber" Text='<%# Bind("ChequeNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htPaymentNumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesPaymentNumber" runat="server" Text='<%# Bind("PaymentNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htPayablesType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesPayablestype" runat="server" Text='<%# Bind("PayablesType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htProcessType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvPayablesProcesstype" runat="server" Text='<%# Bind("ProcessType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,  EmployeeGeneralExpenses_htPayablesGuid  %>" Visible="false">
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
                        <asp:Literal runat="server" ID="ltrPayablesCreditCardTitle" Text="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htpayablesCreditCard %>"></asp:Literal>
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htCreditCardName%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetPayablesCreditCardDetails('<%#Eval("CardName")%>','<%#Eval("tbl_PayablesId")%>');">

                                                    <asp:Literal runat="server" ID="ltrgvChequeNumber" Text='<%# Bind("CardName") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htPaymentNumber%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCreditCardPaymentNumber" runat="server" Text='<%# Bind("PaymentNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htPayablesType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCreditCardPayablestype" runat="server" Text='<%# Bind("PayablesType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htProcessType%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvCreditCardProcesstype" runat="server" Text='<%# Bind("ProcessType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, EmployeeGeneralExpenses_htPayablesCreditCardGuid%>" Visible="false">
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


