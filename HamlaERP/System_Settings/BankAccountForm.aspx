<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BankAccountForm.aspx.cs" Inherits="System_Settings_BankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server"> 
    <script src="../infra_ui/js/System_Settings_JS/BankAccountForm.js"></script>
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
                                <asp:Literal runat="server" ID="ltrBatchAccountInformation" Text="<%$ Resources:GlobalResource, BankAccount_ltrBankAccountInformation%>"></asp:Literal></h5>
                        </div>
                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label ID="lblBankAccountId" runat="server" Text="<%$ Resources:GlobalResource, BankAccount_lblBankAccountId%>"></asp:Label>
                            <asp:TextBox type="text" ID="txtBankAccountId" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" autofocus="autofocus"></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label ID="lblDescription" runat="server" Text="<%$ Resources:GlobalResource, BankAccount_lblDescription%>"></asp:Label>
                            <asp:TextBox type="text" ID="txtDescription" TextMode="MultiLine" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label ID="lblIsInactive" runat="server" Text="<%$ Resources:GlobalResource, BankAccount_lblIsInactive%>"></asp:Label>
                            <asp:CheckBox Checked="false" ID="ChckIsInactive" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:CheckBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label ID="lblIBAN" runat="server" Text="<%$ Resources:GlobalResource, BankAccount_lblIBAN%>"></asp:Label>
                            <asp:TextBox type="text" ID="txtIban"  runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                        <div class="col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblCurrencyId" Text="<%$ Resources:GlobalResource, BankAccount_lblCurrencyId %>"></asp:Label>
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
                            <asp:Label ID="lblChequeBookBalance" runat="server" Text="<%$ Resources:GlobalResource, BankAccount_lblChequeBookBalance%>"></asp:Label>
                            <asp:TextBox type="text" ID="txtChequebookBal"  runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label ID="lblCashAccountBalance" runat="server" Text="<%$ Resources:GlobalResource, BankAccount_lblCashAccountBalance%>"></asp:Label>
                            <asp:TextBox type="text" ID="txtCashAccountBal"  runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <div>
                                <asp:Label runat="server" ID="lblGLAccountId" Text="<%$ Resources:GlobalResource, BankAccount_lblGLAccountId%>"></asp:Label>
                            </div>
                            <div class="input-group">
                                <asp:TextBox ID="txtGLAccount" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>

                                <span class="input-group-addon lookup" id="sizing-addo2">
                                     <a href="#" data-toggle="modal" data-target="#basicModalGLAccountSearch" data-keyboard="false" data-backdrop="static" onclick="CallGLAccountRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtGLAccountGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>


                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label ID="lblNextChequeNumber" runat="server" Text="<%$ Resources:GlobalResource, BankAccount_lblnextChequeNumber%>"></asp:Label>
                            <asp:TextBox  ID="txtNextChckNmbr" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label ID="lblNextDepositNumber" runat="server" Text="<%$ Resources:GlobalResource, BankAccount_lblNextDepositNumber%>"></asp:Label>
                            <asp:TextBox ID="txtNextDepositNumber" runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label ID="lblLastRecouncileBal" runat="server" Text="<%$ Resources:GlobalResource, BankAccount_lblLastRecouncileBal%>"></asp:Label>
                            <asp:TextBox type="text" ID="txtlastRecounciledBal"  runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label ID="lblLastrecounciledDate" runat="server" Text="<%$ Resources:GlobalResource, BankAccount_lblLastrecounciledDate%>"></asp:Label>
                            <asp:TextBox type="text" ID="txtLastRecounciledDate"  runat="server" TextMode="Date" ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label ID="lblAccountNumber" runat="server" Text="<%$ Resources:GlobalResource, BankAccount_lblAccountNumber%>"></asp:Label>
                            <asp:TextBox type="text" ID="txtAccountNumber"  runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">

                            <div>
                                <asp:Label runat="server" ID="lblBankId" Text="<%$ Resources:GlobalResource, BankAccount_lblBankId%>"></asp:Label>
                            </div>

                            <div class="input-group">
                                <asp:TextBox ID="txtBank" ReadOnly="true" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-addon lookup" id="sizing-addon1">
                                     <a href="#" data-toggle="modal" data-target="#basicModalBankSearch" data-keyboard="false" data-backdrop="static" onclick="CallBankRefreshButton();" ">
                                        <i class="fa fa-search"></i>
                                    </a>
                                </span>

                                <asp:TextBox ID="txtBankGuid" runat="server" ClientIDMode="Static" Style="display: none;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group col-md-4 col-sm-4">
                            <asp:Label ID="lblDuplicateChequeNumber" runat="server" Text="<%$ Resources:GlobalResource, BankAccount_lblDuplicateChequeNumber%>"></asp:Label>
                            <asp:TextBox type="text" ID="txtDuplicateChequeNumber"  runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>

                         <div class="form-group col-md-4 col-sm-4">
                            <asp:Label ID="lblOverrideChequeNumber" runat="server" Text="<%$ Resources:GlobalResource, BankAccount_lblOverrideChequeNumber%>"></asp:Label>
                            <asp:TextBox type="text" ID="txtOverrideChequeNmbr"  runat="server" ClientIDMode="Static" class="form-control" placeholder="" required="required" ></asp:TextBox>
                        </div>


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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, BankAccount_htCurrencyCode%>">
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
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,BankAccount_htCurrencyGuid%>" Visible="false">
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

    <div class="modal fade" id="basicModalGLAccountSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalGlAccountTitle"><span>
                        <asp:Literal runat="server" ID="ltrGLAccountTitle" Text="<%$ Resources:GlobalResource, BankAccount_lblGLAccountId%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlGLAccount">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="pnlGLAccount" DefaultButton="btnGLAccountSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtGLAccountSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlGLAccountSearch" onclick="CallGLAccountSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlGLAccountClose" visible="false" onclick="ClearGLAccountSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnGLAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnGLAccountSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearGLAccountSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearGLAccountSearch_Click" formnovalidate="formnovalidate" />

                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divGLAccountSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divGLAccountSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblGLAccountSearchSucces"></asp:Label>
                        </div>
                    </div>
                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgGLAccountData" AssociatedUpdatePanelID="updpnlgvGLAccountSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvGLAccountSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnGLAccountRefresh" ClientIDMode="Static" OnClick="btnGLAccountRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvGLAccountSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, BankAccount_htAccountNumber%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetGLAccountDetails('<%#Eval("AccountNumber")%>','<%#Eval("tbl_GLAccountId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvGLAccountCode" Text='<%# Bind("AccountNumber") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, BankAccount_htGLAccountGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvGLAccountGuid" runat="server" Text='<%# Bind("tbl_GLAccountId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnGLAccountSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearGLAccountSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="divGLAccountFooter">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblGLAccountClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="basicModalBankSearch" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header" style="text-align: left;">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h4 class="modal-title" id="hdrModalBankTitle"><span>
                        <asp:Literal runat="server" ID="Literal1" Text="<%$ Resources:GlobalResource, BankAccount_ltrBankId%>"></asp:Literal>
                    </span>
                    </h4>
                </div>
                <div class="modal-body">

                    <asp:UpdatePanel runat="server" ID="updpnlBank">
                        <ContentTemplate>
                            <asp:Panel runat="server" ID="Panel1" DefaultButton="btnBankSearch">
                                <div class="col-md-4 col-xs-5">
                                    <div class="icon-addon addon-md">
                                        <asp:TextBox runat="server" ID="txtBankSearch" CssClass="form-control" placeholder="Search..." autofocus="autofocus"></asp:TextBox>
                                        <a runat="server" id="btnHtmlBankSearch" onclick="CallBankSearch();" class="fa fa-search"></a>
                                        <a runat="server" id="btnHtmlBankClose" visible="false" onclick="ClearBankSearch();" class="fa fa-close closex"></a>
                                    </div>
                                </div>
                                <asp:Button runat="server" ID="btnBankSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnBankSearch_Click" formnovalidate="formnovalidate" />
                                <asp:Button runat="server" ID="btnClearBankSearch" Style="display: none;" ClientIDMode="Static" OnClick="btnClearBankSearch_Click" />
                            </asp:Panel>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12 col-sm-12 colformstyle3">
                        <div runat="server" id="divBankSearchError" visible="false" class="alert alert-danger" role="alert">
                            <asp:Label runat="server" ID="lblBankSearchError"></asp:Label>
                        </div>
                        <div runat="server" id="divBankSearchSucces" visible="false" class="alert alert-success" role="alert">
                            <asp:Label runat="server" ID="lblBankSearchSucces"></asp:Label>
                        </div>
                    </div>

                    <div>
                        <asp:UpdateProgress runat="server" ID="updProgBankData" AssociatedUpdatePanelID="updpnlgvBankSearch">
                            <ProgressTemplate>
                                Loading...
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel runat="server" ID="updpnlgvBankSearch">
                            <ContentTemplate>
                                <asp:Button runat="server" ID="btnBankRefresh" ClientIDMode="Static" OnClick="btnBankRefresh_Click" Style="display: none;" formnovalidate="formnovalidate" />
                                <asp:GridView ID="gvBankSearch" runat="server" Width="100%" CssClass="table table-hover" AutoGenerateColumns="False"
                                    EmptyDataText="<%$ Resources:GlobalResource,msgNoRecordFound%>" AllowPaging="True" PageSize="10" ClientIDMode="Static">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource, BankAccount_htBankCode%>">
                                            <ItemTemplate>
                                                <a href="#" data-dismiss="modal" onclick="SetBankDetails('<%#Eval("BankName")%>','<%#Eval("tbl_BankId")%>');">
                                                    <asp:Literal runat="server" ID="ltrgvBankCode" Text='<%# Bind("BankCode") %>'></asp:Literal>
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,htName%>">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBankName" runat="server" Text='<%# Bind("BankName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:GlobalResource,BankAccount_htBankGuid%>" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgvBankGuid" runat="server" Text='<%# Bind("tbl_BankId") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#24648f" ForeColor="White" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnBankSearch" />
                                <asp:AsyncPostBackTrigger EventName="Click" ControlID="btnClearBankSearch" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="modal-footer row" runat="server" id="div3">
                    <div class="pull-left">
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <asp:Literal runat="server" ID="lblBankClose" Text="<%$ Resources:GlobalResource, ltrClose %>"></asp:Literal></button>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>