<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="~/System_Settings/BankSetup/BankAccountingSetupForm.aspx.cs" Inherits="System_Settings_BankAccountingSetupForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script src="../../infra_ui/js/System_Settings_JS/BankSetup_JS/BankAccountingSetupForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrBankAccountingSetupInformation" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrInformation%>"></asp:Literal></h5>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDepositcode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblDepositcode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDepositcode" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAlphaNumberKey(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDeposit" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblDeposit %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDeposit" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKey(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblReceiptCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblReceiptCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtReceiptCode" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAddress(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblReceipt" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblReceipte %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtReceipt" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKeyPoint(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCheckCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblCheckCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCheckCode" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAddress(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblCheck" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblCheck %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtCheck" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKeyPoint(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblWithdrawalCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblWithdrawalCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtWithdrawalCode" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAddress(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblWithdrawal" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblWithdrawal %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtWithdrawal" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKeyPoint(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblIncreaseAdjustmentCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblIncreaseAdjustmentCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtIncreaseAdjustmentCode" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAddress(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblIncreaseAdjustment" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblIncreaseAdjustment%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtIncreaseAdjustment" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKeyPoint(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDecreaseAdjustmentCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblDecreaseAdjustmentCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDecreaseAdjustmentCode" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAddress(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblDecreaseAdjustment" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblDecreaseAdjustment%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtDecreaseAdjustment" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKeyPoint(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTransferCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblTransferCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtTransferCode" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAddress(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblTransfer" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblTransfer%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtTransfer" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKeyPoint(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblIsTransaction_Reconcilation" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblIsTransaction_Reconcilation%>"></asp:Label>
                            <asp:CheckBox ID="chkIsTransaction_Reconcilation" runat="server" ClientIDMode="Static" class="form-control"></asp:CheckBox>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblChequeBook" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblChequeBook%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtChequeBook" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addonChequeBook">
                                    <a href="#" data-toggle="modal" data-target="#basicModalChequeBookSearch" data-keyboard="false" data-backdrop="static" onclick="CallChequeBookRefreshButton();">
                                        <i class="fa fa-search"></i></a>
                                </span>

                                <asp:TextBox ID="txtChequeBookGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblInterestIncomeCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblInterestIncomeCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtInterestIncomeCode" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAddress(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblInterestIncome" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblInterestIncome%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtInterestIncome" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKeyPoint(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOtherIncomeCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblOtherIncomeCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtOtherIncomeCode" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAddress(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOtherIncome" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblOtherIncome%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtOtherIncome" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKeyPoint(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOtherExpenseCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblOtherExpenseCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtOtherExpenseCode" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAddress(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblOtherExpense" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblOtherExpense%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtOtherExpense" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKeyPoint(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblServiceChargeCode" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblServiceChargeCode %>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtServiceChargeCode" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isAddress(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label runat="server" ID="lblServiceCharge" Text="<%$ Resources:GlobalResource, BankAccountingSetup_lblServiceCharge%>"></asp:Label>
                            <asp:TextBox runat="server" ID="txtServiceCharge" ClientIDMode="Static" class="form-control" placeholder="" onkeypress="return isNumberKeyPoint(this);" MaxLength="50" required="required"></asp:TextBox>

                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="modal fade" id="basicModalChequeBookSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalChequeBookTitle"><span>
                        <asp:Literal runat="server" ID="ltrChequeBookTitle" Text="<%$ Resources:GlobalResource, BankAccountingSetup_ltrChequeBookInformation%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlChequeBook">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlChequeBook" DefaultButton="btnChequeBookSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtChequeBookSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlChequeBookSearch" onclick="CallChequeBookSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlChequeBookClose" visible="false" onclick="ClearChequeBookSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>

                                <asp:Button runat="server" ID="btnChequeBookSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnChequeBookSearch_Click" formnovalidate="formnovalidate " />
                                <asp:Button runat="server" ID="btnClearChequeBookSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearChequeBookSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divChequeBookSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblChequeBookSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divChequeBookSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblChequeBookSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgChequeBookData" AssociatedUpdatePanelID="updpnlgvChequeBookSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvChequeBookSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnChequeBookRefresh" ClientIDMode="Static" OnClick="btnChequeBookRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvChequeBookSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, BankAccountingSetup_htChequeBookNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetChequeBookDetails('<%#Eval("ChequeBookName")%>','<%#Eval("tbl_ChequeBookId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvChequeBookNumber" Text='<%# Bind("ChequeBookNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, BankAccountingSetup_htChequeBookGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvChequeBookGuid" runat="server" Text='<%# Bind("tbl_ChequeBookId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnChequeBookSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearChequeBookSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divChequeBookFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblChequeBookClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

